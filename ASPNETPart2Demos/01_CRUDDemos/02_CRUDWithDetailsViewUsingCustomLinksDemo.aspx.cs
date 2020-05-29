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
        x.LastName = (DetailsView1.Rows[1].Cells[1].Controls[0] as TextBox).Text;
        x.FirstName = (DetailsView1.Rows[2].Cells[1].Controls[0] as TextBox).Text;
        x.Title = (DetailsView1.Rows[3].Cells[1].Controls[0] as TextBox).Text;
        x.TitleOfCourtesy = (DetailsView1.Rows[4].Cells[1].Controls[0] as TextBox).Text;

        int Counter = x.InsertEmployee();

        DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
        BindData();

    }

    protected void DetailsView1_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        Employee x = new Employee();
        x.EmployeeID = Convert.ToInt32(DetailsView1.DataKey["EmployeeId"]);
        x.LastName = (DetailsView1.Rows[1].Cells[1].Controls[0] as TextBox).Text;
        x.FirstName = (DetailsView1.Rows[2].Cells[1].Controls[0] as TextBox).Text;
        x.Title = (DetailsView1.Rows[3].Cells[1].Controls[0] as TextBox).Text;
        x.TitleOfCourtesy = (DetailsView1.Rows[4].Cells[1].Controls[0] as TextBox).Text;

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

    protected void DetailsView1_ItemCommand(object sender, DetailsViewCommandEventArgs e)
    {
        // this code is important if u have to change the button comand name e.g New to Newww
        if (e.CommandName == "Newww")
            DetailsView1.ChangeMode(DetailsViewMode.Insert);

    }
}