<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditCourse.ascx.cs" Inherits="WebApp.Admin.Controls.EditCourse" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>    
        <div>            
            <table width="100%">
                <tr>
                    <td colspan="8"><asp:Label runat="server" ID="lblSatusInfo" CssClass="status"></asp:Label></td>
                </tr>
                <tr>
                    <td>CourseID:</td> <td><asp:TextBox runat="server" ID="txtID" Enabled="false"></asp:TextBox></td>                                                      
                    <td>Name:</td><td><asp:TextBox runat="server" ID="txtName"></asp:TextBox></td>

                    <td>Category:</td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlCategories" AppendDataBoundItems="true" 
                            style="text-align: right">
                            <asp:ListItem Value="0">---Choose a category---</asp:ListItem>
                        </asp:DropDownList>
                    </td>

                    <td>Teacher:</td> 
                    <td>
                        <asp:DropDownList runat="server" ID="ddlMembers" AppendDataBoundItems="true" 
                            style="text-align: right">
                            <asp:ListItem Value="0">---Choose a teacher---</asp:ListItem>
                        </asp:DropDownList>                        
                    </td>
                </tr>
                <tr>
                    <td>Sart Date:</td><td><asp:TextBox runat="server" ID="txtStartDate" CssClass="datepicker" ></asp:TextBox></td>

                    <td>Duration:</td><td><asp:TextBox runat="server" ID="txtDuration" ></asp:TextBox></td>
                
                    <td>Fee:</td><td><asp:TextBox runat="server" ID="txtFee" ></asp:TextBox></td>

                    <td>IsActive:</td><td><asp:CheckBox runat="server" ID="chkIsActive" ></asp:CheckBox></td>
                </tr>
                <tr>
                    <td colspan="8">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtName" Display="Dynamic" 
                            ErrorMessage="Must enter course's name!" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                            ErrorMessage="Please choose a category!" Display="Dynamic" ForeColor="Red" 
                            InitialValue="0" ControlToValidate="ddlCategories"></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ErrorMessage="Please choose a teacher!" Display="Dynamic" ForeColor="Red" 
                            InitialValue="0" ControlToValidate="ddlMembers"></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ControlToValidate="txtStartDate" Display="Dynamic" 
                            ErrorMessage="Please iput Start date!" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                            ControlToValidate="txtDuration" Display="Dynamic" 
                            ErrorMessage="Please enter a duration time!" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                            ControlToValidate="txtDuration" Display="Dynamic" 
                            ErrorMessage="Duration's format is not correct!" ForeColor="Red" 
                            ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                            ControlToValidate="txtFee" Display="Dynamic" ErrorMessage="Must input a fee!" 
                            ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                            ControlToValidate="txtFee" Display="Dynamic" 
                            ErrorMessage="Fee's format is not cerrected!" ForeColor="Red" 
                            ValidationExpression="[0-9]+\.[0-9]{0,4}"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="8">
                        Introduction:
                        <asp:TextBox runat="server" ID="txtIntroduction" CssClass="tinymce editor" TextMode="MultiLine" Rows="20" Width="100%" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="7">&nbsp;</td>
                    <td>
                        <asp:Button runat="server" ID="btnSave" Text="Save" OnClick="btnSave_Click" />
                        <input id="Reset1" type="reset" value="Reset" />
                    </td>
                </tr>
            </table>             
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
