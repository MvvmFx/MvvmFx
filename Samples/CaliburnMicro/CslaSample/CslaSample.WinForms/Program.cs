using System;
#if WINFORMS
using System.Windows.Forms;
#else
using Wisej.Web;
#endif

namespace CslaSample
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
#if WINFORMS
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
#else
            Application.SessionTimeout += Application_SessionTimeout;
#endif

            new AppBootstrapper().Run();
        }

#if WISEJ
        private static void Application_SessionTimeout(object sender, System.ComponentModel.HandledEventArgs e)
        {
            // you can display a form and override the default session timeout dialog.
            e.Handled = true;
        }
#endif
    }
}