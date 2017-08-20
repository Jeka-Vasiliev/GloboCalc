using System;
using System.Collections.Generic;
using System.Text;

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
                throw new Exception("Result stack is empty");
            }
            if (_stack.Count > 1)
            {
                throw new Exception("Can't evaluate: incorrect input");
            }

            return _stack.Pop();
        }
    }
}
