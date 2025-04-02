// AttendanceService.cs (Place this in the App_Code folder)
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;


public class AttendanceRecord
{
    public DateTime AttendanceDate { get; set; }
    public string AttendanceStatus { get; set; }
    public string GeofenceStatus { get; set; } 

}

public class AttendanceSummary
{
    public int PresentDays { get; set; }
    public int AbsentDays { get; set; }
    public int Holidays { get; set; }
}

public class AttendanceRow
{
    public string StatusType { get; set; }
    public List<string> Statuses { get; set; }
}


public class MonthlyAttendanceResult
{
    public List<AttendanceRecord> AttendanceRecords { get; set; }
    public AttendanceSummary Summary { get; set; }
}

public class EmployeeAttendance
{
    public string EmpID { get; set; }
    public string EmpName { get; set; }
    public string Designation { get; set; }
    public string Dept { get; set; }
    public string Supervisor1 { get; set; }
    public string Supervisor2 { get; set; }
    public string Supervisor3 { get; set; }
    public string Supervisor4 { get; set; }
    public string Supervisor5 { get; set; }
    public List<string> Statuses { get; set; }  // Attendance status for each date
}

public class EmployeeAttendanceResponse
{
    public string EmpID { get; set; }
    public string EmpFirstName { get; set; }
    public string Designation { get; set; }
    public string Dept { get; set; }
    public string Supervisor1 { get; set; }
    public string Supervisor2 { get; set; }
    public string Supervisor3 { get; set; }
    public string Supervisor4 { get; set; }
    public string Supervisor5 { get; set; }

    public List<AttendanceRecord> AttendanceRecords { get; set; }
}

public class AttendanceService
{
    private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["HRPANOBIZ"].ConnectionString; // Replace with your connection string

    public MonthlyAttendanceResult GetMonthlyAttendance(string empId, int year, int month)
{
    var attendanceRecords = new List<AttendanceRecord>();
    var summary = new AttendanceSummary();

    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        using (SqlCommand cmd = new SqlCommand("GetMonthlyAttendance", conn))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmpID", empId);
            cmd.Parameters.AddWithValue("@Year", year);
            cmd.Parameters.AddWithValue("@Month", month);

            conn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                // ✅ Read attendance records with GeofenceStatus
                while (reader.Read())
                {
                    attendanceRecords.Add(new AttendanceRecord
                    {
                        AttendanceDate = Convert.ToDateTime(reader["AttendanceDate"]),
                        AttendanceStatus = reader["AttendanceStatus"].ToString(),
                        GeofenceStatus = reader["GeofenceStatus"].ToString() // ✅ Read new column
                    });
                }

                // ✅ Move to summary result set
                if (reader.NextResult() && reader.Read())
                {
                    summary.PresentDays = Convert.ToInt32(reader["PresentDays"]);
                    summary.AbsentDays = Convert.ToInt32(reader["AbsentDays"]);
                    summary.Holidays = Convert.ToInt32(reader["Holidays"]);
                }
            }
        }
    }

    return new MonthlyAttendanceResult
    {
        AttendanceRecords = attendanceRecords,
        Summary = summary
    };
}


public List<EmployeeAttendanceResponse> GetMonthlyAttendanceForAllEmployees(int year, int month, string empId)
{
    var employeeAttendanceList = new List<EmployeeAttendanceResponse>();

    using (var conn = new SqlConnection(connectionString))
{
       using (var cmd = new SqlCommand("GetMonthlyAttendanceforall", conn))
{
    cmd.CommandType = CommandType.StoredProcedure;
    cmd.Parameters.AddWithValue("@Year", year);
    cmd.Parameters.AddWithValue("@Month", month);

    if (!string.IsNullOrEmpty(empId))
        cmd.Parameters.AddWithValue("@EmpID", empId);  // Add filter

    conn.Open();
    using (var reader = cmd.ExecuteReader())
    {
        var attendanceDict = new Dictionary<string, EmployeeAttendanceResponse>();

        while (reader.Read())
        {
            var fetchedEmpID = reader["EmpID"].ToString();
            var empName = reader["EmpFirstName"].ToString();
            var sup1 = reader["Supervisor1"].ToString();
            var sup2 = reader["Supervisor2"].ToString();
            var sup3 = reader["Supervisor3"].ToString();
            var sup4 = reader["Supervisor4"].ToString();
            var sup5 = reader["Supervisor5"].ToString();
            var dept = reader["Department"].ToString();
            var designation = reader["Designation"].ToString();

            var attendanceDate = reader["AttendanceDate"] != DBNull.Value ? Convert.ToDateTime(reader["AttendanceDate"]) : (DateTime?)null;
            var status = reader["AttendanceStatus"].ToString();

            if (!attendanceDict.ContainsKey(fetchedEmpID))
            {
                attendanceDict[fetchedEmpID] = new EmployeeAttendanceResponse
                {
                    EmpID = fetchedEmpID,
                    EmpFirstName = empName,
                    Dept = dept,
                    Designation = designation,
                    Supervisor1 = sup1,
                    Supervisor2 = sup2,
                    Supervisor3 = sup3,
                    Supervisor4 = sup4,
                    Supervisor5 = sup5,

                    AttendanceRecords = new List<AttendanceRecord>()
                };
            }

            if (attendanceDate.HasValue)
            {
                attendanceDict[fetchedEmpID].AttendanceRecords.Add(new AttendanceRecord
                {
                    AttendanceDate = attendanceDate.Value,
                    AttendanceStatus = status
                });
            }
        }

        return attendanceDict.Values.ToList();
    }
}

    }

    return employeeAttendanceList;
}




}
