using KT.Common.Enums;
using KT.Domain.Common.Models;
using KT.Domain.Common.ValueObjects;
using KT.Domain.LearnerAggregate.Entities;
using KT.Domain.LearnerAggregate.Events;

namespace KT.Domain.LearnerAggregate;

/// <summary>
/// A learner is a person who is learning with us.
/// </summary>
public class Learner : AggregateRoot
{
    /// <summary>
    /// The inner collection of learning plans.
    /// Note: This is a private collection, so it can only be modified by the Learner itself.
    /// </summary>
    private readonly List<LearningPlan> _learningPlans = [];

    /// <summary>
    /// The public accessor for the learning plans.
    /// This is read-only, so it can't be modified by external classes.
    /// </summary>
    public IReadOnlyList<LearningPlan> LearningPlans => _learningPlans.AsReadOnly();

    /// <summary>
    /// The forename of the learner. E.g., "John"
    /// </summary>
    public string Forename { get; private set; }

    /// <summary>
    /// The surname of the learner. E.g., "Smith"
    /// </summary>
    public string Surname { get; private set; }

    /// <summary>
    /// The full name of the learner. E.g., "John Smith"
    /// </summary>
    public string FullName => $"{Forename} {Surname}";

    /// <summary>
    /// The date of birth of the learner. E.g., "2000-01-01"
    /// </summary>
    public DateOnly DateOfBirth { get; private set; }

    /// <summary>
    /// The contact details of the learner.
    /// </summary>
    public ContactDetails ContactDetails { get; private set; }

    /// <summary>
    /// The address of the learner.
    /// </summary>
    public Address Address { get; private set; }

    /// <summary>
    /// Private constructor to ensure that the only way to create a learner is through the Create method.
    /// </summary>
    private Learner(Guid id, string forename, string surname, DateOnly dateOfBirth, Address address, ContactDetails contactDetails)
        : base(id)
    {
        Forename = forename;
        Surname = surname;
        DateOfBirth = dateOfBirth;
        Address = address;
        ContactDetails = contactDetails;
    }

    /// <summary>
    /// Creates a new learner.
    /// </summary>
    public static Learner Create(string forename, string surname, DateOnly dateOfBirth, Address address, ContactDetails contactDetails)
    {   
        var learner = new Learner(Guid.NewGuid(), forename, surname, dateOfBirth, address, contactDetails);
        
        learner.AddDomainEvent(new LearnerAdded(learner));
        
        return learner;
    }

    /// <summary>
    /// Overwrites the contact details of the learner.
    /// </summary>
    public void UpdateContactDetails(string email, string phone, ContactPreference contactPreference)
    {
        ContactDetails = ContactDetails.Create(email, phone, contactPreference);
    }

    /// <summary>
    /// Overwrites the address of the learner.
    /// </summary>
    public void UpdateAddress(string addressLine1, string addressLine2, string city, string county, string postcode)
    {
        Address = Address.Create(addressLine1, addressLine2, city, county, postcode);
    }

    /// <summary>
    /// Adds a new learning plan to the learner.
    /// </summary>
    public LearningPlan AddLearningPlan(string title, string description)
    {
        var learningPlan = LearningPlan.Create(Id, title, description);
        _learningPlans.Add(learningPlan);

        AddDomainEvent(new LearningPlanAdded(Id, learningPlan));

        return learningPlan;
    }

    /// <summary>
    /// Removes a learning plan from the learner.
    /// </summary>
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