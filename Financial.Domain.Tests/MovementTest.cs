using Financial.Domain.Entities;
using Financial.Domain.Exceptions;
using System;
using Xunit;

namespace Financial.Domain.Tests
{
    public class MovementTests
    {
        [Fact]
        public void CreateMovementWithEmptyDescriptionShouldThrowException()
        {
            // Arrange
            var description = string.Empty;
            var paymentDate = DateTime.Now;
            var charPaymentType = "R";
            var value = 100.00;
            var userId = 1;

            // Act and Assert
            Assert.Throws<FinancialException>(() =>
            {
                new Movement(description, paymentDate, charPaymentType, value, userId);
            });
        }

        [Fact]
        public void CreateMovementWithShortDescriptionShouldThrowException()
        {
            // Arrange
            var description = "AB";
            var paymentDate = DateTime.Now;
            var charPaymentType = "R";
            var value = 100.00;
            var userId = 1;

            // Act and Assert
            Assert.Throws<FinancialException>(() =>
            {
                new Movement(description, paymentDate, charPaymentType, value, userId);
            });
        }

        [Fact]
        public void CreateMovementWithInvalidPaymentTypeShouldThrowException()
        {
            // Arrange
            var description = "Sample Description";
            var paymentDate = DateTime.Now;
            var charPaymentType = "X"; // Invalid payment type
            var value = 100.00;
            var userId = 1;

            // Act and Assert
            Assert.Throws<FinancialException>(() =>
            {
                new Movement(description, paymentDate, charPaymentType, value, userId);
            });
        }

        [Fact]
        public void CreateMovementWithNegativeValueShouldThrowException()
        {
            // Arrange
            var description = "Sample Description";
            var paymentDate = DateTime.Now;
            var charPaymentType = "R";
            var value = -100.00; // Negative value
            var userId = 1;

            // Act and Assert
            Assert.Throws<FinancialException>(() =>
            {
                new Movement(description, paymentDate, charPaymentType, value, userId);
            });
        }

        [Fact]
        public void CreateMovementWithInvalidUserIdShouldThrowException()
        {
            // Arrange
            var description = "Sample Description";
            var paymentDate = DateTime.Now;
            var charPaymentType = "R";
            var value = 100.00;
            var userId = -1; // Invalid user ID

            // Act and Assert
            Assert.Throws<FinancialException>(() =>
            {
                new Movement(description, paymentDate, charPaymentType, value, userId);
            });
        }
    }
}
