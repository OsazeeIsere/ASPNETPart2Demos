using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _03_GridViewControlDemos_09_DisplayingImageInGV : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindData();
        }
    }

    private void BindData()
    {
        ProductPhoto prod = new ProductPhoto();
        DataSet dSet = prod.GetProductPhotos();
        GridView1.DataSource = dSet;
        GridView1.DataBind();

    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView dr = (DataRowView)e.Row.DataItem;
            string imageUrl = "data:image/gif;base64," + Convert.ToBase64String((byte[])dr["ThumbNailPhoto"]);
            (e.Row.FindControl("Image1") as Image).ImageUrl = imageUrl;

            imageUrl = "data:image/gif;base64," + Convert.ToBase64String((byte[])dr["LargePhoto"]);
            (e.Row.FindControl("Image2") as Image).ImageUrl = imageUrl;
        }

    }
}