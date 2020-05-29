using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _07_CRUDWithRepeaterDemos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindData();

        }
    }

    private void BindData(int currentPageIndex = 1)
    {
        Employee emp = new Employee();

        // DataSet dSet = emp.GetEmployees();
        DataSet dSet = emp.GetPagedEmployees(currentPageIndex, 3);

        Repeater1.DataSource = dSet;
        Repeater1.DataBind();
        int recordCount = emp.GetCountOfEmployees();

        this.DisplayPageNumbers(recordCount, currentPageIndex);
    }
    private void DisplayPageNumbers(int TotalRows, int currentPage)
    {

        double TotalNumberOfPages = Math.Ceiling(Convert.ToDouble(TotalRows) / 3);
        List<ListItem> lstPages = new List<ListItem>();
        if (TotalNumberOfPages > 0)
        {
            for (int i = 1; i <= TotalNumberOfPages; i++)
            {
                lstPages.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }
        rptPager.DataSource = lstPages;
        rptPager.DataBind();
    }
    protected void PageIndex_Changed(object sender, EventArgs e)
    {
        int currentPageIndex = int.Parse((sender as LinkButton).CommandArgument);
        BindData(currentPageIndex);

    }


    protected void OnInsert(object sender, EventArgs e)
    {
        Employee x = new Employee();
        x.LastName = TextBox2.Text;
        x.FirstName = TextBox3.Text;
        x.Title = TextBox4.Text;
        x.TitleOfCourtesy = TextBox5.Text;

        int Counter = x.InsertEmployee();
        BindData();

        TextBox1.Text = string.Empty;
        TextBox2.Text = string.Empty;
        TextBox3.Text = string.Empty;
        TextBox4.Text = string.Empty;
        TextBox5.Text = string.Empty;

    }
    protected void OnEdit(object sender, EventArgs e)
    {

        RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
        this.ShowHideButtons(item, true);
    }
    private void ShowHideButtons(RepeaterItem item, bool isEdit)
    {

        item.FindControl("lnkEdit").Visible = !isEdit;
        item.FindControl("lnkUpdate").Visible = isEdit;
        item.FindControl("lnkCancel").Visible = isEdit;
        item.FindControl("lnkDelete").Visible = !isEdit;

        if (isEdit)
        {
            lnkInsert.Visible = false;
            TextBox1.Visible = true;
            TextBox1.Text = ((Label)item.FindControl("Label1")).Text;
            TextBox2.Text = ((Label)item.FindControl("Label2")).Text;
            TextBox3.Text = ((Label)item.FindControl("Label3")).Text;
            TextBox4.Text = ((Label)item.FindControl("Label4")).Text;
            TextBox5.Text = ((Label)item.FindControl("Label5")).Text;
        }
        else
        {
            lnkInsert.Visible = true;
            TextBox1.Visible = true;
            TextBox1.Text = string.Empty;
            TextBox2.Text = string.Empty;
            TextBox3.Text = string.Empty;
            TextBox4.Text = string.Empty;
            TextBox5.Text = string.Empty;
        }

    }
    protected void OnUpdate(object sender, EventArgs e)
    {
        TextBox1.Visible = true;
        Employee x = new Employee();
        x.EmployeeID = Convert.ToInt32(TextBox1.Text);
        x.LastName = TextBox2.Text;
        x.FirstName = TextBox3.Text;
        x.Title = TextBox4.Text;
        x.TitleOfCourtesy = TextBox5.Text;

        int Counter = x.UpdateEmployee();
        BindData();

        TextBox1.Text = string.Empty;
        TextBox2.Text = string.Empty;
        TextBox3.Text = string.Empty;
        TextBox4.Text = string.Empty;
        TextBox5.Text = string.Empty;

        lnkInsert.Visible = true;
    }

    protected void OnCancel(object sender, EventArgs e)
    {

        RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
        this.ShowHideButtons(item, false);
    }

    protected void OnDelete(object sender, EventArgs e)
    {
        RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
        Employee x = new Employee();
        x.EmployeeID = int.Parse((item.FindControl("Label1") as Label).Text);
        int Counter = x.DeleteEmployee();
        BindData();
    }



    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }
}