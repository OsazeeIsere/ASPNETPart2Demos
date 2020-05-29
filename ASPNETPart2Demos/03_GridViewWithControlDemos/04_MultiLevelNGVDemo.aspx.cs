using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _03_GridViewWithControlDemos_04_MultiLevelNGVDemo : System.Web.UI.Page
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
        DataSet dSdet = emp.GetEmployees();
        GridView1.DataSource = dSdet;
        GridView1.DataBind();

    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Employee emp = new Employee();
        DataSet dSet = new DataSet();
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            emp.EmployeeID = Convert.ToInt32(GridView1.DataKeys[e.Row.RowIndex].Value.ToString());
            GridView gvOrders = e.Row.FindControl("gvOrders") as GridView;
            dSet = emp.GetEmployeeWiseOrders();
            gvOrders.DataSource = dSet;
            gvOrders.DataBind();

        }

    }
    protected void gvOrders_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Orders ord = new Orders();
        int OrderID = 0;
        DataSet dSet = new DataSet();
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblOrderID = (Label)e.Row.FindControl("lblOrderID");

            OrderID = Convert.ToInt32(lblOrderID.Text);

            GridView gvOrderDetails = e.Row.FindControl("gvOrderDetails") as GridView;
            dSet = ord.GetOrderIDWiseDetails(OrderID);
            gvOrderDetails.DataSource = dSet;
            gvOrderDetails.DataBind();
        }

    }

}