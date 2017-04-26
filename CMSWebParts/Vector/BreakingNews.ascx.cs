using CMS.DocumentEngine;
using CMS.Helpers;
using CMS.PortalControls;
using CMS.PortalEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vector.PublicWeb.Common.Shared;
namespace CMSApp.CMSWebParts.Vector
{
    public partial class BreakingNews : CMSAbstractWebPart
    {
        public string Message { get; set; }
        public bool ShouldShowMessage { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            //dont show in design mode
            if(PortalContext.ViewMode == ViewModeEnum.Design)
            {
                ContentPanel.Visible = false;
                return;
            }

            //check cookie
            var lastSeen = Request.Cookies[Constants.Webparts.HasReadBreakingNews];
            DateTime? lastSeenDate = null;
            if (lastSeen != null)
            {
                var lastSeenTicks = long.Parse(lastSeen.Value);
                lastSeenDate = new DateTime(lastSeenTicks, DateTimeKind.Utc);
            }

            var nextCheck = Request.Cookies[Constants.Webparts.NextCheck];
            DateTime? nextCheckDate = null;
            if (nextCheck != null)
            {
                var nextCheckTicks = long.Parse(nextCheck.Value);
                nextCheckDate = new DateTime(nextCheckTicks, DateTimeKind.Utc);
            }

            if(lastSeenDate.HasValue && nextCheckDate.HasValue && DateTime.UtcNow < nextCheckDate.Value)
            {
                //if has seen and the cookie is still active, show nothing
                ContentPanel.Visible = false;
                return;
            }

            string path = DataHelper.GetNotEmpty(GetValue(Constants.Webparts.BreakingNewsPage), null);
            if (!path.IsNotNullOrEmpty())
            {
                //breaking news is not set.
                ContentPanel.Visible = false;
                return;
            }


            var pages = DocumentHelper.GetDocuments()
                        .Types(Constants.PageTypes.Vector + "." + Constants.PageTypes.BreakingNews)
                        .Path(path.ToString(), PathTypeEnum.Single)
                        .OnCurrentSite()
                        .WithCoupledColumns(); 

            var page = pages.FirstOrDefault();
            if(page == null)
            {
                this.Visible = false;
                return;
            }

            //either the user hasnt seen the new message or the cookie has expired, 
            Message = DataHelper.GetNotEmpty(page.GetValue(Constants.Webparts.NewsText), string.Empty);

            if (Message.IsNullOrEmpty())
            {
                //if there is no message to be seen, show nothing
                this.Visible = false;
                return;
            }

            var seenText = Request.Cookies[Constants.Webparts.NewsText];
            if(seenText!= null && seenText.Value.IsNotNullOrEmpty())
            {
                if (Message.ToLower().Equals(seenText.Value.ToLower()) && lastSeenDate.HasValue)
                {
                    //nothing new to see, the user has head this message before, show nothing
                    ContentPanel.Visible = false;
                    return;
                }
            }

            //if there is, setup the control
            var fromDate = DataHelper.GetNotEmpty(page.GetValue(Constants.Webparts.DocumentPublishFrom), string.Empty);
            var toDate = DataHelper.GetNotEmpty(page.GetValue(Constants.Webparts.DocumentPublishTo), string.Empty);
            DateTime? dateFrom = null, dateTo = null;

            if (fromDate.IsNotNullOrEmpty())
            {
                dateFrom = DateTime.Parse(fromDate);
            }
            if (toDate.IsNotNullOrEmpty())
            {
                dateTo = DateTime.Parse(toDate);
            }
            var now = DateTime.UtcNow;
            ShouldShowMessage = (!dateFrom.HasValue && !dateTo.HasValue) ||
                                        (dateFrom.HasValue && dateFrom.Value.ToUniversalTime() <= now && !dateTo.HasValue) ||
                                        (dateFrom.HasValue && dateFrom.Value.ToUniversalTime() <= now && dateTo.HasValue && dateTo.Value.ToUniversalTime() > now) ||
                                        (!dateFrom.HasValue && dateTo.HasValue && dateTo.Value.ToUniversalTime() > now);
        }
    }
}