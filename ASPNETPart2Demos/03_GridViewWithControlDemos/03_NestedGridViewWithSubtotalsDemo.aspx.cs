using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _03_GridViewWithControlDemos_03_NestedGridViewWithSubtotalsDemo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    private void BindData()
    {
        Orders o = new Orders();
        DataSet dSet = o.GetOrdersInfo();

        int RowCount = dSet.Tables[1].Rows.Count - 1;
        decimal GrandTotal = Convert.ToDecimal(dSet.Tables[1].Rows[RowCount][1].ToString());
        ViewState["GrandTotal"] = GrandTotal;


        GridView1.DataSource = dSet;
        GridView1.DataBind();

    }

    private void AddTotalRow(string cellText, string CellValue)
    {
        GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Normal);
        row.BackColor = ColorTranslator.FromHtml("#F9F9F9");

        row.Cells.AddRange(new TableCell[4] {new TableCell (),new TableCell (),
                                        new TableCell { Text = cellText, HorizontalAlign = HorizontalAlign.Right},
                                        new TableCell { Text = CellValue, HorizontalAlign = HorizontalAlign.Right } });

        GridView1.Controls[0].Controls.Add(row);
    }



       protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        Orders o = new Orders();
        DataSet dSet = new DataSet();
        decimal SubTotal = 0;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string orderID = GridView1.DataKeys[e.Row.RowIndex].Value.ToString();
            GridView gvOrders = e.Row.FindControl("gvOrders") as GridView;
            dSet = o.GetOrderDetails(Convert.ToInt32(orderID));
            gvOrders.DataSource = dSet.Tables[0].DefaultView;
            gvOrders.DataBind();

            SubTotal = Convert.ToDecimal(dSet.Tables[1].Rows[0][1]);
            this.AddTotalRow("Sub Total", SubTotal.ToString("C2"));
        }

    }

    protected void GridView1_DataBound1(object sender, EventArgs e)
    {
        decimal GrandTotal = Convert.ToDecimal(ViewState["GrandTotal"].ToString());
        this.AddTotalRow("Grand Total", GrandTotal.ToString("C2"));

    }
}