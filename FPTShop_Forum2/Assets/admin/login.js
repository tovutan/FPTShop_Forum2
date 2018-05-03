function onSignIn(googleUser) {
    var profile = googleUser.getBasicProfile();
    if (profile !== null && profile !== undefined) {
        var user = {
            ID: profile.getId(),
            Name: profile.getName(),
            Email: profile.getEmail(),
            UserName: response.UserName,
            Image: profile.getImageUrl()
        };
        $.ajax({
            type: "POST",
            url: "/Home/UpdateUserInfo",
            //data: JSON.stringify(user),
            data: { customer:user },
           // contentType: "application/json; charset=utf-8",
           // dataType: "json",
            success: function (response) {
                if (response === true) {
                    alert("updated user success google");
                } else {
                    alert("update failed");
                }
            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
    }
    console.log('ID: ' + profile.getId()); // Do not send to your backend! Use an ID token instead.
    console.log('Name: ' + profile.getName());
    console.log('Image URL: ' + profile.getImageUrl());
    console.log('Email: ' + profile.getEmail()); // This is null if the 'email' scope is not present.
}

function signOut() {
    var auth2 = gapi.auth2.getAuthInstance();
    auth2.signOut().then(function () {
        console.log('User signed out.');
    });
}

function renderButton() {
    gapi.signin2.render('my-signin2', {
        'scope': 'profile email',
        'width': 240,
        'height': 50,
        'longtitle': true,
        'theme': 'dark',
        //'onsuccess': onSuccess,
        'onfailure': onFailure
    });
}

function onLoadGoogleCallback() {
    gapi.load('auth2', function () {
        auth2 = gapi.auth2.init({
            client_id: '896622894562-eams8dj01aesjt83rq08v7n7qlr42esv.apps.googleusercontent.com',
            cookiepolicy: 'single_host_origin',
            scope: 'profile'
        });

        auth2.attachClickHandler(element, {},
            function (googleUser) {
                console.log('Signed in: ' + googleUser.getBasicProfile().getName());
            }, function (error) {
                console.log('Sign-in error', error);
            }
        );
    });

    element = document.getElementById('googleSignIn');
}

// This is called with the results from from FB.getLoginStatus().
function statusChangeCallback(response) {
    console.log('statusChangeCallback');
    console.log(response);
    // The response object is returned with a status field that lets the
    // app know the current login status of the person.
    // Full docs on the response object can be found in the documentation
    // for FB.getLoginStatus().
    if (response.status === 'connected') {
        // Logged into your app and Facebook.
        testAPI();
    } else {
        // The person is not logged into your app or we are unable to tell.
        document.getElementById('status').innerHTML = 'Please log ' +
            'into this app.';
    }
}

// This function is called when someone finishes with the Login
// Button.  See the onlogin handler attached to it in the sample
// code below.
function checkLoginState() {
    FB.getLoginStatus(function (response) {
        statusChangeCallback(response);
    });
}

window.fbAsyncInit = function () {
    FB.init({
        appId: '1782734941785850',
        xfbml: true,
        channelURL: '',
        oauth: false,
        version: 'v2.12'
    });
    FB.AppEvents.logPageView();

    //FB.getLoginStatus(function(response) {
    //    statusChangeCallback(response);
    //});
};

(function (d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) {
        return;
    }
    js = d.createElement(s);
    js.id = id;
    js.src = "https://connect.facebook.net/en_US/sdk.js";
    fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));

function testAPI() {
    var test = 1;
    console.log('Welcome!  Fetching your information.... ');
    FB.api('/me?fields=id,name,email,gender,age_range,link,picture',
        function (response) {
            if (response !== null && response !== undefined) {
                var user = {
                    ID: response.id,
                    Name: response.name,
                    Email: response.email,
                    UserName:response.UserName,
                    Image: response.picture.data.url
            };
                $.ajax({
                    type: "POST",
                    url: "/Home/UpdateUserInfo",
                    //data: JSON.stringify(user),
                    data: { customer:user },
                    //contentType: "application/json; charset=utf-8",
                    //dataType: "json",
                    success: function (response)
                    {
                        if (response === true)
                        {
                            alert("updated user success");
                        } else
                        {
                            alert("update failed");
                        }
                    },
                    failure: function (response) {
                        alert(response.responseText);
                    },
                    error: function (response) {
                        alert(response.responseText);
                    }
                });
            }
            console.log('Successful login for: ' + response.name);
            console.log(response.id);
            console.log(response.email);
            console.log(response.picture);
            document.getElementById('status').innerHTML =
                'Thanks for logging in, ' + response.name + '!' + '<br/><img src="' + response.picture.data.url + '" alt="Smiley face" height="42" width="42">';
        });
}