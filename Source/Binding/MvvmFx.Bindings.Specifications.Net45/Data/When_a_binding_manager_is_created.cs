using System.Threading;
using Moq;
using MvvmFx.Bindings.Data;
using Xunit;

namespace MvvmFx.Bindings.Specifications
{
	public class When_a_binding_manager_is_created
	{
		private BindingManager _bindingManager;

		public When_a_binding_manager_is_created()
		{
			_bindingManager = new BindingManager();
		}

		[Fact]
		public void it_has_a_bindings_collection()
		{
			Assert.NotNull(_bindingManager.Bindings);
		}

		[Fact]
		public void it_has_no_bindings_in_its_bindings_collection()
		{
			Assert.Equal(0, _bindingManager.Bindings.Count);
		}

		[Fact]
		public void it_uses_the_current_synchronization_context()
		{
			Assert.Same(SynchronizationContext.Current, _bindingManager.SynchronizationContext);

			var currentSynchronizationContext = SynchronizationContext.Current;

			try
			{
				var synchronizationContext = new Mock<SynchronizationContext>();
				SynchronizationContext.SetSynchronizationContext(synchronizationContext.Object);
				_bindingManager = new BindingManager();
				Assert.Same(SynchronizationContext.Current, _bindingManager.SynchronizationContext);
			}
			finally
			{
				SynchronizationContext.SetSynchronizationContext(currentSynchronizationContext);
			}
		}
	}
}