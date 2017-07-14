using System;
using System.Collections.Generic;
using MvvmFx.Windows.Data;
using MvvmFx.Windows.Specifications.Support;
using MvvmFx.Windows.Specifications.Support.Entities;
using Xunit;
using Xunit.Extensions;

namespace MvvmFx.Windows.Specifications
{
	public class When_a_single_source_binding_has_a_mismatch_between_target_and_source_types_and_an_automatic_conversion_exists
	{
		[Theory]
		[PropertyData("TestData")]
		public void conversions_from_source_to_target_are_automatically_converted_where_possible(BindingManager bindingManager, SingleSourceBinding binding, IPerson targetObject, IPerson sourceObject)
		{
			sourceObject.Age = 69;
			Assert.Equal("69", targetObject.Name);
		}

		[Theory]
		[PropertyData("TestData")]
		public void conversions_from_target_to_source_are_automatically_converted_where_possible(BindingManager bindingManager, SingleSourceBinding binding, IPerson targetObject, IPerson sourceObject)
		{
			targetObject.Name = "69";
			Assert.Equal(69, sourceObject.Age);

			targetObject.Name = "13a";
			Assert.Equal(69, sourceObject.Age);
		}

		public static IEnumerable<Func<IPerson, IPerson, SingleSourceBinding>> GetBindingFactories()
		{
			yield return (targetObject, sourceObject) => new Binding(targetObject, "Name", sourceObject, "Age");

			yield return (targetObject, sourceObject) => new TypedBinding<IPerson, IPerson>(targetObject, x => x.Name, sourceObject, x => x.Age);
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
}