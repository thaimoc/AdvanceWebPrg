$(function() {
    // lay checkbox co id=chkAll
    var $chkBox = $("input:checkbox[id$=chkAll]");

    // lay mang cac checkbox co name = cid
    var $tblChkBox = $("table.list input:checkbox[name$=cid]");

    // them su kien click cho chkAll
    $chkBox.click(function() {
        $tblChkBox
            .attr('checked', $chkBox
            .is(':checked'));
    });

    // them su kien cho cac check box co name = cid
    // khi bo check thi chkAll cung tro ve trang thai uncheck
    $tblChkBox.click(
       function(e) {
           if (!$(this)[0].checked) {
               $chkBox.attr("checked", false);
           }
       });

    // hien thong bao nhac nho nguoi dung co that su muon xoa cac muc da chon hay khong
       $("input.multidelete, a.multidelete").click(function () {
        var n = $("table.list input:checkbox[name$=cid]:checked").length;
        if (n == 0) {
            alert('Please choose at least one item to delete!');
            return false;
        }
        else {
            return confirm('WARNING: The seleted items will be removed permanently. Are you sure?');
        }
    });
});

