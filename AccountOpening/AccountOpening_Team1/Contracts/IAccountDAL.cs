using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contracts
{
    public interface IAccountDAL
    {
        /*------------------------------------------account operations-----------------------------------------*/

        int GetAccountID(ICustomerDetailsBO cbo); 
        bool UserLogin(ILoginDetailsBO lbo);
         void AddUserLoginDetails(ILoginDetailsBO lbo);
         void ViewPersonalDetails(ICustomerDetailsBO cbo);
         void EditPersonalDetails(ICustomerDetailsBO cbo);
         bool isFirstLogin(ILoginDetailsBO lbo);
         bool ChangePassword(ILoginDetailsBO lbo);
         void SetSecretQuestion(ILoginDetailsBO lbo);
         void ForgotPassword(ILoginDetailsBO lbo);
         List<ITransactionBO> ViewTransactionDetails(ITransactionBO tbo);
         void RequestCheckBook(ICheckbookBO cbo);
          bool AddVisitor(IVisitorBO vbo);
          List<ICheckbookBO> ViewCheckBookRequest(ICheckbookBO cbo);

        /*-----------------------------------customer enrollment------------------------------------------------*/

        bool RegisterCustomer(ICustomerDetailsBO ubo);
        List<ICustomerDetailsBO> ViewCustomerRegistrationRequest(ICustomerDetailsBO icbo);
        List<ICustomerDetailsBO> AddCustomerToBank(ICustomerDetailsBO cbo);
        //List<ICustomerDetailsBO> ShowCustomerRegistrationRequest(ICustomerDetailsBO cbo);
        List<ICustomerDetailsBO> ShowCustomerDetails(ICustomerDetailsBO icbo);
        List<ICustomerDetailsBO> EditCustomerDetails(ICustomerDetailsBO icbo);
        void UpdateApproveStatusBO(ICustomerDetailsBO cbo);
        List<ICustomerDetailsBO> ShowCustomerInfoRequest(ICustomerDetailsBO cbo);
        void ShowCustomerInfoDetails(ICustomerDetailsBO cbo);
        void UpdateRegisteredCustomer(ICustomerDetailsBO ubo);

        /*--------------------------------validations and verifications------------------------------------------*/

        List<ICustomerDetailsBO> ShowCustomerDetailsBM(ICustomerDetailsBO icbo);
        bool GenerateAccountAccessDetails(ICustomerDetailsBO icbo);
        List<ICustomerDetailsBO> ViewAccountDetailsByDate(ICustomerDetailsBO icbo);
        List<ICustomerDetailsBO> ViewAllAccountDetails(ICustomerDetailsBO icbo);
        bool RejectCustomer(ICustomerDetailsBO icbo);
        bool UpdateRegistrationStatus(ICustomerDetailsBO icbo);
    }
}
