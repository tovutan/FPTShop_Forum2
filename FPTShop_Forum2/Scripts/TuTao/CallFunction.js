$(document).ready(function () {
    $(".hd-hdr-ch").off('click').on('click', function (e) {
        e.preventDefault();
        $("#dang-nhap").show();
    });

    $(".hd-hdr-ch").off('click').on('click', function (e) {
        e.preventDefault();
        $("#gui-cau-hoi").show();
    })
})