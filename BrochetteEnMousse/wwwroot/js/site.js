// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$('.open-link a').click(function () {
    if ($(".desc-wrap").css("height") === "60px") {
        $('.desc-wrap').css('height', 'auto');
        var autoHeight = $('.desc-wrap').height();
        $('.desc-wrap').css('height', '60px');
        $(".desc-wrap").animate({ height: autoHeight }, 1000);
    } else {
        $(".desc-wrap").animate({ height: "60px" }, 1000);
    }
    return false;
});
