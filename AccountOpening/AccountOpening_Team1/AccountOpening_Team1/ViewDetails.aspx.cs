using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contracts;
using FactoryPatternBO;
using FactoryPatternBLL;
using BO;
using BLL;

namespace AccountOpening_Team1
{
    public partial class ViewDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userID"] == null)
            {
                Response.Redirect("index.aspx");
            }
            MultiView m1 = (MultiView)this.Master.FindControl("mlt1");
            m1.ActiveViewIndex = 3;
            multBMDetails.ActiveViewIndex = -1;

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            multBMDetails.ActiveViewIndex = 1;

            ICustomerDetailsBO cbo;
            cbo = CustomerBOFactory.CreateInstance();
            cbo.AccountCreationDate = Convert.ToDateTime(txtDate.Text);
            IAccountBLL bll;
            bll = BLLFactory.CreateInstance();
            List<ICustomerDetailsBO> result = bll.ViewAccountDetailsByDate(cbo);
            grdViewDetails.DataSource = result;
            grdViewDetails.DataBind();

        }

        protected void rdbDateSelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdbDate.SelectedIndex == 0)
            {
                multBMDetails.ActiveViewIndex = 0;
            }
            else
            {

                ICustomerDetailsBO cbo;
                cbo = CustomerBOFactory.CreateInstance();

                IAccountBLL bll;
                bll = BLLFactory.CreateInstance();
                List<ICustomerDetailsBO> result = bll.ViewAllAccountDetails(cbo);
                grdViewDetails.DataSource = result;
                grdViewDetails.DataBind();
                multBMDetails.ActiveViewIndex = 1;

            }
        }



    }
}