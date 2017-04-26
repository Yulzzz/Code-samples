<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FooterShareControl.ascx.cs" Inherits="CMSApp.CMSWebParts.Vector.ContentWebParts.FooterShareControl" %>
<script src="~/CMSScripts/Vector/vctr.sharePrice.js"></script>

<p>Vector Shares</p>
<div class="vctr-shares-inner row">
    <div class="vctr-shares-info col-xs-12 col-sm-4 col-md-6">
        <div class="col-xs-4 col-sm-3 col-md-4 vctr-shares-icon">
            <span id="jq-live-shareMove"></span>
        </div>
        
        <div class="col-xs-8 col-sm-9 col-md-8 vctr-shares-price">
            <h5 id="jq-live-sharePrice"> </h5>
            <p>NZX live price</p>
        </div>

    </div>
    <div class="vctr-share-link col-xs-12 col-sm-8 col-md-6">
        Visit our <asp:HyperLink runat="server" ID="InvestorLink">investor section</asp:HyperLink> for more information.
    </div>
</div>


