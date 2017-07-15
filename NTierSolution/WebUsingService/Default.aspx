<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebUsingService._Default" %>
    <%@ OutputCache Duration="200" VaryByParam="None" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome to ASP.NET!
    </h2>        
    
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
              <table style="border: 1px solid">        
                <tr>
                    <td>Fraction A:</td>
                    <td><asp:TextBox runat="server" ID="txtAx"></asp:TextBox>                
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ErrorMessage="(*)" ControlToValidate="txtAx" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                            ErrorMessage="Value is not accepted!" ControlToValidate="txtAx" Display="Dynamic"
                            ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                    </td>
                    <td>/<asp:TextBox runat="server" ID="txtAy"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ErrorMessage="(*)" ControlToValidate="txtAy" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                            ErrorMessage="Value is not accepted!" ControlToValidate="txtAy" Display="Dynamic"
                            ValidationExpression="([1-9]([0-9]*))|(0[1-9]+)"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>Choose Operator:</td>
                    <td colspan="2" align="center">
                        <asp:DropDownList ID="ddlOperator" runat="server" Width="100%">
                            <asp:ListItem Value="0" Selected="True" >+</asp:ListItem>
                            <asp:ListItem Value="1" >-</asp:ListItem>
                            <asp:ListItem Value="2" >*</asp:ListItem>
                            <asp:ListItem Value="3" >/</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Fraction B: </td>
                    <td><asp:TextBox runat="server" ID="txtBx"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ErrorMessage="(*)" ControlToValidate="txtBx" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                            ErrorMessage="Value is not accepted!" ControlToValidate="txtBx" Display="Dynamic"
                            ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                    </td>
                    <td>/<asp:TextBox runat="server" ID="txtBy"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                            ErrorMessage="(*)" ControlToValidate="txtBy" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                            ErrorMessage="Value is not accepted!" ControlToValidate="txtBy" Display="Dynamic"
                            ValidationExpression="([1-9]([0-9]*))|(0[1-9]+)"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="3"><hr /></td>
                </tr>
                <tr>
                    <td>Result:</td><td><asp:TextBox runat="server" ID="txtAddResult" Enabled="false"></asp:TextBox></td><td align="center">
                    <asp:Button runat="server" ID="btnAdd" Text="Do action" onclick="btnAdd_Click" /></td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
