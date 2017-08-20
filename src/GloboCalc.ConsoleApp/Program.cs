using GloboCalc.ConsoleApp.CustomOperation;
using GloboCalc.Core;
using GloboCalc.Core.Abstractions;
using GloboCalc.Core.Operations.Factories;
using GloboCalc.Core.Tokenization;
using SimpleInjector;
using System;
using System.Linq;

namespace GloboCalc.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var container = new Container())
            {
                CompositionRoot(container);

                var calc = container.GetInstance<ICalc>();

                if (args.Any())
                {
                    // для списка атрибутов просто вычисляем каждый как выражение и выходим
                    var results = string.Join(' ', args.Select(calc.CalculateExpression));
                    Console.WriteLine(results);
                }
                else
                {
                    // при вызове без параметров входим в режим чтения консоли
                    ShowTips();
                }
            }
        }

        static void CompositionRoot(Container container)
        {
            container.Register<ICalc, Calc>();
            container.Register<ITokenizer, Tokenizer>();
            container.Register<IInfixToPostfixNotationConverter, InfixToPostfixNotationConverter>();
            container.Register<IPostfixNotationCalculator, PostfixNotationCalculator>();
            container.Register<IAllOperationsFactory, AllOperationsFactory>();
            container.RegisterCollection(new IOperationFactory[]
            {
                new AdditionFactory(),
                new SubtractionFactory(),
                new DivisionFactory(),
                new MultiplicationFactory(),
                new ExponentiationFactory(),
                new SinFunctionFactory(),
                new Log10OperationFactory(),
            });
        }

        static void ShowTips()
        {
            Console.WriteLine("Usage: GloboCalc.exe \"<math expression>\"");
            Console.WriteLine("Example: GloboCalc.exe \"23 * 2 + 45 - 24 / 5\"");
        }
    }
}
