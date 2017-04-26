<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VectorHeaderControl.ascx.cs" Inherits="CMSApp.CMSWebParts.Vector.VectorHeaderControl" %>
<%@ Register Src="~/CMSWebParts/Vector/TextButtonCarousel.ascx" TagPrefix="carl" TagName="TextButtonCarousel" %>


<script src="~/CMSScripts/Vendor/jQueryMobileTouch/jquery.mobile.custom.min.js" ></script>
<script>

$.fn.click = function(listener) {

    return this.each(function() {

       var $this = $( this );

       $this.on('vclick', listener);

    });

};

</script>
<script type="text/javascript">
        $(document).ready(function () {
            $('#SecondLeveMenu').find('ul').hide();

            $('#SecondLeveMenu .CMSListMenuLI, #SecondLeveMenu .CMSListMenuHighlightedLI').mouseenter(function () {
                $(this).find('ul').show();
            });
            $('#SecondLeveMenu .CMSListMenuLI, #SecondLeveMenu .CMSListMenuHighlightedLI').mouseleave(function () {
                $(this).find('ul').hide();
            });

            $('#MobileListMenu ul').parents('li').addClass('has-child-ul');
            $('#MobileListMenu ul').after('<i class="has-children"></i>');
            $('#MobileListMenu ul').hide();

            $('.vctr-hamburger-button').click( function (event) {
                event.preventDefault();

                $('.vctr-mobile-nav').show();
                $('.vctr-content-wrapper').addClass('overlay');
                $('.vctr-hamburger-button').hide();
                $('.vctr-mobile-contact').hide();
                $('.vctr-close-menu-button').show();
            });

            $('.vctr-close-menu-button').click( function (event) {
                event.preventDefault();

                $('.vctr-mobile-nav').hide();
                $('.vctr-content-wrapper').removeClass('overlay');
                $('.vctr-hamburger-button').show();
                $('.vctr-mobile-contact').show();
                $('.vctr-close-menu-button').hide();
            });


            $('#MobileListMenu i').click(function (event) {
                event.preventDefault();//because we need to override kentico default behaviour

                if ($(this).hasClass('toggle-open')) {
                    // $('#MobileListMenu i').removeClass('toggle-open');
                    $(this).removeClass('toggle-open');
                    $(this).siblings('ul').hide();

                } else {
                    $(this).addClass('toggle-open');
                   // $('#MobileListMenu ul').hide();
                    //$(this).parents('ul').show();
                    $(this).siblings('ul').show();
                }

            });

            $('#MobileListMenu li a').click(function (event) {
                $('#MobileListMenu .selected').removeClass('selected');
                 $(this).addClass('selected');
            });
        });
    </script>
<asp:Panel runat="server" ID="CarouselPanel"  >
    <div class="vctr-has-carousel">
        <nav class="navbar vctr-navbar-nav-top  hidden-sm hidden-xs" role="navigation">
        <div class="container">
            <div class="row">
                <div class="col-xs-12 col-sm-12 vctr-top-nav">
                    <cms:CMSListMenu runat="server" Path="/%" ID="FirstLevelMenu" ClassNames="Vector.ContentPage;Vector.BannerPage;Vector.BreadcrumbPage" MaxRelativeLevel="1" DisplayHighlightedItemAsLink="true" />
                    <a class="vctr-search jqSearch" href="<%=SearchPagePath %>"></a>
                </div>
            </div>
        </div>
     </nav>
    <nav class="navbar vctr-navbar-nav-middle jq-mobile-nav" role="navigation">
        <div class="vctr-navbar-middle">
            <div class="container">
                <div class="row">
                    <div class="col-xs-12 col-sm-12 ">
                        <div class="pull-left visible-sm-block visible-xs-block">
                            <button class="vctr-hamburger-button">
                                <div>
                                    <span></span>
                                    <span></span>
                                    <span></span>
                                </div>
                            </button>
                        </div>

                        <a href="/" class="pull-left vctr-logo-container-link">
                            <div class="vctr-logo-container"></div>
                        </a>
                        <a href="tel:0508832867">
                            <div class="vctr-nav-contact hidden-sm hidden-xs">
                                <p class="main-number">0508 VECTOR</p>
                                <p class="small-number">0508 832 867</p>
                            </div>
                        </a>
                        <div class="visible-sm-block visible-xs-block">
                            <div class="pull-right vctr-mobile-contact">
                                <a href="<%=SearchPagePath %>" class="vctr-search-button vctr-ghost-circle-button jqSearch">
                                    <img src="/App_Themes/Vector/images/vctr-header-search.svg" /></a>
                                <a href="tel:0508832867" class="vctr-contact-button vctr-ghost-circle-button">
                                    <img src="/App_Themes/Vector/images/vctr-header-call.svg" /></a>
                            </div>
                            <button class="pull-right vctr-close-menu-button">
                                <img src="/App_Themes/Vector/images/vctr-cancel.svg" />
                            </button>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12 col-sm-12 vctr-secondary-nav hidden-sm hidden-xs">
                        <cms:CMSListMenu runat="server" ID="SecondLeveMenu" ClassNames="Vector.ContentPage;Vector.BannerPage;Vector.ArticlePage;Vector.BreadcrumbPage" MaxRelativeLevel="2" DisplayHighlightedItemAsLink="true" />
                    </div>

                </div>
            </div>
          <div class="container-fluid">
                <div class="row">
                    <div class="col-xs-12 col-sm-12 vctr-mobile-nav">
                        <cms:CMSListMenu runat="server" ID="MobileListMenu" ClassNames="Vector.ContentPage;Vector.BannerPage;Vector.ArticlePage;Vector.BreadcrumbPage" MaxRelativeLevel="3" />
                    </div>
                </div>
            </div>
        </div>
    </nav>
    </div>
    

</asp:Panel>
<carl:textbuttoncarousel runat="server" id="backgroundCarousel" />

<!-- end of Header -->