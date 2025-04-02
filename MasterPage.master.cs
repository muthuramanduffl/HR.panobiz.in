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
    SupAttendance attend = new SupAttendance();
    LeaveRequests req = new LeaveRequests();
    AddDB add = new AddDB();
    Credential cred = new Credential();
    protected void Page_Load(object sender, EventArgs e)
    {
        string stEmpName = attend.GetEmpName();
        lblempname.Text = "Hi " + stEmpName;

        string empId = attend.GetEmpId();
        string strloginapproval = CheckLoginApproval(empId);

        if (string.IsNullOrEmpty(stEmpName) || (strloginapproval!="Yes"))
            Response.Redirect("login.aspx");

        BindEmp(empId);

        BindNotification();
    }
    public string CheckLoginApproval(string stEmpId)
    {
        string strloginapproval = "";
        DataSet ds = cred.ViewLoginSupApprovedStatus(stEmpId);
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
        Session["SEmpName"] = null;
        Session.Abandon();
        FormsAuthentication.SignOut();
        if (Request.Cookies["SEmpLOGIN"] != null)
        {
            var c = new HttpCookie("SEmpLOGIN");
            c.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(c);

        }
        Session["SEmpEmailId"] = null;
        Session["SEmpEmpId"] = null;
        Response.Redirect("login.aspx", true);

    }
    public string GetCss(string stUrl)
    {
        string Url = HttpContext.Current.Request.Url.AbsolutePath.Trim();
        string filename = System.IO.Path.GetFileName(Url);
        string stCSS = string.Empty;

        if (!string.IsNullOrEmpty(Url) && !string.IsNullOrEmpty(filename))
        {
            if (string.Equals(stUrl.Trim(), "emptodayattendance") && string.Equals(filename.Trim(), "emp-todayattendance.aspx", StringComparison.OrdinalIgnoreCase))
            {
                lblPageTitle.Text = "Today's Attendance List (Team Members)";
                stCSS = "active";
            }
            if (string.Equals(stUrl.Trim(), "PunchInPunchOut") && string.Equals(filename.Trim(), "punch-in-out.aspx", StringComparison.OrdinalIgnoreCase))
            {
                lblPageTitle.Text = "Punch In / Punch Out";
                stCSS = "active";
            }
            if (string.Equals(stUrl.Trim(), "ActivityHistory") && string.Equals(filename.Trim(), "activity-history.aspx", StringComparison.OrdinalIgnoreCase))
            {
                lblPageTitle.Text = "Activity History";
                stCSS = "active";
            }
            if (string.Equals(stUrl.Trim(), "ApplyLeave") && string.Equals(filename.Trim(), "apply-leave.aspx", StringComparison.OrdinalIgnoreCase))
            {
                lblPageTitle.Text = "Apply Leave";
                stCSS = "active";
            }
             if (string.Equals(stUrl.Trim(), "ActivityHistory") && string.Equals(filename.Trim(), "activity-report.aspx", StringComparison.OrdinalIgnoreCase))
            {
                lblPageTitle.Text = "Daily Activity Report";
                stCSS = "active";
            }
             if (string.Equals(stUrl.Trim(), "ActivityHistory") && string.Equals(filename.Trim(), "addactivity.aspx", StringComparison.OrdinalIgnoreCase))
            {
                lblPageTitle.Text = "Add Activity";
                stCSS = "active";
            }
            if (string.Equals(stUrl.Trim(), "AttendanceHistory") && string.Equals(filename.Trim(), "attendance-history.aspx", StringComparison.OrdinalIgnoreCase))
            {
                lblPageTitle.Text = "Attendance History";
                stCSS = "active";
            }
             if (string.Equals(stUrl.Trim(), "empListing") && string.Equals(filename.Trim(), "employee-listing.aspx", StringComparison.OrdinalIgnoreCase))
            {
                lblPageTitle.Text = "Employee Listing";
                stCSS = "active";
            }
             if (string.Equals(stUrl.Trim(), "empListing") && string.Equals(filename.Trim(), "Empattendance-history.aspx", StringComparison.OrdinalIgnoreCase))
            {
                lblPageTitle.Text = "Employee Attendance History";
                stCSS = "active";
            }
            if (string.Equals(stUrl.Trim(), "empListing") && string.Equals(filename.Trim(), "Empleave-history.aspx", StringComparison.OrdinalIgnoreCase))
            {
                lblPageTitle.Text = "Employee Leave History";
                stCSS = "active";
            }
            if (string.Equals(stUrl.Trim(), "empListing") && string.Equals(filename.Trim(), "employee-kycdoc.aspx", StringComparison.OrdinalIgnoreCase))
            {
                lblPageTitle.Text = "Employee KYC Document";
                stCSS = "active";
            }
            if (string.Equals(stUrl.Trim(), "empLeaveRequest") && string.Equals(filename.Trim(), "employee-leaverequest.aspx", StringComparison.OrdinalIgnoreCase))
            {
                lblPageTitle.Text = "Employee Leave Request";
                stCSS = "active";
            }

             if (string.Equals(stUrl.Trim(), "KYCDocs") && string.Equals(filename.Trim(), "kycdoc.aspx", StringComparison.OrdinalIgnoreCase))
            {
                lblPageTitle.Text = "KYC Document";
                stCSS = "active";
            }
             if (string.Equals(stUrl.Trim(), "KYCDocs") && string.Equals(filename.Trim(), "upload-kycdoc.aspx", StringComparison.OrdinalIgnoreCase))
            {
                lblPageTitle.Text = "Upload KYC Document";
                stCSS = "active";
            }
              if (string.Equals(stUrl.Trim(), "ApplyLeave") && string.Equals(filename.Trim(), "leave-history.aspx", StringComparison.OrdinalIgnoreCase))
            {
                lblPageTitle.Text = "Pending Leave Requests";
                stCSS = "active";
            }
              if (string.Equals(stUrl.Trim(), "leaveReport") && string.Equals(filename.Trim(), "leave-report.aspx", StringComparison.OrdinalIgnoreCase))
            {
                lblPageTitle.Text = "Leave Report";
                stCSS = "active";
            }
              if (string.Equals(stUrl.Trim(), "candidateProfile") && string.Equals(filename.Trim(), "candidate-profile-sheet.aspx", StringComparison.OrdinalIgnoreCase))
            {
                lblPageTitle.Text = "Candidate Profile Sheet";
                stCSS = "active";
            }
             if (string.Equals(stUrl.Trim(), "personalDetails") && string.Equals(filename.Trim(), "personal-details.aspx", StringComparison.OrdinalIgnoreCase))
            {
                lblPageTitle.Text = "Personal Details";
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
        string SupempId = emp.GetSupEmpId();
        hdnEmpID.Value = SupempId;

        //-----------------Supervisor Leave Request Count---------------------------
        int count = 0;
        int flag = 0;
        DataSet dscnt = req.ViewLeaveRequestStatusCount(SupempId);
        if (dscnt.Tables.Count > 0 && dscnt.Tables[0].Rows.Count > 0)
        {
            count = Convert.ToInt32(dscnt.Tables[0].Rows[0]["leavecount"]);
        }

        //-----------------Top 10 Leave Request updation ---------------------------
        DataSet ds = req.ViewLeaveRequestStatus(SupempId);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            lblhead1.Text = "Leave Status";
            rptr.Visible = true;
            rptr.DataSource = ds.Tables[0];
            rptr.DataBind();
            flag = 1;
        }
        else
        {
            rptr.Visible = false;
        }

        //-----------------Leave Request count By Executives ---------------------------
        DataSet dscnt1 = req.ViewLeaveRequestStatusCountBYSup(SupempId);
        if (dscnt1.Tables.Count > 0 && dscnt1.Tables[0].Rows.Count > 0)
        {
            count += Convert.ToInt32(dscnt1.Tables[0].Rows[0]["leavecount"]);
        }

        //-----------------Top 10 Leave Request applied By Executives ---------------------------
        DataSet dsE = req.ViewLeaveRequestStatusBYSup(SupempId);
        if (dsE.Tables.Count > 0 && dsE.Tables[0].Rows.Count > 0)
        {
            lblhead3.Text = "Executives Leave Request";
            rptrE.Visible = true;
            rptrE.DataSource = dsE.Tables[0];
            rptrE.DataBind();
            flag += 1;
        }
        else
        {
            rptrE.Visible = false;
        }

        //-----------------KYC Doc Notification Message and count---------------------------
        DataSet ds1 = emp.ViewKYCDocNotification(SupempId);
        if (ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
        {
            lblhead2.Text = "KYC DOC";
            lblkycdoc.Text = "You have to update KYC Document.";
            count += 1;
            divKYC.Visible = true;
            flag += 1;
        }
        else
        {
            divKYC.Visible = false;
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
        if(flag==0)
        {
            lblnomsg.Text = "No New Notifications";
        }
        else
        {
            lblnomsg.Text = "";
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

    protected void OnAllExecItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField hdnExLeaveRequestStatus = (e.Item.FindControl("hdnExLeaveRequestStatus") as HiddenField);
                HiddenField hdnExleavefromdate = (e.Item.FindControl("hdnExleavefromdate") as HiddenField);
                HiddenField hdnExleavetodate = (e.Item.FindControl("hdnExleavetodate") as HiddenField);
                HiddenField hdnExLeaveFor = (e.Item.FindControl("hdnExLeaveFor") as HiddenField);
                HiddenField hdnExecEmpID = (e.Item.FindControl("hdnExecEmpID") as HiddenField);
                Label lblExleavenotify = (e.Item.FindControl("lblExleavenotify") as Label); 

                if (hdnExLeaveFor.Value == "Single")
                    lblExleavenotify.Text = hdnExecEmpID.Value+ " applied leave on " + bindDate(System.Convert.ToDateTime(hdnExleavefromdate.Value)) + " is " + hdnExLeaveRequestStatus.Value;
                if (hdnExLeaveFor.Value == "Multiple")
                    lblExleavenotify.Text += hdnExecEmpID.Value + " applied leave on (" + bindDate(System.Convert.ToDateTime(hdnExleavefromdate.Value)) + " to " + bindDate(System.Convert.ToDateTime(hdnExleavetodate.Value)) + ") is " + hdnExLeaveRequestStatus.Value;
                if (hdnExLeaveFor.Value == "Half")
                    lblExleavenotify.Text +=  hdnExecEmpID.Value+ " applied leave on " + bindDate(System.Convert.ToDateTime(hdnExleavefromdate.Value)) + " is " + hdnExLeaveRequestStatus.Value;


            }
        }
        catch (Exception ex)
        {

        }
    }

}
