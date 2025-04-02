


sp_helptext ViewLoginApprovedStatusBoth


CREATE PROCEDURE [dbo].[ViewLoginApprovedStatusBoth]           
@EmpID varchar(200)       
AS                    
BEGIN                    
                     
 SET NOCOUNT ON;                    
Select loginApproval from tblEmpDetails where  EmpID=@EmpID      
        
END 


exec [ViewLoginApprovedStatusBoth]           
@EmpID ='333495'    

Select LoginApproval from tblEmpDetails where  EmpID='333495'






sp_helptext ViewValidLoginEmployeeBoth

CREATE PROCEDURE [dbo].[ViewValidLoginEmployeeBoth]           
@EmpID varchar(200),     
@mpin varchar(50)    
AS                    
BEGIN                    
                     
 SET NOCOUNT ON;                    
Select * from tblEmpDetails where  EmpID=@EmpID and MPIN=@mpin    
        
END 