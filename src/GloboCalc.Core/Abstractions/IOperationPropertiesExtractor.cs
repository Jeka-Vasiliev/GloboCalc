using GloboCalc.Core.Tokenization;

namespace GloboCalc.Core.Abstractions
{
    /// <summary>
    /// Получение параметров операций
    /// </summary>
    public interface IOperationPropertiesExtractor
    {
        /// <summary>
        /// Возвращает ассоциативность для токена
        /// </summary>
        Associativity GetAssociativity(Token token);

        /// <summary>
        /// Возвращает старшинство для токена
        /// </summary>
        int GetPresendence(Token token);
    }
}
