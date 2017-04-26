<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VectorHotjarControl.ascx.cs" Inherits="CMSApp.CMSWebParts.Vector.VectorHotjarControl" %>

<!-- start of Hotjar -->
<asp:Panel ID="pnlHotjarControlPreviewMode" runat="server">
    <% if (HotjarKeyEnabled)
       {
    %>
    <script>
        (function(h,o,t,j,a,r){
            h.hj=h.hj||function(){(h.hj.q=h.hj.q||[]).push(arguments)};
            h._hjSettings={hjid:<%= HotjarKey %>,hjsv:5};
            a=o.getElementsByTagName('head')[0];
            r=o.createElement('script');r.async=1;
            r.src=t+h._hjSettings.hjid+j+h._hjSettings.hjsv;
            a.appendChild(r);
        })(window, document, '//static.hotjar.com/c/hotjar-', '.js?sv=');
    </script>
    <% } %>
</asp:Panel>
<!-- end of Hotjar -->