using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _04_CRUDWithFornView : System.Web.UI.Page
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
        FormView1.DataSource = dSet;
        FormView1.DataBind();
    }


    protected void FormView1_PageIndexChanging(object sender, FormViewPageEventArgs e)
    {
        FormView1.PageIndex = e.NewPageIndex;
        BindData();

    }

    protected void FormView1_ModeChanging(object sender, FormViewModeEventArgs e)
    {
        FormView1.ChangeMode(e.NewMode);
        BindData();

    }

    protected void FormView1_ItemInserting(object sender, FormViewInsertEventArgs e)
    {
        TextBox t1 = (TextBox)((FormView)sender).FindControl("TextBox2");
        TextBox t2 = (TextBox)((FormView)sender).FindControl("TextBox3");
        TextBox t3 = (TextBox)((FormView)sender).FindControl("TextBox4");
        TextBox t4 = (TextBox)((FormView)sender).FindControl("TextBox5");


        Employee x = new Employee();
        x.LastName = t1.Text;
        x.FirstName = t2.Text;
        x.Title = t3.Text;
        x.TitleOfCourtesy = t4.Text;

        int Counter = x.InsertEmployee();
        FormView1.ChangeMode(FormViewMode.ReadOnly);
        BindData();

    }

    protected void FormView1_ItemUpdating(object sender, FormViewUpdateEventArgs e)
    {
        TextBox t1 = (TextBox)((FormView)sender).FindControl("TextBox2");
        TextBox t2 = (TextBox)((FormView)sender).FindControl("TextBox3");
        TextBox t3 = (TextBox)((FormView)sender).FindControl("TextBox4");
        TextBox t4 = (TextBox)((FormView)sender).FindControl("TextBox5");

        Employee x = new Employee();
        x.EmployeeID = Convert.ToInt32(FormView1.DataKey["EmployeeId"]);
        x.LastName = t1.Text;
        x.FirstName = t2.Text;
        x.Title = t3.Text;
        x.TitleOfCourtesy = t4.Text;

        int Counter = x.UpdateEmployee();
        FormView1.ChangeMode(FormViewMode.ReadOnly);
        BindData();

    }

    protected void FormView1_ItemDeleting(object sender, FormViewDeleteEventArgs e)
    {
        Employee x = new Employee();

        x.EmployeeID = Convert.ToInt32(FormView1.DataKey["EmployeeId"]);
        int Counter = x.DeleteEmployee();
        FormView1.ChangeMode(FormViewMode.ReadOnly);
        BindData();

    }

    protected void FormView1_ItemCommand(object sender, FormViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Delete"))
        {
            FormView1.ChangeMode(FormViewMode.ReadOnly);
            BindData();
        }
    }
}