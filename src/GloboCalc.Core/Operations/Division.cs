using GloboCalc.Core.Operations.Abstractions;

namespace GloboCalc.Core.Operations
{
    public class Division : BinaryOperation
    {
        public Division() { }
        public Division(int position): base(position) { }

        protected override double Apply(double left, double right)
        {
            return left / right;
        }
    }
}