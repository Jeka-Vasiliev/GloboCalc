using GloboCalc.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using GloboCalc.Core.Operations.Abstractions;

namespace GloboCalc.Core.Operations.Factories
{
    public class SinFunctionFactory : IOperationFactory
    {
        public string TokenValue => "sin";

        public Associativity Associativity => Associativity.None;

        public int Presendence => 5;

        public IOperation Create()
        {
            return new SinFunction();
        }
    }
}
