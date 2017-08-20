using GloboCalc.Core.Operations.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace GloboCalc.Core.Abstractions
{
    public interface IOperationFactory
    {
        string TokenValue { get; }

        Associativity Associativity { get; }

        int Presendence { get; }

        IOperation Create();
    }
}
