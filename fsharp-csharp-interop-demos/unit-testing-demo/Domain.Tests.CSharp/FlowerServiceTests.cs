using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Domain.Tests.CSharp
{
    public class FlowerServiceTests
    {
        [Fact]
        public void Send_happy_case_calls_deliveryService()
        {
            // Arrange
            var deliveryServiceMock = Substitute.For<IDeliveryService>();
            var sut = new FlowerService(deliveryServiceMock);

            // Act
            sut.Send(new Order{ From = "Bob", To = "Alice", FlowerName = "Rose" });

            // Assert
            deliveryServiceMock.Received().SendFlowers(Arg.Any<Order>());
        }

        [Fact]
        public void Send_happy_case_returns_success()
        {
            // Arrange
            var deliveryServiceMock = Substitute.For<IDeliveryService>();
            deliveryServiceMock.SendFlowers(Arg.Any<Order>())
                .Returns(new SendResponse {WasSuccessfull = true});

            var sut = new FlowerService(deliveryServiceMock);

            // Act
            var result = sut.Send(new Order{ From = "Bob", To = "Alice", FlowerName = "Rose" });

            // Assert
            result.WasSuccessfull.Should().BeTrue();
        }
    }
}
