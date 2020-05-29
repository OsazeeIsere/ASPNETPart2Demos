using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _05_CRUDWithDataListDemo : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindData();

        }

    }
    private void BindData(int currentPageIndex=1)
    {
        Employee emp = new Employee();

        // DataSet dSet = emp.GetEmployees();
        DataSet dSet = emp.GetPagedEmployees(currentPageIndex, 3);
        DataList1.DataSource = dSet;
        DataList1.DataBind();

        int recordCount = emp.GetCountOfEmployees();

        this.DisplayPageNumbers(recordCount, currentPageIndex);

    }
    private void DisplayPageNumbers(int TotalRows, int currentPage)
    {

        double TotalNumberOfPages = Math.Ceiling(Convert.ToDouble(TotalRows) / 3);
        List<ListItem> lstPages = new List<ListItem>();
        if (TotalNumberOfPages > 0)
        {
            for (int i = 1; i <= TotalNumberOfPages; i++)
            {
                lstPages.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }
        rptPager.DataSource = lstPages;
        rptPager.DataBind();
    }

    protected void PageIndex_Changed(object sender, EventArgs e)
    {
        int currentPageIndex = int.Parse((sender as LinkButton).CommandArgument);
        BindData(currentPageIndex);

    }

    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        string name = e.CommandName;

        if (name.Equals("Insert"))
        {
            Employee x = new Employee();

            x.LastName = ((TextBox)e.Item.FindControl("TextBox6")).Text;
            x.FirstName = ((TextBox)e.Item.FindControl("TextBox7")).Text;
            x.Title = ((TextBox)e.Item.FindControl("TextBox8")).Text;
            x.TitleOfCourtesy = ((TextBox)e.Item.FindControl("TextBox9")).Text;

            int Counter = x.InsertEmployee();

            BindData();
        }

    }

    protected void DataList1_EditCommand(object source, DataListCommandEventArgs e)
    {
        DataList1.EditItemIndex = e.Item.ItemIndex;
        BindData();

    }

    protected void DataList1_UpdateCommand(object source, DataListCommandEventArgs e)
    {
        Employee x = new Employee();
        x.EmployeeID = Convert.ToInt32(DataList1.DataKeys[e.Item.ItemIndex].ToString());
        x.LastName = ((TextBox)e.Item.FindControl("TextBox2")).Text;
        x.FirstName = ((TextBox)e.Item.FindControl("TextBox3")).Text;
        x.Title = ((TextBox)e.Item.FindControl("TextBox4")).Text;
        x.TitleOfCourtesy = ((TextBox)e.Item.FindControl("TextBox5")).Text;

        int Counter = x.UpdateEmployee();
        DataList1.EditItemIndex = -1;
        BindData();

    }

    protected void DataList1_CancelCommand(object source, DataListCommandEventArgs e)
    {
        DataList1.EditItemIndex = -1;
        BindData();
    }

    protected void DataList1_DeleteCommand(object source, DataListCommandEventArgs e)
    {
        Employee x = new Employee();
        x.EmployeeID = Convert.ToInt32(DataList1.DataKeys[e.Item.ItemIndex].ToString());
        int Counter = x.DeleteEmployee();
        BindData();
    }
}