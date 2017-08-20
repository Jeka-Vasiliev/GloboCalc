using GloboCalc.Core.Abstractions;

namespace GloboCalc.Core.Operations.Abstractions
{
    /// <summary>
    /// Применяет бинарную операцию к стеку
    /// </summary>
    public abstract class BinaryOperation: IOperation
    {
        protected abstract double Apply(double left, double right);

        public void Execute(IResultStack resultStack)
        {
            var right = resultStack.Pop();
            var left = resultStack.Pop();
            var result = Apply(left, right);
            resultStack.Push(result);
        }
    }
}