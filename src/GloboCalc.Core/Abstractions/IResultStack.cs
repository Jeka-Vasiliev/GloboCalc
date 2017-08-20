namespace GloboCalc.Core.Abstractions
{
    /// <summary>
    /// Базовые операции для стека вычисления результата
    /// </summary>
    public interface IResultStack
    {
        /// <summary>
        /// Кладет элемент в стек
        /// </summary>
        /// <param name="value">Элемент</param>
        void Push(double value);

        /// <summary>
        /// Берет верхний элемент со стека
        /// </summary>
        /// <returns>Верхний элемент</returns>
        double Pop();
    }
}
