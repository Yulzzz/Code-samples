using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMS.Controls;
using CMS.EventLog;
using CMS.Helpers;
using CMS.PortalControls;
using CMS.PortalEngine;
using Newtonsoft.Json;
using Vector.PublicWeb.Common.Helpers;
using Vector.PublicWeb.Common.Services.Abstract;
using Vector.PublicWeb.Common.Services.Concrete;
using Vector.PublicWeb.Common.Shared;
using Vector.PublicWeb.Common.Webparts;

namespace CMSApp.CMSWebParts.Vector
{
    public partial class VectorOutagesMapControl : CMSAbstractWebPart
    {
        private IOutageService _liveOutageService;
        private OutageSummary _outageSummary;
        public string GoogleMapKey { get; private set; }
        public string OutageInformationAsJson { get; set; }
        public bool IsSummaryMode { get; set; }
        public string MoreDetailsPath => DataHelper.GetNotEmpty(GetValue("MoreDetailsUrl"), null);
        public string GoBackPath => DataHelper.GetNotEmpty(GetValue("GoBackUrl"), null);


        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            _liveOutageService = new LiveOutageService();
            _outageSummary = _liveOutageService.GetOutageInformation();

            string incidentId = Request.QueryString["incidentId"];
            IsSummaryMode = !string.IsNullOrEmpty(incidentId);

            try
            {
                if (IsSummaryMode)
                {
                    _outageSummary = new OutageSummary()
                    {
                        Success = true,
                        Data = new[] { _liveOutageService.GetOutageInformation(incidentId) }
                    };
                }
                else
                {
                    _outageSummary = _liveOutageService.GetOutageInformation();
                }
            }
            catch (Exception ex)
            {
                //log exception to kentico
                EventLogProvider.LogException("Content", "GET", ex, 0, "Outage Summary Control", null);
            }

            bool designMode = (PortalContext.ViewMode == ViewModeEnum.Design) || (this.HideOnCurrentPage) || (!this.IsVisible);
            pnlOutageMapControlPreviewMode.Visible = !designMode;

            GoogleMapKey = SettingsHelper.Webpart.GoogleMapApiKey;
            OutageInformationAsJson = JsonConvert.SerializeObject(_outageSummary);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            OutageTitle.Text = CreateOutagesTitle();
            OutageSubTitle.Text = CreateOutageSubTitle();
            OutagesMapNoOutageOverlay.Visible = !_outageSummary.Data.Any();
            OutagesMapGoBackButton.Visible = IsSummaryMode;
            OutagesMapGoBackButton.HRef = GoBackPath;
        }

        private string CreateOutagesTitle()
        {
            if (_outageSummary.Data == null || !_outageSummary.Data.Any()) return "Current Outages";
            if (!IsSummaryMode) return "Current Outages";

            var incident = _outageSummary.Data.First();

            return $"{incident.UtilityAffected} Outage #{incident.IncidentId}";
        }

        private string CreateOutageSubTitle()
        {
            if (_outageSummary.Data == null || !_outageSummary.Data.Any()) return "No Current Outages";

            if (IsSummaryMode)
            {
                return $"Status: {_outageSummary.Data.First().Status}";
            }

            var sb = new StringBuilder();

            var numberElectricty =
                _outageSummary.Data.Count(
                    x => x.UtilityAffected.Equals("electricity", StringComparison.OrdinalIgnoreCase));
            var numberGas =
                _outageSummary.Data.Count(x => x.UtilityAffected.Equals("gas", StringComparison.OrdinalIgnoreCase));
            var numberFibre =
                _outageSummary.Data.Count(x => x.UtilityAffected.Equals("fibre", StringComparison.OrdinalIgnoreCase));


            if (numberElectricty > 0)
                sb.Append($"{numberElectricty} Electricity {(numberElectricty > 1 ? "Outages" : "Outage")},");
            if (numberGas > 0)
                sb.Append($"{numberGas} Gas {(numberGas > 1 ? "Outages" : "Outage")},");
            if (numberFibre > 0)
                sb.Append($"{numberFibre} Fibre {(numberFibre > 1 ? "Outages" : "Outage")},");

            return sb.ToString().TrimEnd(',');
        }
    }
}