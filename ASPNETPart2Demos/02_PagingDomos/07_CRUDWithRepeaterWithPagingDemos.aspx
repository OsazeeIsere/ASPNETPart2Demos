<%@ Page Language="C#" AutoEventWireup="true" CodeFile="07_CRUDWithRepeaterWithPagingDemos.aspx.cs" Inherits="_07_CRUDWithRepeaterDemos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <style>
         .link_enabled, .link_disabled
        {
            display: inline-block;
            height: 35px;
            min-width: 35px;
            line-height: 35px;
            text-align: center;
            text-decoration: none;
            border: 3px solid #ccc;
        }
        .link_enabled
        {
            background-color: #eee;
            color: #000;
        }
        .link_disabled
        {
            background-color: #6C6C6C;
            color: #fff;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                <HeaderTemplate>
                     <table border="1" bgColor="aqua">
                    <tr>
                        <td>Employee ID</td>
                        <td>Last Name</td>
                        <td>First Name</td>
                        <td>Title</td>
                        <td>Title Of Courtesy</td>
                        <td></td>
                    </tr>

                </HeaderTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
                    <ItemTemplate>
                         <tr>
                   <td><asp:Label ID="Label1" runat="server" Text='<%# Eval("EmployeeId") %>'></asp:Label></td>
                   <td>
                       <asp:Label ID="Label2" runat="server" Text='<%# Eval("LastName") %>'></asp:Label> </td>
                      
                   
                   <td><asp:Label ID="Label3" runat="server" Text='<%# Eval("FirstName") %>'></asp:Label></td>
                   <td><asp:Label ID="Label4" runat="server" Text='<%# Eval("Title") %>'></asp:Label></td>
                   <td><asp:Label ID="Label5" runat="server" Text='<%# Eval("TitleOfCourtesy") %>'></asp:Label></td>

                   <td>
                      <asp:LinkButton ID="lnkEdit" Text="Edit" runat="server" OnClick="OnEdit" />
               <asp:LinkButton ID="lnkUpdate" Text="Update" runat="server" Visible="false" OnClick="OnUpdate" />
                <asp:LinkButton ID="lnkCancel" Text="Cancel" runat="server" Visible="false" OnClick="OnCancel" />
                <asp:LinkButton ID="lnkDelete" Text="Delete" runat="server" OnClick="OnDelete" OnClientClick="return confirm('Do you want to delete?');" />
                  </td>

                   </tr>

                    </ItemTemplate>
            </asp:Repeater>
             <table>
            <tr>
                    <td></td>
                    <td><asp:TextBox ID="TextBox1" runat="server"  visible="false"></asp:TextBox></td>
                    <td><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
                    <td><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>
                    <td><asp:TextBox ID="TextBox4" runat="server"></asp:TextBox></td>
                    <td><asp:TextBox ID="TextBox5" runat="server"></asp:TextBox></td>
                    <td> <asp:LinkButton ID="lnkInsert" Text="Insert" runat="server" Visible="True" OnClick="OnInsert" /></td>
                </tr>
        </table>
 <asp:Repeater ID="rptPager" runat="server">
                <ItemTemplate>
                     <asp:LinkButton ID="lnkPage" runat="server" 
                    Text='<%#Eval("Text") %>' 
                CommandArgument='<%# Eval("Value") %>'
                CssClass='<%# Convert.ToBoolean(Eval("Enabled")) ? "link_enabled" : "link_disabled" %>'
                OnClick="PageIndex_Changed" 
                ></asp:LinkButton>
                </ItemTemplate>

            </asp:Repeater>

        </div>
    </form>
</body>
</html>
