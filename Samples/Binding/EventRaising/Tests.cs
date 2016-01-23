using System;
using MvvmFx.Windows.Data;

namespace EventRaising
{
    public static class Tests
    {
        private static readonly BindingManager BindingManager = new BindingManager();
        private static readonly EntityINPC Source = new EntityINPC();
        private static readonly EntityXxxChanged Target = new EntityXxxChanged();

        public static void DoTests()
        {
            BuildBindings();

            Console.WriteLine("=== Start of tests ===" + Environment.NewLine);
            Console.ReadLine();

            Console.WriteLine("=== OneWayToTarget ===" + Environment.NewLine);
            Source.OneWayToTarget = "Source.OneWayToTarget";
            Console.ReadLine();

            Console.WriteLine("=== OneWayToSource ===" + Environment.NewLine);
            Source.OneWayToSource = 1;
            Console.ReadLine();

            Console.WriteLine("=== TwoWay ===" + Environment.NewLine);
            Source.TwoWay = "Source.TwoWay";
            Console.ReadLine();

            Console.WriteLine("=== OneWayToTarget ===" + Environment.NewLine);
            Target.OneWayToTarget = "Target.OneWayToTarget";
            Console.ReadLine();

            Console.WriteLine("=== OneWayToSource ===" + Environment.NewLine);
            Target.OneWayToSource = -1;
            Console.ReadLine();

            Console.WriteLine("=== TwoWay ===" + Environment.NewLine);
            Target.TwoWay = "Target.TwoWay";
        }

        public static void BuildBindings()
        {
            var bindingOneWayToTarget = new Binding
            {
                SourceObject = Source,
                SourcePath = "OneWayToTarget",
                TargetObject = Target,
                TargetPath = "OneWayToTarget",
                Mode = BindingMode.OneWayToTarget
            };
            BindingManager.Bindings.Add(bindingOneWayToTarget);

            var bindingOneWayToSource = new Binding
            {
                SourceObject = Source,
                SourcePath = "OneWayToSource",
                TargetObject = Target,
                TargetPath = "OneWayToSource",
                Mode = BindingMode.OneWayToSource
            };
            BindingManager.Bindings.Add(bindingOneWayToSource);

            var bindingTwoWay = new Binding
            {
                SourceObject = Source,
                SourcePath = "TwoWay",
                TargetObject = Target,
                TargetPath = "TwoWay",
                Mode = BindingMode.TwoWay
            };
            BindingManager.Bindings.Add(bindingTwoWay);
        }
    }
}