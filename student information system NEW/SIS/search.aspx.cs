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
        if (!IsPostBack)
        {
            List<student> lstuser = tbl_membermaster_provider.getallusers(Session["uname"].ToString());
            GridView1.DataSource = lstuser;
            GridView1.DataBind();
        }

    }
}