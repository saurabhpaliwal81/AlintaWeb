using Application.Customers.Commands;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Linq;

namespace Application.UnitTest
{
    public class CreateCustomerCommandValidatorTest
    {
        private CreateCustomerCommandValidator _validator;

        [SetUp]
        public void Setup()
        {
            // arrange
            _validator = new CreateCustomerCommandValidator();
        }

        [Test]
        public void Validate_WhenNoValueProvided_ShouldReturnValidationError()
        {
            // act
            var validationResult = _validator.Validate(new CreateCustomerCommand() { });
            var validationError = validationResult.Errors;

            // assert
            validationError.Count().Should().Be(3);
        }

        private static CreateCustomerCommandValidator CreateValidator()
        {
            return new CreateCustomerCommandValidator();
        }

        [Test]
        public void Validate_WhenCorrectValueProvided_ShouldNotReturnValidationError()
        {
            // act
            var validationResult = _validator.Validate(new CreateCustomerCommand() { FirstName = "saurabh", LastName = "paliwal", DateOfBirth = new DateTimeOffset(1981, 11, 23, 0, 0, 0, TimeSpan.Zero) });
            var validationError = validationResult.Errors;

            // assert
            validationError.Count().Should().Be(0);
        }
    }
}