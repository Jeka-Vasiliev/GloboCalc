using GloboCalc.Core.Operations.Abstractions;

namespace GloboCalc.Core.Operations
{
    /// <summary>
    /// Операнд стека
    /// </summary>
    public class Constant : IOperation
    {
        public double Value { get; }

        public Constant(double value)
        {
            Value = value;
        }

        public void Execute(IResultStack resultStack)
        {
            resultStack.Push(Value);
        }
    }
}
