using System;
using System.ComponentModel;
using Wisej.Web;

namespace MvvmFx.CaliburnMicro.WisejWeb.Toolable
{
    /// <summary>
    /// Proxy class for <see cref="ComponentToolEx"/> components.
    /// </summary>
    [DefaultProperty("Name")]
    public class ComponentToolExProxy : Control
    {
        private bool _eventsWired;
        private bool _isEnabledChanging;
        private bool _isVisibleChanging;

        /// <summary>
        /// Returns a dynamic object that can be used to store custom data in relation to this control.
        /// </summary>
        public new dynamic UserData
        {
            get { return Item.UserData; }
        }

        /// <summary>
        /// Gets the <see cref="ComponentToolEx"/> component item.
        /// </summary>
        /// <value>
        /// The component item.
        /// </value>
        public ComponentToolEx Item { get; }

        private ComponentToolExProxy()
        {
            // force to use parametrized constructor
        }

        /// <summary>Dispose the control.</summary>
        /// <param name="disposing">true when this method is called by the application rather than a finalizer.</param>
        protected override void Dispose(bool disposing)
        {
            UnwireEvents();
            Item.Dispose();
            base.Dispose(disposing);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ComponentToolExProxy" /> class, for the specified <see cref="ComponentToolExProxy" />.
        /// </summary>
        /// <param name="item">The tool strip item.</param>
        /// <param name="parent">The parent Control.</param>
        /// <param name="wireEvents">if set to <c>true</c>, the constructor will wire the item events.</param>
        public ComponentToolExProxy(ComponentToolEx item, Control parent, bool wireEvents)
        {
            Parent = parent;
            Item = item;
            Name = item.Name;
            Enabled = item.Enabled;
            Visible = item.Visible;

            if (wireEvents)
                WireEvents();
        }

        /// <summary>
        /// Wires the proxy events.
        /// </summary>
        public void WireEvents()
        {
            if (_eventsWired)
                return;

            EnabledChanged += ComponentToolExProxy_EnabledChanged;
            VisibleChanged += ComponentToolExProxy_VisibleChanged;
            Item.Click += item_Click;
            Item.Disposed += item_Disposed;

            _eventsWired = true;
        }

        /// <summary>
        /// Unwires the proxy events.
        /// </summary>
        public void UnwireEvents()
        {
            if (!_eventsWired)
                return;

            Item.Disposed -= item_Disposed;
            Item.Click -= item_Click;
            VisibleChanged -= ComponentToolExProxy_VisibleChanged;
            EnabledChanged -= ComponentToolExProxy_EnabledChanged;

            _eventsWired = false;
        }

        private void item_Disposed(object sender, EventArgs e)
        {
            UnwireEvents();
            Dispose();
        }

        private void item_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }

        private void ComponentToolExProxy_EnabledChanged(object sender, EventArgs e)
        {
            if (_isEnabledChanging)
                return;

            _isEnabledChanging = true;
            Item.Enabled = Enabled;
            _isEnabledChanging = false;
        }

        private void ComponentToolExProxy_VisibleChanged(object sender, EventArgs e)
        {
            if (_isVisibleChanging)
                return;

            _isVisibleChanging = true;
            Item.Visible = Visible;
            _isVisibleChanging = false;
        }
    }
}