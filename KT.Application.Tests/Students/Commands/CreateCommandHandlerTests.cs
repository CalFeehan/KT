using KT.Application.Common.Interfaces.Persistence;
using KT.Application.Students.Commands;
using Moq;
using FluentAssertions;
using KT.Domain.StudentAggregate;
using KT.Domain.Common.Enums;
using KT.Domain.Common.ValueObjects;

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
        var address = Address.Create("123 Fake Street", "Fake Road", "Fake City", County.Clwyd, "AA11 1AA");
        var contactDetails = ContactDetails.Create("email@email.com", "1234567890", ContactPreference.Email);

        var command = new CreateCommand(
            "John",
            "Doe",
            DateOnly.FromDateTime(new DateTime(2000, 1, 1)),
            address,
            contactDetails);

        
        var student = Student.Create(command.Forename, command.Surname, command.DateOfBirth, 
            command.Address.Line1, command.Address.Line2, command.Address.City, command.Address.County, command.Address.Postcode,
            command.ContactDetails.Email, command.ContactDetails.Phone, command.ContactDetails.ContactPreference);

        _studentRepositoryMock.Setup(x => x.CreateAsync(It.IsAny<Student>()))
            .ReturnsAsync(student);

        // Act
        var result = await _createCommandHandler.Handle(command, CancellationToken.None);

        // Assert
        result.Value.Should().Be(student);
    }
}
