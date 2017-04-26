using System;
using System.Data;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CMS.PortalControls;
using CMS.Helpers;
using CMS.PortalEngine;
using Vector.PublicWeb.Common.Shared;

public partial class CMSWebParts_Vector_VectorReportsControl : CMSAbstractWebPart
{
    #region "Properties"

    /*Header*/
    public string HeaderImageUrl {
        get {
            return DataHelper.GetNotEmpty(GetValue("HeaderImageUrl"), null);
        }

        set {
            SetValue("HeaderImageUrl", value);
        }
    }
    public string HeaderTitle
    {
        get
        {
            return DataHelper.GetNotEmpty(GetValue("HeaderTitle"), null);
        }

        set
        {
            SetValue("HeaderTitle", value);
        }
    }
    public string HeaderSubTitle
    {
        get
        {
            return DataHelper.GetNotEmpty(GetValue("HeaderSubTitle"), null);
        }

        set
        {
            SetValue("HeaderSubTitle", value);
        }
    }
    public string HeaderButtonText
    {
        get
        {
            return DataHelper.GetNotEmpty(GetValue("HeaderButtonText"), null);
        }

        set
        {
            SetValue("HeaderButtonText", value);
        }
    }
    public string HeaderButtonLink
    {
        get
        {
            return DataHelper.GetNotEmpty(GetValue("HeaderButtonLink"), null);
        }

        set
        {
            SetValue("HeaderButtonLink", value);
        }
    }

    /*Annual Report*/
    public string AnnualReportDate
    {
        get
        {
            return DataHelper.GetNotEmpty(GetValue("AnnualReportDate"), null);
        }

        set
        {
            SetValue("AnnualReportDate", value);
        }
    }
    public string AnnualReportTitle
    {
        get
        {
            return DataHelper.GetNotEmpty(GetValue("AnnualReportTitle"), null);
        }

        set
        {
            SetValue("AnnualReportTitle", value);
        }
    }
    public string AnnualReportDescription
    {
        get
        {
            return DataHelper.GetNotEmpty(GetValue("AnnualReportDescription"), null);
        }

        set
        {
            SetValue("AnnualReportDescription", value);
        }
    }
    public string AnnualReportLinks
    {
        get
        {
            return DataHelper.GetNotEmpty(GetValue("AnnualReportLinks"), null);
        }

        set
        {
            SetValue("AnnualReportLinks", value);
        }
    }
    public string AnnualReportFullReportButtonText
    {
        get
        {
            return DataHelper.GetNotEmpty(GetValue("AnnualReportFullReportButtonText"), null);
        }

        set
        {
            SetValue("AnnualReportFullReportButtonText", value);
        }
    }
    public string AnnualReportFullReportButtonLink
    {
        get
        {
            return DataHelper.GetNotEmpty(GetValue("AnnualReportFullReportButtonLink"), null);
        }

        set
        {
            SetValue("AnnualReportFullReportButtonLink", value);
        }
    }

    /*Interim Report*/
    public string InterimReportDate
    {
        get
        {
            return DataHelper.GetNotEmpty(GetValue("InterimReportDate"), null);
        }

        set
        {
            SetValue("InterimReportDate", value);
        }
    }
    public string InterimReportTitle
    {
        get
        {
            return DataHelper.GetNotEmpty(GetValue("InterimReportTitle"), null);
        }

        set
        {
            SetValue("InterimReportTitle", value);
        }
    }
    public string InterimReportDescription
    {
        get
        {
            return DataHelper.GetNotEmpty(GetValue("InterimReportDescription"), null);
        }

        set
        {
            SetValue("InterimReportDescription", value);
        }
    }
    public string InterimReportLinks
    {
        get
        {
            return DataHelper.GetNotEmpty(GetValue("InterimReportLinks"), null);
        }

        set
        {
            SetValue("InterimReportLinks", value);
        }
    }
    public string InterimReportButtonText
    {
        get
        {
            return DataHelper.GetNotEmpty(GetValue("InterimReportButtonText"), null);
        }

        set
        {
            SetValue("InterimReportButtonText", value);
        }
    }
    public string InterimReportButtonLink
    {
        get
        {
            return DataHelper.GetNotEmpty(GetValue("InterimReportButtonLink"), null);
        }

        set
        {
            SetValue("InterimReportButtonLink", value);
        }
    }
    #endregion


    #region "Methods"


    protected void Page_Load(object sender, EventArgs e)
    {
        SetupControl();


        HeaderImageUrl = DataHelper.GetNotEmpty(GetValue("HeaderImageUrl"), string.Empty);
        HeaderTitle = DataHelper.GetNotEmpty(GetValue("HeaderTitle"), string.Empty);
        HeaderSubTitle = DataHelper.GetNotEmpty(GetValue("HeaderSubTitle"), string.Empty);
        HeaderButtonText = DataHelper.GetNotEmpty(GetValue("HeaderButtonText"), string.Empty);
        HeaderButtonLink = DataHelper.GetNotEmpty(GetValue("HeaderButtonLink"), string.Empty);

        AnnualReportDate = DataHelper.GetNotEmpty(GetValue("AnnualReportDate"), string.Empty);
        AnnualReportTitle = DataHelper.GetNotEmpty(GetValue("AnnualReportTitle"), string.Empty);
        AnnualReportDescription = DataHelper.GetNotEmpty(GetValue("AnnualReportDescription"), string.Empty);
        AnnualReportLinks = DataHelper.GetNotEmpty(GetValue("AnnualReportLinks"), string.Empty);
        AnnualReportFullReportButtonText = DataHelper.GetNotEmpty(GetValue("AnnualReportFullReportButtonText"), string.Empty);
        AnnualReportFullReportButtonLink = DataHelper.GetNotEmpty(GetValue("AnnualReportFullReportButtonLink"), string.Empty);

        InterimReportDate = DataHelper.GetNotEmpty(GetValue("InterimReportDate"), string.Empty);
        InterimReportTitle = DataHelper.GetNotEmpty(GetValue("InterimReportTitle"), string.Empty);
        InterimReportDescription = DataHelper.GetNotEmpty(GetValue("InterimReportDescription"), string.Empty);
        InterimReportLinks = DataHelper.GetNotEmpty(GetValue("InterimReportLinks"), string.Empty);
        InterimReportButtonText = DataHelper.GetNotEmpty(GetValue("InterimReportButtonText"), string.Empty);
        InterimReportButtonLink = DataHelper.GetNotEmpty(GetValue("InterimReportButtonLink"), string.Empty);
    }

    /// <summary>
    /// Initializes the control properties.
    /// </summary>
    protected void SetupControl()
    {

        switch (ViewMode)
        {
            case ViewModeEnum.EditLive:
            case ViewModeEnum.EditDisabled:
            case ViewModeEnum.Design:
            case ViewModeEnum.DesignDisabled:
            case ViewModeEnum.EditNotCurrent:
                pnlReportPreviewMode.Visible = false;
                break;
            default:
                pnlReportPreviewMode.Visible = true;
                break;
        }
    }


    #endregion
}



