using System;
using MvvmFx.Bindings.Data;
using MvvmFx.Bindings.Specifications.Support.Entities.INPC;
using Moq;
using Xunit;

namespace MvvmFx.Bindings.Specifications.Fluent
{
	public class When_binding_to_multiple_sources_with_lambda_using_the_fluent_interface
	{
		private readonly BindingManager _bindingManager;
		private readonly Person _targetObject;
		private readonly Address _sourceObject;

		public When_binding_to_multiple_sources_with_lambda_using_the_fluent_interface()
		{
			_bindingManager = new BindingManager();
			_targetObject = new Person();
			_sourceObject = new Address();
		}

		[Fact]
		public void it_must_have_a_binding_manager()
		{
			BindingManager bindingManager = null;
			var ex = Assert.Throws<ArgumentNullException>(() => bindingManager.MultiBind(_targetObject, "Name"));
			Assert.Equal("bindingManager", ex.ParamName);
		}

		[Fact]
		public void it_must_have_a_target_object()
		{
			var ex = Assert.Throws<ArgumentNullException>(() => _bindingManager.MultiBind(null, "Name"));
			Assert.Equal("targetObject", ex.ParamName);
		}

		[Fact]
		public void it_must_have_a_target_expression()
		{
			var ex = Assert.Throws<ArgumentNullException>(() => _bindingManager.MultiBind(_targetObject, null));
			Assert.Equal("targetExpression", ex.ParamName);
		}

		[Fact]
		public void nothing_happens_without_activation()
		{
			var converter = new Mock<IMultiValueConverter>(MockBehavior.Strict);

			_bindingManager.MultiBind(_targetObject, x => x.Name)
				.WithConverter(converter.Object, "Some Parameter")
				.TwoWay()
					.To(_sourceObject, x => x.Line1)
					.AndTo(_sourceObject, x => x.Line2)
					.AndTo(_sourceObject, x => x.Line3);

			_targetObject.Name = "Kent";
			Assert.Null(_sourceObject.Line1);
			Assert.Null(_sourceObject.Line2);
			Assert.Null(_sourceObject.Line3);

			_sourceObject.Line1 = "Whatever";
			_sourceObject.Line2 = "Whatever";
			_sourceObject.Line3 = "Whatever";
			Assert.Equal("Kent", _targetObject.Name);
		}

		[Fact]
		public void binding_works_once_activated()
		{
			var converter = new Mock<IMultiValueConverter>(MockBehavior.Strict);
			converter.Setup(x => x.Convert(It.IsAny<object[]>(), It.IsAny<Type>(), "Some Parameter", null)).Returns("Converted Value");

			_bindingManager.MultiBind(_targetObject, x => x.Name)
				.WithConverter(converter.Object, "Some Parameter")
				.OneWayToTarget()
					.To(_sourceObject, x => x.Line1)
					.AndTo(_sourceObject, x => x.Line2)
					.AndTo(_sourceObject, x => x.Line3)
				.Activate();

			_targetObject.Name = "Kent";
			Assert.Null(_sourceObject.Line1);
			Assert.Null(_sourceObject.Line2);
			Assert.Null(_sourceObject.Line3);

			_sourceObject.Line1 = "Line1";
			_sourceObject.Line2 = "Line2";
			_sourceObject.Line3 = "Line3";
			Assert.Equal("Converted Value", _targetObject.Name);

			converter.VerifyAll();
		}
	}
}