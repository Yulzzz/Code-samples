<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VectorOneColumnControl.ascx.cs" Inherits="CMSApp.CMSWebParts.Vector.VectorOneColumnControl" %>

<!-- start of One Column -->
<asp:Panel ID="pnlOneColumnControlPreviewMode" runat="server">
    <div class="container">
        <div class="row">
            <div class="vctr-one-column-main col-md-12 col-lg-12">
                <%
                    if (!string.IsNullOrEmpty(Item.ImageUrl))
                    {
                %>
                <div class="vctr-icon">
                    <img src="<%= Item.ImageUrl %>" alt="<%=Regex.Replace(Item.Title, "<.*?>", string.Empty) %>" /></div>
                <%
                    }
                %>

                <h2><%=Item.Title %></h2>

                <h5><%=Item.Subtitle %></h5>

                <%
                    if (!string.IsNullOrEmpty(Item.ButtonText))
                    {
                %>
                <div><a class="vctr-btn btn vctr-button-primary" aria-label="<%= Item.ButtonText %>" href="<%= Item.ButtonUrl %>"><%= Item.ButtonText %></a></div>
                <%
                    }
                %>
            </div>
        </div>
    </div>
</asp:Panel>
<!-- end of One Column -->
