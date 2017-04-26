<%@ Control Language="C#" AutoEventWireup="true" Inherits="CMSWebParts_Vector_VectorReportsControl"  CodeBehind="~/CMSWebParts/Vector/VectorReportsControl.ascx.cs" %>

<!-- start of Reports Control -->

<asp:Panel ID="pnlReportPreviewMode" runat="server">
    <div class="report row">
        <div class="report-header row">
            <div class="col-xs-12 col-md-10 col-md-offset-1">
                <div class="report-header-image">
                    <img src="<%=HeaderImageUrl %>"/>
                </div>
                <h2 class="report-header-title"><%=HeaderTitle %></h2>
                <h5 class="report-header-subtitle"><%=HeaderSubTitle %></h5>
                <div class="report-header-button">
                    <a class="vctr-btn btn vctr-button-primary" href="<%=HeaderButtonLink %>"><%=HeaderButtonText %></a>

                </div>
            </div>
        </div>
        <div class="report-annual-report col-xs-12">
            <div class="report-annual-report-date"><%=AnnualReportDate %></div>
            <h2 class="report-annual-report-title"><%=AnnualReportTitle %></h2>
            <h5 class="report-annual-report-description"><%=AnnualReportDescription %></h5>
            <div class="report-annual-report-links"><%=AnnualReportLinks %></div>
            <div class="report-annual-report-button"><a class="vctr-btn btn vctr-button-primary" href="<%=AnnualReportFullReportButtonLink %>"><%=AnnualReportFullReportButtonText %></a></div>
        </div>
        <div class="report-interim-report col-xs-12">
            <div class="report-interim-report-date"><%=InterimReportDate %></div>
            <h2 class="report-interim-report-title"><%=InterimReportTitle %></h2>
            <h5 class="report-interim-report-description"><%=InterimReportDescription %></h5>
            <div class="report-interim-report-links"><%=InterimReportLinks %></div>
            <div class="report-interim-report-button"><a class="vctr-btn btn vctr-button-primary" href="<%=InterimReportButtonLink %>"><%=InterimReportButtonText %></a></div>
        </div>
    </div>

</asp:Panel>
<!-- end of Reports Control-->