using GloboCalc.Core.Abstractions;

namespace GloboCalc.Core.Operations.Abstractions
{
    /// <summary>
    /// Оператор или операнд очереди постфиксной нотации
    /// </summary>
    public interface IOperation
    {
        /// <summary>
        /// Обработка текущего токена
        /// </summary>
        void Execute(IResultStack resultStack);
    }
}