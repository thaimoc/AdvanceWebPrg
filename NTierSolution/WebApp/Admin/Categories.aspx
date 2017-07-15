<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="WebApp.Admin.Categories" %>
<%@ Register src="Controls/EditCategory.ascx" tagname="EditCategory" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
        <div>        
            <div>
                <asp:LinkButton runat="server" ID="lnkAdd" Text="Add new a category" OnClick="lnkAdd_Click"></asp:LinkButton>
                <asp:LinkButton runat="server" ID="lnkDeleteSelected" Text="Delete all selected" CssClass="multidelete" ></asp:LinkButton> 
            </div>
            <table class="list">
                <tr>
                    <th class="cid"><input type="checkbox" id="chkAll" /></th>
                    <th>Name</th>
                    <th>Parent</th>
                    <th>Is Active</th>
                    <th>Descrition</th>            
                    <th>ID</th>
                </tr>
                <tr>
                    <td colspan="6">
                        <asp:PlaceHolder runat="server" ID="newPalaceHolder" Visible="false">
                            <uc1:EditCategory ID="editCategory" runat="server" />
                        </asp:PlaceHolder>                    
                    </td>
                </tr>            
                <asp:Repeater runat="server" ID="repCategories" OnItemCommand="repCategories_ItemCommand">
                    <ItemTemplate>
                        <tr <%#Container.ItemIndex%2 == 0? "class='even'":"" %>>
                            <td>
                                <%#ShowData(Container.DataItem, "CategoryID", "Category")%>
                            </td>
                            <td>
                                <asp:LinkButton runat="server" ID="lnkUpdate" Text='<%#Eval("Name") %>' CommandName="edit" ToolTip="Update" ></asp:LinkButton>
                            </td>
                            <td><%#Eval("ParentName")%></td>
                            <td>
                                <asp:ImageButton runat="server" ID="ibtnIsActive" CommandName="UpdateIsActive" 
                                    CommandArgument='<%#Eval("CategoryID") %>' ImageUrl='<%# ShowData(Container.DataItem, "IsActive", "Category") %>' /> 
                            </td>
                            <td><%#Eval("Description")%></td>
                            <td class="id"><%#Eval("CategoryID")%></td>
                        </tr>
                        <tr <%#Container.ItemIndex%2 == 0? "class='even'":"" %>>
                            <td colspan="6">
                                <asp:PlaceHolder runat="server" ID="updatePlaceHodler">
                                    <uc1:EditCategory ID="inSideEditCategory" runat="server" Visible="false" />
                                </asp:PlaceHolder>
                            </td>
                        </tr>                              
                    </ItemTemplate>                
                </asp:Repeater>
            </table>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
