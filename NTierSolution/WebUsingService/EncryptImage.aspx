<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EncryptImage.aspx.cs" Inherits="WebUsingService.EncryptImage" %>
<%@ OutputCache Duration="200" VaryByParam="None" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <td>Choose image path:</td>
            <td>
                <asp:TextBox runat="server" ID="txtImagePath"></asp:TextBox>
                <a href="javascript:void(0)" target="_blank"
                onclick='window.open("Upload.aspx?id=<%=txtImagePath.ClientID %>", "Upload", "height=400, width=550"); return false;'>Select</a>
            </td>
        </tr>
        <tr>
            <td>
                <asp:RadioButton runat="server" ID="rdMD5" Text="MD5" GroupName="EncryptGroup" Checked="true" />
                <asp:RadioButton runat="server" ID="rdSHA1" Text="SHA1" GroupName="EncryptGroup" />
            </td>
            <td>
                <asp:Button runat="server" ID="btnEncrypt" Text="Encrypt" 
                    onclick="btnEncrypt_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:TextBox runat="server" ID="txtEncryptText" Enabled="false" Width="350px" TextMode="MultiLine" Rows="10" Columns="70"></asp:TextBox>
            </td>
        </tr>
    </table>

</asp:Content>
