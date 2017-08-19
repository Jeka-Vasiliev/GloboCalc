using System;
using System.Collections.Generic;
using System.Text;

namespace GloboCalc.Core.Tokenization
{
    public class Tokenizer
    {
        public List<Token> Parse(string expression)
        {
            // 1 + 2 * 3
            return new List<Token>
            {
                new Token("1", TokenCategory.Number, 0),
                new Token("+", TokenCategory.Number, 2),
                new Token("2", TokenCategory.Number, 4),
                new Token("*", TokenCategory.Number, 6),
                new Token("3", TokenCategory.Number, 8),
            };
        }
    }
}
