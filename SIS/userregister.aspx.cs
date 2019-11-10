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
        String upass = TextBox2.Text;
        String urpass = TextBox3.Text;
        tbl_membermaster_provider.registernew(uname, upass);
        Label1.Text = "Added successfully.";
        
    }
}