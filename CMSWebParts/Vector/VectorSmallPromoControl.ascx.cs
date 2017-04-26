using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMS.Helpers;
using CMS.PortalControls;
using CMS.PortalEngine;
using Vector.PublicWeb.Common.Shared;

namespace CMSApp.CMSWebParts.Vector
{
    public partial class VectorSmallPromoControl : CMSAbstractWebPart
    {
        public string Message { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Message = DataHelper.GetNotEmpty(GetValue(Constants.PageTypes.Message), string.Empty);

            SetupControl();
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
                    pnlSmallPromoControlPreviewMode.Visible = false;
                    break;
                default:
                    pnlSmallPromoControlPreviewMode.Visible = true;
                    break;
            }
        }
    }
}