using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contracts;

namespace BO
{
    public class CustomerDetailsBO:ICustomerDetailsBO
    {
        public string CustomerName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string FatherName { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string CommunicationAddress { get; set; }
        public string NomineeName { get; set; }
        public string NomineeAddress { get; set; }
        public string IDProofStatus { get; set; }
        public string AddressProofStatus { get; set; }
        public string IDProofDocument { get; set; }
        public string AddressProofDocument { get; set; }
        public int RegistrationID { get; set; }
        public string RegistrationStatus { get; set; }
        public DateTime currentDate { get; set; }
        public string CustomerID { get; set; }
        public string DefaultPassword { get; set; }
        public long ContactDetails { get; set; }
        public string Reason { get; set; }
        public string AccountType { get; set; }
        public int Balance { get; set; }
        public DateTime CustomerRegistrationDate { get; set; }
        public int AccountId { get; set; }
        public DateTime AccountCreationDate { get; set; }
        public DateTime BOApprovalDate { get; set; }
        
        
    }
}
