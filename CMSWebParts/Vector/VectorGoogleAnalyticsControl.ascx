<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VectorGoogleAnalyticsControl.ascx.cs" Inherits="CMSApp.CMSWebParts.Vector.VectorGoogleAnalyticsControl" %>

<!-- start of Google Analytics -->
<asp:Panel ID="pnlGoogleAnalyticsControlPreviewMode" runat="server">
    <%
        var latestBrowser = false;
        // Shitty IE browsers
        if (Request.Browser.Type.ToUpper().Contains("IE"))
        {
            if (Request.Browser.MajorVersion <= 9)
            {
    %>
                <script>
                    (function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){
                    (i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),
                    m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)
                    })(window,document,'script','https://www.google-analytics.com/analytics.js','ga');

                    ga('create', '<%=GoogleAnalyticsKey%>', 'auto');
                    ga('send', 'pageview');
                </script>
    <%
            }
            else
            {
                latestBrowser = true;
            }
        }

        // Latest browsers
        if (!Request.Browser.Type.ToUpper().Contains("IE") || latestBrowser)
        {
    %>
            <script>
                window.ga=window.ga||function(){(ga.q=ga.q||[]).push(arguments)};ga.l=+new Date;
                ga('create', '<%=GoogleAnalyticsKey%>', 'auto');
                ga('send', 'pageview');
            </script>
            <script async src='https://www.google-analytics.com/analytics.js'></script>
    <%
        }
    %>

</asp:Panel>
<!-- end of Google Analytics -->