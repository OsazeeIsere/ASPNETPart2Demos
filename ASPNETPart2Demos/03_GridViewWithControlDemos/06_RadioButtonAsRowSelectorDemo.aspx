<%@ Page Language="C#" AutoEventWireup="true" CodeFile="06_RadioButtonAsRowSelectorDemo.aspx.cs" Inherits="_03_GridViewWithControlDemos_06_RadioButtonAsRowSelectorDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None">
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


                     <asp:TemplateField HeaderText="Who is Best Employee?">
                         <ItemTemplate>

                             <input name="radBestEmployee" type="radio" 
                                 value='<%# Eval("EmployeeID").ToString() + " " +  Eval("LastName").ToString() %>' />
                            
                         </ItemTemplate>
                     </asp:TemplateField>




                     </Columns>


            </asp:GridView>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" 
                 Text="Click Here To Confirm Your Selection" />
        <p>
            &nbsp;</p>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

        </div>
    </form>
</body>
</html>
