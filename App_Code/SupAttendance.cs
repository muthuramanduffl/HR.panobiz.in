using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// 
/// Summary description for SupAttendance
/// </summary>
public class SupAttendance
{
    public SupAttendance()
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
    
    
    public string GetEmpName()
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
    

  

    public string GetEmpRole()
    {
        string strEmpName = string.Empty;
        try
        {
            if (HttpContext.Current.Session["SEmpEmpRole"] != null)
            {
                strEmpName = Convert.ToString(HttpContext.Current.Session["SEmpEmpRole"]);
            }
            if (string.IsNullOrEmpty(strEmpName))
            {
                if (HttpContext.Current.Request.Cookies["SEmpLOGIN"] != null)
                {
                    System.Web.HttpCookie Logincookie = HttpContext.Current.Request.Cookies["SEmpLOGIN"];
                    strEmpName = Logincookie["SEmpEmpRole"];
                }
            }
        }
        catch
        {
        }
        return strEmpName;
    }
    public DataSet ViewTodayEmpAttendance(string stSEmpID,string todaydate)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewTodayEmpAttendance", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@SupervisorID", stSEmpID));
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

    public DataSet ViewTodayEmpAttendanceBySupIDwithFilter(string stSEmpID, string todaydate,string stEmpID, string stEmpName, string stClient, string stDept,
      string stRole, string stStatus,string stsearch)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewTodayEmpAttendanceBySupIDwithFilter", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@SupervisorID", stSEmpID));
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

    public DataSet ViewTodayEmpAttendanceBySupIDwithFilterNew(string stSEmpID, string todaydate,string stEmpID, string stEmpName, string stsearch)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewTodayEmpAttendanceBySupIDwithFilterNew", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@SupervisorID", stSEmpID));
                command.Parameters.Add(new SqlParameter("@todaydate", todaydate));

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

}