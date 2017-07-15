<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CoursesView.ascx.cs" Inherits="WebApp.Admin.Controls.CoursesView" %>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<formview>
<div>    
    <table class="list">
        <tr>
            <th class="cid"><input type="checkbox" id="chkAll" /></th>
            <th>Name</th>
            <th>Category</th>
            <th>Teacher</th>
            <th>Start Date</th>
            <th>Duration</th>
            <th>Fee</th>            
            <th>Is Active</th>
            <th class="cid"></th>
        </tr>
        <asp:Repeater ID="repCourses" runat="server" OnItemCommand="repCourses_ItemCommand">
            <ItemTemplate>
                <tr <%# Container.ItemIndex%2==0 ? "class='even'" : "" %>>
                    <td class="cid">
                        <%# ShowData(Container.DataItem, "CourseID") %>
                    </td>
                    <td >
                        <asp:LinkButton runat="server" ID="lnkName" ToolTip="Update" CommandName="edit" CommandArgument='<%#Eval("CourseID")%>' ><%#Eval("Name") %></asp:LinkButton>
                    </td>
                    <td><%#Eval("CategoryName")%></td>
                    <td><%#Eval("TeacherName")%></td>
                    <td><%#Eval("StartDate")%></td>
                    <td><%#Eval("Duration")%></td>
                    <td><%#Eval("Fee")%></td>
                    <td>
                        <asp:ImageButton runat="server" ID="ibtnIsActive" CommandName="UpdateIsActive" 
                                    CommandArgument='<%#Eval("CategoryID") %>' ImageUrl='<%# ShowData(Container.DataItem, "IsActive") %>' /> 
                    </td>
                    <td class="cid"><%#Eval("CourseID")%></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</div>
</formview>
</ContentTemplate>
</asp:UpdatePanel>