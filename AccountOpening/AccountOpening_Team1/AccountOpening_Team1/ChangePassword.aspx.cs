using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contracts;
using BO;
using BLL;
using FactoryPatternBLL;
using FactoryPatternBO;
namespace AccountOpening_Team1
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        string UserID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userID"] == null)
            {
                Response.Redirect("index.aspx");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
             UserID=HttpContext.Current.Session["UserID"].ToString();
            ILoginDetailsBO lbo;
            lbo=LoginBOFactory.CreateInstance();
            lbo.userID=UserID;
            lbo.Password=txtOldPassword.Text;
            lbo.NewPassword = txtNewPassword.Text;
            IAccountBLL bll;
            bll=BLLFactory.CreateInstance();
           bool result= bll.ChangePassword(lbo);
          
           if (result == true)
           {
               
               lbo.loginDate = System.DateTime.Today.ToLongDateString();
               lbo.loginTime = System.DateTime.Now.ToShortTimeString();
               lbo.loginIP = Request.UserHostAddress.ToString();
               bll.AddLoginDetails(lbo);
               
               Response.Write("<script language='javascript'>alert('Password changed successfully');</script>");
               Response.Redirect("index.aspx");
           }
           else
           {

           }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            string userRole = Session["userRole"].ToString();
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
}