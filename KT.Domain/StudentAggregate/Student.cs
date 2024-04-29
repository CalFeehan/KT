using KT.Domain.Common.Enums;
using KT.Domain.Common.Models;
using KT.Domain.Common.ValueObjects;

namespace KT.Domain.StudentAggregate;

public class Student : AggregateRoot
{
    public string Forename { get; private set; }

    public string Surname { get; private set; }

    public string FullName => $"{Forename} {Surname}";

    public DateOnly DateOfBirth { get; private set; }

    public ContactDetails ContactDetails { get; private set; }

    public Address Address { get; private set; }

    private Student(Guid id, string forename, string surname, DateOnly dateOfBirth)
        : base(id)
    {
        Forename = forename;
        Surname = surname;
        DateOfBirth = dateOfBirth;
        ContactDetails = new ContactDetails("", "", ContactPreference.Email);
        Address = new Address(string.Empty, string.Empty, string.Empty, County.Clwyd, string.Empty);
    }

    public void UpdateContactDetails(ContactDetails contactDetails)
    {
        ContactDetails = contactDetails;
    }

    public void UpdateAddress(Address address)
    {
        Address = address;
    }

    public static Student Create(string forename, string surname, DateOnly dateOfBirth)
    {
        var student = new Student(Guid.NewGuid(), forename, surname, dateOfBirth);
        student.AddDomainEvent(new StudentCreated(student));
        return student;
    }
}