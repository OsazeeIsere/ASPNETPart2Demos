<%@ Page Language="C#" AutoEventWireup="true" CodeFile="01_GridViewWithDropDownListDemo.aspx.cs" Inherits="_03_GridViewWithControlDemos_01_GridViewWithDropDownListDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%--<script src="../Scripts/jquery-3.3.1.js"></script>
    <script src="../Scripts/jquery-ui-1.12.1.js"></script>
    <link href="../Content/themes/base/jquery-ui.css" rel="stylesheet" />--%>
    <script src="../jquery-3.3.1.js"></script>
    <script src="../Scripts/jquery-ui-1.12.1.js"></script>
    <link href="../Content/jquery-ui.css" rel="stylesheet" />
    <script type="text/javascript">

 $(function () {
            $(".date").datepicker({
                showOn: 'button',
                buttonImageOnly: true,
                buttonImage: 'http://itacademy.in/images/ka.gif'
            });
        });

    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" AutoGenerateColumns="False" AutoGenerateEditButton="True" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDataBound="GridView1_RowDataBound" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
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
                <asp:BoundField DataField="ProductID"  HeaderText="Product ID" />

                <%--<asp:BoundField DataField="ProductName" HeaderText="Product Name" />--%>

                     <asp:TemplateField HeaderText="ProductName">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" 
                            Text='<%# Bind("ProductName") %>'>
                        </asp:TextBox>
                        <asp:RequiredFieldValidator 
                            ControlToValidate="TextBox5" 
                            ID="RequiredFieldValidator1" 
                            runat="server" 
                            ErrorMessage="Product Name is must" 
                            Text="*">
                        </asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("ProductName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="QuantityPerUnit" HeaderText="QuantityPerUnit" />
                <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" />
                <asp:BoundField DataField="UnitsInStock" HeaderText="UnitsInStock" />
                <asp:BoundField DataField="UnitsOnOrder" HeaderText="UnitsOnOrder" />
                <asp:BoundField DataField="ReorderLevel" HeaderText="ReorderLevel" />
               <%-- <asp:BoundField DataField="Discontinued" HeaderText="Discontinued" />--%>

                      <asp:TemplateField HeaderText="Discontinued">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" Visible="false" 
                            runat="server" 
                            Text='<%# Bind("Discontinued") %>'>

                        </asp:TextBox>
                        <asp:CheckBox ID="CheckBox1" runat="server" 
                            Checked='<%# Bind("Discontinued") %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("Discontinued") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <%--<asp:BoundField DataField="MFDate" HeaderText="MFDate" />--%>

<asp:TemplateField HeaderText="MFDate">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" class="date" 
                            runat="server" 
                            Text='<%# Bind("MFDate") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                       <%-- <asp:TextBox ID="TextBox4" class="date" runat="server" Text='<%# Bind("MFDate") %>'></asp:TextBox>--%>

                        <asp:Label ID="Label4" runat="server" 
                            Text='<%# Bind("MFDate","{0: dd/MMM/yyyy}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

<asp:TemplateField HeaderText="SupplierName">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" visible="false" runat="server" Text='<%# Bind("CompanyName") %>'></asp:TextBox>
                        <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("CompanyName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
  <asp:TemplateField HeaderText="Category Name">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" visible="false" runat="server" Text='<%# Bind("CategoryName") %>'></asp:TextBox>
                        <asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("CategoryName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>


            </Columns>

            </asp:GridView>
        </div>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    </form>
</body>
</html>
