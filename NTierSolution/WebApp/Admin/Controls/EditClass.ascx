<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditClass.ascx.cs" Inherits="WebApp.Admin.Controls.EditClass" %>

    <div>
        
        <table>
            <asp:Label ID="lblStatus" runat="server" Text="" CssClass="status"></asp:Label>
            <tr>
                <td>Course:</td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlCourses" AppendDataBoundItems="true" 
                        onselectedindexchanged="ddlCourses_SelectedIndexChanged">
                        <asp:ListItem Value="0">--Choose Course--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ErrorMessage="Choose a course!" ControlToValidate="ddlCourses" 
                        Display="Dynamic" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CustomValid" runat="server" 
                        ControlToValidate="ddlCourses" 
                        ErrorMessage="Please choose a course have not been completed" 
                        ForeColor="Red"></asp:CustomValidator>
                </td>
            </tr>            
            <tr>
                <td>Your Name:</td>
                <td>
                    <asp:TextBox runat="server" ID="txtMember" Enabled="false" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>RegisterDay:</td>
                <td>
                    <asp:TextBox runat="server" ID="txtRegisterDay" Enabled="false"></asp:TextBox>
                </td>
            </tr>           
            <tr>
                <td>Assessement:</td>
                <td>
                    <asp:TextBox runat="server" ID="txtAssessement" Rows="10" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Password:</td>
                <td><asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtPassword" Display="Dynamic" 
                        ErrorMessage="Enter your password!" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CustomValidatorPass" runat="server" 
                        ControlToValidate="txtPassword" ErrorMessage="Password is not corect!" 
                        ForeColor="Red"></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td>Retype Password:</td>
                <td><asp:TextBox ID="txtRetypePass" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ControlToCompare="txtPassword" ControlToValidate="txtRetypePass" 
                        Display="Dynamic" ErrorMessage="Retype password is not sample" ForeColor="Red"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" Text="Register" 
                        onclick="btnSubmit_Click" />
                    <asp:Button ID="btnRefresh" runat="server" Text="Refresh" 
                        onclick="btnRefresh_Click" />
                </td>
            </tr>
        </table>
    </div>
