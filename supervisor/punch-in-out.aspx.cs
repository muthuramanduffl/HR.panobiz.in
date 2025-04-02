using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.IO;
using System.Net.Mail;
using System.Net;
using RestSharp;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

public partial class punch_in_out : System.Web.UI.Page
{

    EmpDetail emp = new EmpDetail();
    Attendance attend = new Attendance();

    public string Intime = "";
    public string outtime = "";
    public string LocationInTime = "";
    public string LocationOutTime = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.IsPostBack)
        {
            Label1.Text = Request.Form[hdnlat.UniqueID];
            Label2.Text = Request.Form[hdnlong.UniqueID];
        }
        if (!IsPostBack)
        {
            string stEmpId = emp.GetSupEmpId();
            BindEmp(stEmpId);
            BindAttendance(stEmpId);

        }
    }

    public void BindEmp(string stEmpId)
    {
        DataSet ds = emp.ViewEmpDetailByEmpID(stEmpId);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["AttendanceMethod"])))
            {
                hdnattendmethod.Value = Convert.ToString(ds.Tables[0].Rows[0]["AttendanceMethod"]);
            }
        }

        if(hdnattendmethod.Value == "7")
        {
            displaysection.Attributes.Add("style", "display:none");
            lblnopunch.Text = "No Punch In Punch Out";
            submitbtn.Attributes.Add("style", "display:block");
        }
        else if (string.IsNullOrEmpty(hdnattendmethod.Value))
        {
            displaysection.Attributes.Add("style", "display:none");
            lblnopunch.Text = "Attendance not approved.";
            submitbtn.Attributes.Add("style", "display:block");
        }
        else
        {
            displaysection.Attributes.Add("style", "display:block");
            lblnopunch.Text = "";
        }
    }

    public void BindAttendance(string stEmpId)
    {
        DataSet ds = attend.ViewAttendanceByEmpIDAttDate(stEmpId, Utility.IndianTime);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            Intime = Convert.ToString(ds.Tables[0].Rows[0]["InTime"]);
            LocationInTime = Convert.ToString(ds.Tables[0].Rows[0]["LocationInTime"]);
            outtime = Convert.ToString(ds.Tables[0].Rows[0]["OutTime"]);
            LocationOutTime = Convert.ToString(ds.Tables[0].Rows[0]["LocationOutTime"]);

            if (hdnattendmethod.Value == "1")
            {
                lblInAttend1.Text = Convert.ToString(ds.Tables[0].Rows[0]["InTime"]);
                div_Pin1.Attributes.Add("style", "display:block");
                div_out.Attributes.Add("style", "display:none");
                div_in.Attributes.Add("style", "display:none");
                divtogglebtn.Attributes.Add("style", "display:none");
            }
            else if (hdnattendmethod.Value == "2")
            {
                lblInAttend2.Text = Convert.ToString(ds.Tables[0].Rows[0]["InTime"]) + ", " + LocationInTime;
                div_Pin2.Attributes.Add("style", "display:block");
                div_out.Attributes.Add("style", "display:none");
                div_in.Attributes.Add("style", "display:none");
                divtogglebtn.Attributes.Add("style", "display:none");
            }
            else if (hdnattendmethod.Value == "3")
            {
                lblOutAttend3.Text = Convert.ToString(ds.Tables[0].Rows[0]["OutTime"]);
                div_Pout3.Attributes.Add("style", "display:block");
                div_out.Attributes.Add("style", "display:none");
                div_in.Attributes.Add("style", "display:none");
                divtogglebtn.Attributes.Add("style", "display:none");
            }
            else if (hdnattendmethod.Value == "4")
            {
                lblOutAttend4.Text = Convert.ToString(ds.Tables[0].Rows[0]["OutTime"]) + ", " + LocationOutTime;
                div_Pout4.Attributes.Add("style", "display:block");
                div_out.Attributes.Add("style", "display:none");
                div_in.Attributes.Add("style", "display:none");
                divtogglebtn.Attributes.Add("style", "display:none");
            }
            else if (hdnattendmethod.Value == "5")
            {
                lblInAttend5.Text = Convert.ToString(ds.Tables[0].Rows[0]["InTime"]);
                div_Pin5.Attributes.Add("style", "display:block");

                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["OutTime"])))
                {
                    lblOutAttend5.Text = Convert.ToString(ds.Tables[0].Rows[0]["OutTime"]);
                    div_Pout5.Attributes.Add("style", "display:block");
                    divtogglebtn.Attributes.Add("style", "display:none");
                }
                else
                {
                    div_out.Attributes.Add("style", "display:block");
                    div_Pout5.Attributes.Add("style", "display:none");
                    divtogglebtn.Attributes.Add("style", "display:block");
                    chkOnOff.Checked = true;
                }

                div_in.Attributes.Add("style", "display:none");
            }
            else if (hdnattendmethod.Value == "6")
            {
                lblInAttend6.Text = Convert.ToString(ds.Tables[0].Rows[0]["InTime"]) + ", " + LocationInTime;
                div_Pin6.Attributes.Add("style", "display:block");

                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["OutTime"])))
                {
                    lblOutAttend6.Text = Convert.ToString(ds.Tables[0].Rows[0]["OutTime"]) + ", " + LocationOutTime;
                    div_Pout6.Attributes.Add("style", "display:block");
                    divtogglebtn.Attributes.Add("style", "display:none");
                }
                else
                {
                    div_out.Attributes.Add("style", "display:block");
                    div_Pout6.Attributes.Add("style", "display:none");
                    divtogglebtn.Attributes.Add("style", "display:block");
                    chkOnOff.Checked = true;
                }
                div_in.Attributes.Add("style", "display:none");

            }

            
            DataSet ds1 = emp.ViewDailyActivityExistByDate(stEmpId, Utility.IndianTime);
            if (ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
            {
                submitbtn.Attributes.Add("style", "display:none");
                lblmsg.Text = "Today activity submitted. To view, Select activity history in the menu";
            }
            else
            {
                if ((hdnattendmethod.Value == "5") && (string.IsNullOrEmpty(lblOutAttend5.Text)))
                {
                    submitbtn.Attributes.Add("style", "display:none");
                    lblmsg.Text = "";
                }
                else if ((hdnattendmethod.Value == "6") && (string.IsNullOrEmpty(lblOutAttend6.Text)))
                {
                    submitbtn.Attributes.Add("style", "display:none");
                    lblmsg.Text = "";
                }
                else
                {
                    submitbtn.Attributes.Add("style", "display:block");
                    lblmsg.Text = "";
                }
            }
            
        }
        else
        {
            if ((hdnattendmethod.Value == "1") || (hdnattendmethod.Value == "2"))
            {
                div_out.Attributes.Add("style", "display:none");
                div_in.Attributes.Add("style", "display:block");
                divtogglebtn.Attributes.Add("style", "display:block");
            }
            else if ((hdnattendmethod.Value == "3") || (hdnattendmethod.Value == "4"))
            {
                div_out.Attributes.Add("style", "display:block");
                div_in.Attributes.Add("style", "display:none");
                divtogglebtn.Attributes.Add("style", "display:block");
            }
            else if ((hdnattendmethod.Value == "5") || (hdnattendmethod.Value == "6"))
            {
                div_out.Attributes.Add("style", "display:none");
                div_in.Attributes.Add("style", "display:block");
                divtogglebtn.Attributes.Add("style", "display:block");
            }

            submitbtn.Attributes.Add("style", "display:none");
            
        }

        if (hdnattendmethod.Value == "7")
        {

            DataSet ds1 = emp.ViewDailyActivityExistByDate(stEmpId, Utility.IndianTime);
            if (ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
            {
                submitbtn.Attributes.Add("style", "display:none");
                lblno.Text = "Today activity submitted. To view, Select activity history in the menu";
            }
            else
            {
                submitbtn.Attributes.Add("style", "display:block");
                lblno.Text = "";
            }
            displaysection.Attributes.Add("style", "display:none");
            lblnopunch.Text = "No Punch In Punch Out";
        }

    }

    protected void chkOnOff_Changed(object sender, EventArgs e)
    {
        string onOff = chkOnOff.Checked ? "On" : "Off";

        if (onOff == "On")
        {
            if (hdnattendmethod.Value == "1")
            {
                lblInAttend1.Text = Utility.IndianTime.ToString("hh:mm:ss tt", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                Intime = lblInAttend1.Text;
                InsertAttendance();
                div_Pin1.Attributes.Add("style", "display:block");
                div_out.Attributes.Add("style", "display:none");
                div_in.Attributes.Add("style", "display:none");
                divtogglebtn.Attributes.Add("style", "display:none");
                submitbtn.Attributes.Add("style", "display:block");
            }
            else if (hdnattendmethod.Value == "2")
            {
                Intime = Utility.IndianTime.ToString("hh:mm:ss tt", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                LocationInTime = GetLocation(Label1.Text, Label2.Text);
                lblInAttend2.Text = Intime + ", " + LocationInTime;
                InsertAttendance();
                div_Pin2.Attributes.Add("style", "display:block");
                div_out.Attributes.Add("style", "display:none");
                div_in.Attributes.Add("style", "display:none");
                divtogglebtn.Attributes.Add("style", "display:none");
                submitbtn.Attributes.Add("style", "display:block");
            }
            else if (hdnattendmethod.Value == "3")
            {
                lblOutAttend3.Text = Utility.IndianTime.ToString("hh:mm:ss tt", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                outtime = lblOutAttend3.Text;
                InsertAttendance();
                div_Pout3.Attributes.Add("style", "display:block");
                div_out.Attributes.Add("style", "display:none");
                div_in.Attributes.Add("style", "display:none");
                divtogglebtn.Attributes.Add("style", "display:none");
                submitbtn.Attributes.Add("style", "display:block");
            }
            else if (hdnattendmethod.Value == "4")
            {
                outtime = Utility.IndianTime.ToString("hh:mm:ss tt", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                LocationOutTime = GetLocation(Label1.Text, Label2.Text);
                lblOutAttend4.Text = outtime + ", " + LocationOutTime;

                InsertAttendance();
                div_Pout4.Attributes.Add("style", "display:block");
                div_out.Attributes.Add("style", "display:none");
                div_in.Attributes.Add("style", "display:none");
                divtogglebtn.Attributes.Add("style", "display:none");
                submitbtn.Attributes.Add("style", "display:block");
            }
            else if (hdnattendmethod.Value == "5")
            {
                lblInAttend5.Text = Utility.IndianTime.ToString("hh:mm:ss tt", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                Intime = lblInAttend5.Text;
                InsertAttendance();
                div_Pin5.Attributes.Add("style", "display:block");
                div_out.Attributes.Add("style", "display:block");
                div_in.Attributes.Add("style", "display:none");
                divtogglebtn.Attributes.Add("style", "display:block");
                submitbtn.Attributes.Add("style", "display:none");
            }
            else if (hdnattendmethod.Value == "6")
            {
                Intime = Utility.IndianTime.ToString("hh:mm:ss tt", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                LocationInTime = GetLocation(Label1.Text, Label2.Text);
                lblInAttend6.Text = Intime + ", " + LocationInTime;
                InsertAttendance();
                div_Pin6.Attributes.Add("style", "display:block");
                div_out.Attributes.Add("style", "display:block");
                div_in.Attributes.Add("style", "display:none");
                divtogglebtn.Attributes.Add("style", "display:block");
                submitbtn.Attributes.Add("style", "display:none");
            }
            else
            {
                lblnoattend.Text = "Attendance not approved.";
            }


        }
        else if (onOff == "Off")
        {
            if (hdnattendmethod.Value == "5")
            {
                lblOutAttend5.Text = Utility.IndianTime.ToString("hh:mm:ss tt", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                outtime = lblOutAttend5.Text;

                UpdateAttendance();
                div_Pin5.Attributes.Add("style", "display:block");
                div_Pout5.Attributes.Add("style", "display:block");
                div_out.Attributes.Add("style", "display:none");
                div_in.Attributes.Add("style", "display:none");
                divtogglebtn.Attributes.Add("style", "display:none");
                submitbtn.Attributes.Add("style", "display:block");
            }
            else if (hdnattendmethod.Value == "6")
            {
                lblOutAttend6.Text = Utility.IndianTime.ToString("hh:mm:ss tt", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                outtime = lblOutAttend6.Text;
                LocationOutTime = GetLocation(Label1.Text, Label2.Text);
                lblOutAttend6.Text = outtime + ", " + LocationOutTime;
                UpdateAttendance();
                div_Pin6.Attributes.Add("style", "display:block");
                div_Pout6.Attributes.Add("style", "display:block");
                div_out.Attributes.Add("style", "display:none");
                div_in.Attributes.Add("style", "display:none");
                divtogglebtn.Attributes.Add("style", "display:none");
                submitbtn.Attributes.Add("style", "display:block");
            }
        }
    }

    public void InsertAttendance()
    {
        attend.EmpID = emp.GetSupEmpId();
        attend.InTime = Intime;
        attend.OutTime = outtime;
        attend.LocationInTime = LocationInTime;
        attend.LocationOutTime = LocationOutTime;
        attend.Attendancestatus = "Present";
        attend.AttendanceDate = Utility.IndianTime;
        attend.AddedDate = Utility.IndianTime;
        attend.AddedBy = attend.EmpID;
        int row = 0;
        row = attend.AddAttendance(attend);
        if (row == -1)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script>alert('Have a nice day');</script>");
        }
    }

    public void UpdateAttendance()
    {
        attend.EmpID = emp.GetSupEmpId();
        attend.OutTime = outtime;
        attend.LocationOutTime = LocationOutTime;
        attend.AttendanceDate = Utility.IndianTime;
        attend.UpdatedDate = Utility.IndianTime;
        attend.UpdatedBy = attend.EmpID;
        int row = 0;
        row = attend.UpdateAttendance(attend);
        if (row == -1)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script>alert('Have a nice day');</script>");

        }
    }

    // public string GetLocation(string latitude, string longitude)
    // {
    //     string location = string.Empty;
    //     try
    //     {
    //         HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.bigdatacloud.net/data/reverse-geocode?latitude=" + latitude + "&longitude=" + longitude + "&localityLanguage=en&key=bdc_03c5d0f39e62415b9eefd0789c3aaaee");
    //         HttpWebResponse response = (HttpWebResponse)request.GetResponse();
    //         Stream responseStream = response.GetResponseStream();
    //         StreamReader readStream = new StreamReader(responseStream, Encoding.UTF8);
    //         var _Result = readStream.ReadToEnd();

    //         if (!string.IsNullOrEmpty(_Result))
    //         {
    //             dynamic jsonObject = JsonConvert.DeserializeObject(_Result);
    //             var result = jsonObject;
    //             var msg = result.success;
    //             location = result.city;
    //         }

    //     }
    //     catch (Exception ex)
    //     {
    //     }
    //     return location;
    // }
    public string GetLocation(string latitude, string longitude)
    {
        string location = string.Empty;
        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://maps.googleapis.com/maps/api/geocode/json?latlng=" + latitude + ","+ longitude + "&key=AIzaSyCWWYhHVzaFDet-_2BD9k3ox-sLc8x3NVs");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader readStream = new StreamReader(responseStream, Encoding.UTF8);
            var _Result = readStream.ReadToEnd();

            if (!string.IsNullOrEmpty(_Result))
            {
                dynamic jsonObject = JsonConvert.DeserializeObject(_Result);
                var obj = jsonObject;
                var msg = obj.results[0];

                //Response.Write(msg);
                //Response.Write(msg.formatted_address);
                location = msg.formatted_address;
            }

        }
        catch (Exception ex)
        {
        }
        return location;
    }

}
