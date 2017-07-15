<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Upload.aspx.cs" Inherits="WebUsingService.Upload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">    
    <title></title>
    <script type="text/javascript">
        function select(imageName) {
            window.opener.document.getElementById('<%=id%>').value = imageName;
            close();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="upload">
        <asp:Label runat="server" ID="lblStatus" CssClass="status" />
        <asp:Label ID="lblImageFile" runat="server" Text="Image File:" AssociatedControlID="upImage"/>  
        <asp:FileUpload ID="upImage" runat="server" />
        <asp:Button ID="btnUpload" runat="server" Text="Upload" />
        <hr />        
        <div class="imagelist">
            <asp:DataList runat="server" ID="dlImage" RepeatColumns="5" RepeatDirection="Horizontal">
                <ItemTemplate>
                    <a href="javascript:void(0)" onclick="select('<%#Eval("Name") %>')">
                        <img src='<%# ToUploadImage(Eval("Name").ToString()) %>' alt='' />
                    </a>
                    <p>
                        <%# Eval("Name") %>
                    </p>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
    </form>
</body>
</html>
