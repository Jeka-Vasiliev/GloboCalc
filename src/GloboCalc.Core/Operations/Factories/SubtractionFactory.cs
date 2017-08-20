using GloboCalc.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using GloboCalc.Core.Operations.Abstractions;

namespace GloboCalc.Core.Operations.Factories
{
    public class SubtractionFactory : IOperationFactory
    {
        public string TokenValue => "-";

        public Associativity Associativity => Associativity.Left;

        public int Presendence => 2;

        public IOperation Create(int position)
        {
            return new Subtraction(position);
        }
    }
}
