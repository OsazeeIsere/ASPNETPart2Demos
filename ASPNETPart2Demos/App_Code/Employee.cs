using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Employee
/// </summary>
public class Employee
{
    
    public Employee()
    {
        // TODO: Add constructor logic here
        //
    }

    public int EmployeeID { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string Title { get; set; }
    public string TitleOfCourtesy { get; set; }
    public object IsCertified { get; set; }

    public DataSet GetPagedEmployees(object currentPageIndex, int v)
    {
        throw new NotImplementedException();
    }

    public string GetCS()
    {
        string cs = "data source=.;initial catalog=Northwind;integrated security=true;";
        return (cs);
    }

    public System.Data.DataSet GetEmployees()
    {
        SqlConnection cn = new SqlConnection(GetCS());
        // SqlCommand cmd = new SqlCommand("select * from employees where employeeid <= 9", cn);
        SqlCommand cmd = new SqlCommand("select * from employees", cn);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataSet dSet = new DataSet();
        sda.Fill(dSet);
        //cn.Close();
        return (dSet);
    }

       public int InsertEmployee()
    {
        SqlConnection cn = null;
        SqlCommand cmd = null;
        int Counter = 0;

        try
        {
            cn = new SqlConnection(GetCS());
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "usp_Employees_Insert";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LastName", LastName);
            cmd.Parameters.AddWithValue("@FirstName", FirstName);
            cmd.Parameters.AddWithValue("@Title", Title);
            cmd.Parameters.AddWithValue("@TitleOfCourtesy", TitleOfCourtesy);

            cn.Open();
            Counter = cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            if (cn != null)
            {
                cn.Close();
                cn.Dispose();
                cn = null;
            }
        }
        return (Counter);
    }
    public int UpdateEmployee()
    {
        SqlConnection cn = null;
        SqlCommand cmd = null;
        int Counter = 0;

        try
        {
            cn = new SqlConnection(GetCS());
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "usp_Employees_Update";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@EmployeeId", EmployeeID);
            cmd.Parameters.AddWithValue("@LastName", LastName);
            cmd.Parameters.AddWithValue("@FirstName", FirstName);
            cmd.Parameters.AddWithValue("@Title", Title);
            cmd.Parameters.AddWithValue("@TitleOfCourtesy", TitleOfCourtesy);

            cn.Open();
            Counter = cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            if (cn != null)
            {
                cn.Close();
                cn.Dispose();
                cn = null;
            }
        }
        return (Counter);
    }

    public int UpdateEmployeeCertDetails()
    {
        SqlConnection cn = null;
        SqlCommand cmd = null;
        int Counter = 0;

        try
        {
            cn = new SqlConnection(GetCS());
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "usp_EmployeesCert_Update";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@EmployeeId", EmployeeID);
            cmd.Parameters.AddWithValue("@LastName", LastName);
            cmd.Parameters.AddWithValue("@FirstName", FirstName);
            cmd.Parameters.AddWithValue("@Title", Title);
            cmd.Parameters.AddWithValue("@TitleOfCourtesy", TitleOfCourtesy);
            cmd.Parameters.AddWithValue("@IsCertified", IsCertified);


            cn.Open();
            Counter = cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            if (cn != null)
            {
                cn.Close();
                cn.Dispose();
                cn = null;
            }
        }
        return (Counter);
    }
    public int DeleteEmployee()
    {
        SqlConnection cn = null;
        SqlCommand cmd = null;
        int Counter = 0;

        try
        {
            cn = new SqlConnection(GetCS());
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "usp_Employees_Delete";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);


            cn.Open();
            Counter = cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            if (cn != null)
            {
                cn.Close();
                cn.Dispose();
                cn = null;
            }
        }
        return (Counter);
    }
    public System.Data.DataSet GetPagedEmployees(int CurrentPage, int PageSize)
    {
        SqlConnection cn = new SqlConnection(GetCS());
        SqlCommand cmd = new SqlCommand("[usp_GetPageWiseEmployees]", cn);
        cmd.CommandType = CommandType.StoredProcedure;

        SqlParameter p1 = new SqlParameter("@PageSize", SqlDbType.Int, 4);
        p1.Value = PageSize;
        cmd.Parameters.Add(p1);

        SqlParameter p2 = new SqlParameter("@CurrentPage", SqlDbType.Int, 4);
        p2.Value = CurrentPage;
        cmd.Parameters.Add(p2);

        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataSet dSet = new DataSet();
        sda.Fill(dSet);

        return (dSet);
    }


    public int GetCountOfEmployees()
    {
        SqlConnection cn = new SqlConnection(GetCS());
        SqlCommand cmd = new SqlCommand("select count(*) from Employees", cn);
        cn.Open();
        int Counter = Convert.ToInt32(cmd.ExecuteScalar().ToString());

        cn.Close();
        return (Counter);
    }
    public ArrayList GetEmployeesUsingReader()
    {
        ArrayList EmployeesList = new ArrayList();

        SqlConnection cn = new SqlConnection(GetCS());
        SqlCommand cmd = new SqlCommand("select * from employees", cn);
        cn.Open();
        SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

        while (sdr.Read())
        {
            Employee emp = new Employee();

            emp.EmployeeID = Convert.ToInt32(sdr["EmployeeId"].ToString());
            emp.LastName = sdr["LastName"].ToString();
            emp.FirstName = sdr["FirstName"].ToString();
            emp.Title = (sdr["Title"].ToString());
            emp.TitleOfCourtesy = (sdr["TitleOfCourtesy"].ToString());
            EmployeesList.Add(emp);
            emp = null;
        }

        return (EmployeesList);

    }
    public int BulkDeleteEmployees(string csvEmployeeIDs)
    {
        SqlConnection cn = null;
        SqlCommand cmd = null;
        int Counter = 0;

        try
        {
            cn = new SqlConnection(GetCS());
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "[USP_EMPLOYEES_BULKDELETE]";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmployeeIds", csvEmployeeIDs);


            cn.Open();
            Counter = cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            if (cn != null)
            {
                cn.Close();
                cn.Dispose();
                cn = null;
            }
        }
        return (Counter);
    }
    public System.Data.DataSet GetEmployeeWiseOrders()
    {
        SqlConnection cn = new SqlConnection(GetCS());
        SqlCommand cmd = new SqlCommand("[USP_GetEmployeeWiseOrders]", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataSet dSet = new DataSet();
        sda.Fill(dSet);
        return (dSet);
    }


}
