<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VectorDividendCalculatorControl.ascx.cs" Inherits="CMSApp.CMSWebParts.Vector.VectorDividendCalculatorControl" %>

<!-- start of Dividend Calculator -->
<asp:Panel ID="pnlDividendCalculatorControlPreviewMode" runat="server">

    <div class="dividend-calc col-xs-12 col-sm-8 col-sm-offset-2 col-md-offset-2">
        <div class="dividend-calc-panel">
            <div class="dividend-calc-header">
                    <h2>Dividend calculator</h2>
                    <h5>Enter your details and click "Calculate" to work out your:
                                <br/>Dividends per share
                                    and Total Dividend paid</span>
                    </h5>
            </div>
            <div class="dividend-calc-form-wrapper">
                        <div id="DivCalc" role="form">
                            <div class="form-group">
                                <label class="vct-label" for="paymentdate">Dividend payment date</label>
                                <select id="dividend_menu" name="dividend_menu" class="form-control vct-input">
                                    <option selected="selected" value="">choose option</option>
                                    <%
                                        foreach (var item in DividendList)
                                        {
                                    %>
                                    <option value="<%=item.Amount %>"><%=item.RecordDate.Year %> - <%=item.RecordDate.ToString("dd MMMM") %> - <%=item.Dividend %></option>
                                    <%
                                        }
                                    %>
                                </select>
                            </div>
                            <div class="form-group">
                                <label class="vct-label" for="noofshares">Enter number of shares owned at record date</label>
                                <input type="text" maxlength="11" name="Shares" class="form-control vct-input" id="noOfShares" placeholder="Enter here">
                            </div>
                            <div class="vctr-dividend-button">
                                <button type="button" onclick="isIntegerNumber()" class="vctr-btn btn vctr-button-primary" disabled="disabled">Calculate</button>

                            </div>
                        </div>
                    <div class="dividend-calc-results-wrapper">
                        <div class="dividend-box-wrapper">
                            <div class="dividend-boxes">
                                <div class="dividend-box">
                                    <h4>Dividends per share</h4>
                                    <h1><span class="symbol">$</span><span id="div_per_share"> - </span></h1>
                                </div>
                                <div class="dividend-box">
                                    <h4>Total dividend paid</h4>
                                    <h1><span class="symbol">$</span><span id="dividend_paid"> - </span></h1>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
        </div>
    </div>
</asp:Panel>

<script type="text/javascript">

    function format(expr, decimalPlaces) {
        var decplaces = (decimalPlaces) ? decimalPlaces : 6;
        var str = "" + Math.round(eval(expr) * Math.pow(10, decplaces));
        while (str.length <= decplaces) {
            str = "0" + str;
        }
        var decpoint = str.length - decplaces;
        return str.substring(0, decpoint) + "." + str.substring(decpoint, str.length);
    }

    // main function
    function Calculate() {
        var dividend = $('#DivCalc #dividend_menu').val();
        // dividend per share
        var intercalc = dividend / 100;
        // dividend in £
        //document.DivCalc.div_per_share.value = format(intercalc);
        $('#div_per_share').text(format(intercalc));
        // total dividend paid
        $('#dividend_paid').text(format(intercalc * $('#DivCalc #noOfShares').val(), 2));

        //document.DivCalc.dividend_paid.value = format(intercalc * document.DivCalc.Shares.value);
        if (!$('.dividend-boxes').is(':visible')) {
            $('.dividend-calc-instructions').hide();
            $('.dividend-boxes').show();
        }
    }

    // validation for integer fields
    function isIntegerNumber() {
        var GoodChars = "0123456789";
        var V = $('#DivCalc #noOfShares').val();
        if (V == 0) {
            alert("Please enter the number of shares");
            return false;
        }
        for (var i = 0; i <= V.length - 1; i++) {
            if (GoodChars.indexOf(V.charAt(i)) == -1) {
                alert("Please use numbers only");
                return false;
            }
        }
        Calculate();
    }

    $(function () {
        $calcBtn = $('.dividend-calc .vctr-button-primary');
        $('.dividend-calc #noOfShares').on('keyup', function (e) {
            var elVal = jQuery.trim($(this).val());
            if (elVal.length == 0) {
                $calcBtn.prop('disabled', true);
            } else if (elVal.length > 0 && $calcBtn.prop('disabled')) {
                $calcBtn.prop('disabled', false);
            }
        });
    });

</script>
<!-- end of Dividend Calculator -->
