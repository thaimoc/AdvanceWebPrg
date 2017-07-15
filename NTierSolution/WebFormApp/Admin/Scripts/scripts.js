$(function () {
    $('textarea.editor').tinymce({
        script_url: 'scripts/tinymce/tiny_mce_gzip.ashx',
        content_css: "styles/content.css",
        theme: "advanced",
        plugins: "pagebreak,style,layer,table,save,advhr,advimage,advlink,emotions,iespell,inlinepopups,insertdatetime,preview,media,searchreplace,print,contextmenu,paste,directionality,fullscreen,noneditable,visualchars,nonbreaking,xhtmlxtras,template",
        theme_advanced_buttons1: "bold,italic,underline,strikethrough,|,justifyleft,justifycenter,justifyright,justifyfull,formatselect,fontsizeselect",
        theme_advanced_buttons2: "pasteword,|,bullist,numlist,|,outdent,indent,|,undo,redo,|,link,unlink,anchor,image,cleanup,help,code",
        theme_advanced_buttons3: "hr,removeformat,visualaid,|,sub,sup,|,forecolor,backcolor,|,charmap,|,fullscreen",
        theme_advanced_toolbar_location: "top",
        theme_advanced_toolbar_align: "left",
        theme_advanced_statusbar_location: "bottom",
        theme_advanced_resizing: false,
        theme_advanced_font_sizes: "10px,12px,13px,14px,16px,18px,20px",
        font_size_style_values: "10px,12px,13px,14px,16px,18px,20px",
        forced_root_block: ''
    });  
});