using System;
using BoundTreeView.Properties;
using FamilyBusiness;
using MvvmFx.Bindings.Data;

namespace BoundTreeView.Framework
{
    public class DeleteModeDescriptionConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (targetType != typeof (string))
                throw new InvalidOperationException("The target must be a string.");

            var result = string.Empty;

            switch ((DeleteMode) value)
            {
                case DeleteMode.CascadeDelete:
                    result = Resources.Cascade_Delete;
                    break;
                case DeleteMode.BypassDeletedNode:
                    result = Resources.Bypass_Deleted_Node;
                    break;
                case DeleteMode.OrphanChildNodes:
                    result = Resources.Orphan_Child_Nodes;
                    break;
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (targetType != typeof (DeleteMode))
                throw new InvalidOperationException("The source must be a DeleteMode option.");

            object result = null;

            if (string.Equals(((string) value), Resources.Cascade_Delete, StringComparison.CurrentCultureIgnoreCase))
            {
                result = DeleteMode.CascadeDelete;
            }
            else if (string.Equals(((string) value), Resources.Bypass_Deleted_Node, StringComparison.CurrentCultureIgnoreCase))
            {
                result = DeleteMode.BypassDeletedNode;
            }
            else if (string.Equals(((string) value), Resources.Orphan_Child_Nodes, StringComparison.CurrentCultureIgnoreCase))
            {
                result = DeleteMode.OrphanChildNodes;
            }

            return result;
        }

        #endregion
    }
}