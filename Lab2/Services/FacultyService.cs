using Lab2.Data;
using Lab2.Models;
using Lab2.Repositories;

namespace Lab2.Services;

public class FacultyService(IUniversityRepository universityRepository)
{

    public Faculty? ReadFaculty()
    {
        Console.WriteLine("Creating Faculty: ");
        Console.WriteLine("Input Faculty Name: ");
        string facultyName = Console.ReadLine()!;
        Console.WriteLine("Input Faculty Abbreviation: ");
        string facultyAbbreviation = Console.ReadLine()!;
        Console.WriteLine("Input Id of University: ");
        int universityId = int.Parse(Console.ReadLine()!);
        University? university = universityRepository.GetUniversityByIdAsync(universityId).GetAwaiter().GetResult();

        var faculty = new Faculty
        {
            Name = facultyName,
            Abbreviation = facultyAbbreviation,
            University = university?? throw new InvalidOperationException("Invalid University")
        };

        return IsValid(faculty) ? faculty : null;
    }

    public static Faculty? ReadNewFacultyValues(Faculty faculty)
    {
        Console.WriteLine($"Faculty Name: {faculty.Name}");
        Console.WriteLine("Do you want to change the Faculty Name? y\\n");
        string? response = Console.ReadLine();

        if (response?.ToLower() == "y")
        {
            Console.WriteLine("Input New Faculty Name: ");
            faculty.Name = Console.ReadLine()!;
        }

        Console.WriteLine($"Faculty Abbreviation: {faculty.Abbreviation}");
        Console.WriteLine("Do you want to change the Faculty Abbreviation? y\\n");
        response = Console.ReadLine();

        if (response?.ToLower() == "y")
        {
            Console.WriteLine("Input New Faculty Abbreviation: ");
            faculty.Abbreviation = Console.ReadLine()!;
        }


        return IsValid(faculty) ? faculty : null;
    }

    private static bool IsValid(Faculty faculty)
    {
        return !string.IsNullOrWhiteSpace(faculty.Name) &&
               !string.IsNullOrWhiteSpace(faculty.Abbreviation);
    }
}
