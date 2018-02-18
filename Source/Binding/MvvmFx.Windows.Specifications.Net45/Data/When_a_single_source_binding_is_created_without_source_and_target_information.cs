using System;
using System.Collections.Generic;
using MvvmFx.Bindings.Data;
using MvvmFx.Bindings.Specifications.Support;
using MvvmFx.Bindings.Specifications.Support.Entities;
using Xunit;
using Xunit.Extensions;

namespace MvvmFx.Bindings.Specifications
{
	public abstract class When_a_single_source_binding_is_created_without_source_and_target_information
	{
		[Theory]
		[PropertyData("TestData")]
		public void it_has_no_source_object(SingleSourceBinding binding, IPerson targetObject, IPerson sourceObject)
		{
			Assert.Null(binding.SourceObject);
		}

		[Theory]
		[PropertyData("TestData")]
		public void it_has_no_target_object(SingleSourceBinding binding, IPerson targetObject, IPerson sourceObject)
		{
			Assert.Null(binding.TargetObject);
		}

		public static IEnumerable<Func<IPerson, IPerson, SingleSourceBinding>> GetBindingFactories()
		{
			yield return (targetObject, sourceObject) => new Binding();

			yield return (targetObject, sourceObject) => new TypedBinding<IPerson, IPerson>();
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
						yield return new object[] { binding, targetObject, sourceObject };
					}
				}
			}
		}
	}

	public class When_a_binding_is_created_without_source_and_target_information : When_a_single_source_binding_is_created_without_source_and_target_information
	{
		[Theory]
		[PropertyData("TestData")]
		public void it_has_no_source_path(SingleSourceBinding singleSourceBinding, IPerson targetObject, IPerson sourceObject)
		{
			var binding = singleSourceBinding as Binding;

			if (binding == null)
			{
				return;
			}

			Assert.Null(binding.SourcePath);
		}

		[Theory]
		[PropertyData("TestData")]
		public void it_has_no_target_path(SingleSourceBinding singleSourceBinding, IPerson targetObject, IPerson sourceObject)
		{
			var binding = singleSourceBinding as Binding;

			if (binding == null)
			{
				return;
			}

			Assert.Null(binding.TargetPath);
		}

		public static new IEnumerable<object[]> TestData
		{
			get
			{
				foreach (var data in When_a_single_source_binding_is_created_without_source_and_target_information.TestData)
				{
					yield return data;
				}
			}
		}
	}

	public class When_a_typed_binding_is_created_without_source_and_target_information : When_a_single_source_binding_is_created_without_source_and_target_information
	{
		[Theory]
		[PropertyData("TestData")]
		public void it_has_no_source_expression(SingleSourceBinding singleSourceBinding, IPerson targetObject, IPerson sourceObject)
		{
			var typedBinding = singleSourceBinding as TypedBinding<IPerson, IPerson>;

			if (typedBinding == null)
			{
				return;
			}

			Assert.Null(typedBinding.SourceExpression);
		}

		[Theory]
		[PropertyData("TestData")]
		public void it_has_no_target_expression(SingleSourceBinding singleSourceBinding, IPerson targetObject, IPerson sourceObject)
		{
			var typedBinding = singleSourceBinding as TypedBinding<IPerson, IPerson>;

			if (typedBinding == null)
			{
				return;
			}

			Assert.Null(typedBinding.TargetExpression);
		}

		public static new IEnumerable<object[]> TestData
		{
			get
			{
				foreach (var data in When_a_single_source_binding_is_created_without_source_and_target_information.TestData)
				{
					yield return data;
				}
			}
		}
	}
}