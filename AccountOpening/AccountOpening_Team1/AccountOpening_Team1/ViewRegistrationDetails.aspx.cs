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
using System.Globalization;

namespace AccountOpening_Team1
{
    public partial class ViewRegistrationDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userID"] == null)
            {
                Response.Redirect("index.aspx");
            }
            MultiView m1 = (MultiView)this.Master.FindControl("mlt1");
            m1.ActiveViewIndex = 2;


            RangeValidator1.MinimumValue = DateTime.Today.AddYears(-110).ToShortDateString();
            RangeValidator1.MaximumValue = DateTime.Today.ToShortDateString();
            RangeValidator1.ErrorMessage = "The date should be in between " + RangeValidator1.MinimumValue.ToString() + " and " + RangeValidator1.MaximumValue.ToString();
            Page.Validate();
            //Response.Write(Convert.ToString(Page.IsValid)); 
        }
        //pankaj viewCustomer
       

        //pankaj ViewCustomerDetails...
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime d;
                if (!DateTime.TryParseExact(txtrequestdate.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.NoCurrentDateDefault, out d))
                    d =DateTime.Parse(txtrequestdate.Text);
                ICustomerDetailsBO cbo;
                cbo = CustomerBOFactory.CreateInstance();

                cbo.CustomerRegistrationDate = d;


                IAccountBLL bll;
                bll = BLLFactory.CreateInstance();
                List<ICustomerDetailsBO> result = bll.ViewCustomerRegistrationRequest(cbo);
                if (result.Count == 0)
                {
                    lblShowMessage.Text = "                   Data Not Found !!";
                }
                else
                {
                    lblShowMessage.Text = "";
                }
              
                grdviewcustomerdetails.DataSource = result;
                grdviewcustomerdetails.DataBind();

            }
            catch (Exception ex)
            {
            }
        }
    }
}