using System;
using System.Collections.Generic;
using MvvmFx.Windows.Data;
using MvvmFx.Windows.Specifications.Support;
using MvvmFx.Windows.Specifications.Support.Converters;
using MvvmFx.Windows.Specifications.Support.Entities;
using Xunit;
using Xunit.Extensions;

namespace MvvmFx.Windows.Specifications
{
	public abstract class When_a_multi_source_binding_is_created_without_target_information
	{
		[Theory]
		[PropertyData("TestData")]
		public void it_has_no_sources(MultiSourceBinding binding, IPerson targetObject, IAddress sourceObject)
		{
			Assert.Empty(binding.Sources);
		}

		[Theory]
		[PropertyData("TestData")]
		public void it_has_no_target_object(MultiSourceBinding binding, IPerson targetObject, IAddress sourceObject)
		{
			Assert.Null(binding.TargetObject);
		}

		public static IEnumerable<Func<IPerson, IAddress, MultiSourceBinding>> GetBindingFactories()
		{
			yield return (targetObject, sourceObject) => new MultiBinding();

			yield return (targetObject, sourceObject) => new TypedMultiBinding<IPerson>();
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

	public class When_a_multi_binding_is_created_without_source_and_target_information : When_a_multi_source_binding_is_created_without_target_information
	{
		[Theory]
		[PropertyData("TestData")]
		public void it_has_no_target_path(MultiSourceBinding binding, IPerson targetObject, IAddress sourceObject)
		{
			var multiBinding = binding as MultiBinding;

			if (multiBinding == null)
			{
				return;
			}

			Assert.Null(multiBinding.TargetPath);
		}

		public static new IEnumerable<object[]> TestData
		{
			get
			{
				foreach (var data in When_a_multi_source_binding_is_created_without_target_information.TestData)
				{
					yield return data;
				}
			}
		}
	}

	public class When_a_typed_multi_binding_is_created_without_source_and_target_information : When_a_multi_source_binding_is_created_without_target_information
	{
		[Theory]
		[PropertyData("TestData")]
		public void it_has_no_target_expression(MultiSourceBinding binding, IPerson targetObject, IAddress sourceObject)
		{
			var typedMultiBinding = binding as TypedMultiBinding<IPerson>;

			if (typedMultiBinding == null)
			{
				return;
			}

			Assert.Null(typedMultiBinding.TargetExpression);
		}

		public static new IEnumerable<object[]> TestData
		{
			get
			{
				foreach (var data in When_a_multi_source_binding_is_created_without_target_information.TestData)
				{
					yield return data;
				}
			}
		}
	}
}