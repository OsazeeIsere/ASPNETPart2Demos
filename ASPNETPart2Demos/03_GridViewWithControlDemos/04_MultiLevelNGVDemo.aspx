<%@ Page Language="C#" AutoEventWireup="true" CodeFile="04_MultiLevelNGVDemo.aspx.cs" Inherits="_03_GridViewWithControlDemos_04_MultiLevelNGVDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" DataKeyNames="EmployeeID" OnRowDataBound="GridView1_RowDataBound">
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
                    <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" ItemStyle-VerticalAlign="Top" />
                    <asp:BoundField DataField="LastName" HeaderText="LastName" ItemStyle-VerticalAlign="Top"/>
                    <asp:BoundField DataField="FirstName" HeaderText="FirstName" ItemStyle-VerticalAlign="Top"/>

                    <asp:TemplateField>
                        <ItemTemplate>

                            <asp:Panel ID="pnlOrders" runat="server">
                                 <asp:GridView ID="gvOrders" Width="100%" runat="server" 
                                     AutoGenerateColumns="false"
                                     OnRowDataBound="gvOrders_RowDataBound">

                                     <Columns>
                                        <asp:BoundField DataField="OrderID" HeaderText="Order ID" />
                                        <asp:BoundField DataField="OrderDate" HeaderText="Order Date" />
                                        <asp:BoundField DataField="CompanyName" HeaderText="CompanyName" />

                                           <asp:TemplateField HeaderText="OrderID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOrderID" runat="server" 
                                                    Text='<%#DataBinder.Eval(Container.DataItem, "OrderID") %>'></asp:Label>
                                             </ItemTemplate>
                                        </asp:TemplateField>

<asp:TemplateField >
                                <ItemTemplate>
                                        <asp:Panel ID="pnlOrderDetails" runat="server">
                                             <asp:GridView ID="gvOrderDetails" Width="100%" runat="server" 
                                                 AutoGenerateColumns="false">
                                                 <Columns>
                
                <asp:BoundField DataField="ProductName" HeaderText="ProductName" />
                <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" HtmlEncode="False" DataFormatString="{0:C2}" ItemStyle-HorizontalAlign="Right" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" ItemStyle-HorizontalAlign="Right" />
                <asp:BoundField DataField="BillAmount" HeaderText="Bill Amount" HtmlEncode="False" DataFormatString="{0:C2}" ItemStyle-HorizontalAlign="Right" />
                                  </Columns>
                                             </asp:GridView>
                                        </asp:Panel>
                                 </ItemTemplate>
                                          </asp:TemplateField>



                                     </Columns>
                                     </asp:GridView>
                                     </asp:Panel>

                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>

            </asp:GridView>
        </div>
    </form>
</body>
</html>
