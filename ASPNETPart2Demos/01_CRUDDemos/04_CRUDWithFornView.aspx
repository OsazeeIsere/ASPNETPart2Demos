<%@ Page Language="C#" AutoEventWireup="true" CodeFile="04_CRUDWithFornView.aspx.cs" Inherits="_04_CRUDWithFornView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:FormView ID="FormView1" runat="server" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" AllowPaging="True" DataKeyNames="EmployeeId" OnPageIndexChanging="FormView1_PageIndexChanging" Width="326px" OnModeChanging="FormView1_ModeChanging" OnItemInserting="FormView1_ItemInserting" OnItemCommand="FormView1_ItemCommand" OnItemDeleting="FormView1_ItemDeleting" OnItemUpdating="FormView1_ItemUpdating">
                <EditRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                <FooterStyle BackColor="Tan" />
                <HeaderStyle BackColor="Tan" Font-Bold="True" />
                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                <ItemTemplate>
                     
                      <table border="1">
                <tr>
                    <td>Employee ID</td>
                    <td><%# Eval("EmployeeID") %></td>
                </tr>
                 <tr>
                    <td>LastName</td>
                    <td><%# Eval("LastName") %></td>
                </tr>
                 <tr>
                    <td>FirstName</td>
                    <td><%# Eval("FirstName") %></td>
                </tr>
                 <tr>
                    <td>Title</td>
                    <td><%# Eval("Title") %></td>
                </tr>
                 <tr>
                    <td>Title Of Courtesy</td>
                    <td><%# Eval("TitleOfCourtesy") %></td>
                </tr>
 
<tr>
                    <td> </td>
                    <td>
                        <asp:Button ID="btnEdit" runat="Server" CommandName="Edit" Text="Edit" />
                        <asp:Button ID="btnInsert" runat="Server" CommandName="New" Text="New" />
                        <asp:Button ID="btnDelete" runat="Server" CommandName="Delete" Text="Delete" 
                            OnClientClick="return confirm('Are you sure to Delete?');" />
                    </td>
                </tr>

                </ItemTemplate>
                <InsertItemTemplate>
                      
                    <table border="1">
                <tr>
                    <td>Employee ID</td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

                    </td>
                   
                </tr>
                 <tr>
                    <td>LastName</td>
                    <td><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td>FirstName</td>
                    <td><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td>Title</td>
                    <td><asp:TextBox ID="TextBox4" runat="server"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td>Title Of Courtesy</td>
                    <td><asp:TextBox ID="TextBox5" runat="server"></asp:TextBox></td>
                </tr>

                <tr>
                    <td> </td>
                    <td>
                        <asp:Button ID="btnSave" runat="Server" CommandName="Insert" Text="Save" />
                        <asp:Button ID="btnCancel" runat="Server" CommandName="Cancel" Text="Cancel" />
                        
                    </td>
                </tr>


            </table>

                </InsertItemTemplate>
                <EditItemTemplate>
                      <table border="1">
                <tr>
                    <td>Employee ID</td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" 
                            Text='<%# Eval("EmployeeID") %>'></asp:TextBox>

                    </td>
                   
                </tr>
                 <tr>
                    <td>LastName</td>
                    <td><asp:TextBox ID="TextBox2" runat="server" 
                        Text='<%# Eval("LastName") %>'></asp:TextBox></td>
                </tr>
                 <tr>
                    <td>FirstName</td>
                    <td><asp:TextBox ID="TextBox3" runat="server" 
                        Text='<%# Eval("FirstName") %>'></asp:TextBox></td>
                </tr>
                 <tr>
                    <td>Title</td>
                    <td><asp:TextBox ID="TextBox4" runat="server" 
                        Text='<%# Eval("Title") %>'></asp:TextBox></td>
                </tr>
                 <tr>
                    <td>Title Of Courtesy</td>
                    <td><asp:TextBox ID="TextBox5" runat="server" 
                        Text='<%# Eval("TitleOfCourtesy") %>'></asp:TextBox></td>
                </tr>

                <tr>
                    <td> </td>
                    <td>
                        <asp:Button ID="btnSave" runat="Server" CommandName="Update" Text="Save" />
                        <asp:Button ID="btnCancel" runat="Server" CommandName="Cancel" Text="Cancel" />
                        
                    </td>
                </tr>


            </table>

                </EditItemTemplate>
            </asp:FormView>
        </div>
    </form>
</body>
</html>
