using KT.Domain.StudentAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KT.Infrastructure.Persistence.Configurations;

public class StudentConfigurations : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        ConfigureStudentTable(builder);
    }

    private static void ConfigureStudentTable(EntityTypeBuilder<Student> builder)
    {
        // Configure the table name
        builder.ToTable("Students", "Student");

        // Configure the primary key
        builder.HasKey(s => s.Id);
        builder.Property(p => p.Id).ValueGeneratedNever();
        
        // Configure other properties
        builder.Property(s => s.Forename)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(s => s.Surname)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(s => s.DateOfBirth)
            .IsRequired();

        builder.OwnsOne(s => s.ContactDetails, cd =>
        {
            cd.Property(c => c.Email)
                .HasMaxLength(100)
                .IsRequired();

            cd.Property(c => c.Phone)
                .HasMaxLength(20)
                .IsRequired();

            cd.Property(c => c.ContactPreference)
                .IsRequired();
        });

        builder.OwnsOne(s => s.Address, a =>
        {
            a.Property(ad => ad.Line1)
                .HasMaxLength(100)
                .IsRequired();

            a.Property(ad => ad.Line2)
                .HasMaxLength(100);

            a.Property(ad => ad.City)
                .HasMaxLength(100);

            a.Property(ad => ad.County)
                .IsRequired();

            a.Property(ad => ad.Postcode)
                .HasMaxLength(10)
                .IsRequired();
        });

        // Configure relationships (if any)

        // Configure indexes (if any)
    }
}