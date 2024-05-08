using System.Text.Json;
using KT.Domain.CourseTemplateAggregate;
using KT.Domain.CourseTemplateAggregate.Entities;
using KT.Domain.CourseTemplateAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KT.Infrastructure;

public class CourseTemplateConfiguration : IEntityTypeConfiguration<CourseTemplate>
{
    public void Configure(EntityTypeBuilder<CourseTemplate> builder)
    {
        ConfigureCourseTemplateTable(builder);
        ConfigureModuleTemplateTable(builder);
        ConfigureActivityPlanTemplateTable(builder);
        ConfigureActivityTemplateTable(builder);
        ConfigureSessionPlanTemplateTable(builder);
        ConfigureSessionTemplateTable(builder);
    }

    private void ConfigureCourseTemplateTable(EntityTypeBuilder<CourseTemplate> builder)
    {
        builder.ToTable("CourseTemplates", "CourseTemplate");

        builder.HasKey(ct => ct.Id);
        builder.Property(ct => ct.Id).ValueGeneratedNever();

        builder.Property(ct => ct.CourseTemplateStatus)
            .IsRequired();

        builder.Property(ct => ct.Title)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(ct => ct.Description)
            .HasMaxLength(500)
            .IsRequired();
        
        builder.Property(ct => ct.Code)
            .HasMaxLength(25)
            .IsRequired();

        builder.Property(ct => ct.Level)
            .IsRequired();

        builder.Property(ct => ct.DurationInWeeks)
            .IsRequired();
    }
    
    private void ConfigureModuleTemplateTable(EntityTypeBuilder<CourseTemplate> builder)
    {
        builder.OwnsMany(ct => ct.ModuleTemplates, moduleTemplate =>
        {
            moduleTemplate.ToTable("ModuleTemplates", "CourseTemplate");

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

            moduleTemplate.Property(mt => mt.DurationInWeeks)
                .IsRequired();

            // list of CriteriaTemplate value objects, serialized as JSON
            moduleTemplate.Property(mt => mt.CriteriaTemplates)
                .IsRequired()
                .HasConversion(
                    ct => JsonSerializer.Serialize(ct, new JsonSerializerOptions()),
                    ct => JsonSerializer.Deserialize<List<CriteriaTemplate>>(ct, new JsonSerializerOptions())!
                );
        });

        builder.Navigation(ct => ct.ModuleTemplates)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .AutoInclude(true);
    }

    private void ConfigureSessionPlanTemplateTable(EntityTypeBuilder<CourseTemplate> builder)
    {
        builder.OwnsOne(ct => ct.SessionPlanTemplate, sessionPlanTemplate =>
        {
            sessionPlanTemplate.ToTable("SessionPlanTemplates", "CourseTemplate");

            sessionPlanTemplate.HasKey(spt => spt.Id);
            sessionPlanTemplate.Property(spt => spt.Id).ValueGeneratedNever();

            sessionPlanTemplate.Property(spt => spt.CourseTemplateId).IsRequired();
            sessionPlanTemplate.WithOwner().HasForeignKey("CourseTemplateId");
        });

        builder.Navigation(ct => ct.SessionPlanTemplate)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .AutoInclude(true);
    }

    private void ConfigureSessionTemplateTable(EntityTypeBuilder<CourseTemplate> builder)
    {
        builder.OwnsOne(ct => ct.SessionPlanTemplate, sessionPlanTemplate =>
        {
            sessionPlanTemplate.OwnsMany(spt => spt.SessionTemplates, sessionTemplate =>
            {
                sessionTemplate.ToTable("SessionTemplates", "CourseTemplate");

                sessionTemplate.HasKey(st => st.Id);
                sessionTemplate.Property(st => st.Id).ValueGeneratedNever();

                sessionTemplate.Property(st => st.SessionPlanTemplateId).IsRequired();
                sessionTemplate.WithOwner().HasForeignKey("SessionPlanTemplateId");

                sessionTemplate.Property(st => st.SessionType)
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

                sessionTemplate.Property(st => st.ScheduleDetails)
                    .IsRequired()
                    .HasConversion(
                        sd => JsonSerializer.Serialize(sd, new JsonSerializerOptions()),
                        sd => JsonSerializer.Deserialize<ScheduleDetails>(sd, new JsonSerializerOptions())!
                    );
            });

            sessionPlanTemplate.Navigation(spt => spt.SessionTemplates)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .AutoInclude(true);
        });
    }

    private void ConfigureActivityPlanTemplateTable(EntityTypeBuilder<CourseTemplate> builder)
    {
        builder.OwnsOne(ct => ct.ActivityPlanTemplate, activityPlanTemplate =>
        {
            activityPlanTemplate.ToTable("ActivityPlanTemplates", "CourseTemplate");

            activityPlanTemplate.HasKey(apt => apt.Id);
            activityPlanTemplate.Property(apt => apt.Id).ValueGeneratedNever();

            activityPlanTemplate.Property(apt => apt.CourseTemplateId).IsRequired();
            activityPlanTemplate.WithOwner().HasForeignKey("CourseTemplateId");
        });

        builder.Navigation(ct => ct.ActivityPlanTemplate)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .AutoInclude(true);
    }

    private void ConfigureActivityTemplateTable(EntityTypeBuilder<CourseTemplate> builder)
    {
        builder.OwnsOne(ct => ct.ActivityPlanTemplate, activityPlanTemplate =>
        {
            activityPlanTemplate.OwnsMany(apt => apt.ActivityTemplates, activityTemplate =>
            {
                activityTemplate.ToTable("ActivityTemplates", "CourseTemplate");

                activityTemplate.HasKey(at => at.Id);
                activityTemplate.Property(at => at.Id).ValueGeneratedNever();

                activityTemplate.Property(at => at.ActivityPlanTemplateId).IsRequired();
                activityTemplate.WithOwner().HasForeignKey("ActivityPlanTemplateId");

                activityTemplate.Property(at => at.Title)
                    .HasMaxLength(100)
                    .IsRequired();

                activityTemplate.Property(at => at.Description)
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

                activityTemplate.Property(at => at.ScheduleDetails)
                    .IsRequired()
                    .HasConversion(
                        sd => JsonSerializer.Serialize(sd, new JsonSerializerOptions()),
                        sd => JsonSerializer.Deserialize<ScheduleDetails>(sd, new JsonSerializerOptions())!
                    );
            });

            activityPlanTemplate.Navigation(apt => apt.ActivityTemplates)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .AutoInclude(true);
        });
    }
}
