using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Learn_Tests.Tests;

[TestFixture]
public class Tests
{
    private Mock<IDatabase> mockDatabase;
    private UserManager userManager;

    [SetUp]
    public void Setup()
    {
        // Initialize mock database and user manager before each test
        mockDatabase = new Mock<IDatabase>();
        userManager = new UserManager(mockDatabase.Object);
    }

    [Test]
public void GetUser_ReturnsCorrectUserFromDatabase()
{
    // Arrange
    var expectedUser = new User(1, "Anna");

    // Set up the service: GetUser with id 1 should return expectedUser
    mockDatabase.Setup(service => service.GetUser(1)).Returns(expectedUser);

    // Act
    var actualUser = userManager.GetUser(1);

    // Assert
    Assert.That(actualUser, Is.EqualTo(expectedUser));
}

    [Test]
    public void AddUser_CreatesUserInDatabase()
    {
        // Arrange
        var newUser = new User(1, "John");

        // Act
        userManager.AddUser(newUser);

        // Assert
        mockDatabase.Verify(service => service.AddUser(newUser), Times.Once);
    }

    [Test]
    public void RemoveUser_RemovesUserFromDatabase()
    {
        // Arrange
        var userId = 1233;
        var userToRemove = new User(userId, "JohnDoe");

        // Set up the service: GetUser with id userId should return userToRemove
        mockDatabase.Setup(service => service.GetUser(userId)).Returns(userToRemove);

        // Act
        userManager.RemoveUser(userId);

        // Assert
        mockDatabase.Verify(service => service.RemoveUser(userId), Times.Once);
    }
}