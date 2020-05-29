<%@ Page Language="C#" AutoEventWireup="true" CodeFile="08_BullkDeleteDemo.aspx.cs" Inherits="_03_GridViewControlDemos_08_BullkDeleteDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../jquery-3.3.1.js"></script>

     <script type="text/javascript">
        var checked = true;
      $(function() {
   
    var MainGridView = $('#GridView1');  


    $('#GridView1_chkHeader').click(
        function (evt) {
            
            MainGridView.find("input[type='checkbox']").prop('checked', checked);
            checked = !checked;
        }
    );   
      });

</script>


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

                       <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:CheckBox ID="chkHeader" runat="server" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkRow" runat="server" />
                    </ItemTemplate>
                        </asp:TemplateField>
               
                    <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" ReadOnly="true" SortExpression="EmployeeID" />
                    <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                    <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                    <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                    <asp:BoundField DataField="TitleOfCourtesy" HeaderText="Title Of Courtesy" SortExpression="TitleOfCourtesy" />


                   




                     </Columns>


             </asp:GridView>
             <br />
             <br />
              
                
             <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Bulk Delete" />


        </div>
    </form>
</body>
</html>
