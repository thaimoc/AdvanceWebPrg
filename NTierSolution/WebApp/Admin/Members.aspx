<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Members.aspx.cs" Inherits="WebApp.Admin.Members" %>
<%@ Register src="../Controls/Pager.ascx" tagname="Pager" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div>
            <uc1:Pager ID="pagerTop" runat="server" />
            <asp:HyperLink runat="server" ID="lnkAdd" Text="Add new a user" NavigateUrl="~/Account/Register.aspx?ReturnUrl=~/Admin/Members.aspx" />
            <asp:LinkButton runat="server" ID="lnkDeleteSelected" Text="Delete all selected" CssClass="multidelete" OnClick="lnkDeleteSelected_Click"></asp:LinkButton> 
        </div>
        <table class="list">
            <tr>
                <th class="cid"><input type="checkbox" id="chkAll" /></th>
                <th>Name</th>
                <th>Email</th>
                <th>Is Active</th>
                <th>Created date</th>
                <th>Last Login</th>                
                <th>ID</th>
            </tr>
            <asp:Repeater runat="server" ID="repMembers" OnItemCommand="repMembers_ItemCommand">
                <ItemTemplate>                
                    <tr <%#Container.ItemIndex%2 == 0? "class='even'":""%>>
                        <td class="small"><%#ShowData(Container.DataItem, "MemberID", "Member")%></td>
                        <td><%#Eval("Name") %></td>
                        <td><%#Eval("Email") %></td>
                        <td>
                            <asp:ImageButton runat="server" ID="ibtnIsActive" CommandName="UpdateIsActive" 
                                CommandArgument='<%#Eval("MemberID") %>' ImageUrl='<%# ShowData(Container.DataItem, "IsActive", "Member") %>' /> 
                        </td>
                        <td><%#Eval("CreateDate") %></td>
                        <td><%#Eval("LastLogin") %></td>                        
                        <td class="id"><%#Eval("MemberID")%></td>
                    </tr>
                </ItemTemplate>                
            </asp:Repeater>
        </table>
        <uc1:Pager ID="pagerBottom" runat="server" />
    </div>
</asp:Content>
