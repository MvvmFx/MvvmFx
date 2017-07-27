using System.ComponentModel;
#if WISEJ
using Wisej.Web;
#else
using System.Windows.Forms;
#endif

namespace MvvmFx.Windows.Forms
{
    /// <summary>
    /// Data binding enabled ToolStripSplitButton.
    /// </summary>
    public class ToolStripSplitButton : System.Windows.Forms.ToolStripSplitButton, IBindableComponent, IHaveName
    {
        #region IBindableComponent Members

        private BindingContext _bindingContext;
        private ControlBindingsCollection _dataBindings;

        /// <summary>Gets or sets the collection of currency managers for the <see cref="System.Windows.Forms.IBindableComponent" />. </summary>
        /// <returns>The collection of <see cref="System.Windows.Forms.BindingManagerBase" /> objects for this <see cref="System.Windows.Forms.IBindableComponent" />.</returns>
        /// <filterpriority>1</filterpriority>
        [Browsable(false)]
        public BindingContext BindingContext
        {
            get
            {
                if (_bindingContext == null)
                {
                    _bindingContext = new BindingContext();
                }
                return _bindingContext;
            }
            set { _bindingContext = value; }
        }

        /// <summary>Gets the collection of data-binding objects for this <see cref="System.Windows.Forms.IBindableComponent" />.</summary>
        /// <returns>The <see cref="System.Windows.Forms.ControlBindingsCollection" /> for this <see cref="System.Windows.Forms.IBindableComponent" />. </returns>
        /// <filterpriority>1</filterpriority>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlBindingsCollection DataBindings
        {
            get
            {
                if (_dataBindings == null)
                {
                    _dataBindings = new ControlBindingsCollection(this);
                }
                return _dataBindings;
            }
        }

        #endregion
    }
}