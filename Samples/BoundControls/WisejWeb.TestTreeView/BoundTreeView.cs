﻿/********************************************************************
    created:    2005/03/27
    created:    27:3:2005   7:05
    filename:   BoundTreeView.cs
    author:     Mike Chaliy
    published:  http://www.codeproject.com/Articles/9949/Hierarchical-TreeView-control-with-data-binding-en

    purpose:    Data binding enabled hierarchical tree view control.

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
/*

Improvements by Tiago Freitas Leal (MvvmFx project).

*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using MvvmFx.Logging;
#if WISEJ
using Wisej.Web;
using MvvmFx.Controls.WisejWeb.Design;
using WisejWeb.TestTreeView.Properties;
using LogManager = WisejWeb.TestTreeView.LogManager;
using TreeViewImageIndexConverter = System.Windows.Forms.TreeViewImageIndexConverter;
using TreeViewImageKeyConverter = System.Windows.Forms.TreeViewImageKeyConverter;
#else
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MvvmFx.Controls.WinForms.Design;
using WinForms.TestTreeView.Properties;
using LogManager = WinForms.TestTreeView.LogManager;
#endif

namespace MvvmFx.Controls.WisejWeb
{
    /// <summary>
    /// Data binding enabled hierarchical tree view control.
    /// </summary>
    [Description("Data binding enabled hierarchical tree view control.")]
    [ComplexBindingProperties("DataSource", "DataMember")]
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(BoundTreeView), "BoundTreeView.bmp")]
    public class BoundTreeView : TreeView
    {
        #region Fields

#if WINFORMS
        private const int SbHorz = 0;
        private bool _ignoreBindingContextChanged;
#endif
        private bool _isDraggingOver;
        private bool _isDroppingOnRoot;

        private readonly Container _components = null;
        private readonly ListChangedEventHandler _listChangedHandler;
        private readonly EventHandler _positionChangedHandler;
        private CurrencyManager _listManager;

        private object _dataSource;
        private string _dataMember;
        private string _displayMember;
        private string _valueMember;
        private string _identifierMember;
        private string _parentIdentifierMember;
        private string _readOnlyMember;
        private string _toolTipTextMember;

        private PropertyDescriptor _identifierProperty;
        private PropertyDescriptor _displayProperty;
        private PropertyDescriptor _parentIdentifierProperty;
        private PropertyDescriptor _valueProperty;
        private PropertyDescriptor _readOnlyProperty;
        private PropertyDescriptor _toolTipTextProperty;

        private TypeConverter _valueConverter;

        private readonly SortedList _itemsPositions;
        private readonly SortedList _itemsIdentifiers;

        private string _readOnlyImageKey;
        private int _readOnlyImageIndex;
        private string _readOnlySelectedImageKey;
        private int _readOnlySelectedImageIndex;
#if WISEJ
        private string _readOnlyOpenedImageKey;
        private int _readOnlyOpenedImageIndex;
#endif
        private bool _allowDropOnRoot = true;
        private bool _allowDropOnDescendent = true;
        private bool _selectingNode;

        #endregion

        #region Log & Messages

        /// <summary>
        /// The logger
        /// </summary>
        private static readonly ILog Logger = LogManager.GetLog(typeof(BoundTreeView));
        //private static readonly ILog Logger = new NullLogger();

        /// <summary>
        /// Gets or sets the duplicated caption for the MessageBox.
        /// </summary>
        [DefaultValue("")]
        [Category("Messages")]
        [Localizable(true)]
        [Description("Specifies the duplicated caption for the MessageBox.")]
        public string DuplicatedCaption { get; set; }

        /// <summary>
        /// Gets or sets the duplicated message for the MessageBox.
        /// </summary>
        [DefaultValue("")]
        [Category("Messages")]
        [Localizable(true)]
        [Description("Specifies the duplicated message for the MessageBox.")]
        public string DuplicatedMessage { get; set; }

        /// <summary>
        /// Gets or sets the self parent  message for the node ToolTip.
        /// </summary>
        [DefaultValue("")]
        [Category("Messages")]
        [Localizable(true)]
        [Description("Specifies the self parent message for the node ToolTip.")]
        public string SelfParent { get; set; }

        /// <summary>
        /// Gets or sets the inexistent parent message for the node ToolTip.
        /// </summary>
        [DefaultValue("")]
        [Category("Messages")]
        [Localizable(true)]
        [Description("Specifies the inexistent parent message for the node ToolTip.")]
        public string InexistentParent { get; set; }

        /// <summary>
        /// Gets or sets the general node error message for the node ToolTip.
        /// </summary>
        [DefaultValue("")]
        [Category("Messages")]
        [Localizable(true)]
        [Description("Specifies the general node error message for the node ToolTip.")]
        public string GeneralNodeError { get; set; }

        #endregion

        #region Properties

#if WINFORMS
        /// <summary>
        /// Gets or sets the data source for this <see cref="MvvmFx.Controls.WinForms.BoundTreeView"/>.
        /// </summary>
        /// <returns>
        /// An object that implements the <see cref="System.Collections.IList"/> or
        /// <see cref="System.ComponentModel.IListSource"/> interfaces. The default is null.
        /// </returns>
#else
        /// <summary>
        /// Gets or sets the data source for this <see cref="MvvmFx.Controls.WisejWeb.BoundTreeView"/>.
        /// </summary>
        /// <returns>
        /// An object that implements the <see cref="System.Collections.IList"/> or
        /// <see cref="System.ComponentModel.IListSource"/> interfaces. The default is null.
        /// </returns>
#endif
        /*[Bindable(true, BindingDirection.TwoWay)] do not uncomment*/
        [AttributeProvider(typeof(IListSource))]
        [DefaultValue(null)]
        [Editor("System.Windows.Forms.Design.DataSourceListEditor, System.Design", typeof(UITypeEditor))]
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
                    Logger.Trace("DataSource");
                    TryDataBinding();
                }
            }
        }

#if WINFORMS
        /// <summary>
        /// Gets or sets the name of the list or table in the data source for which
        /// the <see cref="MvvmFx.Controls.WinForms.BoundTreeView"/> is displaying data.
        /// </summary>
        /// <returns>
        /// The name of the table or list in the <see cref="MvvmFx.Controls.WinForms.BoundTreeView.DataSource"/> for which the
        /// <see cref="MvvmFx.Controls.WinForms.BoundTreeView"/> is displaying data. The default is <see cref="System.String.Empty"/>.
        /// </returns>
#else
        /// <summary>
        /// Gets or sets the name of the list or table in the data source for which
        /// the <see cref="MvvmFx.Controls.WisejWeb.BoundTreeView"/> is displaying data.
        /// </summary>
        /// <returns>
        /// The name of the table or list in the <see cref="MvvmFx.Controls.WisejWeb.BoundTreeView.DataSource"/> for which the
        /// <see cref="MvvmFx.Controls.WisejWeb.BoundTreeView"/> is displaying data. The default is <see cref="System.String.Empty"/>.
        /// </returns>
#endif
        /*[Bindable(true, BindingDirection.TwoWay)] do not uncomment*/
        [DefaultValue(null)]
        [Editor("System.Windows.Forms.Design.DataMemberListEditor, System.Design", typeof(UITypeEditor))]
        [TypeConverter("System.Windows.Forms.Design.DataMemberConverter, System.Design")]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Category("Data")]
        [Description("Indicates a sub-list of the DataSource to show in the BoundTreeView control.")]
        public string DataMember
        {
            get { return _dataMember; }
            set
            {
                if (_dataMember != value)
                {
                    _dataMember = value;
                    Logger.Trace("DataMember");
                    TryDataBinding();
                }
            }
        }

#if WINFORMS
        /// <summary>
        /// Gets or sets the property to display for this <see cref="MvvmFx.Controls.WinForms.BoundTreeView"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> specifying the name of an object property that is contained in the collection specified
        /// by the <see cref="System.Windows.Forms.ListControl.DataSource"/> property. The default is an empty string ("").
        /// </returns>
        /// <remarks>Editing of this member is available only for types that support converting from string.</remarks>
#else
        /// <summary>
        /// Gets or sets the property to display for this <see cref="MvvmFx.Controls.WisejWeb.BoundTreeView"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> specifying the name of an object property that is contained in the collection specified
        /// by the <see cref="Wisej.Web.ListControl.DataSource"/> property. The default is an empty string ("").
        /// </returns>
        /// <remarks>Editing of this member is available only for types that support converting from string.</remarks>
#endif
        /*[Bindable(true, BindingDirection.TwoWay)] do not uncomment*/
        [DefaultValue("")]
        [Editor(typeof(FieldTypeEditor), typeof(UITypeEditor))]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Category("Data")]
        [Description("Indicates the property to display for the items of this control.")]
        public string DisplayMember
        {
            get { return _displayMember; }
            set
            {
                if (_displayMember != value)
                {
                    _displayMember = value;
                    _displayProperty = null;
                    Logger.Trace("DisplayMember");
                    TryDataBinding();
                }
            }
        }

#if WINFORMS
        /// <summary>
        /// Gets or sets the property to use as the actual value for the items in the <see cref="MvvmFx.Controls.WinForms.BoundTreeView"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> representing the name of an object property that is contained in the collection specified
        /// by the <see cref="System.Windows.Forms.ListControl.DataSource"/> property. The default is an empty string ("").
        /// </returns>
#else
        /// <summary>
        /// Gets or sets the property to use as the actual value for the items in the <see cref="MvvmFx.Controls.WisejWeb.BoundTreeView"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> representing the name of an object property that is contained in the collection specified
        /// by the <see cref="Wisej.Web.ListControl.DataSource"/> property. The default is an empty string ("").
        /// </returns>
#endif
        /*[Bindable(true, BindingDirection.TwoWay)] do not uncomment*/
        [DefaultValue(null)]
        [Editor(typeof(FieldTypeEditor), typeof(UITypeEditor))]
        [Category("Data")]
        [Description("Indicates the property to use as the actual value for the items of the control.")]
        public string ValueMember
        {
            get { return _valueMember; }
            set
            {
                if (_valueMember != value)
                {
                    _valueMember = value;
                    _valueProperty = null;
                    _valueConverter = null;
                    Logger.Trace("ValueMember");
                    TryDataBinding();
                }
            }
        }

        /// <summary>
        /// Gets or sets the unique identifier member.
        /// </summary>
        /// <returns>
        /// The identifier member.
        /// </returns>
        /*[Bindable(true, BindingDirection.TwoWay)] do not uncomment*/
        [DefaultValue("")]
        [Editor(typeof(FieldTypeEditor), typeof(UITypeEditor))]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Category("Data")]
        [Description("Indicates the property to use as the unique identifier for the items of the control.")]
        public string IdentifierMember
        {
            get { return _identifierMember; }
            set
            {
                if (_identifierMember != value)
                {
                    _identifierMember = value;
                    _identifierProperty = null;

                    if (string.IsNullOrEmpty(_valueMember))
                        ValueMember = _identifierMember;

                    Logger.Trace("IdentifierMember");
                    TryDataBinding();
                }
            }
        }

        /// <summary>
        /// Gets or sets the parent identifier member.
        /// </summary>
        /// <returns>
        /// The parent identifier member.
        /// </returns>
        /*[Bindable(true, BindingDirection.TwoWay)] do not uncomment*/
        [DefaultValue("")]
        [Editor(typeof(FieldTypeEditor), typeof(UITypeEditor))]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Category("Data")]
        [Description("Indicates the property to use as the parent identifier for the items of the control.")]
        public string ParentIdentifierMember
        {
            get { return _parentIdentifierMember; }
            set
            {
                if (_parentIdentifierMember != value)
                {
                    _parentIdentifierMember = value;
                    _parentIdentifierProperty = null;
                    Logger.Trace("ParentIdentifierMember");
                    TryDataBinding();
                }
            }
        }

        /// <summary>
        /// Gets or sets the ToolTipText member.
        /// </summary>
        /// <returns>
        /// The ToolTipText member.
        /// </returns>
        /*[Bindable(true, BindingDirection.TwoWay)] do not uncomment*/
        [DefaultValue(null)]
        [Editor(typeof(FieldTypeEditor), typeof(UITypeEditor))]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Category("Data")]
        [Description("Indicates the property to use as the ToolTipText member for the items of the control.")]
        public string ToolTipTextMember
        {
            get { return _toolTipTextMember; }
            set
            {
                if (_toolTipTextMember != value)
                {
                    _toolTipTextMember = value;
                    _toolTipTextProperty = null;
                    Logger.Trace("ToolTipTextMember");
                    TryDataBinding();
                }
            }
        }

        /// <summary>
        /// Gets or sets the ReadOnly member.
        /// </summary>
        /// <returns>
        /// The ReadOnly member.
        /// </returns>
        /*[Bindable(true, BindingDirection.TwoWay)] do not uncomment*/
        [DefaultValue(null)]
        [Editor(typeof(FieldTypeEditor), typeof(UITypeEditor))]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Category("Data")]
        [Description("Indicates the property to use as the ReadOnly member for the items of the control.")]
        public string ReadOnlyMember
        {
            get { return _readOnlyMember; }
            set
            {
                if (_readOnlyMember != value)
                {
                    _readOnlyMember = value;
                    _readOnlyProperty = null;
                    Logger.Trace("ReadOnlyMember");
                    TryDataBinding();
                }
            }
        }

#if WINFORMS
        /// <summary>
        /// Gets the value of the member property specified by the <see cref="MvvmFx.Controls.WinForms.BoundTreeView.ValueMember"/> property.
        /// </summary>
        /// <returns>
        /// An object containing the value of the member of the data source specified
        /// by the <see cref="MvvmFx.Controls.WinForms.BoundTreeView.ValueMember"/> property.
        /// </returns>
#else
        /// <summary>
        /// Gets the value of the member property specified by the <see cref="MvvmFx.Controls.WisejWeb.BoundTreeView.ValueMember"/> property.
        /// </summary>
        /// <returns>
        /// An object containing the value of the member of the data source specified
        /// by the <see cref="MvvmFx.Controls.WisejWeb.BoundTreeView.ValueMember"/> property.
        /// </returns>
#endif
        [Browsable(false)]
        [Bindable(true)]
        [DefaultValue(null)]
        public object SelectedValue
        {
            get
            {
                if (SelectedNode != null)
                {
                    if (string.IsNullOrEmpty(_valueMember))
                        return ToString();

                    var node = SelectedNode as BoundTreeNode;
                    if (node != null && PrepareValueDescriptor())
                    {
                        return _valueProperty.GetValue(_listManager.List[node.Position]);
                    }
                }
                return null;
            }
            set
            {
                if (!string.IsNullOrEmpty(_valueMember))
                {
                    if (value == null || (value is string && string.IsNullOrEmpty((string) value)))
                        throw new InvalidOperationException();

                    if (PrepareValueDescriptor())
                    {
                        var found = false;
                        foreach (DictionaryEntry item in _itemsIdentifiers)
                        {
                            if (item.Key.GetHashCode() == value.GetHashCode())
                            {
                                SelectedNode = item.Value as TreeNode;
                                found = true;
                                break;
                            }
                        }
                        if (!found)
                            SelectedNode = null;
                    }
                }
            }
        }

#if WINFORMS
        /// <summary>
        /// Gets or sets the tree node that is currently selected in the bound tree view control.
        /// </summary>
        /// <value>The <see cref="System.Windows.Forms.TreeNode"/> that is currently selected in the tree view control.</value>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
        ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
#else
        /// <summary>
        /// Gets or sets the tree node that is currently selected in the bound tree view control.
        /// </summary>
        /// <value>The <see cref="Wisej.Web.TreeNode"/> that is currently selected in the tree view control.</value>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
        ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
#endif
        [Browsable(false)]
        [Bindable(true)]
        [DefaultValue(null)]
        public new TreeNode SelectedNode
        {
            get { return base.SelectedNode; }
            set
            {
                if (base.SelectedNode != value)
                {
                    _selectingNode = true;
                    base.SelectedNode = value;

                    if (base.SelectedNode == value && !_isDraggingOver)
                        OnSelectedValueChanged();

                    _selectingNode = false;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the tree nodes in the tree view are sorted.
        /// </summary>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
        ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        [Browsable(false)]
        [Bindable(false)]
        [DefaultValue(null)]
        public new bool Sorted
        {
            get { return base.Sorted; }
            set
            {
                if (base.Sorted != value)
                {
                    base.Sorted = value;
                    Logger.Trace("Sorted - TryDataBinding");
                    TryDataBinding();
                }
            }
        }

#if WINFORMS
        /// <summary>Gets or sets the index of the image that is displayed for the ReadOnly tree node.</summary>
        /// <returns>The zero-based index of the image in the <see cref="System.Windows.Forms.ImageList"></see> that is displayed
        /// for the ReadOnly tree node. The default is -1.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">The value specified is less than -1. </exception>
#else
        /// <summary>Gets or sets the index of the image that is displayed for the ReadOnly tree node.</summary>
        /// <returns>The zero-based index of the image in the <see cref="Wisej.Web.ImageList"></see> that is displayed
        /// for the ReadOnly tree node. The default is -1.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">The value specified is less than -1. </exception>
#endif
        [DefaultValue(-1)]
        [Editor("System.Windows.Forms.Design.ImageIndexEditor, System.Design", typeof(UITypeEditor))]
        [TypeConverter(typeof(TreeViewImageIndexConverter))]
        [Localizable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Category("Behavior")]
        [Description("Indicates the index of the image that is displayed for the ReadOnly tree node.")]
        [RelatedImageList(@"BoundTreeView.ImageList")]
        public int ReadOnlyImageIndex
        {
            get
            {
                if (ImageList == null)
                {
                    return -1;
                }
                var imageIndex = _readOnlyImageIndex;
                if (imageIndex >= ImageList.Images.Count)
                {
                    return Math.Max(0, ImageList.Images.Count - 1);
                }
                return imageIndex;
            }
            set
            {
                if (value == -1)
                {
                    value = 0;
                }
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(@"value", @"ReadOnlyImageIndex - InvalidLowBoundArgument");
                }

                _readOnlyImageIndex = value;

                // Set the ReadOnlyImageKey to the default value
                _readOnlyImageKey = "";

                // Update the control
                Update();
            }
        }

        /// <summary>Gets or sets the key for the image that is displayed for the ReadOnly tree node.</summary>
        /// <returns>The key for the image that is displayed for the ReadOnly tree node..</returns>
        [DefaultValue("")]
        [Editor("System.Windows.Forms.Design.ImageIndexEditor, System.Design", typeof(UITypeEditor))]
        [TypeConverter(typeof(TreeViewImageKeyConverter))]
        [Localizable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Category("Behavior")]
        [Description("Indicates the key for the image that is displayed for the ReadOnly tree node.")]
        [RelatedImageList(@"BoundTreeView.ImageList")]
        public string ReadOnlyImageKey
        {
            get { return _readOnlyImageKey; }
            set
            {
                _readOnlyImageKey = value;

                // Set the ReadOnlyImageIndex to the default value
                _readOnlyImageIndex = -1;

                // Update the control
                Update();
            }
        }

#if WINFORMS
        /// <summary>Gets or sets the index of the image that is displayed when a ReadOnly tree node is selected.</summary>
        /// <returns>The zero-based index of the image in the <see cref="System.Windows.Forms.ImageList"></see> that is displayed
        /// when a ReadOnly tree node is selected. The default is -1.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">The value specified is less than -1. </exception>
#else
        /// <summary>Gets or sets the index of the image that is displayed when a ReadOnly tree node is selected.</summary>
        /// <returns>The zero-based index of the image in the <see cref="Wisej.Web.ImageList"></see> that is displayed
        /// when a ReadOnly tree node is selected. The default is -1.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">The value specified is less than -1. </exception>
#endif
        [DefaultValue(-1)]
        [Editor("System.Windows.Forms.Design.ImageIndexEditor, System.Design", typeof(UITypeEditor))]
        [TypeConverter(typeof(TreeViewImageIndexConverter))]
        [Localizable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Category("Behavior")]
        [Description("Indicates the index of the image that is displayed when a ReadOnly tree node is selected.")]
        [RelatedImageList(@"BoundTreeView.ImageList")]
        public int ReadOnlySelectedImageIndex
        {
            get
            {
                if (ImageList == null)
                {
                    return -1;
                }
                var imageIndex = _readOnlySelectedImageIndex;
                if (imageIndex >= ImageList.Images.Count)
                {
                    return Math.Max(0, ImageList.Images.Count - 1);
                }
                return imageIndex;
            }
            set
            {
                if (value == -1)
                {
                    value = 0;
                }
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(@"value",
                        @"ReadOnlySelectedImageIndex - InvalidLowBoundArgument");
                }

                _readOnlySelectedImageIndex = value;

                // Set the ReadOnlySelectedImageKey to the default value
                _readOnlySelectedImageKey = "";

                // Update the control
                Update();
            }
        }

        /// <summary>Gets or sets the key for the image that is displayed when a ReadOnly tree node is selected.</summary>
        /// <returns>The key for the image that is displayed when a ReadOnly tree node is selected.</returns>
        [DefaultValue("")]
        [Editor("System.Windows.Forms.Design.ImageIndexEditor, System.Design", typeof(UITypeEditor))]
        [TypeConverter(typeof(TreeViewImageKeyConverter))]
        [Localizable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Category("Behavior")]
        [Description("Indicates the key for the image that is displayed when a ReadOnly tree node is selected.")]
        [RelatedImageList(@"BoundTreeView.ImageList")]
        public string ReadOnlySelectedImageKey
        {
            get { return _readOnlySelectedImageKey; }
            set
            {
                _readOnlySelectedImageKey = value;

                // Set the ReadOnlySelectedImageIndex to the default value
                _readOnlySelectedImageIndex = -1;

                // Update the control
                Update();
            }
        }

#if WISEJ
        /// <summary>Gets or sets the index of the image that is displayed when a ReadOnly tree node is expanded.</summary>
        /// <returns>The zero-based index of the image in the <see cref="Wisej.Web.ImageList"></see> that is displayed
        /// when a ReadOnly tree node is expanded. The default is -1.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">The value specified is less than -1. </exception>
        [DefaultValue(-1)]
        [Editor("System.Windows.Forms.Design.ImageIndexEditor, System.Design", typeof(UITypeEditor))]
        [TypeConverter(typeof(TreeViewImageIndexConverter))]
        [Localizable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Category("Behavior")]
        [Description("Indicates the index of the image that is displayed when a ReadOnly tree node is expanded.")]
        [RelatedImageList(@"BoundTreeView.ImageList")]
        public int ReadOnlyOpenedImageIndex
        {
            get
            {
                if (ImageList == null)
                {
                    return -1;
                }
                var imageIndex = _readOnlyOpenedImageIndex;
                if (imageIndex >= ImageList.Images.Count)
                {
                    return Math.Max(0, ImageList.Images.Count - 1);
                }
                return imageIndex;
            }
            set
            {
                if (value == -1)
                {
                    value = 0;
                }
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(@"value",
                        @"ReadOnlyOpenedImageIndex - InvalidLowBoundArgument");
                }

                _readOnlyOpenedImageIndex = value;

                // Set the ReadOnlyOpenedImageKey to the default value
                _readOnlyOpenedImageKey = "";

                // Update the control
                Update();
            }
        }

        /// <summary>Gets or sets the key for the image that is displayed when a ReadOnly tree node is expanded.</summary>
        /// <returns>The key for the image that is displayed when a ReadOnly tree node is expanded.</returns>
        [DefaultValue("")]
        [Editor("System.Windows.Forms.Design.ImageIndexEditor, System.Design", typeof(UITypeEditor))]
        [TypeConverter(typeof(TreeViewImageKeyConverter))]
        [Localizable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Category("Behavior")]
        [Description("Indicates the key for the image that is displayed when a ReadOnly tree node is expanded.")]
        [RelatedImageList(@"BoundTreeView.ImageList")]
        public string ReadOnlyOpenedImageKey
        {
            get { return _readOnlyOpenedImageKey; }
            set
            {
                _readOnlyOpenedImageKey = value;

                // Set the ReadOnlyOpenedImageIndex to the default value
                _readOnlyOpenedImageIndex = -1;

                // Update the control
                Update();
            }
        }
#endif

#if WEBGUI
/*
        /// <summary>Gets or sets the index of the image that is displayed for the ReadOnly tree node.</summary>
        /// <returns>The zero-based index of the image in the <see cref="Gizmox.WebGUI.Forms.ImageList"></see> that is displayed for the item. The default is -1.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">The value specified is less than -1. </exception>
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design", typeof(UITypeEditor))]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design")]
        [DefaultValue(-1)]
        [Localizable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Category("Behavior")]
        [Description("Indicates the index of the image that is displayed for the ReadOnly tree node.")]
        [RelatedImageList(@"BoundTreeView.ImageList")]
        public int ReadOnlyImageIndex
        {
            get
            {
                if (ImageList == null)
                {
                    return -1;
                }
                var imageIndex = _readOnlyImageIndex;
                if (imageIndex >= ImageList.Images.Count)
                {
                    return Math.Max(0, ImageList.Images.Count - 1);
                }
                return imageIndex;
            }
            set
            {
                if (value == -1)
                {
                    value = 0;
                }
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(@"value", @"ReadOnlyImageIndex - InvalidLowBoundArgument");
                }

                _readOnlyImageIndex = value;

                // Set the ReadOnlyImageKey to the default value
                _readOnlyImageKey = "";

                // Update the control
                Update();
            }
        }

        /// <summary>Gets or sets the key for the image that is displayed for the ReadOnly tree node.</summary>
        /// <returns>The key for the image that is displayed for the <see cref="Gizmox.WebGUI.Forms.ListViewItem"></see>.</returns>
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design", typeof(UITypeEditor))]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design")]
        [DefaultValue("")]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Localizable(true)]
        [Category("Behavior")]
        [Description("Indicates the key for the image that is displayed for the ReadOnly tree node.")]
        [RelatedImageList(@"BoundTreeView.ImageList")]
        public string ReadOnlyImageKey
        {
            get { return _readOnlyImageKey; }
            set
            {
                _readOnlyImageKey = value;

                // Set the ReadOnlyImageIndex to the default value
                _readOnlyImageIndex = -1;

                // Update the control
                Update();
            }
        }

        /// <summary>Gets or sets the index of the image that is displayed when a ReadOnly tree node is selected.</summary>
        /// <returns>The zero-based index of the image in the <see cref="Gizmox.WebGUI.Forms.ImageList"></see> that is displayed for the item. The default is -1.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">The value specified is less than -1. </exception>
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design", typeof(UITypeEditor))]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design")]
        [DefaultValue(-1)]
        [Localizable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Category("Behavior")]
        [Description("Indicates the index of the image that is displayed when a ReadOnly tree node is selected.")]
        [RelatedImageList(@"BoundTreeView.ImageList")]
        public int ReadOnlySelectedImageIndex
        {
            get
            {
                if (ImageList == null)
                {
                    return -1;
                }
                var imageIndex = _readOnlySelectedImageIndex;
                if (imageIndex >= ImageList.Images.Count)
                {
                    return Math.Max(0, ImageList.Images.Count - 1);
                }
                return imageIndex;
            }
            set
            {
                if (value == -1)
                {
                    value = 0;
                }
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(@"value", @"ReadOnlySelectedImageIndex - InvalidLowBoundArgument");
                }

                _readOnlySelectedImageIndex = value;

                // Set the ReadOnlySelectedImageKey to the default value
                _readOnlySelectedImageKey = "";

                // Update the control
                Update();
            }
        }

        /// <summary>Gets or sets the key for the image that is displayed when a ReadOnly tree node is selected.</summary>
        /// <returns>The key for the image that is displayed for the <see cref="Gizmox.WebGUI.Forms.ListViewItem"></see>.</returns>
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design", typeof(UITypeEditor))]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design")]
        [DefaultValue("")]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Localizable(true)]
        [Category("Behavior")]
        [Description("Indicates the key for the image that is displayed when a ReadOnly tree node is selected.")]
        [RelatedImageList(@"BoundTreeView.ImageList")]
        public string ReadOnlySelectedImageKey
        {
            get { return _readOnlySelectedImageKey; }
            set
            {
                _readOnlySelectedImageKey = value;

                // Set the ReadOnlySelectedImageIndex to the default value
                _readOnlySelectedImageIndex = -1;

                // Update the control
                Update();
            }
        }
*/
#endif

        /// <summary>
        /// Gets or sets a value indicating whether a ReadOnly tree node can be selected.
        /// </summary>
        /// <value>
        /// <c>true</c> if the ReadOnly tree node can be selected; otherwise, <c>false</c>.
        /// </value>
        /*[Bindable(true, BindingDirection.TwoWay)] do not uncomment*/
        [DefaultValue(false)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Category("Behavior")]
        [Description("Indicates whether a ReadOnly tree node can be selected.")]
        public bool ReadOnlyAllowSelect { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a ReadOnly tree node can be dragged.
        /// </summary>
        /// <value>
        /// <c>true</c> if the ReadOnly tree node can be dragged; otherwise, <c>false</c>.
        /// </value>
        /*[Bindable(true, BindingDirection.TwoWay)] do not uncomment*/
        [DefaultValue(false)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Category("Behavior")]
        [Description("Indicates whether a ReadOnly tree node can be dragged.")]
        public bool ReadOnlyAllowDrag { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to block node drop on read only nodes.
        /// </summary>
        /// <value>
        /// <c>true</c> if block node drop on read only nodes; otherwise, <c>false</c>.
        /// </value>
        /*[Bindable(true, BindingDirection.TwoWay)] do not uncomment*/
        [DefaultValue(false)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Category("Behavior")]
        [Description("Indicates whether to block node drop on read only nodes.")]
        public bool ReadOnlyAllowDrop { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to block node drop on the TreeView root.
        /// </summary>
        /// <value>
        /// <c>true</c> if block node drop on the TreeView root; otherwise, <c>false</c>.
        /// </value>
        /*[Bindable(true, BindingDirection.TwoWay)] do not uncomment*/
        [DefaultValue(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Category("Behavior")]
        [Description("Indicates whether to block node drop on the TreeView root.")]
        public bool AllowDropOnRoot
        {
            get { return _allowDropOnRoot; }
            set { _allowDropOnRoot = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to block node drop on its own descendents.
        /// </summary>
        /// <value>
        /// <c>true</c> if block node drop on its own descendents; otherwise, <c>false</c>.
        /// </value>
        /*[Bindable(true, BindingDirection.TwoWay)] do not uncomment*/
        [DefaultValue(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Category("Behavior")]
        [Description("Indicates whether to block node drop on its own descendents.")]
        public bool AllowDropOnDescendents
        {
            get { return _allowDropOnDescendent; }
            set { _allowDropOnDescendent = value; }
        }

        #endregion

        #region Constructor & Dispose

        /// <summary>
        /// Default constructor.
        /// </summary>
        public BoundTreeView()
        {
            Logger.Trace("Constructor");

            SetDefaultMessages();

            _listChangedHandler = ListManager_ListChanged;
            _positionChangedHandler = ListManager_PositionChanged;

            _identifierMember = string.Empty;
            _displayMember = string.Empty;
            _parentIdentifierMember = string.Empty;
            _itemsPositions = new SortedList();
            _itemsIdentifiers = new SortedList();
#if WINFORMS
            HideSelection = false;
            HotTracking = true;
#endif
        }

        private void SetDefaultMessages()
        {
            if (string.IsNullOrWhiteSpace(DuplicatedCaption))
                DuplicatedCaption = Resources.DuplicatedCaption;

            if (string.IsNullOrWhiteSpace(DuplicatedMessage))
                DuplicatedMessage = Resources.DuplicatedMessage;

            if (string.IsNullOrWhiteSpace(SelfParent))
                SelfParent = Resources.SelfParent;

            if (string.IsNullOrWhiteSpace(InexistentParent))
                InexistentParent = Resources.InexistentParent;

            if (string.IsNullOrWhiteSpace(GeneralNodeError))
                GeneralNodeError = Resources.GeneralNodeError;
        }

#if WINFORMS
        /// <summary>
        /// Called after the control has been added to another container.
        /// </summary>
        protected override void InitLayout()
        {
            Logger.Trace("InitLayout - START");
            _ignoreBindingContextChanged = true;
            base.InitLayout();
            ShowScrollBar(Handle, SbHorz, false);
            _ignoreBindingContextChanged = false;
            Logger.Trace("InitLayout - END");
        }
#endif

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            Logger.Trace("Dispose");

            if (disposing)
            {
                if (_components != null)
                    _components.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion

        #region Win32

#if WINFORMS
        [DllImport("User32.dll")]
        private static extern bool ShowScrollBar(IntPtr hWnd, int wBar, bool bShow);
#endif

        #endregion

        #region TryDataBinding

        /// <summary>
        /// Tries to get a new CurrencyManager for new DataBinding
        /// </summary>
        private void TryDataBinding()
        {
            if (_dataSource == null ||
                BindingContext == null)
                return;

            CurrencyManager currencyManager;
            try
            {
                currencyManager = (CurrencyManager) BindingContext[_dataSource, _dataMember];
            }
            catch (ArgumentException)
            {
                Logger.Trace("TryDataBinding - No CurrencyManager found");
                // If no CurrencyManager was found
                return;
            }

#if WINFORMS
            Logger.Trace("TryDataBinding - BeginUpdate");
            BeginUpdate();
#endif

            // Unwire the old CurrencyManager
            if (_listManager != null)
            {
                Logger.Trace("TryDataBinding - Unwire the old CurrencyManager");
                _listManager.ListChanged -= _listChangedHandler;
                _listManager.PositionChanged -= _positionChangedHandler;
            }
            _listManager = currencyManager;

            // Update metadata and data
            Logger.Trace("TryDataBinding - UpdateAllData");
            UpdateAllData();

            // Wire the new CurrencyManager
            if (_listManager != null)
            {
                Logger.Trace("TryDataBinding - Wire the new CurrencyManager");
                _listManager.ListChanged += _listChangedHandler;
                _listManager.PositionChanged += _positionChangedHandler;
            }

#if WINFORMS
            Logger.Trace("TryDataBinding - EndUpdate");
            EndUpdate();
#endif
        }

        #endregion

        #region Descriptors

        private bool PrepareDescriptors()
        {
            if (_listManager.GetItemProperties().Count > 0 && _identifierMember.Length != 0 &&
                _displayMember.Length != 0 && _parentIdentifierMember.Length != 0)
            {
                if (_identifierProperty == null)
                    _identifierProperty = _listManager.GetItemProperties()[_identifierMember];

                if (_displayProperty == null)
                    _displayProperty = _listManager.GetItemProperties()[_displayMember];

                if (_parentIdentifierProperty == null)
                    _parentIdentifierProperty = _listManager.GetItemProperties()[_parentIdentifierMember];

                if (_readOnlyMember != null && _readOnlyProperty == null)
                    _readOnlyProperty = _listManager.GetItemProperties()[_readOnlyMember];

                if (_toolTipTextMember != null && _toolTipTextProperty == null)
                {
                    _toolTipTextProperty = _listManager.GetItemProperties()[_toolTipTextMember];

                    if (_toolTipTextProperty != null)
                        ShowNodeToolTips = true;
                }
            }

            return (_identifierProperty != null && _displayProperty != null && _parentIdentifierProperty != null);
        }

        private bool PrepareValueDescriptor()
        {
            if (_valueProperty == null)
            {
                if (_valueMember == string.Empty)
                    _valueMember = _identifierMember;

                _valueProperty = _listManager.GetItemProperties()[_valueMember];
            }

            return (_valueProperty != null);
        }

        private bool PrepareValueConvertor()
        {
            if (_valueConverter == null)
            {
                _valueConverter = TypeDescriptor.GetConverter(_displayProperty.PropertyType);
            }

            return (_valueConverter != null && _valueConverter.CanConvertFrom(typeof(string)));
        }

        #endregion

        #region Item Methods

        private void NodesClear()
        {
            Logger.Trace("NodesClear");
            _itemsPositions.Clear();
            _itemsIdentifiers.Clear();

#if WINFORMS
            Nodes.Clear();
#else
            Nodes.Clear(true);
#endif
        }

#if WINFORMS
        /// <summary>
        /// Sorts the items in <see cref="System.Windows.Forms.TreeView" /> control.
        /// </summary>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
        ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
#else
        /// <summary>
        /// Sorts the items if the value of the <see cref="Wisej.Web.TreeView.TreeViewNodeSorter"></see> property is not null.
        /// </summary>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
        ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
#endif
        public new void Sort()
        {
            Sorted = true;
        }

        private ArrayList Clone(ArrayList master)
        {
            var copy = new ArrayList();
            foreach (var item in master)
            {
                copy.Add(item);
            }
            return copy;
        }

        /// <summary>
        /// Updates all nodes.
        /// </summary>
        private void UpdateAllData()
        {
            Logger.Trace("UpdateAllData - START");

            //save all expanded nodes
            var expandedNodes = new List<int>();
            foreach (var item in _itemsIdentifiers)
            {
                var node = ((DictionaryEntry)item).Value as BoundTreeNode;
                if (node != null && node.IsExpanded)
                    expandedNodes.Add(node.NodeId.GetHashCode());
            }

            NodesClear();

            if (PrepareDescriptors() && _listManager.Count > 0)
            {
                var controlNodeList = new ArrayList();

                Logger.Trace(string.Format("UpdateAllData - _listManager.Count {0}", _listManager.Count));

                for (var index = 0; index < _listManager.Count; index++)
                {
                    controlNodeList.Add(CreateNode(index));
                }

                Logger.Trace("UpdateAllData - Nodes added");

                if (Sorted)
                    controlNodeList.Sort(new TreeNodeSorter());

                var nodeError = false;

                Logger.Trace(string.Format("UpdateAllData - controlNodeList.Count {0}", controlNodeList.Count));

                while (controlNodeList.Count > 0)
                {
                    var loopNodeList = Clone(controlNodeList);
                    var startCount = loopNodeList.Count;
                    var removed = 0;
                    var failed = false;
                    for (var index = 0; index < loopNodeList.Count; index++)
                    {
                        var node = (BoundTreeNode) loopNodeList[index];
                        if (nodeError)
                        {
                            AddNodeWithError(node);
                            controlNodeList.RemoveAt(index - removed);
                            removed++;
                            nodeError = false;
                        }
                        else if (TryAddNode(node))
                        {
                            controlNodeList.RemoveAt(index - removed);

                            if (failed)
                                break;

                            removed++;
                        }
                        else
                        {
                            failed = true;
                        }
                    }

                    if (startCount == controlNodeList.Count)
                    {
                        nodeError = true;
                    }
                }

                //restore all expanded nodes
                foreach (var expandedNode in expandedNodes)
                {
                    foreach (var item in _itemsIdentifiers)
                    {
                        var node = ((DictionaryEntry) item).Value as BoundTreeNode;
                        if (node != null && node.NodeId.GetHashCode() == expandedNode)
                        {
                            node.Expand();
                            break;
                        }
                    }
                }

                if (_listManager.Position > -1)
                {
                    ListManager_PositionChanged(this, EventArgs.Empty);
                }
            }
            Logger.Trace("UpdateAllData - END");
        }

        private bool TryAddNode(BoundTreeNode node)
        {
            if (!_itemsIdentifiers.ContainsKey(node.NodeId))
            {
                if (IsIdNull(node.ParentNodeId))
                {
                    AddNode(Nodes, node);
                    return true;
                }
                if (_itemsIdentifiers.ContainsKey(node.ParentNodeId))
                {
                    var parentNode = _itemsIdentifiers[node.ParentNodeId] as TreeNode;
                    if (parentNode != null)
                    {
                        AddNode(parentNode.Nodes, node);
                        return true;
                    }
                }
            }
            return false;
        }

        private void AddNodeWithError(BoundTreeNode node)
        {
            string message;

            if (_itemsIdentifiers.ContainsKey(node.NodeId))
            {
                node.NodeError = true;
                // log and ignore node
                message = string.Format(DuplicatedMessage, node.Text, node.NodeId);
                Logger.Error(message);
                MessageBox.Show(message, DuplicatedCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (node.NodeId.Equals(node.ParentNodeId))
                    message = SelfParent;
                else if (!_itemsIdentifiers.ContainsKey(node.ParentNodeId))
                    message = InexistentParent;
                else
                    message = GeneralNodeError;

                Logger.Warn(string.Format("Node \"{0}\" - \"{1}\": {2}", node.Text, node.NodeId, message));
                node.NodeError = true;
                node.ForeColor = Color.Red;
                node.ToolTipText = message + Environment.NewLine + node.ToolTipText;
                AddNode(Nodes, node);
            }
        }

        private void AddNode(TreeNodeCollection nodes, BoundTreeNode node)
        {
            Logger.Trace(string.Format("AddNode - _itemsPositions: {0} - _itemsIdentifiers {1}",
                _itemsPositions.Count,
                _itemsIdentifiers.Count));
            _itemsPositions.Add(node.Position, node);
            _itemsIdentifiers.Add(node.NodeId, node);
            nodes.Add(node);
            CheckAccess(node);
        }

        private bool ChangeParent(BoundTreeNode node)
        {
            var message = string.Empty;

            var dataParentId = _parentIdentifierProperty.GetValue(_listManager.List[node.Position]);
            if (dataParentId == null)
            {
                node.Remove();
                Nodes.Add(node);

                return true;
            }

            if (node.ParentNodeId == null || node.ParentNodeId.GetHashCode() != dataParentId.GetHashCode())
            {
                if (node.NodeId.GetHashCode() == dataParentId.GetHashCode())
                {
                    message = "Node cannot be its own parent.";
                }
                else
                {
                    var newParentNode = _itemsIdentifiers[dataParentId] as BoundTreeNode;
                    if (newParentNode == null)
                    {
                        message = "Item not found or wrong type.";
                    }
                    else
                    {
                        if (IsOwnAncestor(node, newParentNode))
                        {
                            message = "Node cannot be its own ancestor.";
                        }
                        else
                        {
                            node.Remove();
                            newParentNode.Nodes.Add(node);
                            CheckAccess(node);

                            SelectedNode = node;
                            if (SelectedNode != null)
                                SelectedNode.EnsureVisible();

                            return true;
                        }
                    }
                }
            }

            if (message != string.Empty)
            {
                Logger.Warn(message);
                node.NodeError = true;
                return false;
            }

            return true;
        }

        private bool IsOwnAncestor(TreeNode source, TreeNode dropNode)
        {
            return TargetIsSourceAncestor(source, dropNode);
        }

        private bool ModelChangeParent(BoundTreeNode childNode, BoundTreeNode parentNode)
        {
            if (parentNode == null)
            {
                if (!_allowDropOnRoot)
                    return false;

                ChangeParentToRoot(childNode);
                return true;
            }

            if (childNode != null)
            {
                if (AllowDropOnDescendents)
                {
                    BoundTreeNode replacementeParent = null;
                    BoundTreeNode placeHolder = null;

                    if (TargetIsSourceAncestor(childNode, parentNode, ref replacementeParent, ref placeHolder))
                        ChangeParentUpTheSameBranch(childNode, parentNode, replacementeParent, placeHolder);
                    else
                        ChangeParentNoAncestor(childNode, parentNode);
                }
                else
                {
                    if (!TargetIsSourceAncestor(childNode, parentNode))
                        ChangeParentNoAncestor(childNode, parentNode);
                }
            }
            return true;
        }

        private void ChangeParentToRoot(BoundTreeNode childnode)
        {
            if (childnode != null)
            {
                // ReSharper disable AssignNullToNotNullAttribute
                _parentIdentifierProperty.SetValue(_listManager.List[childnode.Position], null);
                // ReSharper restore AssignNullToNotNullAttribute
                _listManager.EndCurrentEdit();
            }
        }

        private void ChangeParentNoAncestor(BoundTreeNode childnode, BoundTreeNode parentNode)
        {
            var parentId = _identifierProperty.GetValue(_listManager.List[parentNode.Position]);
            if (parentId != null)
            {
                _parentIdentifierProperty.SetValue(_listManager.List[childnode.Position], parentId);
                _listManager.EndCurrentEdit();
            }
        }

        private void ChangeParentUpTheSameBranch(BoundTreeNode childnode, BoundTreeNode parentNode,
            BoundTreeNode replacementeParent, BoundTreeNode placeHolder)
        {
            var replacementeParentId = _identifierProperty.GetValue(_listManager.List[replacementeParent.Position]);
            if (replacementeParentId != null)
                _parentIdentifierProperty.SetValue(_listManager.List[placeHolder.Position], replacementeParentId);

            var parentId = _identifierProperty.GetValue(_listManager.List[parentNode.Position]);
            if (parentId != null)
            {
                _parentIdentifierProperty.SetValue(_listManager.List[childnode.Position], parentId);
                _listManager.EndCurrentEdit();
            }
        }

        private void RefreshData(BoundTreeNode node)
        {
            var position = node.Position;
            node.NodeId = _identifierProperty.GetValue(_listManager.List[position]);
            if (_displayProperty != null && _listManager.List.Count > position)
            {
                var text = _displayProperty.GetValue(_listManager.List[position]) as string;
                if (text != null)
                    node.Text = text;
            }
            node.ParentNodeId = _parentIdentifierProperty.GetValue(_listManager.List[position]);
            if (_readOnlyProperty != null)
                node.ReadOnly = Convert.ToBoolean(_readOnlyProperty.GetValue(_listManager.List[position]));
            if (_toolTipTextProperty != null)
                node.ToolTipText = Convert.ToString(_toolTipTextProperty.GetValue(_listManager.List[position]));
            node.ForeColor = ForeColor;
        }

        private BoundTreeNode CreateNode(int position)
        {
            var node = new BoundTreeNode(position);
            RefreshData(node);
            return node;
        }

        private static bool IsIdNull(object id)
        {
            if (id == null || Convert.IsDBNull(id))
                return true;
            var s = id as string;
            if (s != null)
                return (s.Length == 0);
            if (id is Guid)
                return ((Guid) id == Guid.Empty);
            if (id is int)
                return ((int) id == 0);
            return false;
        }

        private void CheckAccess(BoundTreeNode node)
        {
            if (_readOnlyMember == null)
                return;

            node.SetNodeImages();
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
#if WINFORMS
            if (_ignoreBindingContextChanged)
                return;
#endif
            Logger.Trace("OnBindingContextChanged");
            TryDataBinding();
            base.OnBindingContextChanged(e);
        }

        #endregion

        #region Position changed from DataSource

        private void ListManager_PositionChanged(object sender, EventArgs e)
        {
            if (_itemsPositions.Count == 0)
                return;

            var node = _itemsPositions[_listManager.Position] as BoundTreeNode;
            if (node != null)
            {
                if (SelectedNode == null || SelectedNode != node)
                    SelectedNode = node;

                node.EnsureVisible();
            }
        }

        #endregion

        #region Item(s) changed from DataSource

        private void ListManager_ListChanged(object sender, ListChangedEventArgs e)
        {
            Logger.Trace("ListManager_ListChanged - ListChangedType."+ e.ListChangedType+" - START");
            var message = string.Empty;

            switch (e.ListChangedType)
            {
                case ListChangedType.ItemAdded:
                    if (!TryAddNode(CreateNode(e.NewIndex)))
                    {
                        message = "Item was not added.";
                    }
                    break;

                case ListChangedType.ItemChanged:
                    var changedNode = _itemsPositions[e.NewIndex] as BoundTreeNode;
                    if (changedNode != null)
                    {
                        if (ChangeParent(changedNode))
                        {
                            changedNode.NodeError = false;
                            RefreshData(changedNode);
                        }
                        else
                        {
                            Logger.Trace("ListManager_ListChanged - ListChangedType.ItemChanged - RefreshTree");
                            RefreshTree();
                        }
                    }
                    else
                    {
                        message = "Item not found or wrong type.";
                    }
                    break;

                case ListChangedType.ItemMoved:
                    var movedNode = _itemsPositions[e.OldIndex] as BoundTreeNode;
                    if (movedNode != null)
                    {
                        _itemsPositions.Remove(e.OldIndex);
                        _itemsPositions.Add(e.NewIndex, movedNode);
                    }
                    else
                    {
                        message = "Item not found or wrong type.";
                    }
                    break;

                case ListChangedType.ItemDeleted:
                    var deletedNode = _itemsPositions[e.NewIndex] as BoundTreeNode;
                    if (deletedNode != null)
                    {
                        _itemsPositions.Remove(e.NewIndex);
                        _itemsIdentifiers.Remove(deletedNode.NodeId);
                        Logger.Trace("ListManager_ListChanged - ListChangedType.ItemDeleted - RefreshTree");
                        RefreshTree();
                    }
                    else
                    {
                        message = "Item not found or wrong type.";
                    }
                    break;

                case ListChangedType.Reset:
                    Logger.Trace("ListManager_ListChanged - ListChangedType.Reset - RefreshTree");
                    RefreshTree();
                    break;
            }

            if (message != string.Empty)
                Logger.Error(message);
        }

        private void RefreshTree()
        {
#if WINFORMS
            Logger.Trace("RefreshTree - BeginUpdate");
            BeginUpdate();
#endif

            Logger.Trace("RefreshTree - UpdateAllData");
            UpdateAllData();

#if WINFORMS
            Logger.Trace("RefreshTree - EndUpdate");
            EndUpdate();
#endif
        }

        #endregion

        #region Drag & Drop

#if WINFORMS
        /// <summary>
        /// Raises the <see cref="System.Windows.Forms.TreeView.ItemDrag"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.Windows.Forms.ItemDragEventArgs"/> instance containing the event data.</param>
        protected override void OnItemDrag(ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Copy | DragDropEffects.Move); //Begin the drag-drop operation
            base.OnItemDrag(e);
        }

        /// <summary>
        /// Raises the <see cref="System.Windows.Forms.Control.DragOver" /> event.
        /// </summary>
        /// <param name="e">A <see cref="System.Windows.Forms.DragEventArgs" /> that contains the event data.</param>
        protected override void OnDragOver(DragEventArgs e)
        {
            var tv = (TreeView) this;
            var position = tv.PointToClient(new Point(e.X, e.Y)); //Get the co-ordinates of the mouse
            var destinationNode = tv.GetNodeAt(position); //Get the node at the current mouse position

            _isDraggingOver = true;
            SelectedNode = destinationNode; //Highlight the node in relations to the mouse position
            _isDraggingOver = false;
            e.Effect = DragDropEffects.Move;
            base.OnDragOver(e);
        }

        /// <summary>
        /// Raises the <see cref="System.Windows.Forms.Control.DragDrop" /> event.
        /// </summary>
        /// <param name="e">A <see cref="System.Windows.Forms.DragEventArgs" /> that contains the event data.</param>
        protected override void OnDragDrop(DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(BoundTreeNode)))
            {
                // Continue only if the item being dragged is a BoundTreeNode object

                var tv = (TreeView) this;
                var position = tv.PointToClient(new Point(e.X, e.Y)); //Get the mouse co-ordinates
                var dropNode = (BoundTreeNode) tv.GetNodeAt(position);
                var dragNode = (BoundTreeNode) e.Data.GetData(typeof(BoundTreeNode));

                if (dragNode != null && (ReadOnlyAllowDrag || !dragNode.ReadOnly))
                {
                    // now you can drag

                    // dropNode is a BoundTreeNode
                    if (dropNode != null && (ReadOnlyAllowDrop || !dropNode.ReadOnly))
                    {
                        if (ValidateTarget(dragNode, dropNode))
                        {
                            SelectedNode = dropNode;
                            dropNode.EnsureVisible();

                            if (ModelChangeParent(dragNode, dropNode))
                                dropNode.Expand();
                        }
                    }
                    else if (e.Data.GetData(typeof(BoundTreeNode)) != null)
                    {
                        // dropNode is the TreeView's root
                        if (ValidateTarget(dragNode))
                        {
                            _isDroppingOnRoot = true;
                            SelectedNode = dragNode;
                            _isDroppingOnRoot = false;
                            dragNode.EnsureVisible();

                            if (ModelChangeParent(dragNode, null))
                                ExpandAll();
                        }
                    }
                }
            }
            base.OnDragDrop(e);
        }

#else

        /// <summary>
        /// Raises the <see cref="Wisej.Web.TreeView.ItemDrag"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Wisej.Web.ItemDragEventArgs"/> instance containing the event data.</param>
        protected override void OnItemDrag(ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Copy | DragDropEffects.Move); //Begin the drag-drop operation
            base.OnItemDrag(e);
        }

        /*/// <summary>
        /// Raises the <see cref="Wisej.Web.Control.DragOver" /> event.
        /// </summary>
        /// <param name="e">A <see cref="Wisej.Web.DragEventArgs" /> that contains the event data.</param>
        protected override void OnDragOver(DragEventArgs e)
        {
            var destinationNode = e.DropTarget as TreeNode;
            _isDraggingOver = true;
            SelectedNode = destinationNode; //Highlight the node in relations to the mouse position
            _isDraggingOver = false;
            e.Effect = DragDropEffects.Move;
            base.OnDragOver(e);
        }*/

        /// <summary>
        /// Raises the <see cref="Wisej.Web.Control.DragDrop" /> event.
        /// </summary>
        /// <param name="e">A <see cref="Wisej.Web.DragEventArgs" /> that contains the event data.</param>
        protected override void OnDragDrop(DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(BoundTreeNode)))
            {
                // Continue only if the item being dragged is a BoundTreeNode object

                var dropNode = (BoundTreeNode) e.DropTarget;
                var dragNode = (BoundTreeNode) e.Data.GetData(typeof(BoundTreeNode));

                if (dragNode != null && (ReadOnlyAllowDrag || !dragNode.ReadOnly))
                {
                    // now you can drag

                    // dropNode is a BoundTreeNode
                    if (dropNode != null && (ReadOnlyAllowDrop || !dropNode.ReadOnly))
                    {
                        if (ValidateTarget(dragNode, dropNode))
                        {
                            SelectedNode = dropNode;
                            dropNode.EnsureVisible();

                            if (ModelChangeParent(dragNode, dropNode))
                                dropNode.Expand();
                        }
                    }
                    else if (e.Data.GetData(typeof(BoundTreeNode)) != null)
                    {
                        // dropNode is the TreeView's root
                        if (ValidateTarget(dragNode))
                        {
                            _isDroppingOnRoot = true;
                            SelectedNode = dragNode;
                            _isDroppingOnRoot = false;
                            dragNode.EnsureVisible();

                            if (ModelChangeParent(dragNode, null))
                                ExpandAll();
                        }
                    }
                }
            }
            base.OnDragDrop(e);
        }

#endif

#if WEBGUI
/*
        /// <summary>
        /// Raises the <see cref="Gizmox.WebGUI.Forms.Control.DragDrop"/> event.
        /// </summary>
        /// <param name="e">A <see cref="Gizmox.WebGUI.Forms.DragEventArgs"/> that contains the event data. </param>
        protected override void OnDragDrop(DragEventArgs e)
        {
            var dragDropEventArgs = e as DragDropEventArgs;

            if (dragDropEventArgs != null)
            {
                if (dragDropEventArgs.Source != null)
                {
                    if (ReferenceEquals(dragDropEventArgs.Source.GetType(), typeof(BoundTreeNode)))
                    {
                        var dragNode = (BoundTreeNode) dragDropEventArgs.Source;

                        if (dragNode != null && (ReadOnlyAllowDrag || !dragNode.ReadOnly) && dragDropEventArgs.ExplicitTarget != null)
                        {
                            // now you can drag
                            if (ReferenceEquals(dragDropEventArgs.ExplicitTarget.GetType(), typeof(BoundTreeNode)))
                            {
                                // dropNode is a BoundTreeNode
                                var dropNode = (BoundTreeNode) dragDropEventArgs.ExplicitTarget;

                                if (dropNode != null && (ReadOnlyAllowDrop || !dropNode.ReadOnly))
                                {
                                    if (ValidateTarget(dragNode, dropNode))
                                    {
                                        SelectedNode = dropNode;
                                        dropNode.EnsureVisible();

                                        if (ModelChangeParent(dragNode, dropNode))
                                            dropNode.Expand();
                                    }
                                }
                            }
                            else if (ReferenceEquals(dragDropEventArgs.ExplicitTarget.GetType(), typeof(BoundTreeView)))
                            {
                                // dropNode is the TreeView's root
                                if (ValidateTarget(dragNode))
                                {
                                    SelectedNode = dragNode;
                                    SelectedNode.EnsureVisible();

                                    if (ModelChangeParent(dragNode, null))
                                        ExpandAll();
                                }
                            }
                        }
                    }
                }
            }

            base.OnDragDrop(e);
        }
*/
#endif

        private bool ValidateTarget(TreeNode source, TreeNode dropNode)
        {
            var message = string.Empty;

            if (source == dropNode)
            {
                message = "You dropped \"" + source.Text + "\" onto itself";
            }
            else if (source.Parent != null && source.Parent == dropNode)
            {
                message = "You dropped \"" + source.Text + "\"  on its present location";
            }
            else if (!AllowDropOnDescendents && TargetIsSourceAncestor(source, dropNode))
            {
                message = "You dropped \"" + source.Text + "\" on top of a descendent";
            }

            if (message != string.Empty)
            {
                Logger.Warn(message);
                return false;
            }

            return true;
        }

        private bool ValidateTarget(TreeNode source)
        {
            if (source.Parent == null)
            {
                Logger.Warn("You dropped \"" + source.Text + "\" on its present location");
                return false;
            }

            return true;
        }

        private bool TargetIsSourceAncestor(TreeNode source, TreeNode dropNode)
        {
            if (dropNode.Parent == null)
                return false;

            if (source == dropNode.Parent)
                return true;

            return TargetIsSourceAncestor(source, dropNode.Parent);
        }

        private bool TargetIsSourceAncestor(TreeNode source, TreeNode dropNode,
            ref BoundTreeNode replacementeParent, ref BoundTreeNode placeHolder)
        {
            if (dropNode.Parent == null)
                return false;

            if (source == dropNode.Parent)
            {
                placeHolder = dropNode as BoundTreeNode;
                replacementeParent = source.Parent as BoundTreeNode;
                return true;
            }

            return TargetIsSourceAncestor(source, dropNode.Parent, ref replacementeParent, ref placeHolder);
        }

        #endregion

        #region Position Changed from TreeView

#if WEBGUI
/*
        /// <summary>
        /// Raises the <see cref="Gizmox.WebGUI.Forms.TreeView.BeforeExpand"></see> event.
        /// </summary>
        /// <param name="e">A <see cref="Gizmox.WebGUI.Forms.TreeViewCancelEventArgs"></see> that contains the event data.</param>
        protected override void OnBeforeExpand(TreeViewCancelEventArgs e)
        {
            Logger.Trace("Enter OnBeforeExpand");
            _activeNode = e.Node;
            _collapseOrExpand = true;
            _collapseOrExpandNode = _activeNode;
            base.OnBeforeExpand(e);
            Logger.Trace("Exit OnBeforeExpand");
        }

        /// <summary>
        /// Raises the <see cref="Gizmox.WebGUI.Forms.TreeView.BeforeCollapse"></see> event.
        /// </summary>
        /// <param name="e">A <see cref="Gizmox.WebGUI.Forms.TreeViewCancelEventArgs"></see> that contains the event data.</param>
        protected override void OnBeforeCollapse(TreeViewCancelEventArgs e)
        {
            Logger.Trace("Enter OnBeforeCollapse");
            _activeNode = e.Node;
            _collapseOrExpand = true;
            _collapseOrExpandNode = _activeNode;
            base.OnBeforeCollapse(e);
            Logger.Trace("Exit OnBeforeCollapse");
        }

        /// <summary>
        /// Raises the <see cref="Gizmox.WebGUI.Forms.Control.DoubleClick"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="System.EventArgs"></see> that contains the event data.</param>
        protected override void OnDoubleClick(EventArgs e)
        {
            Logger.Trace("Enter OnDoubleClick: _collapseOrExpand = " + _collapseOrExpand);
            if (!_collapseOrExpand && _activeNode != null)
            {
                if (_activeNode.IsExpanded)
                {
                    _activeNode.Collapse();
                    Logger.Trace("Collapse OnDoubleClick");
                }
                else
                {
                    _activeNode.Expand();
                    Logger.Trace("Expand OnDoubleClick");
                }
            }

            _collapseOrExpand = false;
            base.OnDoubleClick(e);
            Logger.Trace("Exit OnDoubleClick");
        }

        /// <summary>
        /// Raises the <see cref="Gizmox.WebGUI.Forms.TreeView.BeforeSelect"></see> event.
        /// </summary>
        /// <param name="e">A <see cref="Gizmox.WebGUI.Forms.TreeViewCancelEventArgs"></see> that contains the event data.</param>
        protected override void OnBeforeSelect(TreeViewCancelEventArgs e)
        {
            Logger.Trace("Enter OnBeforeSelect: _collapseOrExpand = " + _collapseOrExpand);
            _activeNode = e.Node;
            var collapseOrExpand = _collapseOrExpand && _collapseOrExpandNode == _activeNode;
            _collapseOrExpand = false;

            var disallowSelect = _readOnlyMember != null && !ReadOnlyAllowSelect && ((BoundTreeNode) _activeNode).ReadOnly;

            if (disallowSelect || collapseOrExpand)
            {
                Logger.Trace("Cancel OnBeforeSelect");
                e.Cancel = true;
            }
            else
                base.OnBeforeSelect(e);
            Logger.Trace("Exit OnBeforeSelect");
        }
*/
#endif

#if WINFORMS
        /// <summary>
        /// Raises the <see cref="System.Windows.Forms.TreeView.BeforeSelect" /> event.
        /// </summary>
        /// <param name="e">A <see cref="System.Windows.Forms.TreeViewCancelEventArgs" /> that contains the event data.</param>
#else
        /// <summary>
        /// Raises the <see cref="Wisej.Web.TreeView.BeforeSelect" /> event.
        /// </summary>
        /// <param name="e">A <see cref="Wisej.Web.TreeViewCancelEventArgs" /> that contains the event data.</param>
#endif
        protected override void OnBeforeSelect(TreeViewCancelEventArgs e)
        {
            var disallowSelect = _readOnlyMember != null && !ReadOnlyAllowSelect && ((BoundTreeNode) e.Node).ReadOnly;
            var allowDropOnRoot = _isDroppingOnRoot && (!((BoundTreeNode) e.Node).ReadOnly || ReadOnlyAllowDrag);

            if ((disallowSelect && !_isDraggingOver) && !allowDropOnRoot)
                e.Cancel = true;
            
            base.OnBeforeSelect(e);
        }

#if WINFORMS
        /// <summary>
        /// Raises the <see cref="System.Windows.Forms.TreeView.AfterSelect" /> event.
        /// </summary>
        /// <param name="e">A <see cref="System.Windows.Forms.TreeViewEventArgs" /> that contains the event data.</param>
#else
        /// <summary>
        /// Raises the <see cref="Wisej.Web.TreeView.AfterSelect" /> event.
        /// </summary>
        /// <param name="e">A <see cref="Wisej.Web.TreeViewEventArgs" /> that contains the event data.</param>
#endif
        protected override void OnAfterSelect(TreeViewEventArgs e)
        {
            // SelectedNode is now equal to e.Node
            var nodePosition = ((BoundTreeNode) e.Node).Position;
            if (_listManager.Position != nodePosition)
            {
                _listManager.Position = nodePosition;
            }

            if (!_selectingNode)
                OnSelectedValueChanged();

            base.OnAfterSelect(e);
        }

        #endregion

        #region Item changed from TreeView

#if WINFORMS
        /// <summary>
        /// Raises the <see cref="System.Windows.Forms.TreeView.AfterLabelEdit"/> event.
        /// </summary>
        /// <param name="e">A <see cref="System.Windows.Forms.NodeLabelEditEventArgs"/> that contains the event data. </param>
#else
        /// <summary>
        /// Raises the <see cref="Wisej.Web.TreeView.AfterLabelEdit"></see> event.
        /// </summary>
        /// <param name="e">A <see cref="Wisej.Web.NodeLabelEditEventArgs"></see> that contains the event data.</param>
#endif
        protected override void OnAfterLabelEdit(NodeLabelEditEventArgs e)
        {
            if (e.Label == null)
            {
                // If you press ESC while editing.
                e.CancelEdit = true;
                return;
            }

            var node = e.Node as BoundTreeNode;
            if (node != null && PrepareValueConvertor() && _valueConverter.IsValid(e.Label))
            {
                try
                {
                    _displayProperty.SetValue(_listManager.List[node.Position],
                        _valueConverter.ConvertFromString(e.Label));
                    _listManager.EndCurrentEdit();
                    base.OnAfterLabelEdit(e);
                }
                catch (Exception ex)
                {
                    // If you try to enter strings in number-columns, too long strings or something
                    // else wich is not allowed by the DataSource.
                    MessageBox.Show(Resources.EditFailed + @": " + ex.Message, Resources.EditFailed,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _listManager.CancelCurrentEdit();
                    e.CancelEdit = true;
                }
            }
        }

        #endregion

        #region SelectedValueChanged event

        /// <summary>
        /// Occurs when after the selected value changeds.
        /// </summary>
        public event EventHandler SelectedValueChanged;

        /// <summary>
        /// Called when after the selected value changeds.
        /// </summary>
        protected virtual void OnSelectedValueChanged()
        {
            var handler = SelectedValueChanged;
            if (handler != null)
                handler(this, new EventArgs());
        }

        #endregion
    }
}