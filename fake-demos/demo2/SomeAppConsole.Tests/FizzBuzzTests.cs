using System;
using Xunit;
using SomeAppConsole;
using FluentAssertions;

namespace SomeAppConsole.Tests
{
    public class FizzBuzzTests
    {
        [Theory]
        [InlineData(1, "1")]
        [InlineData(2, "2")]
        [InlineData(3, "Fizz")]
        [InlineData(4, "4")]
        [InlineData(5, "Buzz")]
        [InlineData(9, "Fizz")]
        [InlineData(15, "FizzBuzz")]
        [InlineData(30, "FizzBuzz")]
        public void Should_do_the_right_thing(int input, string expectedOutput)
        {
            var sut = new FizzBuzz();
            sut.Create(input).Should().Be(expectedOutput);
        }
    }
}
