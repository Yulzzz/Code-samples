using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMS.PortalControls;
using CMS.Helpers;
using Vector.PublicWeb.Common.Shared;
using Vector.PublicWeb.Common.Webparts;
using System.Configuration;
using CMS.PortalEngine;
using System.Net.Http;
using Vector.PublicWeb.Common.Helpers;
using Vector.PublicWeb.Common.Webparts.Map;

namespace CMSApp.CMSWebParts.Vector
{
    public partial class VectorMapModuleControl : CMSAbstractWebPart
    {
        public string GoogleMapKey { get; private set; }
        public string ChargePointsJson { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Button.Text = DataHelper.GetNotEmpty(GetValue(Constants.Webparts.MapButtonText), string.Empty);
            Button.NavigateUrl = DataHelper.GetNotEmpty(GetValue(Constants.Webparts.MapButtonUrl), string.Empty);
            Button.Visible = !string.IsNullOrEmpty(Button.Text) && !string.IsNullOrEmpty(Button.NavigateUrl);

            TitleText.Text = DataHelper.GetNotEmpty(GetValue(Constants.Webparts.MapTitle), string.Empty);
            SubtitleText.Text = DataHelper.GetNotEmpty(GetValue(Constants.Webparts.MapSubtitle), string.Empty);
            SubtitleText.Visible = !string.IsNullOrEmpty(SubtitleText.Text);

            NotificationText.Text = DataHelper.GetNotEmpty(GetValue(Constants.Webparts.MapNotification), string.Empty);
            NotificationText.Visible = !string.IsNullOrEmpty(NotificationText.Text);
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            bool designVisible = (PortalContext.ViewMode == ViewModeEnum.Design) || (this.HideOnCurrentPage) || (!this.IsVisible);
            ContentPanel.Visible = !designVisible;

            GoogleMapKey = SettingsHelper.Webpart.GoogleMapApiKey;
        }

    }
}