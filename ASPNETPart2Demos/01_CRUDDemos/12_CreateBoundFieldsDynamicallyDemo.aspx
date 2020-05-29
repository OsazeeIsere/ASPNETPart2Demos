<%@ Page Language="C#" AutoEventWireup="true" CodeFile="12_CreateBoundFieldsDynamicallyDemo.aspx.cs" Inherits="_12_CreateBoundFieldsDynamicallyDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <style>
     .GridView1:hover
        {
            background-color: blue;
            border-top: solid;
            color:#9C6500;
        }
 </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" OnRowDataBound="GridView1_RowDataBound">
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
                    <asp:TemplateField HeaderText="SlNo">
                        <ItemTemplate>
                            <asp:Label id="lblRowNumber" 
                                runat="server" 
                                Text=""></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="RowNumber">
                        <ItemTemplate>
                            <asp:Label id="lblRecordNumber" 
                                runat="server" 
                                Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
             <br />
            Would you like to see Country Information as well?
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
            AutoPostBack="True" 
            OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
            <asp:ListItem>No</asp:ListItem>
            <asp:ListItem>Yes</asp:ListItem>
        </asp:RadioButtonList>

        </div>
    </form>
</body>
</html>
