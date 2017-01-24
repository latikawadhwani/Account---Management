using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contracts;
using BO;
using BLL;
using FactoryPatternBO;
using FactoryPatternBLL;
namespace AccountOpening_Team1
{
    public partial class SetSecretQuestion : System.Web.UI.Page
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
            string UserID = Session["UserID"].ToString();
            ILoginDetailsBO lbo;
            lbo = LoginBOFactory.CreateInstance();
            lbo.userID = UserID;
            lbo.SecretQuestion = ddlSelectSecretQuestion.SelectedItem.Text;
            lbo.Answer = txtAnswer.Text;
            IAccountBLL bll;
            bll = BLLFactory.CreateInstance();
            bll.SetSecretQuestion(lbo);
            Response.Redirect("ChangePassword.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}