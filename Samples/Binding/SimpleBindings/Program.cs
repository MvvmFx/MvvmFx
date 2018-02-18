using System;
using System.Globalization;
using System.Linq;
using BusinessObjects;
using MvvmFx.Bindings.Data;

namespace SimpleBindings
{
    class Program
    {
        static void Main(string[] args)
        {
            var customer1 = new Customer();
            var customer2 = new Customer();
            var customer1OutputSink = new OutputSink();
            var customer2OutputSink = new OutputSink();

            using (var bindingManager = new BindingManager())
            {
                var useFluentInterface = false;

                if (!useFluentInterface)
                {
                    //add various bindings to the binding manager
                    AddSimpleBinding(customer1, customer2, bindingManager);
                    AddSimpleTypedBinding(customer1, customer2, bindingManager);
                    AddComplexBinding(customer1, customer2, bindingManager);
                    AddComplexTypedBinding(customer1, customer2, bindingManager);
                    AddSimpleMultiBinding(customer1, customer1OutputSink, bindingManager);
                    AddSimpleTypedMultiBinding(customer2, customer2OutputSink, bindingManager);
                }
                else
                {
                    //add various bindings to the binding manager using the fluent interface
                    AddSimpleBindingFluent(customer1, customer2, bindingManager);
                    AddSimpleTypedBindingFluent(customer1, customer2, bindingManager);
                    AddComplexBindingFluent(customer1, customer2, bindingManager);
                    AddComplexTypedBindingFluent(customer1, customer2, bindingManager);
                    AddSimpleMultiBindingFluent(customer1, customer1OutputSink, bindingManager);
                    AddSimpleTypedMultiBindingFluent(customer2, customer2OutputSink, bindingManager);
                }

                //make some property changes
                customer1.Name = "Kent";
                customer2.Gender = Gender.Male;
                customer2.Address.Line1 = "12 Somewhere Lodge";
                customer2.Address.Line2 = "Northwich";
            }

            //output the details of each Customer object
            OutputCustomer("Customer 1", customer1);
            OutputCustomer("Customer 2", customer2);

            //output the details of each output sink
            Console.WriteLine("Customer 1 Output Sink: {0}", customer1OutputSink.Output);
            Console.WriteLine("Customer 2 Output Sink: {0}", customer2OutputSink.Output);

            Console.WriteLine("Any key to exit");
            Console.ReadKey();
        }

        private static void OutputCustomer(string title, Customer customer)
        {
            Console.WriteLine(title);
            Console.WriteLine("   Name = '{0}'", customer.Name);
            Console.WriteLine("   Gender = {0}", customer.Gender);
            Console.WriteLine("   BirthDate = {0}", customer.BirthDate);
            Console.WriteLine("   Address = {0}", customer.Address.Line1);
            Console.WriteLine("             {0}", customer.Address.Line2);
            Console.WriteLine("             {0}", customer.Address.Line3);
            Console.WriteLine("             {0}", customer.Address.Line4);
            Console.WriteLine("             {0}", customer.Address.PostCode);
            Console.WriteLine();
        }

        private static void AddSimpleBinding(Customer customer1, Customer customer2, BindingManager bindingManager)
        {
            #region Simple Binding

            var binding = new Binding(customer1, "Name", customer2, "Name");
            bindingManager.Bindings.Add(binding);

            #endregion
        }

        private static void AddSimpleBindingFluent(Customer customer1, Customer customer2, BindingManager bindingManager)
        {
            #region Simple Fluent Binding

            bindingManager.Bind(customer1, "Name")
                .To(customer2, "Name")
                .Activate();

            #endregion
        }

        private static void AddSimpleTypedBinding(Customer customer1, Customer customer2, BindingManager bindingManager)
        {
            #region Simple TypedBinding

            var binding = new TypedBinding<Customer, Customer>(customer1, c => c.Gender, customer2, c => c.Gender);
            bindingManager.Bindings.Add(binding);

            #endregion
        }

        private static void AddSimpleTypedBindingFluent(Customer customer1, Customer customer2, BindingManager bindingManager)
        {
            #region Simple Fluent TypedBinding

            bindingManager.Bind(customer1, c => c.Gender)
                .To(customer2, c => c.Gender)
                .Activate();

            #endregion
        }

        private static void AddComplexBinding(Customer customer1, Customer customer2, BindingManager bindingManager)
        {
            #region Complex Binding

            var binding = new Binding(customer1, "Address.Line1", customer2, "Address.Line1");
            binding.Mode = BindingMode.OneWayToTarget;
            binding.Converter = new FormerAddressLineConverter();
            bindingManager.Bindings.Add(binding);

            #endregion
        }

        private static void AddComplexBindingFluent(Customer customer1, Customer customer2, BindingManager bindingManager)
        {
            #region Complex Fluent Binding

            bindingManager.Bind(customer1, "Address.Line1")
                .To(customer2, "Address.Line1")
                .OneWayToTarget()
                .WithConverter(new FormerAddressLineConverter())
                .Activate();

            #endregion
        }

        private static void AddComplexTypedBinding(Customer customer1, Customer customer2, BindingManager bindingManager)
        {
            #region Complex TypedBinding

            var binding = new TypedBinding<Customer, Customer>(customer1, c => c.Address.Line2, customer2, c => c.Address.Line2);
            binding.Mode = BindingMode.OneWayToTarget;
            binding.Converter = new FormerAddressLineConverter();
            bindingManager.Bindings.Add(binding);

            #endregion
        }

        private static void AddComplexTypedBindingFluent(Customer customer1, Customer customer2, BindingManager bindingManager)
        {
            #region Complex Fluent TypedBinding

            bindingManager.Bind(customer1, c => c.Address.Line2)
                .To(customer2, c => c.Address.Line2)
                .OneWayToTarget()
                .WithConverter(new FormerAddressLineConverter())
                .Activate();

            #endregion
        }

        private static void AddSimpleMultiBinding(Customer customer, OutputSink outputSink, BindingManager bindingManager)
        {
            #region Simple MultiBinding

            var binding = new MultiBinding(outputSink, "Output");
            binding.Sources.Add(new Binding(null, null, customer, "Name"));
            binding.Sources.Add(new Binding(null, null, customer, "Gender"));
            binding.Sources.Add(new Binding(null, null, customer, "BirthDate"));
            binding.Sources.Add(new Binding(null, null, customer, "Address.Line1"));
            binding.Sources.Add(new Binding(null, null, customer, "Address.Line2"));
            binding.Sources.Add(new Binding(null, null, customer, "Address.Line3"));
            binding.Sources.Add(new Binding(null, null, customer, "Address.Line4"));
            binding.Sources.Add(new Binding(null, null, customer, "Address.PostCode"));
            binding.Mode = BindingMode.OneWayToTarget;
            binding.Converter = new OutputConverter();

            bindingManager.Bindings.Add(binding);

            #endregion
        }

        private static void AddSimpleMultiBindingFluent(Customer customer, OutputSink outputSink, BindingManager bindingManager)
        {
            #region Simple Fluent MultiBinding

            bindingManager.MultiBind(outputSink, "Output")
                .WithConverter(new OutputConverter())
                .OneWayToTarget()
                .To(customer, "Name")
                .AndTo(customer, "Gender")
                .AndTo(customer, "BirthDate")
                .AndTo(customer, "Address.Line1")
                .AndTo(customer, "Address.Line2")
                .AndTo(customer, "Address.Line3")
                .AndTo(customer, "Address.Line4")
                .AndTo(customer, "Address.PostCode")
                .Activate();

            #endregion
        }

        private static void AddSimpleTypedMultiBinding(Customer customer, OutputSink outputSink, BindingManager bindingManager)
        {
            #region Simple TypedMultiBinding

            var binding = new TypedMultiBinding<OutputSink>(outputSink, o => o.Output);
            binding.Sources.Add(new TypedBinding<object, Customer>(null, null, customer, c => c.Name));
            binding.Sources.Add(new TypedBinding<object, Customer>(null, null, customer, c => c.Gender));
            binding.Sources.Add(new TypedBinding<object, Customer>(null, null, customer, c => c.BirthDate));
            binding.Sources.Add(new TypedBinding<object, Customer>(null, null, customer, c => c.Address.Line1));
            binding.Sources.Add(new TypedBinding<object, Customer>(null, null, customer, c => c.Address.Line2));
            binding.Sources.Add(new TypedBinding<object, Customer>(null, null, customer, c => c.Address.Line3));
            binding.Sources.Add(new TypedBinding<object, Customer>(null, null, customer, c => c.Address.Line4));
            binding.Sources.Add(new TypedBinding<object, Customer>(null, null, customer, c => c.Address.PostCode));
            binding.Mode = BindingMode.OneWayToTarget;
            binding.Converter = new OutputConverter();

            bindingManager.Bindings.Add(binding);

            #endregion
        }

        private static void AddSimpleTypedMultiBindingFluent(Customer customer, OutputSink outputSink, BindingManager bindingManager)
        {
            #region Simple Fluent TypedMultiBinding

            bindingManager.MultiBind(outputSink, o => o.Output)
                .WithConverter(new OutputConverter())
                .OneWayToTarget()
                .To(customer, c => c.Name)
                .AndTo(customer, c => c.Gender)
                .AndTo(customer, c => c.BirthDate)
                .AndTo(customer, c => c.Address.Line1)
                .AndTo(customer, c => c.Address.Line2)
                .AndTo(customer, c => c.Address.Line3)
                .AndTo(customer, c => c.Address.Line4)
                .AndTo(customer, c => c.Address.PostCode)
                .Activate();

            #endregion
        }

        private class FormerAddressLineConverter : IValueConverter
        {
            public object Convert(object value, Type type, object parameter, CultureInfo culture)
            {
                var valueStr = value as string;

                if (valueStr == null)
                {
                    return null;
                }

                return "FORMERLY AT: " + valueStr;
            }

            public object ConvertBack(object value, Type type, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }

        private class OutputConverter : IMultiValueConverter
        {
            public object Convert(object[] values, Type type, object parameter, CultureInfo culture)
            {
                return string.Join(Environment.NewLine, values.Select(x => x == null ? "" : x.ToString()).ToArray());
            }

            public object[] ConvertBack(object value, Type[] types, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }

        private class OutputSink
        {
            public string Output { get; set; }
        }
    }
}