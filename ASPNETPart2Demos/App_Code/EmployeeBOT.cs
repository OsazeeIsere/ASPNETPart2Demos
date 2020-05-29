using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EmployeeBOT
/// </summary>
[Serializable]
[DataObject(true)]

public class EmployeeBOT
{
    public EmployeeBOT()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string GetCS()
    {
        string cs = "data source=.;initial catalog=northwind;integrated security=true;";
        return (cs);
    }
    [DataObjectMethod(DataObjectMethodType.Select)]
    public System.Data.DataSet GetEmployees()
    {
        SqlConnection cn = new SqlConnection(GetCS());
        SqlCommand cmd = new SqlCommand("select * from employees", cn);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataSet dSet = new DataSet();
        sda.Fill(dSet);
        cn.Close();
        return (dSet);
    }


    [DataObjectMethod(DataObjectMethodType.Select)]
    public System.Data.DataSet GetEmployees(int startRowIndex, int maximumRows, string sortColumn)
    {
        SqlConnection cn = new SqlConnection(GetCS());
        SqlCommand cmd = new SqlCommand("usp_GetEmployeesPageWise", cn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@StartIndex", startRowIndex);
        cmd.Parameters.AddWithValue("@maximumRows", maximumRows);

        if (string.IsNullOrEmpty(sortColumn))
            sortColumn = "EmployeeID asc";

        cmd.Parameters.AddWithValue("@sortColumn", sortColumn);


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


    [DataObjectMethod(DataObjectMethodType.Update)]
    public int UpdateEmployee(int EmployeeID, string LastName, string FirstName, string Title, string TitleOfCourtesy)
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

            cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
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

    [DataObjectMethod(DataObjectMethodType.Insert)]
    public int InsertEmployee(string LastName, string FirstName, string Title, string TitleOfCourtesy)
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

    [DataObjectMethod(DataObjectMethodType.Delete)]
    public int DeleteEmployee(int EmployeeID)
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

}