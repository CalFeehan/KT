using KT.Application.Common.Interfaces.Persistence;
using Moq;
using FluentAssertions;
using KT.Domain.LearnerAggregate;
using KT.Application.Learners.Commands.Create;

namespace KT.Application.Tests.Learners.Commands;

[TestFixture]
public class CreateCommandHandlerTests
{
    private readonly Mock<ILearnerRepository> _learnerRepositoryMock;
    private readonly CreateCommandHandler _createCommandHandler;

    private Learner _learner;

    public CreateCommandHandlerTests()
    {
        _learnerRepositoryMock = new Mock<ILearnerRepository>();
        _createCommandHandler = new CreateCommandHandler(_learnerRepositoryMock.Object);
    }

    [Test]
    public async Task Handle_WhenLearnerIsCreated_ShouldReturnLearner()
    {
        // Arrange
        var command = new CreateCommand(
            _learner.Forename,
            _learner.Surname,
            _learner.DateOfBirth,
            _learner.Address,
            _learner.ContactDetails);

        _learnerRepositoryMock.Setup(x => x.CreateAsync(It.IsAny<Learner>()))
            .ReturnsAsync(_learner);

        // Act
        var result = await _createCommandHandler.Handle(command, CancellationToken.None);

        // Assert
        result.Value.Should().Be(_learner);
    }

    [Test]
    public void Handle_WhenLearnerIsNotCreated_ShouldReturnFailure()
    {
        // Arrange
        var command = new CreateCommand(
            _learner.Forename,
            _learner.Surname,
            _learner.DateOfBirth,
            _learner.Address,
            _learner.ContactDetails);

        _learnerRepositoryMock.Setup(x => x.CreateAsync(It.IsAny<Learner>()))
            .ReturnsAsync((Learner)null!);

        // Act
        var result = _createCommandHandler.Handle(command, CancellationToken.None).Result;

        // Assert
        result.Value.Should().BeNull();
        result.Errors.Count.Should().BeGreaterThan(0);
        result.Errors[0].Type.Should().Be(ErrorOr.ErrorType.Unexpected);
    }

    [SetUp]
    public void Setup()
    {
        SetupData();
        SetupExpections();
    }

    private void SetupExpections()
    {
        _learnerRepositoryMock.Setup(x => x.CreateAsync(It.IsAny<Learner>()))
            .ReturnsAsync(_learner);
    }

    private void SetupData()
    {
        _learner = Learner.Create("John", "Doe", DateOnly.FromDateTime(new DateTime(2000, 1, 1)), AddressHelpers.DummyAddress, ContactDetailsHelpers.DummyContactDetails);
    }
}

