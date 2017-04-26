using CMS.Helpers;
using CMS.PortalControls;
using CMS.PortalEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vector.PublicWeb.Common.Shared;

namespace CMSApp.CMSWebParts.Vector
{
    public partial class DefaultPageNotification : CMSAbstractWebPart
    {
        public bool IsOnSecondaryLandingPage { get; private set; }
        public bool HasClosed { get; private set; }
        public bool RedirectToBusiness { get; private set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            var secondaryLandingPage = DataHelper.GetNotEmpty(GetValue(Constants.Webparts.DefaultPageNotificationPath), string.Empty);

            if (secondaryLandingPage.IsNullOrEmpty() || PortalContext.ViewMode == ViewModeEnum.Design)
            {
                ContentPanel.Visible = false;
                return;
            }

            IsOnSecondaryLandingPage = CurrentDocument.NodeAliasPath == secondaryLandingPage;
            var primaryHomePage = DataHelper.GetNotEmpty(GetValue(Constants.Webparts.PrimaryLandingPage), string.Empty);
            var isHomePage = Request.RawUrl == "/" && CurrentDocument.NodeAliasPath == primaryHomePage;

            var seen = Request.Cookies[Constants.Webparts.HasClosedDefaultPageNotification];
            HasClosed = seen == null ? false : bool.Parse(seen.Value);

            var redirect = Request.Cookies[Constants.Webparts.RedirectToPage];
            RedirectToBusiness = redirect == null ? false : bool.Parse(redirect.Value);
            
            //user visits the root url
            
            if (isHomePage && HttpContext.Current.Request.UrlReferrer == null)
            {
                if (RedirectToBusiness && !IsOnSecondaryLandingPage)
                {
                    Response.Redirect(secondaryLandingPage);
                }

                if (!RedirectToBusiness && CurrentDocument.NodeAliasPath != primaryHomePage)
                {
                    Response.Redirect(primaryHomePage);
                }
            }
        }
    }
}