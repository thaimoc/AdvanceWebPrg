<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GetIp.aspx.cs" Inherits="WebUsingService.GetIp" %>
<%@ OutputCache Duration="200" VaryByParam="None" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <table>
            <tr>
                <td>Your ip: </td>
                <td><asp:TextBox runat="server" ID="txtIp" Width="600px" TextMode="MultiLine" Enabled="false"></asp:TextBox></td>                
            </tr>
        </table>
    </div>
</asp:Content>
