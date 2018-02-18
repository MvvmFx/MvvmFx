using System;
using System.Collections.Generic;
using MvvmFx.Bindings.Data;
using MvvmFx.Bindings.Specifications.Support;
using MvvmFx.Bindings.Specifications.Support.Entities;
using Moq;
using Xunit;
using Xunit.Extensions;

namespace MvvmFx.Bindings.Specifications
{
	public class When_a_single_source_binding_has_a_converter
	{
		[Theory]
		[PropertyData("TestData")]
		public void the_convert_source_to_target_method_is_called_when_the_source_is_changed(BindingManager bindingManager, SingleSourceBinding binding, Mock<IValueConverter> converter, IPerson targetObject, IPerson sourceObject)
		{
			converter.Setup(x => x.Convert("Value", typeof(string), "parameter", null));
			sourceObject.Address.Line1 = "Value";
			converter.VerifyAll();
		}

		[Theory]
		[PropertyData("TestData")]
		public void the_convert_target_to_source_method_is_called_when_the_target_is_changed(BindingManager bindingManager, SingleSourceBinding binding, Mock<IValueConverter> converter, IPerson targetObject, IPerson sourceObject)
		{
			converter.Setup(x => x.ConvertBack("Value", typeof(string), "parameter", null));
			targetObject.Address.Line2 = "Value";
			converter.VerifyAll();
		}

		[Theory]
		[PropertyData("TestData")]
		public void the_converted_value_is_used_when_the_source_is_changed(BindingManager bindingManager, SingleSourceBinding binding, Mock<IValueConverter> converter, IPerson targetObject, IPerson sourceObject)
		{
			converter.Setup(x => x.Convert("Value", typeof(string), "parameter", null)).Returns("Converted Value");
			sourceObject.Address.Line1 = "Value";
			Assert.Equal("Converted Value", targetObject.Address.Line2);
			converter.VerifyAll();
		}

		[Theory]
		[PropertyData("TestData")]
		public void the_converted_value_is_used_when_the_target_is_changed(BindingManager bindingManager, SingleSourceBinding binding, Mock<IValueConverter> converter, IPerson targetObject, IPerson sourceObject)
		{
			converter.Setup(x => x.ConvertBack("Value", typeof(string), "parameter", null)).Returns("Converted Value");
			targetObject.Address.Line2 = "Value";
			Assert.Equal("Converted Value", sourceObject.Address.Line1);
			converter.VerifyAll();
		}

		public static IEnumerable<Func<IPerson, IPerson, SingleSourceBinding>> GetBindingFactories()
		{
			yield return (targetObject, sourceObject) => new Binding(targetObject, "Address.Line2", sourceObject, "Address.Line1");

			yield return (targetObject, sourceObject) => new TypedBinding<IPerson, IPerson>(targetObject, x => x.Address.Line2, sourceObject, x => x.Address.Line1);
		}

		public static IEnumerable<object[]> TestData
		{
			get
			{
				foreach (var bindingFactory in GetBindingFactories())
				{
					foreach (var personFactory in TheoryHelper.PersonFactories)
					{
						var targetObject = personFactory();
						var sourceObject = personFactory();
						var binding = bindingFactory(targetObject, sourceObject);
						var bindingManager = new BindingManager();
						var converter = new Mock<IValueConverter>();
						binding.Converter = converter.Object;
						binding.ConverterParameter = "parameter";
						bindingManager.Bindings.Add(binding);
						yield return new object[] { bindingManager, binding, converter, targetObject, sourceObject };
					}
				}
			}
		}
	}
}