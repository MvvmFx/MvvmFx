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
	public class When_a_binding_is_one_way_to_source
	{
		[Theory]
		[PropertyData("TestData")]
		public void updating_the_source_does_not_update_the_target(BindingManager bindingManager, IPerson targetObject, IAddress sourceObject)
		{
			sourceObject.Line1 = "A new address";
			Assert.Null(targetObject.Name);

			sourceObject.Line1 = "Another new address";
			Assert.Null(targetObject.Name);
		}

		[Theory]
		[PropertyData("TestData")]
		public void updating_the_target_updates_the_source(BindingManager bindingManager, IPerson targetObject, IAddress sourceObject)
		{
			targetObject.Name = "A new address";
			Assert.Equal("A new address", sourceObject.Line1);

			targetObject.Name = "Another new address";
			Assert.Equal("Another new address", sourceObject.Line1);

			targetObject.Name = null;
			Assert.Null(sourceObject.Line1);
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
							binding.Mode = BindingMode.OneWayToSource;
							var bindingManager = new BindingManager();
							bindingManager.Bindings.Add(binding);
							yield return new object[] { bindingManager, person, address };
						}
					}
				}
			}
		}
	}
}