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
    public partial class ViewPersonalDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userID"] == null)
            {
                Response.Redirect("index.aspx");
            }
            MultiView m1 = (MultiView)this.Master.FindControl("mlt1");
            m1.ActiveViewIndex = 1;
            if (!IsPostBack)
            {
                ICustomerDetailsBO cbo;
                cbo = CustomerBOFactory.CreateInstance();
                cbo.CustomerID = HttpContext.Current.Session["userID"].ToString();
                IAccountBLL bll;
                bll = BLLFactory.CreateInstance();
                bll.ViewPersonalDetails(cbo);
                txtName.Text = cbo.CustomerName;
                txtFSName.Text = cbo.FatherName;
                txtDOB.Text = cbo.DateOfBirth.ToShortDateString();
                txtContDetails.Text = cbo.ContactDetails.ToString();
                txtNomiName.Text = cbo.NomineeName;
                txtNomiAddress.Text = cbo.NomineeAddress;
                txtGender.Text = cbo.Gender;
            } 

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            
            string userID=HttpContext.Current.Session["userID"].ToString();
            ICustomerDetailsBO cbo;
            cbo = CustomerBOFactory.CreateInstance();
            cbo.CustomerID = userID;
            cbo.MaritalStatus = ddlMStatus.SelectedItem.Text;
            cbo.NomineeName = txtNomiName.Text;
            cbo.NomineeAddress = txtNomiAddress.Text;
   
            IAccountBLL bll;
            bll = BLLFactory.CreateInstance();
            bll.EditPersonalDetails(cbo);
            Response.Write("<script language='javascript'>alert('Details Updated successfully');</script>");

        }

        protected void lnkEditNomineeName_Click(object sender, EventArgs e)
        {
            txtNomiName.ReadOnly = false;
        }

        protected void lnkEditNomineeAddress_Click(object sender, EventArgs e)
        {
            txtNomiAddress.ReadOnly = false;
        }

        protected void lnkEditMaritalStatus_Click(object sender, EventArgs e)
        {
            ddlMStatus.Enabled = true;
        }

       

       
    }
}