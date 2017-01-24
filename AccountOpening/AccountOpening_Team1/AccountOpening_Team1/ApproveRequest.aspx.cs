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

    public partial class ApproveRequest : System.Web.UI.Page
    {
        // it will bind data with grid and will display on branch managers page
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userID"] == null)
            {
                Response.Redirect("index.aspx");
            }
            MultiView m1 = (MultiView)this.Master.FindControl("mlt1");
            m1.ActiveViewIndex = 3;
            if (!IsPostBack)
            {
                ICustomerDetailsBO cbo;
                cbo = CustomerBOFactory.CreateInstance();

                IAccountBLL bll;
                bll = BLLFactory.CreateInstance();

                List<ICustomerDetailsBO> result = bll.ShowCustomerDetailsBM(cbo);
                
                if (result.Count == 0)
                {
                    lblMessage.Text = "No data found";
                }
                else
                {
                    lblMessage.Text = "";
                }
                grdApproveRequest.DataSource = result;
                grdApproveRequest.DataBind();
            }
        }
        /// <summary>
        /// it will select the row index from the approval row of customer from grid and will redirect to next page else it will reject the request, delete that entry from grid and redirect to same page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdApproveRequest_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ApproveCust")
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                GridView grid = (GridView)e.CommandSource;
               
                GridViewRow row = grid.Rows[index];
                int id = Convert.ToInt16(row.Cells[2].Text);
                Session["RegID"] = id;

                
                Response.Redirect("GenerateAccountDetails.aspx");
            }

            if (e.CommandName == "RejectCust")
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                GridView grid = (GridView)e.CommandSource;
               
                GridViewRow row = grid.Rows[index];
                int id = Convert.ToInt16(row.Cells[2].Text);
                ICustomerDetailsBO cbo;
                cbo = CustomerBOFactory.CreateInstance();

                cbo.RegistrationID = id;

                IAccountBLL bll;
                bll = BLLFactory.CreateInstance();
                bool r = bll.RejectCustomer(cbo);


                List<ICustomerDetailsBO> result = bll.ShowCustomerDetailsBM(cbo);
                grdApproveRequest.DataSource = result;
                grdApproveRequest.DataBind();
            }
        }
    }
}