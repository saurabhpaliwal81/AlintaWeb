using Application.Common.Interfaces;
using Application.Customers.Queries;
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
    public class SearchCustomerQueryHandlerTest
    {
        private SearchCustomerQueryHandler _commandHandler;
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

            _commandHandler = new SearchCustomerQueryHandler(mockApplicationDbContext.Object);
        }

        [Test]
        public async Task Should_ReturnAllCustomer_WhenNoSearchCriteriaProvided()
        {
            var result = await _commandHandler.Handle(new SearchCustomerQuery() { }, CancellationToken.None);
            result.Count().Should().Be(3);
        }

        [Test]
        public async Task Should_ReturnFilteredCustomer_WhenSearchCriteriaProvided()
        {
            var result = await _commandHandler.Handle(new SearchCustomerQuery() { name = "user1" }, CancellationToken.None);

            result.Count().Should().Be(1);
        }
    }
}