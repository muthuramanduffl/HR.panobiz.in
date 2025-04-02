using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Summary description for adddemoDB
/// </summary>
public class adddemoDB
{

    public int ID { get; set; }
    public string cname { get; set; }
    public string pname { get; set; }
    public string jfunction { get; set; }
    public string ddlcname { get; set; }
    public string designation { get; set; }
    public string CompanyName { get; set; }
    public int ddljobfunction { get; set; }
    public string txtname { get; set; }
    public int ddl { get; set; }
    public int id { get; set; }
    public string strERole { get; set; }
    



    public adddemoDB()
    {
       
    }
    #region Companyname
    




    public int  addcomapanyname(adddemoDB addcompany)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("spaddCompany", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@Comapanyname", addcompany.cname));
                
                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }
    public DataSet viewcname(string cname)
    {
        DataSet ds = new DataSet();
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("spExistcompanyname", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(command);
                command.Parameters.Add(
                                          new SqlParameter("@Comapanyname", cname));
                da.Fill(ds);
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return ds;
    }

    public bool AlreadyExistcompanyname(string cname)
    {


        bool IsAvail = false;


        DataSet ds = viewcname(cname);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            string name = ds.Tables[0].Rows[0]["Company"].ToString().Trim();
            if (string.Equals(name.ToLower().Trim(), cname.ToLower().Trim()))
                IsAvail = true;

        }
        else
            IsAvail = false;

        return IsAvail;
    }

    public int UpdateContent(adddemoDB addcompany)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("spUpdateCompany", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ID", addcompany.ID));
                command.Parameters.Add(new SqlParameter("@Comapanyname", addcompany.cname));
                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;


       
    }



    #endregion


    #region productname

    public int addproductname(adddemoDB addproduct)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("spAddproduct", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Productname", addproduct.pname));
                command.Parameters.Add(new SqlParameter("@ddlcopanyname", addproduct.ddlcname));
                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }
   
    public bool AlreadyExistproductname(string ddlcname,string pname)
    {
        bool IsAvail = false;
        DataSet ds = viewproductname(ddlcname);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            for(int i=0;i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                string name = ds.Tables[0].Rows[i]["Productname"].ToString().Trim();
                if (string.Equals(name.ToLower().Trim(), pname.ToLower().Trim()))
                    IsAvail = true;

            }
        }
        else
            IsAvail = false;
        return IsAvail;

    }
    public DataSet viewproductname(string ddlname)
    {
        DataSet ds = new DataSet();
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("spExistproductname", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(command);
                command.Parameters.Add(
                new SqlParameter("@ddlcompanyname", ddlname));


                da.Fill(ds);
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return ds;
    }

    public int Updateproducts(adddemoDB addcompany)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("spUpdateProducts", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ID", addcompany.ID));
                command.Parameters.Add(new SqlParameter("@Product", addcompany.pname));
                command.Parameters.Add(new SqlParameter("@Companyname", addcompany.ddlcname));
                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;

    }


    #endregion


    #region Add Job Function
    public int addJOBFunction(adddemoDB addJopFunction)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("spAddjobfunction", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@JobFunction", addJopFunction.jfunction));
                command.Parameters.Add(new SqlParameter("@ddlCompanyname", addJopFunction.ddlcname));
                rowsAffected = command.ExecuteNonQuery(); 
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
           
        }
        return rowsAffected;
    }
    public DataSet viewjobFunction(string ddlcname)
    {
        DataSet ds = new DataSet();
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("spAlreadyExistJobFunction", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(command);
                command.Parameters.Add(
                
                new SqlParameter("@ddlCompanyname", ddlcname));
                da.Fill(ds);
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return ds;
    }
    public bool AlreadyExistjobFunction(string ddlcname, string JFunction)
    {
        bool IsAvail = false;
        DataSet ds = viewjobFunction(ddlcname);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
           
            for (int i=0;i<=ds.Tables[0].Rows.Count-1;i++) 
            {
               
              string Function = ds.Tables[0].Rows[i]["JobFunction"].ToString().Trim();
                if (string.Equals(Function.ToLower().Trim(),JFunction.ToLower().Trim()))
                    IsAvail = true;
                    

            }
            
                
        }
        else
            IsAvail = false;
        return IsAvail;
    }
    public int UpdateJobFunction(adddemoDB addcompany)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("spUpdatJobFunction", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ID", addcompany.ID));
                command.Parameters.Add(new SqlParameter("@JobFunction", addcompany.pname));
                command.Parameters.Add(new SqlParameter("@Companyname", addcompany.ddlcname));
                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;

    }

    #endregion

    #region Add designation
    public int adddesignation(adddemoDB addJopFunction)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("spadddesignation", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Designation", addJopFunction.designation));
                command.Parameters.Add(new SqlParameter("@CompanyName", addJopFunction.ddlcname));
                command.Parameters.Add(new SqlParameter("@JobFunction", addJopFunction.ddljobfunction));
                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
            
        }
        return rowsAffected;
    }
    public DataSet viewdesignation(string strddljobfunction, string strcompanyname)
    {
        DataSet ds = new DataSet();
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("spAlreadyExistDesignation", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(command);
                command.Parameters.Add(
                new SqlParameter("@JobFunction",strddljobfunction));
                command.Parameters.Add(
                new SqlParameter("@CompanyName",strcompanyname));
                da.Fill(ds);
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
            

        }
        return ds;
    }
    public bool AlreadyExistdesignation(string designation, string strddljobfunction, string strcompanyname)
    {
        bool IsAvail = false;
        DataSet ds = viewdesignation(strddljobfunction, strcompanyname);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            for (int i=0;i<= ds.Tables[0].Rows.Count-1;i++)
            {
                string Designation = ds.Tables[0].Rows[i]["Designation"].ToString().Trim();
                if (string.Equals(Designation.ToLower().Trim(), designation.ToLower().Trim()))
                    IsAvail = true;
            }
            
        }
        else
            IsAvail = false;
        return IsAvail;
    }


    public DataTable ddljobfunctionViewBYCompanyName(string CompanyName)
    {
        
        DataTable dt = new DataTable();
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        try
        {
            using (SqlCommand command = new SqlCommand("spddljobfunctionViewBYCompanyName", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(
                new SqlParameter("@Companyname",CompanyName));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);

            }
            cnn.Close();
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    //public DataTable ddljobfunctionView(string Jobfunction)
    //{
    //    string strjobfunction = string.Empty;
        
           
    //        DataTable dt = new DataTable();
    //        string connetionString = null;
    //        SqlConnection cnn;
    //        connetionString = GetSqlConnection();
    //        cnn = new SqlConnection(connetionString);
    //        try
    //        {
    //            using (SqlCommand command = new SqlCommand("spddljobfunctionViewBYJobfunction", cnn))
    //            {
    //                cnn.Open();
    //                command.CommandType = CommandType.StoredProcedure;
    //                command.Parameters.Add(
    //                new SqlParameter("@JobFunction", Jobfunction));
    //                SqlDataAdapter da = new SqlDataAdapter(command);
    //                da.Fill(dt);
    //            }
    //            cnn.Close();
    //        }
    //        catch (Exception ex)
    //        {

    //        }
        
        
       
    //    return dt;
    //}

    



    #endregion

    #region Add EmpRole
    public int adddEmpRole(adddemoDB addJopFunction)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("spaddEmpRole", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Rolename", addJopFunction.strERole));
                command.Parameters.Add(new SqlParameter("@CompanyName", addJopFunction.ddlcname));
                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }
    public DataSet viewEmpRole(string ddldname)
    {
        DataSet ds = new DataSet();
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("spAlreadyExistEMPRole", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(command);
                
                command.Parameters.Add(
                new SqlParameter("@ddlCompanyname", ddldname));
                da.Fill(ds);
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return ds;
    }
    public bool AlreadyExistEmpRole(string rolename,string ddlname)
    {
        bool IsAvail = false;
        DataSet ds = viewEmpRole(ddlname);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                string Rolename = ds.Tables[0].Rows[i]["Rolename"].ToString().Trim();
                if (string.Equals(Rolename.ToLower().Trim(), rolename.ToLower().Trim()))
                    IsAvail = true;

            }
        }
        else
            IsAvail = false;
        return IsAvail;
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



    #region ddlloadenamelist method
    public DataTable ddlloadenamelist(string ddlnamelist)
    {
        DataTable dt = new DataTable();
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        string spquery = string.Empty;
        string spquery1 = string.Empty;
        if (ddlnamelist == "products" || ddlnamelist == "jobfunction")
        {
            spquery = "ddllist";
        }
        
        else if (ddlnamelist== "Emprole")
        {
            spquery = "ddllistEmp";

        }
        else if (ddlnamelist== "Designation")
        {
            spquery = "ddllist";    
        }

        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand(spquery, cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(command);

                da.Fill(dt);
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return dt;
    }
    public DataTable ddlloadenamelistViewinJobfunction(string ddlnamelist)
    {
        DataTable dt = new DataTable();
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        string spquery = string.Empty;
        string spquery1 = string.Empty;
        
         if (ddlnamelist == "Designation")
        {
            spquery = "ddllist1";
        }

        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand(spquery, cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(command);

                da.Fill(dt);
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return dt;
    }
    #endregion


    public adddemoDB BindContent(int id,string name)
    {
        adddemoDB result = new adddemoDB();
        try
        {
            DataSet dsContent = ViewByID(id,name);
            if (dsContent.Tables.Count > 0 && dsContent.Tables[0].Rows.Count > 0)
            {
                string cname = string.Empty;
                int ddlselect = 0;
                if (name== "Company")
                {
                    cname = Convert.ToString(dsContent.Tables[0].Rows[0]["Company"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(dsContent.Tables[0].Rows[0]["Company"])))
                        result.txtname = cname;
                }
                else if(name == "products")
                {
                    cname = Convert.ToString(dsContent.Tables[0].Rows[0]["Productname"]);
                    ddlselect = Convert.ToInt32(dsContent.Tables[0].Rows[0]["CompanyName"]);

                    if (!string.IsNullOrEmpty(Convert.ToString(dsContent.Tables[0].Rows[0]["Productname"]))&& !string.IsNullOrEmpty(Convert.ToString(dsContent.Tables[0].Rows[0]["Productname"])))
                    {
                         result.txtname = cname;
                         result.ddl = ddlselect;
                    }
                }
                else if (name == "Jobfunction")
                {
                    cname = Convert.ToString(dsContent.Tables[0].Rows[0]["JobFunction"]);
                    ddlselect = Convert.ToInt32(dsContent.Tables[0].Rows[0]["CompanyName"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(dsContent.Tables[0].Rows[0]["JobFunction"]))&& !string.IsNullOrEmpty(Convert.ToString(dsContent.Tables[0].Rows[0]["CompanyName"])))
                    {
                        result.txtname = cname;
                        result.ddl = ddlselect;
                    }
                }
            }
        }
        catch (Exception ex)
        {

        }
         return result;
    }

    public DataSet ViewByID(int ID,string name)
    {
        string spquery = string.Empty;
        DataSet ds = new DataSet();
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);

        switch (name)
        {
            case "Company":
                spquery = "spBindCompany";
                break;
            case "products":
                spquery = "spBindProduts";
                break;
            case "Jobfunction":
                spquery = "spBindJobFunction";
                break;
            default:
                spquery = "";
                break;
        }
            



        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand(spquery, cnn))
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

    #region viewEscalationlisting
    public DataSet viewEscalationlistingbyEmpId(string EmpID)
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
            using (SqlCommand command = new SqlCommand("ViewEscalationlistingbyEmpId", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(command);  
                command.Parameters.Add(
                new SqlParameter("@EmpID", EmpID));     
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
        catch(Exception ex)
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
        catch(Exception exAddedDate)
        {

        }
        return dsAddedDate;
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

    public DataSet  ViewescalationlistNotify()
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