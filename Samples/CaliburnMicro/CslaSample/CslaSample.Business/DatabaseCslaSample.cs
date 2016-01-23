using System.Configuration;

namespace CslaSample.Business
{
    /// <summary>Class that provides the connection
    /// strings used by the application.</summary>
    internal static partial class Database
    {
        /// <summary>Connection string to the CslaSample database.</summary>
        internal static string CslaSampleConnection
        {
            get { return ConfigurationManager.ConnectionStrings["CslaSample"].ConnectionString; }
        }
    }
}
