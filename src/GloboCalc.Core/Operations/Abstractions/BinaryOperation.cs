using GloboCalc.Core.Abstractions;
using System;

namespace GloboCalc.Core.Operations.Abstractions
{
    /// <summary>
    /// Применяет бинарную операцию к стеку
    /// </summary>
    public abstract class BinaryOperation : IOperation
    {
        public int Position { get; }

        public BinaryOperation() { }
        public BinaryOperation(int position)
        {
            Position = position;
        }

        protected abstract double Apply(double left, double right);

        public void Execute(IResultStack resultStack)
        {
            try
            {
                var right = resultStack.Pop();
                var left = resultStack.Pop();
                var result = Apply(left, right);
                resultStack.Push(result);
            }
            catch (InvalidOperationException ex)
            {
                throw new ParseException("Invalid operatior", Position, ex);
            }
        }
    }
}