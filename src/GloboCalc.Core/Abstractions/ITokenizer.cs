using GloboCalc.Core.Tokenization;
using System.Collections.Generic;

namespace GloboCalc.Core.Abstractions
{
    public interface ITokenizer
    {
        List<Token> Parse(string expression);
    }
}