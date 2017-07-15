<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoriesEditRepeater.ascx.cs" Inherits="WebFormApp.Admin.Controls.CategoriesEditRepeater" %>
<script src="../Scripts/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.msgBox/Scripts/jquery.msgBox.js" type="text/javascript"></script>
    <link href="Scripts/jquery.msgBox/Styles/msgBoxLight.css" rel="stylesheet" type="text/css" />

    

    <script src="Scripts/jquery.popBox1.3.0/popBox1.3.0.min.js" type="text/javascript"></script>
    <link href="Scripts/jquery.popBox1.3.0/popBox1.3.0.css" rel="stylesheet" type="text/css" />
    
   <%-- <script src="Scripts/tinymce/tiny_mce.js" type="text/javascript"></script>
    <script src="Scripts/tinymce/tiny_mce_popup.js" type="text/javascript"></script>--%>

<script type="text/javascript">

    $(document).mouseenter(function () {
        $('.inputbox').popBox();
    });

    function ShowError(messages) {
        $.msgBox({
            title: "Error Message!",
            content: messages,
            type: "error",
            buttons: [{ value: "Ok"}],
            afterShow: function (result) { }
        });
    }

    function ShowInfo(messages) {
        $.msgBox({
            title: "Messages",
            content: messages,
            type: "info"
        });
    }

    function OnSave(obj) {
        // Find the row this button is in
        var tr = $(obj).closest("tr");
        // Get the value from the edit control
        var nameEdit = tr.find("[id*='nameEdit']").val();
        // assign value to hidden input
        tr.find("[id*='nameHidden']").val(nameEdit);

        var desEdit = tr.find("[id*='descriptionEdit']").val();
        // assign value to hidden input
        tr.find("[id*='descriptionHidden']").val(desEdit);

        var parEdit = tr.find('[id*=parentEdit] option:selected').val();
        tr.find("[id*='parentNameHidden']").val(parEdit);        
    }

    </script>
    
<asp:ScriptManager runat="server"></asp:ScriptManager>
<asp:UpdatePanel runat="server">
    <ContentTemplate>
        <asp:TextBox ID="inputbox" runat="server"></asp:TextBox>
        <asp:Label ID="lbstatusInfo" runat="server" Text=""></asp:Label>
        <asp:Repeater runat="server" ID="rptCategories" >
            <HeaderTemplate>
                <table>
                    <tr>
                        <th class="cid"><input type="checkbox" id="chkAll" /></th>
                        <th>Handle</th>
                        <th>Parent</th>
                        <th>Name</th>
                        <th>Description</th>
                        <th>IsActive</th>
                        <th>ID</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
              <tr class="even">
                    <td><input type="checkbox" value='<%#Eval("CategoryID") %>' name="cid" id="cid" /></td>
                    <td>
                        <asp:ImageButton ID="Edit" ImageUrl="~/Admin/Images/EditDocument.png" runat="server" CommandName="update" />
                        <asp:ImageButton ID="Delete" ImageUrl="~/Admin/Images/Delete_black_32x32.png" runat="server" CommandName="delete" />
                    </td>
                    <td class="link">
                       <%-- <%# Eval("ParentID") == null ? String.Empty : "<a href='EditCategory.aspx?cid='" + Eval("ParentID") + ">" + Eval("ParentName") + "</a>"%>--%>
                       <%-- <asp:Label ID="parentId" Text='<%#Eval("ParentID") %>' Visible="false" runat="server"></asp:Label>
                        <asp:DropDownList ID="ddlParents" runat="server" AppendDataBoundItems="true">
                            <asp:ListItem Value="0" Text="--Choose Parent--"></asp:ListItem>
                        </asp:DropDownList>--%>
                        <asp:HyperLink  runat="server" ID="parentName" NavigateUrl='EditCategory.aspx?cid=<%#Eval("ParentID") %>' Text='<%#Eval("ParentName") %>'></asp:HyperLink>
                        <asp:PlaceHolder runat="server" ID="parentNamePlaceHolder" />                        
                        <input type="hidden" runat="server" id="parentNameHidden" />
                    </td>
                    <td class="link">
                        <asp:HyperLink runat="server" ID="name" NavigateUrl='EditCategory.aspx?cid=<%#Eval("CategoryID") %>' Text='<%#Eval("Name") %>'></asp:HyperLink>
                        <asp:PlaceHolder runat="server" ID="nameEditPlaceHolder" />
                        <input type="hidden" runat="server" id="nameHidden" visible="false" />
                    </td>
                    <td>
                        <asp:Label runat="server" ID="description"><%#Eval("Description") %></asp:Label>
                        <asp:PlaceHolder runat="server" ID="descriptionEditPlaceHolder" />
                        <input type="hidden" runat="server" id="descriptionHidden" visible="false" />
                    </td>
                    <td>
                        <%--<asp:CheckBox runat="server" ID="chkIsActive" Checked='<%#Eval("IsActive") %>' />--%>
                         <asp:ImageButton ID="updateIsActive" ImageUrl='<%#Eval("IsActive").ToString() == "True"?"~/Admin/Images/security_high.png":"~/Admin/Images/security_low.png" %>' 
                          CommandArgument='<%# Eval("CategoryID") + "_" + Eval("IsActive").ToString() %>' CommandName="changeIsActive" runat="server"/>
                    <td>
                        <asp:HiddenField ID="categoryIDHidden" runat="server" Value='<%#Eval("CategoryID") %>' />
                        <%#Eval("CategoryID") %>
                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr class="even">
                    <td><input type="checkbox" value='<%#Eval("CategoryID") %>' name="cid" id="cid" /></td>
                    <td>
                        <asp:ImageButton ID="Edit" ImageUrl="~/Admin/Images/EditDocument.png" runat="server" CommandName="update" />
                        <asp:ImageButton ID="Delete" ImageUrl="~/Admin/Images/Delete_black_32x32.png" runat="server" CommandName="delete" />
                    </td>
                    <td class="link">
                        <%--<%# Eval("ParentID") == null ? String.Empty : "<a href='EditCategory.aspx?cid='" + Eval("ParentID") + ">" + Eval("ParentName") + "</a>"%>--%>
                       <%-- <asp:Label ID="parentId" Text='<%#Eval("ParentID") %>' Visible="false" runat="server"></asp:Label>
                        <asp:DropDownList ID="ddlParents" runat="server" AppendDataBoundItems="true">
                            <asp:ListItem Value="0" Text="--Choose Parent--"></asp:ListItem>
                        </asp:DropDownList>--%>
                        <asp:HyperLink  runat="server" ID="parentName" NavigateUrl='EditCategory.aspx?cid=<%#Eval("ParentID") %>' Text='<%#Eval("ParentName") %>'></asp:HyperLink>
                        <asp:PlaceHolder runat="server" ID="parentNamePlaceHolder" />
                        <input type="hidden" runat="server" id="parentNameHidden" />
                    </td>
                    <td class="link">
                        <asp:HyperLink runat="server" ID="name" NavigateUrl='EditCategory.aspx?cid=<%#Eval("CategoryID") %>' Text='<%#Eval("Name") %>'></asp:HyperLink>
                        <asp:PlaceHolder runat="server" ID="nameEditPlaceHolder" />
                        <input type="hidden" runat="server" id="nameHidden" visible="false" />
                    </td>
                    <td>
                        <asp:Label runat="server" ID="description"><%#Eval("Description") %></asp:Label>
                        <asp:PlaceHolder runat="server" ID="descriptionEditPlaceHolder" />
                        <input type="hidden" runat="server" id="descriptionHidden" visible="false" />
                    </td>
                    <td>
                        <%--<asp:CheckBox runat="server" ID="chkIsActive" Checked='<%#Eval("IsActive") %>' />--%>
                         <asp:ImageButton ID="updateIsActive" ImageUrl='<%#Eval("IsActive").ToString() == "True"?"~/Admin/Images/security_high.png":"~/Admin/Images/security_low.png" %>' 
                          CommandArgument='<%# Eval("CategoryID") + "_" + Eval("IsActive").ToString() %>' CommandName="changeIsActive" runat="server"/>
                    <td>
                        <asp:HiddenField ID="categoryIDHidden" runat="server" Value='<%#Eval("CategoryID") %>' />
                        <%#Eval("CategoryID") %>
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <FooterTemplate>
                <tr>
                    <td><input type="checkbox" name="cid" id="cid" /></td>
                    <td>
                        <asp:ImageButton ID="Add" ImageUrl="~/Admin/Images/112_Plus_Blue_32x32_72.png" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="parentId" Text='' Visible="false" runat="server"></asp:Label>
                        <asp:DropDownList ID="ddlParents" runat="server" AppendDataBoundItems="true">
                            <asp:ListItem Value="0" Text="--Choose Parent--"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="newName"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="newDescription"></asp:TextBox>
                    </td>
                    <td>
                        <asp:CheckBox runat="server" ID="newActive" />
                    </td>
                    <td>
                        Add New
                    </td>
                </tr>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </ContentTemplate>
</asp:UpdatePanel>
