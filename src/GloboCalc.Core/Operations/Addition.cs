using GloboCalc.Core.Operations.Abstractions;

namespace GloboCalc.Core.Operations
{
    public class Addition : BinaryOperation
    {
        public Addition() { }
        public Addition(int position): base(position) { }

        protected override double Apply(double left, double right)
        {
            return left + right;
        }
    }
}
