<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HtmlScraping.aspx.cs" Inherits="WebUsingService.HtmlScraping" %>
<%@ OutputCache Duration="200" VaryByParam="None" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <th>STT</th>
            <th>MSSV</th>
            <th>Ho</th>
            <th>Ten</th>
        </tr>    
    <asp:Repeater runat="server" ID="repStudents">
        <ItemTemplate>
            <tr>
                <td><%#Container.ItemIndex + 1 %></td>
                <td><%#Eval("Code") %></td>
                <td><%#Eval("LastName") %></td>
                <td><%#Eval("FirstName") %></td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
    </table>
</asp:Content>
