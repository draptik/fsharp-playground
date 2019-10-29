using System;
using FluentAssertions;
using Xunit;

namespace CSharpLib
{
    public class Tests
    {
        [Fact]
        public void Smoke() => true.Should().BeTrue();

        [Fact]
        public void Foo()
        {
            var t = typeof(Sample);
            var values = Enum.GetValues(t);
            foreach (var value in values)
            {
                var name = value;
                var enumValue = (int) value;
                var x = true;
            }
        }
    }
}