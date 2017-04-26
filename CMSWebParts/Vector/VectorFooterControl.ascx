<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VectorFooterControl.ascx.cs" Inherits="CMSApp.CMSWebParts.Vector.VectorFooterControl" %>
<%@ Register Src="/CMSWebParts/Vector/ContentWebParts/FooterShareControl.ascx" TagPrefix="share" TagName="FooterShareControl" %>


<!-- start of Footer -->

            <div class="vctr-footer">
                <div class="container">
                    <div class="row vctr-footer-columns">
                        <div class="col-xs-12 col-md-8 vctr-footer-main">
                            <div class="vctr-strapline-wrapper col-xs-6 col-sm-2 col-md-3">
                                <p class="vctr-footer-strapline">Creating a new energy future</p>
                            </div>
                            <div class="vctr-social-wrapper col-xs-12 col-sm-2 col-md-2">
                                <div class="vctr-footer-social">
                                    <p class="vctr-show-mobile">FOLLOW US</p>
                                    <cms:CMSRepeater runat="server" ID="SocialRepeater" >
                                        <ItemTemplate>
                                            <a class="vctr-social-link <%# Eval("Text") %>" href="<%# Eval("NavigateUrl") %>" target="_blank"></a>
                                        </ItemTemplate>
                                    </cms:CMSRepeater>
                                </div>
                            </div>
                            <div class="vctr-footer-links col-xs-6 col-sm-2 col-md-2">
                                <div class="vctr-footer-legal globalFooterLinks">
                                    <div>
                                        <p><asp:Literal runat="server" ID="LeftFooterTitle" /></p>
                                        <ul>
                                            <cms:CMSRepeater runat="server" ID="LeftFooterRepeater" >
                                                <ItemTemplate>
                                                    <li><a href="<%# Eval("NavigateUrl") %>"><%# Eval("Text") %></a></li>
                                                </ItemTemplate>
                                            </cms:CMSRepeater>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                            <div class="vctr-footer-links col-xs-6 col-sm-2 col-md-2">
                                <div class="vctr-footer-sites globalFooterLinks">
                                    <div>
                                        <p><asp:Literal runat="server" ID="CentreFooterTitle" /></p>
                                        <ul>
                                            <cms:CMSRepeater runat="server" ID="CentreFooterRepeater" >
                                                <ItemTemplate>
                                                    <li><a href="<%# Eval("NavigateUrl") %>"><%# Eval("Text") %></a></li>
                                                </ItemTemplate>
                                            </cms:CMSRepeater>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                            <div class="vctr-footer-links col-xs-6 col-sm-2 col-md-2">
                                <div class="vctr-footer-quick-links globalFooterLinks">
                                    <div>
                                        <p><asp:Literal runat="server" ID="RightFooterTitle" /></p>
                                        <ul>
                                            <cms:CMSRepeater runat="server" ID="RightFooterRepeater" >
                                                <ItemTemplate>
                                                    <li><a href="<%# Eval("NavigateUrl") %>"><%# Eval("Text") %></a></li>
                                                </ItemTemplate>
                                            </cms:CMSRepeater>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                        
                        <div class="vctr-footer-shares col-xs-12 col-md-4">
                            <share:FooterShareControl runat="server" id="FooterShareControl" />
                        </div>
                        
                        <div class="vctr-copyright-wrapper col-xs-12 col-sm-12">
                            <p class="vctr-footer-copyright pull-right">&#169; 2016 Vector Ltd</p>
                        </div>
                    </div>
                </div>
            </div>
<!-- end of Footer -->