using System;
using DpTests.Entities.MvvmFxDOs;
using MvvmFx.ComponentModel;
using MvvmFx.Windows;
using MvvmFx.Windows.Data;

// http://tomsundev.wordpress.com/category/articles/simplified-declaration-of-dependency-properties/

// ReSharper disable InconsistentNaming
// ReSharper disable LocalizableElement
// ReSharper disable SpecifyACultureInStringConversionExplicitly
// ReSharper disable CheckNamespace
namespace DpTests.WindowsForms
{
    internal class TestBindingDependencyObject
    {
        internal static void Tests()
        {
            var person = new Person();
            Console.WriteLine("Name: " + person.Name + "...");
            Console.WriteLine("Age: " + person.Age);
            Console.WriteLine("Gender: " + person.Gender);
            var person1 = new Person { Name = "John", Age = 1 };
            var person2 = new Person { Name = "Jack", Age = 2 };

            var manager1 = new BindingManager();
            var binding1 = new TypedBinding<Person, Person>();
            binding1.SourceObject = person1;
            binding1.SourceExpression = s => s.Age;
            binding1.TargetObject = person2;
            binding1.TargetExpression = t => t.Age;
            manager1.Bindings.Add(binding1);

            person1.Age = 69;
            Console.WriteLine("Person1: " + person1.Age);
            Console.WriteLine("Person2: " + person2.Age + " (Expect 69)");

            person2.Age = 18;
            Console.WriteLine("Person2: " + person2.Age);
            Console.WriteLine("Person1: " + person1.Age + " (Expect 18)");

            var manager2 = new BindingManager();
            manager2.Bindings.Add(new TypedBinding<Person, Person>(person2, t => t.Name, person1, s => s.Name));

            person1.Name = "Mary";
            Console.WriteLine("Person1: " + person1.Name);
            Console.WriteLine("Person2: " + person2.Name + " (Expect Mary)");

            person2.Name = "Lucene";
            Console.WriteLine("Person2: " + person2.Name);
            Console.WriteLine("Person1: " + person1.Name + " (Expect Lucene)");

            person1.Name = null;
            Console.WriteLine("Person1: " + (person1.Name == null ? "null" : person1.Name));
            Console.WriteLine("Person2: " + (person2.Name == null ? "null" : person2.Name));

            person2.Name = null;
            Console.WriteLine("Person2: " + (person2.Name == null ? "null" : person2.Name));
            Console.WriteLine("Person1: " + (person1.Name == null ? "null" : person1.Name));
        }
    }

    public static class DpTests
    {
        public static void Test()
        {
            var test_D1 = new DpTestOne();
            test_D1.Test_1_D1();
            var test_D2 = new DpTestTwo();
            test_D2.Test_2_D2();
            test_D2.Test_2_D3();
            test_D2.Test_2_D4();
            test_D2.Test_2_D5();
            test_D1.Test_1_D6();
            test_D1.Test_1_D7();

            var test_A1 = new AttachedTestOne();
            test_A1.Test_A1();
            var test_A2 = new AttachedTestTwo();
            test_A2.Test_A2();
            test_A2.Test_A3();
            test_A1.Prepare_A1();
            test_A2.Test_A4();
            test_A2.Test_A5();
            test_A1.Test_A6();

            var test_dpd = new DependencyPropertyDescriptorTestOne();
            test_dpd.Test_DPD1();
        }
    }

    public class DpTestOne : DependencyObject
    {
        public static readonly DependencyProperty MyDependentProperty = DependencyProperty.Register("MyDependent", typeof(string), typeof(DpTestOne));
        //public static readonly DependencyProperty MyDependentProperty2 = DependencyProperty.Register("MyDependent", typeof (int), typeof (DpTestOne));
        //public static readonly DependencyProperty MyDependentProperty2 = DependencyProperty.Register("MyDependent", typeof(int), typeof(DpTestTwo));

        public string MyDependent
        {
            get { return GetValue(MyDependentProperty) as string; }
            set { SetValue(MyDependentProperty, value); }
        }

        public void Test_1_D1()
        {
            MyDependent = "Original value.";
            var result = MyDependent == "Original value.";
            Console.WriteLine("Test1 D1: " + result.ToString());
        }

        public void Test_1_D6()
        {
            var result = MyDependent == "Changed value.";
            Console.WriteLine("Test1 D6: " + result.ToString() + " (fails to read back value set on Test2 D3)");
        }

        public void Test_1_D7()
        {
            var test_5 = new TestFive();
            test_5.Test_AD1();
            test_5.Test_AD2();
        }
    }

    public class DpTestTwo : DependencyObject
    {
        public static readonly DependencyProperty MyDependentProperty = DpTestOne.MyDependentProperty.AddOwner(typeof(DpTestTwo));

        public string MyDependent
        {
            get { return GetValue(MyDependentProperty) as string; }
            set { SetValue(MyDependentProperty, value); }
        }

        public string MyDependentAwkward
        {
            get { return GetValue(DpTestOne.MyDependentProperty) as string; }
            set { SetValue(DpTestOne.MyDependentProperty, value); }
        }

        public void Test_2_D2()
        {
            var result = MyDependent == "Original value.";
            Console.WriteLine("Test2 D2: " + result.ToString() + " (fails to read back value set on Test1 D1)");
        }

        public void Test_2_D3()
        {
            MyDependent = "Changed value.";
            var result = MyDependent == "Changed value.";
            Console.WriteLine("Test2 D3: " + result.ToString());
        }

        public void Test_2_D4()
        {
            var result = MyDependent == "Original value.";
            Console.WriteLine("Test2 D4: " + result.ToString() + " (fails)");
        }

        public void Test_2_D5()
        {
            MyDependent = "Changed value.";
            var result = MyDependent == "Changed value.";
            Console.WriteLine("Test2 D5: " + result.ToString());
        }
    }

    public class TestFive : DpTestOne
    {
        public new string MyDependent
        {
            get { return GetValue(MyDependentProperty) as string; }
            set { SetValue(MyDependentProperty, value); }
        }

        public void Test_AD1()
        {
            var result = MyDependent == "Original value.";
            Console.WriteLine("Test AD1: " + result.ToString() + " (fails)");
        }

        public void Test_AD2()
        {
            var result = MyDependent == "Changed value.";
            Console.WriteLine("Test AD2: " + result.ToString() + " (fails)");
        }
    }

    public class AttachedTestOne : DependencyObject
    {
        public static readonly DependencyProperty MyDependentProperty = DependencyProperty.Register("MyDependent", typeof(string), typeof(AttachedTestOne));

        public static readonly DependencyProperty MyAttachedProperty = DependencyProperty.RegisterAttached("MyAttached", typeof(string), typeof(DpTestOne));

        public string MyAttached
        {
            get { return GetValue(MyAttachedProperty) as string; }
            set { SetValue(MyAttachedProperty, value); }
        }

        public void Test_A1()
        {
            MyAttached = "Original value.";
            var result = MyAttached == "Original value.";
            Console.WriteLine("Test A1: " + result.ToString());
        }

        public void Prepare_A1()
        {
            MyAttachedProperty.AddOwner(typeof(DpTestTwo));
        }

        public void Test_A6()
        {
            var result = MyAttached == "Changed value.";
            Console.WriteLine("Test A6: " + result.ToString() + " (fails)");
        }
    }

    public class AttachedTestTwo : DependencyObject
    {
        public string MyAttached
        {
            get { return GetValue(AttachedTestOne.MyAttachedProperty) as string; }
            set { SetValue(AttachedTestOne.MyAttachedProperty, value); }
        }

        public void Test_A2()
        {
            var result = MyAttached == "Original value.";
            Console.WriteLine("Test A2: " + result.ToString() + " (fails)");
        }

        public void Test_A3()
        {
            MyAttached = "Changed value.";
            var result = MyAttached == "Changed value.";
            Console.WriteLine("Test A3: " + result.ToString());
        }

        public void Test_A4()
        {
            var result = MyAttached == "Original value.";
            Console.WriteLine("Test A4: " + result.ToString() + " (fails)");
        }

        public void Test_A5()
        {
            MyAttached = "Changed value.";
            var result = MyAttached == "Changed value.";
            Console.WriteLine("Test A5: " + result.ToString());
        }
    }

    public class DependencyPropertyDescriptorTestOne
    {
        public void Test_DPD1()
        {
            var dpd11 = DependencyPropertyDescriptor.FromName("MyDependent", typeof(DpTestOne), typeof(DpTestOne));
            Console.WriteLine(string.Format("MyDependent same   {0} - {1} - {2} - {3}",
                dpd11 != null,
                dpd11.SupportsChangeEvents,
                dpd11.PropertyType,
                dpd11.ComponentType));
            var dpd12 = DependencyPropertyDescriptor.FromName("MyDependent", typeof(DpTestOne), typeof(DpTestTwo));
            Console.WriteLine(string.Format("MyDependent diff   {0} - {1} - {2} - {3}",
                dpd12 != null,
                dpd12.SupportsChangeEvents,
                dpd12.PropertyType,
                dpd12.ComponentType));
            Console.WriteLine(string.Format("HashCode are equal {0}", dpd11.GetHashCode() == dpd12.GetHashCode()) + " (fails)");
            var dpdNull = DependencyPropertyDescriptor.FromName("MyIndependent", typeof(DpTestOne), typeof(DpTestOne));
            Console.WriteLine(string.Format("MyIndependent      {0}", dpdNull != null) + " (fails)");
        }
    }
}
// ReSharper restore CheckNamespace
// ReSharper restore SpecifyACultureInStringConversionExplicitly
// ReSharper restore LocalizableElement
// ReSharper restore InconsistentNaming
