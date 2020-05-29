using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductPhoto
/// </summary>
public class ProductPhoto
{
    public ProductPhoto()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string GetCS()
    {
        string cs = "data source=.;initial catalog=adventureworks2017;integrated security=true;";
        return (cs);
    }

    public System.Data.DataSet GetProductPhotos()
    {
        SqlConnection cn = new SqlConnection(GetCS());
        SqlCommand cmd = new SqlCommand("select a.*,b.*,c.name from production.productphoto a,production.productproductphoto b,production.product c where a.productphotoid = b.productphotoid and c.productid = b.productid", cn);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataSet dSet = new DataSet();
        sda.Fill(dSet);
        cn.Close();
        return (dSet);
    }

}