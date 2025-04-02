<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="loginer" %>
    <!DOCTYPE html>
    <html lang="en">

    <head>
        <meta http-equiv="X-UA-Compatible" content="IE=edge" />
        <title>Panobiz Team Management System</title>
        <meta content='width=device-width, initial-scale=1.0, shrink-to-fit=no' name='viewport' />
        <link rel="icon" href="assets/img/fav-icon.png" type="image/x-icon" />

        <!-- Fonts and icons -->
        <script src="assets/js/plugin/webfont/webfont.min.js"></script>
        <script>
            WebFont.load({
                google: { "families": ["Lato:300,400,700,900"] },
                custom: { "families": ["Flaticon", "Font Awesome 5 Solid", "Font Awesome 5 Regular", "Font Awesome 5 Brands", "simple-line-icons"], urls: ['assets/css/fonts.min.css'] },
                active: function () {
                    sessionStorage.fonts = true;
                }
            });
        </script>

        <!-- CSS Files -->
        <link rel="stylesheet" href="assets/css/bootstrap.min.css">
        <link rel="stylesheet" href="assets/css/atlantis.min.css">

        <!-- CSS Just for demo purpose, don't include it in your project -->
        <link rel="stylesheet" href="assets/css/demo.css">
        <link rel="stylesheet" href="assets/css/log-reg.css">
    </head>


    <body class="align">

        <div class="grid align__item">
            <form id="form1" runat="server">
                <asp:ScriptManager ID="ScriptManager1" runat="server" />
                <div class="register">

                    <img src="assets/img/logo.png">

                    <div class="my-3 title" id="div_logintitle" runat="server">
                        <p class="mb-0">Login</p>
                        <hr style="border-color: #cccccc38;">
                    </div>

                    <div class="my-3 title" id="div_resettitle" runat="server">
                        <p class="mb-0">Reset MPIN </p>
                        <hr style="border-color: #cccccc38;">
                    </div>

                    <div class="my-3 title" id="div_pinsectiontitle" runat="server">
                        <p class="mb-0">Set your MPIN </p>
                        <hr style="border-color: #cccccc38;">
                    </div>

                    <div class="col-lg-12 login-form px-0 px-sm-3" id="div_login" runat="server">
                        <h4>Enter your Employee ID & MPIN to Log in</h4>
                        <div class="form-group px-0 pb-0">
                            <div class="floating-label">
                                <label>Employee ID</label>
                                <%-- <input class="floating-input text-capitalize" type="text" placeholder=" ">--%>

                                    <asp:TextBox ID="txtEmpID" MaxLength="15" runat="server"
                                        CssClass="floating-input text-capitalize" placeholder=" "
                                        onkeypress="return validate(event)"></asp:TextBox>

                            </div>
                            <span class="error">
                                <asp:Label ID="lblempexist" runat="server" Text="" ForeColor="Red" Font-Size="Small">
                                </asp:Label>
                                <span style="visibility: hidden" id="spanexist">
                                    <p id="p" style="color:blue;font-size: 14px;cursor:pointer;">Click here.</p>
                                </span>


                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtEmpID"
                                    runat="server" ErrorMessage="Enter Employee ID" ValidationGroup="val">
                                </asp:RequiredFieldValidator>
                            </span>
                        </div>
                        <div class="form-group passcode-section-field px-0 pb-0">
                            <label class="col-4 px-0">Enter MPIN </br>
                                <p style="font-size: 12px; font-style: italic;">(Enter only digits)</p>
                            </label>
                            <div class="digit-group col-8 px-0 text-right" data-group-name="digits" autocomplete="off">
                                <asp:TextBox ID="txt1" runat="server" onkeypress="return validateNumber(event)"
                                    onkeyup="return validateempty(this.id,'txt2')" autocomplete="off" MaxLength="1">
                                </asp:TextBox>
                                <asp:TextBox ID="txt2" runat="server" onkeypress="return validateNumber(event)"
                                    onkeyup="return validateempty(this.id,'txt3')" autocomplete="off" MaxLength="1">
                                </asp:TextBox>
                                <asp:TextBox ID="txt3" runat="server" onkeypress="return validateNumber(event)"
                                    onkeyup="return validateempty(this.id,'txt4')" autocomplete="off" MaxLength="1">
                                </asp:TextBox>
                                <asp:TextBox ID="txt4" runat="server" onkeypress="return validateNumber(event)"
                                    onkeyup="return validateempty(this.id,'txt4')" autocomplete="off" MaxLength="1">
                                </asp:TextBox>
                                <%-- <input type="text" id="digit-1" name="digit-1" data-next="digit-2" />
                                <input type="text" id="digit-2" name="digit-2" data-next="digit-3"
                                    data-previous="digit-1" />
                                <input type="text" id="digit-3" name="digit-3" data-next="digit-4"
                                    data-previous="digit-2" />
                                <input type="text" id="digit-4" name="digit-4" data-previous="digit-3" />--%>
                            </div>
                        </div>
                        <span class="error">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txt1"
                                runat="server" ErrorMessage="Enter MPIN" ValidationGroup="val">
                            </asp:RequiredFieldValidator>
                        </span>
                        <div class="form-group pt-0 col-8 text-right px-0 ml-auto">
                            <%-- <input type="button" class="resend-otp reset-mpin mx-0 w-100 text-right px-0"
                                value="Forgot MPIN ? Reset MPIN">--%>
                                <asp:Button ID="Button1" runat="server" CssClass="resend-otp mx-0 w-100 text-right px-0"
                                    Text="Forgot MPIN ? Reset Here" OnClick="Button1_Click"
                                    OnClientClick="return validateForm();" />

                        </div>

                        <div class="form-group text-center mt-3">
                            <%-- <a href="dashboard.html"><input type="button" class="btn btn-dark login-submit"
                                    value="Submit"></a>--%>
                                <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-dark login-submit"
                                    Text="Submit" OnClick="btnLogin_Click" ValidationGroup="val" />
                        </div>
                        <div class="text-center" style="font-size: 12px;">
                            <asp:Label ID="lblerr" runat="server" Text="" ForeColor="Red"></asp:Label>
                        </div>

                    </div>



                    <div class="col-lg-12 px-sm-3 px-0" id="div_reset" runat="server">
                        <h4 class="login-tit">Enter your Employee ID to Reset MPIN</h4>
                        <div class="form-group px-0">
                            <div class="floating-label">
                                <label>Employee ID</label>
                                <%-- <input class="floating-input text-capitalize" type="text" placeholder=" ">--%>

                                    <asp:TextBox ID="txtForgotEmpID" MaxLength="15"
                                        CssClass="floating-input text-capitalize" runat="server"
                                        onkeypress="return validate(event)"></asp:TextBox>

                            </div>
                            <span class="error">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="Fval"
                                    ControlToValidate="txtForgotEmpID" runat="server" ErrorMessage="Enter Employee ID">
                                </asp:RequiredFieldValidator>
                            </span>
                        </div>
                        <div class="form-group text-center mt-3">
                            <%-- <input type="button" class="btn btn-dark reset-submit" value="Submit">--%>
                                <asp:Button ID="btnreset" runat="server" CssClass="btn btn-dark reset-submit"
                                    Text="Submit" OnClick="btnreset_Click" ValidationGroup="Fval" />
                        </div>
                        <div class="text-center" style="font-size: 12px;">
                            <asp:Label ID="lblFerr" runat="server" Text="" ForeColor="Red" Font-Size="Small">
                            </asp:Label>
                        </div>

                    </div>

                    <asp:HiddenField ID="hdnEmpID" runat="server" />
                    <asp:HiddenField ID="hdnmobileno" runat="server" />


                    <div id="div_otp" runat="server">
                        <h4 class="login-tit">
                            <asp:Label ID="lblotpmsg" runat="server"
                                Text="OTP has been sent to your registered phone number " Visible="false"></asp:Label>
                            <%-- <input type="text" value="xxxxxxx647" class="border-0 font-weight-bold"
                                style="width: 93px;" readonly>--%>
                                <asp:TextBox ID="txtmobile" CssClass="border-0 font-weight-bold" runat="server"
                                    Style="width: 115px;" ReadOnly="true"></asp:TextBox>
                        </h4>
                        <div class="form-group col-lg-5 col-6 mx-auto pb-0">
                            <div class="floating-label">
                                <label class="w-100 text-center">Enter OTP</label>
                                <%-- <input class="floating-input" type="text" placeholder=" ">--%>
                                    <asp:TextBox ID="txtOTP" CssClass="floating-input" runat="server"
                                        onkeypress="return validateNumber(event)" MaxLength="4"></asp:TextBox>
                            </div>
                        </div>
                        <span class="error">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtOTP"
                                runat="server" ErrorMessage="Enter OTP" ValidationGroup="OTPval">
                            </asp:RequiredFieldValidator>
                        </span>
                        <div class="form-group pt-0">
                            <%--<input type="button" class="resend-otp" value="Resend OTP">--%>
                                <asp:Button ID="btnResendOTP" runat="server" CssClass="resend-otp" Text="Resend OTP"
                                    OnClick="btnResendOTP_Click" />
                        </div>
                        <div class="form-group">
                            <%-- <input type="button" class="btn btn-dark otp-submit" value="Submit">--%>
                                <asp:Button ID="btnchkOTP" runat="server"
                                    CssClass="btn btn-dark otp-submit otpSubmit-btn"
                                    style="background-color: black !important;" Text="Submit" OnClick="btnchkOTP_Click"
                                    ValidationGroup="OTPval" />
                        </div>
                        <div class="text-center" style="font-size: 12px;">
                            <asp:Label ID="lblotp" runat="server" Text="" ForeColor="Red" Font-Size="Small"></asp:Label>
                            <!-- <asp:Label ID="otpdisplay" runat="server" Text=""></asp:Label></div> -->

                        </div>
                    </div>
                    <!-- <p class="thank-regi">Thanks for registering with us!</p> -->

                    <div id="div_pinsection" runat="server">
                        <!-- <h4 class="login-tit">Set your MPIN</h4> -->
                        <div class="form-group passcode-section-field px-0 pb-0">
                            <label class="col-5 px-0">New MPIN </br>
                                <p style="font-size: 12px; font-style: italic;">(Enter only digits)</p>
                            </label>
                            <div class="digit-group1 col-7 px-0" data-group-name="digits1" autocomplete="off">
                                <%-- <input type="text" id="digit-1" name="digit-1" data-next="digit-2" />
                                <input type="text" id="digit-2" name="digit-2" data-next="digit-3"
                                    data-previous="digit-1" />
                                <input type="text" id="digit-3" name="digit-3" data-next="digit-4"
                                    data-previous="digit-2" />
                                <input type="text" id="digit-4" name="digit-4" data-previous="digit-3" />--%>
                                <asp:TextBox ID="Ntxt1" runat="server" onkeypress="return validateNumber(event)"
                                    onkeyup="return validateempty(this.id,'Ntxt2')" autocomplete="off" MaxLength="1">
                                </asp:TextBox>
                                <asp:TextBox ID="Ntxt2" runat="server" onkeypress="return validateNumber(event)"
                                    onkeyup="return validateempty(this.id,'Ntxt3')" autocomplete="off" MaxLength="1">
                                </asp:TextBox>
                                <asp:TextBox ID="Ntxt3" runat="server" onkeypress="return validateNumber(event)"
                                    onkeyup="return validateempty(this.id,'Ntxt4')" autocomplete="off" MaxLength="1">
                                </asp:TextBox>
                                <asp:TextBox ID="Ntxt4" runat="server" onkeypress="return validateNumber(event)"
                                    onkeyup="return validateempty(this.id,'Ntxt4')" autocomplete="off" MaxLength="1">
                                </asp:TextBox>
                            </div>
                        </div>
                        <span class="error">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="Ntxt1"
                                runat="server" ErrorMessage="Enter New MPIN" ValidationGroup="val1">
                            </asp:RequiredFieldValidator>
                        </span>
                        <div class="form-group passcode-section-field px-0 pb-0">
                            <label class="col-5 px-0">Confirm MPIN </br>
                                <p style="font-size: 12px; font-style: italic;">(Enter only digits)</p>
                            </label>
                            <div class="digit-group2 col-7 px-0" data-group-name="digits2" autocomplete="off">
                                <%--<input type="text" id="digit-11" name="digit-11" data-next="digit-12" />
                                <input type="text" id="digit-12" name="digit-12" data-next="digit-13"
                                    data-previous="digit-11" />
                                <input type="text" id="digit-13" name="digit-13" data-next="digit-14"
                                    data-previous="digit-12" />
                                <input type="text" id="digit-14" name="digit-14" data-previous="digit-13" />--%>
                                <asp:TextBox ID="Ctxt1" runat="server" onkeypress="return validateNumber(event)"
                                    onkeyup="return validateempty(this.id,'Ctxt2')" autocomplete="off" MaxLength="1">
                                </asp:TextBox>
                                <asp:TextBox ID="Ctxt2" runat="server" onkeypress="return validateNumber(event)"
                                    onkeyup="return validateempty(this.id,'Ctxt3')" autocomplete="off" MaxLength="1">
                                </asp:TextBox>
                                <asp:TextBox ID="Ctxt3" runat="server" onkeypress="return validateNumber(event)"
                                    onkeyup="return validateempty(this.id,'Ctxt4')" autocomplete="off" MaxLength="1">
                                </asp:TextBox>
                                <asp:TextBox ID="Ctxt4" runat="server" onkeypress="return validateNumber(event)"
                                    onkeyup="return validateempty(this.id,'Ctxt4')" autocomplete="off" MaxLength="1">
                                </asp:TextBox>
                            </div>
                        </div>
                        <span class="error">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="Ctxt1"
                                runat="server" ErrorMessage="Enter Confirm MPIN" ValidationGroup="val1">
                            </asp:RequiredFieldValidator>
                        </span>
                        <div class="form-group">
                            <%--<input type="button" class="btn btn-dark passcode-submit" value="Submit">--%>
                                <asp:Button ID="btnsubmit" runat="server" CssClass="btn btn-dark passcode-submit"
                                    Text="Submit" OnClick="btnsubmit_Click" ValidationGroup="val1"
                                    OnClientClick="return validateForm();" />
                        </div>
                        <div class="text-center" style="font-size: 12px;">
                            <asp:Label ID="lblpinerr" runat="server" Text="" ForeColor="Red" Font-Size="Small">
                            </asp:Label>
                        </div>

                    </div>
                    <%-- <div class="thank-passcode" ID="div_reg" runat="server">Your MPIN has been reset.
                </div>--%>
        </div>
        <div id="empdetails" class="overlay-popup-bg emp" style="display: none" runat="server">
            <div class="popup">

                <div class="close" id="empformclose"> X
                </div>
                <div class="content font-weight-bold my-30">
                    <div class="swal2-icon swal2-success swal2-animate-success-icon" style="display: flex;">
                        <div class="swal2-success-circular-line-left" style="background-color: rgb(255, 255, 255);">
                        </div>
                        <span class="swal2-success-line-tip"></span><span class="swal2-success-line-long"></span>
                        <div class="swal2-success-ring"></div>
                        <div class="swal2-success-fix" style="background-color: rgb(255, 255, 255);"></div>
                        <div class="swal2-success-circular-line-right" style="background-color: rgb(255, 255, 255);">
                        </div>
                    </div>
                    <div class="form-group px-0 pb-0">
                        <div class="floating-label">
                            <label>Name:</label>
                            <asp:TextBox ID="txtname" ClientIDMode="Static" CssClass="floating-input text-capitalize"
                                runat="server"></asp:TextBox>
                        </div>
                        <span class="error">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ValidationGroup="val2"
                                ForeColor="Red" ControlToValidate="txtname" runat="server"
                                ErrorMessage="Enter Employee Name"></asp:RequiredFieldValidator>
                        </span>
                    </div>
                    <div class="form-group px-0 pb-0">
                        <div class="floating-label">
                            <label>Employee ID:</label>
                            <asp:TextBox ID="txtempid1" ClientIDMode="Static" MaxLength="15" runat="server"
                                CssClass="floating-input text-capitalize" placeholder=" "></asp:TextBox>
                        </div>

                        <span class="error">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ValidationGroup="val2"
                                ForeColor="Red" ControlToValidate="txtempid1" runat="server"
                                ErrorMessage="Enter Employee ID"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationGroup="val2"
                                ValidationExpression="^[a-zA-Z0-9]+$" runat="server" ControlToValidate="txtempid1"
                                ErrorMessage="Enter Valid Employee ID "></asp:RegularExpressionValidator>
                        </span>
                    </div>
                    <div class="form-group px-0 pb-0">
                        <div class="floating-label">
                            <label>Phone Number:</label>
                            <asp:TextBox ID="txtphoneno" ClientIDMode="Static" MaxLength="10"
                                CssClass="floating-input text-capitalize" runat="server"></asp:TextBox>

                        </div>
                        <span class="error">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ValidationGroup="val2"
                                ForeColor="Red" ControlToValidate="txtphoneno" runat="server"
                                ErrorMessage="Enter Employee Phone Number"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ValidationGroup="val2"
                                ForeColor="Red" ValidationExpression="^[0-9]+$" runat="server"
                                ControlToValidate="txtphoneno" ErrorMessage="Enter Valid Phone No ">
                            </asp:RegularExpressionValidator>
                        </span>
                    </div>
                    <div class="form-group px-0 pb-0">
                        <div class="floating-label">
                            <label>Location:</label>
                            <asp:TextBox ID="txtloction" ClientIDMode="Static" CssClass="floating-input text-capitalize"
                                runat="server"></asp:TextBox>

                        </div>
                        <span class="error">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ValidationGroup="val2"
                                ForeColor="Red" ControlToValidate="txtloction" runat="server"
                                ErrorMessage="Enter Employee Location"></asp:RequiredFieldValidator>
                        </span>
                    </div>
                    <div class="form-group px-0 text-center">
                        <asp:Button ID="btnempsubmit1" runat="server" OnClick="btnempsubmit1_Click"
                            ValidationGroup="val2" CssClass="btn btn-dark" Text="submit" />
                    </div>
                </div>
            </div>



        </div>
        </form>
        </div>











        <div id="thankyoupopup" class="overlay-popup-bg " style="display:block" runat="server">
            <div class="popup">
                <a class="close" id="closethankyou">x</a>
                <div class="content font-weight-bold my-30">
                    <div class="swal2-icon swal2-success swal2-animate-success-icon" style="display: flex;">
                        <div class="swal2-success-circular-line-left" style="background-color: rgb(255, 255, 255);">
                        </div>
                        <span class="swal2-success-line-tip"></span><span class="swal2-success-line-long"></span>
                        <div class="swal2-success-ring"></div>
                        <div class="swal2-success-fix" style="background-color: rgb(255, 255, 255);"></div>
                        <div class="swal2-success-circular-line-right" style="background-color: rgb(255, 255, 255);">
                        </div>
                    </div>

                    <p>Thank you for sharing your details.</p>

                </div>
            </div>
        </div>

        <div id="div_reg" class="overlay-popup-bg" runat="server">
            <div class="popup col-xl-4 col-lg-5 col-sm-6 col-11 mx-auto">
                <a class="close" id="close">&times;</a>
                <div class="content font-weight-bold my-30">
                    <h3>Your MPIN has been reset.</h3>
                </div>
            </div>
        </div>

        <!--   Core JS Files   -->
        <script src="assets/js/core/jquery.3.2.1.min.js"></script>
        <script src="assets/js/core/popper.min.js"></script>
        <script src="assets/js/core/bootstrap.min.js"></script>

        <!-- jQuery UI -->
        <script src="assets/js/plugin/jquery-ui-1.12.1.custom/jquery-ui.min.js"></script>
        <script src="assets/js/plugin/jquery-ui-touch-punch/jquery.ui.touch-punch.min.js"></script>

        <!-- jQuery Scrollbar -->
        <script src="assets/js/plugin/jquery-scrollbar/jquery.scrollbar.min.js"></script>


        <!-- Chart JS -->
        <script src="assets/js/plugin/chart.js/chart.min.js"></script>

        <!-- jQuery Sparkline -->
        <script src="assets/js/plugin/jquery.sparkline/jquery.sparkline.min.js"></script>

        <!-- Chart Circle -->
        <script src="assets/js/plugin/chart-circle/circles.min.js"></script>

        <!-- Datatables -->
        <script src="assets/js/plugin/datatables/datatables.min.js"></script>

        <!-- Bootstrap Notify -->
        <script src="assets/js/plugin/bootstrap-notify/bootstrap-notify.min.js"></script>

        <!-- jQuery Vector Maps -->
        <script src="assets/js/plugin/jqvmap/jquery.vmap.min.js"></script>
        <script src="assets/js/plugin/jqvmap/maps/jquery.vmap.world.js"></script>

        <!-- Sweet Alert -->
        <script src="assets/js/plugin/sweetalert/sweetalert.min.js"></script>

        <!-- Atlantis JS -->
        <script>
            $("#p").click(function () {

                $(".emp").css("display", "block");

            });
            $("#closethankyou").click(function () {
                $("#thankyoupopup").css("display", "none");
            });
        </script>
        <script src="assets/js/atlantis.min.js"></script>
        <script>
            $('#txtEmpID').blur(function () {

                var txtEmpID = $('#txtEmpID').val();

                if (txtEmpID != '') {
                    $.ajax({
                        type: "POST",
                        url: "login.aspx/EmpIDExist",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        data: '{stEmpID: "' + $("#<%=txtEmpID.ClientID%>")[0].value + '" }',
                        success: function (data) {
                            if (data.d === "Employee id doesn't exist in our database.please enter the correct ID or check with admin.") {
                                // Display the span block
                                $("#spanexist").css("visibility", "visible");
                            } else {
                                // Hide the span block if it's not the expected error message
                                $("#spanexist").css("visibility", "hidden");
                            }

                            // Update label text
                            $('#lblempexist').text(data.d);
                        },
                        error: (xhr) => {

                            var responseText = jQuery.parseJSON(xhr.responseText);
                            //alert(responseText.Message);
                        }
                    });
                }
            });




            //passcode field
            $('.digit-group').find('input').each(function () {
                $(this).attr('maxlength', 1);
                $(this).on('keyup', function (e) {
                    var parent = $($(this).parent());

                    if (e.keyCode === 8 || e.keyCode === 37) {
                        var prev = parent.find('input#' + $(this).data('previous'));

                        if (prev.length) {
                            $(prev).select();
                        }
                    } else if ((e.keyCode >= 48 && e.keyCode <= 57) || (e.keyCode >= 65 && e.keyCode <= 90) || (e.keyCode >= 96 && e.keyCode <= 105) || e.keyCode === 39) {
                        var next = parent.find('input#' + $(this).data('next'));

                        if (next.length) {
                            $(next).select();
                        } else {
                            if (parent.data('autosubmit')) {
                                parent.submit();
                            }
                        }
                    }
                });
            });
            $('.digit-group1').find('input').each(function () {
                $(this).attr('maxlength', 1);
                $(this).on('keyup', function (e) {
                    var parent = $($(this).parent());

                    if (e.keyCode === 8 || e.keyCode === 37) {
                        var prev = parent.find('input#' + $(this).data('previous'));

                        if (prev.length) {
                            $(prev).select();
                        }
                    } else if ((e.keyCode >= 48 && e.keyCode <= 57) || (e.keyCode >= 65 && e.keyCode <= 90) || (e.keyCode >= 96 && e.keyCode <= 105) || e.keyCode === 39) {
                        var next = parent.find('input#' + $(this).data('next'));

                        if (next.length) {
                            $(next).select();
                        } else {
                            if (parent.data('autosubmit')) {
                                parent.submit();
                            }
                        }
                    }
                });
            });
            $('.digit-group2').find('input').each(function () {
                $(this).attr('maxlength', 1);
                $(this).on('keyup', function (e) {
                    var parent = $($(this).parent());

                    if (e.keyCode === 8 || e.keyCode === 37) {
                        var prev = parent.find('input#' + $(this).data('previous'));

                        if (prev.length) {
                            $(prev).select();
                        }
                    } else if ((e.keyCode >= 48 && e.keyCode <= 57) || (e.keyCode >= 65 && e.keyCode <= 90) || (e.keyCode >= 96 && e.keyCode <= 105) || e.keyCode === 39) {
                        var next = parent.find('input#' + $(this).data('next'));

                        if (next.length) {
                            $(next).select();
                        } else {
                            if (parent.data('autosubmit')) {
                                parent.submit();
                            }
                        }
                    }
                });
            });

            //$(".reset-section").css("display", "none");
            //$(".otp-section").css("display", "none");
            //$(".thank-regi").hide();
            //$(".passcode-section").css("display", "none");
            //$(".thank-passcode").hide();
            //$(document).ready(function () {
            //	$(".reset-mpin").click(function () {
            //		$(".login-form").css("display", "none");
            //		$(".reset-section").css("display", "block");
            //	});
            //	$(".reset-submit").click(function () {
            //		$(".reset-section").css("display", "none");
            //		$(".otp-section").css("display", "block");
            //	});
            //	$(".otp-submit").click(function () {
            //		// $(".thank-regi").show();
            //		// setTimeout(function() { $(".thank-regi").hide(); }, 1000);
            //		$(".otp-section").css("display", "none");
            //		$(".passcode-section").css("display", "block");
            //		// setTimeout(function() { $(".passcode-section").show(); }, 1000);
            //	});
            //	$(".passcode-submit").click(function () {
            //		$(".thank-passcode").show();
            //		$(".passcode-section").css("display", "none");
            //		setTimeout(function(){ window.location.href='dashboard.html'; }, 1000);    
            //	});
            //     });



            function validateempty(id, nxtid) {
                var txtval = document.getElementById(id).value;
                if (txtval == "") {
                    return false;
                }
                else {
                    document.getElementById(nxtid).focus();
                    return true;
                }
            }

            function validate(e) {
                var keyCode = e.keyCode || e.which;

                //Regex to allow only Alphabets Numbers
                var pattern = /^[a-z\d]+$/i;

                //Validating the textBox value against our regex pattern.
                var isValid = pattern.test(String.fromCharCode(keyCode));
                return isValid;
            }

            $(document).ready(function () {
                $(".close").click(function () {
                    $("#div_reg").css("display", "none");
                });
                $("#empformclose").click(function () {
                    location.reload();
                });

            });
        </script>

        <script>
            function validateNumber(event) {
                var key = window.event ? event.keyCode : event.which;

                // Check for other conditions to validate the number
                if (event.keyCode == 8 || event.keyCode == 46
                    || event.keyCode == 37 || event.keyCode == 39) {
                    return true;
                } else if (key < 48 || key > 57) {
                    return false;
                } else {
                    return true;
                }
            }

            function validateForm() {
                // Client-side validation
                var txt1Value = document.getElementById('<%= Ntxt1.ClientID %>').value;
                var txt2Value = document.getElementById('<%= Ntxt2.ClientID %>').value;
                var txt3Value = document.getElementById('<%= Ntxt3.ClientID %>').value;
                var txt4Value = document.getElementById('<%= Ntxt4.ClientID %>').value;

                var ctxt5Value = document.getElementById('<%= Ctxt1.ClientID %>').value;
                var ctxt6Value = document.getElementById('<%= Ctxt2.ClientID %>').value;
                var ctxt7Value = document.getElementById('<%= Ctxt3.ClientID %>').value;
                var ctxt8Value = document.getElementById('<%= Ctxt4.ClientID %>').value;


                if (!isValidNumber(txt1Value) || !isValidNumber(txt2Value) || !isValidNumber(txt3Value) || !isValidNumber(txt4Value) || !isValidNumber(ctxt5Value) || !isValidNumber(ctxt6Value) || !isValidNumber(ctxt7Value) || !isValidNumber(ctxt8Value)) {
                    //alert('Please enter valid numeric values in all textboxes.');
                    //return false; // Prevent form submission
                }

                return true; // Allow form submission
            }

            function isValidNumber(value) {
                return !isNaN(value) && value !== '';
            }
            function validateName(e) {
                var keyCode = e.keyCode || e.which;
                var emailReg = /^[a-zA-Z\s.]+$/;
                var isValid = emailReg.test(String.fromCharCode(keyCode));
                return isValid;
            }
            function validateEmpID(e) {
                var keyCode = e.keyCode || e.which;
                var emailReg = /^[a-zA-Z0-9]+$/;
                var isValid = emailReg.test(String.fromCharCode(keyCode));
                return isValid;
            }

            function validateNumber(event) {
                var key = window.event ? event.keyCode : event.which;

                if (event.keyCode == 8 || event.keyCode == 46
                    || event.keyCode == 37 || event.keyCode == 39) {
                    return true;
                }
                else if (key < 48 || key > 57) {
                    return false;
                }
                else return true;
            }
            $(function () {
                $('[id^=txtempid1]').keypress(validateEmpID);
                $('[id^=txtname]').keypress(validateName);
                $('[id^=txtphoneno]').keypress(validateNumber);
                $('[id^=txtloction]').keypress(validateName);
                $('#btnempsubmit1').on('click', function (e) {
                    $("#btnempsubmit1").val2("Submit");
                    return true;
                });
            });
        </script>
    </body>

    </html>