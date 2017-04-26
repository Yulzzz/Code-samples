<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ImageTextButtonControl.ascx.cs" Inherits="CMSApp.CMSWebParts.Vector.ImageTextButtonControl" %>

<!-- start of Image Text Button -->
<div class="imageTextButton">
    <% if (!string.IsNullOrEmpty(Item.ImageUrl)) {
    %>
    <img src="<%= Item.ImageUrl %>" />
    <% } %>


    <% if (!string.IsNullOrEmpty(Item.Title))
        { %>
            <p><%= Item.Title %></p>
        <%
        } %>

    <% if (!string.IsNullOrEmpty(Item.Subtitle))
        {  %>
            <p><%= Item.Subtitle %></p>
    <%
        } %>


    <% if (Item.HasButton())
        {  %>
            <a href="<%=UrlHelper.EnsureHttpPrefix(Item.ButtonUrl) %>"><%=Item.ButtonText %></a>
    <%
        } %>
</div>
<!-- end of Image Text Button -->