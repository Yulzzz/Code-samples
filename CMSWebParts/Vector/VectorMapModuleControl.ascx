<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VectorMapModuleControl.ascx.cs" Inherits="CMSApp.CMSWebParts.Vector.VectorMapModuleControl" %>
<%@ Import Namespace="NSubstitute.Core" %>

<asp:Panel runat="server" ID="ContentPanel">
<div class="container-fluid vctr-map-module">
        <div class="container">
            <div class="row">
                 <div class="vctr-map-info col-sm-12 col-md-12">
                    <div class="vctr-map-info-heading col-sm-8 col-md-8">
                        <h2><asp:Literal ID="TitleText" runat="server" /></h2>

                            <div>
                                <asp:Literal ID="SubtitleText" runat="server" />
                                <asp:HyperLink ID="Button" runat="server" CssClass="btn vctr-button-primary" />
                            </div>
                    </div>

                    <div class="vctr-map-info-key col-sm-offset-1 col-sm-3 col-md-3">
                        <h4>Colour Key</h4>
                        <div>
                            <img src="~/App_Themes/Vector/Images/vctr-oval-blue.png" alt="standard charge icon"><span>Standard Charge</span>
                        </div>
                        <div>
                            <img src="~/App_Themes/Vector/Images/vctr-oval-green.png" alt="rapid charge icon"><span>Rapid Charge</span>
                        </div>
                        <div>
                            <img src="~/App_Themes/Vector/Images/vctr-oval-grey.png" alt="coming soon icon"><span>Coming Soon</span>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    <div class="row"> 
        <div class="vctr-map-wrap">
            <%
                if (NotificationText.Visible)
                {
                    %>
                    <div class="vctr-map-notify"> <asp:Label ID="NotificationText" CssClass="mapNotification" runat="server" /> </div>

            <%
                }
                 %>
            <div id="evcharge-map" class="vctr-map-container"></div>
        </div>
    </div>   
</div>

<script src="~/CMSScripts/Vector/doT.min.js"></script>
<script id="lightbox-google-template" type="text/template">
    <div class="vctr-map-popup-container">
        <div class="vctr-map-popup">
            {{? it.isClosest }}
            <p>Your nearest charging station is</p>
            {{?}}

            <h1>{{=it.address}}</h1>
            <h2>Ports</h2>
            <div>
                <ul class=""vctr-map-popup-list">
                    {{~it.ports :port:index}}
                    <li><p>{{=port}}<p></li>
                    {{~}}
                </ul>
            </div>
        </div>

        <div class="vctr-map-popup">
            <h2>Opening Hours</h2>
            <p>{{=it.openingHours}}</p>
        </div>

        <div class="vctr-map-popup-action">
            <a class="vctr-button-primary btn" href="https://www.google.co.nz/maps/dir/Current+Location/{{=it.latlng.lat()}},{{=it.latlng.lng()}}/" target="_blank">Get Directions</a>
        </div>
    </div>
</script>
<script id="lightbox-google-coming-soon-template" type="text/template">
    <div class="lightbox-google">
        <div class="inner-lightbox-google-top">
            <h1>{{=it.address}}</h1>
            <div>
                This Charging Station is currently under construction. Watch this space!
            </div>
        </div>
    </div>
</script>

<script src="https://maps.googleapis.com/maps/api/js?key=<%= GoogleMapKey %>"></script>
<script src="~/CMSScripts/Vector/infobox.min.js"></script>
<script src="~/CMSScripts/Vector/ev-charging-map.min.js"></script>
</asp:Panel>