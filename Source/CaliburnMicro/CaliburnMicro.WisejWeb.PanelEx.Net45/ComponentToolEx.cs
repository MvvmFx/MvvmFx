using System;
using System.ComponentModel;
using Wisej.Web;

namespace MvvmFx.CaliburnMicro.WisejWeb.PanelEx
{
    /// <summary>
    /// Extends the <see cref="Wisej.Web.ComponentTool"/> 
    /// to support the <see cref="ComponentToolEx.Click"/> event.
    /// </summary>
    [ToolboxItem(false)]
    [DefaultProperty("Name")]
    [DesignTimeVisible(false)]
    public class ComponentToolEx : Wisej.Web.ComponentTool
    {
        /*public ComponentToolEx()
        {
        }*/

        /// <summary>
        /// Gets or sets whether the <see cref="Click"/> event bubbles up.  
        /// <see cref="ComponentToolEx"/>.
        /// </summary>
        public bool ClickBubbling { get; set; } = false;

        /// <summary>
        /// Gets the  <see cref="Wisej.Web.Control"/> that owns the collection of this 
        /// <see cref="ComponentToolEx"/>.
        /// </summary>
        [Browsable(false)]
        public Panel Parent { get; internal set; }

        /// <summary>
        /// Fired when the ComponentTool is clicked.
        /// </summary>
        public event EventHandler Click;

        /// <summary>
        /// Fires the <see cref="Click" /> event.
        /// </summary>
        /// <param name="e">A <see cref="EventArgs" /> that contains the event data.</param>
        protected virtual void OnClick(EventArgs e)
        {
            if (this.Click != null)
                Click(this, e);
        }

        /// <summary>
        /// Generates the <see cref="Click"/> event.
        /// </summary>
        public virtual void PerformClick()
        {
            OnClick(EventArgs.Empty);
        }

        /*/// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }*/
    }
}