using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for NewFile302025
/// </summary>
public class NewFile302025
{
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




    public int GetDateDiff(string SendOfferdate)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int diff = 0;
        using (SqlCommand command = new SqlCommand("GetDateDiff", cnn))
        {
            cnn.Open();
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@OfferSentDate", SendOfferdate));
            command.Parameters.Add(new SqlParameter("@Todaydate", Utility.IndianTime));
            var result = command.ExecuteScalar();
            diff = result == DBNull.Value ? 0 : Convert.ToInt32(result);
        }

        cnn.Close();
        return diff;
    }








}