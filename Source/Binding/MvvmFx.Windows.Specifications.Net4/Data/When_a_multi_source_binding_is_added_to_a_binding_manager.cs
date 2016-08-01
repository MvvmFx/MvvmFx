using System;
using System.Collections.Generic;
using MvvmFx.Windows.Data;
using MvvmFx.Windows.Specifications.Support;
using MvvmFx.Windows.Specifications.Support.Converters;
using MvvmFx.Windows.Specifications.Support.Entities;
using Moq;
using Xunit;
using Xunit.Extensions;

namespace MvvmFx.Windows.Specifications
{
	public abstract class When_a_multi_source_binding_is_added_to_a_binding_manager
	{
		[Theory]
		[PropertyData("TestData")]
		public void it_must_have_a_converter(BindingManager bindingManager, MultiSourceBinding binding, IPerson targetObject, IAddress sourceObject)
		{
			bindingManager.Bindings.Remove(binding);
			binding.Converter = null;
			var ex = Assert.Throws<InvalidOperationException>(() => bindingManager.Bindings.Add(binding));
			Assert.Equal("All MultiSourceBindings require a converter.", ex.Message);
		}

		[Theory]
		[PropertyData("TestData")]
		public void it_is_present_in_the_bindings_collection(BindingManager bindingManager, MultiSourceBinding binding, IPerson targetObject, IAddress sourceObject)
		{
			Assert.Contains(binding, bindingManager.Bindings);
		}

		[Theory]
		[PropertyData("TestData")]
		public void it_becomes_active(BindingManager bindingManager, MultiSourceBinding binding, IPerson targetObject, IAddress sourceObject)
		{
			sourceObject.Line1 = "Line 1, mighty fine";
			Assert.Equal("Line 1, mighty fine~", targetObject.Name);

			targetObject.Name = "Foo~Bar";
			Assert.Equal("Foo", sourceObject.Line1);
			Assert.Equal("Bar", sourceObject.Line2);
		}

		[Theory]
		[PropertyData("TestData")]
		public void it_cannot_be_added_again(BindingManager bindingManager, MultiSourceBinding binding, IPerson targetObject, IAddress sourceObject)
		{
			var ex = Assert.Throws<InvalidOperationException>(() => bindingManager.Bindings.Add(binding));
			Assert.Equal("This binding is already activated.", ex.Message);
		}

		[Theory]
		[PropertyData("TestData")]
		public void the_target_object_cannot_be_modified(BindingManager bindingManager, MultiSourceBinding binding, IPerson targetObject, IAddress sourceObject)
		{
			var ex = Assert.Throws<InvalidOperationException>(() => binding.TargetObject = null);
			Assert.Equal("BindingBase is currently activated and cannot be modified.", ex.Message);
		}

		[Theory]
		[PropertyData("TestData")]
		public void the_sources_cannot_be_modified(BindingManager bindingManager, MultiSourceBinding binding, IPerson targetObject, IAddress sourceObject)
		{
			var ex = Assert.Throws<InvalidOperationException>(() => binding.Sources.Add(new Binding(targetObject, "Name", sourceObject, "Line1")));
			Assert.Equal("BindingBase is currently activated and cannot be modified.", ex.Message);
		}

		[Theory]
		[PropertyData("TestData")]
		public void the_mode_cannot_be_modified(BindingManager bindingManager, MultiSourceBinding binding, IPerson targetObject, IAddress sourceObject)
		{
			var ex = Assert.Throws<InvalidOperationException>(() => binding.Mode = BindingMode.OneWayToTarget);
			Assert.Equal("BindingBase is currently activated and cannot be modified.", ex.Message);
		}

		[Theory]
		[PropertyData("TestData")]
		public void the_converter_cannot_be_modified(BindingManager bindingManager, MultiSourceBinding binding, IPerson targetObject, IAddress sourceObject)
		{
			var converter = new Mock<IMultiValueConverter>();
			var ex = Assert.Throws<InvalidOperationException>(() => binding.Converter = converter.Object);
			Assert.Equal("BindingBase is currently activated and cannot be modified.", ex.Message);
		}

		[Theory]
		[PropertyData("TestData")]
		public void the_converter_parameter_cannot_be_modified(BindingManager bindingManager, MultiSourceBinding binding, IPerson targetObject, IAddress sourceObject)
		{
			var ex = Assert.Throws<InvalidOperationException>(() => binding.ConverterParameter = "whatever");
			Assert.Equal("BindingBase is currently activated and cannot be modified.", ex.Message);
		}

		public static IEnumerable<Func<IPerson, IAddress, MultiSourceBinding>> GetBindingFactories()
		{
			yield return delegate(IPerson targetObject, IAddress sourceObject)
			{
				var binding = new MultiBinding(targetObject, "Name");
				binding.Sources.Add(new Binding() { SourceObject = sourceObject, SourcePath = "Line1" });
				binding.Sources.Add(new Binding() { SourceObject = sourceObject, SourcePath = "Line2" });
				return binding;
			};

			yield return delegate(IPerson targetObject, IAddress sourceObject)
			{
				var binding = new TypedMultiBinding<IPerson>(targetObject, x => x.Name);
				binding.Sources.Add(new Binding() { SourceObject = sourceObject, SourcePath = "Line1" });
				binding.Sources.Add(new Binding() { SourceObject = sourceObject, SourcePath = "Line2" });
				return binding;
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
							binding.Converter = new NameAndAddressMultiValueConverter();
							var bindingManager = new BindingManager();
							bindingManager.Bindings.Add(binding);
							yield return new object[] { bindingManager, binding, person, address };
						}
					}
				}
			}
		}
	}

	public class When_a_multi_binding_is_added_to_a_binding_manager : When_a_multi_source_binding_is_added_to_a_binding_manager
	{
		[Theory]
		[PropertyData("TestData")]
		public void the_target_path_cannot_be_modified(BindingManager bindingManager, MultiSourceBinding binding, IPerson targetObject, IAddress sourceObject)
		{
			var multiBinding = binding as MultiBinding;

			if (multiBinding == null)
			{
				return;
			}

			var ex = Assert.Throws<InvalidOperationException>(() => multiBinding.TargetPath = null);
			Assert.Equal("BindingBase is currently activated and cannot be modified.", ex.Message);
		}

		public static new IEnumerable<object[]> TestData
		{
			get
			{
				foreach (var data in When_a_multi_source_binding_is_added_to_a_binding_manager.TestData)
				{
					yield return data;
				}
			}
		}
	}

	public class When_a_typed_multi_binding_is_added_to_a_binding_manager : When_a_multi_source_binding_is_added_to_a_binding_manager
	{
		[Theory]
		[PropertyData("TestData")]
		public void the_target_expression_cannot_be_modified(BindingManager bindingManager, MultiSourceBinding binding, IPerson targetObject, IAddress sourceObject)
		{
			var typedMultiBinding = binding as TypedMultiBinding<IPerson>;

			if (typedMultiBinding == null)
			{
				return;
			}

			var ex = Assert.Throws<InvalidOperationException>(() => typedMultiBinding.TargetExpression = null);
			Assert.Equal("BindingBase is currently activated and cannot be modified.", ex.Message);
		}

		public static new IEnumerable<object[]> TestData
		{
			get
			{
				foreach (var data in When_a_multi_source_binding_is_added_to_a_binding_manager.TestData)
				{
					yield return data;
				}
			}
		}
	}
}