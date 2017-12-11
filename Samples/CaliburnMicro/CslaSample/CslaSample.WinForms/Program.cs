using System;
#if WINFORMS
using System.Windows.Forms;
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
#endif

            new AppBootstrapper().Run();
        }
    }
}