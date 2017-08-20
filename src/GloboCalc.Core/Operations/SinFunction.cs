using GloboCalc.Core.Operations.Abstractions;
using System;

namespace GloboCalc.Core.Operations
{
    public class SinFunction : UnaryOperation
    {
        public SinFunction() { }
        public SinFunction(int position): base(position) { }

        protected override double Apply(double value)
        {
            return Math.Sin(value);
        }
    }
}