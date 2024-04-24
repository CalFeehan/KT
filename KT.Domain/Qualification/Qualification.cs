using KT.Domain.Common.Models;

namespace KT.Domain.Qualification;

public class Qualification(Guid id, string title, string description, QualificationType qualificationType, DateOnly startDate, DateOnly expectedEndDate, DateOnly? actualEndDate, AwardingOrganisation awardingOrganisation, int level) : Entity<Guid>(id)
{
    public string Title { get; set; } = title;

    public string Description { get; set; } = description;

    public QualificationType QualificationType { get; set; } = qualificationType;

    public DateOnly StartDate { get; set; } = startDate;

    public DateOnly ExpectedEndDate { get; set; } = expectedEndDate;

    public DateOnly? ActualEndDate { get; set; } = actualEndDate;

    public AwardingOrganisation AwardingOrganisation { get; set; } = awardingOrganisation;

    public int Level { get; set; } = level;
}

public enum QualificationType
{
    Certificate,
    Diploma,
    Degree
}

public enum AwardingOrganisation
{
    Pearson,
    AQA,
    OCR
}