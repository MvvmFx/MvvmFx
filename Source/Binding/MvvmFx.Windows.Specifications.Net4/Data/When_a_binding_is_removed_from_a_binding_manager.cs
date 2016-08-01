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
	public class When_a_binding_is_removed_from_a_binding_manager
	{
		[Theory]
		[PropertyData("TestData")]
		public void it_is_not_present_in_the_bindings_collection(BindingManager bindingManager, BindingBase binding, IPerson targetObject, IAddress sourceObject)
		{
			Assert.DoesNotContain(binding, bindingManager.Bindings);
		}

		[Theory]
		[PropertyData("TestData")]
		public void it_becomes_inactive(BindingManager bindingManager, BindingBase binding, IPerson targetObject, IAddress sourceObject)
		{
			sourceObject.Line1 = "New Name";
			Assert.Null(targetObject.Name);

			targetObject.Name = "Another Name";
			Assert.Equal("New Name", sourceObject.Line1);
		}

		public static IEnumerable<Func<IPerson, IAddress, BindingBase>> GetBindingFactories()
		{
			yield return (targetObject, sourceObject) => new Binding(targetObject, "Name", sourceObject, "Line1");

			yield return (targetObject, sourceObject) => new TypedBinding<IPerson, IAddress>(targetObject, x => x.Name, sourceObject, x => x.Line1);

			yield return delegate(IPerson targetObject, IAddress sourceObject)
			{
				var multiBinding = new MultiBinding(targetObject, "Name");
				multiBinding.Sources.Add(new Binding() { SourceObject = sourceObject, SourcePath = "Line1" });
				multiBinding.Converter = new NameAndAddressMultiValueConverter();
				return multiBinding;
			};

			yield return delegate(IPerson targetObject, IAddress sourceObject)
			{
				var typedMultiBinding = new TypedMultiBinding<IPerson>(targetObject, x => x.Name);
				typedMultiBinding.Sources.Add(new Binding() { SourceObject = sourceObject, SourcePath = "Line1" });
				typedMultiBinding.Converter = new NameAndAddressMultiValueConverter();
				return typedMultiBinding;
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
							var bindingManager = new BindingManager();
							bindingManager.Bindings.Add(binding);
							bindingManager.Bindings.Remove(binding);
							yield return new object[] { bindingManager, binding, person, address };
						}
					}
				}
			}
		}
	}
}