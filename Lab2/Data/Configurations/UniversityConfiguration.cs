using Lab2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab2.Data.Configurations;

public class UniversityConfiguration : IEntityTypeConfiguration<University>
{
    public void Configure(EntityTypeBuilder<University> builder)
    {
        builder.Property(u => u.UniversityId).UseIdentityAlwaysColumn();
        builder.Property(u => u.Name).IsRequired();
        builder.HasMany(u => u.Faculties).WithOne(f => f.University).OnDelete(DeleteBehavior.Cascade);
    }
}
