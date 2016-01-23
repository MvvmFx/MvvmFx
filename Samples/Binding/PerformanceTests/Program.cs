using System;
using PerformanceTests.Business;

namespace PerformanceTests
{
    internal class Program
    {
        internal const int Iterations = 100000;

        [STAThread]
        internal static void Main()
        {
            Console.WriteLine("MvvmFx binding");
            Console.WriteLine("==============");
            Console.WriteLine();
            new MvvmFxTester(new INPC());
            new MvvmFxTester(new XxxChanged());
            new MvvmFxTester(new XxxChangedGenericArgs());
            new MvvmFxTester(new SystemDependencyObject());
            new MvvmFxTester(new MvvmFxDependencyObject());

            Console.WriteLine("WPF binding");
            Console.WriteLine("===========");
            new WpfTester();
        }
    }
}
