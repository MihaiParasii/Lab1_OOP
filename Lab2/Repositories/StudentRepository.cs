using Lab2.Data;
using Lab2.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab2.Repositories;

public class StudentRepository(AppDbContext context) : IStudentRepository
{
    public async Task AddStudentAsync(Student student)
    {
        context.Students.Add(student);
        await context.SaveChangesAsync();
    }

    public async Task<Student?> GetStudentByIdAsync(int id)
    {
        return await context.Students.AsNoTracking().FirstOrDefaultAsync(s => s.StudentId == id);
    }

    public async Task UpdateStudentAsync(Student student)
    {
        await context.Students
            .Where(s => s.StudentId == student.StudentId)
            .ExecuteUpdateAsync(setters => setters
                .SetProperty(s => s.Email, student.Email)
                .SetProperty(s => s.FirstName, student.FirstName)
                .SetProperty(s => s.LastName, student.LastName)
                .SetProperty(s => s.Speciality, student.Speciality));
    }

    public async Task DeleteStudentAsync(Student student)
    {
        await context.Students.Where(s => s.StudentId == student.StudentId).ExecuteDeleteAsync();
    }

    public async Task<ICollection<Student>> GetEnrolledStudentsAsync()
    {
        return await context.Students
            .Where(s => s.IsGraduated == false)
            .AsNoTracking()
            .ToListAsync();
    }


    public async Task<ICollection<Student>> GetAllStudentsAsync()
    {
        return await context.Students.AsNoTracking().ToListAsync();
    }

    public async Task<bool> ExistsStudentAsync(int id)
    {
        return await context.Students.AnyAsync(s => s.StudentId == id);
    }

    public async Task<ICollection<Student>> GetGraduatedStudentsAsync()
    {
        return await context.Students
            .Where(s => s.IsGraduated == true)
            .AsNoTracking()
            .ToListAsync();
    }
}
