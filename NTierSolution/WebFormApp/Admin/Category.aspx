<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="WebFormApp.Admin.Category" %>
<%@ Register Src="~/Admin/Controls/CategoriesEditRepeater.ascx" TagName="EditRepeater" TagPrefix="UC"%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="title">Categories</div>
    <UC:EditRepeater runat="server" />
</asp:Content>
