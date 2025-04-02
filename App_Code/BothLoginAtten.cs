using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BothLoginAtten
/// </summary>
public class BothLoginAtten
{


    public string BothLoginGetEmpId()
    {
        string strEmpId = string.Empty;
        try
        {
            if (HttpContext.Current.Session["EmpEmpId"] != null)
            {
                strEmpId = Convert.ToString(HttpContext.Current.Session["EmpEmpId"]);
            }
            if (string.IsNullOrEmpty(strEmpId))
            {
                if (HttpContext.Current.Request.Cookies["EmpLOGIN"] != null)
                {
                    System.Web.HttpCookie Logincookie = HttpContext.Current.Request.Cookies["EmpEmpId"];
                    strEmpId = Logincookie["EmpEmpId"];
                }
            }
        }
        catch
        {
        }
        return strEmpId;
    }


    //Both login session / cookies

    public string BothLoginGetEmpName()
    {
        string strEmpName = string.Empty;
        try
        {
            if (HttpContext.Current.Session["EmpName"] != null)
            {
                strEmpName = Convert.ToString(HttpContext.Current.Session["EmpName"]);
            }
            if (string.IsNullOrEmpty(strEmpName))
            {
                if (HttpContext.Current.Request.Cookies["EmpLOGIN"] != null)
                {
                    System.Web.HttpCookie Logincookie = HttpContext.Current.Request.Cookies["EmpLOGIN"];
                    strEmpName = Logincookie["EmpName"];
                }
            }
        }
        catch
        {
        }
        return strEmpName;
    }
}