using KT.Application.Common.Interfaces.Persistence;
using KT.Application.Learners.Commands;
using Moq;
using FluentAssertions;
using KT.Domain.LearnerAggregate;
using KT.Domain.Common.ValueObjects;
using NUnit.Framework;
using KT.Common.Enums;

namespace KT.Application.Tests.Learners.Commands;

[TestFixture]
public class CreateCommandHandlerTests
{
    private readonly Mock<ILearnerRepository> _learnerRepositoryMock;
    private readonly CreateCommandHandler _createCommandHandler;

    public CreateCommandHandlerTests()
    {
        _learnerRepositoryMock = new Mock<ILearnerRepository>();
        _createCommandHandler = new CreateCommandHandler(_learnerRepositoryMock.Object);
    }

    [Test]
    public async Task Handle_WhenLearnerIsCreated_ShouldReturnLearner()
    {
        // Arrange
        var address = Address.Create("123 Fake Street", "Fake Road", "Fake City", "Fake County", "AA11 1AA");
        var contactDetails = ContactDetails.Create("email@email.com", "1234567890", ContactPreference.Email);

        var command = new CreateCommand(
            "John",
            "Doe",
            DateOnly.FromDateTime(new DateTime(2000, 1, 1)),
            address,
            contactDetails);

        
        var learner = Learner.Create(command.Forename, command.Surname, command.DateOfBirth, 
            command.Address.Line1, command.Address.Line2, command.Address.City, command.Address.County, command.Address.Postcode,
            command.ContactDetails.Email, command.ContactDetails.Phone, command.ContactDetails.ContactPreference);

        _learnerRepositoryMock.Setup(x => x.CreateAsync(It.IsAny<Learner>()))
            .ReturnsAsync(learner);

        // Act
        var result = await _createCommandHandler.Handle(command, CancellationToken.None);

        // Assert
        result.Value.Should().Be(learner);
    }
}

