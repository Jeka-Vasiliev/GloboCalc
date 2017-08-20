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

        public AllOperationsFactory()
        {
            var defaultFactories = new IOperationFactory[]
            {
                new AdditionFactory(),
                new SubtractionFactory(),
                new MultiplicationFactory(),
                new DivisionFactory(),
                new ExponentiationFactory(),
                new SinFunctionFactory(),
            };
            _operationFactories = defaultFactories.ToDictionary(f => f.TokenValue);
        }

        public AllOperationsFactory(IEnumerable<IOperationFactory> operationFactories)
        {
            _operationFactories = operationFactories.ToDictionary(f => f.TokenValue);
        }

        public IOperation CreateOperator(Token token)
        {
            return _operationFactories[token.Value].Create();
        }
    }
}
