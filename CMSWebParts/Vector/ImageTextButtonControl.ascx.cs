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

namespace CMSApp.CMSWebParts.Vector
{
    public partial class ImageTextButtonControl : CMSAbstractWebPart
    {
        public TextButtonItem Item { get; private set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Item = new TextButtonItem
            {
                ImageUrl = DataHelper.GetNotEmpty(GetValue(Constants.PageTypes.ImageUrl), string.Empty).Replace("~", ""),
                ButtonUrl = DataHelper.GetNotEmpty(GetValue(Constants.PageTypes.ButtonUrl), string.Empty),
                ButtonText = DataHelper.GetNotEmpty(GetValue(Constants.PageTypes.ButtonText), string.Empty),
                Subtitle = DataHelper.GetNotEmpty(GetValue(Constants.PageTypes.Subtitle), string.Empty),
                Title = DataHelper.GetNotEmpty(GetValue(Constants.PageTypes.Title), string.Empty),
                DisplayTitleFirst = bool.Parse(DataHelper.GetNotEmpty(GetValue(Constants.PageTypes.DisplayTitleFirst), "false"))
            };
        }
    }
}