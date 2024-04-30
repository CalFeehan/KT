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

    private Student(Guid id, string forename, string surname, DateOnly dateOfBirth, Address address, ContactDetails contactDetails)
        : base(id)
    {
        Forename = forename;
        Surname = surname;
        DateOfBirth = dateOfBirth;
        Address = address;
        ContactDetails = contactDetails;
    }

    public void UpdateContactDetails(string email, string phone, ContactPreference contactPreference)
    {
        ContactDetails = ContactDetails.Create(email, phone, contactPreference);
    }

    public void UpdateAddress(string addressLine1, string addressLine2, string city, County county, string postcode)
    {
        Address = Address.Create(addressLine1, addressLine2, city, county, postcode);
    }

    public static Student Create(
        string forename, string surname, DateOnly dateOfBirth, 
        string addressLine1, string addressLine2, string city, County county, string postcode, 
        string email, string phone, ContactPreference contactPreference)
    {
        var address = Address.Create(addressLine1, addressLine2, city, county, postcode);
        var contactDetails = ContactDetails.Create(email, phone, contactPreference);
        
        var student = new Student(Guid.NewGuid(), forename, surname, dateOfBirth, address, contactDetails);
        
        student.AddDomainEvent(new StudentCreated(student));
        
        return student;
    }
}