using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _01_CRUDDemos_15_CRUDUsingLINQDemo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            this.BindData();
        }
    }

    private void BindData()
    {
        using (NorthwindDBDataContext ctx = new NorthwindDBDataContext())
        {
            GridView1.DataSource = from employee in ctx.Employees
                                   select employee;
            GridView1.DataBind();
        }

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        GridViewRow gvr = GridView1.FooterRow;

        string LastName, FirstName, Title, TitleOfCourtesy;


        LastName = (gvr.FindControl("TextBox2") as TextBox).Text;
        FirstName = (gvr.FindControl("TextBox3") as TextBox).Text;
        Title = (gvr.FindControl("TextBox4") as TextBox).Text;
        TitleOfCourtesy = (gvr.FindControl("TextBox5") as TextBox).Text;


        using (NorthwindDBDataContext ctx = new NorthwindDBDataContext())
        {
            Employees employee = new Employees
            {
                LastName = LastName,
                FirstName = FirstName,
                Title = Title,
                TitleOfCourtesy = TitleOfCourtesy
            };

            ctx.Employees.InsertOnSubmit(employee);
            ctx.SubmitChanges();
        }

        BindData();


    }


    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        this.BindData();
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        this.BindData();

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

        using (NorthwindDBDataContext ctx = new NorthwindDBDataContext())
        {
            Employees employee = (from c in ctx.Employees
                                  where c.EmployeeID == EmployeeID
                                  select c).FirstOrDefault();


            employee.LastName = LastName;
            employee.FirstName = FirstName;
            employee.Title = Title;
            employee.TitleOfCourtesy = TitleOfCourtesy;


            ctx.SubmitChanges();
        }
        GridView1.EditIndex = -1;
        BindData();


    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != GridView1.EditIndex)
        {
            (e.Row.Cells[0].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
        }

    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int EmployeeID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);

        using (NorthwindDBDataContext ctx = new NorthwindDBDataContext())
        {
            Employees employee = (from c in ctx.Employees
                                  where c.EmployeeID == EmployeeID
                                  select c).FirstOrDefault();


            ctx.Employees.DeleteOnSubmit(employee);


            ctx.SubmitChanges();
        }
        GridView1.EditIndex = -1;
        BindData();

    }
}