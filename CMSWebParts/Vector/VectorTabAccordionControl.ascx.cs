using AjaxControlToolkit;
using CMS.ExtendedControls;
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

using CMS.Base;
using System.Text;

namespace CMSApp.CMSWebParts.Vector
{
    public partial class VectorTabAccordionControl : CMSAbstractLayoutWebPart
    {
        public string MobileViewClass { get; set;}
        public bool IsMobileView { get; set; }
        public string UniqueHtmlId { get; set; }

        public List<string> Headers { get; set; }
        public List<TabAccordionViewModel> TabContent { get; set; }

        #region "Variables"

        private TabContainer tabs = null;

        #endregion


        #region "Public properties"

        /// <summary>
        /// Number of tabs.
        /// </summary>
        public int Tabs
        {
            get
            {
                return ValidationHelper.GetInteger(GetValue("Tabs"), 2);
            }
            set
            {
                SetValue("Tabs", value);
            }
        }


        /// <summary>
        /// Tab headers.
        /// </summary>
        public string TabHeaders
        {
            get
            {
                return ValidationHelper.GetString(GetValue("TabHeaders"), "");
            }
            set
            {
                SetValue("TabHeaders", value);
            }
        }


        /// <summary>
        /// Active tab index.
        /// </summary>
        public int ActiveTabIndex
        {
            get
            {
                return ValidationHelper.GetInteger(GetValue("ActiveTabIndex"), 0);
            }
            set
            {
                SetValue("ActiveTabIndex", value);
            }
        }


        /// <summary>
        /// Hide empty tabs
        /// </summary>
        public bool HideEmptyTabs
        {
            get
            {
                return ValidationHelper.GetBoolean(GetValue("HideEmptyTabs"), false);
            }
            set
            {
                SetValue("HideEmptyTabs", value);
            }
        }


        /// <summary>
        /// Hide if no tabs are visible
        /// </summary>
        public bool HideIfNoTabsVisible
        {
            get
            {
                return ValidationHelper.GetBoolean(GetValue("HideIfNoTabsVisible"), true);
            }
            set
            {
                SetValue("HideIfNoTabsVisible", value);
            }
        }


        /// <summary>
        /// Tab strip placement.
        /// </summary>
        public string TabStripPlacement
        {
            get
            {
                return ValidationHelper.GetString(GetValue("TabStripPlacement"), "top");
            }
            set
            {
                SetValue("TabStripPlacement", value);
            }
        }


        /// <summary>
        /// Width.
        /// </summary>
        public string Width
        {
            get
            {
                return ValidationHelper.GetString(GetValue("Width"), "");
            }
            set
            {
                SetValue("Width", value);
            }
        }


        /// <summary>
        /// Height.
        /// </summary>
        public string Height
        {
            get
            {
                return ValidationHelper.GetString(GetValue("Height"), "");
            }
            set
            {
                SetValue("Height", value);
            }
        }


        /// <summary>
        /// Tabs CSS class.
        /// </summary>
        public string TabsCSSClass
        {
            get
            {
                return ValidationHelper.GetString(GetValue("TabsCSSClass"), "");
            }
            set
            {
                SetValue("TabsCSSClass", value);
            }
        }


        /// <summary>
        /// Scrollbars.
        /// </summary>
        public string Scrollbars
        {
            get
            {
                return ValidationHelper.GetString(GetValue("Scrollbars"), "");
            }
            set
            {
                SetValue("Scrollbars", value);
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected override void OnInit(EventArgs e)
        {
            Content.Visible = PortalContext.ViewMode != ViewModeEnum.Design;

            if (IsDesign)
            {
                base.OnInit(e);
            }
        }


        #region "Page events"

        /// <summary>
        /// Render event handler
        /// </summary>
        protected override void Render(HtmlTextWriter writer)
        {
            if (HideIfNoTabsVisible)
            {
                // Check if some tab is visible
                Visible = tabs.Tabs.Cast<CMSTabPanel>().Any(tab => tab.Visible);
            }
            if (Visible)
            {
                const string preventFocusLoadScript = @"
                        Sys.Extended.UI.TabContainer.prototype._app_onload = function (sender, e) {
                            if (this._cachedActiveTabIndex != -1) {
                                this.set_activeTabIndex(this._cachedActiveTabIndex);
                                this._cachedActiveTabIndex = -1;

                                var activeTab = this.get_tabs()[this._activeTabIndex];
                                if (activeTab) {
                                    activeTab._wasLoaded = true;
                                    /*** CMS ***/
                                    // Disable focus on active tab
                                    //activeTab._setFocus(activeTab);
                                    /*** END CMS ***/
                                }
                            }
                            this._loaded = true;
                        }
                        ";
                // Register script preventing focusing active tab (caused scrolling to tab container - e.g. to the bottom of the page)
                ScriptHelper.RegisterStartupScript(this, typeof(string), "preventTabFocus", preventFocusLoadScript, true);
            }

            base.Render(writer);
        }

        #endregion


        #region "Methods"

        /// <summary>
        /// Prepares the layout of the web part.
        /// </summary>
        protected override void PrepareLayout()
        {
            //make a unique id for the div, this is to deal with multiple instances of the control on the same page
            Random ran = new Random();
            UniqueHtmlId = "vectorTabAccordion" + ran.Next(10000, 999999);
            IsMobileView = Request.IsMobileBrowser();

            StartLayout();
            StringBuilder result = new StringBuilder();

            result.Append("<div ");
            // Width
            string width = Width;
            if (!string.IsNullOrEmpty(width))
            {
                result.Append(" style=\"width: ", width, "\"");
            }

            if (IsDesign)
            {
                result.Append(" id=\"", ShortClientID, "_env\">");

                result.Append("<table class=\"LayoutTable\" cellspacing=\"0\" style=\"width: 100%;\">");

                switch (ViewMode)
                {
                    case ViewModeEnum.Design:
                    case ViewModeEnum.DesignDisabled:
                        {
                            result.Append("<tr><td class=\"LayoutHeader\" colspan=\"2\">");

                            // Add header container
                            AddHeaderContainer();

                            result.Append("</td></tr>");
                        }
                        break;
                }

                result.Append("<tr><td style=\"width: 100%;\">");
            }
            else
            {
                result.Append(">");
            }

            // Add the tabs
            tabs = new TabContainer();
            tabs.ID = "tabs";

            if (IsDesign)
            {
                result.Append("</td>");

                // Resizers
                if (AllowDesignMode)
                {
                    // Width resizer
                    result.Append("<td class=\"HorizontalResizer\" onmousedown=\"", GetHorizontalResizerScript("env", "Width", false, "tabs_body"), " return false;\">&nbsp;</td></tr>");

                    // Height resizer
                    result.Append("<tr><td class=\"VerticalResizer\" onmousedown=\"", GetVerticalResizerScript("tabs_body", "Height"), " return false;\">&nbsp;</td>");
                    result.Append("<td class=\"BothResizer\" onmousedown=\"", GetHorizontalResizerScript("env", "Width", false, "tabs_body"), " ", GetVerticalResizerScript("tabs_body", "Height"), " return false;\">&nbsp;</td>");
                }

                result.Append("</tr>");
            }

            // Tab headers
            string[] headers = TextHelper.EnsureLineEndings(TabHeaders, "\n").Split('\n');

            if ((ActiveTabIndex >= 1) && (ActiveTabIndex <= Tabs))
            {
                tabs.ActiveTabIndex = ActiveTabIndex - 1;
            }

            bool hideEmpty = HideEmptyTabs;

            for (int i = 1; i <= Tabs; i++)
            {
                // Create new tab
                CMSTabPanel tab = new CMSTabPanel();
                tab.ID = "tab" + i;

                // Prepare the header
                string header = null;
                if (headers.Length >= i)
                {
                    header = ResHelper.LocalizeString(headers[i - 1]);
                    header = HTMLHelper.HTMLEncode(header);
                }
                if (String.IsNullOrEmpty(header))
                {
                    header = "Tab " + i;
                }

                tab.HeaderText = header;
                tab.HideIfZoneEmpty = hideEmpty;

                tabs.Tabs.Add(tab);

                tab.WebPartZone = AddZone(ID + "_" + i, header, tab);
            }

            if (IsDesign || !IsMobileView)
            {
                //show tabs in design mode
                AddControl(tabs);
            }
            else
            {
                //show tab content in view mode
                ShowTabContent();
            }

            // Setup the tabs
            tabs.ScrollBars = ControlsHelper.GetScrollbarsEnum(Scrollbars);

            if (!String.IsNullOrEmpty(TabsCSSClass))
            {
                tabs.CssClass = TabsCSSClass;
            }

            tabs.TabStripPlacement = GetTabStripPlacement(TabStripPlacement);

            if (!String.IsNullOrEmpty(Height))
            {
                tabs.Height = new Unit(Height);
            }

            if (IsDesign)
            {
                // Footer
                if (AllowDesignMode)
                {
                    result.Append("<tr><td class=\"LayoutFooter cms-bootstrap\" colspan=\"2\"><div class=\"LayoutFooterContent\">");

                    result.Append("<div class=\"LayoutLeftActions\">");

                    // Pane actions
                    AppendAddAction(ResHelper.GetString("Layout.AddTab"), "Tabs");
                    if (Tabs > 1)
                    {
                        AppendRemoveAction(ResHelper.GetString("Layout.RemoveTab"), "Tabs");
                    }

                    result.Append("</div></div></td></tr>");
                }

                result.Append("</table>");
            }

            result.Append("</div>");

            //Append(result.ToString());
            FinishLayout();
        }

        /// <summary>
        /// Add tab content onto the web page in view mode.
        /// </summary>
        private void ShowTabContent()
        {
            Panel container = new Panel();
            container.CssClass = "jq-tab-accordion ";
            container.ID = UniqueHtmlId;
            MobileViewClass = IsMobileView ? "inMobile" : string.Empty;
            container.ClientIDMode = ClientIDMode.Static;

            container.CssClass += MobileViewClass;

            for(int i = 0; i< tabs.Tabs.Count; i ++)
            {
                Panel child = new Panel();
                var tab = (CMSTabPanel)tabs.Tabs[i];

                Panel header = new Panel();
                header.CssClass = UniqueHtmlId + "accordionHeader";
                header.Controls.Add(new Label() { Text = tab.HeaderText });
                container.Controls.Add(header);

                child.Controls.Add(AddZone(ID + "_" + (i + 1), tab.HeaderText, child));
                container.Controls.Add(child);
            }
            AddControl(container);
        }


        /// <summary>
        /// Gets the tab strip placement based on the string representation
        /// </summary>
        /// <param name="placement">Placement</param>
        protected TabStripPlacement GetTabStripPlacement(string placement)
        {
            switch (placement.ToLowerCSafe())
            {
                case "bottom":
                    return AjaxControlToolkit.TabStripPlacement.Bottom;

                case "bottomright":
                    return AjaxControlToolkit.TabStripPlacement.BottomRight;

                case "topright":
                    return AjaxControlToolkit.TabStripPlacement.TopRight;

                default:
                    return AjaxControlToolkit.TabStripPlacement.Top;
            }
        }

        #endregion
    }

    public class TabAccordionViewModel
    {
        public string HeaderText { get; set; }
        public List<Control> Controls { get; set; }
    }
}