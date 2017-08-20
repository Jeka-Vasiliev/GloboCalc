using GloboCalc.Core.Operations.Abstractions;
using System;

namespace GloboCalc.Core.Operations
{
    public class Exponentiation : BinaryOperation
    {
        public Exponentiation() { }
        public Exponentiation(int position): base(position) { }

        protected override double Apply(double left, double right)
        {
            return Math.Pow(left, right);
        }
    }
}