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

        [Fact]
        public void PostfixNotationCalculator_Execute_Sin()
        {
            // 2 sin
            var evaluator = new PostfixNotationCalculator();
            var tokens = new List<IOperation>
            {
                new Constant(2d),
                new SinFunction(),
           };

            var result = evaluator.Execute(tokens);

            result.Should().BeApproximately(0.9d, 0.1d);
        }

        [Fact]
        public void PostfixNotationCalculator_Execute_MimatchedOperators()
        {
            // +
            var evaluator = new PostfixNotationCalculator();
            var operations = new List<IOperation>
            {
                new Addition(1),
            };

            evaluator.Invoking(c => c.Execute(operations))
                .ShouldThrowExactly<ParseException>()
                .Where(e => e.Position == 1);
        }

        [Fact]
        public void PostfixNotationCalculator_Execute_MimatchedOperands()
        {
            // 1 2
            var evaluator = new PostfixNotationCalculator();
            var operations = new List<IOperation>
            {
                new Constant(1d, 1),
                new Constant(2d, 3),
            };

            evaluator.Invoking(c => c.Execute(operations))
                .ShouldThrowExactly<ParseException>()
                .Where(e => e.Position == 0);
        }

    }
}
