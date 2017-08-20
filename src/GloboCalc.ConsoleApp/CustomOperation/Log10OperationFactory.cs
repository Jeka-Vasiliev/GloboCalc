using GloboCalc.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using GloboCalc.Core;
using GloboCalc.Core.Operations.Abstractions;

namespace GloboCalc.ConsoleApp.CustomOperation
{
    class Log10OperationFactory : IOperationFactory
    {
        public string TokenValue => "log10";

        public Associativity Associativity => Associativity.None;

        public int Presendence => 5;

        public IOperation Create(int position)
        {
            return new Log10Operation(position);
        }
    }
}
