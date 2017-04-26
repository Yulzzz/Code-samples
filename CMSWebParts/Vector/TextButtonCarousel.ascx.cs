using CMS.DocumentEngine;
using CMS.Helpers;
using CMS.Membership;
using CMS.PortalControls;
using CMS.PortalEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMS.DataEngine;
using Vector.PublicWeb.Common.Shared;
using Vector.PublicWeb.Common.Webparts;

namespace CMSApp.CMSWebParts.Vector
{
    public partial class TextButtonCarousel : CMSAbstractWebPart
    {
        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        public List<TextButtonItem> Items { get; set; }
        public string ControlName { get; private set; }

        public string ClassName { get; set; }

        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            Items = new List<TextButtonItem>();
            var path = DataHelper.GetNotEmpty(GetValue(Constants.Webparts.PathFieldName), null);
            if (path != null)
            {
                var pages = DocumentHelper.GetDocuments()
                            .Types(Constants.PageTypes.Vector + "." + Constants.PageTypes.ImageTextButton)
                            .Path(path.ToString(), PathTypeEnum.Children)
                            .OnCurrentSite()
                            .WithCoupledColumns()
                            .OrderBy(OrderDirection.Ascending, "NodeOrder");

                foreach (var page in pages)
                {
                    Items.Add(new TextButtonItem
                    {
                        Title = DataHelper.GetNotEmpty(page.GetValue(Constants.PageTypes.Title), string.Empty),
                        ImageUrl = DataHelper.GetNotEmpty(page.GetValue(Constants.PageTypes.ImageUrl), string.Empty).Replace("~", ""),
                        Subtitle = DataHelper.GetNotEmpty(page.GetValue(Constants.PageTypes.Subtitle), string.Empty),
                        ButtonText = DataHelper.GetNotEmpty(page.GetValue(Constants.PageTypes.ButtonText), string.Empty),
                        ButtonUrl = DataHelper.GetNotEmpty(page.GetValue(Constants.PageTypes.ButtonUrl), string.Empty)
                    });
                }
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            ContentPanel.Visible = PortalContext.ViewMode != ViewModeEnum.Design;
            DesignPanel.Visible = !ContentPanel.Visible;

            Random ran = new Random();
            ControlName = "slider" + ran.Next(10000, 99999);
        }
    }
}