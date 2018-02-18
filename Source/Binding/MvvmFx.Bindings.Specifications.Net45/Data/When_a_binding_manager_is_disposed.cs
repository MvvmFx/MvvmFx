using System;
using MvvmFx.Bindings.Data;
using MvvmFx.Bindings.Specifications.Support.Entities.INPC;
using Xunit;

namespace MvvmFx.Bindings.Specifications
{
	public class When_a_binding_manager_is_disposed
	{
		private readonly BindingManager _bindingManager;
		private readonly Person _targetObject;
		private readonly Person _sourceObject;

		public When_a_binding_manager_is_disposed()
		{
			_bindingManager = new BindingManager();
			_targetObject = new Person();
			_sourceObject = new Person();
			_bindingManager.Bindings.Add(new Binding(_targetObject, "Name", _sourceObject, "Name"));
			_bindingManager.Bindings.Add(new Binding(_targetObject, "Age", _sourceObject, "Age"));
			_bindingManager.Dispose();
		}

		[Fact]
		public void it_can_be_disposed_again()
		{
			_bindingManager.Dispose();
			_bindingManager.Dispose();
		}

		[Fact]
		public void its_bindings_are_deactivated()
		{
			_targetObject.Name = "Kent";
			_targetObject.Age = 21;

			Assert.Null(_sourceObject.Name);
			Assert.Equal(0, _sourceObject.Age);
		}

		[Fact]
		public void accessing_the_bindings_collection_throws_an_exception()
		{
			var ex = Assert.Throws<ObjectDisposedException>(() => Console.WriteLine(_bindingManager.Bindings));
			Assert.Contains("BindingManager", ex.Message);
		}

		[Fact]
		public void accessing_the_container_throws_an_exception()
		{
			var ex = Assert.Throws<ObjectDisposedException>(() => Console.WriteLine((_bindingManager as IBindingContainer).Container));
			Assert.Contains("BindingManager", ex.Message);
		}
	}
}