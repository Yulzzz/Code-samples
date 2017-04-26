<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TextButtonCarousel.ascx.cs" Inherits="CMSApp.CMSWebParts.Vector.TextButtonCarousel" %>

<asp:Panel ID="ContentPanel" runat="server">
<!-- start of Text Button Carousel -->
<script type="text/javascript" src="~/CMSScripts/Slick/slick.min.js"></script>
<script type="text/javascript">

    $(document).ready(function () {
        $('#<%= ControlName%>').slick({
            dots: true,
            infinite: true,
            speed: 600,
            autoplay: true,
            autoplaySpeed:5000,
            appendArrows: '.vctr-button-row',
            appendDots: '.vctr-banner-container'
        });
    });

</script>

<%
    if (Items.Any())
    {
        %>
        <div class="vctr-banner-container">
            <div class="slider banner vctr-banner-carousel" id="<%= ControlName%>">
  
            <%
                foreach(var item in Items)
                {
                %>
                 <div class="vctr-banner-outer">
                    <div class="vctr-banner-image-wrapper">
                        <div class="vctr-banner-image"  style='background-image:url("<%= item.ImageUrl %>")'></div>
                        <div class="vctr-banner-overlay"></div>
                    </div>
                    <div class="container vctr-banner-inner">
                        <div class="row">
                            <div class="vctr-banner">
                                <div class="vctr-banner-message" >

                                        <p class="vctr-banner-heading"><%= item.Title %></p>
                                        <p class="vctr-banner-subheading"><%= item.Subtitle %></p>
                                            <%
                                                if(!string.IsNullOrEmpty(item.ButtonUrl) && !string.IsNullOrEmpty(item.ButtonText))
                                                {
                                                %>
                                                    <a class="vctr-wide-button vctr-banner-button vctr-button-primary btn" href="<%= UrlHelper.EnsureHttpPrefix(item.ButtonUrl) %>"><%= item.ButtonText %></a>
                                                <%
                                                }
                                            %>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <%
                }
              %>
        </div>
     <div class="container hidden-xs vctr-carousel-buttons">
    <div class="row ">
        <div class="col-sm-12 col-lg-12 vctr-button-row"></div>
    </div>
</div>
<!-- end of Text Button Carousel -->
<div class="vctr-curve"></div>

<%
                }
              %>


</asp:Panel>

<asp:Panel ID="DesignPanel" runat="server">
    <p>There is a text carousel control here, it is not displayed in Design Mode. Please switch to view mode to see it</p>
</asp:Panel>