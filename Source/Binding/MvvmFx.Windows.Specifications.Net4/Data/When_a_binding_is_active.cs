using System;
using System.Collections.Generic;
using MvvmFx.Windows.Data;
using MvvmFx.Windows.Specifications.Support.Converters;
using MvvmFx.Windows.Specifications.Support.Entities;
using Xunit;
using Xunit.Extensions;

namespace MvvmFx.Windows.Specifications
{
	public class When_a_binding_is_active
	{
		[Theory]
		[PropertyData("TestData")]
		public void it_does_not_prevent_the_source_object_from_being_garbage_collected(BindingManager bindingManager, WeakReference targetObject, WeakReference sourceObject)
		{
			GC.Collect();
			GC.WaitForPendingFinalizers();
			Assert.False(sourceObject.IsAlive);
		}

		[Theory]
		[PropertyData("TestData")]
		public void it_does_not_prevent_the_target_object_from_being_garbage_collected(BindingManager bindingManager, WeakReference targetObject, WeakReference sourceObject)
		{
			GC.Collect();
			GC.WaitForPendingFinalizers();
			Assert.False(targetObject.IsAlive);
		}

		public static IEnumerable<WeakReference> People
		{
			get
			{
				yield return new WeakReference(new MvvmFx.Windows.Specifications.Support.Entities.INPC.Person());
				yield return new WeakReference(new MvvmFx.Windows.Specifications.Support.Entities.XxxChanged.Person());
			}
		}

		public static IEnumerable<WeakReference> Addresses
		{
			get
			{
				yield return new WeakReference(new MvvmFx.Windows.Specifications.Support.Entities.INPC.Address());
				yield return new WeakReference(new MvvmFx.Windows.Specifications.Support.Entities.XxxChanged.Address());
			}
		}

		public static IEnumerable<BindingBase> GetBindings(WeakReference targetObject, WeakReference sourceObject)
		{
			yield return new Binding(targetObject.Target, "Address.Line2", sourceObject.Target, "Line1");

			yield return new TypedBinding<IPerson, IAddress>(targetObject.Target as IPerson, x => x.Address.Line2, sourceObject.Target as IAddress, x => x.Line1);

			var multiBinding = new MultiBinding(targetObject.Target, "Name");
			multiBinding.Sources.Add(new Binding() { SourceObject = sourceObject.Target, SourcePath = "Line1" });
			multiBinding.Sources.Add(new Binding() { SourceObject = sourceObject.Target, SourcePath = "Line2" });
			multiBinding.Converter = new NameAndAddressMultiValueConverter();
			yield return multiBinding;

			var multiTypedBinding = new TypedMultiBinding<IPerson>(targetObject.Target as IPerson, x => x.Name);
			multiTypedBinding.Sources.Add(new Binding() { SourceObject = sourceObject.Target, SourcePath = "Line1" });
			multiTypedBinding.Sources.Add(new Binding() { SourceObject = sourceObject.Target, SourcePath = "Line2" });
			multiTypedBinding.Converter = new NameAndAddressMultiValueConverter();
			yield return multiTypedBinding;
		}

		public static IEnumerable<object[]> TestData
		{
			get
			{
				foreach (var person in People)
				{
					foreach (var address in Addresses)
					{
						foreach (var binding in GetBindings(person, address))
						{
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