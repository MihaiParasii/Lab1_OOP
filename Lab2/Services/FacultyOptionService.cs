using Lab2.Models;
using Lab2.Repositories;
using static System.Int32;

namespace Lab2.Services;

public class FacultyOptionService(ISpecialityRepository specialityRepository, IFacultyRepository facultyRepository)
{
    private readonly SpecialityService _specialityService = new SpecialityService(facultyRepository);

    public async Task<bool> CreateSpecialityAsync()
    {
        var speciality = _specialityService.ReadSpeciality();

        if (speciality == null)
        {
            return false;
        }

        await specialityRepository.AddSpecialityAsync(speciality);
        return true;
    }

    public async Task<bool> UpdateSpecialityAsync()
    {
        Console.WriteLine("Enter the ID of the Speciality to update: ");
        int specialityId = Parse(Console.ReadLine() ?? "0");

        if (specialityId <= 0)
        {
            return false;
        }

        var speciality = await specialityRepository.GetSpecialityByIdAsync(specialityId);

        if (speciality == null)
        {
            return false;
        }

        speciality = SpecialityService.ReadNewSpecialityValues(speciality);

        if (speciality == null)
        {
            return false;
        }

        await specialityRepository.UpdateSpecialityAsync(speciality);
        return true;
    }

    public async Task<bool> RemoveSpecialityAsync()
    {
        Console.WriteLine("Enter the ID of the Speciality to remove: ");
        int specialityId = Parse(Console.ReadLine() ?? "0");

        if (specialityId <= 0)
        {
            return false;
        }

        var speciality = await specialityRepository.GetSpecialityByIdAsync(specialityId);

        if (speciality == null)
        {
            return false;
        }

        await specialityRepository.DeleteSpecialityAsync(specialityId);

        return true;
    }

    public async Task DisplayAllSpecialitiesAsync()
    {
        var specialities = await specialityRepository.GetAllSpecialitiesAsync();

        foreach (var speciality in specialities)
        {
            Console.WriteLine(speciality.ToString());
        }
    }

    public async Task DisplaySpecialityInfoAsync()
    {
        Console.WriteLine("Enter the ID of the Speciality to show information: ");
        int specialityId = Parse(Console.ReadLine() ?? "0");

        var speciality = await specialityRepository.GetSpecialityByIdAsync(specialityId);

        if (speciality == null)
        {
            Console.WriteLine("Speciality not found.");
            return;
        }

        Console.WriteLine(speciality.ToString());
    }

    public async Task DisplayGraduatedStudentsAsync()
    {
        await Choose(specialityRepository.GetGraduatedStudentsAsync,
            specialityRepository.GetAllStudentsBySpecialityAsync);
    }

    public async Task DisplayEnrolledStudentsAsync()
    {
        await Choose(specialityRepository.GetEnrolledStudentsAsync,
            specialityRepository.GetEnrolledStudentsBySpecialityAsync);
    }

    public async Task DisplayAllStudentsAsync()
    {
        await Choose(specialityRepository.GetAllStudentsAsync, specialityRepository.GetAllStudentsBySpecialityAsync);
    }

    private static async Task Choose(GetStudents getStudents, GetStudentsByUniversity getStudentsByUniversity)
    {
        Console.WriteLine("Do you want from the certain Speciality y\\n: ");
        string choice = Console.ReadLine()!;

        if (choice.Equals("y", StringComparison.CurrentCultureIgnoreCase))
        {
            Console.WriteLine("Enter the ID of the Speciality: ");
            int specialityId = Parse(Console.ReadLine() ?? "0");

            if (specialityId <= 0)
            {
                Console.WriteLine("Invalid ID. Please try again.");
                return;
            }

            PrintStudents(await getStudentsByUniversity(specialityId));
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
