using GloboCalc.Core.Tokenization;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;
using System.Linq;

namespace GloboCalc.Core.Tests
{
    public class RpnPrecedenceParserTests
    {
        [Fact]
        public void RpnPrecedenceParser_Order_Simple()
        {
            // 3 + 4
            var builder = new RpnPrecedenceParser();
            var tokens = new List<Token>
            {
                new Token("3", TokenCategory.Number, 0),
                new Token("+", TokenCategory.Operator, 1),
                new Token("4", TokenCategory.Number, 2),
            };

            var result = builder.Order(tokens);

            // 3 4 +
            result.Select(token => token.Value)
                .ShouldAllBeEquivalentTo(new[] { "3", "4", "+" });
        }

        [Fact]
        public void RpnPrecedenceParser_Order_Brackets()
        {
            // 3 + 4 * (2 − 1)
            var builder = new RpnPrecedenceParser();
            var tokens = new List<Token>
            {
                new Token("3", TokenCategory.Number, 0),
                new Token("+", TokenCategory.Operator, 1),
                new Token("4", TokenCategory.Number, 2),
                new Token("*", TokenCategory.Operator, 3),
                new Token("(", TokenCategory.LeftBracket, 4),
                new Token("2", TokenCategory.Number, 5),
                new Token("-", TokenCategory.Operator, 6),
                new Token("1", TokenCategory.Number, 7),
                new Token(")", TokenCategory.RightBracket, 8),
            };

            var result = builder.Order(tokens);

            // 3 4 2 1 − * +
            result.Select(token => token.Value)
                .ShouldAllBeEquivalentTo(new[] { "3", "4", "2", "1", "-", "*", "+" });
        }

        [Fact]
        public void RpnPrecedenceParser_Order_RightAssociativity()
        {
            // 3 + 4 * 2 / ( 1 − 5 ) ^ 2 ^ 3
            var builder = new RpnPrecedenceParser();
            var tokens = new List<Token>
            {
                new Token("3", TokenCategory.Number, 0),
                new Token("+", TokenCategory.Operator, 1),
                new Token("4", TokenCategory.Number, 2),
                new Token("*", TokenCategory.Operator, 3),
                new Token("2", TokenCategory.Number, 4),
                new Token("/", TokenCategory.Operator, 5),
                new Token("(", TokenCategory.Number, 6),
                new Token("1", TokenCategory.Number, 7),
                new Token("-", TokenCategory.Operator, 8),
                new Token("5", TokenCategory.Number, 9),
                new Token(")", TokenCategory.Number, 10),
                new Token("^", TokenCategory.Operator, 11),
                new Token("2", TokenCategory.Number, 12),
                new Token("^", TokenCategory.Operator, 13),
                new Token("3", TokenCategory.Number, 14),
            };

            var result = builder.Order(tokens);

            // 3 4 2 * 1 5 − 2 3 ^ ^ / +
            var expected = new[] { "3", "4", "2", "*", "1", "5", "-", "2", "3", "^", "^", "/", "+" };
            result.Select(token => token.Value)
                .ShouldAllBeEquivalentTo(expected);
        }
    }
}
