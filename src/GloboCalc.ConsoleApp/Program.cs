using GloboCalc.Core;
using System;
using System.Linq;

namespace GloboCalc.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Any())
            {
                var calc = new Calc();
                var results = string.Join(' ', args.Select(calc.CalculateExpression));
                Console.WriteLine(results);
            }
            else
            {
                ShowTips();
            }
        }

        static void ShowTips()
        {
            Console.WriteLine("Usage: GloboCalc.exe \"<math expression>\"");
            Console.WriteLine("Example: GloboCalc.exe \"23 * 2 + 45 - 24 / 5\"");
        }
    }
}
