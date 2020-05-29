using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class _03_GridViewWithControlDemos_01_GridViewWithDropDownListDemo : System.Web.UI.Page
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
        Products p = new Products();
        DataSet dSet = p.GetProducts();
        GridView1.DataSource = dSet;
        GridView1.DataBind();

    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        BindData();

    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Products pr = new Products();

        GridViewRow gvr = GridView1.Rows[e.RowIndex];

        pr.ProductID = Convert.ToInt32(((TextBox)gvr.Cells[1].Controls[0]).Text);
        //pr.ProductName = ((TextBox)gvr.Cells[2].Controls[0]).Text;

        pr.ProductName = ((TextBox)gvr.Cells[2].Controls[1]).Text;

        pr.QuantityPerUnit = ((TextBox)gvr.Cells[3].Controls[0]).Text;
        pr.UnitPrice = Convert.ToDouble(((TextBox)gvr.Cells[4].Controls[0]).Text);

        pr.UnitsInStock = Convert.ToInt32(((TextBox)gvr.Cells[5].Controls[0]).Text);
        pr.UnitsOnOrder = Convert.ToInt32(((TextBox)gvr.Cells[6].Controls[0]).Text);
        pr.ReorderLevel = Convert.ToInt32(((TextBox)gvr.Cells[7].Controls[0]).Text);

        pr.Discontinued = Convert.ToBoolean((GridView1.Rows[e.RowIndex].FindControl("CheckBox1") as CheckBox).Checked);
        //pr.Discontinued  = Convert.ToBoolean(((TextBox)gvr.Cells[8].Controls[0]).Text);
        //pr.MFDate = Convert.ToDateTime(((TextBox)gvr.Cells[9].Controls[0]).Text);

        pr.MFDate = Convert.ToDateTime(((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox4")).Text);

        pr.SupplierID = Convert.ToInt32((GridView1.Rows[e.RowIndex].FindControl("DropDownList1") as DropDownList).SelectedItem.Value);
        pr.CategoryID = Convert.ToInt32((GridView1.Rows[e.RowIndex].FindControl("DropDownList2") as DropDownList).SelectedItem.Value);

        int Counter = pr.UpdateProduct();

        GridView1.EditIndex = -1;
        BindData();

    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Suppliers supp = new Suppliers();
        Categories cate = new Categories();
        if (e.Row.RowType == DataControlRowType.DataRow && GridView1.EditIndex == e.Row.RowIndex)
        {
            DropDownList ddlSuppliers = (DropDownList)e.Row.FindControl("DropDownList1");

            ddlSuppliers.DataSource = supp.GetSuppliers();
            ddlSuppliers.DataTextField = "CompanyName";
            ddlSuppliers.DataValueField = "SupplierID";
            ddlSuppliers.DataBind();
            ddlSuppliers.Items.FindByText((e.Row.FindControl("TextBox1") as TextBox).Text).Selected = true;

            DropDownList ddlCategories = (DropDownList)e.Row.FindControl("DropDownList2");

            ddlCategories.DataSource = cate.GetCategoryNames();
            ddlCategories.DataTextField = "CategoryName";
            ddlCategories.DataValueField = "CategoryID";
            ddlCategories.DataBind();

            ddlCategories.Items.FindByText((e.Row.FindControl("TextBox2") as TextBox).Text).Selected = true;


        }
    }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        BindData();

    }
}