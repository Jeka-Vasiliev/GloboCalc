using System;
using System.Collections.Generic;
using System.Text;

namespace GloboCalc.Core
{
    public class ParseException: Exception
    {
        public int Position { get; }

        public ParseException(int position): base()
        {
            Position = position;
        }
    }
}
