using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BO;
using BLL;
using Contracts;
using FactoryPatternBO;
using FactoryPatternBLL;


namespace AccountOpening_Team1
{
    public partial class index : System.Web.UI.Page
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {
            MultiView m1 = (MultiView)this.Master.FindControl("mlt1");
            m1.ActiveViewIndex = 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                ILoginDetailsBO lbo;
                lbo = LoginBOFactory.CreateInstance();
                lbo.userID = txtUser.Text;
                lbo.Password = txtPassword.Text;

                IAccountBLL bll;
                bll = BLLFactory.CreateInstance();
                bool result = bll.Login(lbo);
                Session["userID"] = lbo.userID;
                string userRole = lbo.Role;
                Session["userRole"] = lbo.Role;//create session to sore user role
                if (result == true)
                {
                    //check for first login
                    bool isFirstLogin = bll.IsFirstLogin(lbo);
                    if (isFirstLogin == true)
                    {
                        
                        Response.Redirect("SetSecretQuestion.aspx");
                    }

                    else
                    {

                       
                        lbo.loginDate = System.DateTime.Today.ToLongDateString();
                        lbo.loginTime = System.DateTime.Now.ToShortTimeString();
                        lbo.loginIP = Request.UserHostAddress.ToString();
                        bll.AddLoginDetails(lbo);
                        if (userRole == "CUST")
                        {
                            Response.Redirect("ViewPersonalDetails.aspx");
                        }
                        else if (userRole == "SR")
                        {
                            Response.Redirect("CustomerRegistration.aspx");
                        }
                        else if (userRole == "BM")
                        {
                            Response.Redirect("ApproveRequest.aspx");
                        }
                        else if (userRole == "BO")
                        {
                            Response.Redirect("CreateCustomerID.aspx");
                        }

                        
                    }
                        

                   
                    
                }
                else
                {
               
                    lblMessage.Text = "Invalid user ID or password";
                  
                }


            }
            catch (Exception ex)
            {
            }
        }
    }
}