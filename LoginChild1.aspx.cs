using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ASPLogin
{
    public partial class LoginChild1 : System.Web.UI.Page
    {
        SqlConnection Con = null;
        SqlDataAdapter Adp = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlCon"].ToString());
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Adp = new SqlDataAdapter("select * from tbl_Login2 where Empid=@Eid and Password=@P",Con);
            Adp.SelectCommand.Parameters.AddWithValue("@Eid", int.Parse(txtEmpid.Text));
            Adp.SelectCommand.Parameters.AddWithValue("@P", txtPassword.Text);
            DataSet Ds = new DataSet();
            Adp.Fill(Ds, "E");
            string name= "";
            string type= "";
            if(Ds.Tables["E"].Rows.Count==1)
            {
                name = Ds.Tables["E"].Rows[0][1].ToString();
                type = Ds.Tables["E"].Rows[0][3].ToString();
            }
            if (type == "Admin")
            {
                Response.Cookies["name"].Value = name;
                Response.Redirect("Admin.aspx");
            }
            else if (type == "Associate")
            {
                Response.Cookies["name"].Value = name;
                Response.Redirect("Associate.aspx");
            }
            else
                
                Response.Redirect("LoginChild1.aspx");
        }
    }
}