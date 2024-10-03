using Lab2.Data;
using Lab2.Models;
using Lab2.Repositories;

namespace Lab2.Services;

public class SpecialityService(IFacultyRepository facultyRepository)
{

    public Speciality? ReadSpeciality()
    {
        Console.WriteLine("Creating Speciality: ");
        Console.WriteLine("Input Speciality Name: ");
        string specialityName = Console.ReadLine()!;
        Console.WriteLine("Input Speciality Abbreviation: ");
        string specialityAbbreviation = Console.ReadLine()!;
        Console.WriteLine("Input Id of Faculty: ");
        int facultyId = int.Parse(Console.ReadLine()!);
        Faculty? faculty = facultyRepository.GetFacultyByIdAsync(facultyId).GetAwaiter().GetResult();

        if (faculty == null)
        {
            return null;
        }

        var speciality = new Speciality(specialityName, specialityAbbreviation, faculty);

        return IsValid(speciality) ? speciality : null;
    }

    public static Speciality? ReadNewSpecialityValues(Speciality speciality)
    {
        Console.WriteLine($"Speciality Name: {speciality.Name}");
        Console.WriteLine("Do you want to change the Speciality Name? y\\n");
        string? response = Console.ReadLine();

        if (response?.ToLower() == "y")
        {
            Console.WriteLine("Input New Speciality Name: ");
            speciality.Name = Console.ReadLine()!;
        }

        Console.WriteLine($"Speciality Abbreviation: {speciality.Abbreviation}");
        Console.WriteLine("Do you want to change the Speciality Abbreviation? y\\n");
        response = Console.ReadLine();

        if (response?.ToLower() == "y")
        {
            Console.WriteLine("Input New Speciality Abbreviation: ");
            speciality.Abbreviation = Console.ReadLine()!;
        }


        return IsValid(speciality) ? speciality : null;
    }

    private static bool IsValid(Speciality speciality)
    {
        return !string.IsNullOrWhiteSpace(speciality.Name) &&
               !string.IsNullOrWhiteSpace(speciality.Abbreviation);
    }
}
