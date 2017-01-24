using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contracts;
using FactoryPatternBO;
using FactoryPatternBLL;
namespace AccountOpening_Team1
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            IVisitorBO vbo;
            vbo=VisitorBOFactory.CreateInstance();
            IAccountBLL vbll;
            vbll = BLLFactory.CreateInstance();
            vbo.VisitorName=txtName.Text;
            vbo.ContactNo=txtContact.Text;
            vbo.VisitorEmail=txtEmail.Text;
            bool result = vbll.AddVisitor(vbo);
            if (result == true)
            {
                lblMessage.Text="Request sent";
            }
            
            
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("index.aspx");
        }
    }
}
