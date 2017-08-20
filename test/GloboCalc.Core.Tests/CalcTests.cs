using FluentAssertions;
using GloboCalc.Core.Abstractions;
using GloboCalc.Core.Operations.Factories;
using GloboCalc.Core.Tokenization;
using Xunit;

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
            var tokenizer = new Tokenizer();
            var operationsFactory = new AllOperationsFactory(new IOperationFactory[]
            {
                new AdditionFactory(),
                new SubtractionFactory(),
                new MultiplicationFactory(),
                new DivisionFactory(),
                new ExponentiationFactory(),
                new SinFunctionFactory(),
            });
            var tokensToCommands = new InfixToPostfixNotationConverter(operationsFactory);
            var postfixCalc = new PostfixNotationCalculator();
            var calc = new Calc(tokenizer, tokensToCommands, postfixCalc);

            var result = calc.CalculateExpression(expression);

            result.Should().Be(expectedResult, "because expression is {0}", expression);
        }
    }
}
