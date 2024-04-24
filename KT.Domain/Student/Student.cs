using KT.Domain.Common.Models;
using KT.Domain.Common.ValueObjects;

namespace KT.Domain.Student;

public class Student(Guid id, string forename, string surname, DateOnly dateOfBirth) : Entity<Guid>(id)
{
    public string Forename { get; set; } = forename;

    public string Surname { get; set; } = surname;

    public string FullName => $"{Forename} {Surname}";

    public DateOnly DateOfBirth { get; set; } = dateOfBirth;

    public ContactDetails ContactDetails { get; set; }

    public Address Address { get; set; }
}