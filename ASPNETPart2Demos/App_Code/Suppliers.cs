using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Suppliers
/// </summary>
public class Suppliers
{
    public Suppliers()
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

    public System.Data.DataSet GetSuppliers()
    {
        SqlConnection cn = new SqlConnection(GetCS());
        SqlCommand cmd = new SqlCommand("select * from suppliers order by companyname asc", cn);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataSet dSet = new DataSet();
        sda.Fill(dSet);
        cn.Close();
        return (dSet);
    }

}