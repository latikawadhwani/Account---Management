use db01h125

create procedure sp_updateRegisteredDetaillss
(
@CustomerName varchar(25),
@DateOfBirth date,
@FatherName nvarchar(25),
@Gender nvarchar(6),
@MaritalStatus nvarchar(10),
@ContactDetails nvarchar(10),
@CommunicationAddress nvarchar(100),
@NomineeName nvarchar(25),
@NomineeAddress nvarchar(100),
@IDProofStatus nvarchar(10),
@AddressProofStatus nvarchar(10),
@RegistrationID int
)
as 
 update CustomerDetails set CustomerName=@CustomerName,DateOfBirth=@DateOfBirth,FatherName=@FatherName,Gender=@Gender,MaritalStatus=@MaritalStatus,ContactDetails=@ContactDetails,CommunicationAddress=@CommunicationAddress,NomineeName=@NomineeName,
NomineeAddress=@NomineeAddress,IDProofStatus=@IDProofStatus,AddressProofStatus=@AddressProofStatus where RegistrationID=@RegistrationID



create procedure sp_viewPersonalDetails
@UserID nvarchar(20)
as
select CustomerName,
DateOfBirth,
FatherName,
Gender,
MaritalStatus,
ContactDetails,
NomineeName,
NomineeAddress from CustomerDetails,CustDetails where CustDetails.CustomerID=@UserID and CustomerDetails.RegistrationID=CustDetails.RegistrationID

exec sp_viewPersonalDetails abc_abc_1

create procedure usp_UserLogin
  @UserID varchar(20),
  @Password varchar(20)
  as
  select * from tblLogin_Team1 where UserID=@UserID and UserPassword=@Password
  
  create procedure usp_SetSecretQuestion
@UserID nvarchar(20),
@SecretQuestion nvarchar(50),
@Answer nvarchar(30)
as
update tblLogin_Team1 set SecretQuestion=@SecretQuestion,Answer=@Answer where UserID=@UserID

  
 
  create procedure usp_isFirstLogin
@UserId nvarchar(20)
as
select COUNT(*) from Login_Details where  UserId=@UserID


create procedure sp_changePassword1
@UserID nvarchar(20),
@OldPassword nvarchar(20),
@NewPassword nvarchar(20),
@Status int out 
as
begin
if exists(select * from tblLogin_Team1 where UserID=@UserID and UserPassword=@OldPassword)
begin
update tblLogin_Team1 set UserPassword=@NewPassword where UserID=@UserID and UserPassword=@OldPassword
set @Status=1
end
else
begin
set @Status=0
end
end

alter procedure sp_InsertLoginDetails_Team1
@UserID nvarchar(20),
@LoginDate nvarchar(50),
@LoginTime nvarchar(50),
@LoginIP nvarchar(20)
as
insert into Login_Details (UserId,LoginDate,LoginTime,IPAddress) values(@UserID,@LoginDate,@LoginTime,@LoginIP)

create procedure usp_ForgotPassword
@UserID nvarchar(20),
@Answer nvarchar(30),
@NewPassword nvarchar(20)
as
update tblLogin_Team1 set UserPassword=@NewPassword where UserID=@UserID and Answer=@Answer

use account
create procedure sp_EditPersonalDetails
@UserID nvarchar(20),
@MaritalStatus nvarchar(20),
@NomineeName nvarchar(25),
@NomineeAddress nvarchar(50)
as
update CustomerDetails set MaritalStatus=@MaritalStatus,NomineeName=@NomineeName,NomineeAddress=@NomineeAddress from CustomerDetails A join CustDetails B on A.RegistrationID=B.RegistrationID where B.CustomerID=@UserID  

exec sp_EditPersonalDetails 'abc_abc_1','single','kkl','ppo'
select * from CustomerDetails
select * from tblLogin_Team1


alter procedure usp_InsertCustomer
(
@CustomerName varchar(25),
@DateOfBirth date,
@FatherName nvarchar(25),
@Gender nvarchar(6),
@MaritalStatus nvarchar(10),
@ContactDetails bigint,
@CommunicationAddress nvarchar(100),
@NomineeName nvarchar(25),
@NomineeAddress nvarchar(100),
@IDProofDocument nvarchar(50),
@AddressProofDocument nvarchar(50),
@DateOfRegistration date
 )
 as 
 insert CustomerDetails(CustomerName,DateOfBirth,FatherName,Gender,MaritalStatus,ContactDetails,CommunicationAddress,NomineeName,
NomineeAddress,IDProofStatus,AddressProofStatus,IDProofDocument,AddressProofDocument,RegistrationStatus,DateOfRegistration) values(@CustomerName,@DateOfBirth,@FatherName,@Gender,@MaritalStatus,@ContactDetails,@CommunicationAddress,@NomineeName,
@NomineeAddress,'Pending','Pending',@IDProofDocument,@AddressProofDocument,'Pending',@DateOfRegistration) 


alter procedure viewRegCustomerDetails
(
@CustomerRequestDate Date
)
as
select CustomerName,DateOfBirth,Gender,CommunicationAddress,NomineeName, 
NomineeAddress,IDProofStatus,AddressProofStatus from CustomerDetails where DateOfRegistration=@CustomerRequestDate and RegistrationStatus='Pending'

create procedure sp_selectDetails
as
begin
select RegistrationID,CustomerName,DateOfBirth,Gender,CommunicationAddress,NomineeName,NomineeAddress,IDProofStatus,AddressProofStatus from CustomerDetails where RegistrationStatus='Pending'
end

create procedure usp_UpdateStatus
(@id int,
@Balance int,
@AccountCreationDate date,
@DefaultPassword nvarchar(20))
as
begin
update CustomerDetails set RegistrationStatus='Approved',DefaultPassword=@DefaultPassword,IDProofStatus='Approved',AddressProofStatus='Approved' where RegistrationStatus='Pending' and RegistrationID=@id
insert into Account_Details (RegistrationID,AccountType,Balance,AccountCreationDate) values(@id,'Savings',@Balance,@AccountCreationDate)
end

create procedure sp_deleteDetails
@id int
as
begin
update CustomerDetails set RegistrationStatus='Rejected' where RegistrationStatus='Pending' and RegistrationID=@id
end

create procedure usp_GenerateDefaultPassword
@id int
as
select CustomerName,DateOfBirth,FatherName,Gender,MaritalStatus,NomineeName,NomineeAddress,ContactDetails from CustomerDetails where RegistrationID=@id


create procedure usp_AddCustomers
as
select
RegistrationID, 
CustomerName,
DateOfBirth,
Gender,
CommunicationAddress,
NomineeName, 
NomineeAddress,
IDProofStatus,
AddressProofStatus,
ContactDetails 
 from CustomerDetails where RegistrationStatus='Approved' 
 
 
 alter procedure usp_UpdateApproveStatusBO
(@RegistrationID nvarchar(10),
@CustomerID nvarchar(20),
@BOApprovaldate date)
as
begin
update CustomerDetails set RegistrationStatus='Accepted' where RegistrationStatus='Approved' and RegistrationID=@RegistrationID
INSERT INTO CustDetails values(@RegistrationID,@CustomerID,@BOApprovaldate)
insert into tblLogin_Team1 (UserID,UserPassword,UserRole) values(@CustomerID,(select DefaultPassword from CustomerDetails where RegistrationID=@RegistrationID),'CUST')
end

alter procedure sp_EditListCustDetail
(
@CustomerRequestDate Date
)
as
select CustomerName,DateOfBirth,FatherName,Gender,MaritalStatus,CommunicationAddress,ContactDetails,NomineeName, 
NomineeAddress,IDProofDocument,IDProofStatus,AddressProofDocument,AddressProofStatus,RegistrationID from CustomerDetails where DateOfRegistration=@CustomerRequestDate and RegistrationStatus='Pending'
 
 alter procedure sp_getAccountID
 @CustomerID nvarchar(20)
 as
 select AccountID from Account_Details join CustDetails on Account_Details.RegistrationID=CustDetails.RegistrationID JOIN CustomerDetails on CustDetails.RegistrationID=CustomerDetails.RegistrationID where CustDetails.CustomerID=@CustomerID
 
 exec sp_getAccountID 'abc_abc_1'
 
 create procedure sp_ViewTransactionDetails
@AccountID bigint
as
select * from tbl_TransactionDetails_Team1 where AccountID=@AccountID

create procedure usp_UpdateRegisteredDetails
@RegistrationID int,
@CustomerName nvarchar(50),
@DateOfBirth date,
@FatherName nvarchar(50),
@Gender nvarchar(50),
@MaritalStatus nvarchar(50),
@ContactDetails bigint,
@CommunicationAddress nvarchar(150),
@NomineeName nvarchar(50),
@NomineeAddress nvarchar(150)
as
update CustomerDetails set CustomerName=@CustomerName,DateOfBirth=@DateOfBirth,FatherName=@FatherName,Gender=@Gender,MaritalStatus=@MaritalStatus,ContactDetails=@ContactDetails,CommunicationAddress=@CommunicationAddress,NomineeName=@NomineeName,NomineeAddress=@NomineeAddress where RegistrationID=@RegistrationID

create procedure sp_RequestCheckbook
@UserID bigint,
@RequestDate date,
@Status nvarchar(20)
as 
insert into CheckBookDetails_Team1 (AccountID,DateOfRequest,RequestStatus) values(@UserID,@RequestDate,@Status)

create procedure sp_ViewCheckBookRequest
as
select * from CheckBookDetails_Team1 where RequestStatus='Pending'

create procedure sp_ApproveCheckBook
@AccountID bigint
as
update CheckBookDetails_Team1 set RequestStatus='Approved'
use account

select * from CustomerDetails
select * from tblLogin_Team1
select * from Account_Details
use account
create procedure usp_AddVisitor
@VisitorName nvarchar(20),
@ContactNo bigint,
@Email  nvarchar(40)
as
insert into VisitorDetails values (@VisitorName,@ContactNo,@Email)

use db01h125

alter procedure sp_ViewCheckBookRequest
@AccountID bigint
as
select * from CheckBookDetails_Team1 where AccountID=@AccountID

insert into tblLogin_Team1 (UserID,UserPassword,UserRole) values('abc_2',(select DefaultPassword from CustomerDetails where RegistrationID=3),'CUST')