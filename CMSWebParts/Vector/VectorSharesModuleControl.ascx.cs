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
    public partial class VectorSharesModuleControl : CMSAbstractWebPart
    {
        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        public string ImageUrl { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            SetupControl();

            ImageUrl = DataHelper.GetNotEmpty(GetValue(Constants.PageTypes.ImageUrl), string.Empty).Replace("~","");
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
                    pnlSharesModuleControlPreviewMode.Visible = false;
                    break;
                default:
                    pnlSharesModuleControlPreviewMode.Visible = true;
                    break;
            }
        }
    }
}