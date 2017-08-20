using GloboCalc.Core.Abstractions;
using GloboCalc.Core.Operations.Abstractions;
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
            CheckFactoryExists(token);
            return _operationFactories[token.Value].Create(token.Position);
        }

        public Associativity GetAssociativity(Token token)
        {
            CheckFactoryExists(token);
            return _operationFactories[token.Value].Associativity;
        }

        public int GetPresendence(Token token)
        {
            CheckFactoryExists(token);
            return _operationFactories[token.Value].Presendence;
        }

        private void CheckFactoryExists(Token token)
        {
            var hasKey = _operationFactories.ContainsKey(token.Value);
            if (!hasKey) { throw new ParseException("Unknown operator", token.Position); }
        }
    }
}
