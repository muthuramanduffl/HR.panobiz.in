using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for EmpDetail
/// </summary>
public class EmpPersonalDetail
{

    public int Sno { get; set; }
    public string EmpID { get; set; }
    public string EmailId { get; set; }
    public string Mobile { get; set; }
    public string Photo { get; set; }
    public string EmpFirstName { get; set; }
    public string EmpLastName { get; set; }
    public string WorkLocation { get; set; }
    public string GWorkLocation { get; set; }
    public string State { get; set; }
    public string Designation { get; set; }
    public string Jobfunction { get; set; }
    public string Role { get; set; }
    public string Department { get; set; }
    public string ClientName { get; set; }
    public DateTime? DOB { get; set; }
  
    public string Gender { get; set; }
    public string Supervisor1 { get; set; }
    public string Supervisor2 { get; set; }
    public string Supervisor3 { get; set; }
    public string Supervisor4 { get; set; }
    public string Supervisor5 { get; set; }
    public DateTime AddedDate { get; set; }
    public string AddedBy { get; set; }

    public DateTime? DOJ { get; set; }
    public string ReportTo { get; set; }
    public string Bloodgrp { get; set; }
    public string GeofencingStatus { get; set; }

    public string QualLevel { get; set; }
    public string Qual { get; set; }

    public string YrPass { get; set; }

    public string ResdAddress { get; set; }
    public string EmContactPerson { get; set; }
    public string EmContactMobile { get; set; }
    public string EmContactrelation { get; set; }
    public string refname { get; set; }
    public string refmobile { get; set; }
    public string refRelation { get; set; }

    public bool ConfirmFlag { get; set; }
    public string Remarks { get; set; }
    public DateTime UpdatedDate { get; set; }
    public string UpdatedBy { get; set; }
    public string ConfirmApprovedStatus { get; set; }
    public string Name_Aadhar { get; set; }
    public string FromYr { get; set; }
    public string ToYr { get; set; }
    public string PrevUAN_No { get; set; }
    public string PrevESIC_No { get; set; }
    public string AadharNo { get; set; }
    public string PanNo { get; set; }
    public string Name_PAN { get; set; }
    public string BankAccNo { get; set; }
    public string BankName { get; set; }
    
    public string IFSC_Code { get; set; }
    public string Nominee_name { get; set; }
    public string Nominee_relationship { get; set; }
    public string Nominee_address { get; set; }
    public string Fathername { get; set; }
    public string FDOB { get; set; }
    public string Mothername { get; set; }
    public string MDOB { get; set; }
    public string Marital { get; set; }
    public string Spouse_Name { get; set; }
    public string Spouse_DOB { get; set; }
    public string Kid1Name { get; set; }
    public string Kid1DOB { get; set; }
    public string Kid2Name { get; set; }
    public string Kid2DOB { get; set; }
    public string Kid3Name { get; set; }
    public string Kid3DOB { get; set; }

    public string EmpRole { get; set; }
    public string EmpRoleClient { get; set; }
    public string EmpRoleDept { get; set; }
    public string Recommender { get; set; }
    public string Approver { get; set; }
    public string ZoneDir { get; set; }

    public EmpPersonalDetail()
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
            if (HttpContext.Current.Session["EmpEmpId"] != null)
            {
                strEmpId = Convert.ToString(HttpContext.Current.Session["EmpEmpId"]);
            }
            if (string.IsNullOrEmpty(strEmpId))
            {
                if (HttpContext.Current.Request.Cookies["EmpLOGIN"] != null)
                {
                    System.Web.HttpCookie Logincookie = HttpContext.Current.Request.Cookies["EmpLOGIN"];
                    strEmpId = Logincookie["EmpEmpId"];
                }
            }
        }
        catch
        {
        }
        return strEmpId;
    }


    public DataSet ViewEmployeePersonalDetails(string stEmpID)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewEmployeePersonalDetails", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmpID", stEmpID));
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


    public int AddEmpDetails(EmpPersonalDetail emp)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("AddEmpDetails", cnn))
            {

                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ClientName", emp.ClientName));
                command.Parameters.Add(new SqlParameter("@Dept", emp.Department));
                command.Parameters.Add(new SqlParameter("@EmpID", emp.EmpID));
                command.Parameters.Add(new SqlParameter("@EmpFirstName", emp.EmpFirstName));

                command.Parameters.Add(new SqlParameter("@EmpLastName", emp.EmpLastName));
                command.Parameters.Add(new SqlParameter("@EmailId", emp.EmailId));
                command.Parameters.Add(new SqlParameter("@Mobile", emp.Mobile));
                command.Parameters.Add(new SqlParameter("@Gender", emp.Gender));

                command.Parameters.Add(new SqlParameter("@DOB", emp.DOB));
                command.Parameters.Add(new SqlParameter("@Role", emp.Role));
                command.Parameters.Add(new SqlParameter("@Designation", emp.Designation));
                command.Parameters.Add(new SqlParameter("@WorkLocation", emp.WorkLocation));
                command.Parameters.Add(new SqlParameter("@State", emp.State));
                command.Parameters.Add(new SqlParameter("@Supervisor1", emp.Supervisor1));
                command.Parameters.Add(new SqlParameter("@Supervisor2", emp.Supervisor2));
                command.Parameters.Add(new SqlParameter("@Supervisor3", emp.Supervisor3));
                command.Parameters.Add(new SqlParameter("@Supervisor4", emp.Supervisor4));
                command.Parameters.Add(new SqlParameter("@Supervisor5", emp.Supervisor5));
                command.Parameters.Add(new SqlParameter("@AddedBy", emp.AddedBy));
                command.Parameters.Add(new SqlParameter("@AddedDate", emp.AddedDate));
                command.Parameters.Add(new SqlParameter("@EmpRole", emp.EmpRole));
                command.Parameters.Add(new SqlParameter("@EmpRoleClient", emp.EmpRoleClient));
                command.Parameters.Add(new SqlParameter("@EmpRoleDept", emp.EmpRoleDept));
                command.Parameters.Add(new SqlParameter("@Recommender", emp.Recommender));
                command.Parameters.Add(new SqlParameter("@Approver", emp.Approver));
                command.Parameters.Add(new SqlParameter("@ZoneDir", emp.ZoneDir));
                command.Parameters.Add(new SqlParameter("@DOJ", emp.DOJ));
                
                

                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }
    public int AddSingleEmpDetailsByAdmin(EmpPersonalDetail emp)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("AddSingleEmpDetailsByAdmin", cnn))
            {

                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ClientName", emp.ClientName));
                command.Parameters.Add(new SqlParameter("@Dept", emp.Department));
                command.Parameters.Add(new SqlParameter("@EmpID", emp.EmpID));
                command.Parameters.Add(new SqlParameter("@EmpFirstName", emp.EmpFirstName));

                command.Parameters.Add(new SqlParameter("@EmpLastName", emp.EmpLastName));
                command.Parameters.Add(new SqlParameter("@EmailId", emp.EmailId));
                command.Parameters.Add(new SqlParameter("@Mobile", emp.Mobile));
                command.Parameters.Add(new SqlParameter("@Gender", emp.Gender));

                command.Parameters.Add(new SqlParameter("@DOB", emp.DOB));
                command.Parameters.Add(new SqlParameter("@DOJ", emp.DOJ));
                command.Parameters.Add(new SqlParameter("@Role", emp.Role));
                command.Parameters.Add(new SqlParameter("@Designation", emp.Designation));
                command.Parameters.Add(new SqlParameter("@WorkLocation", emp.WorkLocation));
                command.Parameters.Add(new SqlParameter("@State", emp.State));
                command.Parameters.Add(new SqlParameter("@Supervisor1", emp.Supervisor1));
                command.Parameters.Add(new SqlParameter("@Supervisor2", emp.Supervisor2));
                command.Parameters.Add(new SqlParameter("@Supervisor3", emp.Supervisor3));
                command.Parameters.Add(new SqlParameter("@Supervisor4", emp.Supervisor4));
                command.Parameters.Add(new SqlParameter("@Supervisor5", emp.Supervisor5));
                command.Parameters.Add(new SqlParameter("@AddedBy", emp.AddedBy));
                command.Parameters.Add(new SqlParameter("@AddedDate", emp.AddedDate));
                command.Parameters.Add(new SqlParameter("@ZoneDir", emp.ZoneDir));

                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }


    public int UpdateEmpDetails(EmpPersonalDetail emp)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateEmpDetails", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ClientName", emp.ClientName));
                command.Parameters.Add(new SqlParameter("@Dept", emp.Department));
                command.Parameters.Add(new SqlParameter("@EmpID", emp.EmpID));
                command.Parameters.Add(new SqlParameter("@EmpFirstName", emp.EmpFirstName));

                command.Parameters.Add(new SqlParameter("@EmpLastName", emp.EmpLastName));
                command.Parameters.Add(new SqlParameter("@EmailId", emp.EmailId));
                command.Parameters.Add(new SqlParameter("@Mobile", emp.Mobile));
                command.Parameters.Add(new SqlParameter("@WorkLocation", emp.WorkLocation));
                
           

                command.Parameters.Add(new SqlParameter("@ConfirmFlag", emp.ConfirmFlag));
                command.Parameters.Add(new SqlParameter("@Remarks", emp.Remarks));

                command.Parameters.Add(new SqlParameter("@UpdatedBy", emp.UpdatedBy));
                command.Parameters.Add(new SqlParameter("@UpdatedDate", emp.UpdatedDate));
                command.Parameters.Add(new SqlParameter("@ConfirmApprovedStatus", emp.ConfirmApprovedStatus));


                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }

     public int UpdateEmpDetailsGeo(EmpPersonalDetail emp)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateEmpDetailsGeo", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ClientName", emp.ClientName));
                command.Parameters.Add(new SqlParameter("@Dept", emp.Department));
                command.Parameters.Add(new SqlParameter("@EmpID", emp.EmpID));
                command.Parameters.Add(new SqlParameter("@EmpFirstName", emp.EmpFirstName));

                command.Parameters.Add(new SqlParameter("@EmpLastName", emp.EmpLastName));
                command.Parameters.Add(new SqlParameter("@EmailId", emp.EmailId));
                command.Parameters.Add(new SqlParameter("@Mobile", emp.Mobile));
                command.Parameters.Add(new SqlParameter("@WorkLocation", emp.WorkLocation));
                command.Parameters.Add(new SqlParameter("@GoogleAddress", emp.GWorkLocation));
                command.Parameters.Add(new SqlParameter("@ConfirmFlag", emp.ConfirmFlag));
                command.Parameters.Add(new SqlParameter("@Remarks", emp.Remarks));
                command.Parameters.Add(new SqlParameter("@GeofencingStatus", emp.GeofencingStatus));

                command.Parameters.Add(new SqlParameter("@UpdatedBy", emp.UpdatedBy));
                command.Parameters.Add(new SqlParameter("@UpdatedDate", emp.UpdatedDate));
                command.Parameters.Add(new SqlParameter("@ConfirmApprovedStatus", emp.ConfirmApprovedStatus));


                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }


    public int UpdateBulkEmpDetails(EmpPersonalDetail emp)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateBulkEmpDetails", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmpID", emp.EmpID));
                command.Parameters.Add(new SqlParameter("@DOJ", emp.DOJ));
                command.Parameters.Add(new SqlParameter("@Bloodgrp", emp.Bloodgrp));
                command.Parameters.Add(new SqlParameter("@QualLevel", emp.QualLevel));
                command.Parameters.Add(new SqlParameter("@Qual", emp.Qual));

                command.Parameters.Add(new SqlParameter("@YrPass", emp.YrPass));
                command.Parameters.Add(new SqlParameter("@ResAddress", emp.ResdAddress));
                command.Parameters.Add(new SqlParameter("@EmContactPerson", emp.EmContactPerson));
                command.Parameters.Add(new SqlParameter("@EmContactMobile", emp.EmContactMobile));

                command.Parameters.Add(new SqlParameter("@EmContactrelation", emp.EmContactrelation));
                command.Parameters.Add(new SqlParameter("@refname", emp.refname));
                command.Parameters.Add(new SqlParameter("@refmobile", emp.refmobile));
                command.Parameters.Add(new SqlParameter("@refRelation", emp.refRelation));

                command.Parameters.Add(new SqlParameter("@UpdatedBy", emp.UpdatedBy));
                command.Parameters.Add(new SqlParameter("@UpdatedDate", emp.UpdatedDate));


                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }

    public DataSet ViewEmpProfileDetails(string stEmpID)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewEmpProfileDetails", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmpID", stEmpID));
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

    public DataSet ViewSupEmpProfileDetails(string stEmpID)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewSupEmpProfileDetails", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmpID", stEmpID));
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


    public int UpdateEmpPersonalDetailsByAdmin(EmpPersonalDetail emp)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateEmpPersonalDetailsByAdmin1", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmpID", emp.EmpID));
                command.Parameters.Add(new SqlParameter("@EmpFirstName", emp.EmpFirstName));

                command.Parameters.Add(new SqlParameter("@EmpLastName", emp.EmpLastName));
                command.Parameters.Add(new SqlParameter("@EmailId", emp.EmailId));
                command.Parameters.Add(new SqlParameter("@Mobile", emp.Mobile));
                command.Parameters.Add(new SqlParameter("@Gender", emp.Gender));
                command.Parameters.Add(new SqlParameter("@ClientName", emp.ClientName));
                command.Parameters.Add(new SqlParameter("@Dept", emp.Department));

                command.Parameters.Add(new SqlParameter("@DOB", emp.DOB));
                command.Parameters.Add(new SqlParameter("@DOJ", emp.DOJ));
                command.Parameters.Add(new SqlParameter("@Role", emp.Role));
                command.Parameters.Add(new SqlParameter("@Designation", emp.Designation));
                command.Parameters.Add(new SqlParameter("@Jobfunction", emp.Jobfunction));
                command.Parameters.Add(new SqlParameter("@WorkLocation", emp.WorkLocation));
                command.Parameters.Add(new SqlParameter("@Supervisor1", emp.Supervisor1));
                command.Parameters.Add(new SqlParameter("@Supervisor2", emp.Supervisor2));
                command.Parameters.Add(new SqlParameter("@Supervisor3", emp.Supervisor3));


                command.Parameters.Add(new SqlParameter("@UpdatedBy", emp.UpdatedBy));
                command.Parameters.Add(new SqlParameter("@UpdatedDate", emp.UpdatedDate));


                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }

    public int AddDOB_MonthTable(string EmpID, DateTime DOB,string month)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("AddDOB_MonthTable", cnn))
            {

                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmpID", EmpID));
                command.Parameters.Add(new SqlParameter("@DOB", DOB));
                command.Parameters.Add(new SqlParameter("@Month", month));
                command.Parameters.Add(new SqlParameter("@AddedDate", Utility.IndianTime));

                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }

    public DataSet ViewNotUploadedKYCList()
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewNotUploadedKYCList", cnn))
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
    
    public DataSet ViewPendingFailedKYCList()
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewPendingFailedKYCList", cnn))
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
    public DataSet ViewKYCStatusBYEmpID_Field(string EmpID, string fieldname)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewKYCStatusBYEmpID_Field", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmpID", EmpID));
                command.Parameters.Add(new SqlParameter("@fieldname", fieldname));
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
    
    public int AddEmpInformSheet_Details(EmpPersonalDetail emp)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("AddEmpInformSheet_Details", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmpId", emp.EmpID));
                command.Parameters.Add(new SqlParameter("@DOJ", emp.DOJ));
                command.Parameters.Add(new SqlParameter("@Name_Aadhar", emp.Name_Aadhar));
                command.Parameters.Add(new SqlParameter("@Gender", emp.Gender));
                command.Parameters.Add(new SqlParameter("@Designation", emp.Designation));
                command.Parameters.Add(new SqlParameter("@WorkLocation", emp.WorkLocation));
                command.Parameters.Add(new SqlParameter("@CurrentAddress", emp.ResdAddress));

                command.Parameters.Add(new SqlParameter("@MaxQualifLevel", emp.QualLevel));
                command.Parameters.Add(new SqlParameter("@QualifName", emp.Qual));
                command.Parameters.Add(new SqlParameter("@FromYr", emp.FromYr));
                command.Parameters.Add(new SqlParameter("@ToYr", emp.ToYr));
                command.Parameters.Add(new SqlParameter("@PrevUAN_No", emp.PrevUAN_No));
                command.Parameters.Add(new SqlParameter("@PrevESIC_No", emp.PrevESIC_No));
                command.Parameters.Add(new SqlParameter("@EmailID", emp.EmailId));
                command.Parameters.Add(new SqlParameter("@MobileNo", emp.Mobile));
                command.Parameters.Add(new SqlParameter("@AadharNo", emp.AadharNo));
                command.Parameters.Add(new SqlParameter("@DOB", emp.DOB));

                command.Parameters.Add(new SqlParameter("@PanNo", emp.PanNo));
                command.Parameters.Add(new SqlParameter("@Name_PAN", emp.Name_PAN));
                command.Parameters.Add(new SqlParameter("@BankName", emp.BankName));
                command.Parameters.Add(new SqlParameter("@BankAccNo", emp.BankAccNo));
                command.Parameters.Add(new SqlParameter("@IFSC_Code", emp.IFSC_Code));
                command.Parameters.Add(new SqlParameter("@Bloodgrp", emp.Bloodgrp));

                command.Parameters.Add(new SqlParameter("@Nominee_name", emp.Nominee_name));
                command.Parameters.Add(new SqlParameter("@Nominee_relationship", emp.Nominee_relationship));
                command.Parameters.Add(new SqlParameter("@Nominee_address", emp.Nominee_address));

                command.Parameters.Add(new SqlParameter("@EmContact_Person", emp.EmContactPerson));
                command.Parameters.Add(new SqlParameter("@EmContact_Mobile", emp.EmContactMobile));
                command.Parameters.Add(new SqlParameter("@EmContact_relationship", emp.EmContactrelation));

                command.Parameters.Add(new SqlParameter("@Fathername", emp.Fathername));
                command.Parameters.Add(new SqlParameter("@FDOB", emp.FDOB));
                command.Parameters.Add(new SqlParameter("@Mothername", emp.Mothername));
                command.Parameters.Add(new SqlParameter("@MDOB", emp.MDOB));
                command.Parameters.Add(new SqlParameter("@Marital", emp.Marital));

                command.Parameters.Add(new SqlParameter("@Spouse_Name", emp.Spouse_Name));
                command.Parameters.Add(new SqlParameter("@Spouse_DOB", emp.Spouse_DOB));
                command.Parameters.Add(new SqlParameter("@Kid1Name", emp.Kid1Name));
                command.Parameters.Add(new SqlParameter("@Kid1DOB", emp.Kid1DOB));

                command.Parameters.Add(new SqlParameter("@Kid2Name", emp.Kid2Name));
                command.Parameters.Add(new SqlParameter("@Kid2DOB", emp.Kid2DOB));
                command.Parameters.Add(new SqlParameter("@Kid3Name", emp.Kid3Name));
                command.Parameters.Add(new SqlParameter("@Kid3DOB", emp.Kid3DOB));

                command.Parameters.Add(new SqlParameter("@UpdatedDate", Utility.IndianTime));

                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }

    public int UpdateEmpInformSheet_Details(EmpPersonalDetail emp)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateEmpInformSheet_Details", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmpId", emp.EmpID));
                command.Parameters.Add(new SqlParameter("@DOJ", emp.DOJ));
                command.Parameters.Add(new SqlParameter("@Name_Aadhar", emp.Name_Aadhar));
                command.Parameters.Add(new SqlParameter("@Gender", emp.Gender));
                command.Parameters.Add(new SqlParameter("@Designation", emp.Designation));
                command.Parameters.Add(new SqlParameter("@WorkLocation", emp.WorkLocation));
                command.Parameters.Add(new SqlParameter("@CurrentAddress", emp.ResdAddress));

                command.Parameters.Add(new SqlParameter("@MaxQualifLevel", emp.QualLevel));
                command.Parameters.Add(new SqlParameter("@QualifName", emp.Qual));
                command.Parameters.Add(new SqlParameter("@FromYr", emp.FromYr));
                command.Parameters.Add(new SqlParameter("@ToYr", emp.ToYr));
                command.Parameters.Add(new SqlParameter("@PrevUAN_No", emp.PrevUAN_No));
                command.Parameters.Add(new SqlParameter("@PrevESIC_No", emp.PrevESIC_No));
                command.Parameters.Add(new SqlParameter("@EmailID", emp.EmailId));
                command.Parameters.Add(new SqlParameter("@MobileNo", emp.Mobile));
                command.Parameters.Add(new SqlParameter("@AadharNo", emp.AadharNo));
                command.Parameters.Add(new SqlParameter("@DOB", emp.DOB));

                command.Parameters.Add(new SqlParameter("@PanNo", emp.PanNo));
                command.Parameters.Add(new SqlParameter("@Name_PAN", emp.Name_PAN));
                command.Parameters.Add(new SqlParameter("@BankName", emp.BankName));
                command.Parameters.Add(new SqlParameter("@BankAccNo", emp.BankAccNo));
                command.Parameters.Add(new SqlParameter("@IFSC_Code", emp.IFSC_Code));
                command.Parameters.Add(new SqlParameter("@Bloodgrp", emp.Bloodgrp));

                command.Parameters.Add(new SqlParameter("@Nominee_name", emp.Nominee_name));
                command.Parameters.Add(new SqlParameter("@Nominee_relationship", emp.Nominee_relationship));
                command.Parameters.Add(new SqlParameter("@Nominee_address", emp.Nominee_address));

                command.Parameters.Add(new SqlParameter("@EmContact_Person", emp.EmContactPerson));
                command.Parameters.Add(new SqlParameter("@EmContact_Mobile", emp.EmContactMobile));
                command.Parameters.Add(new SqlParameter("@EmContact_relationship", emp.EmContactrelation));

                command.Parameters.Add(new SqlParameter("@Fathername", emp.Fathername));
                command.Parameters.Add(new SqlParameter("@FDOB", emp.FDOB));
                command.Parameters.Add(new SqlParameter("@Mothername", emp.Mothername));
                command.Parameters.Add(new SqlParameter("@MDOB", emp.MDOB));
                command.Parameters.Add(new SqlParameter("@Marital", emp.Marital));

                command.Parameters.Add(new SqlParameter("@Spouse_Name", emp.Spouse_Name));
                command.Parameters.Add(new SqlParameter("@Spouse_DOB", emp.Spouse_DOB));
                command.Parameters.Add(new SqlParameter("@Kid1Name", emp.Kid1Name));
                command.Parameters.Add(new SqlParameter("@Kid1DOB", emp.Kid1DOB));

                command.Parameters.Add(new SqlParameter("@Kid2Name", emp.Kid2Name));
                command.Parameters.Add(new SqlParameter("@Kid2DOB", emp.Kid2DOB));
                command.Parameters.Add(new SqlParameter("@Kid3Name", emp.Kid3Name));
                command.Parameters.Add(new SqlParameter("@Kid3DOB", emp.Kid3DOB));

                command.Parameters.Add(new SqlParameter("@UpdatedDate", Utility.IndianTime));

                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }
    public DataSet ViewEmpInformSheet_DetailsByID(string EmpID)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewEmpInformSheet_DetailsByID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmpID", EmpID));
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
    public DataSet ViewEmpDetailsByColumn(string stval,string stmode)
    {
        string connectionString = null;
        SqlConnection cnn;
        connectionString = GetSqlConnection();
        cnn = new SqlConnection(connectionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewEmpDetailsByColumn", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@val", stval));
                command.Parameters.Add(new SqlParameter("@mode", stmode));
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