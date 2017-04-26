<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DefaultPageNotification.ascx.cs" Inherits="CMSApp.CMSWebParts.Vector.DefaultPageNotification" %>

<asp:Panel runat="server" ID="ContentPanel">
<% if (IsOnSecondaryLandingPage && !HasClosed)
    {
 %>
    <script src="/CMSScripts/Vector/js.cookie.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var expires = 3650;
            var mobileNav = ".jq-mobile-nav";
            var additionalClassNav = 'showingNotification';

            $(mobileNav).addClass(additionalClassNav);
            $('#btnCloseSeconHomepageNotification').click(function () {

                Cookies.set('<%= Vector.PublicWeb.Common.Shared.Constants.Webparts.HasClosedDefaultPageNotification %>', true, { expires: expires });
                $('#btnCloseSeconHomepageNotification').remove();
                $('#secondHomepageNotification').fadeOut(400, function () { $(mobileNav).removeClass(additionalClassNav); });
                return false;
            });

            $('#btnSetSecondHomepage').click(function () {
                
                Cookies.set('<%= Vector.PublicWeb.Common.Shared.Constants.Webparts.HasClosedDefaultPageNotification %>', true, { expires: expires });
                Cookies.set('<%= Vector.PublicWeb.Common.Shared.Constants.Webparts.RedirectToPage %>', true, { expires: expires });
                $('#btnCloseSeconHomepageNotification').remove();
                $('#secondHomepageNotification .vctr-notification-message').html("Great, your home page is now set to the business page.");
                $('#secondHomepageNotification').delay(1500).fadeOut(400, function () {
                    $(mobileNav).removeClass(additionalClassNav);
                });
                return false;
            });
        });
    </script>
    <div id="secondHomepageNotification" class="blue-theme">
        <div class="container">
            <div class="row">
                <div class="vctr-homepage-notification col-xs-12">
                      <span class="vctr-notification-message">Set <a id="btnSetSecondHomepage" href="#">Business</a> as your homepage for next time</span>
                      <a class="vctr-notification-close" href="#" id="btnCloseSeconHomepageNotification"></a>
                </div>
            </div>
        </div>

    </div>

 <%}%>
</asp:Panel>