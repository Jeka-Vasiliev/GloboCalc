using GloboCalc.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using GloboCalc.Core.Operations.Abstractions;

namespace GloboCalc.Core.Operations.Factories
{
    public class ExponentiationFactory : IOperationFactory
    {
        public string TokenValue => "^";

        public Associativity Associativity => Associativity.Right;

        public int Presendence => 4;

        public IOperation Create()
        {
            return new Exponentiation();
        }
    }
}
