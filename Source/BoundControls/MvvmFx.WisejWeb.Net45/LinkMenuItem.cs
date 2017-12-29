using System.ComponentModel;
using Wisej.Web;

namespace MvvmFx.WisejWeb
{
    /// <summary>
    /// Data binding enabled LinkMenuItem.
    /// </summary>
    public class LinkMenuItem : Wisej.Web.LinkMenuItem, INamedBindable
    {
        #region IBindableComponent Members

        private BindingContext _bindingContext;
        private ControlBindingsCollection _dataBindings;

        /// <summary>Gets or sets the collection of currency managers for the <see cref="Wisej.Web.IBindableComponent" />. </summary>
        /// <returns>The collection of <see cref="Wisej.Web.BindingManagerBase" /> objects for this <see cref="Wisej.Web.IBindableComponent" />.</returns>
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

        /// <summary>Gets the collection of data-binding objects for this <see cref="Wisej.Web.IBindableComponent" />.</summary>
        /// <returns>The <see cref="Wisej.Web.ControlBindingsCollection" /> for this <see cref="Wisej.Web.IBindableComponent" />. </returns>
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

        /// <summary>Gets or sets the collection of currency managers for the <see cref="System.Windows.Forms.IBindableComponent" />. </summary>
        /// <returns>The collection of <see cref="System.Windows.Forms.BindingManagerBase" /> objects for this <see cref="System.Windows.Forms.IBindableComponent" />.</returns>
        System.Windows.Forms.BindingContext System.Windows.Forms.IBindableComponent.BindingContext
        {
            get { return BindingContext; }

            set { BindingContext = (BindingContext) value; }
        }

        /// <summary>Gets the collection of data-binding objects for this <see cref="System.Windows.Forms.IBindableComponent" />.</summary>
        /// <returns>The <see cref="System.Windows.Forms.ControlBindingsCollection" /> for this <see cref="System.Windows.Forms.IBindableComponent" />.</returns>
        System.Windows.Forms.ControlBindingsCollection System.Windows.Forms.IBindableComponent.DataBindings
        {
            get { return DataBindings; }
        }

        #endregion
    }
}