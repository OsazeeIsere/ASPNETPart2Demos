<%@ Page Language="C#" AutoEventWireup="true" CodeFile="06_CRUDWithListViewWithPagingDemos.aspx.cs" Inherits="_06" %>

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
            <asp:ListView ID="ListView1" runat="server" DataKeyNames="EmployeeId" OnItemEditing="ListView1_ItemEditing" OnItemInserting="ListView1_ItemInserting" OnItemUpdating="ListView1_ItemUpdating" InsertItemPosition="LastItem" OnItemCanceling="ListView1_ItemCanceling" OnItemDeleting="ListView1_ItemDeleting">
                <ItemTemplate>
                     
                 <table border="1" bgColor="aqua">
                    <tr>
                        <td>Employee ID</td>
                         <td><%# Eval("EmployeeID") %></td>
                    </tr>
                      <tr>
                        <td>LastName</td>
                         <td><%# Eval("LastName") %></td>
                    </tr>
                      <tr>
                        <td>FirstName ID</td>
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
                <InsertItemTemplate>
                     <table border="1">
                    <tr>
                        <td>Last Name</td>
                        <td><asp:TextBox ID="TextBox6" runat="server"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td>First Name</td>
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

                </InsertItemTemplate>
                <EditItemTemplate>
                     <table border="1" bgColor="aqua">
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
                        causesvalidation="false" commandname="Cancel" Text="Cancel" />


                </EditItemTemplate>
            </asp:ListView>
        </div>
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

    </form>
</body>
</html>
