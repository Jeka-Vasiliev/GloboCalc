using System.Collections.Generic;
using GloboCalc.Core.Operations.Abstractions;

namespace GloboCalc.Core.Abstractions
{
    /// <summary>
    /// Вычисляет постфиксные выражения
    /// </summary>
    public interface IPostfixNotationCalculator
    {
        /// <summary>
        /// Вычисляет выражение на основе операций
        /// </summary>
        /// <param name="operations">Операции</param>
        /// <returns>Результат</returns>
        double Execute(IEnumerable<IOperation> operations);
    }
}