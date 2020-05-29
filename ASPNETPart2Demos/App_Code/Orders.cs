using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Orders
/// </summary>
public class Orders
{
    public Orders()
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

    public System.Data.DataSet GetOrders()
    {
        SqlConnection cn = new SqlConnection(GetCS());
        SqlCommand cmd = new SqlCommand("[USP_GETOrder_Details]", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataSet dSet = new DataSet();
        sda.Fill(dSet);
        return (dSet);
    }

    public System.Data.DataSet GetOrderIDWiseDetails(int OrderID)
    {
        SqlConnection cn = new SqlConnection(GetCS());
        SqlCommand cmd = new SqlCommand("[USP_GetOrderIDWiseDetails]", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@OrderID", OrderID);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataSet dSet = new DataSet();
        sda.Fill(dSet);

        return (dSet);
    }
    public System.Data.DataSet GetOrdersInfo()
    {
        SqlConnection cn = new SqlConnection(GetCS());
        SqlCommand cmd = new SqlCommand("usp_GetOrderInfo", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataSet dSet = new DataSet();
        sda.Fill(dSet);
        return (dSet);
    }

    public System.Data.DataSet GetOrderDetails(int OrderID)
    {
        SqlConnection cn = new SqlConnection(GetCS());
        SqlCommand cmd = new SqlCommand("[USP_GetOrderDetails]", cn);
        cmd.Parameters.AddWithValue("@OrderID", OrderID);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataSet dSet = new DataSet();
        sda.Fill(dSet);
        return (dSet);
    }
   
}