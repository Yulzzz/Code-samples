<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VectorPaymentExpress.ascx.cs" Inherits="CMSApp.CMSWebParts.Vector.VectorPaymentExpress" %>

<!-- start of Payment Express -->
<asp:Panel ID="pnlPaymentExpressControlPreviewMode" runat="server" ng-app="app">

    <script language="javascript" src="<%=ResolveUrl("~/CMSScripts/Vector/app.js")%>" type="text/javascript"></script>

    <div id="payment-control" ng-controller="paymentController as vm">
        <div class="vctr-payment-title"><h6><%=Title %></h6></div>
        <div ng-form="paymentForm" autocomplete="off" novalidate>
            <div><asp:Label ID="lblMessage" runat="server"></asp:Label></div>
            <div class="row vctr-field">
                <div class="form-group required">
                    <div class="col-xs-12 col-md-6 ">
                        <label>First Name:</label>
                        <asp:TextBox ID="txtFirstName" required formnovalidate="formnovalidate" ng-model="vm.firstName" runat="server" class="form-control" type="text" maxlength="50" minlength="2" ng-pattern="regName"></asp:TextBox>
                        <div class="vctr-form-control-error help-block" ng-messages="paymentForm.<%= txtFirstName.UniqueID %>.$error" role="alert" ng-show="paymentForm.<%= txtFirstName.UniqueID %>.$invalid && paymentForm.<%= txtFirstName.UniqueID %>.$touched">
                            <div ng-message="required">Please enter your first name.</div>
                            <div ng-message-exp="['minlength', 'maxlength', 'pattern']">Please enter a valid first name</div>
                        </div>
                    </div>
                </div>

                <div class="form-group required">
                    <div class="col-xs-12 col-md-6">
                        <label>Last Name:</label>
                            <asp:TextBox ID="txtLastName" runat="server" class="form-control" name="lastName" maxlength="50" minlength="2" ng-pattern="regName" ng-model="vm.lastName" required></asp:TextBox>
                            <div class="vctr-form-control-error help-block" ng-messages="paymentForm.<%= txtLastName.UniqueID %>.$error" ng-show="paymentForm.<%= txtLastName.UniqueID %>.$invalid && paymentForm.<%= txtLastName.UniqueID %>.$touched" role="alert">
                                <div ng-message="required">Please enter your last name.</div>
                                <div ng-message-exp="['minlength', 'maxlength', 'pattern']">Please enter a valid last name</div>
                            </div>
                    </div>
                </div>
            </div>

            <div class="row vctr-field">
                <div class="form-group required">
                    <div class="col-xs-12 col-md-6 ">
                        <label>Phone:</label>
                        <asp:TextBox ID="txtPhone" type="tel" runat="server" minlength="5" maxlength="14" class="form-control" ng-pattern="phoneRegex" ng-model="vm.phone" required></asp:TextBox>
                        <div class="vctr-form-control-error help-block" ng-messages="paymentForm.<%= txtPhone.UniqueID %>.$error" ng-show="paymentForm.<%= txtPhone.UniqueID %>.$invalid && paymentForm.<%= txtPhone.UniqueID %>.$touched" role="alert">
                            <div ng-message="required">Please enter your phone.</div>
                            <div ng-message-exp="['minlength', 'maxlength', 'pattern']">Please enter a valid phone</div>
                        </div>
                    </div>
                </div>

                <div class="form-group required">
                    <div class="col-xs-12 col-md-6">
                        <label>Reference type:</label>
                        <asp:DropDownList ID="ddlRefType" runat="server" class="form-control" ng-model="vm.referenceType" required ng-change ="onReferenceTypeChange()">
                            <asp:ListItem Value="CNO" Selected="True">Customer Number</asp:ListItem>
                            <asp:ListItem Value="SRO">Service Number</asp:ListItem>
                            <asp:ListItem Value="WBS">Project Number</asp:ListItem>
                        </asp:DropDownList>
                        <div class="vctr-form-control-error help-block" ng-messages="paymentForm.<%= ddlRefType.UniqueID %>.$error" ng-show="paymentForm.<%= ddlRefType.UniqueID %>.$invalid && paymentForm.<%= ddlRefType.UniqueID %>.$touched" role="alert">
                            <div ng-message="required">Please select your reference type.</div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row vctr-field">
                <div class="form-group required">
                    <div class="col-xs-12 col-md-6 ">
                        <label>Reference number:</label>
                        <asp:TextBox ID="txtRefNumber" runat="server" minlength="9" maxlength="20" class="form-control" ng-model="vm.referenceNumber" required ng-pattern="regRef"></asp:TextBox>
                        <div class="vctr-form-control-error help-block" ng-messages="paymentForm.<%= txtRefNumber.UniqueID %>.$error" ng-show="paymentForm.<%= txtRefNumber.UniqueID %>.$invalid && paymentForm.<%= txtRefNumber.UniqueID %>.$touched" role="alert">
                            <div ng-message="required">Please enter your reference number.</div>
                            <div ng-message-exp="['minlength', 'maxlength', 'pattern']">Please enter a valid reference number.</div>
                        </div>
                    </div>
                </div>

                <div class="form-group required">
                    <div class="col-xs-12 col-md-6">
                        <label>Amount payable:</label>
                        <asp:TextBox ID="txtAmount" runat="server" class="form-control" type="text" maxlength="9" ng-model="vm.amountPayable" ng-pattern="regAmount" required placeholder="Enter Amount in NZD e.g. 1000.00"></asp:TextBox>
                        <div class="vctr-form-control-error help-block help-block" ng-messages="paymentForm.<%= txtAmount.UniqueID %>.$error" ng-show="paymentForm.<%= txtAmount.UniqueID %>.$invalid && paymentForm.<%= txtAmount.UniqueID %>.$touched" role="alert">
                            <div ng-message="required">Please enter the amount.</div>
                            <div ng-message="pattern">Please enter a valid amount in e.g. 1000.00 format.</div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div>
                    <div class="col-xs-12 vctr-payment-message"><%=Description %></div>
                </div>

                <div class="form-group">
                    <div class="col-xs-12">
                        <input id="chkAccept" type="hidden" value="{{vm.acceptFee}}" runat="server" />
                        <input name="acceptFee" type="checkbox" value="1" ng-model="vm.acceptFee" required class="accept-fee"/>
                        <label>I accept the convenience fee</label>
                        <div class="vctr-form-control-error" ng-messages="paymentForm.acceptFee.$error" ng-show="!vm.acceptFee && paymentForm.acceptFee.$touched" role="alert">
                            <div ng-message="required">Please confirm</div>
                        </div>
                    </div>
                </div>


                <div>
                    <div class="col-xs-12" id="enquirySubmit">
                        <input id="" type="button" value="Submit" ng-click="submit()" class="btn"/>
                        <asp:Button ID="btnSubmit" ClientIDMode="Static" runat="server"  Text="Submit" OnClick="btnSubmit_Click" class="btn" style="display:none"/>
                    </div>
                </div>
            </div>

        </div>

    </div>

</asp:Panel>
<asp:Panel ID="pnlPaymentExpressControlLoad" runat="server">
    <div id="payment-response-control">
        <div><asp:Label ID="lblResponse" runat="server"></asp:Label></div>
    </div>
</asp:Panel>
<!-- end of Payment Express -->