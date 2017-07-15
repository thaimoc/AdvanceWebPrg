<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="temp.aspx.cs" Inherits="WebFormApp.temp" %>
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
    </div>
</asp:Content>
