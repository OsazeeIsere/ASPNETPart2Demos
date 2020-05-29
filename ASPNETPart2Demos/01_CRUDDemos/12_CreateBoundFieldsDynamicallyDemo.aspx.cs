using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _12_CreateBoundFieldsDynamicallyDemo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CreateBoundFields();
            BindData();
        }
    }

    private void BindData()
    {
        Employee x = new Employee();
        GridView1.DataSource = x.GetEmployees();
        GridView1.DataBind();
    }

    private void CreateBoundFields()
    {
        BoundField bfield = new BoundField();
        bfield.HeaderText = "EmployeeID";
        bfield.DataField = "EmployeeID";
        GridView1.Columns.Add(bfield);

        bfield = new BoundField();
        bfield.HeaderText = "LastName";
        bfield.DataField = "LastName";
        GridView1.Columns.Add(bfield);

        bfield = new BoundField();
        bfield.HeaderText = "FirstName";
        bfield.DataField = "FirstName";
        GridView1.Columns.Add(bfield);

        bfield = new BoundField();
        bfield.HeaderText = "Title";
        bfield.DataField = "Title";
        GridView1.Columns.Add(bfield);

        bfield = new BoundField();
        bfield.HeaderText = "TitleOfCourtesy";
        bfield.DataField = "TitleOfCourtesy";
        GridView1.Columns.Add(bfield);

        TemplateField tfield = new TemplateField();
        tfield.HeaderText = "Country";
        GridView1.Columns.Add(tfield);

    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            (e.Row.FindControl("lblRowNumber") as Label).Text = (e.Row.RowIndex + 1).ToString();

            TextBox txtCountry = new TextBox();
            txtCountry.ID = "txtCountry";
            txtCountry.Text = (e.Row.DataItem as DataRowView).Row["Country"].ToString();
            e.Row.Cells[7].Controls.Add(txtCountry);

            e.Row.ToolTip = (e.Row.DataItem as DataRowView)["LastName"].ToString();


        }


    }

    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedItem.Value.Equals("No"))
        {
            GridView1.Columns[7].Visible = false;
        }
        else
        {
            GridView1.Columns[7].Visible = true;
        }
        BindData();

    }
}