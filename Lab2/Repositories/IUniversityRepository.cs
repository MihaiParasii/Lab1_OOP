using Lab2.Models;

namespace Lab2.Repositories;

public interface IUniversityRepository
{
    Task<List<University>> GetAllUniversitiesAsync();
    Task<University?> GetUniversityByIdAsync(int id);
    Task AddUniversityAsync(University university);
    Task UpdateUniversityAsync(University university);
    Task DeleteUniversityAsync(University university);
    Task<ICollection<Student>> GetGraduatedStudentsByUniversityAsync(int universityId);
    Task<ICollection<Student>> GetGraduatedStudentsAsync();
    Task<ICollection<Student>> GetEnrolledStudentsByUniversityAsync(int universityId);
    Task<ICollection<Student>> GetEnrolledStudentsAsync();
    Task<ICollection<Student>> GetAllStudentsByUniversityAsync(int universityId);
    Task<ICollection<Student>> GetAllStudentsAsync();
}
