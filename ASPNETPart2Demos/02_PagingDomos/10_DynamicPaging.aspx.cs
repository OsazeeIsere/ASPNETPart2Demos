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
            Employee emp = new Employee();

            int TotalRows = emp.GetCountOfEmployees();
            ViewState["TotalRows"] = TotalRows.ToString();

            GridView1.VirtualItemCount = TotalRows;
            GridView1.PageIndex = 0;
            BindData();
            ViewState["PageIndex"] = 1;

            FillPageNumbers(0, 5, TotalRows);
        }

    }
    private void FillPageNumbers(int CurrentPage, int PageSize, int TotalRows)
    {
        int totalPages = TotalRows / PageSize;
        if ((TotalRows % PageSize) != 0)
        {
            totalPages += 1;
        }
        if (totalPages > 1)
        {
            DropDownList2.Enabled = true;
            DropDownList2.Items.Clear();
            for (int i = 1; i <= totalPages; i++)
            {
                DropDownList2.Items.Add(new
                    ListItem(i.ToString(), i.ToString()));
            }
        }
        else
        {
            DropDownList2.SelectedIndex = 0;
            DropDownList2.Enabled = false;
        }
    }
    private void BindData(int currentPageIndex = 1, string sortExpression = "EmployeeID", int PageSize = 5)
    {
        Employee emp = new Employee();

        // DataSet dSet = emp.GetEmployees();
        DataSet dSet = emp.GetPagedEmployees(currentPageIndex, PageSize);

        DataView dv = dSet.Tables[0].DefaultView;

        dv.Sort = sortExpression;

        GridView1.DataSource = dv;
        GridView1.DataBind();
    }



    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {

    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        BindData(e.NewPageIndex + 1);
        ViewState["PageIndex"] = e.NewPageIndex + 1;

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

        emp.EmployeeID = Convert.ToInt32(gvr.Cells[1].Text);

        emp.LastName = ((TextBox)gvr.Cells[2].Controls[0]).Text;
        emp.FirstName = ((TextBox)gvr.Cells[3].Controls[0]).Text;
        emp.Title = ((TextBox)gvr.Cells[4].Controls[0]).Text;
        emp.TitleOfCourtesy = ((TextBox)gvr.Cells[5].Controls[0]).Text;

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
    private string SortDirection
    {
        get { return ViewState["SortDirection"] != null ? ViewState["SortDirection"].ToString() : "ASC"; }
        set { ViewState["SortDirection"] = value; }
    }

    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        int PageIndex = Convert.ToInt32(ViewState["PageIndex"].ToString());
        this.SortDirection = this.SortDirection.ToString() == "ASC" ? "DESC" : "ASC";

        //employeeid asc employeeid desc
        BindData(PageIndex, e.SortExpression + " " + this.SortDirection);


    }

    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int PageSize = Convert.ToInt32(DropDownList1.SelectedItem.Value);
        int CurrentPageIndex = 1;
        int TotalRows = Convert.ToInt32(ViewState["TotalRows"].ToString());

        GridView1.PageSize = PageSize;
        BindData(CurrentPageIndex, "", PageSize);
        FillPageNumbers(CurrentPageIndex, PageSize, TotalRows);

    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        int PageSize = Convert.ToInt32(DropDownList1.SelectedItem.Value);
        int CurrentPageIndex = Convert.ToInt32(DropDownList2.SelectedItem.Value);

        int TotalRows = Convert.ToInt32(ViewState["TotalRows"].ToString());

        GridView1.PageSize = PageSize;
        BindData(CurrentPageIndex, "", PageSize);

    }
}