using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _03_GridViewWithControlDemos_02_SubTotalDemo : System.Web.UI.Page
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
        DataSet dSet = o.GetOrders();
        GridView1.DataSource = dSet;
        GridView1.DataBind();

    }
    int currentOrderId = 0;

    decimal subTotal = 0;
    decimal total = 0;
    int subTotalRowIndex = 0;


    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        subTotal = 0;
        for (int i = subTotalRowIndex; i < GridView1.Rows.Count; i++)
        {
            subTotal += decimal.Parse(GridView1.Rows[i].Cells[6].Text, NumberStyles.Currency);
        }

        this.AddTotalRow("Sub Total", subTotal.ToString("C2"));
        this.AddTotalRow("Grand Total", total.ToString("C2"));
    }

    decimal RunningTotal = 0;
    decimal RunningOrderTotal = 0;
    int curOrderID = 0;
    private void AddTotalRow(string cellText, string CellValue)
    {
        GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Normal);
        row.BackColor = ColorTranslator.FromHtml("#F9F9F9");

        row.Cells.AddRange(new TableCell[7] { new TableCell (),new TableCell (),new TableCell (),new TableCell (),new TableCell (), //Empty Cell
                                        new TableCell { Text = cellText, HorizontalAlign = HorizontalAlign.Right},
                                        new TableCell { Text = CellValue, HorizontalAlign = HorizontalAlign.Right } });

        GridView1.Controls[0].Controls.Add(row);
    }


    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            DataTable dt = (e.Row.DataItem as DataRowView).DataView.Table;
            int orderId = Convert.ToInt32(dt.Rows[e.Row.RowIndex]["OrderID"]);

            total += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["BillAmount"]);

            if (orderId != currentOrderId)
            {
                currentOrderId = orderId;
                RunningOrderTotal = 0;
                subTotal = 0;


                if (e.Row.RowIndex > 0)
                {
                    for (int i = subTotalRowIndex; i < e.Row.RowIndex; i++)
                    {
                        subTotal += decimal.Parse(GridView1.Rows[i].Cells[6].Text, NumberStyles.Currency);
                    }
                    subTotalRowIndex = e.Row.RowIndex;

                    this.AddTotalRow("Sub Total", subTotal.ToString("C2"));
                }

            }
        }

    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            int orderId = Convert.ToInt32(e.Row.Cells[0].Text);

            if (orderId != curOrderID)
            {
                curOrderID = orderId;
                RunningOrderTotal = 0;
            }


            decimal BillAmount = decimal.Parse(e.Row.Cells[6].Text, NumberStyles.Currency);
            RunningTotal += BillAmount;
            Label lblRunningTotal = e.Row.FindControl("lblRunningTotal") as Label;
            lblRunningTotal.Text = RunningTotal.ToString("C2");

            BillAmount = decimal.Parse(e.Row.Cells[6].Text, NumberStyles.Currency);
            RunningOrderTotal += BillAmount;
            Label lblRunningOrderTotal = e.Row.FindControl("lblRunningOrderTotal") as Label;
            lblRunningOrderTotal.Text = RunningOrderTotal.ToString("C2");

        }




    }
}
