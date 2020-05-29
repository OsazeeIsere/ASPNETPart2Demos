<%@ Page Language="C#" AutoEventWireup="true" CodeFile="07_GridViewWithRadioButtonDemo.aspx.cs" Inherits="_03_GridViewWithControlDemos_06_RadioButtonAsRowSelectorDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" AutoGenerateEditButton="True" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDataBound="GridView1_RowDataBound">
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

                <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" ReadOnly="true" SortExpression="EmployeeID" />
                    <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                    <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                    <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                    <asp:BoundField DataField="TitleOfCourtesy" HeaderText="Title Of Courtesy" SortExpression="TitleOfCourtesy" />


                    <asp:TemplateField HeaderText="Is Certified?">
                         <EditItemTemplate>
                             <asp:RadioButton ID="RadioButton1" runat="server" GroupName="Cert"/>Yes
                             <asp:RadioButton ID="RadioButton2" runat="server" GroupName="Cert"/>No
                         </EditItemTemplate>
                         <ItemTemplate>
                             <asp:RadioButton ID="RadioButton1" runat="server" Enabled="false" GroupName="Cert"/>Yes
                             <asp:RadioButton ID="RadioButton2" runat="server" Enabled="false" GroupName="Cert"/>No
                         </ItemTemplate>
                     </asp:TemplateField>






                     </Columns>


            </asp:GridView>
            
        </div>
    </form>
</body>
</html>
