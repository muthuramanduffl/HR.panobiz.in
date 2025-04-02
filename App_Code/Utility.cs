using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Text;
using RestSharp;

public class Utility
{
    public Utility()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static DateTime IndianTime
    {
        get
        {
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
        }
    }

    public static void SendOTPSMS(string MobileNo, string TemplateId, string Message)
    {
        //  try
        //  {

            var client = new RestClient("https://rest.qikberry.ai/v1/sms/messages");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Bearer 54c59e83102293319db882ace9d14bd5");
            request.AddHeader("Content-Type", "application/json");
           var body = string.Format(@"{{
            ""to"": ""{0}"",
            ""sender"": ""PANOBI"",
            ""service"": ""SI"",
            ""template_id"": ""{1}"",
            ""message"": ""{2}""
        }}", MobileNo, TemplateId, Message);
            request.AddParameter("application/json", body,  ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

    }

    
   
}