use db01h125
select * from CustomerDetails
create table CustomerDetails
(CustomerName varchar(25),
DateOfBirth date,
FatherName nvarchar(25),
Gender nvarchar(6),
MaritalStatus nvarchar(10),
CommunicationAddress nvarchar(100),
NomineeName nvarchar(25),
NomineeAddress nvarchar(100),
IDProofStatus nvarchar(10),
AddressProofStatus nvarchar(10),
IDProofDocument nvarchar(50),
AddressProofDocument nvarchar(50),
RegistrationID int identity primary key,
RegistrationStatus nvarchar(10),
ContactDetails bigint,
DefaultPassword nvarchar(20),
DateOfRegistration datetime,
RejectionReason nvarchar(30)
)

create table CustDetails
(RegistrationID int references CustomerDetails(RegistrationID),
CustomerID nvarchar(20) primary key,
ApprovalDate date)

create table tblLogin_Team1
(
	UserID nvarchar(10) primary key,
	UserPassword nvarchar(20),
	UserRole nvarchar(30),
	SecretQuestion nvarchar(50),
	Answer nvarchar(20)
	
)

create table Login_Details
(
	SlNo int identity,
	UserId nvarchar(20),
	LoginDate nvarchar(50),
	LoginTime nvarchar(50),
	IPAddress nvarchar(20)
)

create table Account_Details
(	
	RegistrationID int references CustomerDetails(RegistrationID),
	AccountId bigint primary key identity(100001,1),
	AccountType nvarchar(20),
	Balance decimal(7,2),
	AccountCreationDate date
)


create table tbl_TransactionDetails_Team1
(TransactionID int identity primary key,
AccountID bigint references Account_Details(AccountId),
StartDate date,
Credit int,
Debit int,
Balance int)

use db01h125
DROP table CheckBookDetails_Team1
create table CheckBookDetails_Team1
(RequestID int identity primary key,
CheckBookNo int,
AccountID bigint references Account_Details(AccountID),
DateOfRequest date,
DateOfIssue date,
RequestStatus nvarchar(20)) 
use account
create table VisitorDetails
(VisitorName nvarchar(20),
ContactNo bigint,
Email  nvarchar(40)) 




