using Lab2.Data;
using Lab2.Models;
using Lab2.Repositories;

namespace Lab2.Services;

public class StudentService(ISpecialityRepository specialityRepository)
{

    public  Student? ReadStudent()
    {
        Console.WriteLine("Creating Student: ");
        Console.WriteLine("Input Student First Name: ");
        string studentFirstName = Console.ReadLine()!;
        
        Console.WriteLine("Input Student Last Name: ");
        string studentLastName = Console.ReadLine()!;
        
        Console.WriteLine("Input Student Birth Date: ");
        string studentBirthDateString = Console.ReadLine()!;
        DateOnly studentBirthDate = DateOnly.Parse(studentBirthDateString);
        
        Console.WriteLine("Input Id of Speciality: ");
        int specialityId = int.Parse(Console.ReadLine()!);


        Speciality? speciality = specialityRepository.GetSpecialityByIdAsync(specialityId).GetAwaiter().GetResult();

        if (speciality == null)
        {
            return null;
        }

        var student = new Student(studentFirstName, studentLastName, studentBirthDate, speciality);

        return IsValid(student) ? student : null;
    }

    public static Student? ReadNewStudentValues(Student student)
    {
        Console.WriteLine($"Student First Name: {student.FirstName}");
        Console.WriteLine("Do you want to change the Student First Name? y\\n");
        string? response = Console.ReadLine();

        if (response?.ToLower() == "y")
        {
            Console.WriteLine("Input New Student First Name: ");
            student.FirstName = Console.ReadLine()!;
        }

        Console.WriteLine($"Student Last Name: {student.LastName}");
        Console.WriteLine("Do you want to change the Student Last Name? y\\n");
        response = Console.ReadLine();

        if (response?.ToLower() == "y")
        {
            Console.WriteLine("Input New Student Last Name: ");
            student.LastName = Console.ReadLine()!;
        }
        
        Console.WriteLine($"Student Birth Date: {student.BirthDate.ToString()}");
        Console.WriteLine("Do you want to change the Student Birth Date? y\\n");
        response = Console.ReadLine();

        if (response?.ToLower() == "y")
        {
            Console.WriteLine("Input New Student Birth Date: ");
            student.BirthDate = DateOnly.Parse(Console.ReadLine()!);
        }

        return IsValid(student) ? student : null;
    }

    private static bool IsValid(Student student)
    {
        return !string.IsNullOrWhiteSpace(student.FirstName) &&
               !string.IsNullOrWhiteSpace(student.LastName);
    }
}
