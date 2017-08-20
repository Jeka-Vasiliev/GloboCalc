using System.Collections.Generic;
using GloboCalc.Core.Operations.Abstractions;

namespace GloboCalc.Core.Abstractions
{
    public interface IPostfixNotationCalculator
    {
        double Execute(IEnumerable<IOperation> operations);
    }
}