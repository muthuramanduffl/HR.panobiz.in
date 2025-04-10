<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="add-recommender-request-approver.aspx.cs" Inherits="add_recommender_request_approver" ValidateRequest="false" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>



    <!-- MULITISELECT -->
    <link href="assets/css/multiselect-checkbox.css" />

    <!-- <div class="main-panel"> -->

    <div class="content">
        <div class="page-inner">
            <div class="d-flex d-lg-none justify-content-center pg-tit-cnt">
                <div class="heading-after"></div>
                <h3>HR Panobiz</h3>
                <div class="heading-after"></div>
            </div>
            <div class="row mx-0 col-lg-12">
                <ul class="breadcrumbs ml-0 pl-0 border-0">
                    <li class="nav-home">
                        <a href="View-Designation.aspx">View Designation
                        </a>
                    </li>
                    <li class="separator px-1">
                        <i class="fas fa-angle-double-right"></i>
                    </li>
                    <li class="nav-item">
                        <a>Add</a>
                    </li>
                </ul>
                <a href="view-recommender-request-approver.aspx" class="btn btn-default py-1 btn-sm mb-3 ml-auto"><i class="icon-list" style="position: relative; top: 2px; left: -5px;"></i>View Recommender Request Approver</a>
            </div>
            <div class="seat-book-title">
                <h3>
                    <asp:Label ID="lbldisplaytext" runat="server" Text=""></asp:Label>
                    <ul class="breadcrumbs py-0">
                        <li class="nav-home">
                            <a href="dashboard.aspx">
                                <i class="flaticon-home"></i>
                            </a>
                        </li>
                    </ul>
                </h3>
            </div>
            <div class="col-lg-13" style="float: none; width: 99%;">
                <hr style="border-top: 1px dashed #c8c9cc;">
            </div>
            <asp:HiddenField ID="hdnID" runat="server" />
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="seat-book-wrap bg-img p-sm-4 py-3 applyNow">
                            <div class="seat-book-form mt-3 mx-3">
                                <div class="row">

                                    <div class="col-lg-3 col-md-6 mb-4">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <label>Client</label>
                                                <asp:DropDownList CssClass="form-control h-80px" AppendDataBoundItems="true" AutoPostBack="true" ID="ddlcompany" runat="server" OnSelectedIndexChanged="ddlcompany_SelectedIndexChanged" EnableViewState="true">
                                                    <asp:ListItem Value="">Select client</asp:ListItem>
                                                </asp:DropDownList>
                                                <span class="error">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" InitialValue="" runat="server" ErrorMessage="Select client" Display="Dynamic"
                                                        ControlToValidate="ddlcompany" ValidationGroup="val"></asp:RequiredFieldValidator>
                                                </span>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlcompany" EventName="SelectedIndexChanged" />
                                                 <asp:AsyncPostBackTrigger ControlID="ddlrequester" EventName="SelectedIndexChanged" />
                                                 <asp:AsyncPostBackTrigger ControlID="ddlemp" EventName="SelectedIndexChanged" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-lg-3 col-md-6 mb-4">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <label>Requester</label>
                                                <asp:DropDownList CssClass="form-control h-80px" AppendDataBoundItems="true" ID="ddlrequester" runat="server">
                                                    <asp:ListItem Value="">Select requester</asp:ListItem>
                                                </asp:DropDownList>
                                                <span class="error">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" InitialValue="" runat="server" ErrorMessage="Select requester" Display="Dynamic"
                                                        ControlToValidate="ddlrequester" ValidationGroup="val"></asp:RequiredFieldValidator>
                                                </span>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlcompany" EventName="SelectedIndexChanged" />
                                               
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-lg-3 col-md-6 mb-4">
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                                <label>Emp ID</label>
                                                <asp:DropDownList CssClass="form-control h-80px" AppendDataBoundItems="true" ID="ddlemp" runat="server">
                                                    <asp:ListItem Value="">Select Emp ID</asp:ListItem>
                                                </asp:DropDownList>
                                                <span class="error">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator112" InitialValue="" runat="server" ErrorMessage="Select Emp ID" Display="Dynamic"
                                                        ControlToValidate="ddlemp" ValidationGroup="val"></asp:RequiredFieldValidator>
                                                </span>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlcompany" EventName="SelectedIndexChanged" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-lg-3 col-md-6 mb-4">
                                        <label>Moduler</label>
                                        <asp:DropDownList CssClass="form-control h-80px" AppendDataBoundItems="true" ID="ddlModuler" runat="server">
                                            <asp:ListItem Value="">Select moduler</asp:ListItem>
                                            <asp:ListItem Value="Man Power">Man Power</asp:ListItem>
                                            <asp:ListItem Value="Job Officer">Job Officer</asp:ListItem>
                                        </asp:DropDownList>
                                        <span class="error">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" InitialValue="" runat="server" ErrorMessage="Select moduler" Display="Dynamic"
                                                ControlToValidate="ddlModuler" ValidationGroup="val"></asp:RequiredFieldValidator>
                                        </span>
                                    </div>
                                </div>

                                <div class="col-lg-3 col-md-6 mb-4">
                                  
                                    <asp:CheckBox ID="chkcheckbox" Checked="true" class="form-check-input d-block mx-auto" runat="server" />
                                      <label>Status</label>
                                </div>
                                <asp:Label ID="lblmsg" ForeColor="Green" runat="server"></asp:Label>
                            </div>

                            <div class="card-footer">
                                <div class="d-flex justify-content-center">
                                    <div class="my-2">
                                        <div class="d-flex justify-content-end">
                                            <asp:Button ID="btnSubmit" runat="server"
                                                CssClass="btn btn-success py-1 px-2" Text="Save" ValidationGroup="val"
                                                CausesValidation="true" OnClick="btnSubmit_Click1" />
                                            <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-outline-danger py-1 px-2 ml-2" Text="Cancel" ClientIDMode="Static" OnClick="btnCancel_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <div id="thankyou" class="overlay-popup-bg" runat="server" clientidmode="static">
        <div class="popup">
            <a class="close" id="closethankyou">&times;</a>
            <div class="content font-weight-bold my-30">
                <h3>
                    <asp:Label ID="lblsucessmsg" runat="server" Text=""></asp:Label></h3>
            </div>
        </div>
    </div>


    <!-- </div> -->
    <!--   Core JS Files   -->
    <script src="assets/js/core/jquery.3.2.1.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js"></script>
    <script src="assets/js/core/popper.min.js"></script>
    <script src="assets/js/core/bootstrap.min.js"></script>
    <!-- jQuery UI -->
    <script src="assets/js/plugin/jquery-ui-1.12.1.custom/jquery-ui.min.js"></script>
    <script src="assets/js/plugin/jquery-ui-touch-punch/jquery.ui.touch-punch.min.js"></script>

    <!-- jQuery Scrollbar -->
    <script src="assets/js/plugin/jquery-scrollbar/jquery.scrollbar.min.js"></script>
    <!-- Atlantis JS -->
    <script src="assets/js/atlantis.min.js"></script>
    <!-- Atlantis DEMO methods, don't include it in your project! -->
    <script src="assets/js/setting-demo2.js"></script>
    <!-- <script src="https://code.jquery.com/jquery-1.12.4.js"></script> -->
    <!--	<script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.11.2/jquery-ui.min.js"></script>-->

    <script src="assets/js/plugin/datatables/datatables.min.js"></script>
    <!-- <script src="https://code.jquery.com/jquery-1.12.4.js"></script> -->
    <!-- <script src="assets/js/jquery-1.8.2.min.js"></script> -->

    <script src="assets/js/tinymce/js/tinymce/tinymce.min.js" type='text/javascript'></script>

    <!-- <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script> -->


    <script>

        function validateName(e) {

            var keyCode = e.keyCode || e.which;
            var emailReg = /^[a-zA-Z\s.-]+$/;
            var isValid = emailReg.test(String.fromCharCode(keyCode));
            return isValid;
        }
        $(function () {

            $('[id^=txtdesignation]').keypress(validateName);
            $('#btnSubmit').on('click', function (e) {
                $("#btnSubmit").val("Submit");
                return true;
            });
        });
    </script>



    <script>
        //file upload
        $(".custom-file-input").on("change", function () {
            var fileName = $(this).val().split("\\").pop();
            $(this).siblings(".custom-file-label").addClass("selected").html(fileName);
        });


        $(document).ready(function () {
            $(".successPopup").click(function () {
                $("#thankyou").css("display", "block");
            });
            $("#closethankyou").click(function () {
                $("#thankyou").css("display", "none");

                // Get Query String ID
                const urlParams = new URLSearchParams(window.location.search);
                const id = urlParams.get("ID");

                
                if (id) {
                    window.location.href = "view-recommender-request-approver.aspx";
                }
            });
        });

    </script>
    <script>
        function validatePage() {
            var flag = window.Page_ClientValidate('val');
            return flag;
        }
    </script>
    <script>


        $(document).ready(function () {
            //$('[data-toggle = "tooltip"]').tooltip();
            tinymce.init({
                selector: '#txtcontent',
                height: 500,
                menubar: false,
                themes: 'modern'

            });
        });
    </script>
</asp:Content>
