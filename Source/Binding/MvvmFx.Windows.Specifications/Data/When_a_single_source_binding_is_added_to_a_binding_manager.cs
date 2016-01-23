using System;
using System.Collections.Generic;
using MvvmFx.Windows.Data;
using MvvmFx.Windows.Specifications.Support;
using MvvmFx.Windows.Specifications.Support.Entities;
using Moq;
using Xunit;
using Xunit.Extensions;

namespace MvvmFx.Windows.Specifications
{
	public abstract class When_a_single_source_binding_is_added_to_a_binding_manager
	{
		[Theory]
		[PropertyData("TestData")]
		public void it_is_present_in_the_bindings_collection(BindingManager bindingManager, SingleSourceBinding binding, IPerson targetObject, IPerson sourceObject)
		{
			Assert.Contains(binding, bindingManager.Bindings);
		}

		[Theory]
		[PropertyData("TestData")]
		public void it_becomes_active(BindingManager bindingManager, SingleSourceBinding binding, IPerson targetObject, IPerson sourceObject)
		{
			sourceObject.Name = "New Name";
			Assert.Equal("New Name", targetObject.Name);

			targetObject.Name = "Another Name";
			Assert.Equal("Another Name", sourceObject.Name);
		}

		[Theory]
		[PropertyData("TestData")]
		public void it_cannot_be_added_again(BindingManager bindingManager, SingleSourceBinding binding, IPerson targetObject, IPerson sourceObject)
		{
			var ex = Assert.Throws<InvalidOperationException>(() => bindingManager.Bindings.Add(binding));
			Assert.Equal("This binding is already activated.", ex.Message);
		}

		[Theory]
		[PropertyData("TestData")]
		public void the_source_object_cannot_be_modified(BindingManager bindingManager, SingleSourceBinding binding, IPerson targetObject, IPerson sourceObject)
		{
			var ex = Assert.Throws<InvalidOperationException>(() => binding.SourceObject = null);
			Assert.Equal("BindingBase is currently activated and cannot be modified.", ex.Message);
		}

		[Theory]
		[PropertyData("TestData")]
		public void the_target_object_cannot_be_modified(BindingManager bindingManager, SingleSourceBinding binding, IPerson targetObject, IPerson sourceObject)
		{
			var ex = Assert.Throws<InvalidOperationException>(() => binding.TargetObject = null);
			Assert.Equal("BindingBase is currently activated and cannot be modified.", ex.Message);
		}

		[Theory]
		[PropertyData("TestData")]
		public void the_mode_cannot_be_modified(BindingManager bindingManager, SingleSourceBinding binding, IPerson targetObject, IPerson sourceObject)
		{
			var ex = Assert.Throws<InvalidOperationException>(() => binding.Mode = BindingMode.OneWayToTarget);
			Assert.Equal("BindingBase is currently activated and cannot be modified.", ex.Message);
		}

		[Theory]
		[PropertyData("TestData")]
		public void the_converter_cannot_be_modified(BindingManager bindingManager, SingleSourceBinding binding, IPerson targetObject, IPerson sourceObject)
		{
			var converter = new Mock<IValueConverter>();
			var ex = Assert.Throws<InvalidOperationException>(() => binding.Converter = converter.Object);
			Assert.Equal("BindingBase is currently activated and cannot be modified.", ex.Message);
		}

		[Theory]
		[PropertyData("TestData")]
		public void the_converter_parameter_cannot_be_modified(BindingManager bindingManager, SingleSourceBinding binding, IPerson targetObject, IPerson sourceObject)
		{
			var ex = Assert.Throws<InvalidOperationException>(() => binding.ConverterParameter = "whatever");
			Assert.Equal("BindingBase is currently activated and cannot be modified.", ex.Message);
		}

		public static IEnumerable<Func<IPerson, IPerson, SingleSourceBinding>> GetBindingFactories()
		{
			yield return (targetObject, sourceObject) => new Binding(targetObject, "Name", sourceObject, "Name");

			yield return (targetObject, sourceObject) => new TypedBinding<IPerson, IPerson>(targetObject, x => x.Name, sourceObject, x => x.Name);
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
						bindingManager.Bindings.Add(binding);
						yield return new object[] { bindingManager, binding, targetObject, sourceObject };
					}
				}
			}
		}
	}

	public class When_a_binding_is_added_to_a_binding_manager : When_a_single_source_binding_is_added_to_a_binding_manager
	{
		[Theory]
		[PropertyData("TestData")]
		public void the_source_path_cannot_be_modified(BindingManager bindingManager, SingleSourceBinding singleSourceBinding, IPerson targetObject, IPerson sourceObject)
		{
			var binding = singleSourceBinding as Binding;

			if (binding == null)
			{
				return;
			}

			var ex = Assert.Throws<InvalidOperationException>(() => binding.SourcePath = null);
			Assert.Equal("BindingBase is currently activated and cannot be modified.", ex.Message);
		}

		[Theory]
		[PropertyData("TestData")]
		public void the_target_path_cannot_be_modified(BindingManager bindingManager, SingleSourceBinding singleSourceBinding, IPerson targetObject, IPerson sourceObject)
		{
			var binding = singleSourceBinding as Binding;

			if (binding == null)
			{
				return;
			}

			var ex = Assert.Throws<InvalidOperationException>(() => binding.TargetPath = null);
			Assert.Equal("BindingBase is currently activated and cannot be modified.", ex.Message);
		}

		public static new IEnumerable<object[]> TestData
		{
			get
			{
				foreach (var data in When_a_single_source_binding_is_added_to_a_binding_manager.TestData)
				{
					yield return data;
				}
			}
		}
	}

	public class When_a_typed_binding_is_added_to_a_binding_manager : When_a_single_source_binding_is_added_to_a_binding_manager
	{
		[Theory]
		[PropertyData("TestData")]
		public void the_source_expression_cannot_be_modified(BindingManager bindingManager, SingleSourceBinding singleSourceBinding, IPerson targetObject, IPerson sourceObject)
		{
			var typedBinding = singleSourceBinding as TypedBinding<IPerson, IPerson>;

			if (typedBinding == null)
			{
				return;
			}

			var ex = Assert.Throws<InvalidOperationException>(() => typedBinding.SourceExpression = null);
			Assert.Equal("BindingBase is currently activated and cannot be modified.", ex.Message);
		}

		[Theory]
		[PropertyData("TestData")]
		public void the_target_expression_cannot_be_modified(BindingManager bindingManager, SingleSourceBinding singleSourceBinding, IPerson targetObject, IPerson sourceObject)
		{
			var typedBinding = singleSourceBinding as TypedBinding<IPerson, IPerson>;

			if (typedBinding == null)
			{
				return;
			}

			var ex = Assert.Throws<InvalidOperationException>(() => typedBinding.TargetExpression = null);
			Assert.Equal("BindingBase is currently activated and cannot be modified.", ex.Message);
		}

		public static new IEnumerable<object[]> TestData
		{
			get
			{
				foreach (var data in When_a_single_source_binding_is_added_to_a_binding_manager.TestData)
				{
					yield return data;
				}
			}
		}
	}
}