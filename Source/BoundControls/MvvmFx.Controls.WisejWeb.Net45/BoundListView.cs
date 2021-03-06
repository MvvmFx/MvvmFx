using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
#if WISEJ
using Wisej.Web;
using MvvmFx.Controls.WisejWeb.Properties;
#else
using System.Windows.Forms;
using MvvmFx.Controls.WinForms.Properties;
#endif

// code from Sascha Knopf
// http://www.codeproject.com/Articles/15396/Implementing-complex-data-binding-in-custom-contro

// Improvements by Tiago Freitas Leal (MvvmFx project).

namespace MvvmFx.Controls.WisejWeb
{
    /// <summary>
    /// Data binding enabled list view control.
    /// </summary>
    [Description("Data binding enabled list view control.")]
    [ComplexBindingProperties("DataSource", "DataMember")]
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof (BoundListView), "BoundListView.bmp")]
    public class BoundListView : ListView
    {
        #region Fields

        private bool _isHandlingPositionChange;

        private readonly Container _components = null;
        private readonly ListChangedEventHandler _listChangedHandler;
        private readonly EventHandler _positionChangedHandler;
        private CurrencyManager _listManager;

        private object _dataSource;
        private string _dataMember;
        #endregion

        #region Properties

#if WINFORMS
        /// <summary>
        /// Gets or sets the data source for this <see cref="MvvmFx.Controls.WinForms.BoundListView"/>.
        /// </summary>
        /// <returns>
        /// An object that implements the <see cref="System.Collections.IList"/> or
        /// <see cref="System.ComponentModel.IListSource"/> interfaces,
        /// such as a <see cref="System.Data.DataSet"/> or an <see cref="System.Array"/>. The default is null.
        /// </returns>>
#else
        /// <summary>
        /// Gets or sets the data source for this <see cref="MvvmFx.Controls.WisejWeb.BoundListView"/>.
        /// </summary>
        /// <returns>
        /// An object that implements the <see cref="System.Collections.IList"/> or
        /// <see cref="System.ComponentModel.IListSource"/> interfaces,
        /// such as a <see cref="System.Data.DataSet"/> or an <see cref="System.Array"/>. The default is null.
        /// </returns>>
#endif
        /*[Bindable(true, BindingDirection.TwoWay)] do not uncomment*/
        [AttributeProvider(typeof (IListSource))]
        [DefaultValue((string) null)]
        [Editor("System.Windows.Forms.Design.DataSourceListEditor, System.Design", typeof (UITypeEditor))]
        [TypeConverter("System.Windows.Forms.Design.DataSourceConverter, System.Design")]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Category("Data")]
        [Description("Indicates the list that this control will use to get its items.")]
        public object DataSource
        {
            get { return _dataSource; }
            set
            {
                if (_dataSource != value)
                {
                    _dataSource = value;
                    TryDataBinding();
                }
            }
        }

#if WINFORMS
        /// <summary>
        /// Gets or sets the name of the list or table in the data source for which
        /// the <see cref="MvvmFx.Controls.WinForms.BoundListView"/> is displaying data.
        /// </summary>
        /// <returns>
        /// The name of the table or list in the <see cref="MvvmFx.Controls.WinForms.BoundListView.DataSource"/> for which the
        /// <see cref="MvvmFx.Controls.WinForms.BoundListView"/> is displaying data. The default is <see cref="System.String.Empty"/>.
        /// </returns>
        /// <exception cref="System.Exception">
        /// An error occurred in the data source and either there is no handler for the <see cref="System.Windows.Forms.DataGridView.DataError"/>
        /// event or the handler has set the <see cref="System.Windows.Forms.DataGridViewDataErrorEventArgs.ThrowException"/> property to true.
        /// The exception object can typically be cast to type <see cref="System.FormatException"/>.
        /// </exception>
#else
        /// <summary>
        /// Gets or sets the name of the list or table in the data source for which
        /// the <see cref="MvvmFx.Controls.WisejWeb.BoundListView"/> is displaying data.
        /// </summary>
        /// <returns>
        /// The name of the table or list in the <see cref="MvvmFx.Controls.WisejWeb.BoundListView.DataSource"/> for which the
        /// <see cref="MvvmFx.Controls.WisejWeb.BoundListView"/> is displaying data. The default is <see cref="System.String.Empty"/>.
        /// </returns>
        /// <exception cref="System.Exception">
        /// An error occurred in the data source and either there is no handler for the <see cref="Wisej.Web.DataGridView.DataError"/>
        /// event or the handler has set the <see cref="Wisej.Web.DataGridViewDataErrorEventArgs.ThrowException"/> property to true.
        /// The exception object can typically be cast to type <see cref="System.FormatException"/>.
        /// </exception>
#endif
        /*[Bindable(true, BindingDirection.TwoWay)] do not uncomment*/
        [DefaultValue(null)]
        [Editor("System.Windows.Forms.Design.DataMemberListEditor, System.Design", typeof (UITypeEditor))]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Category("Data")]
        [Description("Indicates a sub-list of the DataSource to show in the BoundListView control.")]
        public string DataMember
        {
            get { return _dataMember; }
            set
            {
                if (_dataMember != value)
                {
                    _dataMember = value;
                    TryDataBinding();
                }
            }
        }

        /// <summary>
        /// Gets the selected item.
        /// </summary>
        /// <value>
        /// The selected item.
        /// </value>
        [Browsable(false)]
        [Bindable(false)]
        [DefaultValue(null)]
        public object SelectedItem
        {
            get { return _listManager.Current; }
        }

        #endregion

        #region Constructor & Dispose

        /// <summary>
        /// Initializes a new instance of the <see cref="BoundListView"/> class.
        /// </summary>
        public BoundListView()
        {
            _listChangedHandler = ListManager_ListChanged;
            _positionChangedHandler = ListManager_PositionChanged;

            View = View.Details;
#if WINFORMS
            FullRowSelect = true;
            HideSelection = false;
#endif
            MultiSelect = false;
            LabelEdit = true;
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_components != null)
                    _components.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion

        #region TryDataBinding

        /// <summary>
        /// Tries to get a new CurrencyManager for new DataBinding
        /// </summary>
        private void TryDataBinding()
        {
            if (DataSource == null ||
                BindingContext == null)
                return;

            CurrencyManager currencyManager;
            try
            {
                currencyManager = (CurrencyManager) BindingContext[_dataSource, _dataMember];
            }
            catch (ArgumentException)
            {
                // If no CurrencyManager was found
                return;
            }

            BeginUpdate();

            // Unwire the old CurrencyManager
            if (_listManager != null)
            {
                _listManager.ListChanged -= _listChangedHandler;
                _listManager.PositionChanged -= _positionChangedHandler;
            }
            _listManager = currencyManager;

            // Update metadata and data
            CalculateColumns();
            UpdateAllData();

            // Wire the new CurrencyManager
            if (_listManager != null)
            {
                _listManager.ListChanged += _listChangedHandler;
                _listManager.PositionChanged += _positionChangedHandler;
            }

            EndUpdate();
        }

        #endregion

        #region Item Methods

        /// <summary>
        /// Updates all Items.
        /// </summary>
        private void UpdateAllData()
        {
            Items.Clear();
            for (var index = 0; index < _listManager.Count; index++)
            {
                AddItem(index);
            }

            if (_listManager.Position > -1)
            {
                for (var index = 0; index < Items.Count; index++)
                {
                    if (Items[index].Tag == _listManager.List[_listManager.Position])
                    {
                        Items[index].Selected = true;
                        EnsureVisible(index);
                    }
                    else
                        Items[index].Selected = false;
                }
            }
        }

        /// <summary>
        /// Adds a new item.
        /// </summary>
        /// <param name="index">The index of the item.</param>
        private void AddItem(int index)
        {
            var item = GetListViewItem(index);
            Items.Insert(index, item);
        }

        /// <summary>
        /// Updates the data of the item with the DataSource.
        /// </summary>
        /// <param name="index">The index of the item.</param>
        private void UpdateItem(int index)
        {
            if (index >= 0 &&
                index < Items.Count)
            {
                var item = GetListViewItem(index);
                Items[index] = item;
            }
        }

        /// <summary>
        /// Returns a <see cref="ListViewItem"/> wich contains the row-data at given index.
        /// </summary>
        /// <param name="index">The index of the row.</param>
        /// <returns>A item wich contains the data.</returns>
        private ListViewItem GetListViewItem(int index)
        {
            var row = _listManager.List[index];
            var propColl = _listManager.GetItemProperties();
            var items = new ArrayList();

            // Fill value for each column
            foreach (ColumnHeader column in Columns)
            {
                var prop = propColl.Find(column.Name, false);
                if (prop != null)
                {
                    var value = prop.GetValue(row);
                    if (value != null)
                        items.Add(value.ToString());
                    else
                        items.Add(string.Empty);
                }
            }
            var item = new ListViewItem((string[]) items.ToArray(typeof (string)));
            item.Tag = row;
            return item;
        }

        /// <summary>
        /// Delete the item at the given index.
        /// </summary>
        /// <param name="index">The index of the item.</param>
        private void DeleteItem(int index)
        {
            if (index >= 0 &&
                index < Items.Count)
                Items.RemoveAt(index);
        }

        /// <summary>
        /// Calculates the Colums of the <see cref="BoundListView"/>.
        /// </summary>
        private void CalculateColumns()
        {
            if (_listManager == null)
                return;

            if (Columns.Count == 0)
            {
                foreach (PropertyDescriptor prop in _listManager.GetItemProperties())
                {
                    var column = new ColumnHeader {Text = prop.Name, Name = prop.Name};
                    Columns.Add(column);
                }
            }
        }

        #endregion

        #region BindingContext Events

#if WINFORMS
        /// <summary>
        /// Raises the <see cref="System.Windows.Forms.Control.BindingContextChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="System.EventArgs"/> that contains the event data. </param>
#else
        /// <summary>
        /// Raises the <see cref="Wisej.Base.ControlBase.BindingContextChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="System.EventArgs"/> that contains the event data. </param>
#endif
        protected override void OnBindingContextChanged(EventArgs e)
        {
            TryDataBinding();
            base.OnBindingContextChanged(e);
        }

        #endregion

        #region Position changed from DataSource

        private void ListManager_PositionChanged(object sender, EventArgs e)
        {
            if (_isHandlingPositionChange)
                return;

            _isHandlingPositionChange = true;

            if (Items.Count > _listManager.Position)
            {
                for (var index = 0; index < Items.Count; index++)
                {
                    if (Items[index].Tag == _listManager.List[_listManager.Position])
                    {
                        Items[index].Selected = true;
                        EnsureVisible(index);
                    }
                    else
                        Items[index].Selected = false;
                }
            }

            _isHandlingPositionChange = false;
        }

        #endregion

        #region Item(s) changed from DataSource

        private void ListManager_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.Reset ||
                e.ListChangedType == ListChangedType.ItemMoved)
            {
                // Update all data
                UpdateAllData();
            }
            else if (e.ListChangedType == ListChangedType.ItemAdded)
            {
                // Add new Item
                AddItem(e.NewIndex);
            }
            else if (e.ListChangedType == ListChangedType.ItemChanged)
            {
                // Change Item
                UpdateItem(e.NewIndex);
            }
            else if (e.ListChangedType == ListChangedType.ItemDeleted)
            {
                // Delete Item
                DeleteItem(e.NewIndex);
            }
            else
            {
                // Update metadata and all data
                CalculateColumns();
            }
        }

        #endregion

        #region Position changed from ListView

#if !WEBGUI

        /// <summary>
        /// Raises the <see cref="System.Windows.Forms.ListView.SelectedIndexChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="System.EventArgs" /> that contains the event data.</param>
        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            if (_isHandlingPositionChange)
                return;

            _isHandlingPositionChange = true;

            try
            {
                if (SelectedIndices.Count > 0)
                {
                    var selectedIndex = SelectedIndices[0];

                    for (var index = 0; index < Items.Count; index++)
                    {
                        if (Items[selectedIndex].Tag == _listManager.List[index])
                        {
                            _listManager.Position = index;
                            break;
                        }
                    }
                }
            }
            catch
            {
                // Could happen, if you change the position while someone edits a row with invalid data.
            }

            _isHandlingPositionChange = false;
            base.OnSelectedIndexChanged(e);
        }

#else

        /// <summary>
        /// Raises the <see cref="SelectedIndexChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            try
            {
                if (SelectedIndices.Count > 0 && _listManager.Position != SelectedIndex)
                    _listManager.Position = SelectedIndex;
            }
            catch
            {
                // Could appear, if you change the position while someone edits a row with invalid data.
            }
            base.OnSelectedIndexChanged(e);
        }

        /// <summary>
        /// Raises the <see cref="Click" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected override void OnClick(EventArgs e)
        {
            try
            {
                _listManager.Position = SelectedIndex;
            }
            catch
            {
                // Could appear, if you change the position while someone edits a row with invalid data.
            }
            base.OnClick(e);
        }

#endif

        #endregion

        #region Item changed from ListView

#if WINFORMS
        /// <summary>
        /// Raises the <see cref="System.Windows.Forms.ListView.AfterLabelEdit" /> event.
        /// </summary>
        /// <param name="e">A <see cref="System.Windows.Forms.LabelEditEventArgs" /> that contains the event data.</param>
#else
        /// <summary>
        /// Raises the <see cref="Wisej.Web.ListView.AfterLabelEdit"></see> event.
        /// </summary>
        /// <param name="e">A <see cref="Wisej.Web.LabelEditEventArgs"></see> that contains the event data.</param>
#endif
        protected override void OnAfterLabelEdit(LabelEditEventArgs e)
        {
            if (e.Label == null)
            {
                // If you press ESC while editing.
                e.CancelEdit = true;
                return;
            }

#if WINFORMS
            var index = e.Item;
#else
            var index = e.Item.Index;
#endif

            if (_listManager.List.Count > index)
            {
                var row = _listManager.List[index];
                // In a ListView you are only able to edit the first Column.
                var col = _listManager.GetItemProperties().Find(Columns[0].Text, false);
                try
                {
                    if (row != null && col != null)
                        col.SetValue(row, e.Label);
                    _listManager.EndCurrentEdit();
                    base.OnAfterLabelEdit(e);
                }
                catch (Exception ex)
                {
                    // If you try to enter strings in number-columns, too long strings or something
                    // else wich is not allowed by the DataSource.
                    MessageBox.Show(Resources.EditFailed + ": " + ex.Message, Resources.EditFailed, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _listManager.CancelCurrentEdit();
                    e.CancelEdit = true;
                }
            }
        }

        #endregion
    }
}