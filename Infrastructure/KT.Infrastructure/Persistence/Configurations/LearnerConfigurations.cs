using System.Text.Json;
using KT.Domain.Common.ValueObjects;
using KT.Domain.LearnerAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KT.Infrastructure.Persistence.Configurations;

public class LearnerConfigurations : IEntityTypeConfiguration<Learner>
{
    public void Configure(EntityTypeBuilder<Learner> builder)
    {
        ConfigureLearnerTable(builder);
    }

    private static void ConfigureLearnerTable(EntityTypeBuilder<Learner> builder)
    {
        // Configure the table name
        builder.ToTable("Learners", "Learner");

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
                a => JsonSerializer.Deserialize<Address>(a, new JsonSerializerOptions())!
            );
        
        builder.Property(s => s.ContactDetails)
            .IsRequired()
            .HasConversion(
                cd => JsonSerializer.Serialize(cd, new JsonSerializerOptions()),
                cd => JsonSerializer.Deserialize<ContactDetails>(cd, new JsonSerializerOptions())!
            );
        
        // Configure relationships (if any)

        // Configure indexes (if any)
    }
}