<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VectorImageOnlyContent.ascx.cs" Inherits="CMSApp.CMSWebParts.Vector.VectorImageOnlyContent" %>

<!-- start of Image Only Content -->
<asp:Panel ID="pnlImageOnlyContentPreviewMode" runat="server">
    <div class="container">
            <div class="vctr-img-only">
                <h2><%=Item.Title %></h2>

                <h5><%=Item.Subtitle %></h5>

                <div class="vctr-img-only-icons">
                    <%=Item.Body %>
                </div>
            </div>
    </div>
</asp:Panel>
<!-- end of Image Only Content -->