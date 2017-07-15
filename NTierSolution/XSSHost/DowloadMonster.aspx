<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DowloadMonster.aspx.cs" Inherits="XSSHost.DowloadMonster" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-2.0.0.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.fileDownload.js" type="text/javascript"></script>
    <script src="Scripts/Support/shCore.js" type="text/javascript"></script>
    <script src="Scripts/Support/shBrushJScript.js" type="text/javascript"></script>
    <script src="Scripts/Support/shBrushXml.js" type="text/javascript"></script>
    <script>
        //
        //With jquery.fileDownload.js
        //custom use with promises
        //
        $(document).on("click", "a.fileDownloadPromise", function () {
            $.fileDownload($(this).prop('href')) // $.fileDownload($(this).prop('href'))
        .done(function () { alert('File download a success!'); })
        .fail(function () { alert('File download failed!'); });

            return false; //this is critical to stop the click event which will trigger a normal file download
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <a class="fileDownloadPromise" href="/FileDownload/Report.pdf">Report.pdf</a>
    </div>
    </form>
</body>
</html>
