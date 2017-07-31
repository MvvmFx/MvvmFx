/********************************************************************
    created:	2005/03/27
    created:	27:3:2005   7:05
    filename: 	DropDownTypeEditor.cs
    author:		Mike Chaliy

    purpose:	Base class for simple drop down type editors.

The MIT License (MIT)

Copyright (c) 2005 Mike Chaliy

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*********************************************************************/

using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace MvvmFx.Windows.Forms.Design
{
    /// <summary>
    /// Base class for simple drop down type editors.
    /// </summary>
    public abstract class DropDownTypeEditor : UITypeEditor
    {
        #region Fields

        private IWindowsFormsEditorService _editorService;

        #endregion

        #region Events

        private void ListBox_SelectedIndexChanged(object objSender, EventArgs eventArgs)
        {
            if (_editorService != null)
            {
                _editorService.CloseDropDown();
            }
        }

        #endregion

        #region Implemenatation

        /// <summary>
        /// Overrides to set editor style in DropDown.
        /// </summary>
        /// <param name="context">Type descriptor context.</param>
        /// <returns>Style of the editor.</returns>
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            if (context != null && context.Instance != null)
            {
                return UITypeEditorEditStyle.DropDown;
            }
            return base.GetEditStyle(context);
        }


        /// <summary>
        /// Edits the specified object's value using the editor style indicated by the <see cref="M:System.Drawing.Design.UITypeEditor.GetEditStyle" /> method.
        /// </summary>
        /// <param name="context">An <see cref="System.ComponentModel.ITypeDescriptorContext" /> that can be used to gain additional context information.</param>
        /// <param name="provider">An <see cref="System.IServiceProvider" /> that this editor can use to obtain services.</param>
        /// <param name="value">The object to edit.</param>
        /// <returns>
        /// The new value of the object. If the value of the object has not changed, this should return the same object it was passed.
        /// </returns>
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (context != null && context.Instance != null && context.Container != null && provider != null)
            {
                _editorService = provider.GetService(typeof (IWindowsFormsEditorService)) as IWindowsFormsEditorService;
                if (_editorService != null)
                {
                    using (var listBox = new ListBox())
                    {
                        listBox.BorderStyle = BorderStyle.None;

                        FillListBox(listBox, context, value);
                        listBox.SelectedIndexChanged += ListBox_SelectedIndexChanged;

                        _editorService.DropDownControl(listBox);

                        if (listBox.SelectedItem != null)
                        {
                            value = GetValueFromListItem(context, listBox.SelectedItem);
                        }
                        listBox.SelectedIndexChanged -= ListBox_SelectedIndexChanged;
                    }
                    _editorService = null;
                }
            }
            return value;
        }

        /// <summary>
        /// Implement this to fill listBox.Items.
        /// </summary>
        /// <param name="listBox">ListBox control to fill.</param>
        /// <param name="context">Type descriptor context.</param>
        /// <param name="value">Current value.</param>
        protected abstract void FillListBox(ListBox listBox, ITypeDescriptorContext context, object value);

        /// <summary>
        /// Override this to change output value.
        /// </summary>
        /// <param name="context">Type descriptor context.</param>
        /// <param name="value">Value to change.</param>
        /// <returns>Changed value.</returns>
        protected virtual object GetValueFromListItem(ITypeDescriptorContext context, object value)
        {
            return value;
        }

        #endregion
    }
}