using CMS.DocumentEngine;
using CMS.Helpers;
using CMS.PortalControls;
using CMS.PortalEngine;
using CMSApp.Vector.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vector.PublicWeb.Common.Shared;
using Vector.PublicWeb.Common.Webparts;

namespace CMSApp.CMSWebParts.Vector
{
    public partial class TeamProfileControl : CMSAbstractWebPart
    {
        public List<PersonItem> People { get; set; }
        public int PageSize { get; set; }
        public string Path { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            PageSize = 50000;
            Path = DataHelper.GetNotEmpty(GetValue(Constants.Webparts.PathFieldName), null);
            if (Request.IsMobileBrowser())
            {
                PageSize = Convert.ToInt32(DataHelper.GetNotEmpty(GetValue(Constants.Webparts.TeamPageSize), "6"));
            }
            //load the first page
            People = PeopleLoader.Get(Path, 0, PageSize);
            
            PeopleRepeater.DataSource = People;
            PeopleRepeater.DataBind();
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            TeamPanel.Visible = PortalContext.ViewMode != ViewModeEnum.Design;
            DesignPanel.Visible = !TeamPanel.Visible;
        }
    }
}