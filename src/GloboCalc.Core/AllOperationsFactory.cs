using GloboCalc.Core.Abstractions;
using GloboCalc.Core.Operations.Abstractions;
using GloboCalc.Core.Operations.Factories;
using GloboCalc.Core.Tokenization;
using System.Collections.Generic;
using System.Linq;

namespace GloboCalc.Core
{
    public class AllOperationsFactory : IAllOperationsFactory
    {
        private Dictionary<string, IOperationFactory> _operationFactories;

        public AllOperationsFactory(IEnumerable<IOperationFactory> operationFactories)
        {
            _operationFactories = operationFactories.ToDictionary(f => f.TokenValue);
        }

        public IOperation CreateOperator(Token token)
        {
            return _operationFactories[token.Value].Create();
        }

        public Associativity GetAssociativity(Token token)
        {
            return _operationFactories[token.Value].Associativity;
        }

        public int GetPresendence(Token token)
        {
            return _operationFactories[token.Value].Presendence;
        }

    }
}
