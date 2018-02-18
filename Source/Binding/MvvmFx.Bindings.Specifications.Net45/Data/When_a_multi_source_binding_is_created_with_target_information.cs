using System;
using System.Collections.Generic;
using MvvmFx.Bindings.Data;
using MvvmFx.Bindings.Specifications.Support;
using MvvmFx.Bindings.Specifications.Support.Converters;
using MvvmFx.Bindings.Specifications.Support.Entities;
using Xunit;
using Xunit.Extensions;

namespace MvvmFx.Bindings.Specifications
{
	public abstract class When_a_multi_source_binding_is_created_with_target_information
	{
		[Theory]
		[PropertyData("TestData")]
		public void it_has_the_correct_target(MultiSourceBinding binding, IPerson targetObject, IAddress sourceObject)
		{
			Assert.Same(targetObject, binding.TargetObject);
		}

		[Theory]
		[PropertyData("TestData")]
		public void it_is_not_yet_active(MultiSourceBinding binding, IPerson targetObject, IAddress sourceObject)
		{
			sourceObject.Line1 = "Line 1";
			Assert.Null(targetObject.Name);

			targetObject.Name = "Another Name";
			Assert.Equal("Line 1", sourceObject.Line1);
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
							yield return new object[] { binding, person, address };
						}
					}
				}
			}
		}
	}

	public class When_a_multi_binding_is_created_with_source_and_target_information : When_a_multi_source_binding_is_created_with_target_information
	{
		[Theory]
		[PropertyData("TestData")]
		public void it_has_the_correct_target_path(MultiSourceBinding binding, IPerson targetObject, IAddress sourceObject)
		{
			var multiBinding = binding as MultiBinding;

			if (multiBinding == null)
			{
				return;
			}

			Assert.Same("Name", multiBinding.TargetPath);
		}

		public static new IEnumerable<object[]> TestData
		{
			get
			{
				foreach (var data in When_a_multi_source_binding_is_created_with_target_information.TestData)
				{
					yield return data;
				}
			}
		}
	}

	public class When_a_typed_multi_binding_is_created_with_source_and_target_information : When_a_multi_source_binding_is_created_with_target_information
	{
		[Theory]
		[PropertyData("TestData")]
		public void it_has_the_target_expression(MultiSourceBinding binding, IPerson targetObject, IAddress sourceObject)
		{
			var typedMultiBinding = binding as TypedMultiBinding<IPerson>;

			if (typedMultiBinding == null)
			{
				return;
			}

			Assert.NotNull(typedMultiBinding.TargetExpression);
		}

		public static new IEnumerable<object[]> TestData
		{
			get
			{
				foreach (var data in When_a_multi_source_binding_is_created_with_target_information.TestData)
				{
					yield return data;
				}
			}
		}
	}
}