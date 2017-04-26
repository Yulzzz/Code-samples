<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsHeaderRepeater.ascx.cs" Inherits="CMSApp.CMSWebParts.Vector.ContentWebParts.NewsHeaderRepeater" %>

<asp:Panel runat="server" ID="ScriptPanel">
    <script type="text/javascript" src="~/CMSScripts/Slick/slick.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            $('.newsHeaderRepeater').slick({
                dots: true,
                infinite: true,
                speed: 600,
                autoplay: true,
                autoplaySpeed: 5000,
                appendArrows: '.vctr-button-row',
            });
        });
    </script>

</asp:Panel>

<div class="newsHeaderRepeater clearfix">
    <cms:CMSRepeater runat="server" ID="ContentRepeater">
        <ItemTemplate>
            <div class="<%# Eval("ClassName") %>" style="background-image:url(<%# Eval("ImageUrl") %>)">
                <img src="<%--<%# Eval("ImageUrl") %>--%>" />
                <div class="vctr-news-header-overlay">

                </div>
                <div class="vctr-news-details">
                    <div class="vctr-news-details-inner">
                        <h2><%# Eval("Title") %></h2>
                        <a href="<%# Eval("PageUrl") %>" class="vctr-ghost-button vctr-button-primary btn">Read More</a>
                    </div>

                </div>

            </div>
        </ItemTemplate>
    </cms:CMSRepeater>
</div>