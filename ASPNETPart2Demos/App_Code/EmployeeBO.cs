using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EmployeeBO
/// </summary>
[Serializable]
[DataObject(true)]
public class EmployeeBO
{
    public int EmployeeID { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string Title { get; set; }
    public string TitleOfCourtesy { get; set; }

    public EmployeeBO()
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
        return (dSet);
    }


    [DataObjectMethod(DataObjectMethodType.Update)]
    public int UpdateEmployee(EmployeeBO empbo)
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

            cmd.Parameters.AddWithValue("@EmployeeID", empbo.EmployeeID);
            cmd.Parameters.AddWithValue("@LastName", empbo.LastName);
            cmd.Parameters.AddWithValue("@FirstName", empbo.FirstName);
            cmd.Parameters.AddWithValue("@Title", empbo.Title);
            cmd.Parameters.AddWithValue("@TitleOfCourtesy", empbo.TitleOfCourtesy);

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
    public int DeleteEmployee(EmployeeBO empbo)
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
            cmd.Parameters.AddWithValue("@EmployeeID", empbo.EmployeeID);


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
    public int InsertEmployee(EmployeeBO empbo)
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
            cmd.Parameters.AddWithValue("@LastName", empbo.LastName);
            cmd.Parameters.AddWithValue("@FirstName", empbo.FirstName);
            cmd.Parameters.AddWithValue("@Title", empbo.Title);
            cmd.Parameters.AddWithValue("@TitleOfCourtesy", empbo.TitleOfCourtesy);

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