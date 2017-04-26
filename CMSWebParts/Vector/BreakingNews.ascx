<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BreakingNews.ascx.cs" Inherits="CMSApp.CMSWebParts.Vector.BreakingNews" %>

<asp:Panel runat="server" ID="ContentPanel">
<% if (ShouldShowMessage)
    {
        var now = DateTime.UtcNow;
 %>
    <script src="/CMSScripts/Vector/js.cookie.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var mobileNav = ".jq-mobile-nav";
            var additionalClassNav = 'showingBreakingNews';

            $(mobileNav).addClass(additionalClassNav);
            $('#btnCloseBreakingNews').click(function () {

                Cookies.set('<%= Vector.PublicWeb.Common.Shared.Constants.Webparts.HasReadBreakingNews %>', '<%= now.Ticks %>', { expires: 1 });
                Cookies.set('<%= Vector.PublicWeb.Common.Shared.Constants.Webparts.NewsText %>', '<%= Message%>', { expires: 1 });
                Cookies.set('<%= Vector.PublicWeb.Common.Shared.Constants.Webparts.NextCheck %>', '<%= now.AddDays(1).Ticks%>', { expires: 1 });
                $('#btnCloseBreakingNews').remove();
                $('#breakingNews').fadeOut(400, function () { $(mobileNav).removeClass(additionalClassNav); });
                return false;
            });
        });
    </script>

    <div id="breakingNews" class="orange-theme">
        <div class="container">
            <div class="row">
                <div class="vctr-homepage-notification col-xs-12">
                      <span class="vctr-notification-message"><%= Message %></span>
                      <a class="vctr-notification-close" href="#" id="btnCloseBreakingNews"></a>
                </div>
            </div>
        </div>

    </div>

 <%}%>
</asp:Panel>
