<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="~/CMSWebParts/Vector/ArticleHeader.ascx.cs" Inherits="CMSApp.CMSWebParts.Vector.ArticleHeader" %>

<!-- start of Article Header -->
<asp:placeholder runat="server">
<style>
    #articleHeader
    {
        background-image: url('<%=CurrentDocument.GetStringValue("ArticleHeaderImage", null)%>');
        background-repeat: no-repeat;
        background-size:cover;
    }

</style>
<div class="vctr-article-header-wrapper">
    <div id="articleHeader" class="vctr-article-header"></div>
     <div class="vctr-article-header-overlay">
         <div class="container">
            <div class="row">
                <div id="articleHeaderContent" class="vctr-article-header-content col-md-12 col-lg-12">
                    <h4 id="articleDate" class="article-date"><%= string.Format("{0:dd MMMM yyyy}", CurrentDocument.GetValue("DocumentPublishFrom"))%></h4>
                    <h2 id="articleTitle" class="article-title"><%=CurrentDocument.GetStringValue("ArticleName", null)%></h2>
                </div>
            </div>
        </div>

     </div>
        
</div>
</asp:placeholder>
<!-- end of Article Header -->