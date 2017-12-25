using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCBillManagementSystemWebApp.BLL;
using DCBillManagementSystemWebApp.Model.ViewModel;

namespace DCBillManagementSystemWebApp.UI
{
    public partial class PaymentUI : System.Web.UI.Page
    {
        readonly PaymentManager _aPaymentManager = new PaymentManager();
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            ViewPaymentInfo aPaymentInfo = new ViewPaymentInfo();
            if (mobileNumberTextBox.Text != String.Empty || billNumberTextBox.Text != String.Empty)
            {
                string text = billNumberTextBox.Text != String.Empty
                    ? billNumberTextBox.Text:mobileNumberTextBox.Text;

                if (_aPaymentManager.IsThisVaild(text))
                {
                    aPaymentInfo = (billNumberTextBox.Text != String.Empty)
                        ? _aPaymentManager.GetPaymentInfo(billNumberTextBox.Text)
                        : _aPaymentManager.GetPaymentInfo(mobileNumberTextBox.Text);
                    billStatusLabel.Text = aPaymentInfo.BillStatus;
                    amountTextBox.Text = aPaymentInfo.TotalAmount.ToString();
                    dueDateTextBox.Text = aPaymentInfo.DueDate;
                    ViewState["patientId"] = text;

                }
                else
                {
                    billStatusLabel.Text = "Invalid Search";                    
                }
            }

            else
            {
                billStatusLabel.Text = "Please Insert the Bill or Mobile Number";
            }
        }

        protected void payButton_Click(object sender, EventArgs e)
        {
            string patientId = ViewState["patientId"].ToString();
            if (amountTextBox.Text != String.Empty && billStatusLabel.Text.Equals("Unpaid"))
            {
                billStatusLabel.Text = _aPaymentManager.PayBill(patientId);
            }
            else
            {
                billStatusLabel.Text = "Bill Already Paid";
            }
        }
    }
}