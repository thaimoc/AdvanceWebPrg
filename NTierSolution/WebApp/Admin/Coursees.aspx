<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Coursees.aspx.cs" Inherits="WebApp.Admin.Coursees" %>
<%@ Register src="Controls/EditCourse.ascx" tagname="EditCourse" tagprefix="uc1" %>
<%@ Register src="Controls/CoursesView.ascx" tagname="CoursesView" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
        <div>
            <div>
                <asp:LinkButton runat="server" ID="lnkNew" >Add new a course</asp:LinkButton>
                <asp:LinkButton runat="server" ID="lnkDeleteAllSelected" CssClass="multidelete" >Delete all selected</asp:LinkButton>
            </div>                
            <uc2:CoursesView ID="coursesView" runat="server" />
        </div>
        <div> 
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:PlaceHolder runat="server" ID="editCoursePlaceHolder">
                <uc1:EditCourse ID="editCourse" runat="server" />
                </asp:PlaceHolder>
            </ContentTemplate>
            </asp:UpdatePanel>
            
        </div>    
</asp:Content>
