using System;
using System.Data;
using System.Drawing;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms;
using TreeListView.Resources.UserData;

//Datahandling is done in a dirt way.
//In a production environment it should be done definitly diffrent!

namespace TreeListView
{
    public partial class TreeListView : Form
    {
        #region Enumerations

        public enum RowExpansionType
        {
            Expanded,
            Collapsed
        }

        #endregion

        #region Structs

        public struct RowTag
        {
            public string ID;
            public ListViewPanelItem Container;
            public RowExpansionType RowExpansion;
            public Label Label;
            public PictureBox PictureBox;
        }

        #endregion

        #region Members

        private readonly NorthWind _northWind;

        #endregion

        #region Constructors

        public TreeListView()
        {
            InitializeComponent();
            _northWind = new NorthWind();
            _northWind.ReadXml(Context.Server.MapPath("~\\Resources\\UserData\\NorthWindData.XML"));
        }

        #endregion

        #region Event handlers

        private void ListView_Load(object sender, EventArgs e)
        {
            BuildCustomerListView(lvMain);
            FillCustomersListView(lvMain);
        }

        private void pbCustomers_Click(object sender, EventArgs e)
        {
            var lvpi = (ListViewPanelItem) ((PictureBox) sender).Tag;
            ToggleCustomerRowExpansion(lvpi);
        }

        private void lblCustomers_Click(object sender, EventArgs e)
        {
            var lvpi = (ListViewPanelItem) ((Label) sender).Tag;
            ToggleCustomerRowExpansion(lvpi);
        }

        private void pbOrders_Click(object sender, EventArgs e)
        {
            var lvpi = (ListViewPanelItem) ((PictureBox) sender).Tag;
            CollapseAllOrders(lvpi);
            ToggleOrdersRowExpansion(lvpi);
        }

        private void lblOrders_Click(object sender, EventArgs e)
        {
            var lvpi = (ListViewPanelItem) ((Label) sender).Tag;
            CollapseAllOrders(lvpi);
            ToggleOrdersRowExpansion(lvpi);
        }

        #endregion

        #region Methods

        private void ToggleCustomerRowExpansion(ListViewPanelItem lvpi)
        {
            var rowTag = (RowTag) lvpi.Tag;

            if (rowTag.RowExpansion == RowExpansionType.Collapsed)
            {
                rowTag.Label.ForeColor = Color.Red;
                rowTag.PictureBox.Image = new IconResourceHandle("down.png");
                lvpi.Panel.Visible = true;

                rowTag.RowExpansion = RowExpansionType.Expanded;


                Gizmox.WebGUI.Forms.ListView lvSub;
                if (lvpi.Panel.Controls.Count == 0)
                {
                    lvSub = BuildOrderListView();
                    lvpi.Panel.Controls.Add(lvSub);
                    lvSub.Dock = DockStyle.Fill;
                }
                else
                {
                    lvSub = (Gizmox.WebGUI.Forms.ListView) lvpi.Panel.Controls[0];
                }

                FillOrderListView(lvpi, lvSub, rowTag.ID);
            }
            else
            {
                rowTag.Label.ForeColor = rowTag.Label.ForeColor = Color.FromArgb(24, 134, 231);
                rowTag.PictureBox.Image = new IconResourceHandle("right.png");
                lvpi.Panel.Visible = false;
                rowTag.RowExpansion = RowExpansionType.Collapsed;
            }

            lvpi.Tag = rowTag;
        }

        private void ToggleOrdersRowExpansion(ListViewPanelItem lvpi)
        {
            var rowTag = (RowTag) lvpi.Tag;

            if (rowTag.RowExpansion == RowExpansionType.Collapsed)
            {
                rowTag.Label.ForeColor = Color.Red;
                rowTag.PictureBox.Image = new IconResourceHandle("down.png");
                lvpi.Panel.Visible = true;

                rowTag.RowExpansion = RowExpansionType.Expanded;

                Gizmox.WebGUI.Forms.ListView lvSub;
                if (lvpi.Panel.Controls.Count == 0)
                {
                    lvSub = BuildOrderLinesListView();
                    lvpi.Panel.Controls.Add(lvSub);
                    lvSub.Dock = DockStyle.Fill;
                }
                else
                {
                    lvSub = (Gizmox.WebGUI.Forms.ListView) lvpi.Panel.Controls[0];
                }

                FillOrderLinesListView(lvpi, lvSub, rowTag.ID);
            }
            else
            {
                rowTag.Label.ForeColor = Color.FromArgb(24, 134, 231);
                rowTag.PictureBox.Image = new IconResourceHandle("right.png");
                lvpi.Panel.Visible = false;
                rowTag.RowExpansion = RowExpansionType.Collapsed;
            }

            lvpi.Tag = rowTag;
        }

        private void CollapseAllOrders(ListViewPanelItem clvpi)
        {
            foreach (ListViewPanelItem lvpi in clvpi.ListView.Items)
            {
                if (((RowTag) lvpi.Tag).RowExpansion == RowExpansionType.Expanded && lvpi.Index != clvpi.Index)
                {
                    ToggleOrdersRowExpansion(lvpi);
                }
            }
        }

        private void BuildCustomerListView(Gizmox.WebGUI.Forms.ListView lv)
        {
            lv.BorderStyle = BorderStyle.None;
            lv.HeaderStyle = ColumnHeaderStyle.None;

            var ch = new ColumnHeader();
            ch.Text = "";
            ch.Width = 16;
            ch.Type = ListViewColumnType.Control;
            ch.PreferedItemHeight = 16;
            lvMain.Columns.Add(ch);

            ch = new ColumnHeader();
            ch.Text = "";
            ch.Width = 300;
            ch.Type = ListViewColumnType.Control;
            lvMain.Columns.Add(ch);
        }

        private Gizmox.WebGUI.Forms.ListView BuildOrderListView()
        {
            var lv = new Gizmox.WebGUI.Forms.ListView();
            lv.BorderStyle = BorderStyle.None;
            lv.HeaderStyle = ColumnHeaderStyle.None;

            var ch = new ColumnHeader();
            ch.Text = "";
            ch.Width = 16;
            ch.Type = ListViewColumnType.Control;
            ch.PreferedItemHeight = 16;
            lv.Columns.Add(ch);

            ch = new ColumnHeader();
            ch.Text = "";
            ch.Width = 300;
            ch.Type = ListViewColumnType.Control;
            lv.Columns.Add(ch);

            return lv;
        }

        private Gizmox.WebGUI.Forms.ListView BuildOrderLinesListView()
        {
            var lv = new Gizmox.WebGUI.Forms.ListView();
            lv.BorderStyle = BorderStyle.None;
            lv.HeaderStyle = ColumnHeaderStyle.None;

            var ch = new ColumnHeader();
            ch.Text = "Quantity";
            ch.Width = 30;
            ch.Type = ListViewColumnType.Text;
            ch.PreferedItemHeight = 16;
            lv.Columns.Add(ch);

            ch = new ColumnHeader();
            ch.Text = "Product";
            ch.Width = 300;
            ch.Type = ListViewColumnType.Text;
            ch.PreferedItemHeight = 16;
            lv.Columns.Add(ch);

            ch = new ColumnHeader();
            ch.Text = "Price";
            ch.Width = 100;
            ch.Type = ListViewColumnType.Text;
            ch.PreferedItemHeight = 16;
            lv.Columns.Add(ch);

            return lv;
        }

        private void FillCustomersListView(Gizmox.WebGUI.Forms.ListView lv)
        {
            var dtCustomers = _northWind.Customers;
            foreach (DataRow row in dtCustomers.Rows)
            {
                var pnl = new Panel();
                pnl.DockPadding.Left = 20;
                var lvpi = new ListViewPanelItem(pnl);
                pnl.Height = 200;

                var pb = new PictureBox();
                pb.Size = new Size(16, 16);
                pb.Tag = lvpi;
                pb.Click += pbCustomers_Click;
                lvpi.SubItems.Add(pb);

                var lbl = new Label();
                lbl.Font = new Font("Arial", 11F, FontStyle.Bold, GraphicsUnit.Point, ((byte) (0)));
                lbl.ForeColor = Color.FromArgb(24, 134, 231);
                lbl.Text = row["CompanyName"].ToString();
                lbl.Click += lblCustomers_Click;
                lbl.AutoSize = true;
                lbl.Tag = lvpi;
                lbl.Cursor = Cursors.Hand;
                lvpi.SubItems.Add(lbl);

                lvMain.Items.Add(lvpi);

                var rowTag = new RowTag();
                rowTag.ID = row["CustomerID"].ToString();
                rowTag.RowExpansion = RowExpansionType.Expanded;
                rowTag.Label = lbl;
                rowTag.PictureBox = pb;
                lvpi.Tag = rowTag;

                ToggleCustomerRowExpansion(lvpi);
            }
        }

        private void FillOrderListView(ListViewPanelItem lvpi, Gizmox.WebGUI.Forms.ListView lvSub, string customerID)
        {
            var dtOrders = _northWind.Orders;
            lvpi.Panel.Height = 0;
            int cnt = 0;

            lvSub.Items.Clear();

            foreach (DataRow row in dtOrders.Rows)
            {
                if (row["CustomerID"].ToString() == customerID)
                {
                    var pnl = new Panel();
                    pnl.DockPadding.Left = 20;
                    var lvspi = new ListViewPanelItem(pnl);

                    var pb = new PictureBox();
                    pb.Size = new Size(16, 16);
                    pb.Tag = lvspi;
                    pb.Click += pbOrders_Click;
                    lvspi.SubItems.Add(pb);

                    var lbl = new Label();
                    lbl.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, ((byte) (0)));
                    lbl.ForeColor = Color.FromArgb(((int) (((byte) (24)))), ((int) (((byte) (134)))),
                        ((int) (((byte) (231)))));
                    lbl.Text = row["OrderID"].ToString();
                    lbl.Click += lblOrders_Click;
                    lbl.AutoSize = true;
                    lbl.Tag = lvspi;
                    lbl.Cursor = Cursors.Hand;
                    lvspi.SubItems.Add(lbl);

                    lvSub.Items.Add(lvspi);

                    var rowTag = new RowTag();
                    rowTag.ID = row["OrderID"].ToString();
                    rowTag.Container = lvpi;
                    rowTag.RowExpansion = RowExpansionType.Expanded;
                    rowTag.Label = lbl;
                    rowTag.PictureBox = pb;
                    lvspi.Tag = rowTag;

                    ToggleOrdersRowExpansion(lvspi);

                    cnt += 1;
                }
            }
            lvpi.Panel.Height = cnt*19;
        }

        private void FillOrderLinesListView(ListViewPanelItem lvpi, Gizmox.WebGUI.Forms.ListView lvSub, string orderID)
        {
            var dtOrderLines = _northWind.Order_Details;
            lvpi.Panel.Height = 0;
            int cnt = 0;

            lvSub.Items.Clear();

            foreach (DataRow row in dtOrderLines.Rows)
            {
                if (row["OrderID"].ToString() == orderID)
                {
                    var lvi = new ListViewItem();
                    lvi.SubItems.Add(row["Quantity"].ToString());
                    lvi.SubItems.Add(GetProductDescrption(row["ProductID"].ToString()));
                    lvi.SubItems.Add("$ " + row["UnitPrice"]);
                    lvSub.Items.Add(lvi);
                    cnt += 1;
                }
            }
            lvpi.Panel.Height = cnt*18;
            ((RowTag) lvpi.ListView.Items[0].Tag).Container.Panel.Height =
                ((lvpi.ListView.Items.Count)*19) + lvpi.Panel.Height;
        }

        private string GetProductDescrption(string productId)
        {
            var dtProducts = _northWind.Products;
            foreach (DataRow row in dtProducts.Rows)
            {
                if (row["ProductID"].ToString() == productId)
                {
                    return row["ProductName"].ToString();
                }
            }
            return "";
        }

        #endregion
    }
}