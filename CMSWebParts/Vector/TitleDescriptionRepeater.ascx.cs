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

namespace CMSApp.CMSWebParts.Vector
{
    public partial class TitleDescriptionRepeater : CMSAbstractWebPart
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var contentPath = DataHelper.GetNotEmpty(GetValue(Constants.Webparts.ContentPath), string.Empty);
            Title.Text = DataHelper.GetNotEmpty(GetValue(Constants.Webparts.FaqTitle), string.Empty);
            IconImage.ImageUrl = DataHelper.GetNotEmpty(GetValue(Constants.Webparts.FaqImage), string.Empty);
            IconImage.Visible = IconImage.ImageUrl.IsNotNullOrEmpty();
            //load faq pages
            var pages = DocumentHelper.GetDocuments()
                        .Types("CMS.Faq")
                        .Path(contentPath, PathTypeEnum.Children)
                        .OnCurrentSite()
                        .OrderBy(Constants.KenticoKeys.NodeLevel)
                        .OrderBy(Constants.KenticoKeys.NodeOrder)
                        .OrderBy(Constants.KenticoKeys.NodeName)
                        .WithCoupledColumns();

            List<KeyValuePair<string, string>> result = new List<KeyValuePair<string, string>>();
            foreach(var page in pages)
            {
                result.Add(new KeyValuePair<string, string>(DataHelper.GetNotEmpty(page.GetValue(Constants.PageTypes.Faq.FaqQuestion), string.Empty),
                    DataHelper.GetNotEmpty(page.GetValue(Constants.PageTypes.Faq.FaqAnswer), string.Empty)));
            }

            ContentRepeater.DataSource = result;
            ContentRepeater.DataBind();
        }
    }
}