using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BulkInsertWithGridView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CreateEmptyTable();
        }
    }

    private void CreateEmptyTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[4] { new DataColumn("LastName", typeof(string)),
                        new DataColumn("FirstName", typeof(string)),
                        new DataColumn("Title",typeof(string)),
                        new DataColumn("TitleOfCourtesy")});

        DataRow dr;
        for (int i = 1; i <= 4; i++)
        {
            dr = dt.NewRow();
            dr[0] = string.Empty;
            dr[1] = string.Empty;
            dr[2] = string.Empty;
            dr[3] = string.Empty;

            dt.Rows.Add(dr);
        }

        GridView1.DataSource = dt;
        GridView1.DataBind();


    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[4] { new DataColumn("LastName", typeof(string)),
                        new DataColumn("FirstName", typeof(string)),
                        new DataColumn("Title",typeof(string)),
                        new DataColumn("TitleOfCourtesy")});

        foreach (GridViewRow row in GridView1.Rows)
        {
            DataRow dr = dt.NewRow();
            dr[0] = ((TextBox)row.Cells[0].FindControl("TextBox1")).Text;
            dr[1] = ((TextBox)row.Cells[0].FindControl("TextBox2")).Text;
            dr[2] = ((TextBox)row.Cells[0].FindControl("TextBox3")).Text;
            dr[3] = ((TextBox)row.Cells[0].FindControl("TextBox4")).Text;

            dt.Rows.Add(dr);

        }

        if (dt.Rows.Count > 0)
        {
            string consString = "data source=.;initial catalog=northwind;integrated security=true;";

            using (SqlConnection con = new SqlConnection(consString))
            {
                using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                {

                    sqlBulkCopy.DestinationTableName = "dbo.Employees";


                    sqlBulkCopy.ColumnMappings.Add("LastName", "LastName");
                    sqlBulkCopy.ColumnMappings.Add("FirstName", "FirstName");
                    sqlBulkCopy.ColumnMappings.Add("Title", "Title");
                    sqlBulkCopy.ColumnMappings.Add("TitleOfCourtesy", "TitleOfCourtesy");
                    con.Open();

                    sqlBulkCopy.BatchSize = 3;
                    sqlBulkCopy.NotifyAfter = 1;

                    sqlBulkCopy.SqlRowsCopied +=
                  new SqlRowsCopiedEventHandler(bulkCopy_RowsCopied);


                    sqlBulkCopy.WriteToServer(dt);
                    con.Close();
                }
            }
        }
    }

    private void bulkCopy_RowsCopied(object sender, SqlRowsCopiedEventArgs e)
    {
        Label1.Text = Label1.Text + "<h1>Records Inserted...</h1>";

    }
}