using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPLogin
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["name"] == null)
                Response.Redirect("LoginChild1.aspx");
            else
                Label1.Text = "Welcome " + Request.Cookies["name"].Value;
        }
    }
}