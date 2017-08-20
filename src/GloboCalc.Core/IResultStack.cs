using System;
using System.Collections.Generic;
using System.Text;

namespace GloboCalc.Core
{
    public interface IResultStack
    {
        void Push(double value);
        double Pop();
    }
}
