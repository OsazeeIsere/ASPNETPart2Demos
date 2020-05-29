using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _06 : System.Web.UI.Page
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
        ListView1.DataSource = dSet;
        ListView1.DataBind();
    }


    protected void ListView1_ItemInserting(object sender, ListViewInsertEventArgs e)
    {
        Employee x = new Employee();


        x.LastName = ((TextBox)e.Item.FindControl("TextBox6")).Text;
        x.FirstName = ((TextBox)e.Item.FindControl("TextBox7")).Text;
        x.Title = ((TextBox)e.Item.FindControl("TextBox8")).Text;
        x.TitleOfCourtesy = ((TextBox)e.Item.FindControl("TextBox9")).Text;

        int Counter = x.InsertEmployee();

        ListView1.EditIndex = -1;
        BindData();

    }

    protected void ListView1_ItemEditing(object sender, ListViewEditEventArgs e)
    {
        ListView1.EditIndex = e.NewEditIndex;
        BindData();
    }

    protected void ListView1_ItemUpdating(object sender, ListViewUpdateEventArgs e)
    {
        Employee x = new Employee();
        x.EmployeeID = Convert.ToInt32(ListView1.DataKeys[e.ItemIndex].Value.ToString());
        x.LastName = ((TextBox)ListView1.Items[e.ItemIndex].FindControl("TextBox2")).Text;
        x.FirstName = ((TextBox)ListView1.Items[e.ItemIndex].FindControl("TextBox3")).Text;
        x.Title = ((TextBox)ListView1.Items[e.ItemIndex].FindControl("TextBox4")).Text;
        x.TitleOfCourtesy = ((TextBox)ListView1.Items[e.ItemIndex].FindControl("TextBox5")).Text;

        int Counter = x.UpdateEmployee();

        ListView1.EditIndex = -1;
        BindData();

    }

    protected void ListView1_ItemCanceling(object sender, ListViewCancelEventArgs e)
    {
        ListView1.EditIndex = -1;
        BindData();

    }

    protected void ListView1_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {
        Employee x = new Employee();
        x.EmployeeID = Convert.ToInt32(ListView1.DataKeys[e.ItemIndex].Value.ToString());
        int Counter = x.DeleteEmployee();

        ListView1.EditIndex = -1;
        BindData();

    }
}
