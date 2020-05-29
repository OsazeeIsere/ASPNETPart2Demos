using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _01_CRUDWithDetailsViewUsingBoundFieldsDemo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindData();

        }

    }
    private void BindData()
    {
        Employee emp = new Employee();

        DataSet dSet = emp.GetEmployees();
        DetailsView1.DataSource = dSet;
        DetailsView1.DataBind();
    }


    protected void DetailsView1_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
    {
        DetailsView1.PageIndex = e.NewPageIndex;
        BindData();

    }

    protected void DetailsView1_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        DetailsView1.ChangeMode(e.NewMode);
        BindData();

    }

    protected void DetailsView1_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
        Employee x = new Employee();

        TextBox t1 = (TextBox)((DetailsView)sender).FindControl("TextBox2");
        TextBox t2 = (TextBox)((DetailsView)sender).FindControl("TextBox3");
        TextBox t3 = (TextBox)((DetailsView)sender).FindControl("TextBox4");
        TextBox t4 = (TextBox)((DetailsView)sender).FindControl("TextBox5");

        x.LastName = t1.Text;
        x.FirstName = t2.Text;
        x.Title = t3.Text;
        x.TitleOfCourtesy = t4.Text;

        int Counter = x.InsertEmployee();

        DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
        BindData();

    }

    protected void DetailsView1_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        Employee x = new Employee();
        x.EmployeeID = Convert.ToInt32(DetailsView1.DataKey["EmployeeId"]);
        TextBox t1 = (TextBox)((DetailsView)sender).FindControl("TextBox2");
        TextBox t2 = (TextBox)((DetailsView)sender).FindControl("TextBox3");
        TextBox t3 = (TextBox)((DetailsView)sender).FindControl("TextBox4");
        TextBox t4 = (TextBox)((DetailsView)sender).FindControl("TextBox5");

        x.LastName = t1.Text;
        x.FirstName = t2.Text;
        x.Title = t3.Text;
        x.TitleOfCourtesy = t4.Text;


        int Counter = x.UpdateEmployee();


        DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
        BindData();

    }

    protected void DetailsView1_ItemDeleting(object sender, DetailsViewDeleteEventArgs e)
    {
        Employee x = new Employee();
        x.EmployeeID = Convert.ToInt32(DetailsView1.DataKey["EmployeeId"]);

        int Counter = x.DeleteEmployee();

        DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
        BindData();

    }
}