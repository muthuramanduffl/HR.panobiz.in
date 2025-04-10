using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;



public partial class admin_request_approver : System.Web.UI.Page
{


    DataTable dt1 = new DataTable();
    DataRow dr1;

    adminmpaccesslevel ACL = new adminmpaccesslevel();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            ACL.GetClient(ddlcompany);

            Bindfunction();
        }
    }

    public void Bindfunction()
    {
        DataTable dt = Get();
        rprjobfunction.Visible = false;
        if (dt != null && dt.Rows.Count > 0)
        {
            rprjobfunction.Visible = true;
            rprjobfunction.DataSource = dt;
            rprjobfunction.DataBind();


        }
        else
        {

            rprjobfunction.Visible = false;
            lblmsg.Text = "No records found";
        }
    }

    protected void OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            (e.Item.FindControl("lblRowNumber") as Label).Text = (e.Item.ItemIndex + 1).ToString();
        }
    }


    public string GetName(string name)
    {
        string strname = string.Empty;
        DataTable dt = ACL.ViewCompanyNameByID(Convert.ToInt32(name));
        try
        {
            if (dt != null && dt.Rows.Count > 0)
            {
                strname = dt.Rows[0]["Company"].ToString();
            }
        }
        catch (Exception ex)
        {

        }
        return strname;
    }


    public string GetEmpID(string strID)
    {
        string empID = string.Empty;
        try
        {
            empID = ACL.viewMPEmpIDBySno(Convert.ToInt32(strID));

        }
        catch (Exception ex)
        {

        }
        return empID;

    }
    public string GetEmpRoleName(string name)
    {
        string strname = string.Empty;
        DataTable dt = ACL.ViewEmpRolesByID(Convert.ToInt32(name));
        try
        {
            if (dt != null && dt.Rows.Count > 0)
            {
                strname = dt.Rows[0]["Rolename"].ToString();
            }
        }
        catch (Exception ex)
        {

        }
        return strname;
    }

    public DataTable Get()
    {
        DataTable dt = new DataTable();
        try
        {
            dt = ACL.ViewAllMPaccesslevelByFilter("", "", ddlrequester.SelectedValue, ddlModuler.SelectedValue, ddlemp.SelectedValue, ddlcompany.SelectedValue);
        }
        catch (Exception ex)
        {
        }
        return dt;
    }






    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            int ret = 0;
            try
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                ret = ACL.DeleteMPaccesslevel(ID);
                if (ret == 1)
                {
                    Bindfunction();
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
            }
        }
    }




    protected void ddlcompany_SelectedIndexChanged1(object sender, EventArgs e)
    {
        ddlemp.Items.Clear();
        ddlemp.Items.Insert(0, new ListItem("All", ""));
        ddlrequester.Items.Clear();
        ddlrequester.Items.Insert(0, new ListItem("All", ""));
        if (!string.IsNullOrEmpty(ddlcompany.SelectedValue))
        {
            ACL.Getroletddl(ddlrequester, Convert.ToInt32(ddlcompany.SelectedValue));
            ACL.GetempID(ddlemp, Convert.ToInt32(ddlcompany.SelectedValue));
        }
        Bindfunction();
    }

    protected void ddlrequester_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bindfunction();
    }

    protected void ddlemp_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bindfunction();
    }

    protected void ddlModuler_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bindfunction();
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        ddlcompany.SelectedIndex = 0;
        ddlemp.Items.Clear();
        ddlemp.Items.Insert(0, new ListItem("All", ""));

        ddlrequester.Items.Clear();
        ddlrequester.Items.Insert(0, new ListItem("All", ""));

        ddlModuler.SelectedIndex = 0;
        Bindfunction();
    }
}
