using KT.Common.Enums;
using KT.Domain.Common.Models;
using KT.Domain.Common.ValueObjects;
using KT.Domain.LearnerAggregate.Entities;
using KT.Domain.LearnerAggregate.Events;

namespace KT.Domain.LearnerAggregate;

public class Learner : AggregateRoot
{
    // Entities
    private readonly List<LearningPlan> _learningPlans = [];
    public IReadOnlyList<LearningPlan> LearningPlans => _learningPlans.AsReadOnly();

    // Properties
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

    public static Learner Create(string forename, string surname, DateOnly dateOfBirth, Address address, ContactDetails contactDetails)
    {   
        var learner = new Learner(Guid.NewGuid(), forename, surname, dateOfBirth, address, contactDetails);
        
        learner.AddDomainEvent(new LearnerCreated(learner));
        
        return learner;
    }

    public void UpdateContactDetails(string email, string phone, ContactPreference contactPreference)
    {
        ContactDetails = ContactDetails.Create(email, phone, contactPreference);
    }

    public void UpdateAddress(string addressLine1, string addressLine2, string city, string county, string postcode)
    {
        Address = Address.Create(addressLine1, addressLine2, city, county, postcode);
    }

    public LearningPlan AddLearningPlan(string title, string description)
    {
        var learningPlan = LearningPlan.Create(Id, title, description);
        _learningPlans.Add(learningPlan);

        AddDomainEvent(new LearningPlanAdded(Id, learningPlan));

        return learningPlan;
    }

    public void RemoveLearningPlan(Guid learningPlanId)
    {
        var learningPlan = _learningPlans.FirstOrDefault(lp => lp.Id == learningPlanId) 
            ?? throw new InvalidOperationException("Learning plan not found.");

        _learningPlans.Remove(learningPlan);

        AddDomainEvent(new LearningPlanRemoved(Id, learningPlan));
    }



    #region EF Core Constructor

    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private Learner(Guid id) : base(id) { }
    #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    
    #endregion
}