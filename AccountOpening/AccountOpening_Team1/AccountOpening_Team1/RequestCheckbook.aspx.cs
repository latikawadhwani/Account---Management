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
    public partial class RequestCheckbook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MultiView m1 = (MultiView)this.Master.FindControl("mlt1");
            m1.ActiveViewIndex = 1;
            ICustomerDetailsBO cbo;
            cbo = CustomerBOFactory.CreateInstance();
            cbo.CustomerID = HttpContext.Current.Session["userID"].ToString();
            IAccountBLL bll;
            bll = BLLFactory.CreateInstance();
            int accID = bll.GetAccountID(cbo);
            txtAccountID.Text = accID.ToString();
        }

        protected void lnkRequest_Click(object sender, EventArgs e)
        {
            ICheckbookBO cbo;
            cbo = CheckbookBOFactory.CreateInstance();
            IAccountBLL bll;
            bll = BLLFactory.CreateInstance();

            // cbo.CustID = HttpContext.Current.Session["userID"].ToString();
            cbo.AccountID = Convert.ToInt32(txtAccountID.Text);
            cbo.RequestDate = System.DateTime.Now;
            cbo.Status = "Pending";
            bll.RequestCheckBook(cbo);
            Response.Write("<script language='javascript'>alert('Request Sent');</script>");


        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }

        protected void lnkViewRequest_Click(object sender, EventArgs e)
        {
            ICheckbookBO cbo;
            cbo = CheckbookBOFactory.CreateInstance();
            IAccountBLL bll;
            bll = BLLFactory.CreateInstance();

            List<ICheckbookBO> result = bll.ViewCheckBookRequest(cbo);
            grdViewCheckBookStatus.DataSource = result;
            grdViewCheckBookStatus.DataBind();
        }
    }
}