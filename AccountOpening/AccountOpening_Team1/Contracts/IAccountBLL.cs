using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contracts
{
   public interface IAccountBLL
    {
        
         //  Customer Enrollment
       
        bool RegisterCustomer(ICustomerDetailsBO ubo);
        List<ICustomerDetailsBO> ViewCustomerRegistrationRequest(ICustomerDetailsBO ubo);
        List<ICustomerDetailsBO> AddCustomerToBank(ICustomerDetailsBO cbo);
        List<ICustomerDetailsBO> ShowCustomerRegistrationRequest(ICustomerDetailsBO cbo); //show details in gridview
        List<ICustomerDetailsBO> EditCustomerRegistrationRequest(ICustomerDetailsBO cbo);  //Edit for update in gridview
        void UpdateApproveStatusBO(ICustomerDetailsBO cbo);
        List<ICustomerDetailsBO> ShowCustomerInfoRequest(ICustomerDetailsBO cbo);
        void ShowCustomerInfoDetails(ICustomerDetailsBO cbo);
       
        //  Validations And Verification

        List<ICustomerDetailsBO> ShowCustomerDetailsBM(ICustomerDetailsBO cbo);//get details of customer in gridview
        List<ICustomerDetailsBO> ViewAccountDetailsByDate(ICustomerDetailsBO cbo);
        List<ICustomerDetailsBO> ViewAllAccountDetails(ICustomerDetailsBO cbo);
        bool GenerateAccountAccessDetails(ICustomerDetailsBO cbo);//generate account id and password
        bool RejectCustomer(ICustomerDetailsBO cbo);
        bool UpdateRegistrationStatus(ICustomerDetailsBO cbo);
        void UpdateRegisteredCustomer(ICustomerDetailsBO ubo);

         //  Account Operations
        int GetAccountID(ICustomerDetailsBO cbo);
       void EditPersonalDetails(ICustomerDetailsBO cbo);
       bool IsFirstLogin(ILoginDetailsBO lbo);
        bool Login(ILoginDetailsBO lbo);
        void AddLoginDetails(ILoginDetailsBO lbo);
        List<ITransactionBO> ViewTransactionDetails(ITransactionBO tbo);
         bool AddVisitor(IVisitorBO vbo);
        void ViewPersonalDetails(ICustomerDetailsBO cbo);
        void RequestCheckBook(ICheckbookBO cbo);
        List<ICheckbookBO> ViewCheckBookRequest(ICheckbookBO cbo);
        void SetSecretQuestion(ILoginDetailsBO lbo);
       bool ChangePassword(ILoginDetailsBO lbo);
        void ForgotPassword(ILoginDetailsBO lbo);
    }
}
