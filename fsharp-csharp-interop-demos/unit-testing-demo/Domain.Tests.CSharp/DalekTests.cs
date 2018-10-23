using FluentAssertions;
using Xunit;

namespace Domain.Tests.CSharp
{
    public class DalekTests
    {
        [Fact]
        public void Dalek_creation_via_ctor_returns_valid_result()
        {
            var dalek = new Dalek(1, 10);

            dalek.Id.Should().Be(1);
            dalek.Power.Should().Be(10);
        }

        [Fact]
        public void Dalek_creation_via_props_returns_valid_result()
        {
            var dalek = new Dalek
            {
                Id = 1,
                Power = 10
            };

            dalek.Id.Should().Be(1);
            dalek.Power.Should().Be(10);
        }
    }
}
