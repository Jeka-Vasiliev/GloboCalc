using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace GloboCalc.Core.Tokenization
{
    public class Tokenizer
    {
        const char decimalSeparator = '.';
        string validOperators = "+-*/%^";

        public Tokenizer()
        {

        }

        public List<Token> Parse(string expression)
        {
            var tokens = new List<Token>();

            var chars = expression.ToCharArray();

            var unaryMinus = false;
            var unaryMinusPosition = -1;

            for (var i = 0; i < chars.Length; i++)
            {
                if (IsNumberStarting(chars[i]))
                {
                    var startIndex = i;
                    var prefix = "";
                    if (unaryMinus)
                    {
                        unaryMinus = false;
                        startIndex = unaryMinusPosition;
                        prefix = "-";
                    }
                    var lexeme = ReadLexeme(chars, ref i, IsNumberPart, prefix);
                    tokens.Add(new Token(lexeme, TokenCategory.Number, startIndex));
                }
                else if (IsFunctionStarting(chars[i]))
                {
                    if (unaryMinus) { throw new ParseException(i); }
                    var startIndex = i;
                    var lexeme = ReadLexeme(chars, ref i, IsFunctionPart);
                    tokens.Add(new Token(lexeme, TokenCategory.Operator, startIndex));
                }
                else if (IsEmptySpace(chars[i]))
                {
                    continue;
                }
                else if (IsUnaryMinus(chars[i], tokens))
                {
                    if (unaryMinus) { throw new ParseException(i); }
                    unaryMinus = true;
                    unaryMinusPosition = i;
                }
                else if (IsOperator(chars[i]))
                {
                    if (unaryMinus) { throw new ParseException(i); }
                    tokens.Add(new Token(chars[i].ToString(), TokenCategory.Operator, i));
                }
                else if (IsLeftBracket(chars[i]))
                {
                    if (unaryMinus) { throw new ParseException(i); }
                    tokens.Add(new Token(chars[i].ToString(), TokenCategory.LeftBracket, i));
                }
                else if (IsRightBracket(chars[i]))
                {
                    if (unaryMinus) { throw new ParseException(i); }
                    tokens.Add(new Token(chars[i].ToString(), TokenCategory.RightBracket, i));
                }
            }

            return tokens;
        }

        private bool IsLeftBracket(char character)
        {
            return character == '(';
        }

        private bool IsRightBracket(char character)
        {
            return character == ')';
        }

        private bool IsOperator(char character)
        {
            return validOperators.Any(op => op == character);
        }


        private bool IsUnaryMinus(char character, List<Token> tokens)
        {
            if (character != '-') { return false; }
            else if (!tokens.Any()) { return true; }
            else if (tokens.Last().TokenCategory == TokenCategory.Operator || (tokens.Last().TokenCategory == TokenCategory.LeftBracket)) { return true; }
            else { return false; }
        }

        private bool IsNumberStarting(char character)
        {
            return (character >= '1' && character <= '9');
        }

        private bool IsEmptySpace(char character)
        {
            return (character == ' ' && character == '\t');
        }

        private bool IsNumberPart(char character)
        {
            return (character >= '1' && character <= '9') || character == decimalSeparator;
        }

        private bool IsFunctionStarting(char character)
        {
            return (character >= 'a' && character <= 'z') || (character >= 'A' && character <= 'Z');
        }

        private bool IsFunctionPart(char character)
        {
            return (character >= 'a' && character <= 'z') ||
                (character >= 'A' && character <= 'Z') ||
                (character >= '1' && character <= '9');
        }

        private string ReadLexeme(char[] chars, ref int i, Func<char, bool> isPartOfLexeme, string prefix = "")
        {
            var buffer = new StringBuilder();
            buffer.Append(prefix);
            do
            {
                buffer.Append(chars[i]);
                i++;
            }
            while (i < chars.Length && isPartOfLexeme(chars[i]));
            i--;    // итерация произойдет во внешнем цикле
            return buffer.ToString();
        }
    }
}
