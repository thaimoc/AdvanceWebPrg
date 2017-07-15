<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="About.aspx.cs" Inherits="WebUsingService.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Convet Money
    </h2>
    <p>
        &nbsp;<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
               <table>
                <tr>
                    <td colspan="5" align="center">Convert Money:</td>
                </tr>
                <tr>
                    <td>Input Value:</td>
                    <td><asp:TextBox runat="server" ID="txtValue"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                            ControlToValidate="txtValue" Display="Dynamic" ErrorMessage="(*)" 
                            ForeColor="Red"></asp:RequiredFieldValidator>

                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" 
                            ControlToValidate="txtValue" ErrorMessage="Value is not accepted!" 
                            ValidationExpression="([0-9]+)|([0-9]+\.[0-9]{4})"></asp:RegularExpressionValidator>

                    </td>
                    <td><asp:DropDownList runat="server" ID="ddlTypeConvert" >
                        <asp:ListItem Value="USD2VND">USD To VND</asp:ListItem>
                        <asp:ListItem Value="VND2USD">VND To USD</asp:ListItem>
                        <asp:ListItem Value="EUR2VND">EUR To VND</asp:ListItem>
                        <asp:ListItem Value="VND2EUR">VND To EUR</asp:ListItem>
                        <asp:ListItem Value="YP2VND">YP To VND</asp:ListItem>
                        <asp:ListItem Value="VND2YP">VND To YP</asp:ListItem>
                    </asp:DropDownList></td>
                    <td><asp:Button runat="server" ID="btnConvert" Text="Convert" 
                            onclick="btnConvert_Click" /></td>
                    <td><asp:TextBox runat="server" ID="txtConvertValue" Enabled="false"></asp:TextBox></td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    </p>
</asp:Content>
