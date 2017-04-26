using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMS.EventLog;
using CMS.Helpers;
using CMS.PortalControls;
using CMS.PortalEngine;
using Vector.PublicWeb.Common.Helpers;
using Vector.PublicWeb.Common.Payment;
using Vector.PublicWeb.Common.Payment.PxPay;
using Vector.PublicWeb.Common.Shared;

namespace CMSApp.CMSWebParts.Vector
{
    public partial class VectorPaymentExpress : CMSAbstractWebPart
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string SuccessMessage { get; set; }
        public string FailMessage { get; set; }

        /// <summary>
        /// Content loaded event handler.
        /// </summary>
        public override void OnContentLoaded()
        {
            base.OnContentLoaded();
            SetupControl();
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
                    pnlPaymentExpressControlPreviewMode.Visible = false;
                    pnlPaymentExpressControlLoad.Visible = false;
                    break;
                case ViewModeEnum.Edit:
                case ViewModeEnum.Preview:
                    pnlPaymentExpressControlPreviewMode.Visible = true;
                    pnlPaymentExpressControlLoad.Visible = true;
                    break;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Title = DataHelper.GetNotEmpty(GetValue(Constants.PageTypes.Title), string.Empty);
            Description = DataHelper.GetNotEmpty(GetValue(Constants.PageTypes.Description), string.Empty);
            SuccessMessage = DataHelper.GetNotEmpty(GetValue(Constants.PageTypes.SuccessMessage), string.Empty);
            FailMessage = DataHelper.GetNotEmpty(GetValue(Constants.PageTypes.FailMessage), string.Empty);

            //Determine if the page request is for a user returning from the payment page
            string resultQs = Request.QueryString["result"];

            if (!string.IsNullOrEmpty(resultQs))
            {
                string pxPayUserId = SettingsHelper.Payment.UserId;
                string pxPayKey = SettingsHelper.Payment.Key;

                try
                {
                    // Obtain the transaction result
                    PxPay wsPxPay = new PxPay(pxPayUserId, pxPayKey);

                    ResponseOutput output = wsPxPay.ProcessResponse(resultQs);

                    lblResponse.Text = (output.Success == "1") ? SuccessMessage : FailMessage;

                    pnlPaymentExpressControlPreviewMode.Visible = false;
                    pnlPaymentExpressControlLoad.Visible = true;

                    // Sending invoices/updating order status within database etc.

                    if (!IsProcessed(output.TxnId) && output.valid == "1" && output.Success == "1")
                    {
                        // TODO: Send emails, generate invoices, update order status etc.
                    }
                }
                catch (Exception ex)
                {
                    //log exception to Kentico
                    EventLogProvider.LogException("Payment", "GET", ex, 0, "Payment Express Control", null);
                }
            }
        }

        /// <summary>
        /// Database lookup to check the status of the order or shopping cart
        /// </summary>
        /// <param name="txnId"></param>
        /// <returns></returns>
        protected bool IsProcessed(string txnId)
        {
            // TODO: Check database if order relating to TxnId has alread been processed
            return false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string pxPayUserId = SettingsHelper.Payment.UserId;
            string pxPayKey = SettingsHelper.Payment.Key;

            try
            {
                PaymentDetails paymentDetails = ReadAndValidateInput();

                if (paymentDetails == null)
                {
                    lblMessage.Text = "There was an error processing your request, please try again.";
                    return;
                }

                PxPay wsPxPay = new PxPay(pxPayUserId, pxPayKey);

                RequestInput input = new RequestInput();
                input.AmountInput = paymentDetails.Amount.ToString(CultureInfo.InvariantCulture);
                input.CurrencyInput = "NZD";
                input.MerchantReference = paymentDetails.RefNumber;
                input.TxnData1 = paymentDetails.RefType;
                input.TxnData2 = paymentDetails.FullName;
                input.TxnData3 = paymentDetails.Phone;
                input.TxnType = "Purchase";
                input.UrlFail = CMS.DocumentEngine.DocumentContext.CurrentDocument.AbsoluteURL;
                input.UrlSuccess = CMS.DocumentEngine.DocumentContext.CurrentDocument.AbsoluteURL;

                // TODO: GUID representing unique identifier for the transaction within the shopping cart (normally would be an order ID or similar)
                Guid orderId = Guid.NewGuid();
                input.TxnId = orderId.ToString().Substring(0, 16);

                RequestOutput output = wsPxPay.GenerateRequest(input);

                if (output.valid == "1")
                {
                    // Redirect user to payment page

                    Response.Redirect(output.Url);
                }
            }
            catch (Exception ex)
            {
                //log exception to Kentico
                EventLogProvider.LogException("Payment", "POST", ex, 0, "Payment Express Control", null);
                lblMessage.Text = "There was an error processing your request, please contact Vector.";
            }
        }

        private PaymentDetails ReadAndValidateInput()
        {
            StringBuilder output = new StringBuilder();

            var paymentDetail = new PaymentDetails()
            {
                FirstName = txtFirstName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                Phone = txtPhone.Text,
                RefType = ddlRefType.SelectedValue,
                RefNumber = txtRefNumber.Text,
                Amount = 0, //set below
                Accept = !string.IsNullOrEmpty(chkAccept.Value) && bool.Parse(chkAccept.Value)
            };

            var context = new ValidationContext(paymentDetail, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            var isValid = System.ComponentModel.DataAnnotations.Validator.TryValidateObject(paymentDetail, context, results);

            //Validation - FirstName
            if (results.Find(v => v.ErrorMessage == "Please enter your first name") == null)
            {
                if (paymentDetail.FirstName.Length < 2 || paymentDetail.FirstName.Length > 50)
                    output.AppendLine("Please enter a valid first name");
                if (!Regex.IsMatch(paymentDetail.FirstName, @"[\u00C0-\u01FFa-zA-Z'\-]+( [\u00C0-\u01FFa-zA-Z'\-]+)*", RegexOptions.IgnoreCase))
                    output.AppendLine("Please enter a valid first name");
            }

            //Validation - LastName
            if (results.Find(v => v.ErrorMessage == "Please enter your last name") == null)
            {
                if (paymentDetail.FirstName.Length < 2 || paymentDetail.FirstName.Length > 50)
                    output.AppendLine("Please enter a valid last name");
                if (!Regex.IsMatch(paymentDetail.LastName, @"[\u00C0-\u01FFa-zA-Z'\-]+( [\u00C0-\u01FFa-zA-Z'\-]+)*", RegexOptions.IgnoreCase))
                    output.AppendLine("Please enter a valid last name");
            }

            //Validation - Phone
            if (results.Find(v => v.ErrorMessage == "Please enter your phone") == null)
            {
                if (paymentDetail.Phone.Length < 5)
                    output.AppendLine("Please enter a valid phone");
                if (!Regex.IsMatch(paymentDetail.Phone, @"\d{1,14}", RegexOptions.IgnoreCase))
                    output.AppendLine("Please enter a valid phone");
            }

            //Validation - Reference Number
            if (results.Find(v => v.ErrorMessage == "Please enter a reference number") == null)
            {
                if (paymentDetail.RefNumber.Length < 9 || paymentDetail.RefNumber.Length > 20)
                    output.AppendLine("Please enter a valid reference number");
                switch (paymentDetail.RefType)
                {
                    case "CNO":
                        if (!Regex.IsMatch(paymentDetail.RefNumber, @"[9]{3}[0-9]{6}", RegexOptions.IgnoreCase))
                            output.AppendLine("Please enter a valid reference number");
                        break;
                    case "SRO":
                        if (!Regex.IsMatch(paymentDetail.RefNumber, @"[0-9]+[\-]+[\-a-zA-Z0-9]+", RegexOptions.IgnoreCase))
                            output.AppendLine("Please enter a valid reference number");
                        break;
                    case "WBS":
                        if (!Regex.IsMatch(paymentDetail.RefNumber, @"[a-zA-Z0-9]+[\-]+[\-a-zA-Z0-9]+", RegexOptions.IgnoreCase))
                            output.AppendLine("Please enter a valid reference number");
                        break;
                }
            }

            //Validation - Amount payable
            if (results.Find(v => v.ErrorMessage == "Please enter the amount") == null)
            {
                if (txtAmount.Text.Length > 20)
                    output.AppendLine("Please enter the amount in e.g. 1000.00 format");
                if (!Regex.IsMatch(txtAmount.Text, @"(?=.*[1-9])\d+[\.][0-9]{2}", RegexOptions.IgnoreCase))
                    output.AppendLine("Please enter a valid amount in e.g. 1000.00 format");
            }

            //Validation - Acceptance
            if (!paymentDetail.Accept) output.AppendLine("Please confirm");

            //Final
            if (!isValid || output.Length > 0)
            {
                paymentDetail = null;
            }
            else
            {
                paymentDetail.Amount = decimal.Parse(txtAmount.Text);
            }

            return paymentDetail;
        }
    }
}