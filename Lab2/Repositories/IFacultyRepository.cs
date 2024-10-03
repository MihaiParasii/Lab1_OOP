using Lab2.Models;

namespace Lab2.Repositories;

public interface IFacultyRepository
{
    Task<Faculty?> GetFacultyByIdAsync(int id);
    Task<IEnumerable<Faculty>> GetAllFacultiesAsync();
    Task AddFacultyAsync(Faculty faculty);
    Task UpdateFacultyAsync(Faculty faculty);
    Task DeleteFacultyAsync(int id);
    Task<ICollection<Student>> GetGraduatedStudentsAsync();
    Task<ICollection<Student>> GetGraduatedStudentsByFacultyAsync(int universityid);
    Task<ICollection<Student>> GetEnrolledStudentsAsync();
    Task<ICollection<Student>> GetEnrolledStudentsByFacultyAsync(int facultyId);
    Task<ICollection<Student>> GetAllStudentsAsync();
    Task<ICollection<Student>> GetAllStudentsByFacultyAsync(int facultyId);
}
