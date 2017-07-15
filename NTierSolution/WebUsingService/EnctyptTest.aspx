<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EnctyptTest.aspx.cs" Inherits="WebUsingService.EnctyptTest" %>
<%@ OutputCache Duration="200" VaryByParam="None" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Encrypt algorythm
    </h2>  
    <table>
        <tr>
            <td>Text Encrypt:</td>
            <td><asp:TextBox runat="server" ID="txtEncrypt" Width="350px"></asp:TextBox></td>
            <td><asp:DropDownList runat="server" ID="ddlAlgorythm">
                <asp:ListItem Value="Md5">MD5</asp:ListItem>
                <asp:ListItem Value="SHA1">SHA1</asp:ListItem>
            </asp:DropDownList></td>
            <td><asp:Button runat="server" ID="btnEncrypt" Text="Encrypt" 
                    onclick="btnEncrypt_Click" /></td>
        </tr>
    </table>
    
</asp:Content>
