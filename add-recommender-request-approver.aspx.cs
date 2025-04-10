using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;




public partial class add_recommender_request_approver : System.Web.UI.Page
{
    adminmpaccesslevel AAL = new adminmpaccesslevel();

    protected void Page_Load(object sender, EventArgs e)
    {
        hdnID.Value = null;
        int value = 0;
        if (Request.QueryString["ID"] != null)
        {
            if (int.TryParse(Request.QueryString["ID"], out value))
            {
                //edit
                btnSubmit.Text = "Update";
                lbldisplaytext.Text = "Edit ";
                hdnID.Value = Convert.ToString(value);
            }
            else
            {
                thankyou.Style.Add("Display", "Block");
                lblsucessmsg.Text = "URL is incorrect. please try again";
            }
        }
        else
        {
            lbldisplaytext.Text = "Add ";
            btnSubmit.Text = "Submit";
            //add
        }

        if (!IsPostBack)
        {
            AAL.GetClient(ddlcompany);
            if (hdnID.Value != null && !string.IsNullOrEmpty(hdnID.Value))
            {
                Bind(Convert.ToInt32(hdnID.Value));
            }
        }
    }


    public void Bind(int ID)
    {
        DataTable Dt = AAL.ViewAllMPaccesslevelByFilter(Convert.ToString(ID), "", "", "", "", "");

        if (Dt.Rows.Count > 0)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(Dt.Rows[0]["ClientID"])))
            {
                ddlcompany.SelectedValue = Convert.ToString(Dt.Rows[0]["ClientID"]);

                ddlemp.Items.Clear();
                ddlemp.Items.Insert(0, new ListItem("Select Emp ID", ""));
                ddlrequester.Items.Clear();
                ddlrequester.Items.Insert(0, new ListItem("Select requester", ""));
                if (!string.IsNullOrEmpty(ddlcompany.SelectedValue))
                {
                    AAL.Getroletddl(ddlrequester, Convert.ToInt32(ddlcompany.SelectedValue));
                    AAL.GetempID(ddlemp, Convert.ToInt32(ddlcompany.SelectedValue));
                }
            }
            if (!string.IsNullOrEmpty(Convert.ToString(Dt.Rows[0]["MPAStatus"])))
            {
                chkcheckbox.Checked = Convert.ToBoolean(Dt.Rows[0]["MPAStatus"]);
            }
            if (!string.IsNullOrEmpty(Convert.ToString(Dt.Rows[0]["Requester"])))
            {
                ddlrequester.SelectedValue = Convert.ToString(Dt.Rows[0]["Requester"]);
            }
            if (!string.IsNullOrEmpty(Convert.ToString(Dt.Rows[0]["EMPID"])))
            {
                ddlemp.SelectedValue = Convert.ToString(Dt.Rows[0]["EMPID"]);
            }
            if (!string.IsNullOrEmpty(Convert.ToString(Dt.Rows[0]["Moduler"])))
            {
                ddlModuler.SelectedValue = Convert.ToString(Dt.Rows[0]["Moduler"]);
            }
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {

        if (Request.QueryString["ID"] == null)
        {
            Clear();
            Response.Redirect(Request.Url.GetLeftPart(UriPartial.Path));
        }
        else
        {
            Clear();
            Response.Redirect("View-recommender-request-approver.aspx");
        }
    }
    protected void btnSubmit_Click1(object sender, EventArgs e)
    {
        string strerrolabel = string.Empty;

        if (string.IsNullOrEmpty(ddlcompany.SelectedValue))
        {
            strerrolabel = "Select client";
        }
        else if (string.IsNullOrEmpty(ddlrequester.SelectedValue))
        {
            strerrolabel = "Select requester";
        }
        else if (string.IsNullOrEmpty(ddlModuler.SelectedValue))
        {
            strerrolabel = "Select Moduler";
        }
        else if (string.IsNullOrEmpty(ddlemp.SelectedValue))
        {
            strerrolabel = "Select empID";
        }

        if (string.IsNullOrEmpty(strerrolabel))
        {
            int existret = AAL.ExistMPaccesslevel(hdnID.Value, ddlrequester.SelectedValue, ddlcompany.SelectedValue, ddlModuler.SelectedValue, ddlemp.SelectedValue);
            if (existret != 2)// fetching time error or network issue 
            {
                if (existret == 0)// already exist check
                {

                    if (Request.QueryString["ID"] == null)
                    {
                        int ret = 0;
                        ret = AddedData();
                        if (ret == 1)
                        {
                            thankyou.Style.Add("Display", "block");
                            lblsucessmsg.Text = "Added Successfully!";
                            Clear();
                        }
                    }
                    else
                    {
                        int ret = 0;
                        ret = UpdateData();
                        if (ret == 1)
                        {
                            thankyou.Style.Add("Display", "block");
                            lblsucessmsg.Text = "Updated Successfully!";
                            Clear();
                        }
                    }
                }
                else
                {
                    thankyou.Style.Add("Display", "block");
                    lblsucessmsg.Text = "Alredy exist!";
                }
            }
            else
            {
                thankyou.Style.Add("Display", "block");
                lblsucessmsg.Text = "A server error occurred. Please try again later. ";
            }
        }
    }



    public int AddedData()
    {
        int rowaffected = 0;

        try
        {
            AAL.ClientID = ddlcompany.SelectedValue;
            AAL.Moduler = ddlModuler.SelectedValue;
            AAL.Requester = ddlrequester.SelectedValue;
            AAL.EMPID = ddlemp.SelectedValue;
            AAL.AddedBy = "Admin";
            AAL.EMPstatus = chkcheckbox.Checked;
            rowaffected = AAL.Addadminmpaccesslevel(AAL);
        }
        catch (Exception ex)
        {

        }
        return rowaffected;
    }

    public int UpdateData()
    {
        int rowaffected = 0;

        try
        {
            AAL.intID = Convert.ToInt32(hdnID.Value);
            AAL.ClientID = ddlcompany.SelectedValue;
            AAL.Moduler = ddlModuler.SelectedValue;
            AAL.Requester = ddlrequester.SelectedValue;
            AAL.EMPID = ddlemp.SelectedValue;
            AAL.UpdatedBy = "Admin";
            AAL.EMPstatus = chkcheckbox.Checked;
            rowaffected = AAL.Updateadminmpaccesslevel(AAL);
        }
        catch (Exception ex)
        {

        }
        return rowaffected;
    }

    protected void ddlcompany_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlemp.Items.Clear();
        ddlemp.Items.Insert(0, new ListItem("Select Emp ID", ""));
        ddlrequester.Items.Clear();
        ddlrequester.Items.Insert(0, new ListItem("Select requester", ""));
        if (!string.IsNullOrEmpty(ddlcompany.SelectedValue))
        {
            AAL.Getroletddl(ddlrequester, Convert.ToInt32(ddlcompany.SelectedValue));
            AAL.GetempID(ddlemp, Convert.ToInt32(ddlcompany.SelectedValue));
        }
    }


    public void Clear()
    {
        ddlcompany.SelectedIndex = 0;
        ddlModuler.SelectedIndex = 0;
        ddlrequester.SelectedIndex = 0;
        ddlemp.SelectedIndex = 0;
        chkcheckbox.Checked = true;
    }

}
