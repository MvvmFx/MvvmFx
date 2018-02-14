/********************************************************************
    created:    2005/03/27
    created:    27:3:2005   7:05
    filename:   FieldTypeEditor.cs
    author:     Mike Chaliy

    purpose:    Data members fields editor.

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

using System.ComponentModel;
using System.Windows.Forms;

namespace MvvmFx.Controls.WisejWeb.Design
{
    /// <summary>
    /// Data members fields editor.
    /// </summary>
    public class FieldTypeEditor : DropDownTypeEditor
    {

        /// <summary>
        /// Fill list box with fileds of the current datasource.
        /// </summary>
        /// <param name="listBox">ListBox control to fill.</param>
        /// <param name="context">Type descriptor context.</param>
        /// <param name="value">Current value.</param>
        protected override void FillListBox(ListBox listBox, ITypeDescriptorContext context, object value)
        {
            var selectedField = (string) value;
            if (selectedField == null)
                selectedField = string.Empty;

            var dataSourceDescriptor = TypeDescriptor.GetProperties(context.Instance)["DataSource"];
            if (dataSourceDescriptor == null)
            {
                return;
            }
            var dataSource = dataSourceDescriptor.GetValue(context.Instance);
            if (dataSource != null)
            {
                var currencyManager = new BindingContext()[dataSource] as CurrencyManager;
                if (currencyManager != null)
                {
                    foreach (PropertyDescriptor descriptor in currencyManager.GetItemProperties())
                    {
                        int lastIndex = listBox.Items.Add(descriptor.Name);
                        if (string.Compare(descriptor.Name, selectedField) == 0)
                        {
                            listBox.SelectedIndex = lastIndex;
                        }
                    }
                }
            }
        }
    }
}