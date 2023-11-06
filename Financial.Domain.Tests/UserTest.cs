using Financial.Domain.Entities;
using Financial.Domain.Exceptions;
using System;
using Xunit;

namespace Financial.Domain.Tests
{
    public class UserTests
    {
        [Fact]
        public void CreateValidUser()
        {
            // Arrange
            var name = "John Doe";
            var userName = "johndoe";
            var password = "password123";

            // Act
            var user = new User(name, userName, password);

            // Assert
            Assert.NotNull(user);
        }

        [Fact]
        public void CreateUserWithEmptyNameShouldThrowException()
        {
            // Arrange
            var name = string.Empty;
            var userName = "johndoe";
            var password = "password123";

            // Act and Assert
            Assert.Throws<FinancialException>(() =>
            {
                new User(name, userName, password);
            });
        }

        [Fact]
        public void CreateUserWithShortNameShouldThrowException()
        {
            // Arrange
            var name = "A";
            var userName = "johndoe";
            var password = "password123";

            // Act and Assert
            Assert.Throws<FinancialException>(() =>
            {
                new User(name, userName, password);
            });
        }

        [Fact]
        public void CreateUserWithEmptyPasswordShouldThrowException()
        {
            // Arrange
            var name = "John Doe";
            var userName = "johndoe";
            var password = string.Empty;

            // Act and Assert
            Assert.Throws<FinancialException>(() =>
            {
                new User(name, userName, password);
            });
        }

        [Fact]
        public void TrimNameAndConvertUserNameToLowercase()
        {
            // Arrange
            var name = "   John Doe   ";
            var userName = "JohnDoe";
            var password = "password123";

            // Act
            var user = new User(name, userName, password);

            // Assert
            Assert.Equal("John Doe", user.Name);
            Assert.Equal("johndoe", user.UserName);
        }

        [Fact]
        public void SetPassword()
        {
            // Arrange
            var user = new User("John Doe", "johndoe", "password123");

            // Act
            user.SetPassword("newpassword");

            // Assert
            Assert.Equal("newpassword", user.Password);
        }
    }
}
