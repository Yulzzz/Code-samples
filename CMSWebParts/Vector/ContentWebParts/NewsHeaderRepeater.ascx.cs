using CMS.DocumentEngine;
using CMS.Helpers;
using CMS.PortalControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vector.PublicWeb.Common.Shared;
using Vector.PublicWeb.Common.Webparts;

namespace CMSApp.CMSWebParts.Vector.ContentWebParts
{
    public partial class NewsHeaderRepeater : CMSAbstractWebPart
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var path1 = DataHelper.GetNotEmpty(GetValue(Constants.Webparts.PathOne), string.Empty);
            var path2 = DataHelper.GetNotEmpty(GetValue(Constants.Webparts.PathTwo), string.Empty);
            var path3 = DataHelper.GetNotEmpty(GetValue(Constants.Webparts.PathThree), string.Empty);

            List<NewsHeaderRepeaterItem> list = new List<NewsHeaderRepeaterItem>();
            list.Add(GetHeaderPage(path1, "nhr-first"));
            list.Add(GetHeaderPage(path2, "nhr-second"));
            list.Add(GetHeaderPage(path3, "nhr-third"));

            ContentRepeater.DataSource = list;
            ContentRepeater.DataBind();

            var isMobile = Request.IsMobileBrowser();

            ScriptPanel.Visible = isMobile;
        }

        private NewsHeaderRepeaterItem GetHeaderPage(string path, string className)
        {
            var pages = DocumentHelper.GetDocuments()
                        .Types(Constants.PageTypes.Vector + "." + Constants.PageTypes.ArticlePage)
                        .Path(path, PathTypeEnum.Single)
                        .OnCurrentSite()
                        .WithCoupledColumns();
            var page = pages.FirstOrDefault();

            return new NewsHeaderRepeaterItem
            {
                ClassName = className,
                Title = page== null ? "Page not found" : DataHelper.GetNotEmpty(page.GetValue(Constants.PageTypes.ArticlePageFields.ArticleName), string.Empty),
                ImageUrl = page == null ? "" : DataHelper.GetNotEmpty(page.GetValue(Constants.PageTypes.ArticlePageFields.ArticleHeaderImage), string.Empty),
                PageUrl = path
            };
        }
    }

}