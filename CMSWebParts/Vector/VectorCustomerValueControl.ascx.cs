using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using CMS.DocumentEngine;
using CMS.Helpers;
using CMS.PortalControls;
using CMS.PortalEngine;
using Vector.PublicWeb.Common.Shared;
using Vector.PublicWeb.Common.Webparts;

namespace CMSApp.CMSWebParts.Vector
{
    public partial class VectorCustomerValueControl : ImageTextButtonControl
    {
        public bool UsesRepeater { get; set; }
        public string TopTitle { get; set; }
        public List<TextButtonItem> Items { get; set; }
        public TextButtonRepeaterItem RepeaterItem { get; set; }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            UsesRepeater = bool.Parse(DataHelper.GetNotEmpty(GetValue(Constants.PageTypes.UsesRepeater), "false"));

            if (UsesRepeater)
            {
                TopTitle = DataHelper.GetNotEmpty(GetValue(Constants.PageTypes.TopTitle), string.Empty);

                Items = new List<TextButtonItem>();
                var path = DataHelper.GetNotEmpty(GetValue(Constants.Webparts.PathFieldName), null);
                if (path != null)
                {
                    var pages = DocumentHelper.GetDocuments()
                        .Types(Constants.PageTypes.Vector + "." + Constants.PageTypes.ImageTextButton)
                        .Path(path, PathTypeEnum.Explicit)
                        .OnCurrentSite()
                        .OrderBy(Constants.KenticoKeys.NodeLevel)
                        .OrderBy(Constants.KenticoKeys.NodeOrder)
                        .OrderBy(Constants.KenticoKeys.NodeName)
                        .WithCoupledColumns();

                    foreach (var page in pages)
                    {
                        Items.Add(new TextButtonItem
                        {
                            ImageUrl = DataHelper.GetNotEmpty(page.GetValue(Constants.PageTypes.ImageUrl), string.Empty),
                            Title = DataHelper.GetNotEmpty(page.GetValue(Constants.PageTypes.Title), string.Empty),
                            Subtitle = DataHelper.GetNotEmpty(page.GetValue(Constants.PageTypes.Subtitle), string.Empty),
                            ButtonUrl = DataHelper.GetNotEmpty(page.GetValue(Constants.PageTypes.ButtonUrl), string.Empty)
                        });
                    }
                }
            }
            else
            {
                RepeaterItem = new TextButtonRepeaterItem
                {
                    ImageUrl = Item.ImageUrl.Replace("~", ""),
                    ImageUrl2 = DataHelper.GetNotEmpty(GetValue(Constants.PageTypes.ImageUrl2), string.Empty).Replace("~", ""),
                    ImageUrl3 = DataHelper.GetNotEmpty(GetValue(Constants.PageTypes.ImageUrl3), string.Empty).Replace("~", ""),
                    Subtitle = Item.Subtitle,
                    Subtitle2 = DataHelper.GetNotEmpty(GetValue(Constants.PageTypes.Subtitle2), string.Empty),
                    Subtitle3 = DataHelper.GetNotEmpty(GetValue(Constants.PageTypes.Subtitle3), string.Empty),
                    Title = Item.Title,
                    Title2 = DataHelper.GetNotEmpty(GetValue(Constants.PageTypes.Title2), string.Empty),
                    Title3 = DataHelper.GetNotEmpty(GetValue(Constants.PageTypes.Title3), string.Empty)
                };

            }

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
                    pnlCustomerValueControlDesignMode.Visible = true;
                    pnlCustomerValueControlPreviewMode.Visible = false;
                    break;
                default:
                    pnlCustomerValueControlDesignMode.Visible = false;
                    pnlCustomerValueControlPreviewMode.Visible = true;
                    break;
            }
        }
    }
}