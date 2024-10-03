using Lab2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab2.Data.Configurations;

public class SpecialityConfiguration : IEntityTypeConfiguration<Speciality>
{
    public void Configure(EntityTypeBuilder<Speciality> builder)
    {
        builder.Property(u => u.SpecialityId).UseIdentityAlwaysColumn();
        builder.HasMany<Student>(s => s.Students).WithOne(s => s.Speciality);
    }
}
