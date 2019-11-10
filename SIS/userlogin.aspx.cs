using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLayer;
using BusinessLayer;
public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        String uname = TextBox1.Text;
        String pass = TextBox2.Text;
        bool r = tbl_membermaster_provider.userlogin(uname, pass);
        if(r==true)
        {
            Session["uname"] = uname;
            Response.Redirect("search.aspx");
        }

    }
}