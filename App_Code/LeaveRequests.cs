using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for EmpDetail
/// </summary>
public class LeaveRequests
{
    public int Sno { get; set; }
    public string EmpID { get; set; }
    public string LeaveFor { get; set; }
    public DateTime LeaveFromdate { get; set; }
    public DateTime LeaveTodate { get; set; }
    public string TimeForHalfDay { get; set; }
    public string LeaveType { get; set; }
    public string Reason { get; set; }
    public DateTime AppliedDate { get; set; }
    public bool NotifySupervisor { get; set; }
    public string LeaveRequestStatus { get; set; }
    public DateTime ApprovedDate { get; set; }
    public bool NotifyUser { get; set; }
    public string ApprovedBy { get; set; }
    
    public LeaveRequests()
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

    public int AddApplyLeave(LeaveRequests req)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("AddApplyLeave", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@EmpID", req.EmpID));
                command.Parameters.Add(new SqlParameter("@LeaveFor", req.LeaveFor));
                command.Parameters.Add(new SqlParameter("@LeaveFromdate", req.LeaveFromdate));
                command.Parameters.Add(new SqlParameter("@LeaveTodate", req.LeaveTodate));
                command.Parameters.Add(new SqlParameter("@TimeForHalfDay", req.TimeForHalfDay));
                command.Parameters.Add(new SqlParameter("@LeaveType", req.LeaveType));
                command.Parameters.Add(new SqlParameter("@Reason", req.Reason));
                command.Parameters.Add(new SqlParameter("@AppliedDate", req.AppliedDate));
                command.Parameters.Add(new SqlParameter("@NotifySupervisor", req.NotifySupervisor));
                command.Parameters.Add(new SqlParameter("@LeaveRequestStatus", req.LeaveRequestStatus));

                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }
    public DataSet ViewEmployeeLeaveDetails(string stEmpID, string FromDate, string ToDate)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewEmployeeLeaveDetails", cnn))
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

    public DataSet ViewLeaveDateExist(string stEmpID, string fromdate)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewLeaveDateExist", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmpID", stEmpID));
                command.Parameters.Add(new SqlParameter("@LeaveFromDate", fromdate));
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

    public int DeleteLeaveEmpDetail(int sno)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("DeleteLeaveEmpDetail", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@sno", sno));

                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }

    public DataSet ViewLeaveRequestStatus(string stEmpID)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewLeaveRequestStatus", cnn))
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

    public int UpdateNotifyUser(string empID)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateNotifyUser", cnn))
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
    
    public DataSet ViewEmployeeLeaveRequestsBySupervisorID(string stSupervisorID)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewEmployeeLeaveRequestsBySupervisorID", cnn))
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

    public int UpdateLeaveRequestStatus(LeaveRequests req)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateLeaveRequestStatus", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@EmpID", req.EmpID));
                command.Parameters.Add(new SqlParameter("@sno", req.Sno));
                command.Parameters.Add(new SqlParameter("@ApprovedDate", req.ApprovedDate));
                command.Parameters.Add(new SqlParameter("@ApprovedBy", req.ApprovedBy));
                command.Parameters.Add(new SqlParameter("@NotifyUser", req.NotifyUser));
                command.Parameters.Add(new SqlParameter("@NotifySupervisor", req.NotifySupervisor));
                command.Parameters.Add(new SqlParameter("@LeaveRequestStatus", req.LeaveRequestStatus));

                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }

    public DataSet ViewEmployeeLeaveDetailsSup(string stEmpID, string FromDate, string ToDate, string strleavestatus,string stSupEmpID)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewEmployeeLeaveDetailsSup", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmpID", stEmpID));
                command.Parameters.Add(new SqlParameter("@FromDate", FromDate));
                command.Parameters.Add(new SqlParameter("@ToDate", ToDate));
                command.Parameters.Add(new SqlParameter("@leavestatus", strleavestatus));
                command.Parameters.Add(new SqlParameter("@SupEmpID", stSupEmpID));
                
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

    public DataSet ViewEmpLeaveReqBySupWithFilter(string stSupervisorID,string stEmpID, string stEmpName, string stClient, string stDept,
     string stRole, string stsearch, string strleavetype, string strFromDate, string strToDate)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewEmpLeaveReqBySupWithFilter", cnn))
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

    public DataSet ViewEmpLeaveReqBySupWithFilternew(string stSupervisorID,string stEmpID, string stEmpName, string stsearch, string strleavetype, string strFromDate, string strToDate)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewEmpLeaveReqBySupWithFilternew", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@SupervisorID", stSupervisorID));
                command.Parameters.Add(new SqlParameter("@EmpID", stEmpID));
                command.Parameters.Add(new SqlParameter("@EmpName", stEmpName));
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

    public DataSet ViewLeaveRequestStatusBYSup(string stSupEmpID)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewLeaveRequestStatusBYSup", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@SupEmpID", stSupEmpID));
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
    
   public DataSet ViewLeaveRequestStatusCount(string stEmpID)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewLeaveRequestStatusCount", cnn))
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

    public DataSet ViewLeaveRequestStatusCountBYSup(string stEmpID)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewLeaveRequestStatusCountBYSup", cnn))
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

    public DataSet ViewLeaveReqIDBySup(string stEmpID)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewLeaveReqIDBySup", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@SupEmpID", stEmpID));
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

    public int UpdateLeaveReqNotifyBySup(int Sno)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateLeaveReqNotifyBySup", cnn))
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
}