using GloboCalc.Core.Operations.Abstractions;
using System;

namespace GloboCalc.Core.Operations
{
    public class SinFunction : UnaryOperation
    {
        protected override double Apply(double value)
        {
            return Math.Sin(value);
        }
    }
}