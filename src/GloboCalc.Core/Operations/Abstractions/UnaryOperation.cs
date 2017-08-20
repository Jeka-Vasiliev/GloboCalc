using GloboCalc.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace GloboCalc.Core.Operations.Abstractions
{
    public abstract class UnaryOperation : IOperation
    {
        protected abstract double Apply(double value);

        public void Execute(IResultStack resultStack)
        {
            var value = resultStack.Pop();
            var result = Apply(value);
            resultStack.Push(result);
        }
    }
}
