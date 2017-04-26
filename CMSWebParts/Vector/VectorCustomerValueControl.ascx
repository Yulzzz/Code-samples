<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VectorCustomerValueControl.ascx.cs" Inherits="CMSApp.CMSWebParts.Vector.VectorCustomerValueControl" %>

<!-- start of Customer Value -->
<asp:Panel ID="pnlCustomerValueControlPreviewMode" runat="server">
    <div class="container">
        <div class="row">
            <div class="customer-value col-md-12 col-lg-12">
                <%
                    if (UsesRepeater)
                    {
                %>

                <h2><%= TopTitle %></h2>
                <%
                    if (Items.Any())
                    {
                %>

                <%
                    var mod = 0;
                    for (var i = 0; i < Items.Count; i++)
                    {
                        if (i % 3 == 0)
                        {
                            mod = i + 3;
                %>
                <div class="customer-value-group clearfix">
                    <%
                        }
                    %>
                    <div class="customer-value-item">
                        <div>
                            <%
                                if (Items[i].ButtonUrl.IsNotNullOrEmpty())
                                {
                                    %>
                            
                                    <a href="<%= Items[i].ButtonUrl %>">
                                        <img src="<%= Items[i].ImageUrl %>" alt="<%= Regex.Replace(Items[i].Title, "<.*?>", string.Empty) %>" />
                                    </a>
                                    <%
                                }
                                else
                                {
                                    %>
                                        <img src="<%= Items[i].ImageUrl %>" alt="<%= Regex.Replace(Items[i].Title, "<.*?>", string.Empty) %>" />
                                    <%

                                }

                                 %>
                            
                        </div>
                        <h6><%= Items[i].Title %></h6>
                        <p><%= Items[i].Subtitle %></p>
                    </div>
                    <%
                        if (i == mod - 1)
                        {
                    %>
                    <div class="customer-value-clear"></div>
                </div>
                <%
                    }
                    else if (i == Items.Count - 1)
                    {
                %>
                </div>
                <div class="customer-value-clear"></div>
            
            <%
                    }
                }
            %>

            <%

                }
            %>

            <%
                }
                else
                {
            %>

            <div class="customer-value-group clearfix col-md-12 col-lg-12">
                <div class="customer-value-item">
                    <div>
                        <img src="<%= RepeaterItem.ImageUrl %>" alt="<%= Regex.Replace(RepeaterItem.Title, "<.*?>", string.Empty) %>" /></div>
                    <h6><%= RepeaterItem.Title %></h6>
                    <p>
                        <%= RepeaterItem.Subtitle %>
                    </h5>
                </div>
                <div class="customer-value-item">
                    <div>
                        <img src="<%= RepeaterItem.ImageUrl2 %>" alt="<%= Regex.Replace(RepeaterItem.Title2, "<.*?>", string.Empty) %>" /></div>
                    <h6><%= RepeaterItem.Title2 %></h6>
                    <p><%= RepeaterItem.Subtitle2 %></p>
                </div>
                <div class="customer-value-item">
                    <div>
                        <img src="<%= RepeaterItem.ImageUrl3 %>" alt="<%= Regex.Replace(RepeaterItem.Title3, "<.*?>", string.Empty) %>" /></div>
                    <h6><%= RepeaterItem.Title3 %></h6>
                    <p><%= RepeaterItem.Subtitle3 %></p>
                </div>
                <div class="customer-value-clear"></div>
            </div>

            <%
                }
            %>
            </div>
        </div>
    </div>
</asp:Panel>

<asp:Panel ID="pnlCustomerValueControlDesignMode" runat="server">
    <p>You are in design mode.</p>
</asp:Panel>
<!-- end of Customer Value -->
