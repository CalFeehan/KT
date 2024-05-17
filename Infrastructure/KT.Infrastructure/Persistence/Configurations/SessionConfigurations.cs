using KT.Domain.SessionAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KT.Infrastructure.Persistence.Configurations;

public class SessionConfigurations : IEntityTypeConfiguration<Session>
{
    public void Configure(EntityTypeBuilder<Session> builder)
    {
        ConfigureSessionTable(builder);
    }

    private void ConfigureSessionTable(EntityTypeBuilder<Session> builder)
    {
        // Configure the table name
        builder.ToTable("Sessions", "Session");

        // Configure the primary key
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).ValueGeneratedNever();

        // Configure properties
        builder.Property(s => s.CourseId)
            .IsRequired();

        builder.Property(s => s.SessionType)
            .IsRequired();

        builder.Property(s => s.StartTime)
            .IsRequired();

        builder.Property(s => s.EndTime)
            .IsRequired();

        builder.Property(s => s.CohortId)
            .IsRequired(false);

        builder.Property(s => s.Location)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(s => s.Notes)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(s => s.MeetingLink)
            .HasMaxLength(100)
            .IsRequired();

        // Configure relationships (if any)

        // Configure indexes (if any)
    }
}