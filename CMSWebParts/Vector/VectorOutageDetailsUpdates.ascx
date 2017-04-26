<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VectorOutageDetailsUpdates.ascx.cs" Inherits="CMSApp.CMSWebParts.Vector.VectorOutageDetailsUpdates" %>

<!-- start of Outage Details Updates -->
<asp:Panel ID="pnlOutageDetailsUpdatesControlPreviewMode" runat="server">
    <%
        if (DisplayDetails)
        {
    %>
    <div class="outage-details">
        <div class="vctr-outage-tab-item">
            <h6>Utility affected</h6>
            <h5><%=DataOutageAllActivities.UtilityAffected %></h5>
        </div>
        <div class="vctr-outage-tab-item">
            <h6>Fault Type</h6>
            <h5><%=DataOutageAllActivities.FaultType %></h5>
        </div>
        <div class="vctr-outage-tab-item">
                    <h6>Affecting</h6>
                    <h5><%= DataOutageAllActivities.CustomersAffected %> Households</h5>
        </div>
    </div>
    <%
        }
        else
        {
    %>
    <div class="outage-updates">
        <%
            foreach (var timeline in DataOutageAllActivities.Timeline)
            {
        %>
                <div class="vctr-outage-tab-item">
                    <h6><%=timeline.DateRecordedFormatted %></h6>
                    <h5><%=timeline.Comment %></h5>
                </div>
        <%
            }
        %>
    </div>
    <%
        }
    %>
</asp:Panel>
<!-- end of Outage Details Updates -->