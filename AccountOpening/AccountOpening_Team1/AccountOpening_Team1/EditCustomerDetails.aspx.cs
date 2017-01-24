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
    public partial class EditCustomerDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userID"] == null)
            {
                Response.Redirect("index.aspx");
            }
            MultiView m1 = (MultiView)this.Master.FindControl("mlt1");
            m1.ActiveViewIndex = 2;
            mtv1.ActiveViewIndex = 0;
        }






        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            //mtv1.ActiveViewIndex = 1;
            try
            {
                ICustomerDetailsBO cbo;
                cbo = CustomerBOFactory.CreateInstance();
                cbo.CustomerRegistrationDate = DateTime.Parse(txtcalenderreq.Text);//For BO //String By Default,so converting to DateTime


                IAccountBLL bll;
                bll = BLLFactory.CreateInstance();
                List<ICustomerDetailsBO> result = bll.ShowCustomerInfoRequest(cbo); //function call from BLL of List Type
                if (result.Count == 0)
                {
                    lblMessage.Text = "No results found";
                }
                grdeditcustomerdetails.DataSource = result;
                grdeditcustomerdetails.DataBind();

            }
            catch (Exception ex)
            {
            }
        }






        protected void grdeditcustomerdetails_RowEditing(object sender, GridViewEditEventArgs e)
        {

            int index = e.NewEditIndex;
            
            GridViewRow row = (GridViewRow)grdeditcustomerdetails.Rows[index];
            int id = Convert.ToInt16(row.Cells[1].Text);

            ICustomerDetailsBO ubo;
            ubo = CustomerBOFactory.CreateInstance();
            ubo.RegistrationID = id;
            txtName.Text = row.Cells[2].Text;
            txtdob.Text = row.Cells[3].Text;
            txtFatherName.Text = row.Cells[4].Text;
            rdbGender.Text = row.Cells[5].Text;

            if (row.Cells[6].Text == "Married")
            {
                ddlMaritalStatus.SelectedIndex = 1;
            }
            else if (row.Cells[6].Text == "Single")
            {
                ddlMaritalStatus.SelectedIndex = 0;
            }
            else if (row.Cells[6].Text == "Widow")
            {
                ddlMaritalStatus.SelectedIndex = 2;
            }
            else
            {
                ddlMaritalStatus.SelectedIndex = 3;
            }
            txtCommunicationAddress.Text = row.Cells[7].Text;
            txtContactDetails.Text = row.Cells[8].Text;
            txtNomineeName.Text = row.Cells[9].Text;
            txtNomineeAddress.Text = row.Cells[10].Text;
            ddlstatusofidproof.Text = row.Cells[11].Text;
            ddlstatusofaddressproof.Text = row.Cells[12].Text;
            mtv1.ActiveViewIndex = 1;
          
        }

        protected void btnupdatesubmit_Click(object sender, EventArgs e)
        {
            ICustomerDetailsBO ubo;
            IAccountBLL ubll;
            ubo = CustomerBOFactory.CreateInstance();
            ubo.CustomerName = txtName.Text;

            ubo.DateOfBirth = DateTime.Parse(txtdob.Text);

            ubo.FatherName = txtFatherName.Text;
            ubo.Gender = rdbGender.Text;
            ubo.MaritalStatus = ddlMaritalStatus.Text;
            ubo.CommunicationAddress = txtCommunicationAddress.Text;

            ubo.ContactDetails = Convert.ToInt64(txtContactDetails.Text);
            ubo.NomineeName = txtNomineeName.Text;
            ubo.NomineeAddress = txtNomineeAddress.Text;
            ubo.IDProofStatus = ddlstatusofidproof.Text;

            ubo.AddressProofStatus = ddlstatusofaddressproof.Text;
           
            ubll = BLLFactory.CreateInstance();
            ubll.UpdateRegisteredCustomer(ubo);
            List<ICustomerDetailsBO> result = ubll.ShowCustomerInfoRequest(ubo); //function call from BLL of List Type
            grdeditcustomerdetails.DataSource = result;
            grdeditcustomerdetails.DataBind();



        }


    }
}
