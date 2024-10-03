using Lab2.Data;
using Lab2.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab2.Repositories;

public class FacultyRepository(AppDbContext context) : IFacultyRepository
{
    public async Task<Faculty?> GetFacultyByIdAsync(int id)
    {
        return await context.Faculties.Include(f => f.University).AsNoTracking()
            .FirstOrDefaultAsync(f => f.FacultyId == id);
    }

    public async Task<IEnumerable<Faculty>> GetAllFacultiesAsync()
    {
        return await context.Faculties.Include(f => f.University).AsNoTracking().ToListAsync();
    }

    public async Task AddFacultyAsync(Faculty faculty)
    {
        Console.WriteLine("1");
        await context.AddAsync(faculty);
        Console.WriteLine("2");
        await context.SaveChangesAsync();
        Console.WriteLine("3");
    }

    public async Task UpdateFacultyAsync(Faculty faculty)
    {
        await context.Faculties.Where(f => f.FacultyId == faculty.FacultyId)
            .ExecuteUpdateAsync(setters => setters
                .SetProperty(f => f.Name, faculty.Name)
                .SetProperty(f => f.Abbreviation, faculty.Abbreviation));
    }

    public async Task DeleteFacultyAsync(int id)
    {
        await context.Faculties.Where(f => f.FacultyId == id).ExecuteDeleteAsync();
    }

    public async Task<ICollection<Student>> GetGraduatedStudentsAsync()
    {
        return await context.Students
            .Where(s => s.IsGraduated == true)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<ICollection<Student>> GetGraduatedStudentsByFacultyAsync(int facultyId)
    {
        return await context.Students
            .Include(s => s.Speciality)
            .ThenInclude(s => s.Faculty)
            .Where(s => s.Speciality.Faculty.FacultyId == facultyId && s.IsGraduated == true)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<ICollection<Student>> GetEnrolledStudentsAsync()
    {
        return await context.Students
            .Where(s => s.IsGraduated == false)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<ICollection<Student>> GetEnrolledStudentsByFacultyAsync(int facultyId)
    {
        return await context.Students
            .Include(s => s.Speciality)
            .ThenInclude(s => s.Faculty)
            .ThenInclude(f => f.University)
            .Where(s => s.Speciality.Faculty.FacultyId == facultyId && s.IsGraduated == false)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<ICollection<Student>> GetAllStudentsAsync()
    {
        return await context.Students.AsNoTracking().ToListAsync();
    }

    public async Task<ICollection<Student>> GetAllStudentsByFacultyAsync(int facultyId)
    {
        return await context.Students
            .Include(s => s.Speciality)
            .ThenInclude(s => s.Faculty)
            .Where(s => s.Speciality.Faculty.FacultyId == facultyId)
            .AsNoTracking()
            .ToListAsync();
    }
}
