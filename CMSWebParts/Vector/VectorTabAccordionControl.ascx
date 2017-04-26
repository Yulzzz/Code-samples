<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VectorTabAccordionControl.ascx.cs" Inherits="CMSApp.CMSWebParts.Vector.VectorTabAccordionControl" %>
<script src="~/CMSScripts/Vector/jquery-ui.js"></script>
<link href="~/App_Themes/Vector/Stylesheets/jquery-ui.css" rel="stylesheet" />
<asp:Panel runat="server" ID="Content" >
    <script type="text/javascript">
        $(document).ready(function () {
            <% 
                if (IsMobileView)
                {
                    %>
                    $(".<%= UniqueHtmlId %>accordionHeader").each(function (index, value) {
                        var header = $(value).html();
                        $('<h3>' + header + '</h3>').insertAfter($(value));
                        $(value).remove();
                    });
                    $(".jq-tab-accordion").accordion({
                        collapsible: true,
                        animate: 100
                    });
            <%
                }
            %>
        });
    </script>
</asp:Panel>