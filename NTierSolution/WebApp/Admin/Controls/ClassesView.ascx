<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ClassesView.ascx.cs" Inherits="WebApp.Admin.Controls.ClassesView" %>
    
    <div>
        <table class="list">
            <tr>
                <th class="cid"><input type="checkbox" id="chkAll" /></th>
                <th>Course</th>
                <th>Member</th>
                <th>Register Day</th>
                <th>Completed</th>
                <th>Assessement</th>
            </tr>
            <asp:Repeater ID="repData" runat="server">
                <ItemTemplate>
                    <tr <%#Container.ItemIndex%2==0?"class='even'" : "" %>>
                        <td class="cid">
                            <%# ShowData(Container.DataItem, "ID") %>
                        </td>
                        <td><%# Eval("CourseName") %></td>
                        <td><%# Eval("MemberName") %></td>
                        <td><%# Eval("RegisterDay")%></td>
                        <td>
                             <asp:ImageButton ID="ibnCompleted" runat="server" ImageUrl='<%# ShowData(Container.DataItem, "Completed") %>' />
                        </td>
                        <td><%# Eval("Assessement")%></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>            
        </table>
    </div>