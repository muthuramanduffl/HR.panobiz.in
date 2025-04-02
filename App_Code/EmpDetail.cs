using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.IO;

/// <summary>
/// Summary description for EmpDetail
/// </summary>
public class EmpDetail
{

    public int Sno { get; set; }
    public string EmpID { get; set; }
    public string EmailId { get; set; }
    public string Mobile { get; set; }
    public string AddedBy { get; set; }
    public DateTime AddedDate { get; set; }
    public string UpdatedBy { get; set; }
    public DateTime UpdatedDate { get; set; }
    public string Photo { get; set; }
    public string SSLCmark { get; set; }
    public string HSCmark { get; set; }
    public string graduationmark { get; set; }
    public string Resume { get; set; }
    public string PreApptmentletter { get; set; }
    public string ExpRelievingLetter { get; set; }
    public string ResignAcceptLetter { get; set; }
    public string PreviousPayslip { get; set; }
    public string BCCertificate { get; set; }
    public string Aadharcard { get; set; }
    public string Pancard { get; set; }
    public string Currentresidence { get; set; }
    public string SignUpload { get; set; }
    public bool Notify { get; set; }
    public string Activity1 { get; set; }
    public string Activity2 { get; set; }
    public string Activity3 { get; set; }
    public string Activity4 { get; set; }
    public string Activity5 { get; set; }
    public string Activity6 { get; set; }
    public string Activity7 { get; set; }
    public string Activity8 { get; set; }

    public bool KYCDOCNotify { get; set; }
    public DateTime KYCDOCnotifyDate { get; set; }
    public string Seenstatus { get; set; }
    public string Path { get; set; }
    public EmpDetail()
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

    public string GetEmpId()
    {
        string strEmpId = string.Empty;
        try
        {
            if (HttpContext.Current.Session["EmpEmpId"] != null)
            {
                strEmpId = Convert.ToString(HttpContext.Current.Session["EmpEmpId"]);
            }
            if (string.IsNullOrEmpty(strEmpId))
            {
                if (HttpContext.Current.Request.Cookies["EmpLOGIN"] != null)
                {
                    System.Web.HttpCookie Logincookie = HttpContext.Current.Request.Cookies["EmpLOGIN"];
                    strEmpId = Logincookie["EmpEmpId"];
                }
            }
        }
        catch
        {
        }
        return strEmpId;
    }
    public string GetCandidateID()
    {
        string strcandId = string.Empty;
        try
        {
            if (HttpContext.Current.Session["EmpCandId"] != null)
            {
                strcandId = Convert.ToString(HttpContext.Current.Session["EmpCandId"]);
            }
            if (string.IsNullOrEmpty(strcandId))
            {
                if (HttpContext.Current.Request.Cookies["EmpLOGIN"] != null)
                {
                    System.Web.HttpCookie Logincookie = HttpContext.Current.Request.Cookies["EmpLOGIN"];
                    strcandId = Logincookie["EmpCandId"];
                }
            }
        }
        catch
        {
        }
        return strcandId;
    }
    
    public string GetEmpName()
    {
        string strEmpName = string.Empty;
        try
        {
            if (HttpContext.Current.Session["EmpName"] != null)
            {
                strEmpName = Convert.ToString(HttpContext.Current.Session["EmpName"]);
            }
            if (string.IsNullOrEmpty(strEmpName))
            {
                if (HttpContext.Current.Request.Cookies["EmpLOGIN"] != null)
                {
                    System.Web.HttpCookie Logincookie = HttpContext.Current.Request.Cookies["EmpLOGIN"];
                    strEmpName = Logincookie["EmpName"];
                }
            }
        }
        catch
        {
        }
        return strEmpName;
    }
    public int AddKYCDoc(EmpDetail empdoc)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("AddKYCDoc", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmpId", empdoc.EmpID));
                command.Parameters.Add(new SqlParameter("@Photo", empdoc.Photo));
                command.Parameters.Add(new SqlParameter("@SSLCmark", empdoc.SSLCmark));
                command.Parameters.Add(new SqlParameter("@HSCmark", empdoc.HSCmark));
                command.Parameters.Add(new SqlParameter("@graduationmark", empdoc.graduationmark));
                command.Parameters.Add(new SqlParameter("@Resume", empdoc.Resume));
                command.Parameters.Add(new SqlParameter("@PreApptmentletter", empdoc.PreApptmentletter));
                command.Parameters.Add(new SqlParameter("@ExpRelievingLetter", empdoc.ExpRelievingLetter));
                command.Parameters.Add(new SqlParameter("@ResignAcceptLetter", empdoc.ResignAcceptLetter));
                command.Parameters.Add(new SqlParameter("@Previouspayslip", empdoc.PreviousPayslip));
                command.Parameters.Add(new SqlParameter("@BCCertificate", empdoc.BCCertificate));
                command.Parameters.Add(new SqlParameter("@Aadharcard", empdoc.Aadharcard));
                command.Parameters.Add(new SqlParameter("@Pancard", empdoc.Pancard));
                command.Parameters.Add(new SqlParameter("@Currentresidence", empdoc.Currentresidence));
                command.Parameters.Add(new SqlParameter("@AddedDate", empdoc.AddedDate));
                command.Parameters.Add(new SqlParameter("@Notify", empdoc.Notify));
                command.Parameters.Add(new SqlParameter("@SignUpload", empdoc.SignUpload));

                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }
    public int UpdateCandidateKYCDoc(EmpDetail empdoc)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateCandidateKYCDoc", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ID", empdoc.EmpID));
                command.Parameters.Add(new SqlParameter("@Photo", empdoc.Photo));
                command.Parameters.Add(new SqlParameter("@SSLCmark", empdoc.SSLCmark));
                command.Parameters.Add(new SqlParameter("@HSCmark", empdoc.HSCmark));
                command.Parameters.Add(new SqlParameter("@graduationmark", empdoc.graduationmark));
                command.Parameters.Add(new SqlParameter("@Resume", empdoc.Resume));
                command.Parameters.Add(new SqlParameter("@PreApptmentletter", empdoc.PreApptmentletter));
                command.Parameters.Add(new SqlParameter("@ExpRelievingLetter", empdoc.ExpRelievingLetter));
                command.Parameters.Add(new SqlParameter("@ResignAcceptLetter", empdoc.ResignAcceptLetter));
                command.Parameters.Add(new SqlParameter("@Previouspayslip", empdoc.PreviousPayslip));
                command.Parameters.Add(new SqlParameter("@BCCertificate", empdoc.BCCertificate));
                command.Parameters.Add(new SqlParameter("@Aadharcard", empdoc.Aadharcard));
                command.Parameters.Add(new SqlParameter("@Pancard", empdoc.Pancard));
                command.Parameters.Add(new SqlParameter("@Currentresidence", empdoc.Currentresidence));
                command.Parameters.Add(new SqlParameter("@UpdatedDate", empdoc.UpdatedDate));
                command.Parameters.Add(new SqlParameter("@UpdatedBy", empdoc.UpdatedBy));
                //command.Parameters.Add(new SqlParameter("@Notify", empdoc.Notify));
                command.Parameters.Add(new SqlParameter("@SignUpload", empdoc.SignUpload));

                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }

    public DataSet ViewKYCDoc(string stEmpID)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewKYCDoc", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmpID", stEmpID));
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
    public DataSet ViewKYCDocbyCandID(string stEmpID)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewKYCDocbyCandID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmpID", stEmpID));
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

    public int UpdateKYCDoc(EmpDetail empdoc)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateKYCDoc", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmpId", empdoc.EmpID));
                command.Parameters.Add(new SqlParameter("@Photo", empdoc.Photo));
                command.Parameters.Add(new SqlParameter("@SSLCmark", empdoc.SSLCmark));
                command.Parameters.Add(new SqlParameter("@HSCmark", empdoc.HSCmark));
                command.Parameters.Add(new SqlParameter("@graduationmark", empdoc.graduationmark));
                command.Parameters.Add(new SqlParameter("@Resume", empdoc.Resume));
                command.Parameters.Add(new SqlParameter("@PreApptmentletter", empdoc.PreApptmentletter));
                command.Parameters.Add(new SqlParameter("@ExpRelievingLetter", empdoc.ExpRelievingLetter));
                command.Parameters.Add(new SqlParameter("@ResignAcceptLetter", empdoc.ResignAcceptLetter));
                command.Parameters.Add(new SqlParameter("@Previouspayslip", empdoc.PreviousPayslip));
                command.Parameters.Add(new SqlParameter("@BCCertificate", empdoc.BCCertificate));
                command.Parameters.Add(new SqlParameter("@Aadharcard", empdoc.Aadharcard));
                command.Parameters.Add(new SqlParameter("@Pancard", empdoc.Pancard));
                command.Parameters.Add(new SqlParameter("@Currentresidence", empdoc.Currentresidence));
                command.Parameters.Add(new SqlParameter("@UpdatedDate", empdoc.UpdatedDate));
                command.Parameters.Add(new SqlParameter("@Notify", empdoc.Notify));
                command.Parameters.Add(new SqlParameter("@SignUpload", empdoc.SignUpload));

                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }

    public int AddActivity(EmpDetail empdoc)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("AddActivity", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmpId", empdoc.EmpID));
                command.Parameters.Add(new SqlParameter("@Activity1", empdoc.Activity1));
                command.Parameters.Add(new SqlParameter("@Activity2", empdoc.Activity2));
                command.Parameters.Add(new SqlParameter("@Activity3", empdoc.Activity3));
                command.Parameters.Add(new SqlParameter("@Activity4", empdoc.Activity4));
                command.Parameters.Add(new SqlParameter("@Activity5", empdoc.Activity5));
                command.Parameters.Add(new SqlParameter("@Activity6", empdoc.Activity6));
                command.Parameters.Add(new SqlParameter("@Activity7", empdoc.Activity7));
                command.Parameters.Add(new SqlParameter("@Activity8", empdoc.Activity8));
                command.Parameters.Add(new SqlParameter("@AddedDate", empdoc.AddedDate));

                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }

    public int UpdateActivity(EmpDetail empdoc,int Sno)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateActivity", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmpId", empdoc.EmpID));
                command.Parameters.Add(new SqlParameter("@Activity1", empdoc.Activity1));
                command.Parameters.Add(new SqlParameter("@Activity2", empdoc.Activity2));
                command.Parameters.Add(new SqlParameter("@Activity3", empdoc.Activity3));
                command.Parameters.Add(new SqlParameter("@Activity4", empdoc.Activity4));
                command.Parameters.Add(new SqlParameter("@Activity5", empdoc.Activity5));
                command.Parameters.Add(new SqlParameter("@Activity6", empdoc.Activity6));
                command.Parameters.Add(new SqlParameter("@Activity7", empdoc.Activity7));
                command.Parameters.Add(new SqlParameter("@Activity8", empdoc.Activity8));
                command.Parameters.Add(new SqlParameter("@UpdatedDate", empdoc.UpdatedDate));
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

    public DataSet ViewDailyActivity(string stEmpID,int Sno)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewDailyActivity", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmpID", stEmpID));
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

    public DataSet ViewAllDailyActivity(string stEmpID,string FromDate,string ToDate)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewAllDailyActivity", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmpID", stEmpID));
                command.Parameters.Add(new SqlParameter("@FromDate", FromDate));
                command.Parameters.Add(new SqlParameter("@ToDate", ToDate));
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

    public DataSet ViewTwoDaysDailyActivity(string stEmpID,string CurrentDate)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewTwoDaysDailyActivity", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmpID", stEmpID));
                command.Parameters.Add(new SqlParameter("@AddedDate", CurrentDate));
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

    public DataSet ViewAllDailyAttendance(string stEmpID,string FromDate,string ToDate)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewAllDailyAttendance", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmpID", stEmpID));
                command.Parameters.Add(new SqlParameter("@FromDate", FromDate));
                command.Parameters.Add(new SqlParameter("@ToDate", ToDate));
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

    public DataSet ViewEmpDetailByEmpID(string stEmpID)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewEmpDetailByEmpID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmpID", stEmpID));
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
    
    public DataSet ViewEmpDailyAttendance(string stEmpID)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewEmpDailyAttendance", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmpID", stEmpID));
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

    public DataSet ViewDailyActivityExistByDate(string stEmpID, DateTime straddeddate)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewDailyActivityExistByDate", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmpID", stEmpID));
                command.Parameters.Add(new SqlParameter("@AddedDate", straddeddate));
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

    public string GetSupEmpId()
    {
        string strEmpId = string.Empty;
        try
        {
            if (HttpContext.Current.Session["SEmpEmpId"] != null)
            {
                strEmpId = Convert.ToString(HttpContext.Current.Session["SEmpEmpId"]);
            }
            if (string.IsNullOrEmpty(strEmpId))
            {
                if (HttpContext.Current.Request.Cookies["SEmpLOGIN"] != null)
                {
                    System.Web.HttpCookie Logincookie = HttpContext.Current.Request.Cookies["SEmpLOGIN"];
                    strEmpId = Logincookie["SEmpEmpId"];
                }
            }
        }
        catch
        {
        }
        return strEmpId;
    }
    public string GetSupCandidateID()
    {
        string strCandId = string.Empty;
        try
        {
            if (HttpContext.Current.Session["SEmpCandId"] != null)
            {
                strCandId = Convert.ToString(HttpContext.Current.Session["SEmpCandId"]);
            }
            if (string.IsNullOrEmpty(strCandId))
            {
                if (HttpContext.Current.Request.Cookies["SEmpLOGIN"] != null)
                {
                    System.Web.HttpCookie Logincookie = HttpContext.Current.Request.Cookies["SEmpLOGIN"];
                    strCandId = Logincookie["SEmpCandId"];
                }
            }
        }
        catch
        {
        }
        return strCandId;
    }
    public string GetSupEmpName()
    {
        string strEmpName = string.Empty;
        try
        {
            if (HttpContext.Current.Session["SEmpName"] != null)
            {
                strEmpName = Convert.ToString(HttpContext.Current.Session["SEmpName"]);
            }
            if (string.IsNullOrEmpty(strEmpName))
            {
                if (HttpContext.Current.Request.Cookies["SEmpLOGIN"] != null)
                {
                    System.Web.HttpCookie Logincookie = HttpContext.Current.Request.Cookies["SEmpLOGIN"];
                    strEmpName = Logincookie["SEmpName"];
                }
            }
        }
        catch
        {
        }
        return strEmpName;
    }
	
	public DataSet ViewEmployeeListBySupervisorID(string stSupervisorID)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewEmployeeListBySupervisorID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@SupervisorID", stSupervisorID));
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

    public int UpdateEmpKYCDocNotification(EmpDetail empdoc)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateEmpKYCDocNotification", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmpId", empdoc.EmpID));
                command.Parameters.Add(new SqlParameter("@Notify", empdoc.KYCDOCNotify));
                command.Parameters.Add(new SqlParameter("@UpdatedDate", empdoc.KYCDOCnotifyDate));

                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }


    public DataSet ViewEmployeeListBySupervisorIDwithFilter(string stSupervisorID, string stEmpID, string stEmpName, string stClient, string stDept,
        string stRole, string stsearch)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewEmployeeListBySupervisorIDwithFilter", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@SupervisorID", stSupervisorID));

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

    public DataSet SupViewAttendanceReport(string stSupervisorID, string stEmpID, string stEmpName, string stClient, string stDept,
      string stRole, string stsearch)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("SupViewAttendanceReport", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@SupervisorID", stSupervisorID));

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

    public DataSet SupViewAttendanceReportnew(string stSupervisorID, string stEmpID, string stEmpName, string stsearch)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("SupViewAttendanceReportnew", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@SupervisorID", stSupervisorID));

                command.Parameters.Add(new SqlParameter("@EmpID", stEmpID));
                command.Parameters.Add(new SqlParameter("@EmpName", stEmpName));
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

    public DataSet ViewDept()
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewDept", cnn))
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

    public DataSet ViewClientName()
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewClientName", cnn))
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

    public DataSet SupViewLeaveRequestReport(string stSupervisorID, string stEmpID, string stEmpName, string stClient, string stDept,
     string stRole, string stsearch,string flag)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("SupViewLeaveRequestReport", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@SupervisorID", stSupervisorID));

                command.Parameters.Add(new SqlParameter("@EmpID", stEmpID));
                command.Parameters.Add(new SqlParameter("@EmpName", stEmpName));
                command.Parameters.Add(new SqlParameter("@Client", stClient));
                command.Parameters.Add(new SqlParameter("@Dept", stDept));
                command.Parameters.Add(new SqlParameter("@Role", stRole));
                command.Parameters.Add(new SqlParameter("@search", stsearch));
                command.Parameters.Add(new SqlParameter("@flag", flag));
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

    public DataSet SupViewLeaveRequestReportModify(string stSupervisorID, string stEmpID, string stEmpName, string stClient, string stDept,
   string stRole, string stsearch, string flag, string todaydate)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("SupViewLeaveRequestReportModify", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@SupervisorID", stSupervisorID));

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
    public DataSet ViewKYCDocNotification(string stEmpID)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewKYCDocNotification", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmpID", stEmpID));
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
    public int UpdateNotifyForKYCDOC(string empID)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateNotifyForKYCDOC", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@EmpID", empID));

                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }

    public DataSet ViewSupervisorList()
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewSupervisorList", cnn))
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


    public void SendMail(string subject, string body, string stTomail)
    {
        try
        {
            var SmtpClient = new SmtpClient();
            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
            message.From = new MailAddress("inputsfrom@sitequery.info", subject);
            message.Subject = subject;
            //message.To.Add(stTomail);
            message.To.Add("selvi@duffldigital.com");
            //message.Bcc.Add("veni@duffldigital.com");
            message.Body = body;
            message.IsBodyHtml = true;
            SmtpClient.EnableSsl = false;
            SmtpClient.Send(message);

        }
        catch (Exception ex)
        {

        }
    }

    public void SendSMS(string stMsg, string stMobileNo, string stEmpID)
    {
        try
        {
            string Message = stMsg;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://alerts.qikberry.com/api/v2/sms/send?access_token=2640d057bd8f5408f35f5bfd3106fc81&message=" + HttpUtility.UrlEncode(Message) + "&sender=Panobiz&to=" + stMobileNo + "&service=T&entity_id=1601100000000003960&template_id=1607100000000209953");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader readStream = new StreamReader(responseStream, Encoding.UTF8);
            var _Result = readStream.ReadToEnd();
        }
        catch (Exception ex)
        {
        }
    }
    public string GetSupervisor(string stEmpID)
    {
        string str = string.Empty;
        DataSet ds = ViewEmpDetailByEmpID(stEmpID);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            str = ds.Tables[0].Rows[0]["supervisor1"].ToString();
        return str;
    }
    public string GetEmailID(string stEmpID)
    {
        string str = string.Empty;
        DataSet ds = ViewEmpDetailByEmpID(stEmpID);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            str = ds.Tables[0].Rows[0]["EmailId"].ToString();
        return str;
    }

    public DataSet ViewEmpInformSheetByEmpID(string stEmpID)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewEmpInformSheetByEmpID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmpID", stEmpID));
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

    public int AddEmpInformSheet(string EmpId,string stFile)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("AddEmpInformSheet", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmpId", EmpId));
                command.Parameters.Add(new SqlParameter("@InformFilename", stFile));
                command.Parameters.Add(new SqlParameter("@UpdatedDate", Utility.IndianTime));

                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }

    public int UpdateEmpInformSheet(string EmpId, string stFile)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateEmpInformSheet", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmpId", EmpId));
                command.Parameters.Add(new SqlParameter("@InformFilename", stFile));
                command.Parameters.Add(new SqlParameter("@UpdatedDate", Utility.IndianTime));

                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }

    public int UpdateSeenStatus(EmpDetail empdoc)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateSeenStatus", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Sno", empdoc.Sno));
                command.Parameters.Add(new SqlParameter("@Seenstatus", empdoc.Seenstatus));

                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }

    public int AddKycDocStatusHistory(string stEmpID, string stcolname, string ststatus, string strupdatedby)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("AddKycDocStatusHistory", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmpID", stEmpID));
                command.Parameters.Add(new SqlParameter("@colname", stcolname));
                command.Parameters.Add(new SqlParameter("@status", ststatus));
                command.Parameters.Add(new SqlParameter("@updatedby", strupdatedby));
                command.Parameters.Add(new SqlParameter("@updateddate", Utility.IndianTime));

                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }
    public int UpdateKycDocStatusHistory(string stEmpID, string stcolname, string ststatus, string strupdatedby)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateKycDocStatusHistory", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmpID", stEmpID));
                command.Parameters.Add(new SqlParameter("@colname", stcolname));
                command.Parameters.Add(new SqlParameter("@status", ststatus));
                command.Parameters.Add(new SqlParameter("@updatedby", strupdatedby));
                command.Parameters.Add(new SqlParameter("@updateddate", Utility.IndianTime));

                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }

    public DataSet ViewKycDocStatusHistory(string stEmpID,string stcolname)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewKycDocStatusHistory", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmpID", stEmpID));
                command.Parameters.Add(new SqlParameter("@colname", stcolname));
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

    public DataSet ViewKYCDocStatusHistorybyEmpID(string stEmpID)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewKYCDocStatusHistorybyEmpID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmpID", stEmpID));
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
    public DataSet ViewBroadcastNotification(string stEmpID)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewBroadcastNotification", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmpId", stEmpID));
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
    public int UpdateNotifyForBroadcast(string empID)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateNotifyForBroadcast", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@EmpID", empID));

                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }

    public DataSet ViewBirthdayTablebyMonth(string stMonth, string currentDate,string SupempId)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewBirthdayTablebyMonth", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Month", stMonth));
                command.Parameters.Add(new SqlParameter("@CurrentDate", currentDate));
                command.Parameters.Add(new SqlParameter("@Supervisor1", SupempId));
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
    public DataSet ViewHolidayListByStateID(string stateID)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewHolidayListByStateID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@StateID", stateID));
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
    public DataSet ViewStateByEmpID(string EmpID)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewStateByEmpID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmpID", EmpID));
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
}