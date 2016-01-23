using System;
using System.Collections.Generic;
using System.ComponentModel;
using MvvmFx.Windows.Data;
using MvvmFx.Windows.Specifications.Support.Converters;
using Xunit;
using Xunit.Extensions;

namespace MvvmFx.Windows.Specifications
{
	public class When_a_binding_is_used_against_a_class_that_implements_ICustomTypeDescriptor
	{
		[Theory]
		[PropertyData("TestData")]
		public void properties_and_events_exposed_by_the_class_are_successfully_resolved_and_bound(BindingManager bindingManager, CustomEntity targetObject, CustomEntity sourceObject)
		{
			SetName(sourceObject, "A new name");
			Assert.Equal("A new name", GetName(targetObject));

			SetName(targetObject, "Another name");
			Assert.Equal("Another name", GetName(sourceObject));
		}

		private string GetName(CustomEntity customEntity)
		{
			return TypeDescriptor.GetProperties(customEntity).Find("Name", false).GetValue(customEntity) as string;
		}

		private void SetName(CustomEntity customEntity, string name)
		{
			TypeDescriptor.GetProperties(customEntity).Find("Name", false).SetValue(customEntity, name);
		}

		public static IEnumerable<Func<CustomEntity, CustomEntity, BindingBase>> GetBindingFactories()
		{
			yield return (targetObject, sourceObject) => new Binding(targetObject, "Name", sourceObject, "Name");

			yield return delegate(CustomEntity targetObject, CustomEntity sourceObject)
			{
				var multiBinding = new MultiBinding(targetObject, "Name");
				multiBinding.Sources.Add(new Binding() { SourceObject = sourceObject, SourcePath = "Name" });
				multiBinding.Converter = new NameAndAddressMultiValueConverter();
				return multiBinding;
			};
		}

		public static IEnumerable<object[]> TestData
		{
			get
			{
				foreach (var bindingFactory in GetBindingFactories())
				{
					var target = new CustomEntity();
					var source = new CustomEntity();
					var binding = bindingFactory(target, source);
					var bindingManager = new BindingManager();
					bindingManager.Bindings.Add(binding);
					yield return new object[] { bindingManager, target, source };
				}
			}
		}

		#region Supporting Types

		public class CustomEntity : CustomTypeDescriptor
		{
			private static readonly MyPropertyDescriptor _propertyDescriptor = new MyPropertyDescriptor();
			private static readonly MyEventDescriptor _eventDescriptor = new MyEventDescriptor();

			public CustomEntity()
			{
				EventHandler handler = delegate(object sender, EventArgs e)
				{
					_eventDescriptor.Raise(sender);
				};

				_propertyDescriptor.AddValueChanged(this, handler);
			}

			public override PropertyDescriptorCollection GetProperties()
			{
				var properties = new PropertyDescriptorCollection(new PropertyDescriptor[] { _propertyDescriptor });
				return properties;
			}

			public override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
			{
				return GetProperties();
			}

			public override EventDescriptorCollection GetEvents()
			{
				var events = new EventDescriptorCollection(new EventDescriptor[] { _eventDescriptor });
				return events;
			}

			public override EventDescriptorCollection GetEvents(Attribute[] attributes)
			{
				return GetEvents();
			}
		}

		private class MyPropertyDescriptor : PropertyDescriptor
		{
			private readonly IDictionary<object, object> _values;

			public MyPropertyDescriptor()
				: base("Name", null)
			{
				_values = new Dictionary<object, object>();
			}

			public override bool CanResetValue(object component)
			{
				throw new NotImplementedException();
			}

			public override Type ComponentType
			{
				get { throw new NotImplementedException(); }
			}

			public override object GetValue(object component)
			{
				object value = null;
				_values.TryGetValue(component, out value);
				return value;
			}

			public override bool IsReadOnly
			{
				get { throw new NotImplementedException(); }
			}

			public override Type PropertyType
			{
				get { return typeof(object); }
			}

			public override void ResetValue(object component)
			{
				throw new NotImplementedException();
			}

			public override void SetValue(object component, object value)
			{
				var oldValue = GetValue(component);

				if (oldValue != value)
				{
					_values[component] = value;
					OnValueChanged(component, new PropertyChangedEventArgs("Name"));
				}
			}

			public override bool ShouldSerializeValue(object component)
			{
				throw new NotImplementedException();
			}
		}

		private class MyEventDescriptor : EventDescriptor
		{
			private readonly IDictionary<object, EventHandler<EventArgs>> _handlers;

			public MyEventDescriptor()
				: base("NameChanged", null)
			{
				_handlers = new Dictionary<object, EventHandler<EventArgs>>();
			}

			public override void AddEventHandler(object component, Delegate value)
			{
				EventHandler<EventArgs> handler;
				_handlers.TryGetValue(component, out handler);

				handler = (EventHandler<EventArgs>)Delegate.Combine(handler, (EventHandler<EventArgs>)value);
				_handlers[component] = handler;
			}

			public override Type ComponentType
			{
				get { throw new NotImplementedException(); }
			}

			public override Type EventType
			{
				get { return typeof(EventHandler<EventArgs>); }
			}

			public override bool IsMulticast
			{
				get { return true; }
			}

			public override void RemoveEventHandler(object component, Delegate value)
			{
				EventHandler<EventArgs> handler;
				_handlers.TryGetValue(component, out handler);

				handler = (EventHandler<EventArgs>)Delegate.Remove(handler, (EventHandler<EventArgs>)value);

				if (handler == null)
				{
					_handlers.Remove(component);
				}
				else
				{
					_handlers[component] = handler;
				}
			}

			public void Raise(object component)
			{
				EventHandler<EventArgs> handler;
				_handlers.TryGetValue(component, out handler);

				if (handler != null)
				{
					handler(this, EventArgs.Empty);
				}
			}
		}

		#endregion
	}
}