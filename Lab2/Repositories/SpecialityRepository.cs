using Lab2.Data;
using Lab2.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab2.Repositories;

public class SpecialityRepository(AppDbContext context) : ISpecialityRepository
{
    public async Task<Speciality?> GetSpecialityByIdAsync(int id)
    {
        return await context.Specialities.AsNoTracking().FirstOrDefaultAsync(x => x.SpecialityId == id);
    }

    public async Task<IEnumerable<Speciality>> GetAllSpecialitiesAsync()
    {
        return await context.Specialities.AsNoTracking().ToListAsync();
    }

    public async Task AddSpecialityAsync(Speciality speciality)
    {
        await context.Specialities.AddAsync(speciality);
        await context.SaveChangesAsync();
    }

    public async Task UpdateSpecialityAsync(Speciality speciality)
    {
        await context.Specialities.Where(x => x.SpecialityId == speciality.SpecialityId)
            .ExecuteUpdateAsync(setters => setters
                .SetProperty(x => x.Name, speciality.Name)
                .SetProperty(x => x.Abbreviation, speciality.Abbreviation));
    }

    public async Task DeleteSpecialityAsync(int id)
    {
        await context.Specialities.Where(s => s.SpecialityId == id).ExecuteDeleteAsync();
    }

    public async Task<bool> ExistsSpecialityAsync(int id)
    {
        return await context.Specialities.AnyAsync(x => x.SpecialityId == id);
    }

    public async Task<ICollection<Student>> GetGraduatedStudentsBySpecialityAsync(int specialityId)
    {
        return await context.Students
            .Include(s => s.Speciality)
            .Where(s => s.Speciality.SpecialityId == specialityId && s.IsGraduated == true)
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

    public async Task<ICollection<Student>> GetEnrolledStudentsBySpecialityAsync(int specialityId)
    {
        return await context.Students
            .Include(s => s.Speciality)
            .Where(s => s.Speciality.SpecialityId == specialityId && s.IsGraduated == false)
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

    public async Task<ICollection<Student>> GetAllStudentsBySpecialityAsync(int specialityId)
    {
        return await context.Students
            .Include(s => s.Speciality)
            .Where(s => s.Speciality.SpecialityId == specialityId)
            .AsNoTracking()
            .ToListAsync();

    }

    public async Task<ICollection<Student>> GetAllStudentsAsync()
    {
        return await context.Students.AsNoTracking().ToListAsync();
    }
}
