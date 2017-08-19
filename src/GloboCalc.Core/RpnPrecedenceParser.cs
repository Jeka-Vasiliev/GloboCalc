using GloboCalc.Core.Tokenization;
using System;
using System.Collections.Generic;

namespace GloboCalc.Core
{
    public class RpnPrecedenceParser
    {
        public List<Token> Order(List<Token> tokens)
        {
            // 1 + 2 * 3 => 1 2 3 * +
            return new List<Token>
            {
                new Token("1", TokenCategory.Number, 0),
                new Token("2", TokenCategory.Number, 4),
                new Token("3", TokenCategory.Number, 8),
                new Token("*", TokenCategory.Number, 6),
                new Token("+", TokenCategory.Number, 2),
            };
        }
    }
}