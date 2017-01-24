using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using Contracts;
using FactoryPatternBLL;
using FactoryPatternBO;
using BO;
using BLL;

namespace AccountOpening_Team1
{
    public partial class GenerateAccountDetails : System.Web.UI.Page
    {
        /// <summary>
        /// it will display the details on this page based on the index selected from the grid in previous page using session.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                int RegsID = Convert.ToInt16(HttpContext.Current.Session["RegID"]);
                
                ICustomerDetailsBO cbo;
                cbo = CustomerBOFactory.CreateInstance();
                cbo.RegistrationID = RegsID;
                IAccountBLL cbll;
                cbll = BLLFactory.CreateInstance();

                cbll.GenerateAccountAccessDetails(cbo);
                txtName.Text = cbo.CustomerName;
                txtDOB.Text = cbo.DateOfBirth.ToShortDateString();
                txtFSName.Text = cbo.FatherName;
                txtGender.Text = cbo.Gender;
                txtMstatus.Text=cbo.MaritalStatus;
                txtContDetails.Text = cbo.ContactDetails.ToString();
                txtNomiName.Text = cbo.NomineeName;
                txtNomiAddress.Text = cbo.NomineeAddress;
              
            }
        }

        /// <summary>
        /// it will  generate random password on button click from BM's Page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGenPwdSub_Click(object sender, EventArgs e)
        {
           string p= GeneratePassword();

            ICustomerDetailsBO cbo;
            cbo = CustomerBOFactory.CreateInstance();

            cbo.RegistrationID = Convert.ToInt16(HttpContext.Current.Session["RegID"]);
            cbo.Balance =Convert.ToInt32(txtInitialAmt.Text);
            cbo.AccountType = txtAcctype.Text;
            cbo.DefaultPassword = p;

            IAccountBLL bll;
            bll = BLLFactory.CreateInstance();
            bool r = bll.UpdateRegistrationStatus(cbo);
            if (r == true)
            {
                Response.Write("<script language='javascript'>alert('Details Updated');</script>");
                Response.Redirect("ApproveRequest.aspx");
            }
            else
            {
                lblMessage.Text = "Error while updating details";
            }

            

        }
        public string GeneratePassword()
        {
            String _allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ23456789";
            Byte[] randomBytes = new Byte[8];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(randomBytes);
            char[] chars = new char[8];
            int allowedCharCount = _allowedChars.Length;

            for (int i = 0; i < 8; i++)
            {

                chars[i] = _allowedChars[(int)randomBytes[i] % allowedCharCount];
            }

            string pass = new string(chars);
            return pass;
          
        }
    }
}