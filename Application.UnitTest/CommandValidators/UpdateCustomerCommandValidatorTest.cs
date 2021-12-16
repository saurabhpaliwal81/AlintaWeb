using Application.Customers.Commands;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Linq;

namespace Application.UnitTest
{
    public class UpdateCustomerCommandValidatorTest
    {
        private UpdateCustomerCommandValidator _validator;

        [SetUp]
        public void Setup()
        {
            // arrange
            _validator = new UpdateCustomerCommandValidator();
        }

        [Test]
        public void Validate_WhenNoValueProvided_ShouldReturnValidationError()
        {
            // act
            var validationResult = _validator.Validate(new UpdateCustomerCommand() { });
            var validationError = validationResult.Errors;

            // assert
            validationError.Count().Should().Be(3);
        }

        [Test]
        public void Validate_WhenCorrectValueProvided_ShouldNotReturnValidationError()
        {
            // act
            var validationResult = _validator.Validate(new UpdateCustomerCommand() { FirstName = "saurabh", LastName = "paliwal", DateOfBirth = new DateTimeOffset(1981, 11, 23, 0, 0, 0, TimeSpan.Zero) });
            var validationError = validationResult.Errors;

            // assert
            validationError.Count().Should().Be(0);
        }
    }
}