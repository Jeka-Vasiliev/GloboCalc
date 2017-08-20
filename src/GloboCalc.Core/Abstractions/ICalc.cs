namespace GloboCalc.Core.Abstractions
{
    /// <summary>
    /// Выполняет арифметические операции
    /// </summary>
    public interface ICalc
    {
        /// <summary>
        /// Выполняет разбор выражения и возвращает результат
        /// </summary>
        double CalculateExpression(string expression);
    }
}