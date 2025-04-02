
using Quartz;
using System.Net.Mail;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Data;
using System.Net.Http;
using System.Net.Http.Headers;

namespace DocVerified11
{
    public class MyJob11 : IJob
    {

        public async Task Execute(IJobExecutionContext context)
        {
            await sendRemainder1();
            await sendRemainder1sup();
            await sendRemainder2sup();
            await sendRemainder6sup();
        }
        public async Task sendRemainder1()
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
                
                DataSet ds = remainderJob.Viewattendancenotmarkedemployee1();
               
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        mailCount++;
                        
                        stFirstName = Convert.ToString(ds.Tables[0].Rows[i]["EmpFirstName"]);
                        sWhatsAppNo = Convert.ToString(ds.Tables[0].Rows[i]["Mobile"]);
                       // string therapistemailBody = PopulateTherapistEmailBody(stFirstName);
                //         if (!string.IsNullOrEmpty(therapistemailBody))
                //         {
                //             try
                //             {
                //                 var SmtpClient = new SmtpClient();
                //                 System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
                //                 message.From = new MailAddress("support@themindandcompany.com", "Reminder for Today's Attendance");
                //                 message.Subject = "Reminder for Today's Attendance ";
                //                 message.To.Add("veni@duffldigital.com");
                //                 //message.Bcc.Add("veni@duffldigital.com");
                //                 message.Body = therapistemailBody;
                //                 message.IsBodyHtml = true;
                //                 SmtpClient.EnableSsl = false;
                //                 await SmtpClient.SendMailAsync(message);
                //             }
                //             catch(Exception ex)
                //             {
                //                     string mailcount = Convert.ToString(mailCount);
                // remainderJob.AddRemainderJob(mailcount, ex.ToString(), stStatus);

                //             }
                //         }
                       
                        try
                        {
                            // string stMessage = "Hi " + stTFirstName + ", this is a reminder for your session today @ " + stSlotTime + " with " + stUFirstName + ". Meet Link - check mail or login to TMC account. -MINDKO";
                            // Utility.SendNewSMS(stTherapistMobileNo, stMessage, "1707164431909899178");

                            // string stMessage1 = "Hi " + stUFirstName + ", this is a reminder for your session today @ " + stSlotTime + " with " + stTFirstName + ". Meet Link - check mail or login to TMC account. -MINDKO";
                            // Utility.SendNewSMS(stUserMobileNo, stMessage1, "1707164431905551113");

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
        public async Task sendRemainder1sup()
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
                
                DataSet ds = remainderJob.Viewattendancenotmarkedemployee1sup();
               
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
                                SendUserWhatsAppMessagesup(stUserWhatsAppno, stFirstName);

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

        public async Task sendRemainder2sup()
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
                
                DataSet ds = remainderJob.Viewattendancenotmarkedemployee2sup();
               
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
                                SendUserWhatsAppMessagesup(stUserWhatsAppno, stFirstName);

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
        public async Task sendRemainder6sup()
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
                
                DataSet ds = remainderJob.Viewattendancenotmarkedemployee6sup();
               
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
                                SendUserWhatsAppMessagesup(stUserWhatsAppno, stFirstName);

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

        // public string PopulateTherapistEmailBody(string stTherapistName)
        // {
        //     string body = string.Empty;
        //     string stFilePath = System.Web.Hosting.HostingEnvironment.MapPath("~/mailtemplate/remaindertherapist.html");
        //     using (StreamReader reader = new StreamReader(stFilePath))
        //     {
        //         body = reader.ReadToEnd();
        //     }
        //     body = body.Replace("{TherapistName}", stTherapistName.Trim());
        //     return body;
        // }
        // public string PopulateUserEmailBody(string stTherapistName, string stUserName, string SlotTime, string stMeetingLink)
        // {
        //     string body = string.Empty;
        //     string stFilePath = System.Web.Hosting.HostingEnvironment.MapPath("~/mailtemplate/remainderuser.html");
        //     using (StreamReader reader = new StreamReader(stFilePath))
        //     {
        //         body = reader.ReadToEnd();
        //     }
        //     body = body.Replace("{TherapistName}", stTherapistName.Trim());
        //     body = body.Replace("{SlotTime}", SlotTime.Trim());
        //     body = body.Replace("{UserName}", stUserName.Trim());
        //     body = body.Replace("{MeetingLink}", stMeetingLink.Trim());
        //     return body;
        // }


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