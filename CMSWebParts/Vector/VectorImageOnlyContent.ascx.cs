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
    public partial class VectorImageOnlyContent : CMSAbstractWebPart
    {
        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        public ItemContent Item { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            SetupControl();

            Item = new ItemContent()
            {
                Title = DataHelper.GetNotEmpty(GetValue(Constants.PageTypes.Title), string.Empty),
                Subtitle = DataHelper.GetNotEmpty(GetValue(Constants.PageTypes.Subtitle), string.Empty),
                Body = DataHelper.GetNotEmpty(GetValue(Constants.PageTypes.Body), string.Empty)
            };
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
                    pnlImageOnlyContentPreviewMode.Visible = false;
                    break;
                default:
                    pnlImageOnlyContentPreviewMode.Visible = true;
                    break;
            }
        }
    }

    public class ItemContent
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Body { get; set; }
    }
}