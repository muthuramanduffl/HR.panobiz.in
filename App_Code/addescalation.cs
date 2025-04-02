using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
    

/// <summary>
/// Summary description for supervisor_addescalation
/// </summary>
public class addescalation
{
    public string ddldepartment { get; set; }
    public string ddlissue { get; set; }
    public string Remarks { get; set; }
    public string EmpID { get; set; }
    public string Imagesuploade { get; set; }

    public string err = string.Empty;
    public addescalation()
    {

    }
    public string Date()
    {
        string adddedDate;
        DateTime utcNow = DateTime.UtcNow;
        TimeZoneInfo istTimeZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        DateTime istNow = TimeZoneInfo.ConvertTimeFromUtc(utcNow, istTimeZone);
        adddedDate = istNow.ToString("dd/MM/yyyy");
        return adddedDate;
    }

    public DataTable ddlviewisues()
    {
        DataTable dt = new DataTable();
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        string spquery = string.Empty;

        try
        {
            using (SqlCommand command = new SqlCommand("spviewddlissue", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(command);
                //command.Parameters.Add(
                //new SqlParameter("@ddldepartment", ddldepartment));
                da.Fill(dt);
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return dt;
    }
    public DataTable ddlviewdepartment(string strissueID)
    {


        DataTable dt = new DataTable();
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        string spquery = string.Empty;

        try
        {
            using (SqlCommand command = new SqlCommand("spddlDepartment", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(command);
                command.Parameters.Add(new SqlParameter("@ID", strissueID));

                da.Fill(dt);
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return dt;
    }

    public DataTable GETIDBYdepartment(string DEPARTMENT)
    {


        DataTable dt = new DataTable();
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        string spquery = string.Empty;

        try
        {
            using (SqlCommand command = new SqlCommand("GETIDBYDEPARTMENTNAME", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(command);
                command.Parameters.Add(new SqlParameter("@DEPARTMENT", DEPARTMENT));

                da.Fill(dt);
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return dt;
    }

    public int Updatereminder(string strReminder, int Sno)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        int rowsffected = 0;
        cnn = new SqlConnection(connetionString);
        try
        {
            using (SqlCommand command = new SqlCommand("SpRemindersAddBYSno", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(command);
                command.Parameters.Add(
                new SqlParameter("@Sno", Sno));
                command.Parameters.Add(
                new SqlParameter("@Reminder1", strReminder));
                command.Parameters.Add(
                new SqlParameter("@Senddate", Utility.IndianTime));
                rowsffected = command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {

        }
        return rowsffected;
    }
    public int Updatereminder2(string strReminder, int Sno)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        int rowsffected = 0;
        cnn = new SqlConnection(connetionString);
        try
        {
            using (SqlCommand command = new SqlCommand("SpReminders2AddBYSno", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(command);
                command.Parameters.Add(
                new SqlParameter("@Sno", Sno));
                command.Parameters.Add(
                new SqlParameter("@Reminder2 ", strReminder));
                command.Parameters.Add(
                new SqlParameter("@Senddate2", Utility.IndianTime));
                rowsffected = command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {

        }
        return rowsffected;
    }

    public int UpdateEscalation(string strReminderEscalation, int Sno)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        int rowsffected = 0;
        cnn = new SqlConnection(connetionString);
        try
        {
            using (SqlCommand command = new SqlCommand("spUpdateEscalation1", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(command);
                command.Parameters.Add(
                new SqlParameter("@Sno", Sno));
                command.Parameters.Add(
                new SqlParameter("@Escalation_1 ", strReminderEscalation));
                command.Parameters.Add(
                new SqlParameter("@Escalation_1AddedDate", Utility.IndianTime));
                rowsffected = command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {

        }
        return rowsffected;
    }

    public int UpdateEscalation2(string strReminder, int Sno)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        int rowsffected = 0;
        cnn = new SqlConnection(connetionString);
        try
        {
            using (SqlCommand command = new SqlCommand("spUpdateEscalation2", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(command);
                command.Parameters.Add(
                new SqlParameter("@Sno", Sno));
                command.Parameters.Add(
                new SqlParameter("@Escalation_2", strReminder));
                command.Parameters.Add(
                new SqlParameter("@Escalation_2AddedDate", Utility.IndianTime));
                rowsffected = command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {

        }
        return rowsffected;
    }







    #region viewescalation particular ID Details
    public DataSet ViewDataByID(int ID)
    {
        string spquery = string.Empty;
        DataSet ds = new DataSet();
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        try
        {
            using (SqlCommand command = new SqlCommand("spViewEscalationDetails", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(command);
                command.Parameters.Add(
                new SqlParameter("@ID", ID));

                da.Fill(ds);
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return ds;
    }
    #endregion












    #region viewEscalationlisting
    public DataSet viewEscalationlisting()
    {
        string spquery = string.Empty;
        DataSet ds = new DataSet();
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);

        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("spviewsuperviceEscalation", cnn))
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

    #endregion



    #region GetSqlConnectionstring
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
    #endregion


    public int adddataescalation(addescalation addescalation)
    {       
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowaffected = 0;
        
            using (SqlCommand command = new SqlCommand("spaddEscalation", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(command);
                command.Parameters.Add(
                new SqlParameter("@EmpID", addescalation.EmpID));
                command.Parameters.Add(
                new SqlParameter("@Department", addescalation.ddldepartment));
                command.Parameters.Add(
               new SqlParameter("@issue", addescalation.ddlissue));
                command.Parameters.Add(
              new SqlParameter("@Remarks", addescalation.Remarks));
                command.Parameters.Add(
             new SqlParameter("@UploadedImages", addescalation.Imagesuploade));
                command.Parameters.Add(
              new SqlParameter("@AddedDate",Utility.IndianTime));
                rowaffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        
        
        return rowaffected;
    }


    //public DataSet ISAlREADYEXISTBYEMPID(String strempid)
    //{
    //    string connetionString = null;
    //    DataSet ds = new DataSet();
    //    SqlConnection cnn;
    //    connetionString = GetSqlConnection();
    //    cnn = new SqlConnection(connetionString);
    //    int rowaffected = 0;
    //    try
    //    {
    //        using (SqlCommand command = new SqlCommand("spISALREADYEXISTBYEMPID", cnn))
    //        {
    //            cnn.Open();
    //            command.CommandType = CommandType.StoredProcedure;
    //            SqlDataAdapter da = new SqlDataAdapter(command);
    //            command.Parameters.Add(
    //            new SqlParameter("@EmpID", strempid));
    //            da.Fill(ds);
    //            command.ExecuteNonQuery();
    //        }
    //        cnn.Close();
    //    }
    //    catch (Exception ex)
    //    {
    //        err = ex.ToString();
    //    }
    //    return ds;
    //}





        public string GetMailID(int Department)
    {
        string Mailid = string.Empty;
        DataSet dsContent = mailidstoredvariable(Department);
        if (dsContent.Tables.Count > 0 && dsContent.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i <= dsContent.Tables[0].Rows.Count - 1; i++)
            {              
                Mailid+= dsContent.Tables[0].Rows[i]["EmailID"].ToString().Trim()+",";
            }
        }
            return Mailid.TrimEnd(','); 
    }



    public DataSet mailidstoredvariable(int Department)
    {
        DataSet ds =new DataSet();
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowaffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("spGetEmailID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(command);
                command.Parameters.Add(
                new SqlParameter("@Department", Department));
                da.Fill(ds);
                rowaffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return ds;
    }
    public DataSet ViewAddedDateByID(int ID)
    {
        DataSet dsAddedDate = new DataSet();
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        try
        {
            using (SqlCommand command = new SqlCommand("SpViewDateBySno", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter daAddedDate = new SqlDataAdapter(command);
                command.Parameters.Add(
                new SqlParameter("@ID", ID));
                command.ExecuteNonQuery();
                daAddedDate.Fill(dsAddedDate);
            }
        }
        catch (Exception exAddedDate)
        {

        }
        return dsAddedDate;
    }
    public DataSet ViewreminderStatus(int Sno)
    {
        DataSet ds = new DataSet();
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        try
        {
            using (SqlCommand command = new SqlCommand("spViewremindStatus", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(command);
                command.Parameters.Add(
                new SqlParameter("@Sno", Sno));
                command.ExecuteNonQuery();
                da.Fill(ds);
            }
        }
        catch (Exception ex)
        {

        }
        return ds;
    }

    public DataSet ViewReminder1SendDateByID(int id)
    {
        DataSet dsReminder1SendDate = new DataSet();
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        try
        {
            using (SqlCommand command = new SqlCommand("SpViewReminder1SendDateDateBySno", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter daReminder1SendDate = new SqlDataAdapter(command);
                command.Parameters.Add(
                new SqlParameter("@ID", id));
                command.ExecuteNonQuery();
                daReminder1SendDate.Fill(dsReminder1SendDate);
            }
        }
        catch (Exception exReminder1SendDate)
        {

        }
        return dsReminder1SendDate;
    }

    public DataSet ViewReminder2SendDateByID(int id)
    {
        DataSet dsReminder2SendDate = new DataSet();
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        try
        {
            using (SqlCommand command = new SqlCommand("SpViewReminder2SendDateDateBySno", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter daReminder2SendDate = new SqlDataAdapter(command);
                command.Parameters.Add(
                new SqlParameter("@ID", id));
                command.ExecuteNonQuery();
                daReminder2SendDate.Fill(dsReminder2SendDate);
            }
        }
        catch (Exception exReminder2SendDate)
        {

        }
        return dsReminder2SendDate;
    }

    public DataSet ViewEscalation_1AddedDateByID(int id)
    {
        DataSet dsEscalation_1AddedDate = new DataSet();
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        try
        {
            using (SqlCommand command = new SqlCommand("SpViewEscalation_1AddedDateDateBySno", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter daEscalation_1AddedDate = new SqlDataAdapter(command);
                command.Parameters.Add(
                new SqlParameter("@ID", id));
                command.ExecuteNonQuery();
                daEscalation_1AddedDate.Fill(dsEscalation_1AddedDate);
            }
        }
        catch (Exception exEscalation_1AddedDate)
        {

        }
        return dsEscalation_1AddedDate;
    }

    public DataSet ViewescalationlistNotify()
    {
        DataSet dsViewescalationlist = new DataSet();
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        try
        {
            using (SqlCommand command = new SqlCommand("SPViewescalationlistNotify", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter daViewescalationlist = new SqlDataAdapter(command);
                daViewescalationlist.Fill(dsViewescalationlist);
            }
        }
        catch (Exception exViewescalationlist)
        {

        }
        return dsViewescalationlist;
    }




}







