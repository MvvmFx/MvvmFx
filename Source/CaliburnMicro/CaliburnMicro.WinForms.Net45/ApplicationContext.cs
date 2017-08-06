#if WISEJ
using System.Reflection;
using Wisej.Web;
#else
using System.Windows.Forms;
#endif

namespace MvvmFx.CaliburnMicro
{
    /// <summary>
    /// Specifies the contextual information about an application.
    /// </summary>
#if WISEJ
    public class ApplicationContext
#else
    public class ApplicationContext : System.Windows.Forms.ApplicationContext
#endif
    {
        /// <summary>
        /// Gets or sets the startup form.
        /// </summary>
        /// <value>
        /// The startup form.
        /// </value>
        internal static Form StartupForm { get; set; }

        /// <summary>
        /// Sets the startup form.
        /// </summary>
        /// <param name="form">The form.</param>
        public static void SetStartupForm(Form form)
        {
            StartupForm = form;
        }

#if WISEJ
    /// <summary>
    /// Gets or sets the entry assembly.
    /// </summary>
    /// <value>
    /// The entry assembly.
    /// </value>
        internal static Assembly EntryAssembly { get; private set; }

        /// <summary>
        /// Sets the entry assembly.
        /// </summary>
        /// <param name="obj">The object of the assembly.</param>
        internal static void SetEntryAssembly(object obj)
        {
            EntryAssembly = obj.GetType().Assembly;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationContext"/> class, using a given main windows Form.
        /// </summary>
        /// <param name="mainWindow">The main window.</param>
        public ApplicationContext(Form mainWindow)
        {
            _mainWindow = mainWindow;
        }

#else
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationContext"/> class, using a given main windows Form.
        /// </summary>
        /// <param name="mainWindow">The main window.</param>
        public ApplicationContext(Form mainWindow)
            : base(mainWindow)
        {
            _mainWindow = mainWindow;
        }
#endif
        private static Form _mainWindow;

        /// <summary>
        /// Gets or sets the application main window.
        /// </summary>
        /// <value>
        /// The application main window.
        /// </value>
        public static Form MainWindow
        {
            get { return _mainWindow; }
            set
            {
                if (_mainWindow != value)
                {
                    if (_mainWindow != null)
                    {
                        _mainWindow.Dispose();
                    }
                    _mainWindow = value;
                }
            }
        }
    }
}