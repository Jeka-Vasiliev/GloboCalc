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
                new Token("+", TokenCategory.Number, 2),
                new Token("2", TokenCategory.Number, 4),
                new Token("*", TokenCategory.Number, 6),
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
                new Token("+", TokenCategory.Operator, 2),
                new Token("2", TokenCategory.Number, 4),
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
                new Token("-1", TokenCategory.LeftBracket, 4),
                new Token("+", TokenCategory.LeftBracket, 6),
                new Token("2", TokenCategory.Number, 8),
                new Token(")", TokenCategory.RightBracket, 9),
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
                new Token("1.1", TokenCategory.Operator, 1),
                new Token("+", TokenCategory.Operator, 5),
                new Token("2.2", TokenCategory.Operator, 7),
            });
        }

    }
}
