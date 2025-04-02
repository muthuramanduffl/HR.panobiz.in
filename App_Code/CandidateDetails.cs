using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

/// <summary>
/// Summary description for CandidateDetails
/// </summary>
public class CandidateDetails
{
    public int ID { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string EmailId { get; set; }
    public string Mobile { get; set; }
    public string Gender { get; set; }
    public string JobZone { get; set; }
    public string Age { get; set; }
    public string TotExperience { get; set; }
    public string CoreExperience { get; set; }
    public string Cibil { get; set; }
    public string FillingPosition { get; set; }

    public string State { get; set; }
    public string Location { get; set; }
    public string assignedCompName { get; set; }
    public string jobfunction { get; set; }
    public string product { get; set; }
    public string designation { get; set; }
    public string Qualification { get; set; }
    public string Fresherstatus { get; set; }
    public string ReportingTo { get; set; }
    public string CurrentCTC { get; set; }
    public string ExpectedCTCAnnum { get; set; }
    public string ExpectedCTCMonth { get; set; }
    public string Comment1 { get; set; }
    public string ImmediateJoinee { get; set; }
    public string RequestedBy { get; set; }
    public DateTime RequestedDate { get; set; }
    public string Recommended { get; set; }
    public string RecommendedBy { get; set; }
    public DateTime RecommendedDate { get; set; }
    public string RecommendedComment { get; set; }
    public string Approved { get; set; }
    public string ApprovedBy { get; set; }
    public DateTime ApprovedDate { get; set; }
    public string SSLCmark { get; set; }
    public string HSCmark { get; set; }
    public string graduationmark { get; set; }
    public string Resume { get; set; }
    public string PreApptmentletter { get; set; }
    public string ExpRelievingLetter { get; set; }
    public string ResignAcceptLetter { get; set; }
    public string PreviousPayslip { get; set; }
    public string Aadharcard { get; set; }
    public string Pancard { get; set; }

    public string empcode1 { get; set; }
    public string empcode2 { get; set; }
    public string empcode3 { get; set; }
    public string empcode4 { get; set; }
    public string approvallevel { get; set; }

    public string Approver1 { get; set; }
    public string Approver2 { get; set; }
    public string Recommender1 { get; set; }
    public string Recommender2 { get; set; }


    public string ProposedCTCAnnum { get; set; }
    public string ProposedCTCMonth { get; set; }
    public string Internalgrade { get; set; }

    public string ApptAccepted { get; set; }
    public string ApptAcceptedstatus { get; set; }
    public string ApptAcceptedBy { get; set; }

    public string ResdAddress { get; set; }
    public string ResdAddressstatus { get; set; }
    public string ResdAddressBy { get; set; }

    public string Photo { get; set; }
    public string Photostatus { get; set; }
    public string PhotoBy { get; set; }

    public string FamilyPhoto { get; set; }
    public string FamilyPhotostatus { get; set; }
    public string FamilyPhotoBy { get; set; }

    public string BgVerification { get; set; }
    public string BgVerificationstatus { get; set; }
    public string BgVerificationBy { get; set; }

    public string EmpBranchCode { get; set; }
    public string EmpBranchCodestatus { get; set; }
    public string EmpBranchCodeBy { get; set; }

    public string GratReg { get; set; }
    public string GratRegstatus { get; set; }
    public string GratRegBy { get; set; }

    public string ESIC { get; set; }
    public string ESICstatus { get; set; }
    public string ESICBy { get; set; }

    public string PF { get; set; }
    public string PFstatus { get; set; }
    public string PFBy { get; set; }

   

    public string AddedBy { get; set; }
    public DateTime AddedDate { get; set; }
    public string UpdatedBy { get; set; }
    public DateTime UpdatedDate { get; set; }
    public bool NotifyRequester { get; set; }
    public bool NotifyRecommender { get; set; }
    public bool NotifyApprover { get; set; }
    public bool RecApprovFlag { get; set; }

    public string RecApprov { get; set; }
    public string RecApprovBy { get; set; }
    public DateTime RecApprovDate { get; set; }
    public string EmpRole { get; set; }

    public string SSLCmarkstatus { get; set; }
    public string SSLCmarkBy { get; set; }

    public string HSCmarkstatus { get; set; }
    public string HSCmarkBy { get; set; }

    public string OfferLetterPDF { get; set; }
    public string OfferLetterPDFupdatedby{ get; set; }
    public string OfferLetterPDFupdatedStatus{ get; set; }
    public DateTime OfferLetterPDFupdateddate { get; set; }
    public DateTime CandidateEstimatedDateofJoining { get; set; }
    public DateTime OfferLetterPDFAcceptedDate { get; set; }
    public string OfferLetterPDFAcceptedBy{ get; set; }

    public string graduationstatus { get; set; }
    public string graduationBy { get; set; }

    public string Resumestatus { get; set; }
    public string ResumeBy { get; set; }

    public string PreAppointstatus { get; set; }
    public string PreAppointBy { get; set; }

    public string Expstatus { get; set; }
    public string ExpBy { get; set; }

    public string Resignstatus { get; set; }
    public string ResignBy { get; set; }

    public string Payslipstatus { get; set; }
    public string PayslipBy { get; set; }

    public string Aadharcardstatus { get; set; }
    public string AadharcardBy { get; set; }

    public string Pancardstatus { get; set; }
    public string PancardBy  { get; set; }

    public bool Fulluploaded  { get; set; }

    public string OfferedCTCAnnum { get; set; }
    public string OfferedCTCMonth { get; set; }
    public string SubmitApptment { get; set; }
    public DateTime Submissiondate { get; set; }
    public string ReviseOffer { get; set; }
    public string RevisedCTCAnnum { get; set; }
    public string RevisedCTCMonth { get; set; }
    public string RevisedRequestBy { get; set; }
    public DateTime RevisedRequestDate { get; set; }

    public string appointmentReqBy { get; set; }
    public DateTime appointmentReqDate { get; set; }

    public string apptapproverdecision { get; set; }
    public string apptapprovercomments { get; set; }
    public string apptapprovedBy  { get; set; }
    public DateTime approverdecisionDate { get; set; }
    public string OfferSentStatus { get; set; }
    public DateTime OfferSentDate { get; set; }
    public DateTime ExpectedDOJ { get; set; }
    public string Reason_For_No { get; set; }
    public string What_Pending { get; set; }
    public string OfferAcceptStatus { get; set; }
    public string CandidateJoined { get; set; }
    public DateTime DOJ { get; set; }
    public string EmpCode { get; set; }
    public string appointmentStatusBy { get; set; }
    public DateTime appointmentStatusDate { get; set; }


    public DateTime DOB { get; set; }
    public string Bloodgrp { get; set; }
    public string Fathername { get; set; }
    public string Mothername { get; set; }
    public string EmContactPerson { get; set; }
    public string EmContactMobile { get; set; }
    public string EmContactLocation { get; set; }
    public string EmContactRelation { get; set; }

    public string  Address1 { get; set; }
    public string  City1 { get; set; }
    public string  District1 { get; set; }
    public string  State1 { get; set; }
    public string  Pincode1 { get; set; }

    public string  Address2 { get; set; }
    public string  City2 { get; set; }
    public string  District2 { get; set; }
    public string  State2 { get; set; }
    public string  Pincode2 { get; set; }
    public string  ResidenceYrFrom { get; set; }
    public string  ResidenceYrTo { get; set; }
    public string CurrentAddressType { get; set; }
    public string StayingWith { get; set; }
    public string StayingWithName { get; set; }
    public string StayingWithMobile { get; set; }

    public string lastcompname { get; set; }
    public string lastcompaddress { get; set; }
    public string lastcompCity { get; set; }
    public string lastcompEmpID { get; set; }
    public string lastcompDesignation { get; set; }
    public string lastcompDept { get; set; }
    public string lastcompMngrname { get; set; }
    public string lastcompMngrMobile { get; set; }
    public string lastcompEmploytype { get; set; }
    public DateTime lastdurationFrom { get; set; }
    public DateTime lastdurationTo { get; set; }

    public string Ref1name { get; set; }
    public string Ref1mobile { get; set; }
    public string Ref1company { get; set; }
    public string Ref1Design { get; set; }
    public string Ref1Relation { get; set; }

    public string Ref2name { get; set; }
    public string Ref2mobile { get; set; }
    public string Ref2company { get; set; }
    public string Ref2Design { get; set; }
    public string Ref2Relation { get; set; }

    public string VerificationSameAddress { get; set; }
    public DateTime VerificationDate { get; set; }
    public string PersonMet { get; set; }
    public string RelationshipPerson { get; set; }
    public string RelationshipName { get; set; }
    public string RelationshipMobileNo { get; set; }
    public string VerificationByRM { get; set; }
    public string Reason { get; set; }
    public string VerifierName { get; set; }
    public string VerifierEmpCode { get; set; }
    public string VerifierMobileNo { get; set; }
    public string VerificationStatus { get; set; }
    public string CanID { get; set; }
    public string Role { get; set; }

    public string Ref1Checkstatus { get; set; }
    public string Ref2Checkstatus { get; set; }

    public string WorkLocLatCoordinates { get; set; }
    public string WorkLocLongCoordinates { get; set; }
    public string Radius { get; set; }


    public CandidateDetails()
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

    public string AddCandidateDetails(CandidateDetails cand)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        int ID = 0;
		string OffID = string.Empty;
        try
        {
            using (SqlCommand command = new SqlCommand("AddCandidateDetails", cnn))
            {

                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@FirstName", cand.FirstName));
                command.Parameters.Add(new SqlParameter("@MiddleName", cand.MiddleName));
                command.Parameters.Add(new SqlParameter("@LastName", cand.LastName));
                command.Parameters.Add(new SqlParameter("@EmailId", cand.EmailId));
                command.Parameters.Add(new SqlParameter("@Mobile", cand.Mobile));
                command.Parameters.Add(new SqlParameter("@Gender", cand.Gender));
                command.Parameters.Add(new SqlParameter("@JobZone", cand.JobZone));
                command.Parameters.Add(new SqlParameter("@FillingPosition", cand.FillingPosition));
                command.Parameters.Add(new SqlParameter("@DOJ", cand.DOJ));
                command.Parameters.Add(new SqlParameter("@DOB", cand.DOB));
                command.Parameters.Add(new SqlParameter("@Cibil", cand.Cibil));
                command.Parameters.Add(new SqlParameter("@CoreExperience", cand.CoreExperience));
                command.Parameters.Add(new SqlParameter("@TotExperience", cand.TotExperience));
                command.Parameters.Add(new SqlParameter("@Age", cand.Age));

                command.Parameters.Add(new SqlParameter("@assignedCompName", cand.assignedCompName));
                command.Parameters.Add(new SqlParameter("@jobfunction", cand.jobfunction));
                command.Parameters.Add(new SqlParameter("@product", cand.product));
                command.Parameters.Add(new SqlParameter("@designation", cand.designation));
                command.Parameters.Add(new SqlParameter("@State", cand.State));
                command.Parameters.Add(new SqlParameter("@Location", cand.Location));

                command.Parameters.Add(new SqlParameter("@Qualification", cand.Qualification));
                command.Parameters.Add(new SqlParameter("@Fresherstatus", cand.Fresherstatus));
                command.Parameters.Add(new SqlParameter("@ReportingTo", cand.ReportingTo));
                command.Parameters.Add(new SqlParameter("@CurrentCTC", cand.CurrentCTC));
                command.Parameters.Add(new SqlParameter("@ExpectedCTCAnnum", cand.ExpectedCTCAnnum));
                command.Parameters.Add(new SqlParameter("@ExpectedCTCMonth", cand.ExpectedCTCMonth));
                command.Parameters.Add(new SqlParameter("@Comment1", cand.Comment1));
                command.Parameters.Add(new SqlParameter("@ImmediateJoinee", cand.ImmediateJoinee));
                command.Parameters.Add(new SqlParameter("@RequestedBy", cand.RequestedBy));
                command.Parameters.Add(new SqlParameter("@RequestedDate", cand.RequestedDate));

                command.Parameters.Add(new SqlParameter("@SSLCmark", cand.SSLCmark));
                command.Parameters.Add(new SqlParameter("@HSCmark", cand.HSCmark));
                command.Parameters.Add(new SqlParameter("@graduationmark", cand.graduationmark));
                command.Parameters.Add(new SqlParameter("@Resume", cand.Resume));
                command.Parameters.Add(new SqlParameter("@PreApptmentletter", cand.PreApptmentletter));
                command.Parameters.Add(new SqlParameter("@ExpRelievingLetter", cand.ExpRelievingLetter));
                command.Parameters.Add(new SqlParameter("@ResignAcceptLetter", cand.ResignAcceptLetter));
                command.Parameters.Add(new SqlParameter("@Previouspayslip", cand.PreviousPayslip));
                command.Parameters.Add(new SqlParameter("@Aadharcard", cand.Aadharcard));
                command.Parameters.Add(new SqlParameter("@Pancard", cand.Pancard));

                command.Parameters.Add(new SqlParameter("@SSLCmarkstatus", cand.SSLCmarkstatus));
                command.Parameters.Add(new SqlParameter("@SSLCmarkBy", cand.SSLCmarkBy));

                command.Parameters.Add(new SqlParameter("@HSCmarkstatus", cand.HSCmarkstatus));
                command.Parameters.Add(new SqlParameter("@HSCmarkBy", cand.HSCmarkBy));

                command.Parameters.Add(new SqlParameter("@graduationstatus", cand.graduationstatus));
                command.Parameters.Add(new SqlParameter("@graduationBy", cand.graduationBy));

                command.Parameters.Add(new SqlParameter("@Resumestatus", cand.Resumestatus));
                command.Parameters.Add(new SqlParameter("@ResumeBy", cand.ResumeBy));

                command.Parameters.Add(new SqlParameter("@PreAppointstatus", cand.PreAppointstatus));
                command.Parameters.Add(new SqlParameter("@PreAppointBy", cand.PreAppointBy));

                command.Parameters.Add(new SqlParameter("@Expstatus", cand.Expstatus));
                command.Parameters.Add(new SqlParameter("@ExpBy", cand.ExpBy));

                command.Parameters.Add(new SqlParameter("@Resignstatus", cand.Resignstatus));
                command.Parameters.Add(new SqlParameter("@ResignBy", cand.ResignBy));

                command.Parameters.Add(new SqlParameter("@Payslipstatus", cand.Payslipstatus));
                command.Parameters.Add(new SqlParameter("@PayslipBy", cand.PayslipBy));

                command.Parameters.Add(new SqlParameter("@Aadharcardstatus", cand.Aadharcardstatus));
                command.Parameters.Add(new SqlParameter("@AadharcardBy", cand.AadharcardBy));
                command.Parameters.Add(new SqlParameter("@Pancardstatus", cand.Pancardstatus));
                command.Parameters.Add(new SqlParameter("@PancardBy", cand.PancardBy));
                command.Parameters.Add(new SqlParameter("@Fulluploaded", cand.Fulluploaded));

                command.Parameters.Add(new SqlParameter("@AddedBy", cand.AddedBy));
                command.Parameters.Add(new SqlParameter("@AddedDate", cand.AddedDate));
                command.Parameters.Add(new SqlParameter("@NotifyRecommender", cand.NotifyRecommender));
                command.Parameters.Add(new SqlParameter("@NotifyApprover", cand.NotifyApprover));

                command.Parameters.Add("@ID", SqlDbType.Int);
                command.Parameters["@ID"].Direction = ParameterDirection.Output;
                rowsAffected = command.ExecuteNonQuery();

                ID = Convert.ToInt32(command.Parameters["@ID"].Value);

                if (ID != 0)
                { 
                    OffID = "CAN" + string.Format("{0:D2}", ID);
                    UpdateCandidateID(OffID, ID);
                }
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
		return OffID;
    }

    public string AddCandidateDetails2024(CandidateDetails cand)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        int ID = 0;
		string OffID = string.Empty;
        try
        {
            using (SqlCommand command = new SqlCommand("AddCandidateDetails2024", cnn))
            {

                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@FirstName", cand.FirstName));
                command.Parameters.Add(new SqlParameter("@MiddleName", cand.MiddleName));
                command.Parameters.Add(new SqlParameter("@LastName", cand.LastName));
                command.Parameters.Add(new SqlParameter("@EmailId", cand.EmailId));
                command.Parameters.Add(new SqlParameter("@Mobile", cand.Mobile));
                command.Parameters.Add(new SqlParameter("@Gender", cand.Gender));
                command.Parameters.Add(new SqlParameter("@JobZone", cand.JobZone));
                command.Parameters.Add(new SqlParameter("@FillingPosition", cand.FillingPosition));
                command.Parameters.Add(new SqlParameter("@DOJ", cand.DOJ));
                command.Parameters.Add(new SqlParameter("@DOB", cand.DOB));
                command.Parameters.Add(new SqlParameter("@Cibil", cand.Cibil));
                command.Parameters.Add(new SqlParameter("@CoreExperience", cand.CoreExperience));
                command.Parameters.Add(new SqlParameter("@TotExperience", cand.TotExperience));
                command.Parameters.Add(new SqlParameter("@Age", cand.Age));

                command.Parameters.Add(new SqlParameter("@assignedCompName", cand.assignedCompName));
                command.Parameters.Add(new SqlParameter("@jobfunction", cand.jobfunction));
                command.Parameters.Add(new SqlParameter("@product", cand.product));
                command.Parameters.Add(new SqlParameter("@designation", cand.designation));
                command.Parameters.Add(new SqlParameter("@State", cand.State));
                command.Parameters.Add(new SqlParameter("@Location", cand.Location));

                command.Parameters.Add(new SqlParameter("@Qualification", cand.Qualification));
                command.Parameters.Add(new SqlParameter("@Fresherstatus", cand.Fresherstatus));
                command.Parameters.Add(new SqlParameter("@ReportingTo", cand.ReportingTo));
                command.Parameters.Add(new SqlParameter("@CurrentCTC", cand.CurrentCTC));
                command.Parameters.Add(new SqlParameter("@ExpectedCTCAnnum", cand.ExpectedCTCAnnum));
                command.Parameters.Add(new SqlParameter("@ExpectedCTCMonth", cand.ExpectedCTCMonth));
                command.Parameters.Add(new SqlParameter("@Comment1", cand.Comment1));
                command.Parameters.Add(new SqlParameter("@ImmediateJoinee", cand.ImmediateJoinee));
                command.Parameters.Add(new SqlParameter("@RequestedBy", cand.RequestedBy));
                command.Parameters.Add(new SqlParameter("@RequestedDate", cand.RequestedDate));

                command.Parameters.Add(new SqlParameter("@SSLCmark", cand.SSLCmark));
                command.Parameters.Add(new SqlParameter("@HSCmark", cand.HSCmark));
                command.Parameters.Add(new SqlParameter("@graduationmark", cand.graduationmark));
                command.Parameters.Add(new SqlParameter("@Resume", cand.Resume));
                command.Parameters.Add(new SqlParameter("@PreApptmentletter", cand.PreApptmentletter));
                command.Parameters.Add(new SqlParameter("@ExpRelievingLetter", cand.ExpRelievingLetter));
                command.Parameters.Add(new SqlParameter("@ResignAcceptLetter", cand.ResignAcceptLetter));
                command.Parameters.Add(new SqlParameter("@Previouspayslip", cand.PreviousPayslip));
                command.Parameters.Add(new SqlParameter("@Aadharcard", cand.Aadharcard));
                command.Parameters.Add(new SqlParameter("@Pancard", cand.Pancard));

                command.Parameters.Add(new SqlParameter("@SSLCmarkstatus", cand.SSLCmarkstatus));
                command.Parameters.Add(new SqlParameter("@SSLCmarkBy", cand.SSLCmarkBy));

                command.Parameters.Add(new SqlParameter("@HSCmarkstatus", cand.HSCmarkstatus));
                command.Parameters.Add(new SqlParameter("@HSCmarkBy", cand.HSCmarkBy));

                command.Parameters.Add(new SqlParameter("@graduationstatus", cand.graduationstatus));
                command.Parameters.Add(new SqlParameter("@graduationBy", cand.graduationBy));

                command.Parameters.Add(new SqlParameter("@Resumestatus", cand.Resumestatus));
                command.Parameters.Add(new SqlParameter("@ResumeBy", cand.ResumeBy));

                command.Parameters.Add(new SqlParameter("@PreAppointstatus", cand.PreAppointstatus));
                command.Parameters.Add(new SqlParameter("@PreAppointBy", cand.PreAppointBy));

                command.Parameters.Add(new SqlParameter("@Expstatus", cand.Expstatus));
                command.Parameters.Add(new SqlParameter("@ExpBy", cand.ExpBy));

                command.Parameters.Add(new SqlParameter("@Resignstatus", cand.Resignstatus));
                command.Parameters.Add(new SqlParameter("@ResignBy", cand.ResignBy));

                command.Parameters.Add(new SqlParameter("@Payslipstatus", cand.Payslipstatus));
                command.Parameters.Add(new SqlParameter("@PayslipBy", cand.PayslipBy));

                command.Parameters.Add(new SqlParameter("@Aadharcardstatus", cand.Aadharcardstatus));
                command.Parameters.Add(new SqlParameter("@AadharcardBy", cand.AadharcardBy));
                command.Parameters.Add(new SqlParameter("@Pancardstatus", cand.Pancardstatus));
                command.Parameters.Add(new SqlParameter("@PancardBy", cand.PancardBy));
                command.Parameters.Add(new SqlParameter("@Fulluploaded", cand.Fulluploaded));

                command.Parameters.Add(new SqlParameter("@AddedBy", cand.AddedBy));
                command.Parameters.Add(new SqlParameter("@AddedDate", cand.AddedDate));
                command.Parameters.Add(new SqlParameter("@NotifyRecommender", cand.NotifyRecommender));
                command.Parameters.Add(new SqlParameter("@NotifyApprover", cand.NotifyApprover));

                command.Parameters.Add(new SqlParameter("@empcode1", cand.empcode1));
                command.Parameters.Add(new SqlParameter("@empcode2", cand.empcode2));
                command.Parameters.Add(new SqlParameter("@empcode3", cand.empcode3));
                command.Parameters.Add(new SqlParameter("@empcode4", cand.empcode4));

                command.Parameters.Add(new SqlParameter("@Recommender1", cand.Recommender1));
                command.Parameters.Add(new SqlParameter("@Recommender2", cand.Recommender2));
                command.Parameters.Add(new SqlParameter("@Approver1", cand.Approver1));
                command.Parameters.Add(new SqlParameter("@Approver2", cand.Approver2));

                command.Parameters.Add(new SqlParameter("@approvallevel", cand.approvallevel));


                command.Parameters.Add("@ID", SqlDbType.Int);
                command.Parameters["@ID"].Direction = ParameterDirection.Output;
                rowsAffected = command.ExecuteNonQuery();

                ID = Convert.ToInt32(command.Parameters["@ID"].Value);

                if (ID != 0)
                { 
                    OffID = "CAN" + string.Format("{0:D2}", ID);
                    UpdateCandidateID(OffID, ID);
                }
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
		return OffID;
    }


    public int UpdateCandidateID(string OffID, int ID)
    {
        int rowsAffected = 0;
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        try
        {
            using (SqlCommand cmd = new SqlCommand("UpdateCandidateID", cnn))
            {
                cnn.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@OffID", OffID));
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

    public DataSet ViewCandidateJobNotification(string EmpID, string EmpRole)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataSet ds = new DataSet();
        using (SqlCommand command = new SqlCommand("ViewCandidateJobNotification", cnn))
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

    public DataSet ViewCandidateDetailsByID(int ID)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewCandidateDetailsByID", cnn))
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
    public DataSet ViewCandidateDetailsByIDNew(string ID)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewCandidateDetailsByIDNew", cnn))
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
    public DataSet ViewCandidateDetailsByEmpID(string ID)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataSet ds = new DataSet();
        using (SqlCommand command = new SqlCommand("ViewCandidateDetailsByEmpID", cnn))
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

    public int UpdateCandidateJobRequest(CandidateDetails cand)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        string ReqID = string.Empty;
        SqlDateTime sqldatenull;
        sqldatenull = SqlDateTime.Null;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateCandidateJobRequest", cnn))
            {

                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@Recommended", cand.Recommended));
                command.Parameters.Add(new SqlParameter("@RecommendedBy", cand.RecommendedBy));
                //command.Parameters.Add(new SqlParameter("@RecommendedDate", cand.RecommendedDate));
                if (cand.RecommendedDate == DateTime.MaxValue)
                {
                    command.Parameters.Add(
                    new SqlParameter("@RecommendedDate", sqldatenull));
                }
                else
                {
                    command.Parameters.Add(
                    new SqlParameter("@RecommendedDate", cand.RecommendedDate));
                }
                command.Parameters.Add(new SqlParameter("@Approved", cand.Approved));
                command.Parameters.Add(new SqlParameter("@ApprovedBy", cand.ApprovedBy));
               // command.Parameters.Add(new SqlParameter("@ApprovedDate", cand.ApprovedDate));
                if (cand.ApprovedDate == DateTime.MaxValue)
                {
                    command.Parameters.Add(
                    new SqlParameter("@ApprovedDate", sqldatenull));
                }
                else
                {
                    command.Parameters.Add(
                    new SqlParameter("@ApprovedDate", cand.ApprovedDate));
                }
                command.Parameters.Add(new SqlParameter("@RecommendedComment", cand.RecommendedComment));
                //command.Parameters.Add(new SqlParameter("@RecApprovFlag", cand.RecApprovFlag));
                command.Parameters.Add(new SqlParameter("@NotifyRequester", cand.NotifyRequester));
                command.Parameters.Add(new SqlParameter("@NotifyApprover", cand.NotifyApprover));
                command.Parameters.Add(new SqlParameter("@NotifyRecommender", cand.NotifyRecommender));
                command.Parameters.Add(new SqlParameter("@EmpRole", cand.EmpRole));
                command.Parameters.Add(new SqlParameter("@ID", cand.ID));

                command.Parameters.Add(new SqlParameter("@SSLCmark", cand.SSLCmark));
                command.Parameters.Add(new SqlParameter("@HSCmark", cand.HSCmark));
                command.Parameters.Add(new SqlParameter("@graduationmark", cand.graduationmark));
                command.Parameters.Add(new SqlParameter("@Resume", cand.Resume));
                command.Parameters.Add(new SqlParameter("@PreApptmentletter", cand.PreApptmentletter));
                command.Parameters.Add(new SqlParameter("@ExpRelievingLetter", cand.ExpRelievingLetter));
                command.Parameters.Add(new SqlParameter("@ResignAcceptLetter", cand.ResignAcceptLetter));
                command.Parameters.Add(new SqlParameter("@Previouspayslip", cand.PreviousPayslip));
                command.Parameters.Add(new SqlParameter("@Aadharcard", cand.Aadharcard));
                command.Parameters.Add(new SqlParameter("@Pancard", cand.Pancard));

                command.Parameters.Add(new SqlParameter("@ProposedCTCAnnum", cand.ProposedCTCAnnum));
                command.Parameters.Add(new SqlParameter("@ProposedCTCMonth", cand.ProposedCTCMonth));
                command.Parameters.Add(new SqlParameter("@Internalgrade", cand.Internalgrade));

                command.Parameters.Add(new SqlParameter("@SSLCmarkstatus", cand.SSLCmarkstatus));
                command.Parameters.Add(new SqlParameter("@SSLCmarkBy", cand.SSLCmarkBy));

                command.Parameters.Add(new SqlParameter("@HSCmarkstatus", cand.HSCmarkstatus));
                command.Parameters.Add(new SqlParameter("@HSCmarkBy", cand.HSCmarkBy));

                command.Parameters.Add(new SqlParameter("@graduationstatus", cand.graduationstatus));
                command.Parameters.Add(new SqlParameter("@graduationBy", cand.graduationBy));

                command.Parameters.Add(new SqlParameter("@Resumestatus", cand.Resumestatus));
                command.Parameters.Add(new SqlParameter("@ResumeBy", cand.ResumeBy));

                command.Parameters.Add(new SqlParameter("@PreAppointstatus", cand.PreAppointstatus));
                command.Parameters.Add(new SqlParameter("@PreAppointBy", cand.PreAppointBy));

                command.Parameters.Add(new SqlParameter("@Expstatus", cand.Expstatus));
                command.Parameters.Add(new SqlParameter("@ExpBy", cand.ExpBy));

                command.Parameters.Add(new SqlParameter("@Resignstatus", cand.Resignstatus));
                command.Parameters.Add(new SqlParameter("@ResignBy", cand.ResignBy));

                command.Parameters.Add(new SqlParameter("@Payslipstatus", cand.Payslipstatus));
                command.Parameters.Add(new SqlParameter("@PayslipBy", cand.PayslipBy));

                command.Parameters.Add(new SqlParameter("@Aadharcardstatus", cand.Aadharcardstatus));
                command.Parameters.Add(new SqlParameter("@AadharcardBy", cand.AadharcardBy));
                command.Parameters.Add(new SqlParameter("@Pancardstatus", cand.Pancardstatus));
                command.Parameters.Add(new SqlParameter("@PancardBy", cand.PancardBy));
                command.Parameters.Add(new SqlParameter("@Fulluploaded", cand.Fulluploaded));
                command.Parameters.Add(new SqlParameter("@updatedby", cand.UpdatedBy));
                command.Parameters.Add(new SqlParameter("@updateddate", cand.UpdatedDate));
                
                command.Parameters.Add(new SqlParameter("@Recommender2", cand.Recommender2));
                command.Parameters.Add(new SqlParameter("@Approver1", cand.Approver1));
                command.Parameters.Add(new SqlParameter("@Approver2", cand.Approver2));

                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }

    //public int AddCandidateDocHistory(string stCandID, string stcolname, string ststatus, string strupdatedby)
    //{
    //    string connetionString = null;
    //    SqlConnection cnn;
    //    connetionString = GetSqlConnection();
    //    cnn = new SqlConnection(connetionString);
    //    int rowsAffected = 0;
    //    try
    //    {
    //        using (SqlCommand command = new SqlCommand("AddCandidateDocHistory", cnn))
    //        {
    //            cnn.Open();
    //            command.CommandType = CommandType.StoredProcedure;
    //            command.Parameters.Add(new SqlParameter("@CandID", stCandID));
    //            command.Parameters.Add(new SqlParameter("@colname", stcolname));
    //            command.Parameters.Add(new SqlParameter("@status", ststatus));
    //            command.Parameters.Add(new SqlParameter("@updatedby", strupdatedby));
    //            command.Parameters.Add(new SqlParameter("@updateddate", Utility.IndianTime));

    //            rowsAffected = command.ExecuteNonQuery();
    //        }
    //        cnn.Close();
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //    return rowsAffected;
    //}

    public int UpdateCandidateDetails(CandidateDetails cand)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateCandidateDetails", cnn))
            {

                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@FirstName", cand.FirstName));
                command.Parameters.Add(new SqlParameter("@MiddleName", cand.MiddleName));
                command.Parameters.Add(new SqlParameter("@LastName", cand.LastName));
                command.Parameters.Add(new SqlParameter("@EmailId", cand.EmailId));
                command.Parameters.Add(new SqlParameter("@Mobile", cand.Mobile));
                command.Parameters.Add(new SqlParameter("@Gender", cand.Gender));
                command.Parameters.Add(new SqlParameter("@JobZone", cand.JobZone));
                command.Parameters.Add(new SqlParameter("@Cibil", cand.Cibil));
                command.Parameters.Add(new SqlParameter("@FillingPosition", cand.FillingPosition));
                command.Parameters.Add(new SqlParameter("@DOJ", cand.DOJ));
                command.Parameters.Add(new SqlParameter("@DOB", cand.DOB));
                command.Parameters.Add(new SqlParameter("@CoreExperience", cand.CoreExperience));
                command.Parameters.Add(new SqlParameter("@TotExperience", cand.TotExperience));


                command.Parameters.Add(new SqlParameter("@assignedCompName", cand.assignedCompName));
                command.Parameters.Add(new SqlParameter("@jobfunction", cand.jobfunction));
                command.Parameters.Add(new SqlParameter("@product", cand.product));
                command.Parameters.Add(new SqlParameter("@designation", cand.designation));
                command.Parameters.Add(new SqlParameter("@State", cand.State));
                command.Parameters.Add(new SqlParameter("@Location", cand.Location));

                command.Parameters.Add(new SqlParameter("@Qualification", cand.Qualification));
                command.Parameters.Add(new SqlParameter("@Fresherstatus", cand.Fresherstatus));
                command.Parameters.Add(new SqlParameter("@ReportingTo", cand.ReportingTo));
                command.Parameters.Add(new SqlParameter("@CurrentCTC", cand.CurrentCTC));
                command.Parameters.Add(new SqlParameter("@ExpectedCTCAnnum", cand.ExpectedCTCAnnum));
                command.Parameters.Add(new SqlParameter("@ExpectedCTCMonth", cand.ExpectedCTCMonth));
                command.Parameters.Add(new SqlParameter("@Comment1", cand.Comment1));
                command.Parameters.Add(new SqlParameter("@ImmediateJoinee", cand.ImmediateJoinee));
                command.Parameters.Add(new SqlParameter("@RequestedBy", cand.RequestedBy));
                command.Parameters.Add(new SqlParameter("@RequestedDate", cand.RequestedDate));

                command.Parameters.Add(new SqlParameter("@SSLCmark", cand.SSLCmark));
                command.Parameters.Add(new SqlParameter("@HSCmark", cand.HSCmark));
                command.Parameters.Add(new SqlParameter("@graduationmark", cand.graduationmark));
                command.Parameters.Add(new SqlParameter("@Resume", cand.Resume));
                command.Parameters.Add(new SqlParameter("@PreApptmentletter", cand.PreApptmentletter));
                command.Parameters.Add(new SqlParameter("@ExpRelievingLetter", cand.ExpRelievingLetter));
                command.Parameters.Add(new SqlParameter("@ResignAcceptLetter", cand.ResignAcceptLetter));
                command.Parameters.Add(new SqlParameter("@Previouspayslip", cand.PreviousPayslip));
                command.Parameters.Add(new SqlParameter("@Aadharcard", cand.Aadharcard));
                command.Parameters.Add(new SqlParameter("@Pancard", cand.Pancard));

                command.Parameters.Add(new SqlParameter("@SSLCmarkstatus", cand.SSLCmarkstatus));
                command.Parameters.Add(new SqlParameter("@SSLCmarkBy", cand.SSLCmarkBy));

                command.Parameters.Add(new SqlParameter("@HSCmarkstatus", cand.HSCmarkstatus));
                command.Parameters.Add(new SqlParameter("@HSCmarkBy", cand.HSCmarkBy));

                command.Parameters.Add(new SqlParameter("@OfferLetterPDF", cand.OfferLetterPDF));
                command.Parameters.Add(new SqlParameter("@OfferLetterPDFupdatedby", cand.OfferLetterPDFupdatedby));
                command.Parameters.Add(new SqlParameter("@OfferLetterPDFupdateddate", cand.OfferLetterPDFupdateddate));
                command.Parameters.Add(new SqlParameter("@OfferLetterPDFupdatedStatus", cand.OfferLetterPDFupdatedStatus));

                command.Parameters.Add(new SqlParameter("@graduationstatus", cand.graduationstatus));
                command.Parameters.Add(new SqlParameter("@graduationBy", cand.graduationBy));

                command.Parameters.Add(new SqlParameter("@Resumestatus", cand.Resumestatus));
                command.Parameters.Add(new SqlParameter("@ResumeBy", cand.ResumeBy));

                command.Parameters.Add(new SqlParameter("@PreAppointstatus", cand.PreAppointstatus));
                command.Parameters.Add(new SqlParameter("@PreAppointBy", cand.PreAppointBy));

                command.Parameters.Add(new SqlParameter("@Expstatus", cand.Expstatus));
                command.Parameters.Add(new SqlParameter("@ExpBy", cand.ExpBy));

                command.Parameters.Add(new SqlParameter("@Resignstatus", cand.Resignstatus));
                command.Parameters.Add(new SqlParameter("@ResignBy", cand.ResignBy));

                command.Parameters.Add(new SqlParameter("@Payslipstatus", cand.Payslipstatus));
                command.Parameters.Add(new SqlParameter("@PayslipBy", cand.PayslipBy));

                command.Parameters.Add(new SqlParameter("@Aadharcardstatus", cand.Aadharcardstatus));
                command.Parameters.Add(new SqlParameter("@AadharcardBy", cand.AadharcardBy));
                command.Parameters.Add(new SqlParameter("@Pancardstatus", cand.Pancardstatus));
                command.Parameters.Add(new SqlParameter("@PancardBy", cand.PancardBy));
                command.Parameters.Add(new SqlParameter("@Fulluploaded", cand.Fulluploaded));

                command.Parameters.Add(new SqlParameter("@UpdatedBy", cand.UpdatedBy));
                command.Parameters.Add(new SqlParameter("@UpdatedDate", cand.UpdatedDate));
                command.Parameters.Add(new SqlParameter("@NotifyRequester", cand.NotifyRequester));
                command.Parameters.Add(new SqlParameter("@NotifyRecommender", cand.NotifyRecommender));
                command.Parameters.Add(new SqlParameter("@NotifyApprover", cand.NotifyApprover));
                command.Parameters.Add(new SqlParameter("@ID", cand.ID));

                rowsAffected = command.ExecuteNonQuery();

            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }

    public int UpdateCandidateDetailsByOBO(CandidateDetails cand)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateCandidateDetailsByOBO", cnn))
            {

                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@FirstName", cand.FirstName));
                command.Parameters.Add(new SqlParameter("@MiddleName", cand.MiddleName));
                command.Parameters.Add(new SqlParameter("@LastName", cand.LastName));
                command.Parameters.Add(new SqlParameter("@EmailId", cand.EmailId));
                command.Parameters.Add(new SqlParameter("@Mobile", cand.Mobile));
                command.Parameters.Add(new SqlParameter("@Gender", cand.Gender));

                command.Parameters.Add(new SqlParameter("@assignedCompName", cand.assignedCompName));
                command.Parameters.Add(new SqlParameter("@jobfunction", cand.jobfunction));
                command.Parameters.Add(new SqlParameter("@product", cand.product));
                command.Parameters.Add(new SqlParameter("@designation", cand.designation));
                command.Parameters.Add(new SqlParameter("@State", cand.State));
                command.Parameters.Add(new SqlParameter("@Location", cand.Location));

                command.Parameters.Add(new SqlParameter("@Qualification", cand.Qualification));
                command.Parameters.Add(new SqlParameter("@Fresherstatus", cand.Fresherstatus));
                command.Parameters.Add(new SqlParameter("@ReportingTo", cand.ReportingTo));
                command.Parameters.Add(new SqlParameter("@CurrentCTC", cand.CurrentCTC));
                command.Parameters.Add(new SqlParameter("@ExpectedCTCAnnum", cand.ExpectedCTCAnnum));
                command.Parameters.Add(new SqlParameter("@ExpectedCTCMonth", cand.ExpectedCTCMonth));
                command.Parameters.Add(new SqlParameter("@Comment1", cand.Comment1));
                command.Parameters.Add(new SqlParameter("@ImmediateJoinee", cand.ImmediateJoinee));

                command.Parameters.Add(new SqlParameter("@OfferedCTCAnnum", cand.OfferedCTCAnnum));
                command.Parameters.Add(new SqlParameter("@OfferedCTCMonth", cand.OfferedCTCMonth));
                command.Parameters.Add(new SqlParameter("@SubmitApptment", cand.SubmitApptment));
                command.Parameters.Add(new SqlParameter("@Submissiondate", cand.Submissiondate));
                command.Parameters.Add(new SqlParameter("@ReviseOffer", cand.ReviseOffer));
                command.Parameters.Add(new SqlParameter("@RevisedCTCAnnum", cand.RevisedCTCAnnum));
                command.Parameters.Add(new SqlParameter("@RevisedCTCMonth", cand.RevisedCTCMonth));
                command.Parameters.Add(new SqlParameter("@RevisedRequestBy", cand.RevisedRequestBy));
                command.Parameters.Add(new SqlParameter("@RevisedRequestDate", cand.RevisedRequestDate));
                command.Parameters.Add(new SqlParameter("@UpdatedBy", cand.UpdatedBy));
                command.Parameters.Add(new SqlParameter("@UpdatedDate", cand.UpdatedDate));
                command.Parameters.Add(new SqlParameter("@appointmentReqBy", cand.appointmentReqBy));
                command.Parameters.Add(new SqlParameter("@appointmentReqDate", cand.appointmentReqDate));
                command.Parameters.Add(new SqlParameter("@ID", cand.ID));

                rowsAffected = command.ExecuteNonQuery();

            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }
    public int UpdateCandidateDetailsByPayroll(CandidateDetails cand)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateCandidateDetailsByPayroll", cnn))
            {

                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;


                command.Parameters.Add(new SqlParameter("@OfferLetterPDF", cand.OfferLetterPDF));
                command.Parameters.Add(new SqlParameter("@OfferLetterPDFupdatedby", cand.OfferLetterPDFupdatedby));
                command.Parameters.Add(new SqlParameter("@OfferLetterPDFupdateddate", cand.OfferLetterPDFupdateddate));
                command.Parameters.Add(new SqlParameter("@OfferLetterPDFupdatedStatus", cand.OfferLetterPDFupdatedStatus));

                command.Parameters.Add(new SqlParameter("@ID", cand.ID));

                rowsAffected = command.ExecuteNonQuery();
 

                rowsAffected = command.ExecuteNonQuery();

            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }
    
    public DataSet ViewReworkCandidate()
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataSet ds = new DataSet();
        using (SqlCommand command = new SqlCommand("ViewReworkCandidate", cnn))
        {
            cnn.Open();
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(ds);
        }

        cnn.Close();
        return ds;
    }
    
	public DataSet ViewAllCandidates()
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataSet ds = new DataSet();
        using (SqlCommand command = new SqlCommand("ViewAllCandidates", cnn))
        {
            cnn.Open();
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(ds);
        }

        cnn.Close();
        return ds;
    }
	
    public int UpdateCandDetailsAppntApproval(CandidateDetails cand)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateCandDetailsAppntApproval", cnn))
            {

                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@FirstName", cand.FirstName));
                command.Parameters.Add(new SqlParameter("@MiddleName", cand.MiddleName));
                command.Parameters.Add(new SqlParameter("@LastName", cand.LastName));
                command.Parameters.Add(new SqlParameter("@EmailId", cand.EmailId));
                command.Parameters.Add(new SqlParameter("@Mobile", cand.Mobile));
                command.Parameters.Add(new SqlParameter("@Gender", cand.Gender));

                command.Parameters.Add(new SqlParameter("@assignedCompName", cand.assignedCompName));
                command.Parameters.Add(new SqlParameter("@jobfunction", cand.jobfunction));
                command.Parameters.Add(new SqlParameter("@product", cand.product));
                command.Parameters.Add(new SqlParameter("@designation", cand.designation));
                command.Parameters.Add(new SqlParameter("@State", cand.State));
                command.Parameters.Add(new SqlParameter("@Location", cand.Location));

                command.Parameters.Add(new SqlParameter("@Qualification", cand.Qualification));
                command.Parameters.Add(new SqlParameter("@Fresherstatus", cand.Fresherstatus));
                command.Parameters.Add(new SqlParameter("@ReportingTo", cand.ReportingTo));
                command.Parameters.Add(new SqlParameter("@CurrentCTC", cand.CurrentCTC));
                command.Parameters.Add(new SqlParameter("@ExpectedCTCAnnum", cand.ExpectedCTCAnnum));
                command.Parameters.Add(new SqlParameter("@ExpectedCTCMonth", cand.ExpectedCTCMonth));
                command.Parameters.Add(new SqlParameter("@Comment1", cand.Comment1));
                command.Parameters.Add(new SqlParameter("@ImmediateJoinee", cand.ImmediateJoinee));

                command.Parameters.Add(new SqlParameter("@OfferedCTCAnnum", cand.OfferedCTCAnnum));
                command.Parameters.Add(new SqlParameter("@OfferedCTCMonth", cand.OfferedCTCMonth));
              
                command.Parameters.Add(new SqlParameter("@UpdatedBy", cand.UpdatedBy));
                command.Parameters.Add(new SqlParameter("@UpdatedDate", cand.UpdatedDate));
                command.Parameters.Add(new SqlParameter("@apptapproverdecision", cand.apptapproverdecision));
                command.Parameters.Add(new SqlParameter("@apptapprovercomments", cand.apptapprovercomments));
                command.Parameters.Add(new SqlParameter("@apptapprovedBy", cand.apptapprovedBy));
                command.Parameters.Add(new SqlParameter("@approverdecisionDate", cand.approverdecisionDate));

                command.Parameters.Add(new SqlParameter("@ID", cand.ID));

                rowsAffected = command.ExecuteNonQuery();

            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }

    public DataSet ViewCandidateDetailsforOBOByID(int ID,string empID)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataSet ds = new DataSet();
        using (SqlCommand command = new SqlCommand("ViewCandidateDetailsforOBOByID", cnn))
        {
            cnn.Open();
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@ID", ID));
            command.Parameters.Add(new SqlParameter("@appointmentReqBy", empID));
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(ds);
        }

        cnn.Close();
        return ds;
    }
    public DataSet ViewCandidateDetailsforOBOByIDnew(int ID)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataSet ds = new DataSet();
        using (SqlCommand command = new SqlCommand("ViewCandidateDetailsforOBOByIDnew", cnn))
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
    public int UpdateAppointStatusByOBO(CandidateDetails cand)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        SqlDateTime sqldatenull;
        sqldatenull = SqlDateTime.Null;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateAppointStatusByOBO", cnn))
            {

                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@FirstName", cand.FirstName));
                command.Parameters.Add(new SqlParameter("@MiddleName", cand.MiddleName));
                command.Parameters.Add(new SqlParameter("@LastName", cand.LastName));
                command.Parameters.Add(new SqlParameter("@EmailId", cand.EmailId));
                command.Parameters.Add(new SqlParameter("@Mobile", cand.Mobile));
                command.Parameters.Add(new SqlParameter("@Gender", cand.Gender));

                command.Parameters.Add(new SqlParameter("@assignedCompName", cand.assignedCompName));
                command.Parameters.Add(new SqlParameter("@jobfunction", cand.jobfunction));
                command.Parameters.Add(new SqlParameter("@product", cand.product));
                command.Parameters.Add(new SqlParameter("@designation", cand.designation));
                command.Parameters.Add(new SqlParameter("@State", cand.State));
                command.Parameters.Add(new SqlParameter("@Location", cand.Location));

                command.Parameters.Add(new SqlParameter("@Qualification", cand.Qualification));
                command.Parameters.Add(new SqlParameter("@Fresherstatus", cand.Fresherstatus));
                command.Parameters.Add(new SqlParameter("@ReportingTo", cand.ReportingTo));
                command.Parameters.Add(new SqlParameter("@CurrentCTC", cand.CurrentCTC));
                command.Parameters.Add(new SqlParameter("@ExpectedCTCAnnum", cand.ExpectedCTCAnnum));
                command.Parameters.Add(new SqlParameter("@ExpectedCTCMonth", cand.ExpectedCTCMonth));
                command.Parameters.Add(new SqlParameter("@Comment1", cand.Comment1));
                command.Parameters.Add(new SqlParameter("@ImmediateJoinee", cand.ImmediateJoinee));

                command.Parameters.Add(new SqlParameter("@OfferedCTCAnnum", cand.OfferedCTCAnnum));
                command.Parameters.Add(new SqlParameter("@OfferedCTCMonth", cand.OfferedCTCMonth));

                command.Parameters.Add(new SqlParameter("@OfferSentStatus", cand.OfferSentStatus));
                if (cand.OfferSentDate == DateTime.MaxValue)
                {
                    command.Parameters.Add(
                    new SqlParameter("@OfferSentDate", sqldatenull));
                }
                else
                {
                    command.Parameters.Add(
                    new SqlParameter("@OfferSentDate", cand.OfferSentDate));
                }
                if (cand.ExpectedDOJ == DateTime.MaxValue)
                {
                    command.Parameters.Add(
                    new SqlParameter("@ExpectedDOJ", sqldatenull));
                }
                else
                {
                    command.Parameters.Add(
                    new SqlParameter("@ExpectedDOJ", cand.ExpectedDOJ));
                }
                command.Parameters.Add(new SqlParameter("@Reason_For_No", cand.Reason_For_No));
                command.Parameters.Add(new SqlParameter("@What_Pending", cand.What_Pending));
                command.Parameters.Add(new SqlParameter("@OfferAcceptStatus", cand.OfferAcceptStatus));
                command.Parameters.Add(new SqlParameter("@CandidateJoined", cand.CandidateJoined));
                if (cand.DOJ == DateTime.MaxValue)
                {
                    command.Parameters.Add(
                    new SqlParameter("@DOJ", sqldatenull));
                }
                else
                {
                    command.Parameters.Add(
                    new SqlParameter("@DOJ", cand.DOJ));
                }
                command.Parameters.Add(new SqlParameter("@EmpCode", cand.EmpCode));
                command.Parameters.Add(new SqlParameter("@UpdatedBy", cand.UpdatedBy));
                command.Parameters.Add(new SqlParameter("@UpdatedDate", cand.UpdatedDate));
                command.Parameters.Add(new SqlParameter("@appointmentStatusBy", cand.appointmentStatusBy));
                command.Parameters.Add(new SqlParameter("@appointmentStatusDate", cand.appointmentStatusDate));

                command.Parameters.Add(new SqlParameter("@ID", cand.ID));

                rowsAffected = command.ExecuteNonQuery();

            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }

    public int UpdateProfileSheetByCandidate(CandidateDetails cand)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        SqlDateTime sqldatenull;
        sqldatenull = SqlDateTime.Null;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateProfileSheetByCandidate", cnn))
            {

                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;

                if (cand.DOB == DateTime.MaxValue)
                {
                    command.Parameters.Add(
                    new SqlParameter("@DOB", sqldatenull));
                }
                else
                {
                    command.Parameters.Add(
                    new SqlParameter("@DOB", cand.DOB));
                }
                command.Parameters.Add(new SqlParameter("@Bloodgrp", cand.Bloodgrp));
                command.Parameters.Add(new SqlParameter("@Fathername", cand.Fathername));
                command.Parameters.Add(new SqlParameter("@Mothername", cand.Mothername));
                command.Parameters.Add(new SqlParameter("@EmContactPerson", cand.EmContactPerson));
                command.Parameters.Add(new SqlParameter("@EmContactMobile", cand.EmContactMobile));

                command.Parameters.Add(new SqlParameter("@EmContactLocation", cand.EmContactLocation));
                command.Parameters.Add(new SqlParameter("@EmContactRelation", cand.EmContactRelation));
                command.Parameters.Add(new SqlParameter("@Address1", cand.Address1));
                command.Parameters.Add(new SqlParameter("@City1", cand.City1));
                command.Parameters.Add(new SqlParameter("@District1", cand.District1));
                command.Parameters.Add(new SqlParameter("@State1", cand.State1));
                command.Parameters.Add(new SqlParameter("@Pincode1", cand.Pincode1));

                command.Parameters.Add(new SqlParameter("@Address2", cand.Address2));
                command.Parameters.Add(new SqlParameter("@City2", cand.City2));
                command.Parameters.Add(new SqlParameter("@District2", cand.District2));
                command.Parameters.Add(new SqlParameter("@State2", cand.State2));
                command.Parameters.Add(new SqlParameter("@Pincode2", cand.Pincode2));
                command.Parameters.Add(new SqlParameter("@ResidenceYrFrom", cand.ResidenceYrFrom));
                command.Parameters.Add(new SqlParameter("@ResidenceYrTo", cand.ResidenceYrTo));
                command.Parameters.Add(new SqlParameter("@CurrentAddressType", cand.CurrentAddressType));

                command.Parameters.Add(new SqlParameter("@StayingWith", cand.StayingWith));
                command.Parameters.Add(new SqlParameter("@StayingWithName", cand.StayingWithName));
                command.Parameters.Add(new SqlParameter("@StayingWithMobile", cand.StayingWithMobile));
                command.Parameters.Add(new SqlParameter("@lastcompname", cand.lastcompname));
                command.Parameters.Add(new SqlParameter("@lastcompaddress", cand.lastcompaddress));
                command.Parameters.Add(new SqlParameter("@lastcompCity", cand.lastcompCity));
                command.Parameters.Add(new SqlParameter("@lastcompEmpID", cand.lastcompEmpID));
                command.Parameters.Add(new SqlParameter("@lastcompDesignation", cand.lastcompDesignation));
                command.Parameters.Add(new SqlParameter("@lastcompDept", cand.lastcompDept));
                command.Parameters.Add(new SqlParameter("@lastcompMngrname", cand.lastcompMngrname));
                command.Parameters.Add(new SqlParameter("@lastcompMngrMobile", cand.lastcompMngrMobile));
                command.Parameters.Add(new SqlParameter("@lastcompEmploytype", cand.lastcompEmploytype));
                if (cand.lastdurationFrom == DateTime.MaxValue)
                {
                    command.Parameters.Add(
                    new SqlParameter("@lastdurationFrom", sqldatenull));
                }
                else
                {
                    command.Parameters.Add(
                    new SqlParameter("@lastdurationFrom", cand.lastdurationFrom));
                }
                if (cand.lastdurationTo == DateTime.MaxValue)
                {
                    command.Parameters.Add(
                    new SqlParameter("@lastdurationTo", sqldatenull));
                }
                else
                {
                    command.Parameters.Add(
                    new SqlParameter("@lastdurationTo", cand.lastdurationTo));
                }
                command.Parameters.Add(new SqlParameter("@Ref1name", cand.Ref1name));
                command.Parameters.Add(new SqlParameter("@Ref1mobile", cand.Ref1mobile));
                command.Parameters.Add(new SqlParameter("@Ref1company", cand.Ref1company));
                command.Parameters.Add(new SqlParameter("@Ref1Design", cand.Ref1Design));
                command.Parameters.Add(new SqlParameter("@Ref1Relation", cand.Ref1Relation));

                command.Parameters.Add(new SqlParameter("@Ref2name", cand.Ref2name));
                command.Parameters.Add(new SqlParameter("@Ref2mobile", cand.Ref2mobile));
                command.Parameters.Add(new SqlParameter("@Ref2company", cand.Ref2company));
                command.Parameters.Add(new SqlParameter("@Ref2Design", cand.Ref2Design));
                command.Parameters.Add(new SqlParameter("@Ref2Relation", cand.Ref2Relation));

                command.Parameters.Add(new SqlParameter("@UpdatedBy", cand.UpdatedBy));
                command.Parameters.Add(new SqlParameter("@UpdatedDate", cand.UpdatedDate));

                command.Parameters.Add(new SqlParameter("@ID", cand.EmpCode));

                rowsAffected = command.ExecuteNonQuery();

            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }

    
    public int AddAddressVerification(CandidateDetails cand)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        SqlDateTime sqldatenull;
        sqldatenull = SqlDateTime.Null;
        try
        {
            using (SqlCommand command = new SqlCommand("AddAddressVerification", cnn))
            {

                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@VerificationSameAddress", cand.VerificationSameAddress));
                if (cand.VerificationDate == DateTime.MaxValue)
                {
                    command.Parameters.Add(
                    new SqlParameter("@VerificationDate", sqldatenull));
                }
                else
                {
                    command.Parameters.Add(
                    new SqlParameter("@VerificationDate", cand.VerificationDate));
                }

                command.Parameters.Add(new SqlParameter("@PersonMet", cand.PersonMet));
                command.Parameters.Add(new SqlParameter("@RelationshipPerson", cand.RelationshipPerson));
                command.Parameters.Add(new SqlParameter("@RelationshipName", cand.RelationshipName));
                command.Parameters.Add(new SqlParameter("@RelationshipMobileNo", cand.RelationshipMobileNo));

                command.Parameters.Add(new SqlParameter("@VerificationByRM", cand.VerificationByRM));
                command.Parameters.Add(new SqlParameter("@Reason", cand.Reason));
                command.Parameters.Add(new SqlParameter("@VerifierName", cand.VerifierName));
                command.Parameters.Add(new SqlParameter("@VerifierEmpCode", cand.VerifierEmpCode));
                command.Parameters.Add(new SqlParameter("@VerifierMobileNo", cand.VerifierMobileNo));
                command.Parameters.Add(new SqlParameter("@VerificationStatus", cand.VerificationStatus));

                command.Parameters.Add(new SqlParameter("@Address1", cand.Address1));
                command.Parameters.Add(new SqlParameter("@City1", cand.City1));
                command.Parameters.Add(new SqlParameter("@District1", cand.District1));
                command.Parameters.Add(new SqlParameter("@State1", cand.State1));
                command.Parameters.Add(new SqlParameter("@Pincode1", cand.Pincode1));


                command.Parameters.Add(new SqlParameter("@AddedBy", cand.AddedBy));
                command.Parameters.Add(new SqlParameter("@AddedDate", cand.AddedDate));
                command.Parameters.Add(new SqlParameter("@CanID", cand.CanID));

                rowsAffected = command.ExecuteNonQuery();

            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }

    public DataSet ViewAddressVerificationDetailsByID(int ID,string empId)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataSet ds = new DataSet();
        using (SqlCommand command = new SqlCommand("ViewAddressVerificationDetailsByID", cnn))
        {
            cnn.Open();
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@ID", ID));
            command.Parameters.Add(new SqlParameter("@EmpID", empId));
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(ds);
        }

        cnn.Close();
        return ds;
    }
    public int UpdateAddressVerification(CandidateDetails cand)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        SqlDateTime sqldatenull;
        sqldatenull = SqlDateTime.Null;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateAddressVerification", cnn))
            {

                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@VerificationSameAddress", cand.VerificationSameAddress));
                if (cand.VerificationDate == DateTime.MaxValue)
                {
                    command.Parameters.Add(
                    new SqlParameter("@VerificationDate", sqldatenull));
                }
                else
                {
                    command.Parameters.Add(
                    new SqlParameter("@VerificationDate", cand.VerificationDate));
                }

                command.Parameters.Add(new SqlParameter("@PersonMet", cand.PersonMet));
                command.Parameters.Add(new SqlParameter("@RelationshipPerson", cand.RelationshipPerson));
                command.Parameters.Add(new SqlParameter("@RelationshipName", cand.RelationshipName));
                command.Parameters.Add(new SqlParameter("@RelationshipMobileNo", cand.RelationshipMobileNo));

                command.Parameters.Add(new SqlParameter("@VerificationByRM", cand.VerificationByRM));
                command.Parameters.Add(new SqlParameter("@Reason", cand.Reason));
                command.Parameters.Add(new SqlParameter("@VerifierName", cand.VerifierName));
                command.Parameters.Add(new SqlParameter("@VerifierEmpCode", cand.VerifierEmpCode));
                command.Parameters.Add(new SqlParameter("@VerifierMobileNo", cand.VerifierMobileNo));
                command.Parameters.Add(new SqlParameter("@VerificationStatus", cand.VerificationStatus));

                command.Parameters.Add(new SqlParameter("@Address1", cand.Address1));
                command.Parameters.Add(new SqlParameter("@City1", cand.City1));
                command.Parameters.Add(new SqlParameter("@District1", cand.District1));
                command.Parameters.Add(new SqlParameter("@State1", cand.State1));
                command.Parameters.Add(new SqlParameter("@Pincode1", cand.Pincode1));


                command.Parameters.Add(new SqlParameter("@UpdatedBy", cand.UpdatedBy));
                command.Parameters.Add(new SqlParameter("@UpdatedDate", cand.UpdatedDate));
                command.Parameters.Add(new SqlParameter("@CanID", cand.CanID));

                rowsAffected = command.ExecuteNonQuery();

            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }

    public DataSet ViewAddressVerifyDetailsByCandID(string CandID)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataSet ds = new DataSet();
        using (SqlCommand command = new SqlCommand("ViewAddressVerifyDetailsByCandID", cnn))
        {
            cnn.Open();
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@CandID", CandID));
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(ds);
        }

        cnn.Close();
        return ds;
    }

    public DataSet ViewCandidateListByRM(string EmpID)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataSet ds = new DataSet();
        using (SqlCommand command = new SqlCommand("ViewCandidateListByRM", cnn))
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

    public DataSet ViewAppointmentRequest()
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataSet ds = new DataSet();
        using (SqlCommand command = new SqlCommand("ViewAppointmentRequest", cnn))
        {
            cnn.Open();
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(ds);
        }

        cnn.Close();
        return ds;
    }
    public DataSet ViewJobOfferApprovedListing()
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataSet ds = new DataSet();
        using (SqlCommand command = new SqlCommand("ViewJobOfferApprovedListing", cnn))
        {
            cnn.Open();
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(ds);
        }

        cnn.Close();
        return ds;
    }
    public DataSet ViewJobOfferAcceptedListing()
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataSet ds = new DataSet();
        using (SqlCommand command = new SqlCommand("ViewJobOfferAcceptedListing", cnn))
        {
            cnn.Open();
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(ds);
        }

        cnn.Close();
        return ds;
    }
      public DataSet ViewCandidatesWithMismatchedDOJ()
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataSet ds = new DataSet();
        using (SqlCommand command = new SqlCommand("ViewCandidatesWithMismatchedDOJ", cnn))
        {
            cnn.Open();
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(ds);
        }

        cnn.Close();
        return ds;
    }
    public DataSet ViewOfferLetterReworkListing()
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataSet ds = new DataSet();
        using (SqlCommand command = new SqlCommand("ViewOfferLetterReworkListing", cnn))
        {
            cnn.Open();
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(ds);
        }

        cnn.Close();
        return ds;
    }
    public DataSet ViewOfferLetterSentListing()
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataSet ds = new DataSet();
        using (SqlCommand command = new SqlCommand("ViewOfferLetterSentListing", cnn))
        {
            cnn.Open();
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(ds);
        }

        cnn.Close();
        return ds;
    }

    public int UpdateNotifyApptmentApprover(int ID,bool apptapprovernotify, bool apptOBOnotify)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateNotifyApptmentApprover", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@ID", ID));
                command.Parameters.Add(new SqlParameter("@apptapprovernotify", apptapprovernotify));
                command.Parameters.Add(new SqlParameter("@apptOBOnotify", apptOBOnotify));
                rowsAffected = command.ExecuteNonQuery();

            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }

    public DataSet ViewAppointmentApproval()
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataSet ds = new DataSet();
        using (SqlCommand command = new SqlCommand("ViewAppointmentApproval", cnn))
        {
            cnn.Open();
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(ds);
        }

        cnn.Close();
        return ds;
    }

    public DataSet ViewAppointmentApproved()
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataSet ds = new DataSet();
        using (SqlCommand command = new SqlCommand("ViewAppointmentApproved", cnn))
        {
            cnn.Open();
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(ds);
        }

        cnn.Close();
        return ds;
    }
    public DataSet ViewAppointmentDeclined()
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataSet ds = new DataSet();
        using (SqlCommand command = new SqlCommand("ViewAppointmentDeclined", cnn))
        {
            cnn.Open();
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(ds);
        }

        cnn.Close();
        return ds;
    }

    public DataSet ViewAppointApproverNotify()///For Admin
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataSet ds = new DataSet();
        using (SqlCommand command = new SqlCommand("ViewAppointApproverNotify", cnn))
        {
            cnn.Open();
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(ds);
        }

        cnn.Close();
        return ds;
    }

    public int UpdateAppointApproverNotified()
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateAppointApproverNotified", cnn))
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
        return rowsAffected;
    }
    public int UpdateNotifyApptmentOBO(int ID, bool apptapprovernotify, bool apptOBOnotify)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateNotifyApptmentOBO", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@ID", ID));
                command.Parameters.Add(new SqlParameter("@apptapprovernotify", apptapprovernotify));
                command.Parameters.Add(new SqlParameter("@apptOBOnotify", apptOBOnotify));
                rowsAffected = command.ExecuteNonQuery();

            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }

    public DataSet ViewAppointOBONotify()///For OBO
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataSet ds = new DataSet();
        using (SqlCommand command = new SqlCommand("ViewAppointOBONotify", cnn))
        {
            cnn.Open();
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(ds);
        }

        cnn.Close();
        return ds;
    }

    public int UpdateAppointOBONotified()
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateAppointOBONotified", cnn))
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
        return rowsAffected;
    }
    
    public int AddCandidateintoEmp(CandidateDetails cand)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("AddCandidateintoEmp", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@candID", cand.CanID));
                command.Parameters.Add(new SqlParameter("@EmpID", cand.EmpCode));
                command.Parameters.Add(new SqlParameter("@EmpFirstName", cand.FirstName));
                command.Parameters.Add(new SqlParameter("@EmpLastName", cand.LastName));
                command.Parameters.Add(new SqlParameter("@EmailId", cand.EmailId));
                command.Parameters.Add(new SqlParameter("@Mobile", cand.Mobile));
                command.Parameters.Add(new SqlParameter("@Gender", cand.Gender));

                //command.Parameters.Add(new SqlParameter("@DOB", cand.DOB));
                command.Parameters.Add(new SqlParameter("@Role", cand.Role));
                command.Parameters.Add(new SqlParameter("@Designation", cand.designation));
                command.Parameters.Add(new SqlParameter("@Supervisor1", cand.ReportingTo));
                command.Parameters.Add(new SqlParameter("@ClientName", cand.assignedCompName));
                command.Parameters.Add(new SqlParameter("@Dept", cand.product));

                command.Parameters.Add(new SqlParameter("@AddedBy", cand.AddedBy));
                command.Parameters.Add(new SqlParameter("@AddedDate", cand.AddedDate));
                //command.Parameters.Add(new SqlParameter("@EmpRole", emp.EmpRole));
                command.Parameters.Add(new SqlParameter("@EmpRoleClient", cand.assignedCompName));
                command.Parameters.Add(new SqlParameter("@EmpRoleDept", cand.product));
                //command.Parameters.Add(new SqlParameter("@Recommender", cand.Recommender));
                //command.Parameters.Add(new SqlParameter("@Approver", cand.Approver));

                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }

    public int UpdateDocumentConfirmation(CandidateDetails cand)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        string ReqID = string.Empty;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateDocumentConfirmation", cnn))
            {

                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@ID", cand.ID));

                command.Parameters.Add(new SqlParameter("@SSLCmark", cand.SSLCmark));
                command.Parameters.Add(new SqlParameter("@HSCmark", cand.HSCmark));
                command.Parameters.Add(new SqlParameter("@graduationmark", cand.graduationmark));
                command.Parameters.Add(new SqlParameter("@Resume", cand.Resume));
                command.Parameters.Add(new SqlParameter("@PreApptmentletter", cand.PreApptmentletter));
                command.Parameters.Add(new SqlParameter("@ExpRelievingLetter", cand.ExpRelievingLetter));
                command.Parameters.Add(new SqlParameter("@ResignAcceptLetter", cand.ResignAcceptLetter));
                command.Parameters.Add(new SqlParameter("@Previouspayslip", cand.PreviousPayslip));
                command.Parameters.Add(new SqlParameter("@Aadharcard", cand.Aadharcard));
                command.Parameters.Add(new SqlParameter("@Pancard", cand.Pancard));

                command.Parameters.Add(new SqlParameter("@SSLCmarkstatus", cand.SSLCmarkstatus));
                command.Parameters.Add(new SqlParameter("@SSLCmarkBy", cand.SSLCmarkBy));

                command.Parameters.Add(new SqlParameter("@HSCmarkstatus", cand.HSCmarkstatus));
                command.Parameters.Add(new SqlParameter("@HSCmarkBy", cand.HSCmarkBy));

                command.Parameters.Add(new SqlParameter("@graduationstatus", cand.graduationstatus));
                command.Parameters.Add(new SqlParameter("@graduationBy", cand.graduationBy));

                command.Parameters.Add(new SqlParameter("@Resumestatus", cand.Resumestatus));
                command.Parameters.Add(new SqlParameter("@ResumeBy", cand.ResumeBy));

                command.Parameters.Add(new SqlParameter("@PreAppointstatus", cand.PreAppointstatus));
                command.Parameters.Add(new SqlParameter("@PreAppointBy", cand.PreAppointBy));

                command.Parameters.Add(new SqlParameter("@Expstatus", cand.Expstatus));
                command.Parameters.Add(new SqlParameter("@ExpBy", cand.ExpBy));

                command.Parameters.Add(new SqlParameter("@Resignstatus", cand.Resignstatus));
                command.Parameters.Add(new SqlParameter("@ResignBy", cand.ResignBy));

                command.Parameters.Add(new SqlParameter("@Payslipstatus", cand.Payslipstatus));
                command.Parameters.Add(new SqlParameter("@PayslipBy", cand.PayslipBy));

                command.Parameters.Add(new SqlParameter("@Aadharcardstatus", cand.Aadharcardstatus));
                command.Parameters.Add(new SqlParameter("@AadharcardBy", cand.AadharcardBy));
                command.Parameters.Add(new SqlParameter("@Pancardstatus", cand.Pancardstatus));
                command.Parameters.Add(new SqlParameter("@PancardBy", cand.PancardBy));


                command.Parameters.Add(new SqlParameter("@ApptAccepted", cand.ApptAccepted));
                command.Parameters.Add(new SqlParameter("@ApptAcceptedstatus", cand.ApptAcceptedstatus));
                command.Parameters.Add(new SqlParameter("@ApptAcceptedBy", cand.ApptAcceptedBy));

                command.Parameters.Add(new SqlParameter("@ResdAddress", cand.ResdAddress));
                command.Parameters.Add(new SqlParameter("@ResdAddressstatus", cand.ResdAddressstatus));
                command.Parameters.Add(new SqlParameter("@ResdAddressBy", cand.ResdAddressBy));

                command.Parameters.Add(new SqlParameter("@Photo", cand.Photo));
                command.Parameters.Add(new SqlParameter("@Photostatus", cand.Photostatus));
                command.Parameters.Add(new SqlParameter("@PhotoBy", cand.PhotoBy));


                command.Parameters.Add(new SqlParameter("@FamilyPhoto", cand.FamilyPhoto));
                command.Parameters.Add(new SqlParameter("@FamilyPhotostatus", cand.FamilyPhotostatus));
                command.Parameters.Add(new SqlParameter("@FamilyPhotoBy", cand.FamilyPhotoBy));

                command.Parameters.Add(new SqlParameter("@BgVerification", cand.BgVerification));
                command.Parameters.Add(new SqlParameter("@BgVerificationstatus", cand.BgVerificationstatus));
                command.Parameters.Add(new SqlParameter("@BgVerificationBy", cand.BgVerificationBy));

                command.Parameters.Add(new SqlParameter("@EmpBranchCode", cand.EmpBranchCode));
                command.Parameters.Add(new SqlParameter("@EmpBranchCodestatus", cand.EmpBranchCodestatus));
                command.Parameters.Add(new SqlParameter("@EmpBranchCodeBy", cand.EmpBranchCodeBy));

                command.Parameters.Add(new SqlParameter("@GratReg", cand.GratReg));
                command.Parameters.Add(new SqlParameter("@GratRegstatus", cand.GratRegstatus));
                command.Parameters.Add(new SqlParameter("@GratRegBy", cand.GratRegBy));

                command.Parameters.Add(new SqlParameter("@ESIC", cand.ESIC));
                command.Parameters.Add(new SqlParameter("@ESICstatus", cand.ESICstatus));
                command.Parameters.Add(new SqlParameter("@ESICBy", cand.ESICBy));

                command.Parameters.Add(new SqlParameter("@PF", cand.PF));
                command.Parameters.Add(new SqlParameter("@PFstatus", cand.PFstatus));
                command.Parameters.Add(new SqlParameter("@PFBy", cand.PFBy));

                command.Parameters.Add(new SqlParameter("@updatedby", cand.UpdatedBy));
                command.Parameters.Add(new SqlParameter("@updateddate", cand.UpdatedDate));

                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }

    public int UpdateCandidateKycDocConfirmStatus(string stID, string stcolname, string ststatus, string strupdatedby)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateCandidateKycDocConfirmStatus", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ID", stID));
                command.Parameters.Add(new SqlParameter("@colname", stcolname));
                command.Parameters.Add(new SqlParameter("@status", ststatus));
                command.Parameters.Add(new SqlParameter("@updatedby", strupdatedby));
                command.Parameters.Add(new SqlParameter("@updateddate", Utility.IndianTime));

                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }

    public DataSet ViewCandidateAddressVerifyByEmpID(string EmpID)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataSet ds = new DataSet();
        using (SqlCommand command = new SqlCommand("ViewCandidateAddressVerifyByEmpID", cnn))
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

    public int AddReferenceCheckStatus(CandidateDetails cand)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("AddReferenceCheckStatus", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@CandID", cand.CanID));
                command.Parameters.Add(new SqlParameter("@EmpID", cand.EmpCode));
                command.Parameters.Add(new SqlParameter("@Ref1Checkstatus", cand.Ref1Checkstatus));
                command.Parameters.Add(new SqlParameter("@Ref2Checkstatus", cand.Ref2Checkstatus));

                command.Parameters.Add(new SqlParameter("@AddedBy", cand.AddedBy));
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

    public int UpdateReferenceCheckStatus(CandidateDetails cand)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateReferenceCheckStatus", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmpID", cand.EmpCode));
                command.Parameters.Add(new SqlParameter("@Ref1Checkstatus", cand.Ref1Checkstatus));
                command.Parameters.Add(new SqlParameter("@Ref2Checkstatus", cand.Ref2Checkstatus));

                command.Parameters.Add(new SqlParameter("@UpdatedBy", cand.UpdatedBy));
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
    public DataSet ViewReferenceCheckStatusByEmpID(string EmpID)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataSet ds = new DataSet();
        using (SqlCommand command = new SqlCommand("ViewReferenceCheckStatusByEmpID", cnn))
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

    public int UpdateCandidateOfferLetter(CandidateDetails cand)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateCandidateOfferLetter", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@OfferLetterPDF", cand.OfferLetterPDF));
                command.Parameters.Add(new SqlParameter("@OfferLetterPDFupdatedby", cand.OfferLetterPDFupdatedby));
                command.Parameters.Add(new SqlParameter("@OfferLetterPDFupdateddate", cand.OfferLetterPDFupdateddate));
                command.Parameters.Add(new SqlParameter("@OfferLetterPDFupdatedStatus", cand.OfferLetterPDFupdatedStatus));
                command.Parameters.Add(new SqlParameter("@ID", cand.ID));

                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }

    public int UpdateCandidateJobOfferApprovalStatus(CandidateDetails cand)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateCandidateJobOfferApprovalStatus", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@OfferAcceptStatus", cand.OfferAcceptStatus));
                command.Parameters.Add(new SqlParameter("@CandidateEstimatedDateofJoining", cand.CandidateEstimatedDateofJoining));
                command.Parameters.Add(new SqlParameter("@OfferLetterPDFAcceptedDate", cand.OfferLetterPDFAcceptedDate));
                command.Parameters.Add(new SqlParameter("@OfferLetterPDFAcceptedBy", cand.OfferLetterPDFAcceptedBy));
                command.Parameters.Add(new SqlParameter("@ID", cand.CanID));

                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }

    public DataSet GetGeofenceDetails(string EmpID)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataSet ds = new DataSet();
        using (SqlCommand command = new SqlCommand("GetGeofenceDetails", cnn))
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

    public int AddOutsideGeoFenceData(double latitude, double longitude, string EmpID, string geofence)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("AddOutsideGeoFenceData", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmpID", EmpID));
                command.Parameters.Add(new SqlParameter("@latitude", latitude));
                command.Parameters.Add(new SqlParameter("@longitude", longitude));
                command.Parameters.Add(new SqlParameter("@Geofence", geofence));
                command.Parameters.Add(new SqlParameter("@AttendanceDate", Utility.IndianTime));
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

    public int UpdateGeoFenceStatus(string EmpID, string Geofence)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdatGeoStatus", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmpID", EmpID));
                command.Parameters.Add(new SqlParameter("@Geofence", Geofence));

                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }

    public int AddLocationDetails(double latitude, double longitude, string EmpID, string googleMapsURL)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;

        // Database connection logic to insert or update the location details
        // Example:
        try 
        {
            using (SqlCommand cmd = new SqlCommand("SaveEmpLongLatitude", cnn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@EmpID", EmpID));
                cmd.Parameters.Add(new SqlParameter("@Latitude", latitude));
                cmd.Parameters.Add(new SqlParameter("@Longitude", longitude));
                cmd.Parameters.Add(new SqlParameter("@Radius", "100"));
                cmd.Parameters.Add(new SqlParameter("@GoogleAddress", googleMapsURL));

                cnn.Open();
                rowsAffected = cmd.ExecuteNonQuery();
            }
             cnn.Close();
        }
        catch (Exception ex)
        {

        }

        return rowsAffected;
    }


}