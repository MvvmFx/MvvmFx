using System.Collections.Generic;
using Gizmox.WebGUI.Forms;

namespace WebGUI.TestBoundTreeView
{
    internal class ListViewState
    {
        private Dictionary<string, colOptionsClass> SaveOptions(ListView listView)
        {
            Dictionary<string, colOptionsClass> colDict = new Dictionary<string, colOptionsClass>();
            foreach (ColumnHeader columnHeader in listView.Columns)
            {
                colOptionsClass columnOptions = new colOptionsClass();
                columnOptions.label = columnHeader.Tag;
                columnOptions.visible = columnHeader.Visible;
                columnOptions.width = columnHeader.Width;
                columnOptions.displayindex = columnHeader.DisplayIndex;
                columnOptions.sortorder = columnHeader.SortOrder;
                if (columnOptions.sortorder == SortOrder.None)
                {
                    columnOptions.sortposition = 0;
                }
                else
                {
                    columnOptions.sortposition = columnHeader.SortPosition;
                }
                colDict.Add(columnOptions.Label(), columnOptions);
            }
            return colDict;
        }
    }
}
