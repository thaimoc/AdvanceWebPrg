<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HtmlScraping2.aspx.cs" Inherits="WebUsingService.HtmlScraping2" %>
<%@ OutputCache Duration="200" VaryByParam="None" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <th>STT</th>
            <th>HO VA TEN</th>
        </tr>    
    <asp:Repeater runat="server" ID="repStudents">
        <ItemTemplate>
            <tr>
                <td><%#Container.ItemIndex + 1 %></td>
                <td><%#Container.DataItem.ToString() %></td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
    </table>
</asp:Content>
