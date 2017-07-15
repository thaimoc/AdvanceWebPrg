$(document).ready(function () {
    $("#CatList1_MyMenu ul.level1 li").hover(function () {
        $(this).find('ul:first').css({ visibility: "visible", display: "none" }).show(500);
    }, function () {
        $(this).find('ul:first').css({ visibility: "hidden" });
    });
});