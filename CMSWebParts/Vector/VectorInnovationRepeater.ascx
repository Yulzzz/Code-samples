<%@ Control Language="C#" AutoEventWireup="true" Inherits="CMSWebParts_Vector_VectorInnovationRepeater"  Codebehind="~/CMSWebParts/Vector/VectorInnovationRepeater.ascx.cs" %>

<!-- start of Innovation Repeater -->
<asp:Panel ID="pnlInnovationRepeaterPreviewMode" runat="server">

<div class="container">
    <div class="row">
        <div class="col-md-12 col-lg-12 vctr-innovation vctr-content-repeater">
            <h2><%=RepeaterTitle %><a class="vctr-rss" href="<%=RSSUrl %>"><i class="fa fa-rss"></i> RSS</a></h2>

            <cms:CMSEditModeButtonAdd ID="btnAdd" runat="server" Visible="False" />
            <div class="vctr-repeater">
                 <cms:CMSRepeater ID="repItems" runat="server" />
            </div>
            <%--<div class="vctr-centered-button-row">
                <a class="vctr-wide-button vctr-button-primary btn" href="#">Load More</a>
            </div>--%>
        </div>
    </div>
</div>

</asp:Panel>
<!-- end of Innovation Repeater -->