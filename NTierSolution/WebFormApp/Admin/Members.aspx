<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Members.aspx.cs" Inherits="WebFormApp.Admin.Members" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <table class="list">
            <tr>
                <th class="cid"><input type="checkbox" id="chkAll" /></th>
                <th>Name(UserName)</th>
                <th>Email</th>
                <th>IsActive</th>
                <th>Create Date</th>
                <th>Last LogIn</th>
                <th class="small">ID</th>
            </tr>
            <asp:Repeater runat="server" ID="repMembers">
                <ItemTemplate>
                    <tr <%#Container.ItemIndex%2 == 0? "class='even'":""%> >
                        <td class="small"><%#ShowData(Container.DataItem, "MemberID")%></td>
                        <td><%#Eval("Name") %></td>
                        <td><%#Eval("Email") %></td>
                        <td class="small">
                            <asp:ImageButton runat="server" ID="ibtnOnFrontPage" CommandName="" 
                            CommandArgument='' ImageUrl='<%# ShowData(Container.DataItem, "IsActive") %>' /> 
                        </td>
                        <td><%#Eval("CreateDate") %></td>
                        <td><%#Eval("LastLogin") %></td>
                        <td class="id"><%#Eval("MemberID")%></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <asp:HyperLink runat="server" NavigateUrl="~/Register.aspx">Add new a user</asp:HyperLink>
        <asp:LinkButton runat="server" ID="lnkDelete">Delete all selected</asp:LinkButton>
    </div>
</asp:Content>

