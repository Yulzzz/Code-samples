using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMS.PortalControls;
using CMS.PortalEngine;
using Vector.PublicWeb.Common.Helpers;

namespace CMSApp.CMSWebParts.Vector
{
    public partial class VectorAppInsightsControl : CMSAbstractWebPart
    {
        public string AppInsightsKey { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            SetupControl();

            AppInsightsKey = SettingsHelper.System.AppInsightsInstrumentationKey;
        }

        /// <summary>
        /// Initializes the control properties.
        /// </summary>
        protected void SetupControl()
        {
            // Do not hide for roles in edit or preview mode
            switch (ViewMode)
            {
                case ViewModeEnum.EditLive:
                case ViewModeEnum.EditDisabled:
                case ViewModeEnum.Design:
                case ViewModeEnum.DesignDisabled:
                case ViewModeEnum.EditNotCurrent:
                    pnlAppInsightsControlPreviewMode.Visible = false;
                    break;
                default:
                    pnlAppInsightsControlPreviewMode.Visible = true;
                    break;
            }
        }
    }
}