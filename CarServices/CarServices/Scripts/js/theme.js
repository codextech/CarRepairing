!function(a){"use strict";a("#home-slider").owlCarousel({loop:!0,items:1,dots:!1,nav:!0,autoplayTimeout:2500,smartSpeed:2e3,autoHeight:!1,touchDrag:!0,mouseDrag:!0,margin:0,autoplay:!0,slideSpeed:600,navText:['<i class="fa fa-angle-left" aria-hidden="true"></i>','<i class="fa fa-angle-right" aria-hidden="true"></i>'],responsive:{0:{items:1,nav:!1,dots:!1},600:{items:1,nav:!1,dots:!1},768:{items:1,nav:!0},1100:{items:1,nav:!0}}}),a("#work-gallery-slider").owlCarousel({loop:!0,items:4,dots:!1,nav:!0,autoplayTimeout:2500,smartSpeed:2e3,autoHeight:!1,touchDrag:!0,mouseDrag:!0,margin:30,autoplay:!0,slideSpeed:300,navText:['<i class="fa fa-angle-left" aria-hidden="true"></i>','<i class="fa fa-angle-right" aria-hidden="true"></i>'],responsive:{0:{items:1,nav:!1,dots:!1},600:{items:2,nav:!1,dots:!1},768:{items:3,nav:!0},1100:{items:4,nav:!0}}}),a("#testimonials-slider").owlCarousel({loop:!0,items:1,dots:!0,nav:!1,autoplayTimeout:2500,smartSpeed:2e3,autoHeight:!1,touchDrag:!0,mouseDrag:!0,margin:0,autoplay:!0,slideSpeed:600,navText:['<i class="fa fa-angle-left" aria-hidden="true"></i>','<i class="fa fa-angle-right" aria-hidden="true"></i>'],responsive:{0:{items:1,nav:!1,dots:!1},600:{items:1,nav:!1,dots:!1},768:{items:1,nav:!1,dots:!0},1100:{items:1,nav:!1,dots:!0}}}),a("#client-slider").owlCarousel({loop:!0,items:6,dots:!1,nav:!1,autoplayTimeout:2500,smartSpeed:2e3,autoHeight:!1,touchDrag:!0,mouseDrag:!0,margin:0,autoplay:!0,slideSpeed:600,navText:['<i class="fa fa-angle-left" aria-hidden="true"></i>','<i class="fa fa-angle-right" aria-hidden="true"></i>'],responsive:{0:{items:1,nav:!1,dots:!1},600:{items:4,nav:!1,dots:!1},768:{items:4,nav:!1,dots:!1},1100:{items:6,nav:!1,dots:!1}}}),a(".btn-video-play").on("click",function(){a(".video-item .video-preview").append(video_url),a(this).hide()}),smoothScroll.init(),a("#subscribe-form").ajaxChimp({url:"http://blahblah.us1.list-manage.com/subscribe/post?u=5afsdhfuhdsiufdba6f8802&id=4djhfdsh9"}),a(".work-gallery-slider").magnificPopup({delegate:"a",type:"image",tLoading:"Loading image #%curr%...",mainClass:"mfp-img-mobile",gallery:{enabled:!0,navigateByImgClick:!0,preload:[0,1]},image:{tError:'<a href="%url%">The image #%curr%</a> could not be loaded.',titleSrc:function(a){return a.el.attr("title")+"<small>by Car Wash</small>"}}}),a("#cssmenu").menumaker({title:"Menu",format:"multitoggle"}),a(".date-pick").length&&a(".date-pick").datepicker({format:"dd/mm/yyyy"}),a(".counter").length&&a(".counter").counterUp({delay:20,time:2e3}),a(".comming-countdown").length&&a(".comming-countdown").each(function(){var e=a(this),t=a(this).data("countdown");e.countdown(t,function(e){a(this).html(e.strftime('<div class="counter-col-days"><span class="count-days">%D </span>:</div> <div class="counter-col"><span class="count-hours">%H</span> <span class="count-number">:</span> </div>  <div class="counter-col"><span class="count-minutes">%M</span> <span class="count-number">:</span> </div>  <div class="counter-col"><span class="count-seconds">%S</span></div>'))})}),a(".scroll-bar").length&&a(".scroll-bar").appear(function(){var e=a(this),t=e.data("percent");a(e).css("width",t)},{accY:-50}),a(".cart-plus-minus").append('<div class="dec qtybutton"><i class="fa fa-angle-down"></i></div><div class="inc qtybutton"><i class="fa fa-angle-up"></i></div>'),a(".qtybutton").on("click",function(){var e=a(this),t=e.parent().find("input").val();if(" "==e.text())var s=parseFloat(t)+1;else if(t>0)var s=parseFloat(t)-1;else s=0;e.parent().find("input").val(s)}),a("#slider-range").slider({range:!0,min:0,max:1e3,values:[50,250],slide:function(e,t){a("#amount").val("$"+t.values[0]+" - $"+t.values[1])}}),a("#amount").val("$"+a("#slider-range").slider("values",0)+" - $"+a("#slider-range").slider("values",1)),a("#zoom-01").elevateZoom({gallery:"gallery-01",zoomType:"lens",lensShape:"round",lensSize:200,galleryActiveClass:"active",imageCrossfade:!0}),a("#zoom-01").on("click",function(e){var t=a("#zoom-01").data("elevateZoom");return a.fancybox(t.getGalleryList()),!1}),a(document.body).on("click",".dropdown-menu li",function(e){var t=a(e.currentTarget);return t.closest(".dropdown").find('[data-bind="label"]').text(t.text()).end().children(".dropdown-toggle").dropdown("toggle"),!1}),a(window).on("load",function(){a(".status").fadeOut(),a(".preloader").delay(350).fadeOut("slow")})}(jQuery);