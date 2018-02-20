using System;
using BoundControls.Business;
using Wisej.Web;

namespace WisejWeb.ComponentBinding
{
    public partial class MainPage : Page
    {
        private readonly MvvmFxBindComponents _binder = new MvvmFxBindComponents();

        private bool _menuItemIsVisible = true;

        public MainPage()
        {
            InitializeComponent();
        }

        private bool MenuItemIsVisible
        {
            set
            {
                if (_menuItemIsVisible != value)
                {
                    _menuItemIsVisible = value;
                    changeMenuItem.Enabled = _menuItemIsVisible;
                }
            }
        }


        private void MainPage_Load(object sender, EventArgs e)
        {
            MenuItemIsVisible = false;

            var item = ItemCollection.GetItem("menuItem6");
            item.Visible = false;
            item.Text = "Hidden";
            item.ToolTipText = "Hidden menu entry";


            _binder.SetMvvmFxBindings(this);
        }

        private void showMenuItem_Click(object sender, EventArgs e)
        {
            var item = ItemCollection.GetItem("menuItem6");
            item.Visible = true;

            MenuItemIsVisible = true;
        }

        private void changeMenuItem_Click(object sender, EventArgs e)
        {
            var item = ItemCollection.GetItem("menuItem6");
            item.Text = "Help";
            item.ToolTipText = "Get help about an application topic.";
        }


        private void winFormsBindings_Click(object sender, EventArgs e)
        {
            using (var winFormsBindMenu = new WinFormsBindings())
            {
                winFormsBindMenu.ShowDialog();
            }
        }

        private void mvvmfxBindings_Click(object sender, EventArgs e)
        {
            using (var mvvmFxBindMenu = new MvvmFxBindings())
            {
                mvvmFxBindMenu.ShowDialog();
            }
        }
    }
}