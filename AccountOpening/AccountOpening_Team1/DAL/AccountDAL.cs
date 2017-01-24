using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contracts;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using BO;

namespace DAL
{
    public class AccountDAL:IAccountDAL
    {


        /*-------------------------------------------------------account operations-------------------------------------------------------------------------*/


        public int GetAccountID(ICustomerDetailsBO cbo)
        {
             int acCID=0;
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(constr))
                {
                   
                    SqlCommand cmd = new SqlCommand("sp_getAccountID", conn);
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CustomerID", cbo.CustomerID);
                    SqlDataReader rdr=cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                           acCID = Convert.ToInt32(rdr[0]);
                        }
                    }
                }
                return acCID;
            }

            catch (Exception ex)
            {
                return acCID;
            }
    
        }

        /// <summary>
        /// login method latika
        /// </summary>
        /// <param name="lbo"></param>
        /// <returns></returns>
        public bool UserLogin(ILoginDetailsBO lbo)
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    SqlCommand cmd = new SqlCommand("usp_UserLogin", conn);
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", lbo.userID);
                    cmd.Parameters.AddWithValue("@Password", lbo.Password);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        while (rdr.Read()) 
                        lbo.Role=rdr[2].ToString();
                        return true;
                    }
                    else
                        return false;

                }



            }

            catch (Exception ex)
            {
                return false;
            }

        }


        /// <summary>
        /// method to track login details of user
        /// added by latika
        /// </summary>
        /// <param name="lbo"></param>
          public void AddUserLoginDetails(ILoginDetailsBO lbo)
          {
              try
              {
                  string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                  using (SqlConnection conn = new SqlConnection(constr))
                  {
                      SqlCommand cmd = new SqlCommand("sp_InsertLoginDetails_Team1", conn);
                      conn.Open();
                      cmd.CommandType = CommandType.StoredProcedure;
                      cmd.Parameters.AddWithValue("@UserID", lbo.userID);
                      cmd.Parameters.AddWithValue("@LoginDate", lbo.loginDate);
                      cmd.Parameters.AddWithValue("@LoginTime", lbo.loginTime);
                      cmd.Parameters.AddWithValue("@LoginIP", lbo.loginIP);
                      cmd.ExecuteNonQuery();
                  }
              }

              catch (Exception ex)
              {
                  
              }
    
              }


        /// <summary>
        /// method to view personal details of customer
        /// added by latika
        /// </summary>
        /// <param name="cbo"></param>
          public void ViewPersonalDetails(ICustomerDetailsBO cbo)
          {
              try
              {
                  string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                  using (SqlConnection conn = new SqlConnection(constr))
                  {
                      SqlCommand cmd = new SqlCommand("sp_viewPersonalDetails", conn);
                      conn.Open();
                      cmd.CommandType = CommandType.StoredProcedure;
                      cmd.Parameters.AddWithValue("@UserID", cbo.CustomerID);
                      
                      SqlDataReader rdr = cmd.ExecuteReader();
                      if (rdr.HasRows)
                      {
                          while (rdr.Read())
                          {
                              cbo.CustomerName = rdr[0].ToString();
                              cbo.FatherName = rdr[2].ToString();
                              
                              cbo.DateOfBirth = Convert.ToDateTime(rdr[1].ToString());//remove time
                              cbo.Gender = rdr[3].ToString();
                              cbo.ContactDetails = Convert.ToInt64(rdr[5]);
                              cbo.MaritalStatus = rdr[4].ToString();
                              cbo.NomineeName = rdr[6].ToString();
                              cbo.NomineeAddress = rdr[7].ToString();

                          }
                      }
                     
                  }



              }

              catch (Exception ex)
              {
                  
              }

          }


        /// <summary>
        /// method to edit personal details of customer
        /// added by latika
        /// </summary>
        /// <param name="cbo"></param>
          public void EditPersonalDetails(ICustomerDetailsBO cbo)
          {
              try
              {
                  string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                  using (SqlConnection conn = new SqlConnection(constr))
                  {
                      SqlCommand cmd = new SqlCommand("sp_EditPersonalDetails", conn);
                      conn.Open();
                      cmd.CommandType = CommandType.StoredProcedure;
                      cmd.Parameters.AddWithValue("@UserID", cbo.CustomerID);
                      cmd.Parameters.AddWithValue("@MaritalStatus", cbo.MaritalStatus);
                      cmd.Parameters.AddWithValue("@NomineeName", cbo.NomineeName);
                      cmd.Parameters.AddWithValue("@NomineeAddress", cbo.NomineeAddress);
                      cmd.ExecuteNonQuery();


                  }



              }

              catch (Exception ex)
              {

              }
    
             
          }
        /// <summary>
        /// check if user login is for first time
        /// added by latika
        /// </summary>
        /// <param name="cbo"></param>
        /// <returns></returns>
          public bool isFirstLogin(ILoginDetailsBO lbo)
          {
              try
              {
                  string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                  using (SqlConnection conn = new SqlConnection(constr))
                  {
                      SqlCommand cmd = new SqlCommand("usp_isFirstLogin", conn);
                      conn.Open();
                      cmd.CommandType = CommandType.StoredProcedure;
                      cmd.Parameters.AddWithValue("@UserID", lbo.userID);

                     int x =Convert.ToInt16(cmd.ExecuteScalar());
                     if (x > 0)
                     {
                         return false;
                     }
                     else
                         return true;

                  }



              }

              catch (Exception ex)
              {
                  return false;
              }

          
          }
         /// <summary>
         /// change user password
         /// added by latika
         /// </summary>
         /// <param name="lbo"></param>
          public bool ChangePassword(ILoginDetailsBO lbo)
          {
              try
              {
                  string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                  using (SqlConnection conn = new SqlConnection(constr))
                  {
                      SqlCommand cmd = new SqlCommand("sp_changePassword1", conn);
                      conn.Open();
                      cmd.CommandType = CommandType.StoredProcedure;
                      cmd.Parameters.AddWithValue("@UserID", lbo.userID);
                      cmd.Parameters.AddWithValue("@OldPassword", lbo.Password);
                      cmd.Parameters.AddWithValue("@NewPassword", lbo.NewPassword);
                      SqlParameter p = cmd.Parameters.Add("@Status",SqlDbType.Int);
                      p.Direction = ParameterDirection.Output;
                      cmd.ExecuteNonQuery();
                      if (Convert.ToInt16(p.Value) == 1)
                      {
                          return true;
                      }
                      else
                      {
                          return false;
                      }

                     

                  }



              }

              catch (Exception ex)
              {
                  return false;
              }

          
          }

        /// <summary>
        /// method to set secret question
        /// added by latika
        /// </summary>
        /// <param name="lbo"></param>
          public void SetSecretQuestion(ILoginDetailsBO lbo)
          {
              try
              {
                  string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                  using (SqlConnection conn = new SqlConnection(constr))
                  {
                      SqlCommand cmd = new SqlCommand("usp_SetSecretQuestion", conn);
                      conn.Open();
                      cmd.CommandType = CommandType.StoredProcedure;
                      cmd.Parameters.AddWithValue("@UserID", lbo.userID);
                      cmd.Parameters.AddWithValue("@SecretQuestion", lbo.SecretQuestion);
                      cmd.Parameters.AddWithValue("@Answer", lbo.Answer);
                     
                      cmd.ExecuteNonQuery();

                  }

              }

              catch (Exception ex)
              {
               
              }

          }
        /// <summary>
        /// forgot password
        /// added by latika
        /// </summary>
        /// <param name="lbo"></param>
          public void ForgotPassword(ILoginDetailsBO lbo)
          {

              try
              {
                  string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                  using (SqlConnection conn = new SqlConnection(constr))
                  {
                      SqlCommand cmd = new SqlCommand("usp_ForgotPassword", conn);
                      conn.Open();
                      cmd.CommandType = CommandType.StoredProcedure;
                      cmd.Parameters.AddWithValue("@UserID", lbo.userID);
                      cmd.Parameters.AddWithValue("@Answer", lbo.Answer);
                      cmd.Parameters.AddWithValue("@NewPassword", lbo.NewPassword);
                      cmd.ExecuteNonQuery();

                  }

              }

              catch (Exception ex)
              {

              }


          }

          public List<ICheckbookBO> ViewCheckBookRequest(ICheckbookBO cbo)
          {
              List<ICheckbookBO> CheckBookList = new List<ICheckbookBO>();
              try
              {
                  string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                  using (SqlConnection conn = new SqlConnection(constr))
                  {
                      SqlCommand cmd = new SqlCommand("sp_ViewCheckBookRequest", conn);
                      conn.Open();
                      cmd.CommandType = CommandType.StoredProcedure;
                      cmd.Parameters.AddWithValue("@AccountID", cbo.AccountID);

                      SqlDataReader rdr = cmd.ExecuteReader();

                      if (rdr.HasRows)
                      {
                          while (rdr.Read())
                          {
                              ICheckbookBO bo;
                              bo = new CheckbookBO();
                              bo.RequestID = Convert.ToInt32(rdr[0]);
                              bo.AccountID = Convert.ToInt32(rdr[1]);
                              bo.RequestDate = Convert.ToDateTime(rdr[2]);
                              bo.Status = rdr[3].ToString();
                              CheckBookList.Add(bo);

                          }
                      }

                  }

                  return CheckBookList;

              }

              catch (Exception ex)
              {
                  return CheckBookList;
              }
          }
        /// <summary>
        /// method to view transaction details
        /// added by latika
        /// </summary>
        /// <param name="tbo"></param>
          /// <summary>
          /// method to view transaction details
          /// added by latika
          /// </summary>
          /// <param name="tbo"></param>
          public List<ITransactionBO> ViewTransactionDetails(ITransactionBO bo)
          {
              List<ITransactionBO> TransactionList = new List<ITransactionBO>();
              try
              {
                  string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                  using (SqlConnection conn = new SqlConnection(constr))
                  {
                      SqlCommand cmd = new SqlCommand("sp_ViewTransactionDetails", conn);
                      conn.Open();
                      cmd.CommandType = CommandType.StoredProcedure;
                      cmd.Parameters.AddWithValue("@AccountID", bo.AccountID);

                      SqlDataReader rdr = cmd.ExecuteReader();

                      if (rdr.HasRows)
                      {
                          while (rdr.Read())
                          {
                              ITransactionBO tbo = new TransactionBO();
                              tbo.TransactionID = Convert.ToInt32(rdr[0]);
                              tbo.AccountID = Convert.ToInt32(rdr[1]);
                              tbo.StartDate = Convert.ToDateTime(rdr[2]);
                              tbo.Credit = Convert.ToInt32(rdr[3]);
                              tbo.Debit = Convert.ToInt32(rdr[4]);
                              tbo.Balance = Convert.ToInt32(rdr[5]);
                              TransactionList.Add(tbo);

                          }
                      }

                  }

                  return TransactionList;

              }

              catch (Exception ex)
              {
                  return TransactionList;
              }
          }



          public void RequestCheckBook(ICheckbookBO cbo)
          {
              try
              {
                  string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                  using (SqlConnection conn = new SqlConnection(constr))
                  {
                      SqlCommand cmd = new SqlCommand("sp_RequestCheckbook", conn);
                      conn.Open();
                      cmd.CommandType = CommandType.StoredProcedure;
                      cmd.Parameters.AddWithValue("@UserID", cbo.AccountID);
                      cmd.Parameters.AddWithValue("@RequestDate",cbo.RequestDate);
                      cmd.Parameters.AddWithValue("@Status",cbo.Status);
                      cmd.ExecuteNonQuery();

                  }

              }

              catch (Exception ex)
              {

              }
          }


         
        /*------------------------------------------customer enrollment-------------------------------------------------------*/



          public void UpdateRegisteredCustomer(ICustomerDetailsBO ubo)
          {
              try
              {
                  string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                  using (SqlConnection cn = new SqlConnection(constr))
                  {
                      SqlCommand cmd = new SqlCommand("usp_UpdateRegisteredDetails", cn);
                      cmd.CommandType = CommandType.StoredProcedure;
                      cmd.Parameters.AddWithValue("@RegistrationID", ubo.RegistrationID);
                      cmd.Parameters.AddWithValue("@CustomerName", ubo.CustomerName);
                      cmd.Parameters.AddWithValue("@DateOfBirth", ubo.DateOfBirth);
                      cmd.Parameters.AddWithValue("@FatherName", ubo.FatherName);
                      cmd.Parameters.AddWithValue("@Gender", ubo.Gender);
                      cmd.Parameters.AddWithValue("@MaritalStatus", ubo.MaritalStatus);
                      cmd.Parameters.AddWithValue("@ContactDetails", ubo.ContactDetails);
                      cmd.Parameters.AddWithValue("@CommunicationAddress", ubo.CommunicationAddress);
                      cmd.Parameters.AddWithValue("@NomineeName", ubo.NomineeName);
                      cmd.Parameters.AddWithValue("@NomineeAddress", ubo.NomineeAddress);
                     
                      cn.Open();
                      cmd.ExecuteNonQuery();
                      cn.Close();
                  }
              }
              catch (Exception ex)
              {

              }
          }

          public void UpdateApproveStatusBO(ICustomerDetailsBO cbo)
          {
              try
              {
                  string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                  using (SqlConnection conn = new SqlConnection(constr))
                  {

                      SqlCommand cmd = new SqlCommand("usp_UpdateApproveStatusBO", conn);
                      cmd.CommandType = CommandType.StoredProcedure;


                      cmd.Parameters.AddWithValue("@RegistrationID", cbo.RegistrationID);
                      cmd.Parameters.AddWithValue("@CustomerID", cbo.CustomerID);
                      cmd.Parameters.AddWithValue("@BOApprovalDate", cbo.BOApprovalDate);
                      conn.Open();

                      cmd.ExecuteNonQuery();
                      conn.Close();


                  }
              }
              catch (Exception ex)
              {

              }




          }



          /// <summary>
          /// view customer details by sales representative 
          ///pankaj
          /// </summary>
          /// <param name="icbo"></param>
          /// <returns></returns>
          public List<ICustomerDetailsBO> ShowCustomerInfoRequest(ICustomerDetailsBO cbo)
          {

              List<ICustomerDetailsBO> LST = new List<ICustomerDetailsBO>();
              try
              {
                  string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                  using (SqlConnection conn = new SqlConnection(constr))
                  {
                      SqlCommand cmd = new SqlCommand("sp_EditListCustDetail", conn);
                      cmd.CommandType = CommandType.StoredProcedure;
                      conn.Open();
                      cmd.Parameters.AddWithValue("@CustomerRequestDate", cbo.CustomerRegistrationDate);


                      SqlDataReader rdr = cmd.ExecuteReader();


                      while (rdr.Read())
                      {
                          ICustomerDetailsBO icbo = new CustomerDetailsBO();

                          icbo.CustomerName = rdr[0].ToString();
                          icbo.DateOfBirth = Convert.ToDateTime(rdr[1].ToString());
                          icbo.FatherName = rdr[2].ToString();
                          icbo.Gender = rdr[3].ToString();
                          icbo.MaritalStatus = rdr[4].ToString();
                          icbo.CommunicationAddress = rdr[5].ToString();
                          icbo.ContactDetails =Convert.ToInt64(rdr[6]);
                          icbo.NomineeName = rdr[7].ToString();
                          icbo.NomineeAddress = rdr[8].ToString();
                          icbo.IDProofDocument = rdr[9].ToString();
                          icbo.IDProofStatus = rdr[10].ToString();
                          icbo.AddressProofDocument = rdr[11].ToString();
                          icbo.AddressProofStatus = rdr[12].ToString();
                          icbo.RegistrationID = Convert.ToInt32(rdr[13]);
                          LST.Add(icbo);
                      }
                      return LST;

                  }
              }
              catch (Exception ex)
              {
                  return LST;
              }
          }




        /// <summary>
        /// customer registration by sales representative
        /// addded by pankaj
        /// </summary>
        /// <param name="ubo"></param>
        public bool RegisterCustomer(ICustomerDetailsBO ubo)
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection cn = new SqlConnection(constr))
                {
                    SqlCommand cmd = new SqlCommand("usp_InsertCustomer", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CustomerName", ubo.CustomerName);
                    cmd.Parameters.AddWithValue("@DateOfBirth", ubo.DateOfBirth);
                    cmd.Parameters.AddWithValue("@FatherName", ubo.FatherName);
                    cmd.Parameters.AddWithValue("@Gender", ubo.Gender);
                    cmd.Parameters.AddWithValue("@MaritalStatus",ubo.MaritalStatus);
                    cmd.Parameters.AddWithValue("@ContactDetails", ubo.ContactDetails);
                    cmd.Parameters.AddWithValue("@CommunicationAddress", ubo.CommunicationAddress);
                    cmd.Parameters.AddWithValue("@NomineeName", ubo.NomineeName);
                    cmd.Parameters.AddWithValue("@NomineeAddress", ubo.NomineeAddress);
                    cmd.Parameters.AddWithValue("@IDProofDocument", ubo.IDProofDocument);
                    cmd.Parameters.AddWithValue("@AddressProofDocument ", ubo.AddressProofDocument);
                    cmd.Parameters.AddWithValue("@DateOfRegistration", DateTime.Now);
                    cn.Open();
                    int i=cmd.ExecuteNonQuery();
                    cn.Close();
                    if (i == 1)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// view customer registration request
        /// added by pankaj
        /// </summary>
        /// <param name="icbo"></param>
        /// <returns></returns>
        public List<ICustomerDetailsBO> ViewCustomerRegistrationRequest(ICustomerDetailsBO cbo)
        {

            List<ICustomerDetailsBO> LST = new List<ICustomerDetailsBO>();
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    SqlCommand cmd = new SqlCommand("viewRegCustomerDetails", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    cmd.Parameters.AddWithValue("@CustomerRequestDate", cbo.CustomerRegistrationDate);

                    SqlDataReader rdr = cmd.ExecuteReader();


                    while (rdr.Read())
                    {
                        ICustomerDetailsBO icbo;
                        icbo = new CustomerDetailsBO();
                       
                        icbo.CustomerName = rdr[0].ToString();
                        icbo.DateOfBirth = Convert.ToDateTime(rdr[1].ToString());
                        icbo.Gender = rdr[2].ToString();
                        icbo.CommunicationAddress = rdr[3].ToString();
                        
                        icbo.NomineeName = rdr[4].ToString();
                        icbo.NomineeAddress = rdr[5].ToString();
                        icbo.IDProofStatus = rdr[6].ToString();
                        icbo.AddressProofStatus = rdr[7].ToString();
                        LST.Add(icbo);


                    }
                    return LST;

                }
            }
            catch (Exception ex)
            {
                return LST;
            }

        }


        /// <summary>
        /// add customer to bank by bank officer
        /// Added By Sutrishna
        /// </summary>
        /// <param name="cbo"></param>
        /// <returns></returns>

        public List<ICustomerDetailsBO> AddCustomerToBank(ICustomerDetailsBO cbo)
        {

            List<ICustomerDetailsBO> LST = new List<ICustomerDetailsBO>();
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    SqlCommand cmd = new SqlCommand("usp_AddCustomers", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();




                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {

                            ICustomerDetailsBO icbo = new CustomerDetailsBO();
                            icbo.RegistrationID = Convert.ToInt16(rdr[0].ToString());
                            icbo.CustomerName = rdr[1].ToString();
                            icbo.DateOfBirth = Convert.ToDateTime(rdr[2].ToString());

                            icbo.Gender = rdr[3].ToString();

                            icbo.CommunicationAddress = rdr[4].ToString();


                            icbo.NomineeName = rdr[5].ToString();
                            icbo.NomineeAddress = rdr[6].ToString();
                            icbo.IDProofStatus = rdr[7].ToString();
                            icbo.AddressProofStatus = rdr[8].ToString();
                            icbo.ContactDetails =Convert.ToInt64(rdr[9]);

                            LST.Add(icbo);



                        }
                    }


                }
                return LST;

            }

            catch (Exception ex)
            {
                return LST;
            }

        }

        /// <summary>
        /// view customer details by sales representative 
        /// added by sutrishna
        /// </summary>
        /// <param name="icbo"></param>
        /// <returns></returns>
        public List<ICustomerDetailsBO> ShowCustomerDetails(ICustomerDetailsBO icbo)  //method calling to view EditCustomerDetails in Gridview
        {

            List<ICustomerDetailsBO> LST = new List<ICustomerDetailsBO>();
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    SqlCommand cmd = new SqlCommand("sp_EditListCustDetails", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@CustomerRequestDate", icbo.currentDate);


                    SqlDataReader rdr = cmd.ExecuteReader();


                    while (rdr.Read())
                    {


                        icbo.CustomerName = rdr[0].ToString();
                        icbo.DateOfBirth = Convert.ToDateTime(rdr[1].ToString());
                        icbo.FatherName = rdr[2].ToString();
                        icbo.Gender = rdr[3].ToString();
                        icbo.MaritalStatus = rdr[4].ToString();
                        icbo.CommunicationAddress = rdr[5].ToString();
                        icbo.ContactDetails =Convert.ToInt32(rdr[6]);
                        icbo.NomineeName = rdr[7].ToString();
                        icbo.NomineeAddress = rdr[8].ToString();
                        icbo.IDProofDocument = rdr[9].ToString();
                        icbo.IDProofStatus = rdr[10].ToString();
                        icbo.AddressProofDocument = rdr[11].ToString();
                        icbo.AddressProofStatus = rdr[12].ToString();
                        LST.Add(icbo);
                    }
                    return LST;

                }
            }
            catch (Exception ex)
            {
                return LST;
            }
        }
        /// <summary>
        /// method to edit customer details by sales representative
        /// added by sutrishna
        /// </summary>
        /// <param name="icbo"></param>
        /// <returns></returns>
        public List<ICustomerDetailsBO> EditCustomerDetails(ICustomerDetailsBO icbo)  //method calling to edit on EditcustomerDetails Gridview
        {

            List<ICustomerDetailsBO> LST = new List<ICustomerDetailsBO>();
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    SqlCommand cmd = new SqlCommand("sp_UpdateList", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@CustomerName", icbo.CustomerName);
                    cmd.Parameters.AddWithValue("@DateOfBirth", icbo.DateOfBirth);
                    cmd.Parameters.AddWithValue("@FatherName", icbo.FatherName);
                    cmd.Parameters.AddWithValue("@Gender", icbo.Gender);
                    cmd.Parameters.AddWithValue("@MaritalStatus", icbo.MaritalStatus);
                    cmd.Parameters.AddWithValue("@ContactDetails", icbo.ContactDetails);
                    cmd.Parameters.AddWithValue("@CommunicationAddress", icbo.CommunicationAddress);
                    cmd.Parameters.AddWithValue("@NomineeName", icbo.NomineeName);
                    cmd.Parameters.AddWithValue("@NomineeAddress", icbo.NomineeAddress);
                    cmd.Parameters.AddWithValue("@IDProofStatus", icbo.IDProofStatus);
                    cmd.Parameters.AddWithValue("@AddressProofStatus", icbo.AddressProofStatus);
                    cmd.Parameters.AddWithValue("@IDProofDocument", icbo.AddressProofStatus);
                    cmd.Parameters.AddWithValue("@AddressProofDocument ", icbo.AddressProofStatus);


                    return LST;

                }
            }
            catch (Exception ex)
            {
                return LST;
            }
        }


        public void ShowCustomerInfoDetails(ICustomerDetailsBO cbo)  //for dispaly in text box
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["constr1"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    SqlCommand cmd = new SqlCommand("sp_showCustomerInfoDetails", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            ICustomerDetailsBO icbo = new CustomerDetailsBO();

                            icbo.CustomerName = rdr[0].ToString();
                            icbo.DateOfBirth = Convert.ToDateTime(rdr[1].ToString());
                            icbo.FatherName = rdr[2].ToString();
                            icbo.Gender = rdr[3].ToString();
                            icbo.MaritalStatus = rdr[4].ToString();
                            icbo.CommunicationAddress = rdr[5].ToString();
                            icbo.ContactDetails = Convert.ToInt64(rdr[6]);
                            icbo.NomineeName = rdr[7].ToString();
                            icbo.NomineeAddress = rdr[8].ToString();
                            icbo.IDProofDocument = rdr[9].ToString();
                            icbo.IDProofStatus = rdr[10].ToString();
                            icbo.AddressProofDocument = rdr[11].ToString();
                            icbo.AddressProofStatus = rdr[12].ToString();

                        }
                    }


                }
            }

            catch (Exception ex)
            {

            }
        }


/*------------------------------------------validations and verifications----------------------------------------------------------*/

        
        /// <summary>
        /// Branch Managers page to perform approve or reject operation,it will open on page load 
        /// added by poonam and kushal
        /// </summary>
        /// <param name="cbo"></param>
        /// <returns></returns>
        public List<ICustomerDetailsBO> ApproveCustomer(ICustomerDetailsBO cbo)
        {
            List<ICustomerDetailsBO> LST = new List<ICustomerDetailsBO>();
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    SqlCommand cmd = new SqlCommand("sp_selectDetails", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();



                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        ICustomerDetailsBO icbo;
                        icbo = new CustomerDetailsBO();

                        icbo.RegistrationID = Convert.ToInt16(rdr[0].ToString());
                        icbo.CustomerName = rdr[1].ToString();
                        icbo.DateOfBirth = Convert.ToDateTime(rdr[2].ToString());
                        icbo.Gender = rdr[3].ToString();
                        icbo.CommunicationAddress = rdr[4].ToString();
                        icbo.NomineeName = rdr[5].ToString();
                        icbo.NomineeAddress = rdr[6].ToString();
                        icbo.IDProofStatus = rdr[7].ToString();
                        icbo.AddressProofStatus = rdr[8].ToString();
                        LST.Add(icbo);
                    }
                    return LST;
                }
            }
            catch (Exception ex)
            {
                return LST;
            }
        }

        /// <summary>
        /// Branch Managers page to perform approve or reject operation,it will open on page load 
        /// added by poonam and kushal
        /// </summary>
        /// <param name="cbo"></param>
        /// <returns></returns>
        public List<ICustomerDetailsBO> ShowCustomerDetailsBM(ICustomerDetailsBO cbo)
        {
            List<ICustomerDetailsBO> LST = new List<ICustomerDetailsBO>();
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    SqlCommand cmd = new SqlCommand("sp_selectDetails", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();



                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        ICustomerDetailsBO icbo;
                        icbo = new CustomerDetailsBO();

                        icbo.RegistrationID = Convert.ToInt16(rdr[0].ToString());
                        icbo.CustomerName = rdr[1].ToString();
                        icbo.DateOfBirth = Convert.ToDateTime(rdr[2].ToString());
                        icbo.Gender = rdr[3].ToString();
                        icbo.CommunicationAddress = rdr[4].ToString();
                        icbo.NomineeName = rdr[5].ToString();
                        icbo.NomineeAddress = rdr[6].ToString();
                        icbo.IDProofStatus = rdr[7].ToString();
                        icbo.AddressProofStatus = rdr[8].ToString();
                        LST.Add(icbo);
                    }
                    return LST;
                }
            }
            catch (Exception ex)
            {
                return LST;
            }
        }

        /// <summary>
        /// 19 March :It will reject the details of the customer and delete entry from grid and database
        ///  added by poonam and kushal
        ///  </summary>
        /// <param name="cbo"></param>
        /// <returns></returns>
        public bool RejectCustomer(ICustomerDetailsBO cbo)
        {

            try
            {
                string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(constr))
                {

                    SqlCommand cmd = new SqlCommand("sp_deleteDetails", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    cmd.Parameters.AddWithValue("@id", cbo.RegistrationID);

                    int result = cmd.ExecuteNonQuery();
                    return true;

                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 19 March :It will update the status to approved in database
        /// added by poonam and kushal
        /// </summary>
        /// <param name="cbo"></param>
        /// <returns></returns>
        public bool UpdateRegistrationStatus(ICustomerDetailsBO cbo)
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(constr))
                {

                    SqlCommand cmd = new SqlCommand("usp_UpdateStatus", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Balance", cbo.Balance);
                    cmd.Parameters.AddWithValue("@AccountCreationDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@DefaultPassword", cbo.DefaultPassword);
                    cmd.Parameters.AddWithValue("@id", cbo.RegistrationID);
                    
                    conn.Open();

                    

                    int result = cmd.ExecuteNonQuery();
                    if (result >0)
                    {
                        return true;
                    }
                    else
                        return false;

                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //Branch Managers page will display details of customer in grid on the basis of date selected from calendar
        /// <summary>
        /// added by poonam and kushal
        /// </summary>
        /// <param name="icbo"></param>
        /// <returns></returns>
        public List<ICustomerDetailsBO> ViewAccountDetailsByDate(ICustomerDetailsBO cbo)
        {
            List<ICustomerDetailsBO> lstView = new List<ICustomerDetailsBO>();
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    SqlCommand cmd = new SqlCommand("sp_selectDetailsByDate", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@currentDate", cbo.AccountCreationDate);
                    conn.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        ICustomerDetailsBO icbo;
                        icbo = new CustomerDetailsBO();
                        icbo.RegistrationID = Convert.ToInt16(rdr[0].ToString());
                        icbo.CustomerName = rdr[1].ToString();
                        icbo.DateOfBirth = Convert.ToDateTime(rdr[2].ToString());
                        icbo.Gender = rdr[3].ToString();
                        icbo.currentDate = Convert.ToDateTime(rdr[4].ToString());
                        icbo.CommunicationAddress = rdr[5].ToString();
                        icbo.AccountType = rdr[6].ToString();
                        icbo.Balance = Convert.ToInt16(rdr[7].ToString());
                        lstView.Add(icbo);

                    }

                    return lstView;
                }
            }
            catch (Exception ex)
            {
                return lstView;
            }
        }



        /// <summary>
        /// Branch Managers page will display all the details of customer in grid
        /// added by poonam and kushal
        /// </summary>
        /// <param name="icbo"></param>
        /// <returns></returns>
        public List<ICustomerDetailsBO> ViewAllAccountDetails(ICustomerDetailsBO icbo)
        {
            List<ICustomerDetailsBO> lstViewAll = new List<ICustomerDetailsBO>();
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    SqlCommand cmd = new SqlCommand("sp_selectDetailsAll", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();



                    while (rdr.Read())
                    {
                        ICustomerDetailsBO cbo;
                        cbo = new CustomerDetailsBO();
                        cbo.RegistrationID = Convert.ToInt16(rdr[0].ToString());
                        cbo.CustomerName = rdr[1].ToString();
                        cbo.DateOfBirth = Convert.ToDateTime(rdr[2].ToString());
                        cbo.Gender = rdr[3].ToString();
                        cbo.currentDate = Convert.ToDateTime(rdr[4].ToString());// account opening date
                        cbo.CommunicationAddress = rdr[5].ToString();
                        cbo.AccountType = rdr[6].ToString();
                        cbo.Balance = Convert.ToInt16(rdr[7].ToString());

                        lstViewAll.Add(cbo);

                    }

                    return lstViewAll;
                }
            }
            catch (Exception ex)
            {
                return lstViewAll;
            }
        }

        /// <summary>
        /// Branch Managers page will be redirected to this page and details of customers will be displayed in textboxes based on the selected row of customer approval
        /// added by poonam and kushal
        /// </summary>
        /// <param name="icbo"></param>
        /// <returns></returns>
        public bool GenerateAccountAccessDetails(ICustomerDetailsBO icbo)
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    SqlCommand cmd = new SqlCommand("usp_GenerateDefaultPassword", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", icbo.RegistrationID);
                    conn.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            icbo.CustomerName = rdr[0].ToString();
                            icbo.DateOfBirth = Convert.ToDateTime(rdr[1].ToString());
                            icbo.FatherName = rdr[2].ToString();
                            icbo.Gender = rdr[3].ToString();
                            icbo.MaritalStatus = rdr[4].ToString();
                            icbo.NomineeName = rdr[5].ToString();
                            icbo.NomineeAddress = rdr[6].ToString();
                            icbo.ContactDetails = Convert.ToInt64(rdr[7]);

                           
                        }
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddVisitor(IVisitorBO vbo)
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(constr))
                {

                    SqlCommand cmd = new SqlCommand("usp_AddVisitor", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@VisitorName", vbo.VisitorName);
                    cmd.Parameters.AddWithValue("@ContactNo", vbo.ContactNo);
                    cmd.Parameters.AddWithValue("@Email", vbo.VisitorEmail);
                    
                    
                    conn.Open();

                    

                    int result = cmd.ExecuteNonQuery();
                    if(result==1)
                    {
                    return true;
                        }
                    else
                        return false;

                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        }
        
    }

