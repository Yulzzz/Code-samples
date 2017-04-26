<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VectorOutageSummaryControl.ascx.cs" Inherits="CMSApp.CMSWebParts.Vector.VectorOutageSummaryControl" %>

<!-- start of Outage Summary -->
<asp:Panel ID="pnlOutageSummaryControlPreviewMode" runat="server">
    <div class="outage-summary">
        <div class="outage-container">
            <div class="outage-item">
                <h6>Time Reported</h6>
                <h5><%=DataOutageSummary.DateRecorded %></h5>
            </div>
            <div class="outage-item">
                <h6>Estimated Restoration</h6>
                <h5><%=DataOutageSummary.EstimatedRestorationDate %></h5>
            </div>
            <div class="outage-item">
                <h6>Elapsed Time</h6>
                <h5><%=DataOutageSummary.ElapsedTime %></h5>
            </div>
        </div>

    </div>
</asp:Panel>
<!-- end of Outage Summary -->