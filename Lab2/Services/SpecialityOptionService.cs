using Lab2.Models;
using Lab2.Repositories;
using static System.Int32;

namespace Lab2.Services;

public class SpecialityOptionService(IStudentRepository studentRepository, ISpecialityRepository specialityRepository)
{
    private readonly StudentService _studentService = new StudentService(specialityRepository);
    public async Task<bool> CreateStudentAsync()
    {
        var student = _studentService.ReadStudent();

        if (student == null)
        {
            return false;
        }

        await studentRepository.AddStudentAsync(student);
        return true;
    }

    public async Task<bool> UpdateStudentAsync()
    {
        Console.WriteLine("Enter the ID of the Student to update: ");
        int studentId = Parse(Console.ReadLine() ?? "0");

        if (studentId <= 0)
        {
            return false;
        }

        var student = await studentRepository.GetStudentByIdAsync(studentId);

        if (student == null)
        {
            return false;
        }

        student = StudentService.ReadNewStudentValues(student);

        if (student == null)
        {
            return false;
        }

        await studentRepository.UpdateStudentAsync(student);
        return true;
    }

    public async Task<bool> RemoveStudentAsync()
    {
        Console.WriteLine("Enter the ID of the Student to remove: ");
        int studentId = Parse(Console.ReadLine() ?? "0");

        if (studentId <= 0)
        {
            return false;
        }

        var student = await studentRepository.GetStudentByIdAsync(studentId);

        if (student == null)
        {
            return false;
        }

        await studentRepository.DeleteStudentAsync(student);

        return true;
    }


    public async Task DisplayStudentInfoAsync()
    {
        Console.WriteLine("Enter the ID of the Student to show information: ");
        int studentId = Parse(Console.ReadLine() ?? "0");

        var student = await studentRepository.GetStudentByIdAsync(studentId);

        if (student == null)
        {
            Console.WriteLine("Student not found.");
            return;
        }

        Console.WriteLine(student.ToString());
    }

    public async Task DisplayGraduatedStudentsAsync()
    {
        await Choose(studentRepository.GetGraduatedStudentsAsync);
    }

    public async Task DisplayEnrolledStudentsAsync()
    {
        await Choose(studentRepository.GetEnrolledStudentsAsync);
    }

    public async Task DisplayAllStudentsAsync()
    {
        await Choose(studentRepository.GetAllStudentsAsync);
    }

    public async Task ChangeStudentSpecialityAsync()
    {
        Console.WriteLine("Enter the ID of the Student to change speciality: ");
        int studentId = Parse(Console.ReadLine()?? "0");

        if (studentId <= 0)
        {
            return;
        }

        var student = await studentRepository.GetStudentByIdAsync(studentId);

        if (student == null)
        {
            Console.WriteLine("Student not found.");
            return;
        }

        Console.WriteLine("Enter the ID of the Speciality to change to: ");
        int specialityId = Parse(Console.ReadLine()?? "0");
        
        if (specialityId <= 0)
        {
            return;
        }

        var speciality = await specialityRepository.GetSpecialityByIdAsync(specialityId);

        if (speciality == null)
        {
            Console.WriteLine("Speciality not found.");
            return;
        }

        student.Speciality = speciality;
        await studentRepository.UpdateStudentAsync(student);
        Console.WriteLine($"Student {student.FirstName} {student.LastName} changed to {speciality}");
    }

    public async Task GraduateStudentAsync()
    {
        Console.WriteLine("Enter the ID of the Student to graduate: ");
        int studentId = Parse(Console.ReadLine() ?? "0");
        
        if (studentId <= 0)
        {
            return;
        }
        
        var student = await studentRepository.GetStudentByIdAsync(studentId);

        if (student == null)
        {
            Console.WriteLine("Student not found.");
            return;
        }

        student.IsGraduated = true;
        await studentRepository.UpdateStudentAsync(student);
        Console.WriteLine($"Student {student.FirstName} {student.LastName} is graduated successfully.");
    }

    private static async Task Choose(GetStudents getStudents)
    {
        PrintStudents(await getStudents());
    }

    private static void PrintStudents(IEnumerable<Student> students)
    {
        foreach (var student in students)
        {
            Console.WriteLine(student.ToString());
        }
    }

    private delegate Task<ICollection<Student>> GetStudents();
}
