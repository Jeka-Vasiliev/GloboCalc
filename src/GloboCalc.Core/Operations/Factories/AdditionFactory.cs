using GloboCalc.Core.Abstractions;
using GloboCalc.Core.Operations.Abstractions;

namespace GloboCalc.Core.Operations.Factories
{
    public class AdditionFactory : IOperationFactory
    {
        public string TokenValue => "+";

        public Associativity Associativity => Associativity.Left;

        public int Presendence => 2;

        public IOperation Create()
        {
            return new Addition();
        }
    }
}
