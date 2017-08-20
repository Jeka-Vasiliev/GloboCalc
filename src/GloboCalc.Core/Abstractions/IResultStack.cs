using System;
using System.Collections.Generic;
using System.Text;

namespace GloboCalc.Core.Abstractions
{
    public interface IResultStack
    {
        void Push(double value);
        double Pop();
    }
}
