namespace MMT.Src.UnitTests.Extensions
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using FluentAssertions;
    using MMT.Src.Extensions;
    using Xunit;

    public class IEnumerableExtenionsTests
    {
        [Theory]
        [MemberData(nameof(IsNullOrEmptyTestData))]
        public void IsNullOrEmpty_ReturnsExpectedResult(IEnumerable<string> enumerable, bool expected)
        {
            enumerable.IsNullOrEmpty().Should().Be(expected);
        }

        public static IList<object[]> IsNullOrEmptyTestData()
        {
            return new List<object[]>
            {
                new object[]
                {
                    null,
                    true
                },
                new object[]
                {
                    new Collection<string>(),
                    true
                },
                new object[]
                {
                    new Collection<string> { "something" },
                    false
                },
                new object[]
                {
                    new List<string> { "something else" },
                    false
                }
            };
        }
    }
}