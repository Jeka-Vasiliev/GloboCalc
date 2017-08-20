using GloboCalc.Core.Tokenization;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;
using System.Linq;
using GloboCalc.Core.Operations;
using GloboCalc.Core.Operations.Abstractions;
using GloboCalc.Core.Abstractions;
using GloboCalc.Core.Operations.Factories;

namespace GloboCalc.Core.Tests
{
    public class InfixToPostfixNotationConverterTests
    {
        private IInfixToPostfixNotationConverter GetConverter()
        {
            var operationsFactory = new AllOperationsFactory(new IOperationFactory[]
            {
                new AdditionFactory(),
                new SubtractionFactory(),
                new MultiplicationFactory(),
                new DivisionFactory(),
                new ExponentiationFactory(),
                new SinFunctionFactory(),
            });
            return new InfixToPostfixNotationConverter(operationsFactory);
        }

        [Fact]
        public void InfixToPostfixNotationConverter_Convert_Simple()
        {
            // 3 + 4
            var converter = GetConverter();
            var tokens = new List<Token>
            {
                new Token("3", TokenCategory.Number, 0),
                new Token("+", TokenCategory.Operator, 1),
                new Token("4", TokenCategory.Number, 2),
            };

            var result = converter.Convert(tokens);

            // 3 4 +
            result.Should().HaveCount(3);
            result[0].Should().BeOfType<Constant>().Which.Value.Should().Be(3d);
            result[1].Should().BeOfType<Constant>().Which.Value.Should().Be(4d);
            result[2].Should().BeOfType<Addition>();
        }

        [Fact]
        public void InfixToPostfixNotationConverter_Convert_Brackets()
        {
            // 3 + 4 * (2 − 1)
            var converter = GetConverter();
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

            var result = converter.Convert(tokens);

            // 3 4 2 1 − * +
            result.Should().HaveCount(7);
            result[0].Should().BeOfType<Constant>().Which.Value.Should().Be(3d);
            result[1].Should().BeOfType<Constant>().Which.Value.Should().Be(4d);
            result[2].Should().BeOfType<Constant>().Which.Value.Should().Be(2d);
            result[3].Should().BeOfType<Constant>().Which.Value.Should().Be(1d);
            result[4].Should().BeOfType<Subtraction>();
            result[5].Should().BeOfType<Multiplication>();
            result[6].Should().BeOfType<Addition>();
        }

        [Fact]
        public void InfixToPostfixNotationConverter_Convert_RightAssociativity()
        {
            // 3 + 4 * 2 / ( 1 − 5 ) ^ 2 ^ 3
            var converter = GetConverter();
            var tokens = new List<Token>
            {
                new Token("3", TokenCategory.Number, 0),
                new Token("+", TokenCategory.Operator, 1),
                new Token("4", TokenCategory.Number, 2),
                new Token("*", TokenCategory.Operator, 3),
                new Token("2", TokenCategory.Number, 4),
                new Token("/", TokenCategory.Operator, 5),
                new Token("(", TokenCategory.LeftBracket, 6),
                new Token("1", TokenCategory.Number, 7),
                new Token("-", TokenCategory.Operator, 8),
                new Token("5", TokenCategory.Number, 9),
                new Token(")", TokenCategory.RightBracket, 10),
                new Token("^", TokenCategory.Operator, 11),
                new Token("2", TokenCategory.Number, 12),
                new Token("^", TokenCategory.Operator, 13),
                new Token("3", TokenCategory.Number, 14),
            };

            var result = converter.Convert(tokens);

            // 3 4 2 * 1 5 − 2 3 ^ ^ / +
            result.Should().HaveCount(13);
            result[0].Should().BeOfType<Constant>().Which.Value.Should().Be(3d);
            result[1].Should().BeOfType<Constant>().Which.Value.Should().Be(4d);
            result[2].Should().BeOfType<Constant>().Which.Value.Should().Be(2d);
            result[3].Should().BeOfType<Multiplication>();
            result[4].Should().BeOfType<Constant>().Which.Value.Should().Be(1d);
            result[5].Should().BeOfType<Constant>().Which.Value.Should().Be(5d);
            result[6].Should().BeOfType<Subtraction>();
            result[7].Should().BeOfType<Constant>().Which.Value.Should().Be(2d);
            result[8].Should().BeOfType<Constant>().Which.Value.Should().Be(3d);
            result[9].Should().BeOfType<Exponentiation>();
            result[10].Should().BeOfType<Exponentiation>();
            result[11].Should().BeOfType<Division>();
            result[12].Should().BeOfType<Addition>();
        }


        [Fact]
        public void InfixToPostfixNotationConverter_Convert_MismatchedOperator()
        {
            var converter = GetConverter();
            var tokens = new List<Token>
            {
                new Token("3", TokenCategory.Number, 0),
                new Token("+", TokenCategory.Operator, 1),
                new Token("randomFunc", TokenCategory.Operator, 2),
            };

            converter.Invoking(c => c.Convert(tokens))
                .ShouldThrowExactly<ParseException>()
                .Where(e => e.Position == 2);
        }
    }
}
