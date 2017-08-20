using GloboCalc.Core.Abstractions;
using GloboCalc.Core.Tokenization;

namespace GloboCalc.Core
{
    public class Calc : ICalc
    {
        private ITokenizer _tokenizer;
        private IInfixToPostfixNotationConverter _tokensToCommands;
        private IPostfixNotationCalculator _postfixCalc;

        public Calc()
        {
            _tokenizer = new Tokenizer();
            _tokensToCommands = new InfixToPostfixNotationConverter(new AllOperationsFactory());
            _postfixCalc = new PostfixNotationCalculator();
        }

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
