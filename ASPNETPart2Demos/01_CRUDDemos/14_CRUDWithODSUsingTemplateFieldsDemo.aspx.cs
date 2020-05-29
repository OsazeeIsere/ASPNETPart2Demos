using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _01_CRUDDemos_13_CRUDWithODSUsingBoundFieldsDemo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lnkButton1_Click(object sender, EventArgs e)
    {
        EmployeeBOT emp = new EmployeeBOT();
        GridViewRow gvr = GridView1.FooterRow;

        string LastName, FirstName, Title, TitleOfCourtesy;

        LastName = (gvr.FindControl("TextBox12") as TextBox).Text;
        FirstName = (gvr.FindControl("TextBox13") as TextBox).Text;
        Title = (gvr.FindControl("TextBox14") as TextBox).Text;
        TitleOfCourtesy = (gvr.FindControl("TextBox15") as TextBox).Text;

        ObjectDataSource1.InsertParameters["LastName"].DefaultValue = LastName;
        ObjectDataSource1.InsertParameters["FirstName"].DefaultValue = FirstName;
        ObjectDataSource1.InsertParameters["Title"].DefaultValue = Title;
        ObjectDataSource1.InsertParameters["TitleOfCourtesy"].DefaultValue = TitleOfCourtesy;

        ObjectDataSource1.Insert();

    }


    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow gvr = GridView1.Rows[e.RowIndex];

        int EmployeeID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);


        ObjectDataSource1.DeleteParameters["EmployeeID"].DefaultValue = EmployeeID.ToString();
        ObjectDataSource1.Delete();

    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow gvr = GridView1.Rows[e.RowIndex];

        int EmployeeID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);

        string LastName, FirstName, Title, TitleOfCourtesy;

        LastName = (gvr.FindControl("TextBox2") as TextBox).Text;
        FirstName = (gvr.FindControl("TextBox3") as TextBox).Text;
        Title = (gvr.FindControl("TextBox4") as TextBox).Text;
        TitleOfCourtesy = (gvr.FindControl("TextBox5") as TextBox).Text;

        ObjectDataSource1.UpdateParameters["EmployeeID"].DefaultValue = EmployeeID.ToString();
        ObjectDataSource1.UpdateParameters["LastName"].DefaultValue = LastName;
        ObjectDataSource1.UpdateParameters["FirstName"].DefaultValue = FirstName;
        ObjectDataSource1.UpdateParameters["Title"].DefaultValue = Title;
        ObjectDataSource1.UpdateParameters["TitleOfCourtesy"].DefaultValue = TitleOfCourtesy;

        ObjectDataSource1.Update();

    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}