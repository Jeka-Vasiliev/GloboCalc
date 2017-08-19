using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;
using GloboCalc.Core.Tokenization;

namespace GloboCalc.Core.Tests
{
    public class RpnEvaluatorTests
    {
        [Fact]
        public void RpnEvaluator_Eval_Simple()
        {
            // 3 4 +
            var evaluator = new RpnEvaluator();
            var tokens = new List<Token>
            {
                new Token("3", TokenCategory.Number, 0),
                new Token("4", TokenCategory.Number, 2),
                new Token("+", TokenCategory.Operator, 1),
            };

            var result = evaluator.Eval(tokens);

            result.Should().Be(7d);
        }

        [Fact]
        public void RpnEvaluator_Eval_Multiple()
        {
            // 15 7 1 1 + − / 3 * 2 1 1 + + −
            var evaluator = new RpnEvaluator();
            var tokens = new List<Token>
            {
                new Token("15", TokenCategory.Number, 0),
                new Token("7", TokenCategory.Number, 1),
                new Token("1", TokenCategory.Number, 2),
                new Token("1", TokenCategory.Number, 3),
                new Token("+", TokenCategory.Operator, 4),
                new Token("-", TokenCategory.Operator, 5),
                new Token("/", TokenCategory.Operator, 6),
                new Token("3", TokenCategory.Number, 7),
                new Token("*", TokenCategory.Operator, 8),
                new Token("2", TokenCategory.Number, 9),
                new Token("1", TokenCategory.Number, 10),
                new Token("1", TokenCategory.Number, 11),
                new Token("+", TokenCategory.Operator, 12),
                new Token("+", TokenCategory.Operator, 13),
                new Token("-", TokenCategory.Operator, 14),
            };

            var result = evaluator.Eval(tokens);

            result.Should().Be(5d);
        }
    }
}
