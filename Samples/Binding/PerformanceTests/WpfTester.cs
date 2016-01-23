using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Data;
using PerformanceTests.Business;

namespace PerformanceTests
{
    internal class WpfTester
    {
        private readonly TestWpf _subjectUnderTest;
        private readonly TestWpf _anotherSubjectUnderTest;
        private readonly INPC _guineaPig;

        internal WpfTester()
        {
            _subjectUnderTest = new TestWpf();
            _anotherSubjectUnderTest = new TestWpf();
            SymmetricObjects();
            _subjectUnderTest = new TestWpf();
            _guineaPig = new INPC();
            AsymmetricObjects();
        }

        private void SymmetricObjects()
        {
            Console.WriteLine("Symmetric");
            Console.WriteLine("---------");

            // bind
            var numberBinding = new Binding("Number") {Source = _anotherSubjectUnderTest, Mode = BindingMode.TwoWay};
            var nameBinding = new Binding("FullName") {Source = _anotherSubjectUnderTest, Mode = BindingMode.TwoWay};
            _subjectUnderTest.Number.SetBinding(System.Windows.Controls.TextBox.TextProperty, numberBinding);
            _subjectUnderTest.FullName.SetBinding(System.Windows.Controls.TextBox.TextProperty, nameBinding);

            var testDuration = new Stopwatch();
            testDuration.Start();
            Run(_subjectUnderTest);
            testDuration.Stop();
            Console.WriteLine(
                string.Format("Write to {0}: {1} msec.", _subjectUnderTest.GetType().Name, testDuration.ElapsedMilliseconds.ToString("#,###")));

            testDuration.Restart();
            Run(_anotherSubjectUnderTest);
            testDuration.Stop();
            Console.WriteLine(
                string.Format("Write to {0}: {1} msec.", _anotherSubjectUnderTest.GetType().Name, testDuration.ElapsedMilliseconds.ToString("#,###")));

            Console.WriteLine();
        }

        private void AsymmetricObjects()
        {
            Console.WriteLine("Asymmetric");
            Console.WriteLine("----------");

            // bind
            var numberBinding = new Binding("Number") {Source = _guineaPig};
            var nameBinding = new Binding("FullName") {Source = _guineaPig};
            _subjectUnderTest.Number.SetBinding(System.Windows.Controls.TextBox.TextProperty, numberBinding);
            _subjectUnderTest.FullName.SetBinding(System.Windows.Controls.TextBox.TextProperty, nameBinding);

            var testDuration = new Stopwatch();
            testDuration.Start();
            RunAsymmetric();
            testDuration.Stop();
            Console.WriteLine(
                string.Format("Write to {0}: {1} msec.", _subjectUnderTest.GetType().Name, testDuration.ElapsedMilliseconds.ToString("#,###")));

            testDuration.Restart();
            RunReverseAsymmetric();
            testDuration.Stop();
            Console.WriteLine(
                string.Format("Write to {0}: {1} msec.", _guineaPig.GetType().Name, testDuration.ElapsedMilliseconds.ToString("#,###")));

            Console.WriteLine();
        }

        private void Run(TestWpf sut)
        {
            for (var index = 0; index < Program.Iterations; index++)
            {
                var temp = (index + 1).ToString(CultureInfo.InvariantCulture);
                sut.Number.Text = temp;
                sut.FullName.Text = "FullName " + temp;
            }
        }

        private void RunAsymmetric()
        {
            for (var index = 0; index < Program.Iterations; index++)
            {
                var temp = (index + 1).ToString(CultureInfo.InvariantCulture);
                _subjectUnderTest.Number.Text = temp;
                _subjectUnderTest.FullName.Text = "FullName " + temp;
            }
        }

        private void RunReverseAsymmetric()
        {
            for (var index = 0; index < Program.Iterations; index++)
            {
                var temp = index + 1;
                _guineaPig.Number = temp;
                _guineaPig.FullName = "FullName " + temp.ToString(CultureInfo.InvariantCulture);
            }
        }
    }
}
