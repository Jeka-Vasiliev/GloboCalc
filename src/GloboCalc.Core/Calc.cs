using GloboCalc.Core.Tokenization;
using System;
using System.Collections.Generic;
using System.Text;

namespace GloboCalc.Core
{
    public class Calc
    {
        private Tokenizer _tokenizer;
        private InfixToPostfixNotationConverter _tokensToCommands;
        private PostfixNotationCalculator _postfixCalc;

        public Calc()
        {
            _tokenizer = new Tokenizer();
            _tokensToCommands = new InfixToPostfixNotationConverter();
            _postfixCalc = new PostfixNotationCalculator();
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
