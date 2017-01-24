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
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.IO;
using System.Xml;
using System.Data;
using System.Text;

namespace AccountOpening_Team1
{
    public partial class ViewTransactionDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userID"] == null)
            {
                Response.Redirect("index.aspx");
            }
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            BindMyGrid();
        }
        public void BindMyGrid()
        {
            ITransactionBO tbo;
            tbo = TransactionBOFactory.CreateInstance();
            tbo.AccountID = Convert.ToInt32(txtAccountID.Text);
           
            List<ITransactionBO> TransactionList = new List<ITransactionBO>();

            IAccountBLL bll;
            bll = BLLFactory.CreateInstance();
            TransactionList = bll.ViewTransactionDetails(tbo);
            if (TransactionList.Count == 0)
            {
                lblMessage.Text = "No records found";
            }
            grdTransaction.DataSource = TransactionList;
            grdTransaction.DataBind();
        }

    }
}