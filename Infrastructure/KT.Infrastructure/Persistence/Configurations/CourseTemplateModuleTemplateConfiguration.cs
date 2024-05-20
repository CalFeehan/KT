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

        builder.HasKey(mt => mt.Id);
        builder.Property(mt => mt.Id).ValueGeneratedNever();

        builder.Property(mt => mt.CourseTemplateId)
            .IsRequired();

        builder.Property(mt => mt.ModuleTemplateId)
            .IsRequired();
    }
}