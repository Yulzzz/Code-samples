<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VectorPromoControl.ascx.cs" Inherits="CMSApp.CMSWebParts.Vector.VectorPromoControl" %>

<!-- start of Promo -->
<asp:Panel ID="pnlPromoControlPreviewMode" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="vctr-promo">
                <div class="vctr-promo-content hidden-xs">
                    <div class="vctr-inner-content">
                        <h2><%=Item.Title %></h2>
                        <p><%=Item.Subtitle %></p>
                        <div class="button-row"><a class="vctr-ghost-button vctr-button-primary btn" aria-label="<%= Item.ButtonText %>" href="<%= Item.ButtonUrl %>"><%= Item.ButtonText %></a></div>
                    </div>
                </div>
                <div class="vctr-promo-image" style='background-image:url("<%=Item.ImageUrl %>")'>
                </div>
                <div class="vctr-promo-content visible-xs-block">
                    <div class="vctr-inner-content">
                        <h2><%=Item.Title %></h2>
                        <p><%=Item.Subtitle %></p>
                        <div class="button-row"><a class="vctr-ghost-button vctr-button-primary btn" aria-label="<%= Item.ButtonText %>" href="<%= Item.ButtonUrl %>"><%= Item.ButtonText %></a></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Panel>
<!-- end of Promo -->
