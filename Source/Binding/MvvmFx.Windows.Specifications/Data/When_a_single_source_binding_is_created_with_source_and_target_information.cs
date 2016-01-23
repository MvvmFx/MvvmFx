using System;
using System.Collections.Generic;
using MvvmFx.Windows.Data;
using MvvmFx.Windows.Specifications.Support;
using MvvmFx.Windows.Specifications.Support.Entities;
using Xunit;
using Xunit.Extensions;

namespace MvvmFx.Windows.Specifications
{
	public abstract class When_a_single_source_binding_is_created_with_source_and_target_information
	{
		[Theory]
		[PropertyData("TestData")]
		public void it_has_the_correct_source(SingleSourceBinding binding, IPerson targetObject, IPerson sourceObject)
		{
			Assert.Same(sourceObject, binding.SourceObject);
		}

		[Theory]
		[PropertyData("TestData")]
		public void it_has_the_correct_target(SingleSourceBinding binding, IPerson targetObject, IPerson sourceObject)
		{
			Assert.Same(targetObject, binding.TargetObject);
		}

		[Theory]
		[PropertyData("TestData")]
		public void it_is_not_yet_active(SingleSourceBinding binding, IPerson targetObject, IPerson sourceObject)
		{
			sourceObject.Name = "New Name";
			Assert.Null(targetObject.Name);

			targetObject.Name = "Another Name";
			Assert.Equal("New Name", sourceObject.Name);
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
						yield return new object[] { binding, targetObject, sourceObject };
					}
				}
			}
		}
	}

	public class When_a_binding_is_created_with_source_and_target_information : When_a_single_source_binding_is_created_with_source_and_target_information
	{
		[Theory]
		[PropertyData("TestData")]
		public void it_has_the_correct_source_path(SingleSourceBinding singleSourceBinding, IPerson targetObject, IPerson sourceObject)
		{
			var binding = singleSourceBinding as Binding;

			if (binding == null)
			{
				return;
			}

			Assert.Same("Name", binding.SourcePath);
		}

		[Theory]
		[PropertyData("TestData")]
		public void it_has_the_correct_target_path(SingleSourceBinding singleSourceBinding, IPerson targetObject, IPerson sourceObject)
		{
			var binding = singleSourceBinding as Binding;

			if (binding == null)
			{
				return;
			}

			Assert.Same("Name", binding.TargetPath);
		}

		public static new IEnumerable<object[]> TestData
		{
			get
			{
				foreach (var data in When_a_single_source_binding_is_created_with_source_and_target_information.TestData)
				{
					yield return data;
				}
			}
		}
	}

	public class When_a_typed_binding_is_created_with_source_and_target_information : When_a_single_source_binding_is_created_with_source_and_target_information
	{
		[Theory]
		[PropertyData("TestData")]
		public void it_has_the_source_expression(SingleSourceBinding singleSourceBinding, IPerson targetObject, IPerson sourceObject)
		{
			var typedBinding = singleSourceBinding as TypedBinding<IPerson, IPerson>;

			if (typedBinding == null)
			{
				return;
			}

			Assert.NotNull(typedBinding.SourceExpression);
		}

		[Theory]
		[PropertyData("TestData")]
		public void it_has_the_target_expression(SingleSourceBinding singleSourceBinding, IPerson targetObject, IPerson sourceObject)
		{
			var typedBinding = singleSourceBinding as TypedBinding<IPerson, IPerson>;

			if (typedBinding == null)
			{
				return;
			}

			Assert.NotNull(typedBinding.TargetExpression);
		}

		public static new IEnumerable<object[]> TestData
		{
			get
			{
				foreach (var data in When_a_single_source_binding_is_created_with_source_and_target_information.TestData)
				{
					yield return data;
				}
			}
		}
	}
}