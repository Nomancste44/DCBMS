using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCBillManagementSystemWebApp.BLL;
using DCBillManagementSystemWebApp.Model.EntityModel;
using DCBillManagementSystemWebApp.Model.ViewModel;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace DCBillManagementSystemWebApp.UI
{
    public partial class TestRequestEntryUI : System.Web.UI.Page
    {
        public int counter = 0;
        public double total = 0;
        List<ViewRequestTestName> totalRequestedTestNames = new List<ViewRequestTestName>();

        readonly TestReuestManager _aTestReuestManager = new TestReuestManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                entryNameDropDownList.DataSource = _aTestReuestManager.BindAllTestName();
                entryNameDropDownList.DataValueField = "Fee";
                entryNameDropDownList.DataTextField = "TestName";
                entryNameDropDownList.DataBind();
                entryNameDropDownList_SelectedIndexChanged(sender, e);
            }


        }

        protected void entryNameDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            feeShowTextBox.Text = entryNameDropDownList.SelectedValue;

        }

        public void ShowTestNamesAtGridVButton_Click(object sender, EventArgs e)
        {
            List<ViewRequestTestName> totalRequestTestNames = new List<ViewRequestTestName>();
            if (ViewState["RequestTests"] != null && ViewState["Counter"] != null && ViewState["Total"] != null)
            {
                totalRequestTestNames = (List<ViewRequestTestName>)ViewState["RequestTests"];
                counter = Convert.ToInt32(ViewState["Counter"]);
                total = Convert.ToDouble(ViewState["Total"]);
            }
            ViewRequestTestName aRequestTestName = new ViewRequestTestName();
            aRequestTestName.Test = entryNameDropDownList.SelectedItem.Text;
            aRequestTestName.Fee = Convert.ToDouble(entryNameDropDownList.SelectedValue);
            aRequestTestName.Sl = ++counter;
            totalRequestTestNames.Add(aRequestTestName);
            requestedTestNameGridView.DataSource = totalRequestTestNames;
            requestedTestNameGridView.DataBind();
            ViewState["RequestTests"] = totalRequestTestNames;
            total += Convert.ToDouble(entryNameDropDownList.SelectedValue);
            totalTextBox.Text = total.ToString(CultureInfo.InvariantCulture);
            ViewState["Counter"] = counter;
            ViewState["Total"] = total;
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            if (ViewState["RequestTests"] != null &&
             patientNameTextBox.Text != String.Empty &&
              mobileNumberTextBox.Text != String.Empty)
            {
                SavePatientContactInfo();
            }
            else
            {
                entrySaveMessageLabel.Text = "No Test Request inserted";
            }

        }

        public void SavePatientContactInfo()
        {
            PatientInfo aPatientInfo = new PatientInfo();
            aPatientInfo.Name = patientNameTextBox.Text;
            aPatientInfo.Birthday = birthdateTextBox.Text;
            aPatientInfo.MobileNumber = mobileNumberTextBox.Text;
            entryAddMessageLabel.Text = (_aTestReuestManager.SavePatientInfo(aPatientInfo));
            if (entryAddMessageLabel.Text.Equals("Saved Sucessfully"))
            {
                SavePatientRequestedTestInfo();
            }
        }

        public void SavePatientRequestedTestInfo()
        {
            totalRequestedTestNames = (List<ViewRequestTestName>)ViewState["RequestTests"];
            entrySaveMessageLabel.Text = _aTestReuestManager.SaveTestsInfo(totalRequestedTestNames,
            _aTestReuestManager.GetPatientId(mobileNumberTextBox.Text));
            if (entrySaveMessageLabel.Text.Equals("Saved Sucessfully"))
            {
                SaveTotalBillAmount();
            }

        }

        public void SaveTotalBillAmount()
        {
            Random aRandom = new Random();
            CustomerBillInformation aBillInformation = new CustomerBillInformation();
            aBillInformation.BillNumber = string.Format("#" + DateTime.Now.ToString() +
             "BILL_{0}", aRandom.Next(100, 10000));
            aBillInformation.BillStatus = "Unpaid";
            aBillInformation.TotalBillAmount = Convert.ToDouble(totalTextBox.Text);
            aBillInformation.DueDate = "GetDate()";
            aBillInformation.CustomerMobileNumber = mobileNumberTextBox.Text;
            entrySaveMessageLabel.Text=_aTestReuestManager.SaveCustomerBillInformation(aBillInformation);
            GeneratePdf();
        }

        public void GeneratePdf()
        {
            string billNumber = _aTestReuestManager.GetBillNumber(mobileNumberTextBox.Text);
            DateTime date = DateTime.Now;
            PdfPTable pdfTable = new PdfPTable(2);

            Font headerFont = FontFactory.GetFont("Arial", 20, Font.BOLD, BaseColor.BLACK);
            pdfTable.PaddingTop = 10f;
            PdfPCell headerText = new PdfPCell(new Paragraph("Lorem Diagnostic Center", headerFont));
            headerText.Colspan = 2;
            headerText.HorizontalAlignment = Element.ALIGN_CENTER;
            headerText.VerticalAlignment = Element.ALIGN_CENTER;
            pdfTable.AddCell(headerText);


            var pdfPCell = new PdfPCell(new Phrase("Bill Number"));
            pdfTable.AddCell(pdfPCell);
            pdfPCell = new PdfPCell(new Phrase("Date : Time"));
            pdfTable.AddCell(pdfPCell);
            pdfPCell = new PdfPCell(new Phrase(billNumber));
            pdfTable.AddCell(pdfPCell);
            pdfPCell = new PdfPCell(new Phrase(date.ToString()));
            pdfTable.AddCell(pdfPCell);
            Document pdfDocument = new Document(PageSize.A4, 15f, 15f, 15f, 15f);
            PdfWriter.GetInstance(pdfDocument, Response.OutputStream);
            pdfDocument.Open();
            pdfDocument.Add(pdfTable);
            pdfDocument.Close();
            Response.ContentType = "application/pdf";
            Response.AppendHeader("content-disposition",
                "attachment;filename=BillNumber.pdf");
            Response.Write(pdfDocument);
            Response.Flush();
            Response.End();
        }

       
    }
}