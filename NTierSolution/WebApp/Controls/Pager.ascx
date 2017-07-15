<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Pager.ascx.cs" Inherits="WebApp.Controls.Pager" %>
<div class="pager">
    Page
    <asp:Label ID="lblCurrentPage" runat="server" />
    of
    <asp:Label ID="lblHowManyPages" runat="server" />
    |
    <asp:HyperLink ID="lnkPrevious" runat="server" Text="Previous" />
    <asp:Repeater runat="server" ID="repPager">
        <ItemTemplate>
            <asp:HyperLink runat="server" ID="lnk" Text='<%#Eval("Page") %>' 
                CssClass='<%#Eval("Url").ToString()=="" ? "current" : "link" %>'
                NavigateUrl='<%#Eval("Url") %>'/>
        </ItemTemplate>
    </asp:Repeater>
    <asp:HyperLink ID="lnkNext" runat="server" Text="Next" />
</div>