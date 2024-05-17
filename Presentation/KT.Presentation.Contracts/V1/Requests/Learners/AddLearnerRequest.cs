using KT.Presentation.Contracts.V1.Requests.Common;

namespace KT.Presentation.Contracts.V1.Requests.Learners;

public record AddLearnerRequest(
    string Forename,
    string Surname,
    DateTime DateOfBirth,
    AddressRequest Address,
    ContactDetailsRequest ContactDetails);