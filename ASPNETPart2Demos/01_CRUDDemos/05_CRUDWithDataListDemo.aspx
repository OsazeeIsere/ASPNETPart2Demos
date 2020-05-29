<%@ Page Language="C#" AutoEventWireup="true" CodeFile="05_CRUDWithDataListDemo.aspx.cs" Inherits="_05_CRUDWithDataListDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DataList ID="DataList1" runat="server" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" DataKeyField="EmployeeID" RepeatColumns="3" OnItemCommand="DataList1_ItemCommand" OnCancelCommand="DataList1_CancelCommand" OnDeleteCommand="DataList1_DeleteCommand" OnEditCommand="DataList1_EditCommand" OnUpdateCommand="DataList1_UpdateCommand">
                <AlternatingItemStyle BackColor="PaleGoldenrod" />
                <FooterStyle BackColor="Tan" />
                <HeaderStyle BackColor="Tan" Font-Bold="True" />
                <SelectedItemStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                <ItemTemplate>
                     <table border="1">
                    <tr>
                        <td>Employee ID</td>
                         <td><%# Eval("EmployeeId") %></td>
                    </tr>
                      <tr>
                        <td>LastName</td>
                         <td><%# Eval("LastName") %></td>
                    </tr>
                      <tr>
                        <td>FirstName </td>
                         <td><%# Eval("FirstName") %></td>
                    </tr>
                      <tr>
                        <td>Title</td>
                         <td><%# Eval("Title") %></td>
                    </tr>
                      <tr>
                        <td>TitleOfCourtesy</td>
                         <td><%# Eval("TitleOfCourtesy") %></td>
                    </tr>
                    <tr>
                      <td>
      <asp:Button ID="btnedit" runat="server" Text="Edit"  ToolTip="Edit" CommandName="Edit"/></td>   
            <td><asp:Button ID="btndelete" runat="server" Text="Delete" CommandName="Delete" ToolTip="Delete"/></td> 
                    </tr>
                </table>
                </ItemTemplate>
                <FooterTemplate>
                    <table border="1">
                    <tr>
                        <td>First Name</td>
                        <td><asp:TextBox ID="TextBox6" runat="server"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td>Last Name</td>
                        <td><asp:TextBox ID="TextBox7" runat="server"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td>Title</td>
                        <td><asp:TextBox ID="TextBox8" runat="server"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td>Title Of Courtesy</td>
                        <td><asp:TextBox ID="TextBox9" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                    <td width="100px">
                    <asp:Button ID="btnInsertButton" runat="server" 
                        CommandName="Insert" 
         Text="Insert" />                        
         </td>
                        </tr>
                </table>
                </FooterTemplate>
                <EditItemTemplate>
                     <table border="1">
                    <tr>
                        <td>Employee ID</td>
                         <td><asp:TextBox ID="TextBox1" runat="server" 
                             Text='<%# Bind("EmployeeID") %>'></asp:TextBox></td>
                    </tr>
                      <tr>
                        <td>LastName</td>
                         <td><asp:TextBox ID="TextBox2" runat="server" 
                             Text='<%# Bind("LastName") %>'></asp:TextBox></td>
                    </tr>
                      <tr>
                        <td>FirstName ID</td>
                         <td> <asp:TextBox ID="TextBox3" runat="server"
                             Text='<%# Bind("FirstName") %>'></asp:TextBox></td>
                    </tr>
                      <tr>
                        <td>Title</td>
                         <td> <asp:TextBox ID="TextBox4" runat="server"
                             Text='<%# Bind("Title") %>'></asp:TextBox></td>
                    </tr>
                      <tr>
                        <td>TitleOfCourtesy</td>
                         <td> <asp:TextBox ID="TextBox5" runat="server" 
                             Text='<%# Bind("TitleOfCourtesy") %>'></asp:TextBox></td>
                    </tr>
                 <asp:linkbutton id="btnUpdate" runat="server" 
                            commandname="Update" text="update" />
					<asp:linkbutton id="btnCancel" runat="server" 
                        causesvalidation="false" commandname="Cancel" 
                        Text="Cancel" />



                </EditItemTemplate>
            </asp:DataList>
        </div>
    </form>
</body>
</html>
