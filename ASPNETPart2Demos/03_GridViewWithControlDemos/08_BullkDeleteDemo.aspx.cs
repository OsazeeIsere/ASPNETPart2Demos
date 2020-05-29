using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _03_GridViewControlDemos_08_BullkDeleteDemo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Employee emp = new Employee();
            BindData();
        }

    }
    private void BindData()
    {
        Employee emp = new Employee();

        DataSet dSet = emp.GetEmployees();
        GridView1.DataSource = dSet;
        GridView1.DataBind();
    }
        protected void Button1_Click(object sender, EventArgs e)
    {
            ArrayList al = new ArrayList();

            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                    if (chkRow.Checked)
                    {

                        al.Add(row.Cells[1].Text);
                    }

                }
            }
            string[] array = al.ToArray(typeof(string)) as string[];

            string csvEmployeeIDs = string.Join(", ", array);

            Employee emp = new Employee();
            int Counter = emp.BulkDeleteEmployees(csvEmployeeIDs);
            BindData();
        }
}