using System;
using System.Diagnostics;
using System.Globalization;
using MvvmFx.Bindings.Data;
using PerformanceTests.Business;

namespace PerformanceTests
{
    internal class MvvmFxTester
    {
        private readonly INumberName _subjectUnderTest;

        internal MvvmFxTester(INumberName subjectUnderTest)
        {
            _subjectUnderTest = subjectUnderTest;
            var guineaPig = new TargetObject();

            // bind
            using (var bindingManager = new BindingManager())
            {
                var numberBinding = new TypedBinding<INumberName, INumberName>
                    (guineaPig, t => t.Number, _subjectUnderTest, s => s.Number);
                var nameBinding = new TypedBinding<INumberName, INumberName>
                    (guineaPig, t => t.FullName, _subjectUnderTest, s => s.FullName);
                bindingManager.Bindings.Add(numberBinding);
                bindingManager.Bindings.Add(nameBinding);

                var testDuration = new Stopwatch();
                testDuration.Start();
                Run();
                testDuration.Stop();
                Console.WriteLine(
                    string.Format("Bind to source {0}: {1} msec.", subjectUnderTest.GetType().Name,
                                  testDuration.ElapsedMilliseconds.ToString("#,###")));

                // unbind
                bindingManager.Bindings.Remove(numberBinding);
                bindingManager.Bindings.Remove(nameBinding);

                //bind back
                numberBinding = new TypedBinding<INumberName, INumberName>
                    (_subjectUnderTest, t => t.Number, guineaPig, s => s.Number);
                nameBinding = new TypedBinding<INumberName, INumberName>
                    (_subjectUnderTest, t => t.FullName, guineaPig, s => s.FullName);
                bindingManager.Bindings.Add(numberBinding);
                bindingManager.Bindings.Add(nameBinding);

                testDuration.Restart();
                Run();
                testDuration.Stop();
                Console.WriteLine(
                    string.Format("Bind to target {0}: {1} msec.", guineaPig.GetType().Name,
                                  testDuration.ElapsedMilliseconds.ToString("#,###")));

                Console.WriteLine();
            }
        }

        private void Run()
        {
            for (var index = 0; index < Program.Iterations; index++)
            {
                _subjectUnderTest.Number = index + 1;
                _subjectUnderTest.FullName = "FullName " + (index + 1).ToString(CultureInfo.InvariantCulture);
            }
        }
    }
}

