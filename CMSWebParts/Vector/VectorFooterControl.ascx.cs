using CMS.CustomTables;
using CMS.Helpers;
using CMS.PortalControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vector.PublicWeb.Common.Helpers;
using Vector.PublicWeb.Common.Shared;

namespace CMSApp.CMSWebParts.Vector
{
    public partial class VectorFooterControl : CMSAbstractWebPart
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            LoadFooterLinks();

            FooterShareControl.InvestorSectionUrl = DataHelper.GetNotEmpty(GetValue(Constants.Webparts.InvestorSectionUrl), null);
        }
        private void LoadFooterLinks()
        {
            //if the table does not exist, let it crash
            var categories =
                CacheHelper.Cache(
                    cs => CustomTableItemProvider.GetItems(Constants.CustomTables.FooterLinkCategory).ToList()
                        .Select(r => new
                        {
                            column = r.GetValue(Constants.CustomTables.CategoryColumn).ToString(),
                            name = r.GetValue(Constants.CustomTables.CategoryName).ToString()
                        }),
                    new CacheSettings(SettingsHelper.Webpart.CacheSettings, Constants.CustomTables.FooterLinkCategory));

            LeftFooterTitle.Text = categories.First(r => r.column == Constants.CustomTables.ColumnLeft).name;
            RightFooterTitle.Text = categories.First(r => r.column == Constants.CustomTables.ColumnRight).name;
            CentreFooterTitle.Text = categories.First(r => r.column == Constants.CustomTables.ColumnCentre).name;

            //social links
            var socialLinks =
                CacheHelper.Cache(
                    cs => CustomTableItemProvider.GetItems(Constants.CustomTables.SocialFooterLinks).ToList()
                        .Select(r => new
                        {
                            title = r.GetValue(Constants.CustomTables.Title).ToString(),
                            url = r.GetValue(Constants.CustomTables.Url).ToString()
                        }),
                    new CacheSettings(SettingsHelper.Webpart.CacheSettings, Constants.CustomTables.SocialFooterLinks));

            var links =
                CacheHelper.Cache(
                    cs => CustomTableItemProvider.GetItems(Constants.CustomTables.GlobalFooterLinks).ToList()
                        .Select(r => new
                        {
                            column = r.GetValue(Constants.CustomTables.LinkColumn).ToString(),
                            url = r.GetValue(Constants.CustomTables.LinkUrl).ToString(),
                            name = r.GetValue(Constants.CustomTables.LinkLabel).ToString()
                        }),
                    new CacheSettings(SettingsHelper.Webpart.CacheSettings, Constants.CustomTables.GlobalFooterLinks));

            LeftFooterRepeater.DataSource = links.Where(r => r.column == Constants.CustomTables.ColumnLeft).Select(r => new HyperLink()
            {
                Text = r.name,
                NavigateUrl = r.url
            }).ToList();
            LeftFooterRepeater.DataBind();

            SocialRepeater.DataSource = socialLinks.Select(r => new HyperLink()
            {
                Text = r.title,
                NavigateUrl = r.url
            }).ToList();
            SocialRepeater.DataBind();

            RightFooterRepeater.DataSource = links.Where(r => r.column == Constants.CustomTables.ColumnRight).Select(r => new HyperLink()
            {
                Text = r.name,
                NavigateUrl = r.url
            }).ToList();
            RightFooterRepeater.DataBind();

            CentreFooterRepeater.DataSource = links.Where(r => r.column == Constants.CustomTables.ColumnCentre).Select(r => new HyperLink()
            {
                Text = r.name,
                NavigateUrl = r.url
            }).ToList();
            CentreFooterRepeater.DataBind();
        }
    }
}