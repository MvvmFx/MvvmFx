using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MvvmFx.Bindings.Data;
using MvvmFx.Bindings.Specifications.Support;
using MvvmFx.Bindings.Specifications.Support.Converters;
using MvvmFx.Bindings.Specifications.Support.Entities;
using Xunit;
using Xunit.Extensions;

namespace MvvmFx.Bindings.Specifications
{
    public class When_a_multi_source_binding_contains_another_multi_source_binding
    {
        [Theory]
        [PropertyData("TestData")]
        public void changes_to_the_target_are_reflected_in_the_sources(BindingManager bindingManager, IPerson targetObject, IAddress sourceObject)
        {
            targetObject.Details = "Kent~0~~,,";
            Assert.Equal("Kent", targetObject.Name);
            targetObject.Details = "Kent~0~~Line 1,,";
            Assert.Equal("Line 1", sourceObject.Line1);
            targetObject.Details = "Kent~0~~Line 1,Line 2,";
            Assert.Equal("Line 2", sourceObject.Line2);
            targetObject.Details = "Kent~0~~Line 1,Line 2,Line 3";
            Assert.Equal("Line 3", sourceObject.Line3);
            targetObject.Details = "Kent~29~~Line 1,Line 2,Line 3";
            Assert.Equal(29, targetObject.Age);
            targetObject.Details = "Kent~29~Male~Line 1,Line 2,Line 3";
            Assert.Same(Gender.Male, targetObject.Gender);
        }

        [Theory]
        [PropertyData("TestData")]
        public void changes_to_the_sources_are_reflected_in_the_target(BindingManager bindingManager, IPerson targetObject, IAddress sourceObject)
        {
            sourceObject.Line1 = "Line 1";
            Assert.Equal("~0~~Line 1,,", targetObject.Details);
            sourceObject.Line2 = "Line 2";
            Assert.Equal("~0~~Line 1,Line 2,", targetObject.Details);
            sourceObject.Line3 = "Line 3";
            Assert.Equal("~0~~Line 1,Line 2,Line 3", targetObject.Details);
            targetObject.Name = "Kent";
            Assert.Equal("Kent~0~~Line 1,Line 2,Line 3", targetObject.Details);
            targetObject.Age = 21;
            Assert.Equal("Kent~21~~Line 1,Line 2,Line 3", targetObject.Details);
            targetObject.Gender = Gender.Male;
            Assert.Equal("Kent~21~Male~Line 1,Line 2,Line 3", targetObject.Details);
        }

        public static IEnumerable<Func<IPerson, IAddress, BindingBase>> GetBindingFactories()
        {
            yield return delegate(IPerson targetObject, IAddress sourceObject)
            {
                //the second-level binding is bound to Line1, Line2, and Line3 of the Address object, all of which are separated by commas
                var secondLevelBinding = new MultiBinding();
                secondLevelBinding.Sources.Add(new Binding() { SourceObject = sourceObject, SourcePath = "Line1" });
                secondLevelBinding.Sources.Add(new Binding() { SourceObject = sourceObject, SourcePath = "Line2" });
                secondLevelBinding.Sources.Add(new Binding() { SourceObject = sourceObject, SourcePath = "Line3" });
                secondLevelBinding.Converter = new SeparatorConverter(",");

                //Person.Details is bound to their Name, Age, Gender, and the full address as determined by the second level binding, all
                //of which are separated by tildes
                var firstLevelBinding = new MultiBinding(targetObject, "Details");
                firstLevelBinding.Sources.Add(new Binding() { SourceObject = targetObject, SourcePath = "Name" });
                firstLevelBinding.Sources.Add(new Binding() { SourceObject = targetObject, SourcePath = "Age" });
                firstLevelBinding.Sources.Add(new Binding() { SourceObject = targetObject, SourcePath = "Gender", Converter = new GenderConverter() });
                firstLevelBinding.Sources.Add(secondLevelBinding);
                firstLevelBinding.Converter = new SeparatorConverter("~");

                return firstLevelBinding;
            };

            yield return delegate(IPerson targetObject, IAddress sourceObject)
            {
                //the second-level binding is bound to Line1, Line2, and Line3 of the Address object, all of which are separated by commas
                var secondLevelBinding = new TypedMultiBinding<object>();
                secondLevelBinding.Sources.Add(new TypedBinding<object, IAddress>() { SourceObject = sourceObject, SourceExpression = x => x.Line1 });
                secondLevelBinding.Sources.Add(new TypedBinding<object, IAddress>() { SourceObject = sourceObject, SourceExpression = x => x.Line2 });
                secondLevelBinding.Sources.Add(new TypedBinding<object, IAddress>() { SourceObject = sourceObject, SourceExpression = x => x.Line3 });
                secondLevelBinding.Converter = new SeparatorConverter(",");

                //Person.Details is bound to their Name, Age, Gender, and the full address as determined by the second level binding, all
                //of which are separated by tildes
                var firstLevelBinding = new TypedMultiBinding<IPerson>(targetObject, x => x.Details);
                firstLevelBinding.Sources.Add(new TypedBinding<object, IPerson>() { SourceObject = targetObject, SourceExpression = x => x.Name });
                firstLevelBinding.Sources.Add(new TypedBinding<object, IPerson>() { SourceObject = targetObject, SourceExpression = x => x.Age });
                firstLevelBinding.Sources.Add(new TypedBinding<object, IPerson>() { SourceObject = targetObject, SourceExpression = x => x.Gender, Converter = new GenderConverter() });
                firstLevelBinding.Sources.Add(secondLevelBinding);
                firstLevelBinding.Converter = new SeparatorConverter("~");

                return firstLevelBinding;
            };
        }

        public static IEnumerable<object[]> TestData
        {
            get
            {
                foreach (var bindingFactory in GetBindingFactories())
                {
                    foreach (var personFactory in TheoryHelper.PersonFactories)
                    {
                        foreach (var addressFactory in TheoryHelper.AddressFactories)
                        {
                            var person = personFactory();
                            var address = addressFactory();
                            var binding = bindingFactory(person, address);
                            binding.Mode = BindingMode.TwoWay;
                            var bindingManager = new BindingManager();
                            bindingManager.Bindings.Add(binding);
                            yield return new object[] { bindingManager, person, address };
                        }
                    }
                }
            }
        }

        private class SeparatorConverter : IMultiValueConverter
        {
            private readonly string _separator;

            public SeparatorConverter(string separator)
            {
                _separator = separator;
            }

            public object Convert(object[] values, Type type, object parameter, CultureInfo culture)
            {
                return string.Join(_separator, values.Select(x => x == null ? "" : x.ToString()).ToArray());
            }

            public object[] ConvertBack(object value, Type[] types, object parameter, CultureInfo culture)
            {
                var valueStr = value as string;

                if (valueStr == null)
                {
                    return new object[types.Length];
                }

                return valueStr.Split(new string[] { _separator }, StringSplitOptions.None);
            }
        }
    }
}