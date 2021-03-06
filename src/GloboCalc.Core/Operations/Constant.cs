﻿using GloboCalc.Core.Abstractions;
using GloboCalc.Core.Operations.Abstractions;

namespace GloboCalc.Core.Operations
{
    /// <summary>
    /// Операнд стека
    /// </summary>
    public class Constant : IOperation
    {
        public double Value { get; }

        public int Position { get; }

        public Constant(double value)
        {
            Value = value;
        }
        public Constant(double value, int position)
        {
            Value = value;
            Position = position;
        }

        public void Execute(IResultStack resultStack)
        {
            resultStack.Push(Value);
        }
    }
}
