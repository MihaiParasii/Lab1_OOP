using Lab2.Models;

namespace Lab2.Services;

public static class UniversityService
{
    public static University? ReadUniversity()
    {
        Console.WriteLine("Creating University:");
        Console.WriteLine("Input University Name: ");
        string universityName = Console.ReadLine()!;
        Console.WriteLine("Input University Abbreviation: ");
        string universityAbbreviation = Console.ReadLine()!;
        Console.WriteLine("Input University Street: ");
        string universityStreet = Console.ReadLine()!;

        var university = new University(universityName, universityStreet, universityAbbreviation);

        return IsValid(university) ? university : null;
    }

    public static University? ReadNewUniversityValues(University university)
    {
        Console.WriteLine($"University Name: {university.Name}");
        Console.WriteLine("Do you want to change the University Name? y\\n");
        string? response = Console.ReadLine();

        if (response?.ToLower() == "y")
        {
            Console.WriteLine("Input New University Name: ");
            university.Name = Console.ReadLine()!;
        }

        Console.WriteLine($"University Abbreviation: {university.Abbreviation}");
        Console.WriteLine("Do you want to change the University Abbreviation? y\\n");
        response = Console.ReadLine();

        if (response?.ToLower() == "y")
        {
            Console.WriteLine("Input New University Abbreviation: ");
            university.Abbreviation = Console.ReadLine()!;
        }

        Console.WriteLine($"University Address: {university.Address}");
        Console.WriteLine("Do you want to change the University Address? y\\n");
        response = Console.ReadLine();

        if (response?.ToLower() == "y")
        {
            Console.WriteLine("Input New University Address: ");
            university.Address = Console.ReadLine()!;
        }

        return IsValid(university) ? university : null;
    }

    private static bool IsValid(University university)
    {
        return !string.IsNullOrWhiteSpace(university.Name) &&
               !string.IsNullOrWhiteSpace(university.Abbreviation) &&
               !string.IsNullOrWhiteSpace(university.Address);
    }
}
