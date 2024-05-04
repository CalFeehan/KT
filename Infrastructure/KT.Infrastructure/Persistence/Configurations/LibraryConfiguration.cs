using System.Text.Json;
using KT.Domain.LibraryAggregate;
using KT.Domain.LibraryAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KT.Infrastructure;

public class LibraryConfiguration : IEntityTypeConfiguration<Library>
{
    public void Configure(EntityTypeBuilder<Library> builder)
    {
        ConfigureLibraryTable(builder);
        ConfigureCourseTemplateTable(builder);
        ConfigureModuleTemplateTable(builder);
        ConfigureActivityPlanTemplateTable(builder);
        ConfigureActivityTemplateTable(builder);
        ConfigureSessionPlanTemplateTable(builder);
        ConfigureSessionTemplateTable(builder);
    }

    private void ConfigureLibraryTable(EntityTypeBuilder<Library> builder)
    {
        // Configure the table name
        builder.ToTable("Libraries", "Library");

        // Configure the primary key
        builder.HasKey(l => l.Id);
        builder.Property(l => l.Id).ValueGeneratedNever();
        
        // Configure relationships (if any)

        // Configure indexes (if any)
    }

    private void ConfigureCourseTemplateTable(EntityTypeBuilder<Library> builder)
    {
        builder.OwnsMany(l => l.CourseTemplates, courseTemplate =>
        {
            courseTemplate.ToTable("CourseTemplates", "Library");

            courseTemplate.HasKey(ct => ct.Id);
            courseTemplate.Property(ct => ct.Id).ValueGeneratedNever();

            courseTemplate.Property(ct => ct.LibraryId).IsRequired();
            courseTemplate.WithOwner().HasForeignKey("LibraryId");

            courseTemplate.Property(ct => ct.CourseTemplateStatus)
                .IsRequired();

            courseTemplate.Property(ct => ct.Title)
                .HasMaxLength(100)
                .IsRequired();

            courseTemplate.Property(ct => ct.Description)
                .HasMaxLength(500)
                .IsRequired();
            
            courseTemplate.Property(ct => ct.Code)
                .HasMaxLength(25)
                .IsRequired();

            courseTemplate.Property(ct => ct.Level)
                .IsRequired();
        });

        builder.Navigation(l => l.CourseTemplates)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .AutoInclude(true);
    }
    
    private void ConfigureModuleTemplateTable(EntityTypeBuilder<Library> builder)
    {
        // the Library.CourseTemplate owns the ModuleTemplate
        builder.OwnsMany(l => l.CourseTemplates, courseTemplate =>
        {
            courseTemplate.OwnsMany(ct => ct.ModuleTemplates, moduleTemplate =>
            {
                moduleTemplate.ToTable("ModuleTemplates", "Library");

                moduleTemplate.HasKey(mt => mt.Id);
                moduleTemplate.Property(mt => mt.Id).ValueGeneratedNever();

                moduleTemplate.Property(mt => mt.CourseTemplateId).IsRequired();
                moduleTemplate.WithOwner().HasForeignKey("CourseTemplateId");

                moduleTemplate.Property(mt => mt.ModuleType)
                .IsRequired();

                moduleTemplate.Property(mt => mt.Title)
                    .HasMaxLength(100)
                    .IsRequired();

                moduleTemplate.Property(mt => mt.Description)
                    .HasMaxLength(500)
                    .IsRequired();

                moduleTemplate.Property(mt => mt.Code)
                    .HasMaxLength(25)
                    .IsRequired();

                moduleTemplate.Property(mt => mt.Level)
                    .IsRequired();
                
                moduleTemplate.Property(mt => mt.StartDate)
                    .IsRequired();

                moduleTemplate.Property(mt => mt.ExpectedEndDate)
                    .IsRequired();

                moduleTemplate.Property(mt => mt.ActualEndDate)
                    .IsRequired(false);

                // list of CriteriaTemplate value objects, serialized as JSON
                moduleTemplate.Property(mt => mt.CriteriaTemplates)
                    .IsRequired()
                    .HasConversion(
                        ct => JsonSerializer.Serialize(ct, new JsonSerializerOptions()),
                        ct => JsonSerializer.Deserialize<List<CriteriaTemplate>>(ct, new JsonSerializerOptions())!
                    );
            });

            courseTemplate.Navigation(ct => ct.ModuleTemplates)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .AutoInclude(true);
        });
    }

    private void ConfigureSessionPlanTemplateTable(EntityTypeBuilder<Library> builder)
    {
        builder.OwnsMany(l => l.CourseTemplates, courseTemplate =>
        {
            courseTemplate.OwnsOne(ct => ct.SessionPlanTemplate, sessionPlanTemplate =>
            {
                sessionPlanTemplate.ToTable("SessionPlanTemplates", "Library");

                sessionPlanTemplate.HasKey(spt => spt.Id);
                sessionPlanTemplate.Property(spt => spt.Id).ValueGeneratedNever();

                sessionPlanTemplate.Property(spt => spt.CourseTemplateId).IsRequired();
                sessionPlanTemplate.WithOwner().HasForeignKey("CourseTemplateId");
            });

            courseTemplate.Navigation(ct => ct.SessionPlanTemplate)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .AutoInclude(true);
        });
    }

    private void ConfigureSessionTemplateTable(EntityTypeBuilder<Library> builder)
    {
        builder.OwnsMany(l => l.CourseTemplates, courseTemplate =>
        {
            courseTemplate.OwnsOne(ct => ct.SessionPlanTemplate, sessionPlanTemplate =>
            {
                sessionPlanTemplate.OwnsMany(spt => spt.SessionTemplates, sessionTemplate =>
                {
                    sessionTemplate.ToTable("SessionTemplates", "Library");

                    sessionTemplate.HasKey(st => st.Id);
                    sessionTemplate.Property(st => st.Id).ValueGeneratedNever();

                    sessionTemplate.Property(st => st.SessionPlanTemplateId).IsRequired();
                    sessionTemplate.WithOwner().HasForeignKey("SessionPlanTemplateId");

                    sessionTemplate.Property(st => st.SessionType)
                        .IsRequired();

                    sessionTemplate.Property(st => st.StartTime)
                        .IsRequired();

                    sessionTemplate.Property(st => st.EndTime)
                        .IsRequired();

                    sessionTemplate.Property(st => st.CohortId)
                        .IsRequired(false);

                    sessionTemplate.Property(st => st.Location)
                        .HasMaxLength(100)
                        .IsRequired();

                    sessionTemplate.Property(st => st.Notes)
                        .HasMaxLength(500)
                        .IsRequired();

                    sessionTemplate.Property(st => st.MeetingLink)
                        .HasMaxLength(500)
                        .IsRequired();
                });

                sessionPlanTemplate.Navigation(spt => spt.SessionTemplates)
                    .UsePropertyAccessMode(PropertyAccessMode.Field)
                    .AutoInclude(true);
            });
        });
    }

    private void ConfigureActivityPlanTemplateTable(EntityTypeBuilder<Library> builder)
    {
        builder.OwnsMany(l => l.CourseTemplates, courseTemplate =>
        {
            courseTemplate.OwnsOne(ct => ct.ActivityPlanTemplate, activityPlanTemplate =>
            {
                activityPlanTemplate.ToTable("ActivityPlanTemplates", "Library");

                activityPlanTemplate.HasKey(apt => apt.Id);
                activityPlanTemplate.Property(apt => apt.Id).ValueGeneratedNever();

                activityPlanTemplate.Property(apt => apt.CourseTemplateId).IsRequired();
                activityPlanTemplate.WithOwner().HasForeignKey("CourseTemplateId");
            });

            courseTemplate.Navigation(ct => ct.ActivityPlanTemplate)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .AutoInclude(true);
        });
    }

    private void ConfigureActivityTemplateTable(EntityTypeBuilder<Library> builder)
    {
        builder.OwnsMany(l => l.CourseTemplates, courseTemplate =>
        {
            courseTemplate.OwnsOne(ct => ct.ActivityPlanTemplate, activityPlanTemplate =>
            {
                activityPlanTemplate.OwnsMany(apt => apt.ActivityTemplates, activityTemplate =>
                {
                    activityTemplate.ToTable("ActivityTemplates", "Library");

                    activityTemplate.HasKey(at => at.Id);
                    activityTemplate.Property(at => at.Id).ValueGeneratedNever();

                    activityTemplate.Property(at => at.ActivityPlanTemplateId).IsRequired();
                    activityTemplate.WithOwner().HasForeignKey("ActivityPlanTemplateId");

                    activityTemplate.Property(at => at.Title)
                        .HasMaxLength(100)
                        .IsRequired();

                    activityTemplate.Property(at => at.Description)
                        .IsRequired();

                    activityTemplate.Property(at => at.Duration)
                        .IsRequired();

                    // list of DocumentIds, serialized as JSON
                    activityTemplate.Property(at => at.DocumentIds)
                        .IsRequired()
                        .HasConversion(
                            di => JsonSerializer.Serialize(di, new JsonSerializerOptions()),
                            di => JsonSerializer.Deserialize<List<Guid>>(di, new JsonSerializerOptions())!
                        );

                    // list of ModuleTemplateIds, serialized as JSON
                    activityTemplate.Property(at => at.ModuleTemplateIds)
                        .IsRequired()
                        .HasConversion(
                            mti => JsonSerializer.Serialize(mti, new JsonSerializerOptions()),
                            mti => JsonSerializer.Deserialize<List<Guid>>(mti, new JsonSerializerOptions())!
                        );
                });

                activityPlanTemplate.Navigation(apt => apt.ActivityTemplates)
                    .UsePropertyAccessMode(PropertyAccessMode.Field)
                    .AutoInclude(true);
            });
        });
    }
}
