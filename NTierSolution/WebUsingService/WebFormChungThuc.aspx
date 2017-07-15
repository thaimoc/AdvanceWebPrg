<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebFormChungThuc.aspx.cs" Inherits="WebUsingService.WebFormChungThuc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label runat="server" ID="lblStatusInfo"></asp:Label>
    <table>
        <tr>
            <td>User Name</td>
            <td><asp:TextBox runat="server" ID="txtUserName"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Password: </td>
            <td><asp:TextBox runat="server" ID="txtPass" TextMode="Password"></asp:TextBox></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button runat="server" ID="btnSubmit" Text="Submit" 
                    onclick="btnSubmit_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
