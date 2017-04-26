using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMS.PortalEngine;

namespace CMSApp.CMSWebParts.Vector
{
    public partial class VectorPromoControl : ImageTextButtonControl
    {
        /// <summary>
        /// Content loaded event handler.
        /// </summary>
        public override void OnContentLoaded()
        {
            base.OnContentLoaded();
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
                    pnlPromoControlPreviewMode.Visible = false;
                    break;
                case ViewModeEnum.Edit:
                case ViewModeEnum.Preview:
                    pnlPromoControlPreviewMode.Visible = true;
                    break;
            }
        }
    }
}