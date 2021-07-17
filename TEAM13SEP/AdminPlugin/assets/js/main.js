$(document).ready(function () {
    $(window).scroll(function () {
        if ($(this).scrollTop() > 50) {
            $('.navbar').addClass('moving');
            $('#logo').attr('src', 'img/logo-dark.png');
        } else {
            $('.navbar').removeClass('moving');
            $('#logo').attr('src', 'img/logo-light.png');
        }

        if ($(this).scrollTop() > 250) {
            $('#back-to-top').fadeIn();
        } else {
            $('#back-to-top').fadeOut();
        }
    });

    $('#back-to-top').click(function () {
        return $('body, html').animate({ scrollTop: 0 }, 400), !1;
    });
});