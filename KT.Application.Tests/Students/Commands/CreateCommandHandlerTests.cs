using KT.Application.Common.Interfaces.Persistence;
using KT.Application.Students.Commands;
using Moq;
using FluentAssertions;
using KT.Domain.StudentAggregate;

namespace KT.Application.Tests.Students.Commands;

public class CreateCommandHandlerTests
{
    private readonly Mock<IStudentRepository> _studentRepositoryMock;
    private readonly CreateCommandHandler _createCommandHandler;

    public CreateCommandHandlerTests()
    {
        _studentRepositoryMock = new Mock<IStudentRepository>();
        _createCommandHandler = new CreateCommandHandler(_studentRepositoryMock.Object);
    }

    [Test]
    public async Task Handle_WhenStudentIsCreated_ShouldReturnStudent()
    {
        // Arrange
        var command = new CreateCommand(
            "John",
            "Doe",
            DateOnly.FromDateTime(new DateTime(2000, 1, 1)));

        var student = Student.Create(command.Forename, command.Surname, command.DateOfBirth);

        _studentRepositoryMock.Setup(x => x.CreateAsync(It.IsAny<Student>()))
            .ReturnsAsync(student);

        // Act
        var result = await _createCommandHandler.Handle(command, CancellationToken.None);

        // Assert
        result.Value.Should().Be(student);
    }
}
