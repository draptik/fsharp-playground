using System;
using FluentAssertions;
using Xunit;

namespace Domain.Tests.CSharp
{
    public class CustomerTests
    {
        [Fact]
        public void Customer_creation_via_ctor_returns_valid_customer()
        {
            var customer = new Customer(1, "fn", "ln");

            customer.Id.Should().Be(1);
            customer.FirstName.Should().Be("fn");
            customer.LastName.Should().Be("ln");
        }

        [Fact]
        public void Customer_creation_via_props_returns_valid_customer()
        {
            var customer = new Customer
            {
                Id = 1,
                FirstName = "fn",
                LastName = "ln"
            };

            customer.Id.Should().Be(1);
            customer.FirstName.Should().Be("fn");
            customer.LastName.Should().Be("ln");
        }
    }
}
