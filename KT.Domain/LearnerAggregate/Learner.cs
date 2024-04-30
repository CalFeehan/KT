using KT.Domain.Common.Enums;
using KT.Domain.Common.Models;
using KT.Domain.Common.ValueObjects;
using KT.Domain.LearnerAggregate.Events;

namespace KT.Domain.LearnerAggregate;

public class Learner : AggregateRoot
{
    public string Forename { get; private set; }

    public string Surname { get; private set; }

    public string FullName => $"{Forename} {Surname}";

    public DateOnly DateOfBirth { get; private set; }

    public ContactDetails ContactDetails { get; private set; }

    public Address Address { get; private set; }

    private Learner(Guid id, string forename, string surname, DateOnly dateOfBirth, Address address, ContactDetails contactDetails)
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

    public static Learner Create(
        string forename, string surname, DateOnly dateOfBirth, 
        string addressLine1, string addressLine2, string city, County county, string postcode, 
        string email, string phone, ContactPreference contactPreference)
    {
        var address = Address.Create(addressLine1, addressLine2, city, county, postcode);
        var contactDetails = ContactDetails.Create(email, phone, contactPreference);
        
        var learner = new Learner(Guid.NewGuid(), forename, surname, dateOfBirth, address, contactDetails);
        
        learner.AddDomainEvent(new LearnerCreated(learner));
        
        return learner;
    }
}