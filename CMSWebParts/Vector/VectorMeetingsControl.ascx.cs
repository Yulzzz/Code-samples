using System;
using System.Data;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CMS.PortalControls;
using CMS.Helpers;
using CMS.PortalEngine;

public partial class CMSWebParts_Vector_VectorMeetingsControl : CMSAbstractWebPart
{
    #region "Properties"


    /*Header*/
    public string HeaderImageUrl
    {
        get
        {
            return DataHelper.GetNotEmpty(GetValue("HeaderImageUrl"), null);
        }

        set
        {
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
    public string AnnualMeetingDate
    {
        get
        {
            return DataHelper.GetNotEmpty(GetValue("AnnualMeetingDate"), null);
        }

        set
        {
            SetValue("AnnualMeetingDate", value);
        }
    }
    public string AnnualMeetingTitle
    {
        get
        {
            return DataHelper.GetNotEmpty(GetValue("AnnualMeetingTitle"), null);
        }

        set
        {
            SetValue("AnnualMeetingTitle", value);
        }
    }
    public string AnnualMeetingDescription
    {
        get
        {
            return DataHelper.GetNotEmpty(GetValue("AnnualMeetingDescription"), null);
        }

        set
        {
            SetValue("AnnualMeetingDescription", value);
        }
    }
    public string AnnualMeetingLinks
    {
        get
        {
            return DataHelper.GetNotEmpty(GetValue("AnnualMeetingLinks"), null);
        }

        set
        {
            SetValue("AnnualMeetingLinks", value);
        }
    }

    /*Interim Report*/
    public string SpecialMeetingDate
    {
        get
        {
            return DataHelper.GetNotEmpty(GetValue("SpecialMeetingDate"), null);
        }

        set
        {
            SetValue("SpecialMeetingDate", value);
        }
    }
    public string SpecialMeetingTitle
    {
        get
        {
            return DataHelper.GetNotEmpty(GetValue("SpecialMeetingTitle"), null);
        }

        set
        {
            SetValue("SpecialMeetingTitle", value);
        }
    }
    public string SpecialMeetingDescription
    {
        get
        {
            return DataHelper.GetNotEmpty(GetValue("SpecialMeetingDescription"), null);
        }

        set
        {
            SetValue("SpecialMeetingDescription", value);
        }
    }
    public string SpecialMeetingLinks
    {
        get
        {
            return DataHelper.GetNotEmpty(GetValue("SpecialMeetingLinks"), null);
        }

        set
        {
            SetValue("SpecialMeetingLinks", value);
        }
    }
    #endregion


    #region "Methods"

    protected void Page_Load(object sender, EventArgs e)
    {
        SetupControl();


        HeaderImageUrl = DataHelper.GetNotEmpty(GetValue("HeaderImageUrl"), string.Empty);
        HeaderTitle = DataHelper.GetNotEmpty(GetValue("HeaderTitle"), string.Empty);
        HeaderButtonText = DataHelper.GetNotEmpty(GetValue("HeaderButtonText"), string.Empty);
        HeaderButtonLink = DataHelper.GetNotEmpty(GetValue("HeaderButtonLink"), string.Empty);

        AnnualMeetingDate = DataHelper.GetNotEmpty(GetValue("AnnualMeetingDate"), string.Empty);
        AnnualMeetingTitle = DataHelper.GetNotEmpty(GetValue("AnnualMeetingTitle"), string.Empty);
        AnnualMeetingDescription = DataHelper.GetNotEmpty(GetValue("AnnualMeetingDescription"), string.Empty);
        AnnualMeetingLinks = DataHelper.GetNotEmpty(GetValue("AnnualMeetingLinks"), string.Empty);

        SpecialMeetingDate = DataHelper.GetNotEmpty(GetValue("SpecialMeetingDate"), string.Empty);
        SpecialMeetingTitle = DataHelper.GetNotEmpty(GetValue("SpecialMeetingTitle"), string.Empty);
        SpecialMeetingDescription = DataHelper.GetNotEmpty(GetValue("SpecialMeetingDescription"), string.Empty);
        SpecialMeetingLinks = DataHelper.GetNotEmpty(GetValue("SpecialMeetingLinks"), string.Empty);

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
                pnlMeetingPreviewMode.Visible = false;
                break;
            default:
                pnlMeetingPreviewMode.Visible = true;
                break;
        }
    }

    #endregion
}



