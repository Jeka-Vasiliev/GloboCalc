using GloboCalc.Core.Abstractions;

namespace GloboCalc.Core
{
    public class Calc : ICalc
    {
        private readonly ITokenizer _tokenizer;
        private readonly IInfixToPostfixNotationConverter _tokensToCommands;
        private readonly IPostfixNotationCalculator _postfixCalc;

        public Calc(ITokenizer tokenizer, IInfixToPostfixNotationConverter tokensToCommands, IPostfixNotationCalculator postfixCalc)
        {
            _tokenizer = tokenizer;
            _tokensToCommands = tokensToCommands;
            _postfixCalc = postfixCalc;
        }

        public double CalculateExpression(string expression)
        {
            var tokens = _tokenizer.Parse(expression);
            var commands = _tokensToCommands.Convert(tokens);
            var result = _postfixCalc.Execute(commands);

            return result;
        }
    }
}
