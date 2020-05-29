<%@ Page Language="C#" AutoEventWireup="true" CodeFile="03_NestedGridViewWithSubtotalsDemo.aspx.cs" Inherits="_03_GridViewWithControlDemos_03_NestedGridViewWithSubtotalsDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../jquery-3.3.1.js"></script>
     <script type="text/javascript">
    function ShowHide(img, div) {
        var current = $('#' + div).css('display');
        if (current == 'none') {
            $('#' + div).show('slow');
            $(img).attr('src', '../images/minus.png');
        }
        else {
            $('#' + div).hide('slow');
            $(img).attr('src', '../images/plus.png');
        }
    }
</script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
                        <asp:GridView ID="GridView1" 
                            ClientIDMode="Predictable"
                            ClientIDRowSuffix="OrderID"

                            runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" DataKeyNames="OrderID" OnDataBound="GridView1_DataBound1" OnRowDataBound="GridView1_RowDataBound1">
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
                <asp:BoundField DataField="OrderID" HeaderText="Order ID" />
                <asp:BoundField DataField="OrderDate" HeaderText="Order Date" />
                <asp:BoundField DataField="CompanyName" HeaderText="CompanyName" />

                <asp:TemplateField>
                    <ItemTemplate>

                        <img alt = "" onclick="ShowHide(this, 'GridView1_pnlOrders_<%# Eval("OrderID") %>')" 
     style="cursor: pointer" id="hi" src="../images/plus.png" />

<asp:Panel ID="pnlOrders" runat="server" Style="display: none">     

    <asp:GridView ID="gvOrders" Width="100%" runat="server" 
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

        </div>
    </form>
</body>
</html>
