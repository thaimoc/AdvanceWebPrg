<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ThemeSwitch.ascx.cs" Inherits="WebApp.Admin.Controls.ThemeSwitch" %>
<div id="themeroller">
    <label>Choose Theme:</label>
    <asp:DropDownList runat="server" ID="ddlThemes"  AutoPostBack="true"
        onselectedindexchanged="ddlThemes_SelectedIndexChanged">
        <%--<asp:ListItem Text="Blue" Value="Blue" />
        <asp:ListItem Text="Brown" Value="Brown"/>
        <asp:ListItem Text="Green" Value="Green"/>
        <asp:ListItem Text="Orange" Value="Orange"/>--%>
    </asp:DropDownList>
</div>