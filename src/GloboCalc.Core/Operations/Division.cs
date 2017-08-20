﻿using GloboCalc.Core.Operations.Abstractions;

namespace GloboCalc.Core.Operations
{
    public class Division : BinaryOperation
    {
        protected override double Apply(double left, double right)
        {
            return left / right;
        }
    }
}