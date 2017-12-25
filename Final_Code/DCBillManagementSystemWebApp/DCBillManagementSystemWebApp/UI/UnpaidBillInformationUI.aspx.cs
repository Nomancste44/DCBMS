using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCBillManagementSystemWebApp.BLL;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace DCBillManagementSystemWebApp.UI
{
    public partial class UnpaidBillInformationUI : System.Web.UI.Page
    {
        readonly UnpaidBillInforManager _aUnpaidBillInforManager = new UnpaidBillInforManager();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void showButton_Click(object sender, EventArgs e)
        {
            if (fromDateTextBox.Text != String.Empty && toDateTextBox.Text != String.Empty)
            {
                unpaidBillInfoGridView.DataSource = _aUnpaidBillInforManager.
                GetAllUnpaidBillInfo(fromDateTextBox.Text, toDateTextBox.Text);
                unpaidBillInfoGridView.DataBind();
                totalTextBox.ForeColor = System.Drawing.Color.Black;
                totalTextBox.Text = _aUnpaidBillInforManager.GetTotalAmount().ToString();
            }
            else
            {
                totalTextBox.ForeColor = System.Drawing.Color.Red;
                totalTextBox.Text = "Please Select Date";
            }
        }

        protected void pdfButton_Click(object sender, EventArgs e)
        {
            if ((totalTextBox.Text != String.Empty) && !totalTextBox.Text.Equals("Please Select Date"))
            {
                if (Convert.ToDouble(totalTextBox.Text) > 0)
                {
                    Font headerFont1 = FontFactory.GetFont("Arial",22, Font.BOLD, BaseColor.BLACK);                    
                    Font headerFont = FontFactory.GetFont("Arial", 11, Font.BOLD, BaseColor.BLACK);
                    Font dataFont = FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK);                    
                    int columnsCount = unpaidBillInfoGridView.HeaderRow.Cells.Count;
                    PdfPTable pdfTable = new PdfPTable(columnsCount);
                    pdfTable.PaddingTop = 10f;
                    PdfPCell headerText = new PdfPCell(new Paragraph("Unpaid Bill Information", headerFont1));
                    headerText.Colspan = 5;
                    headerText.HorizontalAlignment = Element.ALIGN_CENTER;
                    headerText.VerticalAlignment = Element.ALIGN_CENTER;
                    pdfTable.AddCell(headerText);

                    PdfPCell pdfPCell;
                    foreach (TableCell headerCell in unpaidBillInfoGridView.HeaderRow.Cells)
                    {
                        pdfPCell = new PdfPCell(new Phrase(headerCell.Text, headerFont));
                        pdfTable.AddCell(pdfPCell);
                    }

                    foreach (GridViewRow gridViewRow in unpaidBillInfoGridView.Rows)
                    {
                        foreach (TableCell gridViewCell in gridViewRow.Cells)
                        {
                            PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewCell.Text, dataFont));
                            pdfTable.AddCell(pdfCell);
                        }
                    }
                    pdfPCell = new PdfPCell(new Phrase(String.Empty));
                    pdfTable.AddCell(pdfPCell);
                    pdfPCell = new PdfPCell(new Phrase(String.Empty));
                    pdfTable.AddCell(pdfPCell);
                    pdfPCell = new PdfPCell(new Phrase(String.Empty));
                    pdfTable.AddCell(pdfPCell);
                    pdfPCell = new PdfPCell(new Phrase("Total Amount",headerFont));
                    pdfTable.AddCell(pdfPCell);
                    pdfPCell = new PdfPCell(new Phrase(totalTextBox.Text,dataFont));
                    pdfTable.AddCell(pdfPCell);

                    Document pdfDocument = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
                    PdfWriter.GetInstance(pdfDocument, Response.OutputStream);
                    pdfDocument.Open();
                    pdfDocument.Add(pdfTable);
                    pdfDocument.Close();
                    Response.ContentType = "application/pdf";
                    Response.AppendHeader("content-disposition",
                        "attachment;filename=UnpaidBillInformation.pdf");
                    Response.Write(pdfDocument);
                    Response.Flush();
                    Response.End();
                }
            }
        }
    }
}