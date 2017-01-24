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
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userID"] == null)
            {
                Response.Redirect("index.aspx");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            ILoginDetailsBO lbo;
            lbo = LoginBOFactory.CreateInstance();
            lbo.userID = txtUser.Text;
            lbo.Answer = txtAnswer.Text;
            lbo.NewPassword = txtNewPassword.Text;
            IAccountBLL bll;
            bll = BLLFactory.CreateInstance();
            bll.ForgotPassword(lbo);
            Response.Write("<script language='javascript'>alert('Password changed successfully');</script>");
            Response.Redirect("index.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("index.aspx");
        }
    }
}