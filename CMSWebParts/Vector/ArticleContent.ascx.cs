using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using CMS.PortalControls;
using CMS.DocumentEngine;

namespace CMSApp.CMSWebParts.Vector
{
    public partial class ArticleContent : CMSAbstractWebPart
    {
        private TreeNode _currentDocument;

        public string ArticleText { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticleText = "";

            _currentDocument = DocumentContext.CurrentDocument;

            //article title
            var articleText = _currentDocument.GetValue("ArticleText");
            if (articleText != null)
            {
                ArticleText = string.Format("{0}", articleText);
            }

        }
    }
}