using System;
#if WINFORMS
using System.Windows.Forms;
#else
using Wisej.Web;
#endif

namespace WisejWeb.TestTreeView
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
#if WINFORMS
        [STAThread]
#endif
        static void Main()
        {
#if WINFORMS
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
#else
            MainForm window = new MainForm();
            window.Show();
#endif
        }
    }
}
