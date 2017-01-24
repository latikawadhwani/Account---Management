using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contracts
{
   public interface ICustomerDetailsBO
    {
string CustomerName{get;set;}
DateTime DateOfBirth {get;set;}
string FatherName {get;set;}
string Gender {get;set;}
string MaritalStatus {get;set;}
string CommunicationAddress {get;set;}
string NomineeName { get; set; }
string NomineeAddress {get;set;}
string IDProofStatus {get;set;}
string AddressProofStatus {get;set;}
string IDProofDocument {get;set;}
string AddressProofDocument {get;set;}
int  RegistrationID {get;set;}
string RegistrationStatus {get;set;}
string CustomerID {get;set;}
DateTime currentDate { get; set; }
string DefaultPassword {get;set;}
long ContactDetails{get;set;}
string AccountType { get; set; }
string Reason { get; set; }
int Balance { get; set; }
DateTime CustomerRegistrationDate { get; set; }
int AccountId { get; set; }
DateTime AccountCreationDate { get; set; }
DateTime BOApprovalDate { get; set; }
    }
}
