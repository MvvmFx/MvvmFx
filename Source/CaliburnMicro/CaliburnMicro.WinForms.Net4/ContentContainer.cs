using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
#if WEBGUI
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Design;
#else
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.Design;
#endif

namespace MvvmFx.CaliburnMicro
{
    /// <summary>
    /// A content container panel.
    /// </summary>
#if !WEBGUI
    [Docking(DockingBehavior.Ask)]
#endif
    [Designer(typeof (ContentControlDesigner), typeof (IDesigner))]
    [ToolboxBitmap(typeof (Panel))]
    public class ContentContainer : Panel
    {
        private object _viewModel;
        private Control _content;

        /// <summary>
        /// Occurs when the content changes.
        /// </summary>
        public event EventHandler ContentChanged;

        /// <summary>
        /// Gets or sets the control content.
        /// </summary>
        /// <value>
        /// The control content.
        /// </value>
        [Bindable(true), DefaultValue((object) null), Category("Data")]
        public object Content
        {
            get { return _content; }
            set
            {
                if (!ReferenceEquals(_viewModel, value))
                {
                    _viewModel = value;
                    var viewModel = value as IViewAware;

                    if (viewModel == null)
                    {
                        ResetContent();
                    }
                    else
                    {
                        var model = _viewModel as IHaveModel;

                        if (model == null || model.Model != null)
                        {
                            ViewModelBinder.Bind(viewModel, ViewLocator.LocateForModel(viewModel, null, null), null);
                            var control = viewModel.View as Control;
                            if (_content != control && control != null)
                            {
                                Controls.Clear();
                                _content = control;
                                Controls.Add(_content);
                                _content.Dock = DockStyle.Fill;

                                OnContentChanged(EventArgs.Empty);
                            }
                        }
                        else
                        {
                            ResetContent();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets the space, in pixels, that is specified by default between controls.
        /// </summary>
        protected new Padding DefaultMargin
        {
            get { return Padding.Empty; }
        }

        private void ResetContent()
        {
            Controls.Clear();
            _content = null;
            OnContentChanged(EventArgs.Empty);
        }

        /// <summary>
        /// Raises the <see cref="E:ContentChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void OnContentChanged(EventArgs e)
        {
            if (ContentChanged != null)
            {
                ContentChanged(this, e);
            }
        }

        private class ContentControlDesigner : ControlDesigner
        {
            private static readonly StringFormat StringFormat;

            static ContentControlDesigner()
            {
                StringFormat = new StringFormat
                {
                    LineAlignment = StringAlignment.Center,
                    Alignment = StringAlignment.Center
                };
            }

#if !WEBGUI
            /// <summary>
            /// Raises the <see cref="E:PaintAdornments" /> event.
            /// </summary>
            /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
            protected override void OnPaintAdornments(PaintEventArgs e)
            {
                using (var pen = new Pen(Control.ForeColor))
                {
                    pen.DashStyle = DashStyle.Dash;

                    var outline = new Rectangle(0, 0, Control.Width - 1, Control.Height - 1);
                    e.Graphics.DrawRectangle(pen, outline);
                }

                var rect = new RectangleF(0, 0, Control.Width, Control.Height);
                e.Graphics.DrawString(Control.Name, Control.Font, SystemBrushes.ControlText, rect, StringFormat);
            }

            /// <summary>
            /// Receives a call when a drag-and-drop operation is in progress to provide visual cues based on the location of the mouse while a drag operation is in progress.
            /// </summary>
            /// <param name="e">A <see cref="T:System.Windows.Forms.GiveFeedbackEventArgs" /> that provides data for the event.</param>
            protected override void OnGiveFeedback(GiveFeedbackEventArgs e)
            {
                base.OnGiveFeedback(new GiveFeedbackEventArgs(DragDropEffects.None, e.UseDefaultCursors));
            }

            /// <summary>
            /// Receives a call when a drag-and-drop object is dropped onto the control designer view.
            /// </summary>
            /// <param name="de">A <see cref="T:System.Windows.Forms.DragEventArgs" /> that provides data for the event.</param>
            protected override void OnDragDrop(DragEventArgs de)
            {
            }
#endif
        }
    }
}