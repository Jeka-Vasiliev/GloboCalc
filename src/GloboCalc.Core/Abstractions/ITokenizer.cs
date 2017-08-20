using GloboCalc.Core.Tokenization;
using System.Collections.Generic;

namespace GloboCalc.Core.Abstractions
{
    /// <summary>
    /// Токенизирует выражение
    /// </summary>
    public interface ITokenizer
    {
        /// <summary>
        /// Разбирает выражение на токены
        /// </summary>
        /// <param name="expression">Выражение</param>
        /// <returns>Токены</returns>
        List<Token> Parse(string expression);
    }
}