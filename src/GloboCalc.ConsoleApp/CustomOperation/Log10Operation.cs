using GloboCalc.Core.Operations.Abstractions;
using System;

namespace GloboCalc.ConsoleApp.CustomOperation
{
    class Log10Operation : UnaryOperation
    {
        protected override double Apply(double value)
        {
            return Math.Log10(value);
        }
    }
}
