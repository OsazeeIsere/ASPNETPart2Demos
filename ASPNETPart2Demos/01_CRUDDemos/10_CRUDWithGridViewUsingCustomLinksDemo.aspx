<%@ Page Language="C#" AutoEventWireup="true" CodeFile="10_CRUDWithGridViewUsingCustomLinksDemo.aspx.cs" Inherits="_08_CRUDWithGridViewUsingBoundFieldDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataKeyNames="EmployeeId" ForeColor="Black" GridLines="None" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" PageSize="3" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting">
                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                <Columns>
                      <asp:TemplateField>
                           <EditItemTemplate>
                              <asp:linkbutton id="btnUpdate" runat="server" 
                            commandname="Update" text="update" ForeColor="Black" />
					<asp:linkbutton id="btnCancel" runat="server" 
                        causesvalidation="false" commandname="Cancel" 
                        Text="Cancel" ForeColor="Black"  />
                    </EditItemTemplate>
                           <ItemTemplate>
                               <asp:linkbutton id="Linkbutton1" runat="server" causesvalidation="false" 
                commandname="Select" text="Select" ForeColor="Black" />
                             <asp:linkbutton id="btnEdit" runat="server" causesvalidation="false" 
                commandname="Edit" text="Edit" ForeColor="Black" />
					<asp:linkbutton id="btnDelete" runat="server" 
                        causesvalidation="false" commandname="Delete"  ForeColor="Black"
             OnClientClick="return confirm('Are you sure you want to delete?');" 
                        Text="delete" />
					
                        </ItemTemplate>

                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="EmployeeID">
                        <ItemTemplate>
 <asp:Label ID="Label1" runat="server" Text='<%# Bind("EmployeeID") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
<asp:Label ID="Label1" runat="server" Text='<%# Bind("EmployeeID") %>'></asp:Label>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="LastName">
                         <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" 
                            Text='<%# Bind("LastName") %>'></asp:TextBox>
                    </EditItemTemplate>
                   
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" 
                            Text='<%# Bind("LastName") %>'></asp:Label>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="FirstName">
                        <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("FirstName") %>'></asp:TextBox>
                    </EditItemTemplate>
                   
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Title">
                         <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Title") %>'></asp:TextBox>
                    </EditItemTemplate>
                   
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("Title") %>'></asp:Label>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Title Of Courtesy">
                         <EditItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("TitleOfCourtesy") %>'></asp:TextBox>
                    </EditItemTemplate>
                   
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("TitleOfCourtesy") %>'></asp:Label>
                    </ItemTemplate>
                    </asp:TemplateField>
           
                </Columns>
                <FooterStyle BackColor="Tan" />
                <HeaderStyle BackColor="Tan" Font-Bold="True" />
                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                <SortedAscendingCellStyle BackColor="#FAFAE7" />
                <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                <SortedDescendingCellStyle BackColor="#E1DB9C" />
                <SortedDescendingHeaderStyle BackColor="#C2A47B" />
            </asp:GridView>
        </div>
    </form>
</body>
</html>
