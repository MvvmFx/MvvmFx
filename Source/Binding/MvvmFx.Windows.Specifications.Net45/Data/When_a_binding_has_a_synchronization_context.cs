using System;
using System.Collections.Generic;
using System.Threading;
using MvvmFx.Bindings.Data;
using MvvmFx.Bindings.Specifications.Support;
using MvvmFx.Bindings.Specifications.Support.Converters;
using MvvmFx.Bindings.Specifications.Support.Entities;
using Moq;
using Xunit.Extensions;

namespace MvvmFx.Bindings.Specifications
{
	public class When_a_binding_has_a_synchronization_context
	{
		[Theory]
		[PropertyData("TestData")]
		public void changes_to_the_target_should_be_marshalled_via_a_call_to_send(Mock<SynchronizationContext> synchronizationContext, BindingManager bindingManager, IPerson targetObject, IAddress sourceObject)
		{
			synchronizationContext.Setup(x => x.Send(It.IsAny<SendOrPostCallback>(), It.IsAny<object>()));
			targetObject.Name = "Test";

			synchronizationContext.VerifyAll();
		}

		[Theory]
		[PropertyData("TestData")]
		public void changes_to_the_source_should_be_marshalled_via_a_call_to_send(Mock<SynchronizationContext> synchronizationContext, BindingManager bindingManager, IPerson targetObject, IAddress sourceObject)
		{
			synchronizationContext.Setup(x => x.Send(It.IsAny<SendOrPostCallback>(), It.IsAny<object>()));
			sourceObject.Line1 = "Line 1, mighty fine";

			synchronizationContext.VerifyAll();
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
							var synchronizationContext = new Mock<SynchronizationContext>();
							var bindingManager = new BindingManager(synchronizationContext.Object);
							bindingManager.Bindings.Add(binding);
							yield return new object[] { synchronizationContext, bindingManager, person, address };
						}
					}
				}
			}
		}
	}
}