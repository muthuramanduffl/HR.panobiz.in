using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Security;
using System.Data.SqlClient;


/// <summary>
/// Summary description for demoEmailandwhatsapp5
/// </summary>
public class Emailandwhatsapp
{
  public  string EMPID { get; set; }

    
	public Emailandwhatsapp()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    

#region Send WhatsAppMessage
    public void SendWhatsAppMessage(string strname, string strempid1, string strphoneno, string strlocation)
    {

        

        using (var client = new HttpClient())
        {
            var request = new HttpRequestMessage
            {
                Method = System.Net.Http.HttpMethod.Post,
                RequestUri = new Uri("https://live-mt-server.wati.io/300729/api/v1/sendTemplateMessage?whatsappNumber=" + strphoneno + ""),
                Headers =
        {
            { "Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiJlYWMxNzhlNi1kZTAwLTQwYTAtOTdmNC0xOGJlMTFjZTdhYWYiLCJ1bmlxdWVfbmFtZSI6ImxpZmVAcGFub2Jpei5pbiIsIm5hbWVpZCI6ImxpZmVAcGFub2Jpei5pbiIsImVtYWlsIjoibGlmZUBwYW5vYml6LmluIiwiYXV0aF90aW1lIjoiMDEvMDYvMjAyNCAwNzoxMjozMiIsImRiX25hbWUiOiJtdC1wcm9kLVRlbmFudHMiLCJ0ZW5hbnRfaWQiOiIzMDA3MjkiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBRE1JTklTVFJBVE9SIiwiZXhwIjoyNTM0MDIzMDA4MDAsImlzcyI6IkNsYXJlX0FJIiwiYXVkIjoiQ2xhcmVfQUkifQ.OP5X3eTpGps-GJ9arkyC3x2NYjZMyeAFWtBIrJq-K08" },
        },
                Content = new StringContent("{\"parameters\":[{\"name\":\"empname\",\"value\":\"" + strname + "\"},{\"name\":\"empid\",\"value\":\"" + strempid1 + "\"},{\"name\":\"mobile\",\"value\":\"" + strphoneno + "\"},{\"name\":\"location\",\"value\":\"" + strlocation + "\"}],\"template_name\":\"employeenotindbnew\",\"broadcast_name\":\"employeenotindbnew\"}")
                {
                    Headers =
            {
                ContentType = new MediaTypeHeaderValue("application/json-patch+json")
            }
                }
            };


            var response = client.SendAsync(request).Result;

            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content;

                // by calling .Result you are synchronously reading the result
                string responseString = responseContent.ReadAsStringAsync().Result;

                //Response.Write(responseString);
            }
        }

    }
    #endregion

#region SendExeAddEmpWhatsAppMessage
    public void SendExeAddEmpWhatsAppMessage(string strname, string strempid1, string strphoneno)
    {

        

        using (var client = new HttpClient())
        {
            var request = new HttpRequestMessage
            {
                Method = System.Net.Http.HttpMethod.Post,
                RequestUri = new Uri("https://live-mt-server.wati.io/300729/api/v1/sendTemplateMessage?whatsappNumber=" + strphoneno + ""),
                Headers =
        {
            { "Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiJlYWMxNzhlNi1kZTAwLTQwYTAtOTdmNC0xOGJlMTFjZTdhYWYiLCJ1bmlxdWVfbmFtZSI6ImxpZmVAcGFub2Jpei5pbiIsIm5hbWVpZCI6ImxpZmVAcGFub2Jpei5pbiIsImVtYWlsIjoibGlmZUBwYW5vYml6LmluIiwiYXV0aF90aW1lIjoiMDEvMDYvMjAyNCAwNzoxMjozMiIsImRiX25hbWUiOiJtdC1wcm9kLVRlbmFudHMiLCJ0ZW5hbnRfaWQiOiIzMDA3MjkiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBRE1JTklTVFJBVE9SIiwiZXhwIjoyNTM0MDIzMDA4MDAsImlzcyI6IkNsYXJlX0FJIiwiYXVkIjoiQ2xhcmVfQUkifQ.OP5X3eTpGps-GJ9arkyC3x2NYjZMyeAFWtBIrJq-K08" },
        },
                Content = new StringContent("{\"parameters\":[{\"name\":\"name\",\"value\":\"" + strname + "\"},{\"name\":\"id\",\"value\":\"" + strempid1 + "\"}],\"template_name\":\"exenewemployeeadded\",\"broadcast_name\":\"exenewemployeeadded\"}")
                {
                    Headers =
            {
                ContentType = new MediaTypeHeaderValue("application/json-patch+json")
            }
                }
            };


            var response = client.SendAsync(request).Result;

            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content;

                // by calling .Result you are synchronously reading the result
                string responseString = responseContent.ReadAsStringAsync().Result;

                //Response.Write("responseString");
            }
        }

    }
    #endregion

#region SendSupAddEmpWhatsAppMessage
    public void SendSupAddEmpWhatsAppMessage(string strname, string strempid1, string strphoneno)
    {

        

        using (var client = new HttpClient())
        {
            var request = new HttpRequestMessage
            {
                Method = System.Net.Http.HttpMethod.Post,
                RequestUri = new Uri("https://live-mt-server.wati.io/300729/api/v1/sendTemplateMessage?whatsappNumber=" + strphoneno + ""),
                Headers =
        {
            { "Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiJlYWMxNzhlNi1kZTAwLTQwYTAtOTdmNC0xOGJlMTFjZTdhYWYiLCJ1bmlxdWVfbmFtZSI6ImxpZmVAcGFub2Jpei5pbiIsIm5hbWVpZCI6ImxpZmVAcGFub2Jpei5pbiIsImVtYWlsIjoibGlmZUBwYW5vYml6LmluIiwiYXV0aF90aW1lIjoiMDEvMDYvMjAyNCAwNzoxMjozMiIsImRiX25hbWUiOiJtdC1wcm9kLVRlbmFudHMiLCJ0ZW5hbnRfaWQiOiIzMDA3MjkiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBRE1JTklTVFJBVE9SIiwiZXhwIjoyNTM0MDIzMDA4MDAsImlzcyI6IkNsYXJlX0FJIiwiYXVkIjoiQ2xhcmVfQUkifQ.OP5X3eTpGps-GJ9arkyC3x2NYjZMyeAFWtBIrJq-K08" },
        },
                Content = new StringContent("{\"parameters\":[{\"name\":\"name\",\"value\":\"" + strname + "\"},{\"name\":\"id\",\"value\":\"" + strempid1 + "\"}],\"template_name\":\"supnewemployeeadded\",\"broadcast_name\":\"supnewemployeeadded\"}")
                {
                    Headers =
            {
                ContentType = new MediaTypeHeaderValue("application/json-patch+json")
            }
                }
            };


            var response = client.SendAsync(request).Result;

            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content;

                // by calling .Result you are synchronously reading the result
                string responseString = responseContent.ReadAsStringAsync().Result;

                //Response.Write("responseString");
            }
        }

    }
    #endregion

#region SendExeProfileUpdatedEmpWhatsAppMessage
    public void SendExeProfileUpdatedEmpWhatsAppMessage(string strname, string strphoneno)
    {

        

        using (var client = new HttpClient())
        {
            var request = new HttpRequestMessage
            {
                Method = System.Net.Http.HttpMethod.Post,
                RequestUri = new Uri("https://live-mt-server.wati.io/300729/api/v1/sendTemplateMessage?whatsappNumber=" + strphoneno + ""),
                Headers =
        {
            { "Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiJlYWMxNzhlNi1kZTAwLTQwYTAtOTdmNC0xOGJlMTFjZTdhYWYiLCJ1bmlxdWVfbmFtZSI6ImxpZmVAcGFub2Jpei5pbiIsIm5hbWVpZCI6ImxpZmVAcGFub2Jpei5pbiIsImVtYWlsIjoibGlmZUBwYW5vYml6LmluIiwiYXV0aF90aW1lIjoiMDEvMDYvMjAyNCAwNzoxMjozMiIsImRiX25hbWUiOiJtdC1wcm9kLVRlbmFudHMiLCJ0ZW5hbnRfaWQiOiIzMDA3MjkiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBRE1JTklTVFJBVE9SIiwiZXhwIjoyNTM0MDIzMDA4MDAsImlzcyI6IkNsYXJlX0FJIiwiYXVkIjoiQ2xhcmVfQUkifQ.OP5X3eTpGps-GJ9arkyC3x2NYjZMyeAFWtBIrJq-K08" },
        },
                Content = new StringContent("{\"parameters\":[{\"name\":\"name\",\"value\":\"" + strname + "\"}],\"template_name\":\"exeprofileupdated\",\"broadcast_name\":\"exeprofileupdated\"}")
                {
                    Headers =
            {
                ContentType = new MediaTypeHeaderValue("application/json-patch+json")
            }
                }
            };


            var response = client.SendAsync(request).Result;

            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content;

                // by calling .Result you are synchronously reading the result
                string responseString = responseContent.ReadAsStringAsync().Result;

                //Response.Write("responseString");
            }
        }

    }
    #endregion

#region SendSupProfileUpdatedEmpWhatsAppMessage
    public void SendSupProfileUpdatedEmpWhatsAppMessage(string strname, string strphoneno)
    {

        

        using (var client = new HttpClient())
        {
            var request = new HttpRequestMessage
            {
                Method = System.Net.Http.HttpMethod.Post,
                RequestUri = new Uri("https://live-mt-server.wati.io/300729/api/v1/sendTemplateMessage?whatsappNumber=" + strphoneno + ""),
                Headers =
        {
            { "Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiJlYWMxNzhlNi1kZTAwLTQwYTAtOTdmNC0xOGJlMTFjZTdhYWYiLCJ1bmlxdWVfbmFtZSI6ImxpZmVAcGFub2Jpei5pbiIsIm5hbWVpZCI6ImxpZmVAcGFub2Jpei5pbiIsImVtYWlsIjoibGlmZUBwYW5vYml6LmluIiwiYXV0aF90aW1lIjoiMDEvMDYvMjAyNCAwNzoxMjozMiIsImRiX25hbWUiOiJtdC1wcm9kLVRlbmFudHMiLCJ0ZW5hbnRfaWQiOiIzMDA3MjkiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBRE1JTklTVFJBVE9SIiwiZXhwIjoyNTM0MDIzMDA4MDAsImlzcyI6IkNsYXJlX0FJIiwiYXVkIjoiQ2xhcmVfQUkifQ.OP5X3eTpGps-GJ9arkyC3x2NYjZMyeAFWtBIrJq-K08" },
        },
                Content = new StringContent("{\"parameters\":[{\"name\":\"name\",\"value\":\"" + strname + "\"}],\"template_name\":\"supprofileupdated\",\"broadcast_name\":\"supprofileupdated\"}")
                {
                    Headers =
            {
                ContentType = new MediaTypeHeaderValue("application/json-patch+json")
            }
                }
            };


            var response = client.SendAsync(request).Result;

            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content;

                // by calling .Result you are synchronously reading the result
                string responseString = responseContent.ReadAsStringAsync().Result;

                //Response.Write("responseString");
            }
        }

    }
    #endregion


    public void sendGmail(string Tomail, string subject, string body)
    {
        try
        {
            SmtpClient SmtpClient = new SmtpClient();
            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
            message.From = new MailAddress("info@quick-query.info");
            message.Subject = subject;
            message.To.Add(Tomail);
            //message.CC.Add("muthuraman@duffldigital.com");
            //message.Bcc.Add("muthukm627@gmail.com");
            message.Body = body;
            message.IsBodyHtml = true;
            SmtpClient.EnableSsl = false;
            SmtpClient.Send(message);
        }
        catch (Exception ex)
        {

        }
    }

    //public int SelectONLYUpdate(demoEmailandwhatsapp5 update)
    //{

    //    string connetionString = null;
    //    SqlConnection cnn;
    //    connetionString = GetSqlConnection();
    //    cnn = new SqlConnection(connetionString);
    //    int rowsAffected = 0;
    //    try
    //    {
    //        using (SqlCommand command = new SqlCommand("spSelectedOnly", cnn))
    //        {
    //            cnn.Open();
    //            command.CommandType = CommandType.StoredProcedure;
    //            command.Parameters.Add(new SqlParameter("@EmpID",update.EMPID));
               
    //            rowsAffected = command.ExecuteNonQuery();
    //        }
    //        cnn.Close();
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //    return rowsAffected;
    //}

    public void UpdateALL()
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("spAll", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;                
                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }      
    }
    public int UpdateapprovalSelectONLY(Emailandwhatsapp update)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("spApprovalSelectedOnly", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmpID", update.EMPID));
                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }

    public void UpdateapprovalALL()
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("spUpdateapprovalAll", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
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
}