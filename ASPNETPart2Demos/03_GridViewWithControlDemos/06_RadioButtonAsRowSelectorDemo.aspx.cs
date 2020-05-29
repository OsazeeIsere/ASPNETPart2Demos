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

    protected void Button1_Click(object sender, EventArgs e)
    {
        string selectedValue = Request.Form["radBestEmployee"];


        Label1.Text = selectedValue;

    }
}