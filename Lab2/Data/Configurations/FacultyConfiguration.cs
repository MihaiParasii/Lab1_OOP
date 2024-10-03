using Lab2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab2.Data.Configurations;

public class FacultyConfiguration : IEntityTypeConfiguration<Faculty>
{
    public void Configure(EntityTypeBuilder<Faculty> builder)
    {
        builder.HasKey(f => f.FacultyId);
        builder.Property(f => f.FacultyId).UseIdentityAlwaysColumn();
        
        builder.HasOne(f => f.University).WithMany(u => u.Faculties);
        builder.HasMany(f => f.Specialities).WithOne(s => s.Faculty);

        builder.Property(f => f.Name).HasMaxLength(30).IsRequired();
        builder.Property(f => f.Abbreviation).HasMaxLength(10).IsRequired();
        builder.ToTable("Faculties");
    }
}
