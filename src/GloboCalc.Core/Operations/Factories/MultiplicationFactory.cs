using GloboCalc.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using GloboCalc.Core.Operations.Abstractions;

namespace GloboCalc.Core.Operations.Factories
{
    public class MultiplicationFactory : IOperationFactory
    {
        public string TokenValue => "*";

        public Associativity Associativity => Associativity.Left;

        public int Presendence => 3;

        public IOperation Create(int position)
        {
            return new Multiplication(position);
        }
    }
}
