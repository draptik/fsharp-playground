using FluentAssertions;
using Xunit;

namespace Domain.Tests.CSharp
{
    public class EbayTests
    {
        [Fact]
        public void GetSearchResultFor_returns_correct_result() =>
            Ebay.GetSearchResultsFor("foo").Should().Be("FOO");
    }
}
