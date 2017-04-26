<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VectorDecisionControl.ascx.cs" Inherits="CMSApp.CMSWebParts.Vector.VectorDecisionControl" %>

<!-- start of Decision -->
<asp:Panel ID="pnlDecisionControlPreviewMode" runat="server">
    <div class="container">
        <div class="row">
            <div class="vctr-one-column-main  col-md-12 col-lg-10 col-lg-offset-1">
                <%
                    if (!string.IsNullOrEmpty(Item.ImageUrl))
                    {
                %>
                <div>
                    <img src="<%= ClickThroughItem.ImageUrl %>" alt="<%=Regex.Replace(ClickThroughItem.Title, "<.*?>", string.Empty) %>" /></div>
                <%
                    }
                %>

                <h2><%=ClickThroughItem.Title %></h2>

                <h5><%=ClickThroughItem.Subtitle %></h5>

                <div class="btn-container">
                    <%
                        if (!string.IsNullOrEmpty(ClickThroughItem.ButtonText))
                        {
                    %>
                    <div class="vctr-decision-footer"><a class="vctr-btn btn vctr-button-primary" aria-label="<%= ClickThroughItem.ButtonText %>" href="<%= UrlHelper.EnsureHttpPrefix(ClickThroughItem.ButtonUrl) %>"><%= ClickThroughItem.ButtonText %></a></div>
                    <%
                        }
                    %>

                    <%
                        if (!string.IsNullOrEmpty(ClickThroughItem.ButtonText2) && !string.IsNullOrEmpty(ClickThroughItem.ButtonUrl2))
                        {
                    %>
                    <div class="vctr-decision-footer"><a class="vctr-btn btn vctr-button-primary" aria-label="<%= ClickThroughItem.ButtonText2 %>" href="<%= UrlHelper.EnsureHttpPrefix(ClickThroughItem.ButtonUrl2) %>"><%= ClickThroughItem.ButtonText2 %></a></div>
                    <%
                        }
                    %>

                    <%
                        if (!string.IsNullOrEmpty(ClickThroughItem.ButtonText3) && !string.IsNullOrEmpty(ClickThroughItem.ButtonUrl3))
                        {
                    %>
                    <div class="vctr-decision-footer"><a class="vctr-btn btn vctr-button-primary" aria-label="<%= ClickThroughItem.ButtonText3 %>" href="<%= UrlHelper.EnsureHttpPrefix(ClickThroughItem.ButtonUrl3) %>"><%= ClickThroughItem.ButtonText3 %></a></div>
                    <%
                        }
                    %>
                </div>
            </div>
        </div>
    </div>
</asp:Panel>
<!-- end of Decision -->
