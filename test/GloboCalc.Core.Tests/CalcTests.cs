using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;

namespace GloboCalc.Core.Tests
{
    public class CalcTests
    {
        [Theory]
        [InlineData("23 * 2 + 45 - 24 / 5", 86.2d)]
        [InlineData("1 + 2 * 3", 7d)]
        [InlineData("(1 + 2) * 3", 9d)]
        [InlineData("(-1 + 2)", 1d)]
        [InlineData("((2 + 3)/5)^3", 1d)]
        public void Calc_CalculateExpression(string expression, double expectedResult)
        {
            var calc = new Calc();

            var result = calc.CalculateExpression(expression);

            result.Should().Be(expectedResult, "because expression is {0}", expression);
        }
    }
}
