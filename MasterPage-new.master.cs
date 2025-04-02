using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;

public partial class MasterPage : System.Web.UI.MasterPage
{
    EmpDetail emp = new EmpDetail();
    AddDB add = new AddDB();
    LeaveRequests req = new LeaveRequests();
    Credential cred = new Credential();
    BothLoginAtten BothLoginAtten = new BothLoginAtten();

    protected void Page_Load(object sender, EventArgs e)
    {
       // string stEmpName = emp.GetEmpName();
        string stEmpName = BothLoginAtten.BothLoginGetEmpName();
        lblempname.Text = "Hi " + stEmpName;

        //string empId = emp.GetEmpId();
        string empId = BothLoginAtten.BothLoginGetEmpId();
        string strloginapproval = CheckLoginApproval(empId);

        if (string.IsNullOrEmpty(stEmpName) || (strloginapproval!="Yes"))
            Response.Redirect("https://hr.panobiz.in/login.aspx", true);


        //Response.Redirect("login.aspx");

        BindEmp(empId);
        BindNotification();
    }
    public string CheckLoginApproval(string stEmpId)
    {
        string strloginapproval = "";
        DataSet ds = cred.ViewLoginApprovedStatus(stEmpId);
        int stloginstatus = 0;
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["loginApproval"].ToString()))
            {
                stloginstatus = Convert.ToInt32(ds.Tables[0].Rows[0]["loginApproval"]);
            }

            if (stloginstatus == 1)
            {
                strloginapproval = "Yes";
            }
        }
        return strloginapproval;
    }
    public string BindClientName(string ID)
    {
        string str = ID;
        try  
        {
        int ClientID = Convert.ToInt32(ID);

        if (!string.IsNullOrEmpty(ID))
        {
            DataSet ds = add.ViewClientByID(ClientID);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                str = Convert.ToString(ds.Tables[0].Rows[0]["Company"]);
            }
        }
        return str;
        }
        catch
        {

        }
        return str;
    }

    public string BindProductName(string ID)
    {
        string str = string.Empty;

        if (!string.IsNullOrEmpty(ID))
        {
            DataSet ds = add.ViewProductByID(ID);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                str = Convert.ToString(ds.Tables[0].Rows[0]["Productname"]);
            }
        }
        return str;
    }

    public void BindEmp(string stEmpId)
    {
        DataSet ds = emp.ViewEmpDetailByEmpID(stEmpId);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
           // if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["AttendanceMethod"])))
           // {
                lblEmpID.Text = Convert.ToString(ds.Tables[0].Rows[0]["EmpID"]);
                lblEname.Text = Convert.ToString(ds.Tables[0].Rows[0]["EmpFirstName"]);
                lblDept.Text = BindProductName(Convert.ToString(ds.Tables[0].Rows[0]["Dept"])) + ", " + BindClientName(Convert.ToString(ds.Tables[0].Rows[0]["ClientName"]));
                //lblDept.Text = Convert.ToString(ds.Tables[0].Rows[0]["Dept"]) + ", " + Convert.ToString(ds.Tables[0].Rows[0]["ClientName"]);
           // }
        }
    }
    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Session["EmpName"] = null;
        Session.Abandon();
        FormsAuthentication.SignOut();
        if (Request.Cookies["EmpLOGIN"] != null)
        {
            var c = new HttpCookie("EmpLOGIN");
            c.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(c);

        }
        Session["EmpEmailId"] = null;
        Session["EmpEmpId"] = null;
        //Response.Redirect("indexnew.aspx", true);
        Response.Redirect("https://hr.panobiz.in/login.aspx", true);

    }
    public string GetCss(string stUrl)
    {
        string Url = HttpContext.Current.Request.Url.AbsolutePath.Trim();
        string filename = System.IO.Path.GetFileName(Url);
        string stCSS = string.Empty;

        if (!string.IsNullOrEmpty(Url) && !string.IsNullOrEmpty(filename))
        {
            // if (string.Equals(stUrl.Trim(), "Dashboard") && string.Equals(filename.Trim(), "dashboard.aspx", StringComparison.OrdinalIgnoreCase))
            // {
            //     lblPageTitle.Text = "Dashboard";
            //     stCSS = "active";
            // }
            if (string.Equals(stUrl.Trim(), "PunchInPunchOut") && string.Equals(filename.Trim(), "punch-in-out.aspx", StringComparison.OrdinalIgnoreCase))
            {
                lblPageTitle.Text = "Punch In / Punch Out";
                stCSS = "active";
            }
            if (string.Equals(stUrl.Trim(), "AttendanceHistory") && string.Equals(filename.Trim(), "attendance-history.aspx", StringComparison.OrdinalIgnoreCase))
            {
                lblPageTitle.Text = "Attendance History";
                stCSS = "active";
            }
            if (string.Equals(stUrl.Trim(), "LeaveHistory") && string.Equals(filename.Trim(), "leave-history.aspx", StringComparison.OrdinalIgnoreCase))
            {
                lblPageTitle.Text = "Leave Request Status";
                stCSS = "active";
            }
            if (string.Equals(stUrl.Trim(), "ApplyLeave") && string.Equals(filename.Trim(), "apply-leave.aspx", StringComparison.OrdinalIgnoreCase))
            {
                lblPageTitle.Text = "Apply Leave";
                stCSS = "active";
            }
            if (string.Equals(stUrl.Trim(), "Holiday") && string.Equals(filename.Trim(), "holiday.aspx", StringComparison.OrdinalIgnoreCase))
            {
                lblPageTitle.Text = "Holiday";
                stCSS = "active";
            }
            if (string.Equals(stUrl.Trim(), "ActivityHistory") && string.Equals(filename.Trim(), "activity-history.aspx", StringComparison.OrdinalIgnoreCase))
            {
                lblPageTitle.Text = "Activity History";
                stCSS = "active";
            }
            if (string.Equals(stUrl.Trim(), "ActivityHistory") && string.Equals(filename.Trim(), "activity-report.aspx", StringComparison.OrdinalIgnoreCase))
            {
                lblPageTitle.Text = "Daily Activity Report";
                stCSS = "active";
            }
            if (string.Equals(stUrl.Trim(), "KycDoc") && string.Equals(filename.Trim(), "kycdoc.aspx", StringComparison.OrdinalIgnoreCase))
            {
                lblPageTitle.Text = "KYC Document";
                stCSS = "active";
            }
            if (string.Equals(stUrl.Trim(), "KycDoc") && string.Equals(filename.Trim(), "upload-kycdoc.aspx", StringComparison.OrdinalIgnoreCase))
            {
                lblPageTitle.Text = "Upload KYC Documnent";
                stCSS = "active";
            }
            if (string.Equals(stUrl.Trim(), "PersonalDetails") && string.Equals(filename.Trim(), "personal-details.aspx", StringComparison.OrdinalIgnoreCase))
            {
                lblPageTitle.Text = "Personal Details";
                stCSS = "active";
            }
            if (string.Equals(stUrl.Trim(), "PunchInPunchOut") && string.Equals(filename.Trim(), "addactivity.aspx", StringComparison.OrdinalIgnoreCase))
            {
                lblPageTitle.Text = "Add Activity";
                stCSS = "active";
            }
            if (string.Equals(stUrl.Trim(), "PunchInPunchOut") && string.Equals(filename.Trim(), "profile-details.aspx", StringComparison.OrdinalIgnoreCase))
            {
                lblPageTitle.Text = "Profile Details";
                stCSS = "active";
            }
                          if (string.Equals(stUrl.Trim(), "candidateProfile") && string.Equals(filename.Trim(), "candidate-profile-sheet.aspx", StringComparison.OrdinalIgnoreCase))
            {
                lblPageTitle.Text = "Candidate Profile Sheet";
                stCSS = "active";
            }
            if (string.Equals(stUrl.Trim(), "PersonalDetails") && string.Equals(filename.Trim(), "edit-profile-details.aspx", StringComparison.OrdinalIgnoreCase))
            {
                lblPageTitle.Text = "Edit Profile Details";
                stCSS = "active";
            }
              if (string.Equals(stUrl.Trim(), "policy") && string.Equals(filename.Trim(), "policy.aspx", StringComparison.OrdinalIgnoreCase))
            {
                lblPageTitle.Text = "Policy";
                stCSS = "active";
            }
             if (string.Equals(stUrl.Trim(), "policy") && string.Equals(filename.Trim(), "policy-details.aspx", StringComparison.OrdinalIgnoreCase))
            {
                lblPageTitle.Text = "Policy Details";
                stCSS = "active";
            }
  if (string.Equals(stUrl.Trim(), "empInfo") && string.Equals(filename.Trim(), "Employee-Information-sheet.aspx", StringComparison.OrdinalIgnoreCase))
            {
                lblPageTitle.Text = "Employee Information Sheet";
                stCSS = "active";
            }
             if (string.Equals(stUrl.Trim(), "offerApproval") && string.Equals(filename.Trim(), "offer-approval.aspx", StringComparison.OrdinalIgnoreCase))
            {
                lblPageTitle.Text = "Offer Approval";
                stCSS = "active";
            }
        }
        return stCSS;
    }

    public void BindNotification()
    {
        string empId = emp.GetEmpId();
        hdnEmpID.Value = empId;

        //-----------------Leave Request Count---------------------------
        int count = 0;
        
        DataSet dscnt = req.ViewLeaveRequestStatusCount(empId);
        if (dscnt.Tables.Count > 0 && dscnt.Tables[0].Rows.Count > 0)
        {
            count = Convert.ToInt32(dscnt.Tables[0].Rows[0]["leavecount"]);
        }

        //-----------------Top 10 Leave Request updation---------------------------
        DataSet ds = req.ViewLeaveRequestStatus(empId);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            lblhead1.Text = "Leave Status";
            rptr.Visible = true;
            rptr.DataSource = ds.Tables[0];
            rptr.DataBind();
        }
        else
        {
            rptr.Visible = false;
			lblhead1.Text = "No Leave Request";
        }

        //-----------------KYC Doc Notification Message and count---------------------------
        DataSet ds1 = emp.ViewKYCDocNotification(empId);
        if (ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
        {
            lblhead2.Text = "KYC DOC";
            lblkycdoc.Text = "You have to update KYC Document.";
            count += 1;
            divKYC.Visible = true;
        }
        else
        {
            divKYC.Visible = false;
        }

        //-----------------Broadcast Notification Message and count---------------------------
        DataSet dsBr = emp.ViewBroadcastNotification(empId);
        if (dsBr.Tables.Count > 0 && dsBr.Tables[0].Rows.Count > 0)
        {
            lblhead3.Text = "Broadcast Message";
            rprBroad.Visible = true;
            rprBroad.DataSource = dsBr.Tables[0];
            rprBroad.DataBind();
            count += 1;
        }
        else
        {
            rprBroad.Visible = false;
            //lblhead3.Text = "No Broadcast Message";
        }


        if (count > 0)
        {
            lblNotifyDesc.Text = "You have " + count + " new notification";
            spnNotifyCount.InnerText = count.ToString();
            spnnotify.Visible = true;
        }
        else
        {
            spnnotify.Visible = false;
        }
    }


    public string bindDate(DateTime dt)
    {
        if (dt != null)
        {
            return dt.ToString("dd/MM/yyyy");
        }
        else
        {
            return " - ";
        }
    }

    protected void OnAllItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField hdnLeaveRequestStatus = (e.Item.FindControl("hdnLeaveRequestStatus") as HiddenField);
                HiddenField hdnleavefromdate = (e.Item.FindControl("hdnleavefromdate") as HiddenField);
                HiddenField hdnleavetodate = (e.Item.FindControl("hdnleavetodate") as HiddenField);
                HiddenField hdnLeaveFor = (e.Item.FindControl("hdnLeaveFor") as HiddenField);
                Label lblleavenotify = (e.Item.FindControl("lblleavenotify") as Label);

                if(hdnLeaveFor.Value=="Single")
                    lblleavenotify.Text = "Leave applied on "+ bindDate(System.Convert.ToDateTime(hdnleavefromdate.Value)) + " is "+ hdnLeaveRequestStatus.Value;
                if (hdnLeaveFor.Value == "Multiple")
                    lblleavenotify.Text += "Leave applied on (" + bindDate(System.Convert.ToDateTime(hdnleavefromdate.Value)) + " to "+ bindDate(System.Convert.ToDateTime(hdnleavetodate.Value)) + ") is " + hdnLeaveRequestStatus.Value;
                if (hdnLeaveFor.Value == "Half")
                    lblleavenotify.Text += "Leave applied on " + bindDate(System.Convert.ToDateTime(hdnleavefromdate.Value)) + " is " + hdnLeaveRequestStatus.Value;
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void OnBroadcastItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
            }
        }
        catch (Exception ex)
        {

        }
    }

}
