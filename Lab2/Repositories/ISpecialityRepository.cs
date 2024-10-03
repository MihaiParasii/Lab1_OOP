using Lab2.Models;

namespace Lab2.Repositories;

public interface ISpecialityRepository
{
    Task<Speciality?> GetSpecialityByIdAsync(int id);
    Task<IEnumerable<Speciality>> GetAllSpecialitiesAsync();
    Task AddSpecialityAsync(Speciality speciality);
    Task UpdateSpecialityAsync(Speciality speciality);
    Task DeleteSpecialityAsync(int id);
    Task<bool> ExistsSpecialityAsync(int id);
    Task<ICollection<Student>> GetGraduatedStudentsBySpecialityAsync(int specialityId);
    Task<ICollection<Student>> GetGraduatedStudentsAsync();
    Task<ICollection<Student>> GetEnrolledStudentsBySpecialityAsync(int specialityId);
    Task<ICollection<Student>> GetEnrolledStudentsAsync();
    Task<ICollection<Student>> GetAllStudentsBySpecialityAsync(int specialityId);
    Task<ICollection<Student>> GetAllStudentsAsync();
}
