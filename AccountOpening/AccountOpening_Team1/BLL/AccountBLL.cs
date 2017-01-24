using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contracts;
using FactoryPatternDAL;


namespace BLL
{
   public class AccountBLL:IAccountBLL
  {

     
      /*----------------------------validations and verifications--------------------------------------------------*/


           public bool  GenerateAccountAccessDetails(ICustomerDetailsBO cbo)
           {
                IAccountDAL dal;
                dal = DALFactory.CreateInstance();
                bool result = dal.GenerateAccountAccessDetails(cbo);
                return result;
           }
          

           public List<ICustomerDetailsBO> ViewAccountDetailsByDate(ICustomerDetailsBO cbo)
           {
               IAccountDAL dal;
               dal = DALFactory.CreateInstance();
               List<ICustomerDetailsBO> result = dal.ViewAccountDetailsByDate(cbo);
               return result;
           }

           public List<ICustomerDetailsBO> ViewAllAccountDetails(ICustomerDetailsBO cbo)
           {
               IAccountDAL dal;
               dal = DALFactory.CreateInstance();
               List<ICustomerDetailsBO> result = dal.ViewAllAccountDetails(cbo);
               return result;
           }

          
           public List<ICustomerDetailsBO> ShowCustomerDetailsBM(ICustomerDetailsBO cbo)
           {
               IAccountDAL dal;
               dal = DALFactory.CreateInstance();
               List<ICustomerDetailsBO> result = dal.ShowCustomerDetailsBM(cbo);
               return result;
           }
           public List<ICheckbookBO> ViewCheckBookRequest(ICheckbookBO cbo)
           {
               IAccountDAL dal;
               dal = DALFactory.CreateInstance();
               List<ICheckbookBO> result = dal.ViewCheckBookRequest(cbo);
               return result;
           }

           public bool RejectCustomer(ICustomerDetailsBO cbo)
           {
               IAccountDAL dal;
               dal = DALFactory.CreateInstance();
               bool result = dal.RejectCustomer(cbo);
               return result;
           }
           public bool UpdateRegistrationStatus(ICustomerDetailsBO cbo)
           {
               IAccountDAL dal;
               dal = DALFactory.CreateInstance();
               bool result = dal.UpdateRegistrationStatus(cbo);
               return result;
           }


/*-----------------------------------------------------------customer enrollment---------------------------------------------------------------*/

          
           public void UpdateRegisteredCustomer(ICustomerDetailsBO ubo)
           {
               IAccountDAL udal;

               udal = DALFactory.CreateInstance();
               udal.UpdateRegisteredCustomer(ubo);

           }

           public List<ICustomerDetailsBO> ShowCustomerInfoRequest(ICustomerDetailsBO cbo) // create a method to view Customer Details
           {
               IAccountDAL dal;
               dal = DALFactory.CreateInstance();
               List<ICustomerDetailsBO> result = dal.ShowCustomerInfoRequest(cbo);
               return result;
           }


           public void UpdateApproveStatusBO(ICustomerDetailsBO cbo)
           {
               IAccountDAL dal;
               dal = DALFactory.CreateInstance();
               dal.UpdateApproveStatusBO(cbo);

           }

           public List<ICustomerDetailsBO> AddCustomerToBank(ICustomerDetailsBO cbo)
           {
               IAccountDAL dal;   //create obj of accnt dal
               dal = DALFactory.CreateInstance();  //allocate memory to dal
               List<ICustomerDetailsBO> result = dal.AddCustomerToBank(cbo);
               return result;
           }

           public void ShowCustomerInfoDetails(ICustomerDetailsBO cbo)
           {
               IAccountDAL dal;
               dal = DALFactory.CreateInstance();
               dal.ShowCustomerInfoDetails(cbo);

           }
           public int GetAccountID(ICustomerDetailsBO cbo)
           {
               IAccountDAL dal;
               dal = DALFactory.CreateInstance();
               int AccId = dal.GetAccountID(cbo);
               return AccId;
           }

      public bool RegisterCustomer(ICustomerDetailsBO cbo)
      {
          IAccountDAL udal;

          udal = DALFactory.CreateInstance();
         bool result= udal.RegisterCustomer(cbo);
         return result;
      }

      public List<ICustomerDetailsBO> ViewCustomerRegistrationRequest(ICustomerDetailsBO ubo)
      {
          IAccountDAL dal;   //create obj of accnt dal
          dal = DALFactory.CreateInstance();  //allocate memory to dal
          List<ICustomerDetailsBO> result = dal.ViewCustomerRegistrationRequest(ubo);
          return result;
      }
      /// <summary>
      /// Sutrishna
      /// </summary>
      /// <param name="cbo"></param>
      /// <returns></returns>
      public List<ICustomerDetailsBO> ShowCustomerRegistrationRequest(ICustomerDetailsBO cbo) // create a method to view Customer Details
      {
          IAccountDAL dal;
          dal = DALFactory.CreateInstance();
          List<ICustomerDetailsBO> result = dal.ShowCustomerDetails(cbo);
          return result;
      }
       /// <summary>
       /// added by sutrishna
       /// </summary>
       /// <param name="cbo"></param>
       /// <returns></returns>
      public List<ICustomerDetailsBO> EditCustomerRegistrationRequest(ICustomerDetailsBO cbo)  //create a method to edit Customer Details
      {
          IAccountDAL dal;
          dal = DALFactory.CreateInstance();
          List<ICustomerDetailsBO> result = dal.EditCustomerDetails(cbo);
          return result;
      }


       /*-------------------------------------------------------account operations-------------------------------------------------*/
      
      public void EditPersonalDetails(ICustomerDetailsBO cbo)
      {
          IAccountDAL dal;
          dal = DALFactory.CreateInstance();
          dal.EditPersonalDetails(cbo);
      }
      public bool IsFirstLogin(ILoginDetailsBO lbo)
      {
          IAccountDAL dal;
          dal=DALFactory.CreateInstance();
          bool result=dal.isFirstLogin(lbo);
          return result;
      }


      public bool Login(ILoginDetailsBO lbo)
      {
          IAccountDAL dal;
          dal = DALFactory.CreateInstance();
          bool result=dal.UserLogin(lbo);
          return result;
      }
      public void AddLoginDetails(ILoginDetailsBO lbo)
      {
          IAccountDAL dal;
          dal = DALFactory.CreateInstance();
           dal.AddUserLoginDetails(lbo);
          
      }


      public List<ITransactionBO> ViewTransactionDetails(ITransactionBO tbo)
      {
          IAccountDAL dal;
          dal = DALFactory.CreateInstance();
         List<ITransactionBO> transList= dal.ViewTransactionDetails(tbo);
         return transList;
      }

     
      public void ViewPersonalDetails(ICustomerDetailsBO cbo)
      {
          IAccountDAL dal;
          dal = DALFactory.CreateInstance();
          dal.ViewPersonalDetails(cbo);
      }

      public void RequestCheckBook(ICheckbookBO cbo)
      {
          IAccountDAL dal;
          dal = DALFactory.CreateInstance();
          dal.RequestCheckBook(cbo);
         
      }
      public bool AddVisitor(IVisitorBO vbo)
      {
          IAccountDAL udal;

          udal = DALFactory.CreateInstance();
          bool result = udal.AddVisitor(vbo);
          return result;
      }
     
     

      public bool ChangePassword(ILoginDetailsBO lbo)
      {
          IAccountDAL dal;
          dal = DALFactory.CreateInstance();
        bool result=  dal.ChangePassword(lbo);
        return result;
      }

    public  void ForgotPassword(ILoginDetailsBO lbo)
    {
          IAccountDAL dal;
          dal = DALFactory.CreateInstance();
          dal.ForgotPassword(lbo);
          
      }
      public void SetSecretQuestion(ILoginDetailsBO lbo)
      {
          IAccountDAL dal;
          dal = DALFactory.CreateInstance();
          dal.SetSecretQuestion(lbo);
      }
  }
}
