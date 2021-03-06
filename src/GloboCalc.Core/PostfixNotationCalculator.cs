﻿using System.Collections.Generic;
using GloboCalc.Core.Operations.Abstractions;
using GloboCalc.Core.Abstractions;

namespace GloboCalc.Core
{
    public class PostfixNotationCalculator : IPostfixNotationCalculator
    {
        private readonly ResultStack _resultStack = new ResultStack();

        public double Execute(IEnumerable<IOperation> operations)
        {
            foreach (var operation in operations)
            {
                operation.Execute(_resultStack);
            }
            return _resultStack.Result();
        }
    }
}