using GloboCalc.Core.Operations.Abstractions;
using GloboCalc.Core.Tokenization;

namespace GloboCalc.Core.Abstractions
{
    /// <summary>
    /// Фабрика для создания всех операторов выражения
    /// </summary>
    public interface IAllOperationsFactory: IOperationPropertiesExtractor
    {
        /// <summary>
        /// Создает оператор
        /// </summary>
        /// <param name="token">Токен исходного выражения</param>
        /// <returns>Операция</returns>
        IOperation CreateOperator(Token token);
    }
}