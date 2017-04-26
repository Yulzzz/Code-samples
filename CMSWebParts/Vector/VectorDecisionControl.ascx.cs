using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMS.Helpers;
using CMS.PortalEngine;
using Vector.PublicWeb.Common.Shared;
using Vector.PublicWeb.Common.Webparts;

namespace CMSApp.CMSWebParts.Vector
{
    public partial class VectorDecisionControl : ImageTextButtonControl
    {
        public TextButtonClickThroughItem ClickThroughItem { get; private set; }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ClickThroughItem = new TextButtonClickThroughItem
            {
                ImageUrl = Item.ImageUrl.Replace("~", ""),
                ButtonUrl = Item.ButtonUrl,
                ButtonText = Item.ButtonText,
                ButtonUrl2 = DataHelper.GetNotEmpty(GetValue(Constants.PageTypes.ButtonUrl2), string.Empty),
                ButtonText2 = DataHelper.GetNotEmpty(GetValue(Constants.PageTypes.ButtonText2), string.Empty),
                ButtonUrl3 = DataHelper.GetNotEmpty(GetValue(Constants.PageTypes.ButtonUrl3), string.Empty),
                ButtonText3 = DataHelper.GetNotEmpty(GetValue(Constants.PageTypes.ButtonText3), string.Empty),
                Subtitle = Item.Subtitle,
                Title = Item.Title,
                DisplayTitleFirst = Item.DisplayTitleFirst
            };
        }

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
                    pnlDecisionControlPreviewMode.Visible = false;
                    break;
                default:
                    pnlDecisionControlPreviewMode.Visible = true;
                    break;
            }
        }
    }
}