using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
    public partial class VectorOutageDetailsUpdates : CMSAbstractWebPart
    {
        /// <summary>
        /// Gets or sets the data outage all activities.
        /// </summary>
        public ActivityData DataOutageAllActivities { get; set; }

        public bool DisplayDetails { get; private set; }

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
                //either display details or display latest updates
                DisplayDetails = bool.Parse(DataHelper.GetNotEmpty(GetValue(Constants.PageTypes.DisplayDetails), "true"));

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(SettingsHelper.OutageApi.Url);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var request = new HttpRequestMessage(HttpMethod.Get, $"/1/outage/{incidentId}?all_activity=true");
                    request.Headers.Add(SettingsHelper.OutageApi.AuthHeader, SettingsHelper.OutageApi.AuthKey);
                    var response = client.SendAsync(request).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var settings = new JsonSerializerSettings();
                        var responseString = response.Content.ReadAsStringAsync().Result;
                        var outageAllActivities = JsonConvert.DeserializeObject<OutageAllActivities>(responseString,
                            settings);

                        // Format display data
                        if (outageAllActivities.Success)
                            foreach (Timeline t in outageAllActivities.Data.Timeline)
                                t.DateRecordedFormatted = FormatDate(t.DateRecorded);

                        DataOutageAllActivities = outageAllActivities.Data;
                    }
                }
            }
            catch(Exception ex)
            {
                //log exception to Kentico
                EventLogProvider.LogException("Content", "GET", ex, 0, "Outage Details Updates Control", null);
            }
        }

        /// <summary>
        /// Initializes the control properties.
        /// </summary>
        protected void SetupControl()
        {
            DataOutageAllActivities = new ActivityData { Timeline = new Timeline[0] };

            // Do not hide for roles in edit or preview mode
            switch (ViewMode)
            {
                case ViewModeEnum.EditLive:
                case ViewModeEnum.EditDisabled:
                case ViewModeEnum.Design:
                case ViewModeEnum.DesignDisabled:
                case ViewModeEnum.EditNotCurrent:
                    pnlOutageDetailsUpdatesControlPreviewMode.Visible = false;
                    break;
                default:
                    pnlOutageDetailsUpdatesControlPreviewMode.Visible = true;
                    break;
            }
        }

        /// <summary>
        /// Formats the timeline.
        /// </summary>
        private string FormatDate(string dateRecorded)
        {
            //Date Recorded
            DateTime timeReported = DateTime.Parse(dateRecorded);
            DateTime currentTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "UTC", "New Zealand Standard Time");
            TimeSpan span = currentTime.Subtract(timeReported);

            var timelineFormatted = _outageService.FormatDatePerDayDifference(dateRecorded, span.Days);

            return timelineFormatted;
        }
    }
}