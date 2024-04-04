namespace KT.Domain.Aggregates;

public class Student(string forename, string surname)
{
    // TODO: Remove this and implement properly
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Forename { get; set; } = forename;

    public string Surname { get; set; } = surname;
}