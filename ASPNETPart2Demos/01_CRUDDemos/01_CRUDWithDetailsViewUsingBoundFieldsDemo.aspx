﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="01_CRUDWithDetailsViewUsingBoundFieldsDemo.aspx.cs" Inherits="_01_CRUDWithDetailsViewUsingBoundFieldsDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DetailsView ID="DetailsView1" runat="server" AllowPaging="True" AutoGenerateRows="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" Height="305px" OnPageIndexChanging="DetailsView1_PageIndexChanging" Width="367px" AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" AutoGenerateInsertButton="True" DataKeyNames="EmployeeId" OnItemDeleting="DetailsView1_ItemDeleting" OnItemInserting="DetailsView1_ItemInserting" OnItemUpdating="DetailsView1_ItemUpdating" OnModeChanging="DetailsView1_ModeChanging">
                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                <EditRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                <Fields>
                    <asp:BoundField HeaderText="Employee ID" DataField="EmployeeId" />
                    <asp:BoundField HeaderText="Last Name" DataField="LastName" />
                    <asp:BoundField HeaderText="First Name" DataField="FirstName" />
                    <asp:BoundField HeaderText="Title" DataField="Title" />
                    <asp:BoundField HeaderText="Title Of Courtesy" DataField="TitleOfCourtesy" />
                </Fields>
                <FooterStyle BackColor="Tan" />
                <HeaderStyle BackColor="Tan" Font-Bold="True" />
                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
            </asp:DetailsView>
        </div>
    </form>
</body>
</html>