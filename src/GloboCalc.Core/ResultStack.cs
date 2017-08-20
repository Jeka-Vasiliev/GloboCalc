using GloboCalc.Core.Abstractions;
using System.Collections.Generic;

namespace GloboCalc.Core
{
    public class ResultStack: IResultStack
    {
        private readonly Stack<double> _stack;

        public ResultStack()
        {
            _stack = new Stack<double>();
        }


        public void Push(double value)
        {
            _stack.Push(value);
        }

        public double Pop()
        {
            return _stack.Pop();
        }

        public double Result()
        {
            if (_stack.Count == 0)
            {
                throw new ParseException("Result is empty", 0);
            }
            if (_stack.Count > 1)
            {
                _stack.Clear();
                throw new ParseException("Can't evaluate: incorrect input", 0);
            }

            return _stack.Pop();
        }
    }
}
