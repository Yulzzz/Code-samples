using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMS.CustomTables;
using CMS.Helpers;
using CMS.PortalControls;
using CMS.PortalEngine;
using Vector.PublicWeb.Common.Helpers;
using Vector.PublicWeb.Common.Shared;
using Vector.PublicWeb.Common.Webparts;

namespace CMSApp.CMSWebParts.Vector
{
    public partial class VectorDividendCalculatorControl : CMSAbstractWebPart
    {
        public IEnumerable<DividendItem> DividendList { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            SetupControl();

            var dividends =
                CacheHelper.Cache(
                    cs => CustomTableItemProvider.GetItems(Constants.CustomTables.DividendCalculator).ToList()
                        .OrderByDescending(d => d.ItemID)
                        .Select(r => new DividendItem()
                        {
                            Dividend = r.GetValue(Constants.CustomTables.Dividend).ToString(),
                            RecordDate = DateTime.Parse(r.GetValue(Constants.CustomTables.RecordDate).ToString()),
                            Amount = double.Parse(r.GetValue(Constants.CustomTables.Amount).ToString())
                        }),
                    new CacheSettings(SettingsHelper.Webpart.CacheSettings, Constants.CustomTables.DividendCalculator));

            DividendList = dividends ?? new List<DividendItem>();
        }

        /// <summary>
        /// Initializes the control properties.
        /// </summary>
        protected void SetupControl()
        {
            // Do not hide for roles in edit or preview mode
            switch (ViewMode)
            {
                case ViewModeEnum.EditLive:
                case ViewModeEnum.EditDisabled:
                case ViewModeEnum.Design:
                case ViewModeEnum.DesignDisabled:
                case ViewModeEnum.EditNotCurrent:
                    pnlDividendCalculatorControlPreviewMode.Visible = false;
                    break;
                default:
                    pnlDividendCalculatorControlPreviewMode.Visible = true;
                    break;
            }
        }
    }
}