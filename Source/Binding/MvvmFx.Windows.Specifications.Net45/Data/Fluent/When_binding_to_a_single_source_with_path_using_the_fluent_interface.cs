using System;
using MvvmFx.Bindings.Data;
using MvvmFx.Bindings.Specifications.Support.Entities.INPC;
using Moq;
using Xunit;

namespace MvvmFx.Bindings.Specifications.Fluent
{
	public class When_binding_to_a_single_source_with_path_using_the_fluent_interface
	{
		private readonly BindingManager _bindingManager;
		private readonly Person _targetObject;
		private readonly Address _sourceObject;

		public When_binding_to_a_single_source_with_path_using_the_fluent_interface()
		{
			_bindingManager = new BindingManager();
			_targetObject = new Person();
			_sourceObject = new Address();
		}

		[Fact]
		public void it_must_have_a_binding_manager()
		{
			BindingManager bindingManager = null;
			var ex = Assert.Throws<ArgumentNullException>(() => bindingManager.Bind(_targetObject, "Name"));
			Assert.Equal("bindingManager", ex.ParamName);
		}

		[Fact]
		public void it_must_have_a_target_object()
		{
			var ex = Assert.Throws<ArgumentNullException>(() => _bindingManager.Bind(null, "Name"));
			Assert.Equal("targetObject", ex.ParamName);
		}

		[Fact]
		public void it_must_have_a_target_path()
		{
			var ex = Assert.Throws<ArgumentNullException>(() => _bindingManager.Bind(_targetObject, (string)null));
			Assert.Equal("targetPath", ex.ParamName);
		}

		[Fact]
		public void nothing_happens_without_activation()
		{
			var converter = new Mock<IValueConverter>(MockBehavior.Strict);
			
			_bindingManager.Bind(_targetObject, "Name")
				.To(_sourceObject, "Line1")
				.WithConverter(converter.Object)
				.TwoWay();

			_targetObject.Name = "Kent";
			Assert.Null(_sourceObject.Line1);

			_sourceObject.Line1 = "Whatever";
			Assert.Equal("Kent", _targetObject.Name);
		}

		[Fact]
		public void binding_works_once_activated()
		{
			var converter = new Mock<IValueConverter>();
			converter.Setup(x => x.Convert("Line 1, mighty fine", typeof(string), "Some Parameter", null)).Returns("Converted value");

			_bindingManager.Bind(_targetObject, "Name")
				.To(_sourceObject, "Line1")
				.WithConverter(converter.Object, "Some Parameter")
				.OneWayToTarget()
				.Activate();

			_targetObject.Name = "Kent";
			Assert.Null(_sourceObject.Line1);

			_sourceObject.Line1 = "Line 1, mighty fine";
			Assert.Equal("Converted value", _targetObject.Name);

			converter.VerifyAll();
		}
	}
}