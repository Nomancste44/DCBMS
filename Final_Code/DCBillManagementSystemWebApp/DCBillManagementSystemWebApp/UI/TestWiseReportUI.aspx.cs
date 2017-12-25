using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCBillManagementSystemWebApp.BLL;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace DCBillManagementSystemWebApp.UI
{
    public partial class TestWiseReportUI : Page
    {
        private readonly TestWiseReportManager _aTestWiseReportManager = new TestWiseReportManager();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void showButton_Click(object sender, EventArgs e)
        {
            if (fromDateTextBox.Text != String.Empty && toDateTextBox.Text != String.Empty)
            {
                testWiseReportGridView.DataSource = _aTestWiseReportManager.
                    GetAllReport(fromDateTextBox.Text, toDateTextBox.Text);
                testWiseReportGridView.DataBind();
                totalTextBox.ForeColor = System.Drawing.Color.Black;
                totalTextBox.Text = _aTestWiseReportManager.GetTotalAmount().ToString();
            }
            else
            {
                totalTextBox.Text = "Please select date";
                totalTextBox.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void pdfButton_Click(object sender, EventArgs e)
        {
            if (totalTextBox.Text != String.Empty && !totalTextBox.Text.Equals("Please select date"))
            {
                if (Convert.ToDouble(totalTextBox.Text) > 0)
                {
                    Font headerFont = FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK);
                    Font headerFont1 = FontFactory.GetFont("Arial", 20, Font.BOLD, BaseColor.BLACK);
                    int columnsCount = testWiseReportGridView.HeaderRow.Cells.Count;
                    PdfPTable pdfTable = new PdfPTable(columnsCount);
                    pdfTable.PaddingTop = 10f;
                    PdfPCell headerText = new PdfPCell(new Paragraph("Test Wise Report", headerFont1));
                    headerText.Colspan = 4;
                    headerText.HorizontalAlignment = Element.ALIGN_CENTER;
                    headerText.VerticalAlignment = Element.ALIGN_CENTER;
                    pdfTable.AddCell(headerText);

                    foreach (TableCell gridViewHeaderCell in testWiseReportGridView.HeaderRow.Cells)
                    {
                        Font font = new Font();
                        font.Color = new BaseColor(testWiseReportGridView.HeaderStyle.ForeColor);
                        PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewHeaderCell.Text, font));
                        pdfCell.BackgroundColor = new BaseColor(testWiseReportGridView.HeaderStyle.BackColor);
                        pdfTable.AddCell(pdfCell);
                    }

                    foreach (GridViewRow gridViewRow in testWiseReportGridView.Rows)
                    {
                        foreach (TableCell gridViewCell in gridViewRow.Cells)
                        {
                            Font font = new Font();
                            font.Color = new BaseColor(testWiseReportGridView.RowStyle.ForeColor);

                            PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewCell.Text, font));

                            pdfCell.BackgroundColor = new BaseColor(testWiseReportGridView.RowStyle.BackColor);

                            pdfTable.AddCell(pdfCell);
                        }

                    }
                    var pdfPCell = new PdfPCell(new Phrase(String.Empty));
                    pdfTable.AddCell(pdfPCell);
                    pdfPCell = new PdfPCell(new Phrase(String.Empty));
                    pdfTable.AddCell(pdfPCell);
                    pdfPCell = new PdfPCell(new Phrase("Total Amount", headerFont));
                    pdfTable.AddCell(pdfPCell);
                    pdfPCell = new PdfPCell(new Phrase(totalTextBox.Text));
                    pdfTable.AddCell(pdfPCell);

                    Document pdfDocument = new Document(PageSize.A4, 10f, 10f, 10f, 10f);

                    PdfWriter.GetInstance(pdfDocument, Response.OutputStream);

                    pdfDocument.Open();
                    pdfDocument.Add(pdfTable);
                    pdfDocument.Close();

                    Response.ContentType = "application/pdf";
                    Response.AppendHeader("content-disposition",
                        "attachment;filename=TestWiseReport.pdf");
                    Response.Write(pdfDocument);
                    Response.Flush();
                    Response.End();
                }
            }
        }

    }
}
