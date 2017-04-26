using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMSApp.CMSWebParts.Vector.ContentWebParts
{
    public partial class FooterShareControl : System.Web.UI.UserControl
    {
        public string InvestorSectionUrl { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            InvestorLink.NavigateUrl = InvestorSectionUrl;
        }
    }
}