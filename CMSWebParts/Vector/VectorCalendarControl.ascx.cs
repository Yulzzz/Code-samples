using System;
using System.Data;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CMS.PortalControls;
using CMS.Helpers;
using CMS.PortalEngine;

public partial class CMSWebParts_Vector_VectorCalendarControl : CMSAbstractWebPart
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

    /*Calendar Body*/
    public string Body
    {
        get
        {
            return DataHelper.GetNotEmpty(GetValue("Body"), null);
        }

        set
        {
            SetValue("Body", value);
        }
    }


    #endregion


    #region "Methods"

    protected void Page_Load(object sender, EventArgs e)
    {
        SetupControl();


        HeaderImageUrl = DataHelper.GetNotEmpty(GetValue("HeaderImageUrl"), string.Empty);
        HeaderTitle = DataHelper.GetNotEmpty(GetValue("HeaderTitle"), string.Empty);

        Body = DataHelper.GetNotEmpty(GetValue("Body"), string.Empty);


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
                pnlCalendarPreviewMode.Visible = false;
                break;
            default:
                pnlCalendarPreviewMode.Visible = true;
                break;
        }
    }


    #endregion
}



