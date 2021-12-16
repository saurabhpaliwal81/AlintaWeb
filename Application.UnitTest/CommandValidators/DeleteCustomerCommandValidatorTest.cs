using Application.Customers.Commands.DeleteCustomer;
using FluentAssertions;
using NUnit.Framework;
using System.Linq;

namespace Application.UnitTest
{
    public class DeleteCustomerCommandValidatorTest
    {
        private DeleteCustomerCommandValidator _validator;

        [SetUp]
        public void Setup()
        {
            // arrange
            _validator = CreateValidator();
        }

        [Test]
        public void Validate_WhenNoValueProvided_ShouldReturnValidationError()
        {
            // act
            var validationResult = _validator.Validate(new DeleteCustomerCommand() { });
            var validationError = validationResult.Errors;

            // assert
            validationError.Count().Should().Be(1);
        }

        [Test]
        public void Validate_WhenNegativeValueProvided_ShouldReturnValidationError()
        {
            // act
            var validationResult = _validator.Validate(new DeleteCustomerCommand() { Id = -1 });
            var validationError = validationResult.Errors;

            // assert
            validationError.Count().Should().Be(1);
        }

        [Test]
        public void Validate_WhenZeroValueProvided_ShouldReturnValidationError()
        {
            // act
            var validationResult = _validator.Validate(new DeleteCustomerCommand() { Id = 0 });
            var validationError = validationResult.Errors;

            // assert
            validationError.Count().Should().Be(1);
        }

        [Test]
        public void Validate_WhenCorrectValueProvided_ShouldNotReturnValidationError()
        {
            // act
            var validationResult = _validator.Validate(new DeleteCustomerCommand() { Id = 1 });
            var validationError = validationResult.Errors;

            // assert
            validationError.Count().Should().Be(0);
        }

        private static DeleteCustomerCommandValidator CreateValidator()
        {
            return new DeleteCustomerCommandValidator();
        }
    }
}