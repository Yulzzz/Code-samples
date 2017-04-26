<%@ Control Language="C#" AutoEventWireup="true" Inherits="CMSWebParts_Vector_VectorMeetingsControl"  CodeBehind="~/CMSWebParts/Vector/VectorMeetingsControl.ascx.cs" %>

<!-- start of Meetings Control -->

<asp:Panel ID="pnlMeetingPreviewMode" runat="server">
    <div class="meeting row">
        <div class="meeting-header row">
            <div class="col-xs-12 col-md-10 col-md-offset-1">
                <div class="meeting-header-image"><img src="<%=HeaderImageUrl %>"/></div>
                <h2 class="meeting-header-title"><%=HeaderTitle %></h2>
                <div class="meeting-header-button"><a class="vctr-btn btn vctr-button-primary" href="<%=HeaderButtonLink %>"><%=HeaderButtonText %></a></div>
            </div>
        </div>
        <div class="meeting-annual-meeting col-xs-12 col-md-6">
            <div class="meeting-annual-meeting-date"><%=AnnualMeetingDate %></div>
            <h2 class="meeting-annual-meeting-title"><%=AnnualMeetingTitle %></h2>
            <h5 class="meeting-annual-meeting-description"><%=AnnualMeetingDescription %></h5>
            <div class="meeting-annual-meeting-links"><%=AnnualMeetingLinks %></div>
        </div>
        <div class="meeting-special-meeting col-xs-12 col-md-6">
            <div class="meeting-special-meeting-date"><%=SpecialMeetingDate %></div>
            <h2 class="meeting-special-meeting-title"><%=SpecialMeetingTitle %></h2>
            <h5 class="meeting-special-meeting-description"><%=SpecialMeetingDescription %></h5>
            <div class="meeting-special-meeting-links"><%=SpecialMeetingLinks %></div>
        </div>
    </div>

</asp:Panel>
<!-- end of Meetings Control-->