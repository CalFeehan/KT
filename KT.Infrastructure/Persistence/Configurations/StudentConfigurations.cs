using System.Text.Json;
using KT.Domain.Common.ValueObjects;
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

        builder.Property(s => s.Address)
            .IsRequired()
            .HasConversion(
                a => JsonSerializer.Serialize(a, new JsonSerializerOptions()),
                a => JsonSerializer.Deserialize<Address>(a, new JsonSerializerOptions())
            );
        
        builder.Property(s => s.ContactDetails)
            .IsRequired()
            .HasConversion(
                cd => JsonSerializer.Serialize(cd, new JsonSerializerOptions()),
                cd => JsonSerializer.Deserialize<ContactDetails>(cd, new JsonSerializerOptions())
            );
        
        // Configure relationships (if any)

        // Configure indexes (if any)
    }
}