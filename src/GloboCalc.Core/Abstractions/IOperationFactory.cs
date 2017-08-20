using GloboCalc.Core.Operations.Abstractions;

namespace GloboCalc.Core.Abstractions
{
    /// <summary>
    /// Фабрика допустимых операций и функций
    /// </summary>
    public interface IOperationFactory
    {
        /// <summary>
        /// Значение токена по которому будет определятся операция
        /// </summary>
        string TokenValue { get; }

        /// <summary>
        /// Ассоциативность
        /// </summary>
        Associativity Associativity { get; }

        /// <summary>
        /// Старшинство операции (чем старше - тем раньше выполняется)
        /// </summary>
        int Presendence { get; }

        /// <summary>
        /// Создает операцию
        /// </summary>
        /// <returns>Операция</returns>
        IOperation Create();
    }
}
