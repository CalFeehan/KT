using System.Text.Json;
using KT.Domain.CourseAggregate;
using KT.Domain.CourseAggregate.ValueObjects;
using KT.Domain.LearnerAggregate;
using KT.Domain.SessionAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KT.Infrastructure.Persistence.Configurations;

public class CourseConfigurations : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        ConfigureCourseTable(builder);
        ConfigureModulesTable(builder);
    }

    private static void ConfigureCourseTable(EntityTypeBuilder<Course> builder)
    {
        builder.ToTable("Courses", "Course");

        // Configure the primary key
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedNever();

        // Configure the properties
        builder.Property(c => c.LearnerId).IsRequired();
        builder.Property(c => c.Code).IsRequired().HasMaxLength(25);
        builder.Property(c => c.Title).IsRequired().HasMaxLength(100);
        builder.Property(c => c.Description).IsRequired().HasMaxLength(500);
        builder.Property(c => c.Level).IsRequired();
        builder.Property(c => c.CourseStatus).IsRequired();

        // Configure relationships (if any)
        builder.HasOne<Learner>()
            .WithMany()
            .HasForeignKey(c => c.LearnerId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany<Session>()
            .WithOne()
            .HasForeignKey(c => c.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configure indexes (if any)
    }

    private static void ConfigureModulesTable(EntityTypeBuilder<Course> builder)
    {
        builder.OwnsMany(c => c.Modules, module =>
        {
            module.ToTable("Modules", "Course");

            module.HasKey(m => m.Id);
            module.Property(m => m.Id).ValueGeneratedNever();

            module.Property(m => m.Title).IsRequired().HasMaxLength(100);
            module.Property(m => m.Code).IsRequired().HasMaxLength(25);
            module.Property(m => m.Description).IsRequired().HasMaxLength(500);
            module.Property(m => m.Level).IsRequired();
            module.Property(m => m.AwardingOrganisation).IsRequired();
            module.Property(m => m.ModuleStatus).IsRequired();

            module.Property(m => m.Criteria)
                .IsRequired()
                .HasConversion(
                    c => JsonSerializer.Serialize(c, new JsonSerializerOptions()),
                    c => JsonSerializer.Deserialize<List<Criteria>>(c, new JsonSerializerOptions())!);

            module.WithOwner().HasForeignKey("CourseId");
        });

        builder.Navigation(c => c.Modules)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .AutoInclude();
    }
}