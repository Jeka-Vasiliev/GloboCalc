using System.Collections.Generic;
using GloboCalc.Core.Operations.Abstractions;
using GloboCalc.Core.Tokenization;

namespace GloboCalc.Core.Abstractions
{
    public interface IInfixToPostfixNotationConverter
    {
        List<IOperation> Convert(List<Token> tokens);
    }
}