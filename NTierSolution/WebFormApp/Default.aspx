<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormApp.WebForm1" %>

<%@ Register Assembly="ServerControls" Namespace="ServerControls" TagPrefix="cc1" %>


<%@ Register src="Controls/StatusUserOnline.ascx" tagname="StatusUserOnline" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="grid_9">
        <div class="grid_5 alpha">
            <div class="grid_1 alpha">
                Giá trị
            </div>
            <div class="grid_4 omega">
                <asp:TextBox runat="server" ID="txtValue" CssClass="grid_4"></asp:TextBox>
            </div>
        </div>
        <div class="grid_4 omega">
            <asp:Button runat="server" ID="btnView" Text="Xem kết quả" />
        </div>
        <div class="clear"></div>
        <uc1:StatusUserOnline ID="StatusUserOnline1" runat="server" />
    </div>
</asp:Content>




