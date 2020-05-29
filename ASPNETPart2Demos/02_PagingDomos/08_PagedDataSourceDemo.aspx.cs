using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PagingDomos_08_PagedDataSourceDemo : System.Web.UI.Page
{
    public static int currentPageIndex = 0;
    public const int PAGESIZE = 3;
    public static int totalRecords;
    public static int maxNumberOfPages;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            InitializePagingSetup();
            BindData(currentPageIndex, PAGESIZE);

        }

    }
    private void InitializePagingSetup()
    {
        Employee emp = new Employee();
        currentPageIndex = 0;
        totalRecords = emp.GetCountOfEmployees();
        maxNumberOfPages = totalRecords / PAGESIZE;
    }

    private void BindData(int PageIndex = 1, int PageSize = 3)
    {
        Employee emp = new Employee();
        PagedDataSource pagedDataSource = new PagedDataSource();
        pagedDataSource.PageSize = PageSize;
        pagedDataSource.CurrentPageIndex = PageIndex;
        pagedDataSource.AllowPaging = true;

        pagedDataSource.DataSource = emp.GetEmployeesUsingReader();
        Repeater1.DataSource = pagedDataSource;
        Repeater1.DataBind();


    }


    protected void FirstPage(object sender, EventArgs e)
    {
        currentPageIndex = 0;
        BindData(currentPageIndex, PAGESIZE);

    }

    protected void PreviousPage(object sender, EventArgs e)
    {
        currentPageIndex--;
        if (currentPageIndex < 0)
            currentPageIndex = 0;
        BindData(currentPageIndex, PAGESIZE);

    }

    protected void NextPage(object sender, EventArgs e)
    {
        currentPageIndex++;
        if (currentPageIndex > maxNumberOfPages)

            currentPageIndex = maxNumberOfPages;
        BindData(currentPageIndex, PAGESIZE);
    }

    protected void LastPage(object sender, EventArgs e)
    {
        currentPageIndex = maxNumberOfPages;
        BindData(currentPageIndex, PAGESIZE);

    }
}