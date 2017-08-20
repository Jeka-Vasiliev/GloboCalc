using GloboCalc.Core.Operations;
using GloboCalc.Core.Operations.Abstractions;
using GloboCalc.Core.Tokenization;

namespace GloboCalc.Core
{
    public class OperationFactory
    {
        public IOperation CreateOperator(Token token)
        {
            switch (token.Value)
            {
                case "+":
                    return new Addition();
                case "-":
                    return new Subtraction();
                case "*":
                    return new Multiplication();
                case "/":
                    return new Division();
                case "^":
                    return new Exponentiation();
                case "sin":
                    return new SinFunction();
                default:
                    throw new ParseException("Unknown operation", token.Position);
            }
        }
    }
}
