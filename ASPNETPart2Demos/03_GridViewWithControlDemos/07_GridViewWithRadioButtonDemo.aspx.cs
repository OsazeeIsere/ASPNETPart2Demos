using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _03_GridViewWithControlDemos_06_RadioButtonAsRowSelectorDemo : System.Web.UI.Page
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

    
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Employee emp = new Employee();
        GridViewRow gvr = GridView1.Rows[e.RowIndex];

        emp.EmployeeID = Convert.ToInt32(gvr.Cells[1].Text);

        emp.LastName = ((TextBox)gvr.Cells[2].Controls[0]).Text;
        emp.FirstName = ((TextBox)gvr.Cells[3].Controls[0]).Text;
        emp.Title = ((TextBox)gvr.Cells[4].Controls[0]).Text;
        emp.TitleOfCourtesy = ((TextBox)gvr.Cells[5].Controls[0]).Text;

        bool blYes = (gvr.FindControl("RadioButton1") as RadioButton).Checked;
        bool blNo = (gvr.FindControl("RadioButton2") as RadioButton).Checked;

        if (blYes)
            emp.IsCertified = true;
        else
            emp.IsCertified = false;

        int Counter = emp.UpdateEmployeeCertDetails();
        GridView1.EditIndex = -1;
        BindData();

    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        BindData();

    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            bool blIsCertified = (bool)DataBinder.Eval(e.Row.DataItem, "IsCertified");
            RadioButton rbYes = (RadioButton)e.Row.FindControl("RadioButton1");
            RadioButton rbNo = (RadioButton)e.Row.FindControl("RadioButton2");

            if (blIsCertified)
                rbYes.Checked = true;
            else
                rbNo.Checked = true;


        }

    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        BindData();
    }
}