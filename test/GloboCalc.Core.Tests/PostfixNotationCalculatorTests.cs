using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;
using GloboCalc.Core.Tokenization;
using GloboCalc.Core.Operations.Abstractions;
using GloboCalc.Core.Operations;

namespace GloboCalc.Core.Tests
{
    public class PostfixNotationCalculatorTests
    {
        [Fact]
        public void PostfixNotationCalculator_Execute_Simple()
        {
            // 3 4 +
            var evaluator = new PostfixNotationCalculator();
            var tokens = new List<IOperation>
            {
                new Constant(3),
                new Constant(4),
                new Addition(),
            };

            var result = evaluator.Execute(tokens);

            result.Should().Be(7d);
        }

        [Fact]
        public void PostfixNotationCalculator_Execute_Multiple()
        {
            // 15 7 1 1 + − / 3 * 2 1 1 + + −
            var evaluator = new PostfixNotationCalculator();
            var tokens = new List<IOperation>
            {
                new Constant(15),
                new Constant(7),
                new Constant(1),
                new Constant(1),
                new Addition(),
                new Subtraction(),
                new Division(),
                new Constant(3),
                new Multiplication(),
                new Constant(2),
                new Constant(1),
                new Constant(1),
                new Addition(),
                new Addition(),
                new Subtraction(),
           };

            var result = evaluator.Execute(tokens);

            result.Should().Be(5d);
        }

    }
}
