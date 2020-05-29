<%@ Page Language="C#" AutoEventWireup="true" CodeFile="03_CRUDWithDetailsViewUsingTemplateFieldsDemo.aspx.cs" Inherits="_01_CRUDWithDetailsViewUsingBoundFieldsDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DetailsView ID="DetailsView1" runat="server" AllowPaging="True" AutoGenerateRows="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" Height="305px" OnPageIndexChanging="DetailsView1_PageIndexChanging" Width="367px" DataKeyNames="EmployeeId" OnItemDeleting="DetailsView1_ItemDeleting" OnItemInserting="DetailsView1_ItemInserting" OnItemUpdating="DetailsView1_ItemUpdating" OnModeChanging="DetailsView1_ModeChanging">
                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                <EditRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                <Fields>
                   
                    <asp:TemplateField HeaderText="EmployeeID">
                         <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" 
                            Text='<%# Bind("EmployeeId") %>'></asp:TextBox>
                    </EditItemTemplate>

                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" 
                            Text='<%# Bind("EmployeeId") %>'></asp:TextBox>
                    </InsertItemTemplate>

                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" 
                            Text='<%# Bind("EmployeeId") %>'></asp:Label>
                    </ItemTemplate>

                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Last Name">
                         <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" 
                            Text='<%# Bind("LastName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" 
                            Text='<%# Bind("LastName") %>'></asp:TextBox>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" 
                            Text='<%# Bind("LastName") %>'></asp:Label>
                    </ItemTemplate>
           
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="First Name">
                        <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" 
                            Text='<%# Bind("FirstName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" 
                            Text='<%# Bind("FirstName") %>'></asp:TextBox>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" 
                            Text='<%# Bind("FirstName") %>'></asp:Label>
                    </ItemTemplate>

                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Title">
                         <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" 
                            Text='<%# Bind("Title") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" 
                            Text='<%# Bind("Title") %>'></asp:TextBox>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" 
                            Text='<%# Bind("Title") %>'></asp:Label>
                    </ItemTemplate>

                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Title Of Courtesy">
                         <EditItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" 
                            Text='<%# Bind("TitleOfCourtesy") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" 
                            Text='<%# Bind("TitleOfCourtesy") %>'></asp:TextBox>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" 
                            Text='<%# Bind("TitleOfCourtesy") %>'></asp:Label>
                    </ItemTemplate>

                    </asp:TemplateField>
                   
                   <asp:TemplateField>
                         <InsertItemTemplate>
         <asp:linkbutton id="btnInsert" 
                           runat="server" commandname="Insert"
             text="Insert" ForeColor="White" />

              <asp:linkbutton id="btnCancel" runat="server"
                  causesvalidation="false" commandname="Cancel" 
                                Text="Cancel" ForeColor="White" />

                        </InsertItemTemplate>

                         <EditItemTemplate>

        <asp:linkbutton id="btnUpdate" runat="server" 
                            commandname="Update" 
            text="update" ForeColor="White" />

					<asp:linkbutton id="btnCancel" runat="server" 
                        causesvalidation="false" 
                        commandname="Cancel" Text="Cancel" 
                        ForeColor="White"  />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:linkbutton id="btnEdit" runat="server" causesvalidation="false" 
                commandname="Edit" text="Edit" />

					<asp:linkbutton id="btnDelete" runat="server" 
                        causesvalidation="false" commandname="Delete" 
             OnClientClick="return confirm('Are you sure you want to delete?');" Text="Delete" />
					
                            <asp:linkbutton id="btnNew" runat="server" 
                        causesvalidation="false" 
                                commandname="New" text="New" />

                        </ItemTemplate>
                    </asp:TemplateField>
                </Fields>
                <FooterStyle BackColor="Tan" />
                <HeaderStyle BackColor="Tan" Font-Bold="True" />
                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
            </asp:DetailsView>
        </div>
    </form>
</body>
</html>
