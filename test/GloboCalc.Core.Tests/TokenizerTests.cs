using System.Collections.Generic;
using Xunit;
using FluentAssertions;
using GloboCalc.Core.Tokenization;

namespace GloboCalc.Core.Tests
{
    public class TokenizerTests
    {
        [Fact]
        public void Tokenizer_Parse_Simple()
        {
            var tokenazer = new Tokenizer();
            var tokens = tokenazer.Parse("1 + 2 * 3");

            tokens.ShouldAllBeEquivalentTo(new List<Token>
            {
                new Token("1", TokenCategory.Number, 0),
                new Token("+", TokenCategory.Operator, 2),
                new Token("2", TokenCategory.Number, 4),
                new Token("*", TokenCategory.Operator, 6),
                new Token("3", TokenCategory.Number, 8),
            });
        }

        [Fact]
        public void Tokenizer_Parse_Parentesis()
        {
            var tokenazer = new Tokenizer();
            var tokens = tokenazer.Parse("(1 + 2)*3");

            tokens.ShouldAllBeEquivalentTo(new List<Token>
            {
                new Token("(", TokenCategory.LeftBracket, 0),
                new Token("1", TokenCategory.Number, 1),
                new Token("+", TokenCategory.Operator, 3),
                new Token("2", TokenCategory.Number, 5),
                new Token(")", TokenCategory.RightBracket, 6),
                new Token("*", TokenCategory.Operator, 7),
                new Token("3", TokenCategory.Number, 8),
            });
        }

        [Fact]
        public void Tokenizer_Parse_Func()
        {
            var tokenazer = new Tokenizer();
            var tokens = tokenazer.Parse("sin(-1 + 2)");

            tokens.ShouldAllBeEquivalentTo(new List<Token>
            {
                new Token("sin", TokenCategory.Operator, 0),
                new Token("(", TokenCategory.LeftBracket, 3),
                new Token("-1", TokenCategory.Number, 4),
                new Token("+", TokenCategory.Operator, 7),
                new Token("2", TokenCategory.Number, 9),
                new Token(")", TokenCategory.RightBracket, 10),
            });
        }

        [Fact]
        public void Tokenizer_Parse_UnaryMinus()
        {
            var tokenazer = new Tokenizer();
            var tokens = tokenazer.Parse("-1 * (-2)");

            tokens.ShouldAllBeEquivalentTo(new List<Token>
            {
                new Token("-1", TokenCategory.Number, 0),
                new Token("*", TokenCategory.Operator, 3),
                new Token("(", TokenCategory.LeftBracket, 5),
                new Token("-2", TokenCategory.Number, 6),
                new Token(")", TokenCategory.RightBracket, 8),
            });
        }

        [Fact]
        public void Tokenizer_Parse_Float()
        {
            var tokenazer = new Tokenizer();
            var tokens = tokenazer.Parse(" 1.1 + 2.2 ");

            tokens.ShouldAllBeEquivalentTo(new List<Token>
            {
                new Token("1.1", TokenCategory.Number, 1),
                new Token("+", TokenCategory.Operator, 5),
                new Token("2.2", TokenCategory.Number, 7),
            });
        }

        [Fact]
        public void Tokenizer_Parse_Globo()
        {
            var tokenazer = new Tokenizer();
            var tokens = tokenazer.Parse("23 * 2 + 45 - 24 / 5");

            tokens.ShouldAllBeEquivalentTo(new List<Token>
            {
                new Token("23", TokenCategory.Number, 0),
                new Token("*", TokenCategory.Operator, 3),
                new Token("2", TokenCategory.Number, 5),
                new Token("+", TokenCategory.Operator, 7),
                new Token("45", TokenCategory.Number, 9),
                new Token("-", TokenCategory.Operator, 12),
                new Token("24", TokenCategory.Number, 14),
                new Token("/", TokenCategory.Operator, 17),
                new Token("5", TokenCategory.Number, 19),
            });
        }

    }
}
