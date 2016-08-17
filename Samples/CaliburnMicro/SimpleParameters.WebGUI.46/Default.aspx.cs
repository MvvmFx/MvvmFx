using System;
using System.Web;

namespace SimpleParameters.UI
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Redirect("~/ShellView.wgx", true);
        }
    }
}