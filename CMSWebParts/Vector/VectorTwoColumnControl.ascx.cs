using System;
using CMS.Helpers;
using CMS.PortalEngine;

namespace CMSApp.CMSWebParts.Vector
{
    public partial class VectorTwoColumnControl : ImageTextButtonControl
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
                    pnlTwoColumnControlPreviewMode.Visible = false;
                    break;
                case ViewModeEnum.Edit:
                case ViewModeEnum.Preview:
                    pnlTwoColumnControlPreviewMode.Visible = true;
                    break;
            }
        }
    }
}