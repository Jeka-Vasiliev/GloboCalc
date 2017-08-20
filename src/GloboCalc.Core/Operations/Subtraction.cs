using GloboCalc.Core.Operations.Abstractions;

namespace GloboCalc.Core.Operations
{
    public class Subtraction : BinaryOperation
    {
        public Subtraction() { }
        public Subtraction(int position): base(position) { }

        protected override double Apply(double left, double right)
        {
            return left - right;
        }
    }
}
