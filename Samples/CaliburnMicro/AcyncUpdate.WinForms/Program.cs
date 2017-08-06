using System;
#if WISEJ
using Wisej.Web;
#else
using System.Windows.Forms;
#endif

namespace AcyncUpdate.UI
{
    internal static class Program
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
#endif

            new AppBootstrapper().Run();
        }
    }
}