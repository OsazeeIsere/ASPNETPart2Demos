using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _08_CRUDWithGridViewUsingBoundFieldDemo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //Employee emp = new Employee();
            //GridView1.VirtualItemCount = emp.GetCountOfEmployees();
            //GridView1.PageIndex = 0;
            BindData();
          //  ViewState["PageIndex"] = 1;
        }
    }

    private void BindData()
    {
        Employee emp = new Employee();

        DataSet dSet = emp.GetEmployees();
       // DataSet dSet = emp.GetPagedEmployees(currentPageIndex, 3);

        //DataView dv = dSet.Tables[0].DefaultView;

        //dv.Sort = sortExpression;

        GridView1.DataSource = dSet;
        GridView1.DataBind();

    }

    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {

    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        BindData();
       // ViewState["PageIndex"] = e.NewPageIndex + 1;

    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        BindData();

    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        BindData();

    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Employee emp = new Employee();
        GridViewRow gvr = GridView1.Rows[e.RowIndex];



        emp.EmployeeID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);

        emp.LastName = (gvr.FindControl("TextBox2") as TextBox).Text;
        emp.FirstName = (gvr.FindControl("TextBox3") as TextBox).Text;
        emp.Title = (gvr.FindControl("TextBox4") as TextBox).Text;
        emp.TitleOfCourtesy = (gvr.FindControl("TextBox5") as TextBox).Text;

        int Counter = emp.UpdateEmployee();
        GridView1.EditIndex = -1;
        BindData();

    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Employee x = new Employee();
        x.EmployeeID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
        int Counter = x.DeleteEmployee();
        BindData();

    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != GridView1.EditIndex)
        {
            (e.Row.Cells[0].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
        }
    }
}