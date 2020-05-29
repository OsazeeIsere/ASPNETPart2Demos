<%@ Page Language="C#" AutoEventWireup="true" CodeFile="09_DisplayingImageInGV.aspx.cs" Inherits="_03_GridViewControlDemos_09_DisplayingImageInGV" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound">
                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                <FooterStyle BackColor="Tan" />
                <HeaderStyle BackColor="Tan" Font-Bold="True" />
                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                <SortedAscendingCellStyle BackColor="#FAFAE7" />
                <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                <SortedDescendingCellStyle BackColor="#E1DB9C" />
                <SortedDescendingHeaderStyle BackColor="#C2A47B" />
                
                <Columns>

                     <asp:BoundField DataField="ProductPhotoID" HeaderText="ProductPhotoID" ReadOnly="true" SortExpression="EmployeeID" />
                    <asp:BoundField DataField="ThumbnailPhotoFileName" HeaderText="LastName" SortExpression="LastName" />
                    <asp:BoundField DataField="LargePhotoFileName" HeaderText="FirstName" SortExpression="FirstName" />
                   <asp:BoundField DataField="ProductID" HeaderText="ProductID" SortExpression="Name" />
                 <asp:BoundField DataField="Name" HeaderText="Product Name" SortExpression="Name" />


               <asp:TemplateField HeaderText="Thumbnail">
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" />
                    </ItemTemplate>
            </asp:TemplateField>
                   <asp:TemplateField HeaderText="LargePhoto">
                    <ItemTemplate>
                        <asp:Image ID="Image2" runat="server" />
                    </ItemTemplate>
        </asp:TemplateField>



                </Columns>

            </asp:GridView>
        </div>
    </form>
</body>
</html>
