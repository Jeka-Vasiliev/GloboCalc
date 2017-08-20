using GloboCalc.Core.Operations.Abstractions;
using GloboCalc.Core.Tokenization;

namespace GloboCalc.Core.Abstractions
{
    public interface IAllOperationsFactory
    {
        IOperation CreateOperator(Token token);
    }
}