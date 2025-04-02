using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for AdminEmp
/// </summary>
public class AdminEmp
{
    public int Sno { get; set; }
    public string EmpID { get; set; }
    public string AttendanceMethod { get; set; }
    public bool LoginApprovalStatus { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public bool ActiveStatus { get; set; }
    public string AddedBy { get; set; }
    public DateTime AddedDate { get; set; }
    public string UpdatedBy { get; set; }
    public DateTime UpdatedDate { get; set; }
    public string DisapprovalFor { get; set; }
    public string DisapproveReason { get; set; }

    public bool BroadcastNotify { get; set; }
    public int BroadcastID { get; set; }
    public string Client { get; set; }
    public string companyid { get; set; }
    public string Dept { get; set; }
    public string Role { get; set; }
    public string EmpRole { get; set; }
    

    public AdminEmp()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string GetSqlConnection()
    {
        string connectionString = null;
        try
        {

            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["HRPANOBIZ"].ConnectionString;

        }
        catch (Exception ex)
        {
        }
        return connectionString;
    }


    public string GetAdminEmail()
    {
        string strEmailId = string.Empty;
        try
        {
            if (HttpContext.Current.Session["AdminEmailId"] != null)
            {
                strEmailId = Convert.ToString(HttpContext.Current.Session["AdminEmailId"]);
            }
            if (string.IsNullOrEmpty(strEmailId))
            {
                if (HttpContext.Current.Request.Cookies["ADMINLOGIN"] != null)
                {
                    System.Web.HttpCookie Logincookie = HttpContext.Current.Request.Cookies["ADMINLOGIN"];
                    strEmailId = Logincookie["AdminEmailId"];
                }
            }
        }
        catch
        {
        }
        return strEmailId;
    }
    public string GetAdminName()
    {
        string strEmpName = string.Empty;
        try
        {
            if (HttpContext.Current.Session["AdminUserName"] != null)
            {
                strEmpName = Convert.ToString(HttpContext.Current.Session["AdminUserName"]);
            }
            if (string.IsNullOrEmpty(strEmpName))
            {
                if (HttpContext.Current.Request.Cookies["ADMINLOGIN"] != null)
                {
                    System.Web.HttpCookie Logincookie = HttpContext.Current.Request.Cookies["ADMINLOGIN"];
                    strEmpName = Logincookie["AdminUserName"];
                }
            }
        }
        catch
        {
        }
        return strEmpName;
    }

    public DataSet ViewAllEmp(string stEmpID, string stEmpName, string stClient, string stDept,string stRole, string stattendtype, string stsearch)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewAllEmp", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@EmpID", stEmpID));
                command.Parameters.Add(new SqlParameter("@EmpName", stEmpName));
                command.Parameters.Add(new SqlParameter("@Client", stClient));
                command.Parameters.Add(new SqlParameter("@Dept", stDept));
                command.Parameters.Add(new SqlParameter("@Role", stRole));
                command.Parameters.Add(new SqlParameter("@AttendType", stattendtype));
                command.Parameters.Add(new SqlParameter("@search", stsearch));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return ds;
    }

    public DataSet ViewAllEmpbyClientID(string stEmpID, string stEmpName, string stClient, string stDept,string stRole, string stattendtype, string stsearch, string companyid)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewAllEmpbyClientID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@EmpID", stEmpID));
                command.Parameters.Add(new SqlParameter("@EmpName", stEmpName));
                command.Parameters.Add(new SqlParameter("@Client", stClient));
                command.Parameters.Add(new SqlParameter("@Dept", stDept));
                command.Parameters.Add(new SqlParameter("@Role", stRole));
                command.Parameters.Add(new SqlParameter("@AttendType", stattendtype));
                command.Parameters.Add(new SqlParameter("@search", stsearch));
                command.Parameters.Add(new SqlParameter("@companyid", companyid));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return ds;
    }


    public DataSet ViewAllEmpProfileDetailsForUpdation(string stEmpID, string stEmpName, string stClient, string stDept,string stRole, string stattendtype, string stsearch)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewAllEmpProfileDetailsForUpdation", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@EmpID", stEmpID));
                command.Parameters.Add(new SqlParameter("@EmpName", stEmpName));
                command.Parameters.Add(new SqlParameter("@Client", stClient));
                command.Parameters.Add(new SqlParameter("@Dept", stDept));
                command.Parameters.Add(new SqlParameter("@Role", stRole));
                command.Parameters.Add(new SqlParameter("@AttendType", stattendtype));
                command.Parameters.Add(new SqlParameter("@search", stsearch));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return ds;
    }

    public DataSet ViewAllEmpByAdmin()
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewAllEmpByAdmin", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return ds;
    }

    public DataSet ViewEmpListbyClientID()
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewEmpListbyClientID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ClientName", "6"));

                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return ds;
    }

    public DataSet ViewAttendancemethod()
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewAttendancemethod", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return ds;
    }

    public int UpdateAttendanceMethod(AdminEmp empadmin)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateAttendanceMethod", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@EmpID", empadmin.EmpID));
                command.Parameters.Add(new SqlParameter("@AttendanceMethod", empadmin.AttendanceMethod));

                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }
    
    public DataSet ViewAttendancemethodBYID(string stAttID)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewAttendancemethodBYID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@AttID", stAttID));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return ds;
    }

    public DataSet ViewAllEmpLeaveDetailsByAdmin(string stEmpID, string stEmpName, string stClient, string stDept,
   string stRole, string stsearch, string strleavetype, string strFromDate, string strToDate)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewAllEmpLeaveDetailsByAdmin", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmpID", stEmpID));
                command.Parameters.Add(new SqlParameter("@EmpName", stEmpName));
                command.Parameters.Add(new SqlParameter("@Client", stClient));
                command.Parameters.Add(new SqlParameter("@Dept", stDept));
                command.Parameters.Add(new SqlParameter("@Role", stRole));
                command.Parameters.Add(new SqlParameter("@search", stsearch));
                command.Parameters.Add(new SqlParameter("@Leavetype", strleavetype));
                command.Parameters.Add(new SqlParameter("@FromDate", strFromDate));
                command.Parameters.Add(new SqlParameter("@ToDate", strToDate));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return ds;
    }


    public DataSet ViewAllEmpActivity(string stEmpID, string stEmpName, string stClient, string stDept,
   string stRole, string stsearch, string strFromDate, string strToDate)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewAllEmpActivity", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmpID", stEmpID));
                command.Parameters.Add(new SqlParameter("@EmpName", stEmpName));
                command.Parameters.Add(new SqlParameter("@Client", stClient));
                command.Parameters.Add(new SqlParameter("@Dept", stDept));
                command.Parameters.Add(new SqlParameter("@Role", stRole));
                command.Parameters.Add(new SqlParameter("@search", stsearch));
                command.Parameters.Add(new SqlParameter("@FromDate", strFromDate));
                command.Parameters.Add(new SqlParameter("@ToDate", strToDate));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return ds;
    }

    public int UpdateEmpLoginApprovalStatus(bool loginapprovalstatus,string EmpID)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateEmpLoginApprovalStatus", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@EmpID", EmpID));
                command.Parameters.Add(new SqlParameter("@loginapproval", loginapprovalstatus));

                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }
    
    public int AddLoginApprovalHistory(AdminEmp empadmin)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("AddLoginApprovalHistory", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@EmpID", empadmin.EmpID));
                command.Parameters.Add(new SqlParameter("@loginapproval", empadmin.LoginApprovalStatus));
                command.Parameters.Add(new SqlParameter("@UpdatedBy", empadmin.UpdatedBy));
                command.Parameters.Add(new SqlParameter("@UpdatedDate", empadmin.UpdatedDate));
                command.Parameters.Add(new SqlParameter("@DisapprovalFor", empadmin.DisapprovalFor));
                command.Parameters.Add(new SqlParameter("@DisapproveReason", empadmin.DisapproveReason));
                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }

    public DataSet AdminViewAttendanceReport(string stEmpID, string stEmpName, string stClient, string stDept,
      string stRole, string stsearch)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("AdminViewAttendanceReport", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@EmpID", stEmpID));
                command.Parameters.Add(new SqlParameter("@EmpName", stEmpName));
                command.Parameters.Add(new SqlParameter("@Client", stClient));
                command.Parameters.Add(new SqlParameter("@Dept", stDept));
                command.Parameters.Add(new SqlParameter("@Role", stRole));
                command.Parameters.Add(new SqlParameter("@search", stsearch));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return ds;
    }

    public DataSet AdminViewAttendanceReportByMonth(string stEmpID, string stEmpName, string stClient, string stDept,
     string stRole, string stsearch,string flag,string todaydate)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("AdminViewAttendanceReportByMonth", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@EmpID", stEmpID));
                command.Parameters.Add(new SqlParameter("@EmpName", stEmpName));
                command.Parameters.Add(new SqlParameter("@Client", stClient));
                command.Parameters.Add(new SqlParameter("@Dept", stDept));
                command.Parameters.Add(new SqlParameter("@Role", stRole));
                command.Parameters.Add(new SqlParameter("@search", stsearch));
                command.Parameters.Add(new SqlParameter("@flag", flag));
                command.Parameters.Add(new SqlParameter("@todaydate", todaydate));

                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return ds;
    }

    public DataSet ClientViewAttendanceReportByMonth(string stEmpID, string stEmpName, string stClient, string stDept,
     string stRole, string stsearch,string flag,string todaydate, string companyid)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ClientViewAttendanceReportByMonth", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@EmpID", stEmpID));
                command.Parameters.Add(new SqlParameter("@EmpName", stEmpName));
                command.Parameters.Add(new SqlParameter("@Client", stClient));
                command.Parameters.Add(new SqlParameter("@Dept", stDept));
                command.Parameters.Add(new SqlParameter("@Role", stRole));
                command.Parameters.Add(new SqlParameter("@search", stsearch));
                command.Parameters.Add(new SqlParameter("@flag", flag));
                command.Parameters.Add(new SqlParameter("@todaydate", todaydate));
                command.Parameters.Add(new SqlParameter("@companyid", companyid));

                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return ds;
    }


    public DataSet AdminViewAttendanceLeaveReportByMonth(string stEmpID, string stEmpName, string stClient, string stDept,
     string stRole, string stsearch,string flag,string todaydate)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("AdminViewAttendanceLeaveReportByMonth1", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@EmpID", stEmpID));
                command.Parameters.Add(new SqlParameter("@EmpName", stEmpName));
                command.Parameters.Add(new SqlParameter("@Client", stClient));
                command.Parameters.Add(new SqlParameter("@Dept", stDept));
                command.Parameters.Add(new SqlParameter("@Role", stRole));
                command.Parameters.Add(new SqlParameter("@search", stsearch));
                command.Parameters.Add(new SqlParameter("@flag", flag));
                command.Parameters.Add(new SqlParameter("@todaydate", todaydate));

                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return ds;
    }


    public DataSet AdminViewLeaveRequestReportModify(string stEmpID, string stEmpName, string stClient, string stDept,
  string stRole, string stsearch, string flag, string todaydate, string strleavetype, string strFromDate, string strToDate)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("AdminViewLeaveRequestReportModify", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@EmpID", stEmpID));
                command.Parameters.Add(new SqlParameter("@EmpName", stEmpName));
                command.Parameters.Add(new SqlParameter("@Client", stClient));
                command.Parameters.Add(new SqlParameter("@Dept", stDept));
                command.Parameters.Add(new SqlParameter("@Role", stRole));
                command.Parameters.Add(new SqlParameter("@search", stsearch));
                command.Parameters.Add(new SqlParameter("@flag", flag));
                command.Parameters.Add(new SqlParameter("@todaydate", todaydate));
                command.Parameters.Add(new SqlParameter("@Leavetype", strleavetype));
                command.Parameters.Add(new SqlParameter("@FromDate", strFromDate));
                command.Parameters.Add(new SqlParameter("@ToDate", strToDate));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return ds;
    }

    public DataSet AdminViewLeaveTypeReport(string stEmpID, string stEmpName, string stClient, string stDept,
 string stRole, string stsearch, string strFromDate, string strToDate)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("AdminViewLeaveTypeReport", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmpID", stEmpID));
                command.Parameters.Add(new SqlParameter("@EmpName", stEmpName));
                command.Parameters.Add(new SqlParameter("@Client", stClient));
                command.Parameters.Add(new SqlParameter("@Dept", stDept));
                command.Parameters.Add(new SqlParameter("@Role", stRole));
                command.Parameters.Add(new SqlParameter("@search", stsearch));
                command.Parameters.Add(new SqlParameter("@FromDate", strFromDate));
                command.Parameters.Add(new SqlParameter("@ToDate", strToDate));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return ds;
    }

    public DataSet ViewEmpInformSheetByAdmin()
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewEmpInformSheetByAdmin", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return ds;
    }

    public DataSet ViewTodayEmpAttendanceByAdmin(string todaydate, string stEmpID, string stEmpName, string stClient, string stDept,
     string stRole, string stStatus, string stsearch)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewTodayEmpAttendanceByAdmin", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@todaydate", todaydate));

                command.Parameters.Add(new SqlParameter("@EmpID", stEmpID));
                command.Parameters.Add(new SqlParameter("@EmpName", stEmpName));
                command.Parameters.Add(new SqlParameter("@Client", stClient));
                command.Parameters.Add(new SqlParameter("@Dept", stDept));
                command.Parameters.Add(new SqlParameter("@Role", stRole));
                command.Parameters.Add(new SqlParameter("@Status", stStatus));
                command.Parameters.Add(new SqlParameter("@search", stsearch));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return ds;
    }

    public DataSet ViewTodayEmpAttendanceByClientLogin(string todaydate, string stEmpID, string stEmpName, string stClient, string stDept,
     string stRole, string stStatus, string stsearch, string companyid)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        // try
        // {
            using (SqlCommand command = new SqlCommand("ViewTodayEmpAttendanceByClientLogin", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@todaydate", todaydate));

                command.Parameters.Add(new SqlParameter("@EmpID", stEmpID));
                command.Parameters.Add(new SqlParameter("@EmpName", stEmpName));
                command.Parameters.Add(new SqlParameter("@Client", stClient));
                command.Parameters.Add(new SqlParameter("@Dept", stDept));
                command.Parameters.Add(new SqlParameter("@Role", stRole));
                command.Parameters.Add(new SqlParameter("@Status", stStatus));
                command.Parameters.Add(new SqlParameter("@search", stsearch));
                command.Parameters.Add(new SqlParameter("@companyid", companyid));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
            }
            cnn.Close();
        // }
        // catch (Exception ex)
        // {
        // }
        return ds;
    }

    public DataSet ViewKycDocStausCountByAdmin(string stEmpID, string stEmpName)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewKycDocStausCountByAdmin", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@EmpID", stEmpID));
                command.Parameters.Add(new SqlParameter("@EmpName", stEmpName));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return ds;
    }
    public int AddPolicy(AdminEmp empadmin)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("AddPolicy", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@Title", empadmin.Title));
                command.Parameters.Add(new SqlParameter("@Content", empadmin.Content));
                command.Parameters.Add(new SqlParameter("@ActiveStatus", empadmin.ActiveStatus));
                command.Parameters.Add(new SqlParameter("@AddedBy", empadmin.AddedBy));
                command.Parameters.Add(new SqlParameter("@AddedDate", empadmin.AddedDate));

                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }

    public int UpdatePolicy(AdminEmp empadmin)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdatePolicy", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@Title", empadmin.Title));
                command.Parameters.Add(new SqlParameter("@Content", empadmin.Content));
                command.Parameters.Add(new SqlParameter("@ActiveStatus", empadmin.ActiveStatus));
                command.Parameters.Add(new SqlParameter("@UpdatedBy", empadmin.UpdatedBy));
                command.Parameters.Add(new SqlParameter("@UpdatedDate", empadmin.UpdatedDate));
                command.Parameters.Add(new SqlParameter("@Sno", empadmin.Sno));

                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }

    public DataSet ViewPolicyById(int Sno)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewPolicyById", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Sno", Sno));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return ds;
    }

    public DataSet ViewPolicy()
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewPolicy", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return ds;
    }
    
    public int DeletePolicy(int Sno)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("DeletePolicy", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Sno", Sno));

                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }

    public DataSet ViewApprovedEmpDetails(string stEmpID, string stEmpName, string stClient, string stDept, string stRole, string stattendtype, string stsearch)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewApprovedEmpDetails", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@EmpID", stEmpID));
                command.Parameters.Add(new SqlParameter("@EmpName", stEmpName));
                command.Parameters.Add(new SqlParameter("@Client", stClient));
                command.Parameters.Add(new SqlParameter("@Dept", stDept));
                command.Parameters.Add(new SqlParameter("@Role", stRole));
                command.Parameters.Add(new SqlParameter("@AttendType", stattendtype));
                command.Parameters.Add(new SqlParameter("@search", stsearch));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return ds;
    }
    public DataSet ViewDisApprovedEmpDetails(string stEmpID, string stEmpName, string stClient, string stDept, string stRole, string stattendtype, string stsearch)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewDisApprovedEmpDetails", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@EmpID", stEmpID));
                command.Parameters.Add(new SqlParameter("@EmpName", stEmpName));
                command.Parameters.Add(new SqlParameter("@Client", stClient));
                command.Parameters.Add(new SqlParameter("@Dept", stDept));
                command.Parameters.Add(new SqlParameter("@Role", stRole));
                command.Parameters.Add(new SqlParameter("@AttendType", stattendtype));
                command.Parameters.Add(new SqlParameter("@search", stsearch));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return ds;
    }

    public int AddBroadcast(AdminEmp empadmin,ref int ID)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("AddBroadcast", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
               
                command.Parameters.Add(new SqlParameter("@Client", empadmin.Client));
                command.Parameters.Add(new SqlParameter("@Dept", empadmin.Dept));
                command.Parameters.Add(new SqlParameter("@Role", empadmin.Role));
                command.Parameters.Add(new SqlParameter("@Title", empadmin.Title));
                command.Parameters.Add(new SqlParameter("@Content", empadmin.Content));
                command.Parameters.Add(new SqlParameter("@AddedBy", empadmin.AddedBy));
                command.Parameters.Add(new SqlParameter("@AddedDate", empadmin.AddedDate));


                command.Parameters.Add("@ID", SqlDbType.Int);
                command.Parameters["@ID"].Direction = ParameterDirection.Output;
                rowsAffected = int.Parse(command.ExecuteNonQuery().ToString());

                ID = Convert.ToInt32(command.Parameters["@ID"].Value);
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }
    public int AddBroadcastHistory(AdminEmp empadmin)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("AddBroadcastHistory", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@EmpID", empadmin.EmpID));
                command.Parameters.Add(new SqlParameter("@BroadcastID", empadmin.BroadcastID));
                command.Parameters.Add(new SqlParameter("@BroadcastDate", empadmin.AddedDate));
                command.Parameters.Add(new SqlParameter("@BroadcastNotify", empadmin.BroadcastNotify));

                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }
    public DataSet ViewBroadcast()
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewBroadcast", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return ds;
    }
    public DataSet ViewBroadcastById(string ID)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewBroadcastById", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@BroadcastID", ID));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return ds;
    }
    public int UpdateBroadcast(AdminEmp empadmin,string ID)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateBroadcast", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@Client", empadmin.Client));
                command.Parameters.Add(new SqlParameter("@Dept", empadmin.Dept));
                command.Parameters.Add(new SqlParameter("@Role", empadmin.Role));
                command.Parameters.Add(new SqlParameter("@Title", empadmin.Title));
                command.Parameters.Add(new SqlParameter("@Content", empadmin.Content));
                command.Parameters.Add(new SqlParameter("@AddedBy", empadmin.AddedBy));
                command.Parameters.Add(new SqlParameter("@AddedDate", empadmin.AddedDate));
                command.Parameters.Add(new SqlParameter("@ID", ID));

                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }

    public DataSet ViewBroadcastHistory()
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewBroadcastHistory", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return ds;
    }

    public DataSet ViewNotRegEmp(string stEmpID, string stEmpName, string stClient, string stDept, string stRole, string stattendtype, string stsearch)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewNotRegEmp", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@EmpID", stEmpID));
                command.Parameters.Add(new SqlParameter("@EmpName", stEmpName));
                command.Parameters.Add(new SqlParameter("@Client", stClient));
                command.Parameters.Add(new SqlParameter("@Dept", stDept));
                command.Parameters.Add(new SqlParameter("@Role", stRole));
                command.Parameters.Add(new SqlParameter("@AttendType", stattendtype));
                command.Parameters.Add(new SqlParameter("@search", stsearch));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return ds;
    }

    public DataSet ViewPendingEmpInformSheetByAdmin(string stEmpID, string stEmpName, string stClient, string stDept, string stRole, string stattendtype, string stsearch)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewPendingEmpInformSheetByAdmin", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@EmpID", stEmpID));
                command.Parameters.Add(new SqlParameter("@EmpName", stEmpName));
                command.Parameters.Add(new SqlParameter("@Client", stClient));
                command.Parameters.Add(new SqlParameter("@Dept", stDept));
                command.Parameters.Add(new SqlParameter("@Role", stRole));
                command.Parameters.Add(new SqlParameter("@AttendType", stattendtype));
                command.Parameters.Add(new SqlParameter("@search", stsearch));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return ds;
    }

    public string GetOBOName()
    {
        string strEmpName = string.Empty;
        try
        {
            if (HttpContext.Current.Session["OBOUserName"] != null)
            {
                strEmpName = Convert.ToString(HttpContext.Current.Session["OBOUserName"]);
            }
            if (string.IsNullOrEmpty(strEmpName))
            {
                if (HttpContext.Current.Request.Cookies["OBOLOGIN"] != null)
                {
                    System.Web.HttpCookie Logincookie = HttpContext.Current.Request.Cookies["OBOLOGIN"];
                    strEmpName = Logincookie["OBOUserName"];
                }
            }
        }
        catch
        {
        }
        return strEmpName;
    }

    public string GetOBORole()
    {
        string strRole = string.Empty;
        try
        {
            if (HttpContext.Current.Session["OBORole"] != null)
            {
                strRole = Convert.ToString(HttpContext.Current.Session["OBORole"]);
            }
            if (string.IsNullOrEmpty(strRole))
            {
                if (HttpContext.Current.Request.Cookies["OBOLOGIN"] != null)
                {
                    System.Web.HttpCookie Logincookie = HttpContext.Current.Request.Cookies["OBOLOGIN"];
                    strRole = Logincookie["OBORole"];
                }
            }
        }
        catch
        {
        }
        return strRole;
    }

    public string GetPRName()
    {
        string strEmpName = string.Empty;
        try
        {
            if (HttpContext.Current.Session["PRUserName"] != null)
            {
                strEmpName = Convert.ToString(HttpContext.Current.Session["PRUserName"]);
            }
            if (string.IsNullOrEmpty(strEmpName))
            {
                if (HttpContext.Current.Request.Cookies["PRLOGIN"] != null)
                {
                    System.Web.HttpCookie Logincookie = HttpContext.Current.Request.Cookies["PRLOGIN"];
                    strEmpName = Logincookie["PRUserName"];
                }
            }
        }
        catch
        {
        }
        return strEmpName;
    }

    public string GetPRRole()
    {
        string strRole = string.Empty;
        try
        {
            if (HttpContext.Current.Session["PRRole"] != null)
            {
                strRole = Convert.ToString(HttpContext.Current.Session["PRRole"]);
            }
            if (string.IsNullOrEmpty(strRole))
            {
                if (HttpContext.Current.Request.Cookies["PRLOGIN"] != null)
                {
                    System.Web.HttpCookie Logincookie = HttpContext.Current.Request.Cookies["PRLOGIN"];
                    strRole = Logincookie["PRRole"];
                }
            }
        }
        catch
        {
        }
        return strRole;
    }

    public string GetOBOID()
    {
        string strAdminID = string.Empty;
        try
        {
            if (HttpContext.Current.Session["OBOID"] != null)
            {
                strAdminID = Convert.ToString(HttpContext.Current.Session["OBOID"]);
            }
            if (string.IsNullOrEmpty(strAdminID))
            {
                if (HttpContext.Current.Request.Cookies["OBOLOGIN"] != null)
                {
                    System.Web.HttpCookie Logincookie = HttpContext.Current.Request.Cookies["OBOLOGIN"];
                    strAdminID = Logincookie["OBOID"];
                }
            }
        }
        catch
        {
        }
        return strAdminID;
    }

    public string GetOBOEmailId()
    {
        string strEmailId = string.Empty;
        try
        {
            if (HttpContext.Current.Session["OBOEmailId"] != null)
            {
                strEmailId = Convert.ToString(HttpContext.Current.Session["OBOEmailId"]);
            }
            if (string.IsNullOrEmpty(strEmailId))
            {
                if (HttpContext.Current.Request.Cookies["OBOLOGIN"] != null)
                {
                    System.Web.HttpCookie Logincookie = HttpContext.Current.Request.Cookies["OBOLOGIN"];
                    strEmailId = Logincookie["OBOEmailId"];
                }
            }
        }
        catch
        {
        }
        return strEmailId;
    }
    public string GetPREmailId()
    {
        string strEmailId = string.Empty;
        try
        {
            if (HttpContext.Current.Session["PREmailId"] != null)
            {
                strEmailId = Convert.ToString(HttpContext.Current.Session["PREmailId"]);
            }
            if (string.IsNullOrEmpty(strEmailId))
            {
                if (HttpContext.Current.Request.Cookies["PRLOGIN"] != null)
                {
                    System.Web.HttpCookie Logincookie = HttpContext.Current.Request.Cookies["PRLOGIN"];
                    strEmailId = Logincookie["PREmailId"];
                }
            }
        }
        catch
        {
        }
        return strEmailId;
    }

    public DataSet ViewAllEmpforAccess(string stClient, string stDept, string stlevel, string stzone, string stsearch)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewAllEmpforAccess", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@Client", stClient));
                command.Parameters.Add(new SqlParameter("@Dept", stDept));
                command.Parameters.Add(new SqlParameter("@Role", stlevel));
                command.Parameters.Add(new SqlParameter("@Zone", stzone));
                command.Parameters.Add(new SqlParameter("@search", stsearch));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return ds;
    }

    public int UpdateEmpRoleByEmpID(AdminEmp empadmin)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateEmpRoleByEmpID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@EmpID", empadmin.EmpID));
                command.Parameters.Add(new SqlParameter("@EmpRole", empadmin.EmpRole));
                

                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }
}