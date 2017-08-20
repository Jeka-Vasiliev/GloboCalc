using System.Collections.Generic;
using GloboCalc.Core.Operations.Abstractions;
using GloboCalc.Core.Tokenization;

namespace GloboCalc.Core.Abstractions
{
    /// <summary>
    /// Превраящет инфиксное выражение (со скобками) в постфикое (Обратную польскую нотацию)
    /// </summary>
    public interface IInfixToPostfixNotationConverter
    {
        /// <summary>
        /// Конвертирует токены в постфиксные операции
        /// </summary>
        /// <param name="tokens">Список токенов</param>
        /// <returns>Список операций</returns>
        List<IOperation> Convert(List<Token> tokens);
    }
}