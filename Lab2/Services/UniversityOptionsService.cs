using Lab2.Data;
using Lab2.Models;
using Lab2.Repositories;
using static System.Int32;

namespace Lab2.Services;

public class UniversityOptionsService(IFacultyRepository facultyRepository, IUniversityRepository universityRepository)
{
    public async Task<bool> CreateFacultyAsync()
    {
        Console.WriteLine("Creating Faculty: ");
        Console.WriteLine("Input Faculty Name: ");
        string facultyName = Console.ReadLine()!;
        Console.WriteLine("Input Faculty Abbreviation: ");
        string facultyAbbreviation = Console.ReadLine()!;
        Console.WriteLine("Input Id of University: ");
        int universityId = Parse(Console.ReadLine()!);
        University? university = await universityRepository.GetUniversityByIdAsync(universityId);

        var faculty = new Faculty
        {
            Name = facultyName,
            Abbreviation = facultyAbbreviation,
            University = university ?? throw new InvalidOperationException("Invalid University")
        };


        if (faculty == null)
        {
            return false;
        }


        await facultyRepository.AddFacultyAsync(faculty);
        return true;
    }

    public async Task<bool> UpdateFacultyAsync()
    {
        Console.WriteLine("Enter the ID of the Faculty to update: ");
        int facultyId = Parse(Console.ReadLine() ?? "0");

        if (facultyId <= 0)
        {
            return false;
        }

        var faculty = await facultyRepository.GetFacultyByIdAsync(facultyId);

        if (faculty == null)
        {
            return false;
        }

        faculty = FacultyService.ReadNewFacultyValues(faculty);

        if (faculty == null)
        {
            return false;
        }

        await facultyRepository.UpdateFacultyAsync(faculty);
        return true;
    }

    public async Task<bool> RemoveFacultyAsync()
    {
        Console.WriteLine("Enter the ID of the Faculty to remove: ");
        int facultyId = Parse(Console.ReadLine() ?? "0");

        if (facultyId <= 0)
        {
            return false;
        }

        var faculty = await facultyRepository.GetFacultyByIdAsync(facultyId);

        if (faculty == null)
        {
            return false;
        }

        await facultyRepository.DeleteFacultyAsync(facultyId);

        return true;
    }

    public async Task DisplayAllFacultiesAsync()
    {
        var faculties = await facultyRepository.GetAllFacultiesAsync();

        foreach (var faculty in faculties)
        {
            Console.WriteLine(faculty.ToString());
        }
    }

    public async Task DisplayFacultyInfoAsync()
    {
        Console.WriteLine("Enter the ID of the Faculty to show information: ");
        int facultyId = Parse(Console.ReadLine() ?? "0");

        var faculty = await facultyRepository.GetFacultyByIdAsync(facultyId);

        if (faculty == null)
        {
            Console.WriteLine("Faculty not found.");
            return;
        }

        Console.WriteLine(faculty.ToString());
    }

    public async Task DisplayGraduatedStudentsAsync()
    {
        await Choose(facultyRepository.GetGraduatedStudentsAsync,
            facultyRepository.GetGraduatedStudentsByFacultyAsync);
    }

    public async Task DisplayEnrolledStudentsAsync()
    {
        await Choose(facultyRepository.GetEnrolledStudentsAsync,
            facultyRepository.GetEnrolledStudentsByFacultyAsync);
    }

    public async Task DisplayAllStudentsAsync()
    {
        await Choose(facultyRepository.GetAllStudentsAsync, facultyRepository.GetAllStudentsByFacultyAsync);
    }

    private static async Task Choose(GetStudents getStudents, GetStudentsByUniversity getStudentsByUniversity)
    {
        Console.WriteLine("Do you want from the certain Faculty y\\n: ");
        string choice = Console.ReadLine()!;

        if (choice.Equals("y", StringComparison.CurrentCultureIgnoreCase))
        {
            Console.WriteLine("Enter the ID of the Faculty: ");
            int facultyId = Parse(Console.ReadLine() ?? "0");

            if (facultyId <= 0)
            {
                Console.WriteLine("Invalid ID. Please try again.");
                return;
            }

            PrintStudents(await getStudentsByUniversity(facultyId));
        }
        else if (choice.Equals("n", StringComparison.CurrentCultureIgnoreCase))
        {
            PrintStudents(await getStudents());
        }
    }


    private static void PrintStudents(IEnumerable<Student> students)
    {
        foreach (var student in students)
        {
            Console.WriteLine(student.ToString());
        }
    }

    private delegate Task<ICollection<Student>> GetStudentsByUniversity(int universityId);

    private delegate Task<ICollection<Student>> GetStudents();
}
