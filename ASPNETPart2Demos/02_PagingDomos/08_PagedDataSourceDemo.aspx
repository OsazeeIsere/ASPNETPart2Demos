<%@ Page Language="C#" AutoEventWireup="true" CodeFile="08_PagedDataSourceDemo.aspx.cs" Inherits="PagingDomos_08_PagedDataSourceDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Repeater ID="Repeater1" runat="server">
                 <HeaderTemplate>
                     <table border="1">
                    <tr>
                        <td>Employee ID</td>
                        <td>Last Name</td>
                        <td>First Name</td>
                        <td>Title</td>
                        <td>Title Of Courtesy</td>
                        <td></td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                     <tr>
                   <td><asp:Label ID="Label1" runat="server" Text='<%# Eval("EmployeeId") %>'></asp:Label></td>
                   <td>
                       <asp:Label ID="Label2" runat="server" Text='<%# Eval("LastName") %>'></asp:Label> </td>
                      <td><asp:Label ID="Label3" runat="server" Text='<%# Eval("FirstName") %>'></asp:Label></td>
                   <td><asp:Label ID="Label4" runat="server" Text='<%# Eval("Title") %>'></asp:Label></td>
                   <td><asp:Label ID="Label5" runat="server" Text='<%# Eval("TitleOfCourtesy") %>'></asp:Label></td>
                  </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>

            </asp:Repeater>
            <asp:LinkButton id="First" Text="<< First" OnClick="FirstPage"
runat="server"/>;
<asp:LinkButton id="Prev" Text="< Previous" OnClick="PreviousPage"
runat="server"/>;
<asp:LinkButton id="Next" Text="Next >" OnClick="NextPage"
runat="server"/>;
<asp:LinkButton id="Last" Text=">> Last" OnClick="LastPage" runat="server"/>

        </div>
    </form>
</body>
</html>
