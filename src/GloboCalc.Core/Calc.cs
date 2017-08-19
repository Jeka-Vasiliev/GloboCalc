using GloboCalc.Core.Tokenization;
using System;
using System.Collections.Generic;
using System.Text;

namespace GloboCalc.Core
{
    public class Calc
    {
        private Tokenizer _tokenizer;
        private RpnPrecedenceParser _orderer;
        private RpnEvaluator _evaluator;

        public Calc()
        {
            _tokenizer = new Tokenizer();
            _orderer = new RpnPrecedenceParser();
            _evaluator = new RpnEvaluator();
        }

        public double CalculateExpression(string expression)
        {
            var tokens = _tokenizer.Parse(expression);
            var rpnTokens = _orderer.Order(tokens);
            var result = _evaluator.Eval(rpnTokens);

            return result;
        }
    }
}
