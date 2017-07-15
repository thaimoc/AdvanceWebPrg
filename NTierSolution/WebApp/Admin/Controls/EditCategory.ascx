<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditCategory.ascx.cs" Inherits="WebApp.Admin.Controls.EditCategory" %>
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>    
        <div>            
            <table class="list">
                <tr>
                    <td><asp:ImageButton runat="server" ID="btnSave" OnClick="btnSave_Click" /></td>
                    <td><asp:TextBox runat="server" ID="txtName"></asp:TextBox></td>
                    <td>                        
                        <asp:DropDownList runat="server" ID="ddlParent" AppendDataBoundItems="true">
                            <asp:ListItem Value="0">Choose Parent</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td><asp:CheckBox runat="server" ID="chkIsActive" /></td>
                    <td><asp:TextBox runat="server" ID="txtDescription"></asp:TextBox> </td>
                    <td class="cid">
                        <asp:Label runat="server" ID="lblID"></asp:Label>
                    </td>
                </tr>
                
                <tr>
                    <td colspan="6">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ControlToValidate="txtName" Display="Dynamic" ErrorMessage="Must enter category's name" 
                            ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="nameCustomValidator" runat="server" Display="Dynamic" 
                            ErrorMessage="Category's name is exited!" ForeColor="Red"></asp:CustomValidator>
                    </td>
                </tr>
            </table>             
        </div>
    </ContentTemplate>
</asp:UpdatePanel>


