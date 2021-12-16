using Application.Common.Interfaces;
using Application.Customers.Commands.DeleteCustomer;
using Domain.Entities;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UnitTest.Command
{
    public class DeleteCustomerCommandHandlerTest
    {
        private DeleteCustomerCommandHandler _commandHandler;
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
                    Id = 2,
                    FirstName = "user2",
                    LastName = "paliwal",
                    Created = DateTimeOffset.Now,
                    CreatedBy = "admin",
                    DateOfBirth = DateTimeOffset.Now,
                },
                new Customer()
                {
                    Id = 3,
                    FirstName = "user3",
                    LastName = "paliwal",
                    Created = DateTimeOffset.Now,
                    CreatedBy = "admin",
                    DateOfBirth = DateTimeOffset.Now,
                }
            };

            mockApplicationDbContext.Setup(x => x.Customers).Returns(DbContextMock.GetQueryableMockDbSet<Customer>(customerList));

            _commandHandler = new DeleteCustomerCommandHandler(mockApplicationDbContext.Object);
        }

        [Test]
        public async Task Handle_WhenCorrectInputProvided_CustomerDeletedCorrectly()
        {
            // act

            var customer = new Customer()
            {
                Id = 1,
                FirstName = "user1",
                LastName = "paliwal",
                Created = DateTimeOffset.Now,
                CreatedBy = "admin",
                DateOfBirth = DateTimeOffset.Now,
            };

            mockApplicationDbContext.Setup(x => x.Customers.FindAsync(It.IsAny<int>())).ReturnsAsync(customer);

            await _commandHandler.Handle(new DeleteCustomerCommand() { Id = 1 }, CancellationToken.None);

            // assert
            mockApplicationDbContext.Verify(x => x.SaveChangesAsync(CancellationToken.None), Times.Once());
        }

        [Test]
        public void Handle_WhenNullInputRequestProvided_ExceptionThrown()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await _commandHandler.Handle(null, CancellationToken.None);
            });
        }
    }
}