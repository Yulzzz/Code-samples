using CMS.DocumentEngine;
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
    public partial class VectorHeaderControl : CMSAbstractWebPart
    {
        private string SearchUrl => DataHelper.GetNotEmpty(GetValue("SearchURL"), null);
        public string SearchPagePath { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //search path
            SearchPagePath = URLHelper.GetAbsoluteUrl(URLHelper.ResolveUrl(SearchUrl));

            //load path for the carousel from the page field, if any
            var path = DataHelper.GetNotEmpty(CurrentDocument.GetValue(Constants.Webparts.CarouselPathFieldName), null);
            backgroundCarousel.SetValue(Constants.Webparts.PathFieldName, path);

            if (path != null)
            {
                CarouselPanel.CssClass = "hasCarousel";
            }

            backgroundCarousel.CssClass = CarouselPanel.CssClass;
            GetFirstAndSecondLevelNodes();
        }

        private void GetFirstAndSecondLevelNodes()
        {
            string topPath, secondPath;

            var current = CMS.DocumentEngine.DocumentContext.CurrentDocument;
            var parent = CMS.DocumentEngine.DocumentContext.CurrentDocument.Parent;

            if(parent == null || (parent != null && parent.NodeAliasPath == "/"))
            {
                //current doc is one of the root pages
                topPath = current.NodeAliasPath;
                SecondLeveMenu.ParentControl = FirstLevelMenu;
                SecondLeveMenu.Path = topPath + "/%";

                var secondLevel = SecondLeveMenu.GetDataSource();
                SecondLeveMenu.Visible = secondLevel.Tables[0].CreateDataReader().HasRows;
                return;
            }

            while (parent.Parent != null && parent.Parent.NodeAliasPath != "/")
            {
                current = parent;
                parent = parent.Parent;
            }

            topPath = parent.NodeAliasPath;
            secondPath = current.NodeAliasPath;
            FirstLevelMenu.HighlightedNodePath = topPath;
            SecondLeveMenu.HighlightedNodePath = secondPath;

            var data = FirstLevelMenu.GetDataSource();
            var parentMenu = data.Tables[0];

            bool topInMenu = false;
            var reader = parentMenu.CreateDataReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (reader["NodeAliasPath"].ToString().Equals(topPath))
                    {
                        SecondLeveMenu.ParentControl = FirstLevelMenu;
                        //setting the second level nav's path
                        SecondLeveMenu.Path = topPath + "/%";
                        topInMenu = true;
                        return;
                    }
                }
            }

            SecondLeveMenu.Visible = topInMenu;
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }
    }
}