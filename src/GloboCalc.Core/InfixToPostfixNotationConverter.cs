﻿using GloboCalc.Core.Abstractions;
using GloboCalc.Core.Operations;
using GloboCalc.Core.Operations.Abstractions;
using GloboCalc.Core.Tokenization;
using System.Collections.Generic;

namespace GloboCalc.Core
{
    public class InfixToPostfixNotationConverter : IInfixToPostfixNotationConverter
    {
        private readonly IAllOperationsFactory _operationFactories;
        private readonly TokenComparer _tokenComparer;

        public InfixToPostfixNotationConverter(IAllOperationsFactory operationFactories)
        {
            _operationFactories = operationFactories;
            _tokenComparer = new TokenComparer(operationFactories);
        }

        /// <summary>
        /// Реализация алгоритма Shunting-yard
        /// </summary>
        public List<IOperation> Convert(List<Token> tokens)
        {
            var outputQueue = new List<IOperation>();
            var operatorStack = new Stack<Token>();

            foreach (var token in tokens)
            {
                switch (token.TokenCategory)
                {
                    case TokenCategory.Number:
                        if (double.TryParse(token.Value, out var parsed))
                        {
                            outputQueue.Add(new Constant(parsed));
                        }
                        else
                        {
                            throw new ParseException("Invalid number format", token.Position);
                        }
                        break;
                    case TokenCategory.Operator:
                        while (operatorStack.Count > 0 && _tokenComparer.IsPrecedencer(operatorStack.Peek(), token))
                        {
                            var operation = _operationFactories.CreateOperator(operatorStack.Pop());
                            outputQueue.Add(operation);
                        }
                        operatorStack.Push(token);
                        break;
                    case TokenCategory.LeftBracket:
                        operatorStack.Push(token);
                        break;
                    case TokenCategory.RightBracket:
                        while (true)
                        {
                            if (operatorStack.Count == 0)
                            {
                                throw new ParseException("Mismatched parentheses", token.Position);
                            }
                            var tokenFromStack = operatorStack.Pop();
                            if (tokenFromStack.TokenCategory == TokenCategory.LeftBracket)
                            {
                                break;
                            }
                            var operation = _operationFactories.CreateOperator(tokenFromStack);
                            outputQueue.Add(operation);
                        }
                        break;
                }
            }

            while (operatorStack.Count > 0)
            {
                var tokenFromStack = operatorStack.Pop();
                if (tokenFromStack.TokenCategory == TokenCategory.LeftBracket ||
                    tokenFromStack.TokenCategory == TokenCategory.RightBracket)
                {
                    throw new ParseException("Mismatched parentheses", tokenFromStack.Position);
                }
                var operation = _operationFactories.CreateOperator(tokenFromStack);
                outputQueue.Add(operation);
            }


            return outputQueue;
        }
    }
}