using System;

namespace DpTests
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("WPF");
            Wpf.DpTests.Test();
            Wpf.TestBindingDependencyObject.Tests();
            Console.WriteLine();
            Console.WriteLine("WindowsForms");
            WindowsForms.DpTests.Test();
            WindowsForms.TestBindingDependencyObject.Tests();
            Console.WriteLine();
        }
    }
}
