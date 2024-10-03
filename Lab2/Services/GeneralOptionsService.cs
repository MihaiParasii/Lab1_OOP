using Lab2.Models;
using Lab2.Repositories;
using static System.Int32;


namespace Lab2.Services;

public class GeneralOptionsService(IUniversityRepository universityRepository)
{
    public async Task<bool> CreateUniversityAsync()
    {
        var university = UniversityService.ReadUniversity();

        if (university == null)
        {
            return false;
        }

        await universityRepository.AddUniversityAsync(university);
        return true;
    }

    public async Task<bool> UpdateUniversityAsync()
    {
        Console.WriteLine("Enter the ID of the university to update: ");
        int universityId = Parse(Console.ReadLine() ?? "0");

        if (universityId <= 0)
        {
            return false;
        }

        var university = await universityRepository.GetUniversityByIdAsync(universityId);

        if (university == null)
        {
            return false;
        }

        university = UniversityService.ReadNewUniversityValues(university);

        if (university == null)
        {
            return false;
        }

        await universityRepository.UpdateUniversityAsync(university);
        return true;
    }

    public async Task DisplayAllUniversitiesAsync()
    {
        var universities = await universityRepository.GetAllUniversitiesAsync();

        foreach (var university in universities)
        {
            Console.WriteLine(university.ToStringShortly());
        }
    }

    public async Task DisplayUniversityInfoAsync()
    {
        Console.WriteLine("Enter the ID of the university to show information: ");
        int universityId = Parse(Console.ReadLine() ?? "0");

        var university = await universityRepository.GetUniversityByIdAsync(universityId);

        if (university == null)
        {
            Console.WriteLine("University not found.");
            return;
        }

        Console.WriteLine(university.ToString());
    }

    public async Task DisplayGraduatedStudentsAsync()
    {
        await Choose(universityRepository.GetGraduatedStudentsAsync,
            universityRepository.GetGraduatedStudentsByUniversityAsync);
    }

    public async Task DisplayEnrolledStudentsAsync()
    {
        await Choose(universityRepository.GetEnrolledStudentsAsync,
            universityRepository.GetEnrolledStudentsByUniversityAsync);
    }

    public async Task DisplayAllStudentsAsync()
    {
        await Choose(universityRepository.GetAllStudentsAsync, universityRepository.GetAllStudentsByUniversityAsync);
    }

    private static async Task Choose(GetStudents getStudents, GetStudentsByUniversity getStudentsByUniversity)
    {
        Console.WriteLine("Do you want from the certain university y\\n: ");
        string choice = Console.ReadLine()!;

        if (choice.Equals("y", StringComparison.CurrentCultureIgnoreCase))
        {
            Console.WriteLine("Enter the ID of the university: ");
            int universityId = Parse(Console.ReadLine() ?? "0");

            if (universityId <= 0)
            {
                Console.WriteLine("Invalid ID. Please try again.");
                return;
            }

            PrintStudents(await getStudentsByUniversity(universityId));
        }
        else if (choice.Equals("n", StringComparison.CurrentCultureIgnoreCase))
        {
            PrintStudents(await getStudents());
        }
    }


    private static void PrintStudents(ICollection<Student> students)
    {
        if (students.Count != 0)
        {
            foreach (var student in students)
            {
                Console.WriteLine(student.ToString());
            }
            return;
        }
        Console.WriteLine("No students found.");
    }

    private delegate Task<ICollection<Student>> GetStudentsByUniversity(int universityId);

    private delegate Task<ICollection<Student>> GetStudents();
}
