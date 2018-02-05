using System.ComponentModel;
using System.Drawing;
using Wisej.Web;

namespace MvvmFx.WisejWeb.PanelEx
{
    /// <summary>
    /// Extends Panel so ComponentTool items raises their individual click event.
    /// </summary>
    /// <seealso cref="Wisej.Web.Panel" />
    [ToolboxItem(false)]
    //[ToolboxItem(true)]
    [DefaultEvent("Load")]
    //[ToolboxBitmap(typeof(Panel))]
    [Description("Extends Panel so ComponentTool items raises their individual click event.")]
    public class PanelEx : Panel
    {
        // TODO Setting the parent should be done on the Add/AddRange of the ComponentToolCollection

        /// <summary>
        /// Initializes a new instance of the <see cref="PanelEx" /> class.
        /// </summary>
        public PanelEx()
        {
            ToolClick += PanelExToolClick;
        }

        private void PanelExToolClick(object sender, ToolClickEventArgs e)
        {
            var toolEx = e.Tool as ComponentToolEx;
            if (toolEx != null)
            {
                toolEx.PerformClick();

                // there's no Cancel :(
                // e.Cancel = !toolEx.ClickBubbling;
            }
        }
    }
}