using ErrorOr;
using FluentAssertions;
using KT.Application.Common.Interfaces.Persistence;
using KT.Application.Learners.Commands.Add;
using KT.Application.Tests.Common.DataHelpers;
using KT.Domain.LearnerAggregate;
using Moq;

namespace KT.Application.Tests.Learners.Commands.Create;

[TestFixture]
public class AddLearnerCommandHandlerTests
{
    [SetUp]
    public void Setup()
    {
        SetupData();
        SetupExpections();
    }

    private readonly Mock<ILearnerRepository> _learnerRepositoryMock;
    private readonly AddLearnerCommandHandler _addCommandHandler;

    private Learner _learner;

    public AddLearnerCommandHandlerTests()
    {
        _learnerRepositoryMock = new Mock<ILearnerRepository>();
        _addCommandHandler = new AddLearnerCommandHandler(_learnerRepositoryMock.Object);
    }

    [Test]
    public async Task Handle_WhenLearnerIsAdded_ShouldReturnLearner()
    {
        // Arrange
        var command = new AddLearnerCommand(
            _learner.Forename,
            _learner.Surname,
            _learner.DateOfBirth,
            _learner.Address,
            _learner.ContactDetails);

        _learnerRepositoryMock.Setup(x => x.AddAsync(It.IsAny<Learner>()))
            .ReturnsAsync(_learner);

        // Act
        var result = await _addCommandHandler.Handle(command, CancellationToken.None);

        // Assert
        result.Value.Should().Be(_learner);
    }

    [Test]
    public void Handle_WhenLearnerIsNotAdded_ShouldReturnFailure()
    {
        // Arrange
        var command = new AddLearnerCommand(
            _learner.Forename,
            _learner.Surname,
            _learner.DateOfBirth,
            _learner.Address,
            _learner.ContactDetails);

        _learnerRepositoryMock.Setup(x => x.AddAsync(It.IsAny<Learner>()))
            .ReturnsAsync((Learner)null!);

        // Act
        var result = _addCommandHandler.Handle(command, CancellationToken.None).Result;

        // Assert
        result.Value.Should().BeNull();
        result.Errors.Count.Should().BeGreaterThan(0);
        result.Errors[0].Type.Should().Be(ErrorType.Unexpected);
    }

    private void SetupExpections()
    {
        _learnerRepositoryMock.Setup(x => x.AddAsync(It.IsAny<Learner>()))
            .ReturnsAsync(_learner);
    }

    private void SetupData()
    {
        _learner = Learner.Create("John", "Doe", DateOnly.FromDateTime(new DateTime(2000, 1, 1)),
            AddressHelpers.DummyAddress, ContactDetailsHelpers.DummyContactDetails);
    }
}