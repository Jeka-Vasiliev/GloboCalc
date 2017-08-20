using GloboCalc.Core.Operations.Abstractions;

namespace GloboCalc.Core.Operations
{
    public class Multiplication : BinaryOperation
    {
        public Multiplication() { }
        public Multiplication(int position): base(position) { }

        protected override double Apply(double left, double right)
        {
            return left * right;
        }
    }
}