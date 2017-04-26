<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VectorOutagesMapControl.ascx.cs" Inherits="CMSApp.CMSWebParts.Vector.VectorOutagesMapControl" %>

<!-- start of Outages Map Control -->
<asp:Panel ID="pnlOutageMapControlPreviewMode" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12 col-lg-12 vctr-outages-header">
                <div class="vctr-map-back-wrapper"><a id="OutagesMapGoBackButton" class="vctr-outages-back-button " ClientIDMode="Static" runat="server"></a></div>
                <div class="vctr-map-title-wrapper">
                     <h1><asp:Label ID="OutageTitle" runat="server" /></h1>
                      <h2><asp:Label ID="OutageSubTitle" runat="server" /></h2>
                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid">
        <div class="row">
            <div class="vctr-outages-map-wrapper">
                <div id="outages-map" class="vctr-outages-map" style="width: 100%"></div>
                <div id="OutagesMapNoOutageOverlay"  clientidmode="Static" runat="server"><h2>Nothing to report</h2></div>
            </div>
         </div>
    </div>


    <script type="text/javascript">
        window.outages = window.outages || {
            information: <%= OutageInformationAsJson %>,
            isSummaryMode: <%= IsSummaryMode.ToString().ToLower() %>
        };
    </script>
    <script src="~/CMSScripts/Vector/doT.min.js"></script>
    <script id="lightbox-google-outages" type="text/template">
        <div class="lightbox-google">
            <h4 class="outage-number">{{=it.utility_affected}} outage #{{=it.incident_id}}</h4>
            <h4 class="time-header">Estimated Restoration</h4>
            <div class="time">{{=it.estimated_restoration_date}}</div>
            <h4 class="time-header">Elapsed Time</h4>
            <div class="time">{{=it.ElapsedTime}}</div>
            <% if (!IsSummaryMode)
               { %>
                <a class="vctr-wide-button vctr-button-primary btn" href="<%= MoreDetailsPath %>?incidentId={{=it.incident_id}}">More Details</a>
            <% } %>
        </div>
    </script>
    <script src="https://maps.googleapis.com/maps/api/js?key=<%= GoogleMapKey %>"></script>
    <script src="~/CMSScripts/Vector/infobox.min.js"></script>
    <script src="~/CMSScripts/Vector/outages-map.min.js"></script>

</asp:Panel>
<!-- end of Outages Map Control -->
