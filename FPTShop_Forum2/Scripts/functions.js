(function($){
    var avatas = {
        init: function () {
            avatas.events();
        },
        events: function () {
            $('.fhdcmtava').textAvatar({
                width: 70
            });
        }
    };

	$(document).ready(function (){
        /*comment*/
        if ($(".fhdcmtava").length > 0) {
            avatas.init();
        }

        $(document).on('click','.hd-mnleft>li>a',function(){
            $(".hd-mnleft>li").removeClass("active");
            $(this).parent().addClass("active");
        });

        $(document).on('click','.hd-hdchti>li>a',function(e){
            e.preventDefault();
            $(".hd-hdchti>li").removeClass("active");
            $(this).parent().addClass("active");
            var tab = $(this).attr("href");
            $(".hd-tabbox").not(tab).css("display", "none");
            $(tab).fadeIn();
        });

        $('#UpLoadHs1').change(function () {
            for (var i=0, len = this.files.length; i < len; i++) {
                (function (j, self) {
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        $('#UpLoadFlie1').append('<li><img src="'+e.target.result+'" alt=""> <p>' + self.files[j].name + '</p> <i></i></li>')
                    };
                    reader.readAsDataURL(self.files[j]);
                    $(".md-chfile label").hide();
                })(i, this);
            }
        });
        $(document).on('click','.gtu-b4ul>li i',function (e) {
            e.preventDefault();
            $(this).parent().remove();
            $(".md-chfile label").show();
        });

	});
})(window.jQuery);