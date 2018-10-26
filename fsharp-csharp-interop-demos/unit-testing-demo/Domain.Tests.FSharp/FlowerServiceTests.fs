module FlowerServiceTests

open System
open Foq
open FsUnit.Xunit
open Xunit
open Domain
open NHamcrest

// http://brandewinder.com/2013/01/27/Testing-and-mocking-your-C-sharp-code-with-F-sharp/
[<Fact>]
let ``Send happy case calls deliveryService`` () =

    // TODO: Show manual mock before using FOQ library

    // Arrange
    let deliveryServiceMock =
        Mock<IDeliveryService>()
            .Setup(fun x -> <@ x.SendFlowers(any()) @>)
            .Returns(SendResponse(WasSuccessfull = true))
            .Create();

    let sut = FlowerService(deliveryServiceMock);

    // Act
    let result = sut.Send(Order( From = "Bob", To = "Alice", FlowerName = "Rose" ));

    // Assert
    Assert.True(result.WasSuccessfull)
