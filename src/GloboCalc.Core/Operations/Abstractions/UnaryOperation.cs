using GloboCalc.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace GloboCalc.Core.Operations.Abstractions
{
    public abstract class UnaryOperation : IOperation
    {
        public int Position { get; }

        public UnaryOperation() { }
        public UnaryOperation(int position)
        {
            Position = position;
        }

        protected abstract double Apply(double value);

        public void Execute(IResultStack resultStack)
        {
            try
            {
                var value = resultStack.Pop();
                var result = Apply(value);
                resultStack.Push(result);
            }
            catch (InvalidOperationException ex)
            {
                throw new ParseException("Invalid operatior", Position, ex);
            }
        }
    }
}
