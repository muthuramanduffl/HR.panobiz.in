using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security;
using System.Web.Services;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.IO;
using System.Net.Mail;
using System.Net;

public partial class loginboth : System.Web.UI.Page
{
    Credential cred = new Credential();
    EmpDetail empdet = new EmpDetail();
    private static string _numbers = "0123456789";
    protected void Page_Load(object sender, EventArgs e)
    {
        thankyoupopup.Style.Add("display", "none");
        div_reset.Attributes.Add("style", "display:none");
        div_resettitle.Attributes.Add("style", "display:none");
        div_otp.Attributes.Add("style", "display:none");
        div_pinsection.Attributes.Add("style", "display:none");
        div_pinsectiontitle.Attributes.Add("style", "display:none");
        div_reg.Attributes.Add("style", "display:none");
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {

        string txt1Value = Ntxt1.Text;
        string txt2Value = Ntxt2.Text;
        string txt3Value = Ntxt3.Text;
        string txt4Value = Ntxt4.Text;
        string ctxt5Value = Ctxt1.Text;
        string ctxt6Value = Ctxt2.Text;
        string ctxt7Value = Ctxt3.Text;
        string ctxt8Value = Ctxt4.Text;

        if (!IsValidNumber(txt1Value) || !IsValidNumber(txt2Value) || !IsValidNumber(txt3Value) || !IsValidNumber(txt4Value) || !IsValidNumber(ctxt5Value) || !IsValidNumber(ctxt6Value) || !IsValidNumber(ctxt7Value) || !IsValidNumber(ctxt8Value))
        {
            string stError = string.Empty;
            string stempID = txtEmpID.Text.Trim();

            string mpin = txt1.Text.Trim() + txt2.Text.Trim() + txt3.Text.Trim() + txt4.Text.Trim();

            if (string.IsNullOrEmpty(stempID))
            {
                stError = "Enter Employee ID";
            }
            else if (string.IsNullOrEmpty(txt1.Text.Trim()) || string.IsNullOrEmpty(txt2.Text.Trim()) || string.IsNullOrEmpty(txt3.Text.Trim()) || string.IsNullOrEmpty(txt4.Text.Trim()))
            {
                stError = "Enter MPIN(4 digits)";
            }

            if (string.IsNullOrEmpty(stError))
            {
                DataSet ds = cred.ViewLoginApprovedStatusBoth(stempID);
                int stloginstatus = 0;
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["loginApproval"].ToString()))
                    {
                        stloginstatus = Convert.ToInt32(ds.Tables[0].Rows[0]["loginApproval"]);
                    }

                    if (stloginstatus == 1)
                    {
                        DataSet dschk = cred.ViewEmployeeByEmpIDBoth(stempID);
                        if (dschk.Tables.Count > 0 && dschk.Tables[0].Rows.Count > 0)
                        {
                            string stmpin = dschk.Tables[0].Rows[0]["MPIN"].ToString();
                            if (string.IsNullOrEmpty(stmpin))
                            {
                                lblerr.Text = "Employee ID is not registered.(PIN is not set)";
                            }
                            else
                            {
                                DataSet ds1 = cred.ViewValidLoginEmployeeBoth(stempID, mpin);//tblempdetails

                                if (ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
                                {
                                    string EmpID = Convert.ToString(ds1.Tables[0].Rows[0]["EmpID"]);
                                    string MPIN = Convert.ToString(ds1.Tables[0].Rows[0]["MPIN"]);
                                    string EmailId = Convert.ToString(ds1.Tables[0].Rows[0]["EmailId"]);
                                    string Name = Convert.ToString(ds1.Tables[0].Rows[0]["EmpFirstName"]);
                                    string candID = Convert.ToString(ds1.Tables[0].Rows[0]["candID"]);
                                    string clientID = Convert.ToString(ds1.Tables[0].Rows[0]["ClientName"]);
                                    string geostatus = Convert.ToString(ds1.Tables[0].Rows[0]["GeofencingStatus"]);
                                    string role = Convert.ToString(ds1.Tables[0].Rows[0]["Role"]);
                                    int ConfirmByEmp = 0;
                                    string ConfirmByAdmin = "";

                                    StringComparer ordCmp = StringComparer.Ordinal;
                                    if (string.Equals(EmpID, stempID, StringComparison.Ordinal) && string.Equals(MPIN, mpin, StringComparison.Ordinal))
                                    {
                                        if (!string.IsNullOrEmpty(ds1.Tables[0].Rows[0]["ConfirmFlag"].ToString()))
                                        {
                                            ConfirmByEmp = Convert.ToInt32(ds1.Tables[0].Rows[0]["ConfirmFlag"]);
                                        }
                                        ConfirmByAdmin = Convert.ToString(ds1.Tables[0].Rows[0]["ConfmApprovedStatus"]);

                                        if (ConfirmByEmp == 1)
                                        {
                                            CreateCookies(Name, EmailId, EmpID, candID);
                                            FormsAuthentication.SetAuthCookie(stempID, true);
                                            if (role == "Executive" || role == "EXECUTIVE")
                                            {
                                                if (clientID == "6" && geostatus == "Yes")
                                                {
                                                    Response.Redirect("punch-in-out1.aspx", true);
                                                }
                                                else
                                                {
                                                    Response.Redirect("punch-in-out.aspx", true);
                                                }
                                            }
                                            else
                                            {
                                                if (clientID == "6" && geostatus == "Yes")
                                                {
                                                    Response.Redirect("/supervisor/punch-in-out1.aspx", true);
                                                }
                                                else
                                                {
                                                    Response.Redirect("/supervisor/punch-in-out.aspx", true);
                                                }
                                            }
                                            lblerr.Text = "";
                                        }
                                        else if (ConfirmByEmp == 0 && ConfirmByAdmin == "Completed")
                                        {
                                            Response.Redirect("edit-profile-details.aspx?EmpId=" + EmpID, true);
                                            lblerr.Text = "";
                                        }
                                        else if (ConfirmByEmp == 0 && ConfirmByAdmin == "InProgress")
                                        {
                                            lblerr.Text = "Your profile confirmation detail updation is in progress, please try again later.";
                                        }
                                        else if (ConfirmByEmp == 0 && ConfirmByAdmin == "")
                                        {
                                            Response.Redirect("edit-profile-details.aspx?EmpId=" + EmpID, true);
                                            lblerr.Text = "";
                                        }
                                    }
                                    else
                                    {
                                        lblerr.Text = "Invalid Employee ID and MPIN";
                                    }
                                }
                                else
                                {
                                    lblerr.Text = "Invalid  MPIN";

                                }
                            }
                        }
                    }
                    else
                    {
                        lblerr.Text = "Login is not approved for this Employee ID";
                    }
                }
                else
                {
                    lblerr.Text = "Invalid Employee ID";
                }
            }
            else
            {
              //  lblerr.Text = stError;
            }
        }
    }

    public void CreateCookies(string strname, string EmailId, string EmpId, string candID)
    {
        if (Request.Browser.Cookies)
        {
            HttpCookie LoginCookie = Request.Cookies["EmpLOGIN"];
            if (LoginCookie == null)
            {
                LoginCookie = new HttpCookie("EmpLOGIN");
            }
            LoginCookie["EmpName"] = strname.Trim();
            LoginCookie["EmpEmailId"] = EmailId.Trim();
            LoginCookie["EmpEmpId"] = EmpId.Trim();
            LoginCookie["EmpCandId"] = candID.Trim();
            Response.Cookies.Add(LoginCookie);

        }
        Session["EmpName"] = strname.Trim();
        Session["EmpEmailId"] = EmailId.Trim();
        Session["EmpEmpId"] = EmpId.Trim();
        Session["EmpCandId"] = candID.Trim();
    }
    protected void Button1_Click(object sender, EventArgs e)  //create New MPIN
    {
        div_reset.Attributes.Add("style", "display:block");
        div_resettitle.Attributes.Add("style", "display:block");
        div_login.Attributes.Add("style", "display:none");
        div_logintitle.Attributes.Add("style", "display:none");
    }
    protected void btnreset_Click(object sender, EventArgs e)
    {
        div_reset.Attributes.Add("style", "display:block");
        div_resettitle.Attributes.Add("style", "display:block");
        string stempID = txtForgotEmpID.Text.Trim();

        if (string.IsNullOrEmpty(stempID))
        {
            lblFerr.Text = "Enter Employee ID";
        }
        else
        {
            DataSet ds1 = cred.ViewLoginApprovedStatus(stempID);
            int stloginstatus = 0;
            if (ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(ds1.Tables[0].Rows[0]["loginApproval"].ToString()))
                {
                    stloginstatus = Convert.ToInt32(ds1.Tables[0].Rows[0]["loginApproval"]);
                }

                if (stloginstatus == 1)
                {
                    DataSet ds = cred.ViewEmployeeByEmpID(stempID);
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        string EmpID = Convert.ToString(ds.Tables[0].Rows[0]["EmpID"]);
                        //Session["EMPID"] = EmpID;
                        hdnEmpID.Value = EmpID;
                        string mobileNo = Convert.ToString(ds.Tables[0].Rows[0]["Mobile"]);
                        string mobileNonew = "+91" + mobileNo;

                        //Session["mobileNo"] = mobileNo;
                        hdnmobileno.Value = mobileNo;
                        string EmailId = Convert.ToString(ds.Tables[0].Rows[0]["EmailId"]);
                        string Name = Convert.ToString(ds.Tables[0].Rows[0]["EmpFirstName"]);
                        lblFerr.Text = "";
                        div_reset.Attributes.Add("style", "display:none");
                        div_resettitle.Attributes.Add("style", "display:none");
                        div_login.Attributes.Add("style", "display:none");
                        div_logintitle.Attributes.Add("style", "display:none");
                        div_otp.Attributes.Add("style", "display:block");
                        string OTPcode = GenerateOTP();
                        otpdisplay.Text = OTPcode;
                        //Session["OTPcode"] = OTPcode;
                        string Message = "Your OTP for HR Portal login is " + OTPcode + " - PANOBIZ";
                        string strTemplateId = "1707167307666833132";
                        cred.UpdateEmpMobileOTP(mobileNo, OTPcode, EmpID, Utility.IndianTime);
                        Utility.SendOTPSMS(mobileNonew, strTemplateId, Message);
                        //SendOTPSMS1("8939742167", OTPcode);

                        txtmobile.Text = maskmobileNo(mobileNo);
                        lblotpmsg.Visible = true;
                    }
                    else
                    {
                        div_login.Attributes.Add("style", "display:none");
                        div_logintitle.Attributes.Add("style", "display:none");
                        //div_otp.Attributes.Add("style", "display:none");
                        lblFerr.Text = "Invalid Employee ID";
                        div_reset.Attributes.Add("style", "display:block");
                        div_resettitle.Attributes.Add("style", "display:block");


                    }
                }
                else
                {
                    lblFerr.Text = "Login is not approved for this Employee ID";
                }
            }
            else
            {
                lblFerr.Text = "Invalid Employee ID";
            }
        }

    }
    private bool IsValidNumber(string value)
    {
        return false;
    }
    public string maskmobileNo(string mobileNo)
    {
        string maskno = string.Empty;
        if (!string.IsNullOrEmpty(mobileNo))
        {
            char[] ch = new char[mobileNo.Length];
            for (int i = 0; i < mobileNo.Length; i++)
            {
                if (i < 7)
                {
                    ch[i] = 'X';
                }
                else
                {
                    ch[i] = mobileNo[i];
                }
            }

            maskno = new string(ch);
        }
        return maskno;
    }

    protected void btnchkOTP_Click(object sender, EventArgs e)// Check the OTP
    {
        lblotpmsg.Visible = false;
        txtmobile.Visible = false;
        lblotp.Text = "";
        div_otp.Attributes.Add("style", "display:block");

        string stOTP = txtOTP.Text.Trim();

        if (string.IsNullOrEmpty(stOTP))
        {
            lblotp.Text = "Enter OTP";
        }
        //else if ((Session["OTPcode"] != null) && (Session["OTPcode"].ToString()== stOTP))
        else if (!string.IsNullOrEmpty(stOTP))
        {
            string dbOTP = string.Empty;
            DataSet ds = cred.GetMobileOTP(hdnmobileno.Value, hdnEmpID.Value);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dbOTP = Convert.ToString(ds.Tables[0].Rows[0]["MobileOTP"]);
            }
            if (dbOTP == stOTP)
            {
                DateTime OtpCrtDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["MobileOTPcreateddatetime"]);
                TimeSpan timeSub = Utility.IndianTime - OtpCrtDate;
                if (timeSub.TotalMinutes <= 15)
                {
                    div_pinsection.Attributes.Add("style", "display:block");
                    div_pinsectiontitle.Attributes.Add("style", "display:block");
                    div_otp.Attributes.Add("style", "display:none");
                }
                else
                {
                    lblotp.Text = "Sorry,your OTP is valid for 15 minutes. Get a new one";
                    otpdisplay.Text = "";
                }
            }
            else
            {
                lblotp.Text = "OTP not match";
            }
        }
    }

    protected void btnResendOTP_Click(object sender, EventArgs e)///Resend OTP
    {
        txtOTP.Text = "";
        lblotp.Text = "";
        div_reset.Attributes.Add("style", "display:none");
        div_resettitle.Attributes.Add("style", "display:none");
        div_login.Attributes.Add("style", "display:none");
        div_logintitle.Attributes.Add("style", "display:none");
        div_otp.Attributes.Add("style", "display:block");
        lblotpmsg.Visible = true;
        txtmobile.Visible = true;
        string OTPcode = GenerateOTP();
        //Session["OTPcode"] = OTPcode;
        otpdisplay.Text = OTPcode;
        cred.UpdateEmpMobileOTP(hdnmobileno.Value, OTPcode, hdnEmpID.Value, Utility.IndianTime);
        string mobileNo = "+91" + hdnmobileno.Value;

        string Message = "Your OTP for HR Portal login is " + OTPcode + " - PANOBIZ";
        string strTemplateId = "1707167307666833132";

        Utility.SendOTPSMS(mobileNo, strTemplateId, Message);
        //SendOTPSMS1("8939742167", OTPcode);
        txtmobile.Text = maskmobileNo(hdnmobileno.Value);
    }

    protected void btnsubmit_Click(object sender, EventArgs e)///Update New MPIN
    {
        div_pinsection.Attributes.Add("style", "display:block");
        div_pinsectiontitle.Attributes.Add("style", "display:block");

        lblpinerr.Text = "";
        //string stempID = Session["EMPID"].ToString();
        string stempID = hdnEmpID.Value;
        string mpin = Ntxt1.Text.Trim() + Ntxt2.Text.Trim() + Ntxt3.Text.Trim() + Ntxt4.Text.Trim();
        string confirmpin = Ctxt1.Text.Trim() + Ctxt2.Text.Trim() + Ctxt3.Text.Trim() + Ctxt4.Text.Trim();
        string stError = string.Empty;

        if (string.IsNullOrEmpty(Ntxt1.Text.Trim()) || string.IsNullOrEmpty(Ntxt2.Text.Trim()) || string.IsNullOrEmpty(Ntxt3.Text.Trim()) || string.IsNullOrEmpty(Ntxt4.Text.Trim()))
        {
            stError = "Enter New MPIN(4 digits)";
        }
        else if (string.IsNullOrEmpty(Ctxt1.Text.Trim()) || string.IsNullOrEmpty(Ctxt2.Text.Trim()) || string.IsNullOrEmpty(Ctxt3.Text.Trim()) || string.IsNullOrEmpty(Ctxt4.Text.Trim()))
        {
            stError = "Enter Confirm MPIN(4 digits)";
        }
        else if (!string.Equals(mpin, confirmpin))
        {
            stError = "MPIN not match";
        }


        if (string.IsNullOrEmpty(stError))
        {
            if (string.Equals(mpin, confirmpin))
            {
                if (IsAlreadyEmpIDExist(stempID))
                {
                    cred.EmpID = stempID;
                    cred.MPIN = mpin;
                    int ret = cred.UpdateMPIN(cred);
                    if (ret == -1)
                    {
                        div_pinsection.Attributes.Add("style", "display:none");
                        div_pinsectiontitle.Attributes.Add("style", "display:none");
                        //sendEmail("MPIN Reset");
                        //sendSMS("MPIN Reset");

                        DataSet ds1 = cred.ViewValidLoginEmployee(stempID, mpin);

                        if (ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
                        {
                            string EmpID = Convert.ToString(ds1.Tables[0].Rows[0]["EmpID"]);
                            string MPIN = Convert.ToString(ds1.Tables[0].Rows[0]["MPIN"]);
                            string EmailId = Convert.ToString(ds1.Tables[0].Rows[0]["EmailId"]);
                            string Name = Convert.ToString(ds1.Tables[0].Rows[0]["EmpFirstName"]);
                            string stMobileno = Convert.ToString(ds1.Tables[0].Rows[0]["Mobile"]);
                            string candID = Convert.ToString(ds1.Tables[0].Rows[0]["candID"]);

                            string stmsg = "Your MPIN has been successfully reset.";
                            string emailbody = PopulateEmailBody(stmsg);
                            empdet.SendMail("Panobiz Attendance Dashboard:MPIN Reset", emailbody, EmailId);
                            empdet.SendSMS("Panobiz Attendance Dashboard:MPIN Reset", stMobileno, EmpID);

                            int ConfirmByEmp = 0;
                            string ConfirmByAdmin = "";

                            if (!string.IsNullOrEmpty(ds1.Tables[0].Rows[0]["ConfirmFlag"].ToString()))
                            {
                                ConfirmByEmp = Convert.ToInt32(ds1.Tables[0].Rows[0]["ConfirmFlag"]);
                            }
                            ConfirmByAdmin = Convert.ToString(ds1.Tables[0].Rows[0]["ConfmApprovedStatus"]);

                            if (ConfirmByEmp == 1)
                            {
                                CreateCookies(Name, EmailId, EmpID, candID);
                                FormsAuthentication.SetAuthCookie(EmpID, true);
                                div_reg.Attributes.Add("style", "display:block");

                                string CloseWindow; CloseWindow = "$('.close').click(function () {$('.div_reg').css('display', 'none');$('.modal-backdrop').css('display', 'none');});";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "CloseWindow", CloseWindow, true);
                                int SecondsTimeOut = (3000);
                                string str_Script = @"  
                                            <script type='text/javascript'>   
                                                intervalset = window.setInterval('Redirect()'," + SecondsTimeOut.ToString() + @");  
                                                function Redirect()  
                                                {  
                                                    window.location.href='punch-in-out.aspx';   
                                                }  
                                            </script>";
                                div_pinsection.Attributes.Add("style", "display:block");
                                div_pinsectiontitle.Attributes.Add("style", "display:block");

                                ClientScript.RegisterClientScriptBlock(this.GetType(), "Redirect", str_Script);
                            }
                            else if (ConfirmByEmp == 0 && ConfirmByAdmin == "Completed")
                            {
                                div_reg.Attributes.Add("style", "display:block");
                                string CloseWindow; CloseWindow = "$('.close').click(function () {$('.div_reg').css('display', 'none');$('.modal-backdrop').css('display', 'none');});";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "CloseWindow", CloseWindow, true);

                                int SecondsTimeOut = (3000);
                                string str_Script = @"  
                                        <script type='text/javascript'>   
                                            intervalset = window.setInterval('Redirect()'," + SecondsTimeOut.ToString() + @");  
                                            function Redirect()  
                                            {  
                                                window.location.href='edit-profile-details.aspx?EmpID=" + EmpID + @"'; 
                                            }  
                                        </script>";
                                div_pinsection.Attributes.Add("style", "display:block");
                                div_pinsectiontitle.Attributes.Add("style", "display:block");

                                lblpinerr.Text = "";
                                ClientScript.RegisterClientScriptBlock(this.GetType(), "Redirect", str_Script);
                            }
                            else if (ConfirmByEmp == 0 && ConfirmByAdmin == "InProgress")
                            {
                                //div_reg.Attributes.Add("style", "display:block");

                                //string CloseWindow; CloseWindow = "$('.close').click(function () {$('.div_reg').css('display', 'none');$('.modal-backdrop').css('display', 'none');});";
                                //ScriptManager.RegisterStartupScript(this, this.GetType(), "CloseWindow", CloseWindow, true);

                                div_pinsection.Attributes.Add("style", "display:block");
                                div_pinsectiontitle.Attributes.Add("style", "display:block");
                                Ntxt1.Text = ""; Ntxt2.Text = ""; Ntxt3.Text = ""; Ntxt4.Text = "";
                                Ctxt1.Text = ""; Ctxt2.Text = ""; Ctxt3.Text = ""; Ctxt4.Text = "";
                                lblpinerr.Text = "<font style='color:green'>Your MPIN has been reset.</font>" +
                                    "<font style='color:Red'>Your profile confirmation detail updation is in progress, please try again later.</font>";
                            }
                            else if (ConfirmByEmp == 0 && ConfirmByAdmin == "")
                            {
                                div_reg.Attributes.Add("style", "display:block");
                                string CloseWindow; CloseWindow = "$('.close').click(function () {$('.div_reg').css('display', 'none');$('.modal-backdrop').css('display', 'none');});";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "CloseWindow", CloseWindow, true);

                                int SecondsTimeOut = (3000);
                                string str_Script = @"  
                                        <script type='text/javascript'>   
                                            intervalset = window.setInterval('Redirect()'," + SecondsTimeOut.ToString() + @");  
                                            function Redirect()  
                                            {  
                                                window.location.href='edit-profile-details.aspx?EmpID=" + EmpID + @"'; 
                                            }  
                                        </script>";
                                div_pinsection.Attributes.Add("style", "display:block");
                                div_pinsectiontitle.Attributes.Add("style", "display:block");

                                lblpinerr.Text = "";
                                ClientScript.RegisterClientScriptBlock(this.GetType(), "Redirect", str_Script);
                            }
                        }

                    }
                    else
                    {
                        lblpinerr.Text = "MPIN has not been reset.";
                    }

                }
                else
                {
                    lblpinerr.Text = "Invalid Employee ID";
                }
            }
        }
        else
        {
            lblpinerr.Text = stError;
        }
    }

    public bool IsAlreadyEmpIDExist(string stEmpID)
    {
        bool IsExists = false;
        DataSet ds = cred.ViewEmpIDExist(stEmpID);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            IsExists = true;
        return IsExists;
    }
    #region Send OTP
    private void SendOTPSMS(string stMobileNo, string stOTP)
    {
        try
        {
            string Message = "Your OTP for HR Portal login is " + stOTP + " - PANOBIZ";
            // HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://sms.duffldigital.com/api/v2/sms/send?access_token=bd6bfafaac3c4a36a9ecd59db17c8dac&message=" + HttpUtility.UrlEncode(Message) + "&sender=MINDKO&to=" + stMobileNo + "&service=T&entity_id=1701163549560333247&template_id=" + strTemplateId + "");

            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://alerts.qikberry.com/api/v2/sms/send?access_token=2640d057bd8f5408f35f5bfd3106fc81&message=" + HttpUtility.UrlEncode(Message) + "&sender=Panobiz&to=" + stMobileNo + "&service=T&entity_id=1701159280568999610&template_id=1707167307666833132");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://sms.duffldigital.com/api/v2/sms/send?access_token=20982|4cIwOJzjftb80rQcAlrpbv0owUqkv5NbDkonMaVw&message=" + HttpUtility.UrlEncode(Message) + "&sender=PANOBI&to=" + stMobileNo + "&service=T&entity_id=1701159280568999610&template_id=1707167307666833132");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader readStream = new StreamReader(responseStream, Encoding.UTF8);
            var _Result = readStream.ReadToEnd();
        }
        catch (Exception ex)
        {
        }
    }
    private void SendOTPSMS1(string stMobileNo, string stOTP)
    {
        try
        {
            string Message = "Your OTP for HR Portal login is " + stOTP + " - PANOBIZ";
            // HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://sms.duffldigital.com/api/v2/sms/send?access_token=bd6bfafaac3c4a36a9ecd59db17c8dac&message=" + HttpUtility.UrlEncode(Message) + "&sender=MINDKO&to=" + stMobileNo + "&service=T&entity_id=1701163549560333247&template_id=" + strTemplateId + "");

            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://alerts.qikberry.com/api/v2/sms/send?access_token=2640d057bd8f5408f35f5bfd3106fc81&message=" + HttpUtility.UrlEncode(Message) + "&sender=Panobiz&to=" + stMobileNo + "&service=T&entity_id=1701159280568999610&template_id=1707167307666833132");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://sms.duffldigital.com/api/v2/sms/send?access_token=20982|4cIwOJzjftb80rQcAlrpbv0owUqkv5NbDkonMaVw&message=" + HttpUtility.UrlEncode(Message) + "&sender=PANOBI&to=" + stMobileNo + "&service=T&entity_id=1701159280568999610&template_id=1707167307666833132");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader readStream = new StreamReader(responseStream, Encoding.UTF8);
            var _Result = readStream.ReadToEnd();
        }
        catch (Exception ex)
        {
        }
    }
    #endregion

    public static string GenerateOTP()
    {
        Random random = new Random();
        StringBuilder builder = new StringBuilder(6);
        string OTPCode = "";
        for (int i = 0; i < 4; i++)
        {
            builder.Append(_numbers[random.Next(0, _numbers.Length)]);
        }
        OTPCode = builder.ToString();
        return OTPCode;
    }
    private string PopulateEmailBody(string Msg)
    {
        string body = string.Empty;
        //using (StreamReader reader = new StreamReader(Server.MapPath("mailtemplate/register.html")))
        //{
        //    body = reader.ReadToEnd();
        //}
        //body = body.Replace("{Name}", Name);
        body = Msg;

        return body;
    }

    [WebMethod]

    public static string EmpIDExist(string stEmpID)
    {
        string str = "";


        Credential cred = new Credential();
        DataSet ds = cred.ViewEmpIDExistBoth(stEmpID);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DataSet dslog = cred.ViewLoginApprovedStatusBoth(stEmpID);
            int stloginstatus = 0;
            if (!string.IsNullOrEmpty(dslog.Tables[0].Rows[0]["loginApproval"].ToString()))
            {
                stloginstatus = Convert.ToInt32(dslog.Tables[0].Rows[0]["loginApproval"]);
            }

            else
            {
                str = "You are not approved yet to log in.";
            }

        }
        else
        {
            str = "Employee id doesn't exist in our database.please enter the correct ID or check with admin.";


        }
        return str;
    }
    demoEmailandwhatsapp5 email = new demoEmailandwhatsapp5();
    protected void btnsubmit_Click1(object sender, EventArgs e)
    {

    }

    public string PopulateThankyouEmailBody()
    {


        string body = string.Empty;
        using (StreamReader reader = new StreamReader(Server.MapPath("demomailtemplate/adminmail.html")))
        {
            body = reader.ReadToEnd();
        }
        body = body.Replace("{Name}", txtname.Text.Trim());
        body = body.Replace("{Ph.no}", txtphoneno.Text.Trim());
        body = body.Replace("{EmpID}", txtEmpID.Text.Trim());
        body = body.Replace("{Loc}", txtloction.Text.Trim());

        return body;

    }
    private void ClearTextBoxes(params TextBox[] textBoxes)
    {
        foreach (TextBox textBox in textBoxes)
        {
            textBox.Text = "";
        }
    }



    protected void btnempidexist_Click1(object sender, EventArgs e)
    {
        //kjjdkjdjjdskj
    }





    protected void btnempsubmit1_Click(object sender, EventArgs e)
    {
        string thankyouemailBody = PopulateThankyouEmailBody();
        string subject = "Not able to login | - <" + txtname.Text.Trim() + " >-< " + txtphoneno.Text.Trim() + " >-< " + txtempid1.Text.Trim() + "> -< " + txtloction.Text.Trim() + ">";
        email.sendGmail("admin2@finzapp.com", subject, thankyouemailBody);
        email.SendWhatsAppMessage(txtname.Text.Trim(), txtempid1.Text.Trim(), txtphoneno.Text.Trim(), txtloction.Text.Trim(), "919566550568");


        lblerr.Text = "";

        ClearTextBoxes(txt1, txt2, txt3, txt4, txtEmpID, txtempid1, txtname, txtloction, txtphoneno);
        empdetails.Style.Add("display", "none");
        thankyoupopup.Style.Add("display", "block");
    }
}