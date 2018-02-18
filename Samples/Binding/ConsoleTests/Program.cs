using System;
using MvvmFx.Bindings.Input;

namespace ConsoleTests
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("ControlEvents");
            Console.WriteLine("=============");
            var controlEvents = ControlEvents.InputEvents;
            foreach (var @event in controlEvents)
            {
                Console.WriteLine(@event);
            }

            Console.WriteLine();
            Console.WriteLine("ToolStripItemEvents");
            Console.WriteLine("===================");
            var toolStripItemEvents = ToolStripItemEvents.InputEvents;
            foreach (var @event in toolStripItemEvents)
            {
                Console.WriteLine(@event);
            }

            Console.WriteLine();
            Console.WriteLine("MenuItemEvents");
            Console.WriteLine("==============");
            var menuItemEvents = MenuItemEvents.InputEvents;
            foreach (var @event in menuItemEvents)
            {
                Console.WriteLine(@event);
            }
        }
    }
}
