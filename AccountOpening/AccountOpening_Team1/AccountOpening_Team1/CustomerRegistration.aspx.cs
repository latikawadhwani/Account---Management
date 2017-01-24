using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contracts;
using FactoryPatternBO;
using FactoryPatternBLL;
using System.Globalization;


namespace AccountOpening_Team1
{
    public partial class CustomerRegistration : System.Web.UI.Page
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DateTime d;
            if (!DateTime.TryParseExact(txtDob.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.NoCurrentDateDefault, out d))
                d = System.DateTime.Now;

            ICustomerDetailsBO ubo;
            IAccountBLL ubll;
            ubo = CustomerBOFactory.CreateInstance();
            ubo.CustomerName = txtName.Text;


            ubo.DateOfBirth = d;
            ubo.FatherName = txtFatherName.Text;
            ubo.Gender = rdbGender.Text;
            ubo.MaritalStatus = ddlMaritalStatus.Text;
            ubo.CommunicationAddress = txtCommunicationAddress.Text;

            ubo.ContactDetails = Convert.ToInt64(txtContactDetails.Text);
            ubo.NomineeName = txtNomineeName.Text;
            ubo.NomineeAddress = txtNomineeAddress.Text;
           

            string IdProof = StartIdUpLoad();
            ubo.IDProofDocument = IdProof;

            string AddressProof = StartAddressUpLoad();
            ubo.AddressProofDocument = AddressProof;
            ubo.CustomerRegistrationDate = DateTime.Now;






            ubll = BLLFactory.CreateInstance();
          bool result=  ubll.RegisterCustomer(ubo);
          if (result == true)
          {
              Response.Write("<script language='javascript'>alert('Customer details added successfully');</script>");
              Response.Redirect("CustomerRegistration.aspx");
          }
          else
              Response.Write("<script language='javascript'>alert('Error while adding details');</script>");




        }

        protected void btnreset_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtDob.Text = "";
            txtFatherName.Text = "";
            rdbGender.Text = "Male";
            ddlMaritalStatus.Text = "Select";
            txtCommunicationAddress.Text = "";
            txtContactDetails.Text = "";
            txtNomineeName.Text = "";
            txtNomineeAddress.Text = "";
            ddlStatusOfIdProof.Text = "Not Uploaded";
            ddlStatusOfAddressProof.Text = "Not Uploaded";
            lblIdProofMessage.Text = "";
            lblAddProofMessage.Text = "";
            txtName.Focus();

        }





        private string StartIdUpLoad()
        {
            string imgName = fileupload1.FileName;
            string imgPath = "IdProofImage/" + imgName;

            string IdProofPath = "~/" + imgPath;

            int imgSize = fileupload1.PostedFile.ContentLength;

            if (fileupload1.PostedFile != null && fileupload1.PostedFile.FileName != "")
            {

                if (fileupload1.PostedFile.ContentLength > 10240080)
                {
                    ddlStatusOfIdProof.Text = "Not Uploaded";
                    lblIdProofMessage.Text = "Sorry,File is too big";
                }
                else
                {

                    fileupload1.SaveAs(Server.MapPath(imgPath));
                    ddlStatusOfIdProof.Text = "Pending";
                    lblIdProofMessage.Text = "Successfully Uploaded";



                }

            }
            return IdProofPath;
        }

        private string StartAddressUpLoad()
        {
            string imgName = FileUpload2.FileName;
            string imgPath = "AddressProofImage/" + imgName;

            string AddProofPath = "~/" + imgPath;

            int imgSize = FileUpload2.PostedFile.ContentLength;

            if (FileUpload2.PostedFile != null && FileUpload2.PostedFile.FileName != "")
            {

                if (FileUpload2.PostedFile.ContentLength > 10240080)
                {
                    ddlStatusOfAddressProof.Text = "Not Uploaded";
                    lblAddProofMessage.Text = "Sorry,File is too big";
                }
                else
                {

                    FileUpload2.SaveAs(Server.MapPath(imgPath));
                    ddlStatusOfAddressProof.Text = "Pending";
                    lblAddProofMessage.Text = "Successfully Uploaded";



                }

            }
            return AddProofPath;
        }


    }
}