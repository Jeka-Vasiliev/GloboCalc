using GloboCalc.Core.Operations.Abstractions;
using System;

namespace GloboCalc.ConsoleApp.CustomOperation
{
    class Log10Operation : UnaryOperation
    {
        public Log10Operation() : base() { }
        public Log10Operation(int position) : base(position) { }

        protected override double Apply(double value)
        {
            return Math.Log10(value);
        }
    }
}
