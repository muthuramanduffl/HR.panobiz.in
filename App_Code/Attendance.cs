using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Attendance
/// </summary>
public class Attendance
{
    public int Sno { get; set; }
    public string EmpID { get; set; }
    public DateTime AttendanceDate { get; set; }
    public string InTime { get; set; }
    public string OutTime { get; set; }
    public string LocationInTime { get; set; }
    public string LocationOutTime { get; set; }
    public string Attendancestatus { get; set; }
    public string AddedBy { get; set; }
    public DateTime AddedDate { get; set; }
    public string UpdatedBy { get; set; }
    public DateTime UpdatedDate { get; set; }
    public string PunchINPhoto { get; set; }
    public string PunchOUTPhoto { get; set; }
    public string Geofence { get; set; }
    public string Outsidelat { get; set; }
    public string Outsidelong { get; set; }

    public Attendance()
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


    public int AddAttendance(Attendance attend)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("AddAttendance", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmpId", attend.EmpID));
                command.Parameters.Add(new SqlParameter("@AttendanceDate", attend.AttendanceDate));
                command.Parameters.Add(new SqlParameter("@InTime", attend.InTime));
                command.Parameters.Add(new SqlParameter("@OutTime", attend.OutTime));
                command.Parameters.Add(new SqlParameter("@LocationInTime", attend.LocationInTime));
                command.Parameters.Add(new SqlParameter("@LocationOutTime", attend.LocationOutTime));
                command.Parameters.Add(new SqlParameter("@Attendancestatus", attend.Attendancestatus));
                command.Parameters.Add(new SqlParameter("@AddedBy", attend.AddedBy));
                command.Parameters.Add(new SqlParameter("@AddedDate", attend.AddedDate));
               

                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }
    public int AddAttendance_SupGeo(Attendance attend)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("AddAttendance_SupGeo", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmpId", attend.EmpID));
                command.Parameters.Add(new SqlParameter("@AttendanceDate", attend.AttendanceDate));
                command.Parameters.Add(new SqlParameter("@InTime", attend.InTime));
                command.Parameters.Add(new SqlParameter("@OutTime", attend.OutTime));
                command.Parameters.Add(new SqlParameter("@LocationInTime", attend.LocationInTime));
                command.Parameters.Add(new SqlParameter("@LocationOutTime", attend.LocationOutTime));
                command.Parameters.Add(new SqlParameter("@Attendancestatus", attend.Attendancestatus));
                command.Parameters.Add(new SqlParameter("@AddedBy", attend.AddedBy));
                command.Parameters.Add(new SqlParameter("@AddedDate", attend.AddedDate));
                command.Parameters.Add(new SqlParameter("@Geofence", attend.Geofence));
                command.Parameters.Add(new SqlParameter("@Outsidelat", attend.Outsidelat));
                command.Parameters.Add(new SqlParameter("@Outsidelong", attend.Outsidelong));
               

                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }

    public int UpdateAttendance(Attendance attend)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateAttendance", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmpId", attend.EmpID));
                command.Parameters.Add(new SqlParameter("@AttendanceDate", attend.AttendanceDate));
                command.Parameters.Add(new SqlParameter("@OutTime", attend.OutTime));
                command.Parameters.Add(new SqlParameter("@LocationOutTime", attend.LocationOutTime));
                command.Parameters.Add(new SqlParameter("@UpdatedBy", attend.UpdatedBy));
                command.Parameters.Add(new SqlParameter("@UpdatedDate", attend.UpdatedDate));

                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }
    public int UpdateAttendance_SupGeo(Attendance attend)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateAttendance_SupGeo", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmpId", attend.EmpID));
                command.Parameters.Add(new SqlParameter("@AttendanceDate", attend.AttendanceDate));
                command.Parameters.Add(new SqlParameter("@OutTime", attend.OutTime));
                command.Parameters.Add(new SqlParameter("@LocationOutTime", attend.LocationOutTime));
                command.Parameters.Add(new SqlParameter("@UpdatedBy", attend.UpdatedBy));
                command.Parameters.Add(new SqlParameter("@UpdatedDate", attend.UpdatedDate));
                command.Parameters.Add(new SqlParameter("@Geofence", attend.Geofence));
                command.Parameters.Add(new SqlParameter("@Outsidelat", attend.Outsidelat));
                command.Parameters.Add(new SqlParameter("@Outsidelong", attend.Outsidelong));

                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }

    public DataSet ViewAttendanceByEmpIDAttDate(string stEmpID,DateTime todaydate)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewAttendanceByEmpIDAttDate", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmpID", stEmpID));
                command.Parameters.Add(new SqlParameter("@Attendancedate", todaydate));
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
    
    public DataSet ViewEmployeeAttendanceDetails(string stEmpID, string FromDate, string ToDate, string flag, string todaydate)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewEmployeeAttendanceDetails", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmpID", stEmpID));
                command.Parameters.Add(new SqlParameter("@FromDate", FromDate));
                command.Parameters.Add(new SqlParameter("@ToDate", ToDate));
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

    public int UpdateAttendanceBySup(Attendance attend)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateAttendanceBySup", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmpId", attend.EmpID));
                command.Parameters.Add(new SqlParameter("@AttendanceDate", attend.AttendanceDate));
                command.Parameters.Add(new SqlParameter("@AttendanceStatus", attend.OutTime));
                command.Parameters.Add(new SqlParameter("@UpdatedBy", attend.UpdatedBy));
                command.Parameters.Add(new SqlParameter("@UpdatedDate", attend.UpdatedDate));

                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }

    public int DeleteAttendanceDetailBySno(string Sno,string EmpID)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("DeleteAttendanceDetailBySno", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmpId", EmpID));
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

    public int AddAttendance_Executive(Attendance attend)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("AddAttendance_Executive", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmpId", attend.EmpID));
                command.Parameters.Add(new SqlParameter("@AttendanceDate", attend.AttendanceDate));
                command.Parameters.Add(new SqlParameter("@InTime", attend.InTime));
                command.Parameters.Add(new SqlParameter("@OutTime", attend.OutTime));
                command.Parameters.Add(new SqlParameter("@LocationInTime", attend.LocationInTime));
                command.Parameters.Add(new SqlParameter("@LocationOutTime", attend.LocationOutTime));
                command.Parameters.Add(new SqlParameter("@Attendancestatus", attend.Attendancestatus));
                command.Parameters.Add(new SqlParameter("@AddedBy", attend.AddedBy));
                command.Parameters.Add(new SqlParameter("@AddedDate", attend.AddedDate));
                command.Parameters.Add(new SqlParameter("@PunchINPhoto", attend.PunchINPhoto));
                command.Parameters.Add(new SqlParameter("@PunchOUTPhoto", attend.PunchOUTPhoto));
                command.Parameters.Add(new SqlParameter("@PunchOUTPhoto", attend.PunchOUTPhoto));

                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }

    public int AddAttendance_ExecutiveNew(Attendance attend)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("AddAttendance_ExecutiveNew", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmpId", attend.EmpID));
                command.Parameters.Add(new SqlParameter("@AttendanceDate", attend.AttendanceDate));
                command.Parameters.Add(new SqlParameter("@InTime", attend.InTime));
                command.Parameters.Add(new SqlParameter("@OutTime", attend.OutTime));
                command.Parameters.Add(new SqlParameter("@LocationInTime", attend.LocationInTime));
                command.Parameters.Add(new SqlParameter("@LocationOutTime", attend.LocationOutTime));
                command.Parameters.Add(new SqlParameter("@Attendancestatus", attend.Attendancestatus));
                command.Parameters.Add(new SqlParameter("@AddedBy", attend.AddedBy));
                command.Parameters.Add(new SqlParameter("@AddedDate", attend.AddedDate));

                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }
    public int AddAttendance_ExecutiveNewGeo(Attendance attend)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("AddAttendance_ExecutiveNewGeo", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmpId", attend.EmpID));
                command.Parameters.Add(new SqlParameter("@AttendanceDate", attend.AttendanceDate));
                command.Parameters.Add(new SqlParameter("@InTime", attend.InTime));
                command.Parameters.Add(new SqlParameter("@OutTime", attend.OutTime));
                command.Parameters.Add(new SqlParameter("@LocationInTime", attend.LocationInTime));
                command.Parameters.Add(new SqlParameter("@LocationOutTime", attend.LocationOutTime));
                command.Parameters.Add(new SqlParameter("@Attendancestatus", attend.Attendancestatus));
                command.Parameters.Add(new SqlParameter("@AddedBy", attend.AddedBy));
                command.Parameters.Add(new SqlParameter("@AddedDate", attend.AddedDate));
                command.Parameters.Add(new SqlParameter("@Geofence", attend.Geofence));
                command.Parameters.Add(new SqlParameter("@Outsidelat", attend.Outsidelat));
                command.Parameters.Add(new SqlParameter("@Outsidelong", attend.Outsidelong));

                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }

    public int UpdateAttendance_ExecutiveNewGeo(Attendance attend)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateAttendance_ExecutiveNewGeo", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmpId", attend.EmpID));
                command.Parameters.Add(new SqlParameter("@AttendanceDate", attend.AttendanceDate));
                command.Parameters.Add(new SqlParameter("@OutTime", attend.OutTime));
                command.Parameters.Add(new SqlParameter("@LocationOutTime", attend.LocationOutTime));
                command.Parameters.Add(new SqlParameter("@UpdatedBy", attend.UpdatedBy));
                command.Parameters.Add(new SqlParameter("@UpdatedDate", attend.UpdatedDate));
                command.Parameters.Add(new SqlParameter("@Geofence", attend.Geofence));
                command.Parameters.Add(new SqlParameter("@Outsidelat", attend.Outsidelat));
                command.Parameters.Add(new SqlParameter("@Outsidelong", attend.Outsidelong));

                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }
    public int UpdateAttendance_ExecutiveNew(Attendance attend)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateAttendance_ExecutiveNew", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmpId", attend.EmpID));
                command.Parameters.Add(new SqlParameter("@AttendanceDate", attend.AttendanceDate));
                command.Parameters.Add(new SqlParameter("@OutTime", attend.OutTime));
                command.Parameters.Add(new SqlParameter("@LocationOutTime", attend.LocationOutTime));
                command.Parameters.Add(new SqlParameter("@UpdatedBy", attend.UpdatedBy));
                command.Parameters.Add(new SqlParameter("@UpdatedDate", attend.UpdatedDate));

                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }

    public int UpdateAttendance_Executive(Attendance attend)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateAttendance_Executive", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmpId", attend.EmpID));
                command.Parameters.Add(new SqlParameter("@AttendanceDate", attend.AttendanceDate));
                command.Parameters.Add(new SqlParameter("@OutTime", attend.OutTime));
                command.Parameters.Add(new SqlParameter("@LocationOutTime", attend.LocationOutTime));
                command.Parameters.Add(new SqlParameter("@UpdatedBy", attend.UpdatedBy));
                command.Parameters.Add(new SqlParameter("@UpdatedDate", attend.UpdatedDate));
                command.Parameters.Add(new SqlParameter("@PunchOUTPhoto", attend.PunchOUTPhoto));

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