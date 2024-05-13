using System.Text.Json;
using KT.Domain.ModuleTemplateAggregate;
using KT.Domain.ModuleTemplateAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KT.Infrastructure.Persistence.Configurations;

public class ModuleTemplateConfiguration : IEntityTypeConfiguration<ModuleTemplate>
{
    public void Configure(EntityTypeBuilder<ModuleTemplate> builder)
    {
        ConfigureModuleTemplateTable(builder);
    }
    private void ConfigureModuleTemplateTable(EntityTypeBuilder<ModuleTemplate> builder)
    {
        builder.ToTable("ModuleTemplates", "ModuleTemplate");

        builder.HasKey(mt => mt.Id);
        builder.Property(mt => mt.Id).ValueGeneratedNever();

        builder.Property(mt => mt.ModuleType)
        .IsRequired();

        builder.Property(mt => mt.Title)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(mt => mt.Description)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(mt => mt.Code)
            .HasMaxLength(25)
            .IsRequired();

        builder.Property(mt => mt.Level)
            .IsRequired();

        builder.Property(mt => mt.DurationInWeeks)
            .IsRequired();

        // list of CriteriaTemplate value objects, serialized as JSON
        builder.Property(mt => mt.CriteriaTemplates)
            .IsRequired()
            .HasConversion(
                ct => JsonSerializer.Serialize(ct, new JsonSerializerOptions()),
                ct => JsonSerializer.Deserialize<List<CriteriaTemplate>>(ct, new JsonSerializerOptions())!);
    }
}
