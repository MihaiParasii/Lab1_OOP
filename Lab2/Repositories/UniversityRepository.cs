using Lab2.Data;
using Lab2.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab2.Repositories;

public class UniversityRepository(AppDbContext context) : IUniversityRepository
{
    public async Task<List<University>> GetAllUniversitiesAsync()
    {
        return await context.Universities.AsNoTracking().ToListAsync();
    }

    public async Task<University?> GetUniversityByIdAsync(int id)
    {
        return await context.Universities.AsNoTracking().FirstOrDefaultAsync(x => x.UniversityId == id);
    }

    public async Task AddUniversityAsync(University university)
    {
        await context.Universities.AddAsync(university);
        await context.SaveChangesAsync();
    }

    public async Task UpdateUniversityAsync(University university)
    {
        await context.Universities
            .Where(u => u.UniversityId == university.UniversityId)
            .ExecuteUpdateAsync(setters => setters
                .SetProperty(u => u.Name, university.Name)
                .SetProperty(u => u.Abbreviation, university.Abbreviation)
                .SetProperty(u => u.Address, university.Address));
    }

    public async Task DeleteUniversityAsync(University university)
    {
        await context.Universities.Where(u => u.UniversityId == university.UniversityId).ExecuteDeleteAsync();
    }

    public async Task<ICollection<Student>> GetGraduatedStudentsByUniversityAsync(int universityId)
    {
        return await context.Students
            .Include(s => s.Speciality)
            .ThenInclude(s => s.Faculty)
            .ThenInclude(f => f.University)
            .Where(s => s.Speciality.Faculty.University.UniversityId == universityId && s.IsGraduated == true)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<ICollection<Student>> GetGraduatedStudentsAsync()
    {
        return await context.Students
            .Where(s => s.IsGraduated == true)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<ICollection<Student>> GetEnrolledStudentsByUniversityAsync(int universityId)
    {
        return await context.Students
            .Include(s => s.Speciality)
            .ThenInclude(s => s.Faculty)
            .ThenInclude(f => f.University)
            .Where(s => s.Speciality.Faculty.University.UniversityId == universityId && s.IsGraduated == false)
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

    public async Task<ICollection<Student>> GetAllStudentsByUniversityAsync(int universityId)
    {
        return await context.Students
            .Include(s => s.Speciality)
            .ThenInclude(s => s.Faculty)
            .ThenInclude(f => f.University)
            .Where(s => s.Speciality.Faculty.University.UniversityId == universityId)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<ICollection<Student>> GetAllStudentsAsync()
    {
        return await context.Students.AsNoTracking().ToListAsync();
    }
}
