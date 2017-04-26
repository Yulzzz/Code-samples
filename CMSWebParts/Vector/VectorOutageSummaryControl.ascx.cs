using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMS.Base;
using CMS.EventLog;
using CMS.PortalControls;
using CMS.PortalEngine;
using CMS.UIControls;
using Newtonsoft.Json;
using Vector.PublicWeb.Common.Services.Abstract;
using Vector.PublicWeb.Common.Services.Concrete;
using Vector.PublicWeb.Common.Webparts;
using SettingsHelper = Vector.PublicWeb.Common.Helpers.SettingsHelper;

namespace CMSApp.CMSWebParts.Vector
{
    public partial class VectorOutageSummaryControl : CMSAbstractWebPart
    {
        /// <summary>
        /// Gets or sets the data outage summary.
        /// </summary>
        public Datum DataOutageSummary { get; set; }

        private IOutageService _outageService;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            _outageService = new LiveOutageService();
        }

        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            SetupControl();

            string incidentId = Request.QueryString["incidentId"];

            if (string.IsNullOrEmpty(incidentId)) return;

            try
            {
                DataOutageSummary = _outageService.GetOutageInformation(incidentId);
            }
            catch(Exception ex)
            {
                //log exception to kentico
                EventLogProvider.LogException("Content", "GET", ex, 0, "Outage Summary Control", null);
            }
        }

        /// <summary>
        /// Initializes the control properties.
        /// </summary>
        protected void SetupControl()
        {
            DataOutageSummary = new Datum();

            // Do not hide for roles in edit or preview mode
            switch (ViewMode)
            {
                case ViewModeEnum.EditLive:
                case ViewModeEnum.EditDisabled:
                case ViewModeEnum.Design:
                case ViewModeEnum.DesignDisabled:
                case ViewModeEnum.EditNotCurrent:
                    pnlOutageSummaryControlPreviewMode.Visible = false;
                    break;
                default:
                    pnlOutageSummaryControlPreviewMode.Visible = true;
                    break;
            }
        }
    }
}