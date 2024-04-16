jQuery(document).ready(function($) {

  $("#nav-menu-container").on("click","a", function (event) {
    event.preventDefault();
    var id  = $(this).attr('href'),
      top = $(id).offset().top;
      $('body,html').animate({scrollTop: top}, 1500);
  });

  $(".up-btn").on("click", function (event) {
    event.preventDefault();
    $('body,html').animate({scrollTop: 0}, 1500);
  });
  
  $(".up-btn-fixed").on("click", function (event) {
    event.preventDefault();
    $('body,html').animate({scrollTop: 0}, 1500);
  });

  // Mobile Navigation
  if ($('#nav-menu-container').length) {
    var $mobile_nav = $('#nav-menu-container').clone().prop({
      id: 'mobile-nav'
    });
    $mobile_nav.find('> ul').attr({
      'class': '',
      'id': ''
    });
    $('body').append($mobile_nav);
    $('body').prepend('<button type="button" id="mobile-nav-toggle"><i class="fa fa-bars"></i></button>');
    $('body').append('<div id="mobile-body-overly"></div>');
    $('#mobile-nav').find('.menu-has-children').prepend('<i class="fa fa-chevron-down"></i>');

    $(document).on('click', '#mobile-nav-toggle', function(e) {
      $('body').toggleClass('mobile-nav-active');
      $('#mobile-nav-toggle i').toggleClass('fa-times fa-bars fixed');
      $('#mobile-body-overly').toggle();
    });

    $("#mobile-nav").click(function(e) {
      var container = $("#mobile-nav, #mobile-nav-toggle");
      if ($('body').hasClass('mobile-nav-active')) {
        $('body').removeClass('mobile-nav-active');
        $('#mobile-nav-toggle i').toggleClass('fa-times fa-bars fixed');
        $('#mobile-body-overly').fadeOut();
      }
    });
  } else if ($("#mobile-nav, #mobile-nav-toggle").length) {
    $("#mobile-nav, #mobile-nav-toggle").hide();
  }

});
