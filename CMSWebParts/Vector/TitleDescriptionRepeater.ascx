<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TitleDescriptionRepeater.ascx.cs" Inherits="CMSApp.CMSWebParts.Vector.TitleDescriptionRepeater" %>
<script src="~/CMSScripts/Vector/jquery-ui.js"></script>
<link href="~/App_Themes/Vector/Stylesheets/jquery-ui.css" rel="stylesheet" />
 <script type="text/javascript">
     $(document).ready(function () {
             var icons = {
                 header: "ui-icon-circle-arrow-e", //class name for the collapsed icon 
                 activeHeader: "ui-icon-circle-arrow-s" //class name for the opened icon
             };
            $(".jq-faq-accordion").accordion({
                collapsible: true,
                animate: 100, 
                icons: icons,
                active: 'none',
                heightStyle: "content"
            });
        });
    </script>
<div class="vctr-faq-accordion">
    <div class="vctr-faq-title-icon">
        <asp:Image runat ="server" ID="IconImage"  />
    </div>
    
    <h2 class="vctr-faq-title"><asp:Literal runat="server" ID="Title" ></asp:Literal></h2>

    <div class="jq-faq-accordion">
        <cms:CMSRepeater runat="server" ID="ContentRepeater">
            <ItemTemplate>
                <h5><%# Eval("Key") %></h5>
                <div><%# Eval("Value") %></div>
            </ItemTemplate>
        </cms:CMSRepeater>
    </div>
</div>
