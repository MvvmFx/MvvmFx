namespace MvvmFx.CaliburnMicro.ComponentProxy
{
    using System;
    using System.ComponentModel;
    using Wisej.Web;

    /// <summary>
    /// Proxy class for <see cref="StatusBarPanel"/> components.
    /// </summary>
    [DefaultProperty("Name")]
    public class StatusBarPanelProxy : Control
    {
        private bool _eventsWired;
        //private bool _isEnabledChanging;
        //private bool _isVisibleChanging;

        private readonly StatusBarPanel _item;

        /// <summary>
        /// Gets the proxy item.
        /// </summary>
        /// <value>
        /// The proxy item.
        /// </value>
        public StatusBarPanel Item
        {
            get { return _item; }
        }

        /// <summary>
        /// Returns a dynamic object that can be used to store custom data in relation to this control.
        /// </summary>
        public new dynamic UserData
        {
            get { return _item.UserData; }
        }

        private StatusBarPanelProxy()
        {
            // force to use parametrized constructor
        }

        protected override void Dispose(bool disposing)
        {
            UnwireEvents();
            /*for (var index = _item.Panels.Count - 1; index >= 0; index--)
            {
                _item.Panels[index].Dispose();
            }*/
            _item.Dispose();
            base.Dispose(disposing);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusBarPanelProxy" /> class, for the specified <see cref="StatusBarPanel" />.
        /// </summary>
        /// <param name="item">The tool strip item.</param>
        /// <param name="parent">The parent Control.</param>
        /// <param name="wireEvents">if set to <c>true</c>, the constructor will wire the item events.</param>
        public StatusBarPanelProxy(StatusBarPanel item, Control parent, bool wireEvents)
        {
            Parent = parent;
            _item = item;
            Name = item.Name;
            //Enabled = item.Enabled;
            //Visible = item.Visible;
            Tag = item.Tag;

            if (wireEvents)
                WireEvents();
        }

        /// <summary>
        /// Wires the events.
        /// </summary>
        public void WireEvents()
        {
            if (_eventsWired)
                return;

            //EnabledChanged += StatusBarPanelProxy_EnabledChanged;
            //VisibleChanged += StatusBarPanelProxy_VisibleChanged;
            //_item.Click += item_Click;
            _item.Disposed += item_Disposed;

            _eventsWired = true;
        }

        /// <summary>
        /// Unwires the events.
        /// </summary>
        public void UnwireEvents()
        {
            if (!_eventsWired)
                return;

            _item.Disposed -= item_Disposed;
            //_item.Click -= item_Click;
            //VisibleChanged -= StatusBarPanelProxy_VisibleChanged;
            //EnabledChanged -= StatusBarPanelProxy_EnabledChanged;

            _eventsWired = false;
        }

        private void item_Disposed(object sender, EventArgs e)
        {
            UnwireEvents();
            Dispose();
        }

        /*private void item_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }*/

        /*private void StatusBarPanelProxy_EnabledChanged(object sender, EventArgs e)
        {
            if (_isEnabledChanging)
                return;

            _isEnabledChanging = true;
            _item.Enabled = Enabled;
            _isEnabledChanging = false;
        }*/

        /*private void StatusBarPanelProxy_VisibleChanged(object sender, EventArgs e)
        {
            if (_isVisibleChanging)
                return;

            _isVisibleChanging = true;
            _item.Visible = Visible;
            _isVisibleChanging = false;
        }*/
    }
}