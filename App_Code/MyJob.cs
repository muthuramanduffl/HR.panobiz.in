
using Quartz;
using System.Net.Mail;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Data;
using System.Net.Http;
using System.Net.Http.Headers;

namespace DocVerified
{
    public class MyJob : IJob
    {

        public async Task Execute(IJobExecutionContext context)
        {
            await sendRemainder2();
            await sendRemainder4();
      

        }
   
        public async Task sendRemainder2()
        {
            remainderJob remainderJob = new remainderJob();
            string currentDate =  Utility.IndianTime.ToString("yyyy-MM-dd");
         
            int mailCount = 0;
            string stStatus = "Success";
          
            string stFirstName = string.Empty;
            string stmsgs = "Attendance";
            
            string sWhatsAppNo = string.Empty;
            try
            {
                
                DataSet ds = remainderJob.Viewattendancenotmarkedemployee2();
               
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        mailCount++;
                        
                        stFirstName = Convert.ToString(ds.Tables[0].Rows[i]["EmpFirstName"]);
                        sWhatsAppNo = Convert.ToString(ds.Tables[0].Rows[i]["Mobile"]);
                       
                       
                        try
                        {
                        
                            string stUserWhatsAppno = string.Empty;
                            if (sWhatsAppNo.Trim().Length == 10)
                                stUserWhatsAppno = "91" + sWhatsAppNo.Trim();
                            else
                                stUserWhatsAppno = sWhatsAppNo.Trim();
                            if (!string.IsNullOrEmpty(stUserWhatsAppno))
                                SendUserWhatsAppMessage(stUserWhatsAppno, stFirstName);

                        }
                        catch (Exception ex)
                        {
                           

                        }
                    }
                   
                }
                string mailcountss = Convert.ToString(mailCount);
                remainderJob.AddRemainderJob(mailcountss, "Failed", stStatus);
                
            }
            catch (Exception ex)
            {
                string mailcounts = Convert.ToString(mailCount);
                remainderJob.AddRemainderJob(mailcounts, ex.ToString(), "Fail");
                Console.WriteLine("Failed");
            }
            
        }
        


        public async Task sendRemainder4()
        {
            remainderJob remainderJob = new remainderJob();
            string currentDate =  Utility.IndianTime.ToString("yyyy-MM-dd");
         
            int mailCount = 0;
            string stStatus = "Success";
          
            string stFirstName = string.Empty;
            string stmsgs = "Attendance";
            
            string sWhatsAppNo = string.Empty;
            try
            {
                
                DataSet ds = remainderJob.Viewattendancenotmarkedemployee4();
               
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        mailCount++;
                        
                        stFirstName = Convert.ToString(ds.Tables[0].Rows[i]["EmpFirstName"]);
                        sWhatsAppNo = Convert.ToString(ds.Tables[0].Rows[i]["Mobile"]);
                       
                       
                        try
                        {
                        
                            string stUserWhatsAppno = string.Empty;
                            if (sWhatsAppNo.Trim().Length == 10)
                                stUserWhatsAppno = "91" + sWhatsAppNo.Trim();
                            else
                                stUserWhatsAppno = sWhatsAppNo.Trim();
                            if (!string.IsNullOrEmpty(stUserWhatsAppno))
                                SendUserWhatsAppMessage(stUserWhatsAppno, stFirstName);

                        }
                        catch (Exception ex)
                        {
                           

                        }
                    }
                   
                }
                string mailcountss = Convert.ToString(mailCount);
                remainderJob.AddRemainderJob(mailcountss, "Failed", stStatus);
                
            }
            catch (Exception ex)
            {
                string mailcounts = Convert.ToString(mailCount);
                remainderJob.AddRemainderJob(mailcounts, ex.ToString(), "Fail");
                Console.WriteLine("Failed");
            }
            
        }
  

        public async Task sendRemainder5()
        {
            remainderJob remainderJob = new remainderJob();
            string currentDate =  Utility.IndianTime.ToString("yyyy-MM-dd");
         
            int mailCount = 0;
            string stStatus = "Success";
          
            string stFirstName = string.Empty;
            string stmsgs = "Attendance";
            
            string sWhatsAppNo = string.Empty;
            try
            {
                
                DataSet ds = remainderJob.Viewattendancenotmarkedemployee5();
               
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        mailCount++;
                        
                        stFirstName = Convert.ToString(ds.Tables[0].Rows[i]["EmpFirstName"]);
                        sWhatsAppNo = Convert.ToString(ds.Tables[0].Rows[i]["Mobile"]);
                       
                       
                        try
                        {
                        
                            string stUserWhatsAppno = string.Empty;
                            if (sWhatsAppNo.Trim().Length == 10)
                                stUserWhatsAppno = "91" + sWhatsAppNo.Trim();
                            else
                                stUserWhatsAppno = sWhatsAppNo.Trim();
                            if (!string.IsNullOrEmpty(stUserWhatsAppno))
                                SendUserWhatsAppMessage(stUserWhatsAppno, stFirstName);

                        }
                        catch (Exception ex)
                        {
                           

                        }
                    }
                   
                }
                string mailcountss = Convert.ToString(mailCount);
                remainderJob.AddRemainderJob(mailcountss, "Failed", stStatus);
                
            }
            catch (Exception ex)
            {
                string mailcounts = Convert.ToString(mailCount);
                remainderJob.AddRemainderJob(mailcounts, ex.ToString(), "Fail");
                Console.WriteLine("Failed");
            }
            
        }
     



     


        public void SendUserWhatsAppMessage(string stMobileNo, string stName)
        {

            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage
                {
                    Method = System.Net.Http.HttpMethod.Post,
                    RequestUri = new Uri("https://live-mt-server.wati.io/300729/api/v1/sendTemplateMessage?whatsappNumber=" + stMobileNo + ""),
                    Headers =
    {
        { "Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiJiMTAyMDA4My1jMDUxLTQ0NTYtODVlZS03ZDRkZTUyMjM2M2UiLCJ1bmlxdWVfbmFtZSI6ImxpZmVAcGFub2Jpei5pbiIsIm5hbWVpZCI6ImxpZmVAcGFub2Jpei5pbiIsImVtYWlsIjoibGlmZUBwYW5vYml6LmluIiwiYXV0aF90aW1lIjoiMTEvMTQvMjAyMyAxNzo0ODoxNCIsImRiX25hbWUiOiJtdC1wcm9kLVRlbmFudHMiLCJ0ZW5hbnRfaWQiOiIzMDA3MjkiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBRE1JTklTVFJBVE9SIiwiZXhwIjoyNTM0MDIzMDA4MDAsImlzcyI6IkNsYXJlX0FJIiwiYXVkIjoiQ2xhcmVfQUkifQ.c3r_-DJIJxmMxksFfu3g_DjmaP13salloJrHR9Cj61s" },
    },
                    Content = new StringContent("{\"parameters\":[{\"name\":\"name\",\"value\":\"" + stName.Trim() + "\"}],\"template_name\":\"attendancereminderexe\",\"broadcast_name\":\"attendancereminderexe\"}")
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
        public void SendUserWhatsAppMessagesup(string stMobileNo, string stName)
        {

            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage
                {
                    Method = System.Net.Http.HttpMethod.Post,
                    RequestUri = new Uri("https://live-mt-server.wati.io/300729/api/v1/sendTemplateMessage?whatsappNumber=" + stMobileNo + ""),
                    Headers =
    {
        { "Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiJiMTAyMDA4My1jMDUxLTQ0NTYtODVlZS03ZDRkZTUyMjM2M2UiLCJ1bmlxdWVfbmFtZSI6ImxpZmVAcGFub2Jpei5pbiIsIm5hbWVpZCI6ImxpZmVAcGFub2Jpei5pbiIsImVtYWlsIjoibGlmZUBwYW5vYml6LmluIiwiYXV0aF90aW1lIjoiMTEvMTQvMjAyMyAxNzo0ODoxNCIsImRiX25hbWUiOiJtdC1wcm9kLVRlbmFudHMiLCJ0ZW5hbnRfaWQiOiIzMDA3MjkiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBRE1JTklTVFJBVE9SIiwiZXhwIjoyNTM0MDIzMDA4MDAsImlzcyI6IkNsYXJlX0FJIiwiYXVkIjoiQ2xhcmVfQUkifQ.c3r_-DJIJxmMxksFfu3g_DjmaP13salloJrHR9Cj61s" },
    },
                    Content = new StringContent("{\"parameters\":[{\"name\":\"name\",\"value\":\"" + stName.Trim() + "\"}],\"template_name\":\"attendancereminder\",\"broadcast_name\":\"attendancereminder\"}")
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

       
    }
}