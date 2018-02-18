using System;
using System.Collections.Generic;
using MvvmFx.Bindings.Data;
using MvvmFx.Bindings.Specifications.Support;
using MvvmFx.Bindings.Specifications.Support.Entities;
using Xunit;
using Xunit.Extensions;

namespace MvvmFx.Bindings.Specifications
{
	public class When_a_single_source_binding_has_a_mismatch_between_target_and_source_types_and_no_automatic_conversion_exists
	{
		[Theory]
		[PropertyData("TestData")]
		public void conversions_from_source_to_target_are_ignored_when_there_is_no_converter(BindingManager bindingManager, SingleSourceBinding binding, IPerson targetObject, IPerson sourceObject)
		{
			sourceObject.Gender = Gender.Male;
			Assert.Null(targetObject.Name);
		}

		[Theory]
		[PropertyData("TestData")]
		public void conversions_from_target_to_source_are_ignored_when_there_is_no_converter(BindingManager bindingManager, SingleSourceBinding binding, IPerson targetObject, IPerson sourceObject)
		{
			targetObject.Name = "Kent";
			Assert.Null(sourceObject.Gender);

			targetObject.Name = "Male";
			Assert.Null(sourceObject.Gender);
		}

		public static IEnumerable<Func<IPerson, IPerson, SingleSourceBinding>> GetBindingFactories()
		{
			yield return (targetObject, sourceObject) => new Binding(targetObject, "Name", sourceObject, "Gender");

			yield return (targetObject, sourceObject) => new TypedBinding<IPerson, IPerson>(targetObject, x => x.Name, sourceObject, x => x.Gender);
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