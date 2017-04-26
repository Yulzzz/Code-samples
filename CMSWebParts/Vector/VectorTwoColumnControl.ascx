<%@ Control Language="C#" AutoEventWireup="true" Inherits="CMSApp.CMSWebParts.Vector.VectorTwoColumnControl"  CodeBehind="~/CMSWebParts/Vector/VectorTwoColumnControl.ascx.cs" %>

<!-- start of Two Column -->
<asp:Panel ID="pnlTwoColumnControlPreviewMode" runat="server">
    <div class="container vctr-two-column-content">
        <div class="row">
              <div class="two-column-wrapper col-md-12 col-lg-12">

                <%
                    if (Item.DisplayTitleFirst){
                %>
                    <div class="two-column-left has-title">
                       <h2 <%--class="hidden-xs"--%>><%=Item.Title %></h2>
                        <div class="vctr-left-column-image-wrapper">
                            <img src="<%=Item.ImageUrl %>" alt="<%=Regex.Replace(Item.Title, "<.*?>", string.Empty) %>" />
                        </div>
<%--                        <h2 class="visible-xs-block"><%=Item.Title %></h2>--%>
                     </div>

                <%
                    }else { 
                %>
                     <div class="two-column-left">
                           <div class="vctr-left-column-image-wrapper">
                            <img src="<%=Item.ImageUrl %>" alt="<%=Regex.Replace(Item.Title, "<.*?>", string.Empty) %>" />
                        </div>
                      </div>
                <%
                    }
                %>
      
    
                <div class="two-column-right">
                    <%
                        if (!Item.DisplayTitleFirst)
                        {
                    %>
                    <h2><%=Item.Title %></h2>
                    <%
                        }
                    %>

                    <h5><%=Item.Subtitle %></h5>

                    <%
                        if (!string.IsNullOrEmpty(Item.ButtonText))
                        {
                    %>
                    <div><a class="vctr-wide-button  btn vctr-button-primary" aria-label="<%= Item.ButtonText %>" href="<%= Item.ButtonUrl %>"><%= Item.ButtonText %></a></div>
                    <%
                        }
                    %>
                </div>
            </div>
        </div>

    </div>
</asp:Panel>
<!-- end of Two Column -->