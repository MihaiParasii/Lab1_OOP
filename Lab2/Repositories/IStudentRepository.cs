using Lab2.Models;

namespace Lab2.Repositories;

public interface IStudentRepository
{
    Task AddStudentAsync(Student student);
    Task<Student?> GetStudentByIdAsync(int id);
    Task UpdateStudentAsync(Student student);
    Task DeleteStudentAsync(Student student);
    Task<bool> ExistsStudentAsync(int id);
    Task<ICollection<Student>> GetGraduatedStudentsAsync();
    Task<ICollection<Student>> GetEnrolledStudentsAsync();
    Task<ICollection<Student>> GetAllStudentsAsync();

}
