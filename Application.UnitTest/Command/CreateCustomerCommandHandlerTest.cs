using Application.Common.Interfaces;
using Application.Customers.Commands;
using Domain.Entities;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UnitTest.Command
{
    public class CreateCustomerCommandHandlerTest
    {
        private CreateCustomerCommandHandler _commandHandler;
        private Mock<IApplicationDbContext> mockApplicationDbContext;

        [SetUp]
        public void Setup()
        {
            // arrange
            mockApplicationDbContext = new Mock<IApplicationDbContext>();
            var customerList = new List<Customer>()
            {
                new Customer()
                {
                    Id = 1,
                    FirstName = "user1",
                    LastName = "paliwal",
                    Created = DateTimeOffset.Now,
                    CreatedBy = "admin",
                    DateOfBirth = DateTimeOffset.Now,
                },
                new Customer()
                {
                    Id = 1,
                    FirstName = "user2",
                    LastName = "paliwal",
                    Created = DateTimeOffset.Now,
                    CreatedBy = "admin",
                    DateOfBirth = DateTimeOffset.Now,
                },
                new Customer()
                {
                    Id = 1,
                    FirstName = "user3",
                    LastName = "paliwal",
                    Created = DateTimeOffset.Now,
                    CreatedBy = "admin",
                    DateOfBirth = DateTimeOffset.Now,
                }
            };

            mockApplicationDbContext.Setup(x => x.Customers).Returns(DbContextMock.GetQueryableMockDbSet<Customer>(customerList));

            _commandHandler = new CreateCustomerCommandHandler(mockApplicationDbContext.Object);
        }

        [Test]
        public async Task Handle_WhenCorrectInputProvided_CustomerAddedCorrectly()
        {
            // act
            var result = await _commandHandler.Handle(new CreateCustomerCommand() { FirstName = "saurabh", LastName = "paliwal", DateOfBirth = DateTimeOffset.Now }, CancellationToken.None);

            // assert
            mockApplicationDbContext.Object.Customers.FirstOrDefault(x => x.FirstName == "saurabh").Should().NotBeNull();
        }

        [Test]
        public void Handle_WhenNullInputRequestProvided_ExceptionThrown()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                // act
                await _commandHandler.Handle(null, CancellationToken.None);
            });
        }
    }
}