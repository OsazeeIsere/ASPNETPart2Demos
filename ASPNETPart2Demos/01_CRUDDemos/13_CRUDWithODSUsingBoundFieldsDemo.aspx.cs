using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _01_CRUDDemos_13_CRUDWithODSUsingBoundFieldsDemo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        EmployeeBO emp = new EmployeeBO();
        emp.LastName = TextBox1.Text;
        emp.FirstName = TextBox2.Text;
        emp.Title = TextBox3.Text;
        emp.TitleOfCourtesy = TextBox4.Text;

        int Counter = emp.InsertEmployee(emp);
    }

}