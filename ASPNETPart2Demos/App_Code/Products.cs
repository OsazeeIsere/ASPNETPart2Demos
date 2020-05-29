using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Products
/// </summary>
public class Products
{
    public int ProductID { get; set; }
    public string ProductName { get; set; }

    public string QuantityPerUnit { get; set; }

    public double UnitPrice { get; set; }

    public int UnitsInStock { get; set; }

    public int UnitsOnOrder { get; set; }

    public int ReorderLevel { get; set; }

    public Boolean Discontinued { get; set; }
    public int CategoryID { get; set; }

    public int SupplierID { get; set; }

    public DateTime MFDate { get; set; }

    public Products()
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

    public System.Data.DataSet GetProducts()
    {
        SqlConnection cn = new SqlConnection(GetCS());
        SqlCommand cmd = new SqlCommand("USP_GETProductDetails", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataSet dSet = new DataSet();
        sda.Fill(dSet);

        return (dSet);
    }
    public int UpdateProduct()
    {
        SqlConnection cn = new SqlConnection(GetCS());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "USP_UpdateProduct";
        cmd.Connection = cn;

        cmd.Parameters.AddWithValue("@ProductID", ProductID);
        cmd.Parameters.AddWithValue("@ProductName", ProductName);
        cmd.Parameters.AddWithValue("@QuantityPerUnit", QuantityPerUnit);
        cmd.Parameters.AddWithValue("@UnitPrice", UnitPrice);

        cmd.Parameters.AddWithValue("@UnitsInStock", UnitsInStock);
        cmd.Parameters.AddWithValue("@UnitsOnOrder", UnitsOnOrder);
        cmd.Parameters.AddWithValue("@ReorderLevel", ReorderLevel);
        cmd.Parameters.AddWithValue("@Discontinued", Discontinued);

        cmd.Parameters.AddWithValue("@SupplierID", SupplierID);
        cmd.Parameters.AddWithValue("@CategoryID", CategoryID);
        cmd.Parameters.AddWithValue("@MFDate", MFDate);
        cn.Open();

        int Counter = cmd.ExecuteNonQuery();

        return (Counter);
    }

}