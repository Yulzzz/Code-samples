<%@ Control Language="C#" AutoEventWireup="true" Inherits="CMSWebParts_Vector_VectorNewsRepeater"  Codebehind="~/CMSWebParts/Vector/VectorNewsRepeater.ascx.cs" %>

<!-- start of News Repeater -->
<asp:Panel ID="pnlNewsRepeaterPreviewMode" runat="server">

<div class="container">
    <div class="row">
        <div class="col-md-12 col-lg-12 vctr-news vctr-content-repeater">
            <h2>News<a class="vctr-rss" href="<%=RSSUrl %>"><i class="fa fa-rss"></i> RSS</a></h2>

            <cms:CMSEditModeButtonAdd ID="btnAdd" runat="server" Visible="False" />
            <div class="vctr-repeater">
                <cms:CMSRepeater ID="repItems" runat="server" />
            </div>
        </div>
    </div>
</div>

</asp:Panel>
<!-- end of News Repeater -->