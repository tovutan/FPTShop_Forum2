
    function OpenLoginWindowCampaign(n, url) {
        var r = url;
        t = screen.availWidth * .8,
        i = screen.availHeight * .6,
        u = (screen.availWidth - t) / 2,
        f = (screen.availHeight - i) / 2;
        window.socialWindow = window.open(r, "SignIn", "width=" + t + ",height=" + i + ",toolbar=no,resizable=fixed,status=no,scrollbars=no,menubar=no,screenX=" + u + ",screenY=" + f);

        socialWindow.focus();
        $.ajax({
            complete: function () {
                window.socialWindow.close;
            }
        });

        //if (window.focus())
        //{
        //    socialWindow.focus();
        //}
        //return false;
        //myWindow.blur();
       
        setTimeout(function () {
            var n = getCookie("tgdd_email");
            n != null && n != "" && usReload()
        }, 5e3);
        return
    }

    function getCookie(n) {
        for (var r, u, i = document.cookie.split(";"), t = 0; t < i.length; t++)
            if (r = i[t].substr(0, i[t].indexOf("=")), u = i[t].substr(i[t].indexOf("=") + 1), r = r.replace(/^\s+|\s+$/g, ""), r == n) return unescape(u)
    }

    function usReload() {
        location.reload()
    }
