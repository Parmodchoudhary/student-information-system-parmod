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
            List<student> lstuser = tbl_membermaster_provider.getallusers();
            gridSample.DataSource = lstuser;
            gridSample.DataBind();
            lblMessage.Text = "";
        }

    }

   
    void BindGrid()
    {

        using (sisEntities2 context = new sisEntities2())
        {
            if (context.students.Count() > 0)
            {
                List<student> lstuser = tbl_membermaster_provider.getallusers();
                gridSample.DataSource = lstuser;
                gridSample.DataBind();
            }
            else
            {
                var obj = new List<student>();
                obj.Add(new student());
                // Bind the DataTable which contain a blank row to the GridView
                gridSample.DataSource = obj;
                gridSample.DataBind();
                int columnsCount = gridSample.Columns.Count;
                gridSample.Rows[0].Cells.Clear();// clear all the cells in the row
                gridSample.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                gridSample.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell

                //You can set the styles here
                gridSample.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                gridSample.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                gridSample.Rows[0].Cells[0].Font.Bold = true;
                //set No Results found to the new added cell
                gridSample.Rows[0].Cells[0].Text = "NO RESULT FOUND!";
            }
        }
    }

  
     




 

    
 
 
    protected void gridSample_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int Id = Convert.ToInt32(gridSample.DataKeys[e.RowIndex].Value);
        tbl_membermaster_provider.delete(Id);
        BindGrid();
        lblMessage.Text = "Deleted successfully.";
    }

    protected void gridSample_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gridSample.EditIndex = -1;
        BindGrid();
    }

    protected void gridSample_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "InsertNew")
        {
            GridViewRow row = gridSample.FooterRow;
            TextBox txtFirstName = row.FindControl("txtNameNew") as TextBox;
            TextBox email = row.FindControl("txtAgeNew") as TextBox;
            TextBox mno = row.FindControl("txtSalaryNew") as TextBox;
            //DropDownList ddlCategory = row.FindControl("ddlCategoryNew") as DropDownList;

            using (sisEntities2 context = new sisEntities2())
            {
                int t = context.students.Count();
                student obj = new student();
                obj.stu_name = txtFirstName.Text;
                obj.stu_batch = "2018";
                obj.stu_stream = "IT";
                obj.stu_email = email.Text;
                obj.stu_mno = mno.Text;
                int d = context.students.Max(x => x.Id);
                obj.Id = d + 1;



                context.students.Add(obj);
                //..AddObject(obj);
                context.SaveChanges();
                BindGrid();
            }
        }
    }

    protected void gridSample_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void gridSample_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gridSample.EditIndex = e.NewEditIndex;
        BindGrid();
    }

    protected void gridSample_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = gridSample.Rows[e.RowIndex];
        TextBox txtFirstName = row.FindControl("txtName") as TextBox;
        TextBox txtLastName = row.FindControl("txtAge") as TextBox;
        TextBox txtEmail = row.FindControl("txtSalary") as TextBox;
        using (sisEntities2 context = new sisEntities2())
        {
            int id = Convert.ToInt32(gridSample.DataKeys[e.RowIndex].Value);
            String name = txtFirstName.Text;
            String email = txtLastName.Text;
            String mno = txtEmail.Text;
            
            tbl_membermaster_provider.EditUpdate(id, name, email, mno);


            BindGrid();

        }
    }
}
