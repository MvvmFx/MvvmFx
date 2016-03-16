using System;
using System.ComponentModel;
#if WEBGUI
using Gizmox.WebGUI.Forms;
#else
using System.Windows.Forms;
#endif

namespace MvvmFx.CaliburnMicro
{
    /// <summary>
    /// Proxy class for <see cref="ToolStripItem"/> components.
    /// </summary>
    [DefaultProperty("Name")]
    public class ToolStripItemProxy : Control
    {
        private bool _eventsWired;
        private bool _isEnabledChanging;
        private bool _isVisibleChanging;

        private readonly ToolStripItem _item;

        /// <summary>
        /// Gets the proxy item.
        /// </summary>
        /// <value>
        /// The proxy item.
        /// </value>
        public ToolStripItem Item
        {
            get { return _item; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolStripItemProxy" /> class, for the specified <see cref="ToolStripItem" />.
        /// </summary>
        /// <param name="item">The tool strip item.</param>
        /// <param name="parent">The parent Control.</param>
        /// <param name="wireEvents">if set to <c>true</c>, the constructor will wire the item events.</param>
        public ToolStripItemProxy(ToolStripItem item, Control parent, bool wireEvents)
        {
            Parent = parent;
            _item = item;
            Name = item.Name;
            Enabled = item.Enabled;
            Visible = item.Visible;
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

            EnabledChanged += ToolStripItemProxy_EnabledChanged;
            VisibleChanged += ToolStripItemProxy_VisibleChanged;
            _item.EnabledChanged += Item_EnabledChanged;
            _item.VisibleChanged += Item_VisibleChanged;
            _item.DoubleClick += item_DoubleClick;
            _item.Click += item_Click;
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

            _item.DoubleClick -= item_DoubleClick;
            _item.Click -= item_Click;
            _item.Disposed -= item_Disposed;
            _item.EnabledChanged -= Item_EnabledChanged;
            _item.VisibleChanged -= Item_VisibleChanged;
            EnabledChanged -= ToolStripItemProxy_EnabledChanged;
            VisibleChanged -= ToolStripItemProxy_VisibleChanged;

            _eventsWired = false;
        }

        private void item_Disposed(object sender, EventArgs e)
        {
            UnwireEvents();
            Dispose();
        }

        private void item_DoubleClick(object sender, EventArgs e)
        {
            OnDoubleClick(e);
        }

        private void item_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }

        private void Item_EnabledChanged(object sender, EventArgs e)
        {
            if (_isEnabledChanging)
                return;

            _isEnabledChanging = true;
            Enabled = _item.Enabled;
            _isEnabledChanging = false;
        }

        private void Item_VisibleChanged(object sender, EventArgs e)
        {
            if (_isVisibleChanging)
                return;

            _isVisibleChanging = true;
            Visible = _item.Visible;
            _isVisibleChanging = false;
        }

        private void ToolStripItemProxy_EnabledChanged(object sender, EventArgs e)
        {
            if (_isEnabledChanging)
                return;

            _isEnabledChanging = true;
            _item.Enabled = Enabled;
            _isEnabledChanging = false;
        }

        private void ToolStripItemProxy_VisibleChanged(object sender, EventArgs e)
        {
            if (_isVisibleChanging)
                return;

            _isVisibleChanging = true;
            _item.Visible = Visible;
            _isVisibleChanging = false;
        }
    }
}