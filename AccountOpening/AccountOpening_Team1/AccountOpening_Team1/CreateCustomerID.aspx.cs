using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BO;
using BLL;
using Contracts;
using FactoryPatternBLL;
using FactoryPatternBO;

namespace AccountOpening_Team1
{
    public partial class CreateCustomerID : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MultiView m1 = (MultiView)this.Master.FindControl("mlt1");
            m1.ActiveViewIndex = 4;
            if (Session["userID"] == null)
            {
                Response.Redirect("index.aspx");
            }
            if (!IsPostBack)
            {
                ICustomerDetailsBO cbo;
                cbo = CustomerBOFactory.CreateInstance();
                //For BO //String By Default,so converting to DateTime


                IAccountBLL bll;
                bll = BLLFactory.CreateInstance();
                List<ICustomerDetailsBO> result = bll.AddCustomerToBank(cbo); //function call from BLL of List Type
                grdAddCustomer.DataSource = result;
                grdAddCustomer.DataBind();
            }

        }

        protected void grdAddCustomer_RowCommandMethod(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AddCustomer")
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                GridView grid = (GridView)e.CommandSource;
              
                GridViewRow row = grid.Rows[index];
                int id = Convert.ToInt16(row.Cells[1].Text);

                ICustomerDetailsBO cbo;
                cbo = CustomerBOFactory.CreateInstance();

                cbo.RegistrationID = id;
                cbo.CustomerID = "abc_" + id;
                cbo.BOApprovalDate = DateTime.Now;//get date from syatem

                IAccountBLL bll;
                bll = BLLFactory.CreateInstance();
                bll.UpdateApproveStatusBO(cbo);


                List<ICustomerDetailsBO> result = bll.AddCustomerToBank(cbo);
                grdAddCustomer.DataSource = result;
                grdAddCustomer.DataBind();





            }


        }


    }
}