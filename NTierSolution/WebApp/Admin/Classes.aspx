<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Classes.aspx.cs" Inherits="WebApp.Admin.Classes" %>
<%@ Register src="Controls/EditClass.ascx" tagname="EditClass" tagprefix="uc1" %>
<%@ Register src="Controls/ClassesView.ascx" tagname="ClassesView" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <div>
        <asp:LinkButton ID="lnkAdd" runat="server" onclick="lnkAdd_Click">Add new a class</asp:LinkButton>
        <asp:LinkButton ID="lnkDeleteAllSelected" runat="server" CssClass="multidelete">Delete all selected</asp:LinkButton>
    </div>

    <uc2:ClassesView ID="classesView" runat="server"/>

    <uc1:EditClass ID="editClass" runat="server"/>
    
</asp:Content>
