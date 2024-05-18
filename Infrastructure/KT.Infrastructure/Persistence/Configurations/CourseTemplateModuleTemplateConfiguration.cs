using KT.Domain.CourseTemplateAggregate.Entities;
using KT.Domain.CourseTemplateAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KT.Infrastructure.Persistence.Configurations;

public class CourseTemplateModuleTemplateConfiguration : IEntityTypeConfiguration<CourseTemplateModuleTemplate>
{
    public void Configure(EntityTypeBuilder<CourseTemplateModuleTemplate> builder)
    {
        builder.ToTable("CourseTemplateModuleTemplates", "CourseTemplate");

        builder.HasKey(ctmt => ctmt.Id);
        builder.Property(ctmt => ctmt.Id).ValueGeneratedNever();

        builder.Property(ctmt => ctmt.CourseTemplateId)
            .IsRequired();

        builder.Property(ctmt => ctmt.ModuleTemplateId)
            .IsRequired();
    }
}