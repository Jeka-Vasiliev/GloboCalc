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
                    foreach(var expression in args)
                    {
                        try
                        {
                            var result = calc.CalculateExpression(expression);
                            Console.WriteLine(result);
                        }
                        catch (ParseException ex)
                        {
                            PrintError(expression, ex);
                        }
                    }
                }
                else
                {
                    // при вызове без параметров входим в режим диалога
                    CommandLoop(calc);
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
            });
        }

        static void CommandLoop(ICalc calc)
        {
            ShowTips();
            string expression = null;
            while (true)
            {
                expression = Console.ReadLine();
                if (string.IsNullOrEmpty(expression)) { return; }
                try
                {
                    var result = calc.CalculateExpression(expression);
                    Console.WriteLine(result);
                }
                catch (ParseException ex)
                {
                    PrintError(expression, ex);
                }
            }
        }

        static void ShowTips()
        {
            Console.WriteLine("Write math expression");
            Console.WriteLine("Supported operators: ( ) + - * / ^ sin");
            Console.WriteLine("For exit press ctrl+C or input empty string");
            Console.WriteLine("Example: 23 * 2 + 45 - 24 / 5");
        }

        static void PrintError(string expression, ParseException ex)
        {
            Console.Error.WriteLine("There is an error: {0}", ex.Message);
            Console.Error.WriteLine(expression);
            Console.Error.Write(new string(' ', ex.Position));
            Console.Error.WriteLine('^');
        }

    }
}
