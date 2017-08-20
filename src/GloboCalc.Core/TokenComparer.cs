using GloboCalc.Core.Tokenization;
using System;
using System.Collections.Generic;
using System.Text;

namespace GloboCalc.Core
{
    public class TokenComparer
    {
        public bool IsPrecedencer(Token fromStack, Token current)
        {
            if (fromStack.TokenCategory != TokenCategory.Operator)
            {
                return false;
            }

            if (GetPresendence(fromStack) >= GetPresendence(current) && 
                GetAssociativity(fromStack) == Associativity.Left)
            {
                return true;
            }
            return false;
        }

        private Associativity GetAssociativity(Token token)
        {
            switch (token.Value)
            {
                case "+":
                case "-":
                case "*":
                case "/":
                case "%":
                    return Associativity.Left;
                case "^":
                    return Associativity.Right;
                case "sin":
                    return Associativity.None;
                default:
                    throw new ParseException("Unknown Associativity", token.Position);
            }
        }

        private int GetPresendence(Token token)
        {
            switch (token.Value)
            {
                case "+":
                case "-":
                    return 2;
                case "*":
                case "/":
                case "%":
                    return 3;
                case "^":
                    return 4;
                case "sin":
                    return 5;
                default:
                    throw new ParseException("Unknown Presendence", token.Position);
            }
        }
    }
}
