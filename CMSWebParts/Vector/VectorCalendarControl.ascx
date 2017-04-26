<%@ Control Language="C#" AutoEventWireup="true" Inherits="CMSWebParts_Vector_VectorCalendarControl"  CodeBehind="~/CMSWebParts/Vector/VectorCalendarControl.ascx.cs" %>

<!-- start of Calendar Control -->

<asp:Panel ID="pnlCalendarPreviewMode" runat="server">
    <div class="vctr-calendar">
        <div class="vctr-calendar-header">
            <div class="vctr-calendar-header-image"><img src="<%=HeaderImageUrl %>"/></div>
            <div class="vctr-calendar-header-title"><h2><%=HeaderTitle %></h2></div>
        </div>
        <div class="vctr-calendar-body">
            <div class="calendar-body-content row"><%=Body %></div>
        </div>
    </div>

</asp:Panel>
<!-- end of Calendar Control-->