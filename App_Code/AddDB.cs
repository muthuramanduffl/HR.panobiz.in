using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for AddDB
/// </summary>
public class AddDB
{
    public int ID { get; set; }
   
    public string State { get; set; }
    public string Location { get; set; }
    public string assignedCompName { get; set; }
    public string jobfunction { get; set; }
    public string product { get; set; }
    public string designation { get; set; }
    public string openings { get; set; }
    public string ReqName { get; set; }
    public string ReqMobile { get; set; }
    public string RecomName { get; set; }
    public string RecomMobile { get; set; }
    public string ApproverName { get; set; }
    public string ApproverMobile { get; set; }
    public string AddedBy { get; set; }
    public DateTime AddedDate { get; set; }
    public string UpdatedBy { get; set; }
    public DateTime UpdatedDate { get; set; }
    public bool NotifyRequester { get; set; }
    public bool NotifyRecommender { get; set; }
    public bool NotifyApprover { get; set; }
    public bool RecApprovFlag { get; set; }
    public string RecAppRemarks { get; set; }
    public string RecApprov { get; set; }
    public DateTime RecApprovDate { get; set; }
    public DateTime OfferLetterPDFAcceptedDate { get; set; }
    public DateTime ExpectedDOJ { get; set; }
    public string OfferAcceptStatus{get; set;}
    public string CandidateJobOfferStatus {get; set;}
    public DateTime CandidateJobOfferUpdatedDate { get; set; }
    public string candID{get; set;}

    public string EmpRole { get; set; }
    
    public string ReqRemarks { get; set; }
    public string Recommendedstatus { get; set; }
    public string RecRemarks { get; set; }
    public string Approvedstatus { get; set; }
    public string ApprovRemarks { get; set; }

    public AddDB()
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
    public DataSet ViewState()
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataSet ds = new DataSet();
        using (SqlCommand command = new SqlCommand("ViewState", cnn))
        {
            cnn.Open();
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(ds);
        }

        cnn.Close();
        return ds;
    }
    public DataSet ViewProduct()
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataSet ds = new DataSet();
        using (SqlCommand command = new SqlCommand("ViewProduct", cnn))
        {
            cnn.Open();
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(ds);
        }

        cnn.Close();
        return ds;
    }
    public DataSet ViewCityBYStateID(string stateID)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataSet ds = new DataSet();
        using (SqlCommand command = new SqlCommand("ViewCityBYStateID", cnn))
        {
            cnn.Open();
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@StateID", stateID));
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(ds);
        }

        cnn.Close();
        return ds;
    }

    public int AddManPowerRequest(AddDB add)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        string ReqID = string.Empty;
        try
        {
            using (SqlCommand command = new SqlCommand("AddManPowerRequest", cnn))
            {

                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@State", add.State));
                command.Parameters.Add(new SqlParameter("@Location", add.Location));
                command.Parameters.Add(new SqlParameter("@assignedCompName", add.assignedCompName));
                command.Parameters.Add(new SqlParameter("@jobfunction", add.jobfunction));


                command.Parameters.Add(new SqlParameter("@product", add.product));
                command.Parameters.Add(new SqlParameter("@designation", add.designation));
                command.Parameters.Add(new SqlParameter("@openings", add.openings));
                //command.Parameters.Add(new SqlParameter("@ReqName", add.ReqName));
                //command.Parameters.Add(new SqlParameter("@ReqMobile", add.ReqMobile));
                //command.Parameters.Add(new SqlParameter("@RecomName", add.RecomName));
                //command.Parameters.Add(new SqlParameter("@RecomMobile", add.RecomMobile));
                command.Parameters.Add(new SqlParameter("@AddedBy", add.AddedBy));
                command.Parameters.Add(new SqlParameter("@AddedDate", add.AddedDate));
                command.Parameters.Add(new SqlParameter("@NotifyRecommender", add.NotifyRecommender));
                command.Parameters.Add(new SqlParameter("@NotifyApprover", add.NotifyApprover));

                command.Parameters.Add("@ID", SqlDbType.Int);
                command.Parameters["@ID"].Direction = ParameterDirection.Output;
                rowsAffected = command.ExecuteNonQuery();

                int ID = Convert.ToInt32(command.Parameters["@ID"].Value);

                ReqID = "MPR" + string.Format("{0:D2}", ID);
                UpdateMPReqID(ReqID, ID);
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }
    public int UpdateMPReqID(string ReqID, int ID)
    {
        int rowsAffected = 0;
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        try
        {
            using (SqlCommand cmd = new SqlCommand("UpdateMPReqID", cnn))
            {
                cnn.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@RequestID", ReqID));
                cmd.Parameters.Add(new SqlParameter("@Id", ID));
                rowsAffected = int.Parse(cmd.ExecuteNonQuery().ToString());
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }
    public DataSet ViewCompname()
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataSet ds = new DataSet();
        using (SqlCommand command = new SqlCommand("ViewCompname", cnn))
        {
            cnn.Open();
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(ds);
        }

        cnn.Close();
        return ds;
    }
    public DataSet ViewJobFunction()
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataSet ds = new DataSet();
        using (SqlCommand command = new SqlCommand("ViewJobFunction", cnn))
        {
            cnn.Open();
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(ds);
        }

        cnn.Close();
        return ds;
    }
    public DataSet ViewProducts(string PID)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataSet ds = new DataSet();
        using (SqlCommand command = new SqlCommand("ViewProducts", cnn))
        {
            cnn.Open();
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@PID", PID));
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(ds);
        }

        cnn.Close();
        return ds;
    }
    
    public DataSet ViewManPowerNotification(string EmpID,string EmpRole)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataSet ds = new DataSet();
        using (SqlCommand command = new SqlCommand("ViewManPowerNotification", cnn))
        {
            cnn.Open();
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@EmpID", EmpID)); 
            command.Parameters.Add(new SqlParameter("@EmpRole", EmpRole));
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(ds);
        }

        cnn.Close();
        return ds;
    }
    public DataSet ViewManPowerRequistionByID(int ID)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataSet ds = new DataSet();
        using (SqlCommand command = new SqlCommand("ViewManPowerRequistionByID", cnn))
        {
            cnn.Open();
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@ID", ID));
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(ds);
        }

        cnn.Close();
        return ds;
    }
    
    public DataSet ViewEmpReqDetailsByID(int ID)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataSet ds = new DataSet();
        using (SqlCommand command = new SqlCommand("ViewEmpReqDetailsByID", cnn))
        {
            cnn.Open();
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@ID", ID));
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(ds);
        }

        cnn.Close();
        return ds;
    }

    public int UpdateManPowerRequest(AddDB add)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        string ReqID = string.Empty;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateManPowerRequest", cnn))
            {

                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@State", add.State));
                command.Parameters.Add(new SqlParameter("@Location", add.Location));
                command.Parameters.Add(new SqlParameter("@assignedCompName", add.assignedCompName));
                command.Parameters.Add(new SqlParameter("@jobfunction", add.jobfunction));


                command.Parameters.Add(new SqlParameter("@product", add.product));
                command.Parameters.Add(new SqlParameter("@designation", add.designation));
                command.Parameters.Add(new SqlParameter("@openings", add.openings));
                command.Parameters.Add(new SqlParameter("@UpdatedBy", add.UpdatedBy));
                command.Parameters.Add(new SqlParameter("@UpdatedDate", add.UpdatedDate));
                command.Parameters.Add(new SqlParameter("@EmpRole", add.EmpRole));
                command.Parameters.Add(new SqlParameter("@ID", add.ID));

                command.Parameters.Add(new SqlParameter("@NotifyRequester", add.NotifyRequester));
                command.Parameters.Add(new SqlParameter("@NotifyRecommender", add.NotifyRecommender));
                command.Parameters.Add(new SqlParameter("@NotifyApprover", add.NotifyApprover));

                command.Parameters.Add(new SqlParameter("@RecApprovDate", add.RecApprovDate));
                command.Parameters.Add(new SqlParameter("@ReqRemarks", add.ReqRemarks));
                command.Parameters.Add(new SqlParameter("@Recommendedstatus", add.Recommendedstatus));
                command.Parameters.Add(new SqlParameter("@RecRemarks", add.RecRemarks));
                command.Parameters.Add(new SqlParameter("@Approvedstatus", add.Approvedstatus));
                command.Parameters.Add(new SqlParameter("@ApprovRemarks", add.ApprovRemarks));

                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }

    public int UpdateManPowerNotify(string EmpRole,string supEmpID)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateManPowerNotify", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@EmpRole", EmpRole));
                command.Parameters.Add(new SqlParameter("@supEmpID", supEmpID));

                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }

    public DataSet ViewManPowerRequisitionListByEmpRole(string EmpID, string EmpRole)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataSet ds = new DataSet();
        using (SqlCommand command = new SqlCommand("ViewManPowerRequisitionListByEmpRole", cnn))
        {
            cnn.Open();
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@EmpID", EmpID));
            command.Parameters.Add(new SqlParameter("@EmpRole", EmpRole));
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(ds);
        }

        cnn.Close();
        return ds;
    }

    public void BindCompname(DropDownList ddl)
    {
        AddDB add = new AddDB();
        DataSet ds = add.ViewCompname();
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            string stText = string.Empty;
            string stValue = string.Empty;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                stText = Convert.ToString(ds.Tables[0].Rows[i]["Company"]);
                stValue = Convert.ToString(ds.Tables[0].Rows[i]["ID"]);
                ddl.Items.Add(new ListItem(stText, stValue));
            }
            ddl.DataBind();
        }
    }
    public void BindJobFunction(DropDownList ddl)
    {
        AddDB add = new AddDB();
        DataSet ds = add.ViewJobFunction();
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            string stText = string.Empty;
            string stValue = string.Empty;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                stText = Convert.ToString(ds.Tables[0].Rows[i]["JobFunction"]);
                stValue = Convert.ToString(ds.Tables[0].Rows[i]["ID"]);
                ddl.Items.Add(new ListItem(stText, stValue));
            }
            ddl.DataBind();
        }
    }
    public void BindProducts(DropDownList ddl, string ProductID)
    {
        AddDB add = new AddDB();
        DataSet ds = add.ViewProducts(ProductID);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            string stText = string.Empty;
            string stValue = string.Empty;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                stText = Convert.ToString(ds.Tables[0].Rows[i]["productname"]);
                stValue = Convert.ToString(ds.Tables[0].Rows[i]["ID"]);
                ddl.Items.Add(new ListItem(stText, stValue));
            }
            ddl.DataBind();
        }
    }
    public void BindProduct(DropDownList ddl)
    {
        AddDB add = new AddDB();
        DataSet ds = add.ViewProduct();
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            string stText = string.Empty;
            string stValue = string.Empty;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                stText = Convert.ToString(ds.Tables[0].Rows[i]["productname"]);
                stValue = Convert.ToString(ds.Tables[0].Rows[i]["ID"]);
                ddl.Items.Add(new ListItem(stText, stValue));
            }
            ddl.DataBind();
        }
    }
    public void Bindstate(DropDownList ddl)
    {
        AddDB add = new AddDB();
        DataSet ds = add.ViewState();
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            string stText = string.Empty;
            string stValue = string.Empty;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                stText = Convert.ToString(ds.Tables[0].Rows[i]["State"]);
                stValue = Convert.ToString(ds.Tables[0].Rows[i]["StateID"]);
                ddl.Items.Add(new ListItem(stText, stValue));
            }
            ddl.DataBind();
        }
    }
    public void BindCity(string ststateID, DropDownList ddl)
    {
        ddl.Items.Clear();
        ddl.Items.Insert(0, new ListItem("Select", ""));

        AddDB add = new AddDB();
        DataSet ds = add.ViewCityBYStateID(ststateID);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            string stText = string.Empty;
            string stValue = string.Empty;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                stText = Convert.ToString(ds.Tables[0].Rows[i]["City"]);
                stValue = Convert.ToString(ds.Tables[0].Rows[i]["CityID"]);
                ddl.Items.Add(new ListItem(stText, stValue));
            }
            ddl.DataBind();
        }
    }

    public void BindDesignation(string stfuncID, DropDownList ddl)
    {
        ddl.Items.Clear();
        ddl.Items.Insert(0, new ListItem("Select", ""));

        AddDB add = new AddDB();
        DataSet ds = add.ViewDesignByJobFuncID(stfuncID);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            string stText = string.Empty;
            string stValue = string.Empty;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                stText = Convert.ToString(ds.Tables[0].Rows[i]["Designation"]);
                stValue = Convert.ToString(ds.Tables[0].Rows[i]["Sno"]);
                ddl.Items.Add(new ListItem(stText, stValue));
            }
            ddl.DataBind();
        }
    }
    public void BindDesignationnew(DropDownList ddl)
    {
        AddDB add = new AddDB();
        DataSet ds = add.ViewDesignation();
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            string stText = string.Empty;
            string stValue = string.Empty;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                stText = Convert.ToString(ds.Tables[0].Rows[i]["Designation"]);
                stValue = Convert.ToString(ds.Tables[0].Rows[i]["Sno"]);
                ddl.Items.Add(new ListItem(stText, stValue));
            }
            ddl.DataBind();
        }
    }
    public DataSet ViewDesignByJobFuncID(string FuncID)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataSet ds = new DataSet();
        using (SqlCommand command = new SqlCommand("ViewDesignByJobFuncID", cnn))
        {
            cnn.Open();
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@FuncID", FuncID));
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(ds);
        }

        cnn.Close();
        return ds;
    }
    public DataSet ViewDesignation()
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataSet ds = new DataSet();
        using (SqlCommand command = new SqlCommand("ViewDesignation", cnn))
        {
            cnn.Open();
          
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(ds);
        }

        cnn.Close();
        return ds;
    }
    public void BindEmpRoles(ListBox ddl)
    {
        DataSet ds1 = ViewEmpRoles();
        if (ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                string stRolename = Convert.ToString(ds1.Tables[0].Rows[i]["Rolename"]);
                string stID = Convert.ToString(ds1.Tables[0].Rows[i]["Sno"]);
                ddl.Items.Add(new ListItem(stRolename, stID));
            }
            ddl.DataBind();
        }
    }

    public DataSet ViewEmpRoles()
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataSet ds = new DataSet();
        using (SqlCommand command = new SqlCommand("ViewEmpRoles", cnn))
        {
            cnn.Open();
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(ds);
        }

        cnn.Close();
        return ds;
    }
    public string Getseparate(string emprole,string R1,string R2,string R3)
    {
        string ERole = string.Empty;

        if (emprole.Contains(","))
        {
            string[] a1_values = emprole.Split(',');
            foreach (string item in a1_values)
            {
                if (item == R1)
                {
                    ERole = R1;
                    break;
                }
                else if(item == R2)
                {
                    ERole = R2;
                    break;
                }
                else if (item == R3)
                {
                    ERole = R3;
                    break;
                }
            }
        }
        else
        {
            ERole = emprole;
        }
        return ERole;
    }

    public DataSet ViewCandidateListByEmpRole(string EmpID, string EmpRole)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataSet ds = new DataSet();
        using (SqlCommand command = new SqlCommand("ViewCandidateListByEmpRole", cnn))
        {
            cnn.Open();
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@EmpID", EmpID));
            command.Parameters.Add(new SqlParameter("@EmpRole", EmpRole));
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(ds);
        }

        cnn.Close();
        return ds;
    }

    public DataSet ViewCandidateListforRecommendation(string EmpID)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataSet ds = new DataSet();
        using (SqlCommand command = new SqlCommand("ViewCandidateListforRecommendation", cnn))
        {
            cnn.Open();
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@EmpID", EmpID));
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(ds);
        }

        cnn.Close();
        return ds;
    }


    
    public DataSet ViewHRVerifyList(string EmpID, string EmpRole)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataSet ds = new DataSet();
        using (SqlCommand command = new SqlCommand("ViewHRVerifyList", cnn))
        {
            cnn.Open();
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@EmpID", EmpID));
            command.Parameters.Add(new SqlParameter("@EmpRole", EmpRole));
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(ds);
        }

        cnn.Close();
        return ds;
    }

    public int UpdateStatusforReport(string stmode,string stvalue,string EmpID)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        string ReqID = string.Empty;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateStatusforReport", cnn))
            {

                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@stmode", stmode));
                command.Parameters.Add(new SqlParameter("@stvalue", stvalue));
                command.Parameters.Add(new SqlParameter("@EmpID", EmpID));

                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }
    public DataSet ViewDesignationByID(string DesignID)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewDesignationByID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@DesignID", DesignID));
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
    public DataSet ViewClientByID(int DesignID)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewClientByID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@DesignID", DesignID));
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
    public DataSet ViewProductByID(string DesignID)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewProductByID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@DesignID", DesignID));
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
    public DataSet ViewJobFunctionByID(string DesignID)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewJobFunctionByID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@DesignID", DesignID));
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
    public DataSet ViewHRRRHEmail(string clientID, string HRRHID)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataSet ds = new DataSet();
        using (SqlCommand command = new SqlCommand("ViewHRRRHEmail", cnn))
        {
            cnn.Open();
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@clientID", clientID));
            command.Parameters.Add(new SqlParameter("@HRRHID", HRRHID));
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(ds);
        }

        cnn.Close();
        return ds;
    }

    public DataSet ViewHRHRRHEmail(string clientID, string HR,string HRRH)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataSet ds = new DataSet();
        using (SqlCommand command = new SqlCommand("ViewHRHRRHEmail", cnn))
        {
            cnn.Open();
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@clientID", clientID));
            command.Parameters.Add(new SqlParameter("@HR", HR));
            command.Parameters.Add(new SqlParameter("@HRRH", HRRH));
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(ds);
        }

        cnn.Close();
        return ds;
    }

    public DataSet ViewPayrollEmailID()
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataSet ds = new DataSet();
        using (SqlCommand command = new SqlCommand("ViewPayrollEmailID", cnn))
        {
            cnn.Open();
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(ds);
        }

        cnn.Close();
        return ds;
    }

    public DataSet ViewOBOEmailID()
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataSet ds = new DataSet();
        using (SqlCommand command = new SqlCommand("ViewOBOEmailID", cnn))
        {
            cnn.Open();
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(ds);
        }

        cnn.Close();
        return ds;
    }

    public DataSet ViewOfferLetterErrorsListing(string pagename)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataSet ds = new DataSet();
        try
        { 
            using (SqlCommand command = new SqlCommand("ViewOfferLetterErrorsListing", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@pagename", pagename));
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

    public int AddOfferLetterErrors(string pagename, string errorlist, string comments, 
        string addedby, string candID,string errstatus)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        string ReqID = string.Empty;
        try
        {
            using (SqlCommand command = new SqlCommand("AddOfferLetterErrors", cnn))
            {

                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@pagename", pagename));
                command.Parameters.Add(new SqlParameter("@errorlist", errorlist));
                command.Parameters.Add(new SqlParameter("@comments", comments));
                command.Parameters.Add(new SqlParameter("@AddedBy", addedby));
                command.Parameters.Add(new SqlParameter("@AddedDate", Utility.IndianTime));
                command.Parameters.Add(new SqlParameter("@candID", candID));
                command.Parameters.Add(new SqlParameter("@errstatus", errstatus));

                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }

    public DataSet ViewCandidateOfferLetterErrorByID(int ID)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewCandidateOfferLetterErrorByID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ID", ID));
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

    public int UpdateCandidateOfferLetterErrors(string pdfstatus, string Updatedby, string candID)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        string ReqID = string.Empty;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateCandidateOfferLetterErrors", cnn))
            {

                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@pdfstatus", pdfstatus));
                command.Parameters.Add(new SqlParameter("@UpdatedBy", Updatedby));
                command.Parameters.Add(new SqlParameter("@UpdatedDate", Utility.IndianTime));
                command.Parameters.Add(new SqlParameter("@candID", candID));

                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }
    
    public DataSet ViewOfferLetterErrorsNameByErrID(string errID)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewOfferLetterErrorsNameByErrID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@errID", errID));
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

    public DataSet GetMonthDaysbyTodayDate(string todaydate)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("GetMonthDaysbyTodayDate", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
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

    public DataSet GetPrevMonthDaysbyTodayDate(string todaydate)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("GetPrevMonthDaysbyTodayDate", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
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

    public DataSet GetThreeMonthDaysbyTodayDate(string todaydate)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("GetThreeMonthDaysbyTodayDate", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
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



    public DataSet ViewOfferLetterErrorByCandID(string candID)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewOfferLetterErrorByCandID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@candID", candID));
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
    public DataSet ViewPendingOfferLetterErrorsByErrID(string errID, string candID)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewPendingOfferLetterErrorsByErrID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@errID", errID));
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@candID", candID));
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

    public int UpdateOfferLetterErrors(string Sno,string updatedby, string errstatus)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        string ReqID = string.Empty;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateOfferLetterErrors", cnn))
            {

                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Sno", Sno));
                command.Parameters.Add(new SqlParameter("@Updatedby", updatedby));
                command.Parameters.Add(new SqlParameter("@UpdatedDate", Utility.IndianTime));
                command.Parameters.Add(new SqlParameter("@errstatus", errstatus));

                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }

    public int UpdateOfferLetterErrorsResolved(string Sno,string updatedby, string errstatus)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        string ReqID = string.Empty;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateOfferLetterErrorsResolved", cnn))
            {

                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Sno", Sno));
                command.Parameters.Add(new SqlParameter("@Updatedby", updatedby));
                command.Parameters.Add(new SqlParameter("@UpdatedDate", Utility.IndianTime));
                command.Parameters.Add(new SqlParameter("@errstatus", errstatus));

                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }


    public int UpdateCandidateOfferLetterSentStatus(string candID)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        string ReqID = string.Empty;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateCandidateOfferLetterSentStatus", cnn))
            {

                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
               
                command.Parameters.Add(new SqlParameter("@OfferSentStatus", "Yes"));
                command.Parameters.Add(new SqlParameter("@OfferSentDate", Utility.IndianTime));
                command.Parameters.Add(new SqlParameter("@candID", candID));

                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }

    public int UpdateOfferLetterAcceptance(AddDB add)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        string ReqID = string.Empty;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateOfferLetterAcceptance", cnn))
            {

                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
               
                command.Parameters.Add(new SqlParameter("@OfferAcceptStatus", add.OfferAcceptStatus));
                command.Parameters.Add(new SqlParameter("@ExpectedDOJ", add.ExpectedDOJ));
                command.Parameters.Add(new SqlParameter("@OfferLetterPDFAcceptedDate", Utility.IndianTime));
                command.Parameters.Add(new SqlParameter("@candID", add.candID));

                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }

    public int UpdateOfferLetterNonAcceptance(string candID, string stAcceptstatus)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        string ReqID = string.Empty;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateOfferLetterNonAcceptance", cnn))
            {

                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
               
                command.Parameters.Add(new SqlParameter("@OfferAcceptStatus", stAcceptstatus));
                command.Parameters.Add(new SqlParameter("@OfferLetterPDFAcceptedDate", Utility.IndianTime));
                command.Parameters.Add(new SqlParameter("@candID", candID));

                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }

    public int UpdateJobOfferAcceptance(AddDB add)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        string ReqID = string.Empty;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateJobOfferAcceptance", cnn))
            {

                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
               
                command.Parameters.Add(new SqlParameter("@CandidateJobOfferStatus", add.CandidateJobOfferStatus));
                command.Parameters.Add(new SqlParameter("@CandidateJobOfferUpdatedDate", Utility.IndianTime));
                command.Parameters.Add(new SqlParameter("@candID", add.candID));

                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }

    public int UpdateJobOfferNonAcceptance(string candID, string CandidateJobOfferStatus)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        string ReqID = string.Empty;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateJobOfferNonAcceptance", cnn))
            {

                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
               
                command.Parameters.Add(new SqlParameter("@CandidateJobOfferStatus", CandidateJobOfferStatus));
                command.Parameters.Add(new SqlParameter("@CandidateJobOfferUpdatedDate", Utility.IndianTime));
                command.Parameters.Add(new SqlParameter("@candID", candID));

                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }

}