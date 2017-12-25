using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCBillManagementSystemWebApp.BLL;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Font = iTextSharp.text.Font;

namespace DCBillManagementSystemWebApp.UI
{
    public partial class TypeWiseReportUI : Page
    {
        readonly TypeWiseReportManager _aTypeWiseReportManager = new TypeWiseReportManager();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void showButton_Click(object sender, EventArgs e)
        {
            if (fromDateTextBox.Text != String.Empty && toDateTextBox.Text != String.Empty)
            {
                typeWiseReportGridView.DataSource = _aTypeWiseReportManager.
                GetAllReportByTypeWise(fromDateTextBox.Text, toDateTextBox.Text);
                typeWiseReportGridView.DataBind();
                totalTextBox.ForeColor = System.Drawing.Color.Black;
                totalTextBox.Text = _aTypeWiseReportManager.GetTotalAmount().ToString();
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
                    int columnsCount = typeWiseReportGridView.HeaderRow.Cells.Count;
                    PdfPTable pdfTable = new PdfPTable(columnsCount);
                    pdfTable.PaddingTop = 10f;
                    PdfPCell headerText = new PdfPCell(new Paragraph("Type Wise Report", headerFont1));
                    headerText.Colspan = 4;
                    headerText.HorizontalAlignment = Element.ALIGN_CENTER;
                    headerText.VerticalAlignment = Element.ALIGN_CENTER;
                    pdfTable.AddCell(headerText);

                    PdfPCell pdfPCell;
                    foreach (TableCell headerCell in typeWiseReportGridView.HeaderRow.Cells)
                    {
                        pdfPCell = new PdfPCell(new Phrase(headerCell.Text,headerFont));
                        pdfTable.AddCell(pdfPCell);
                    }

                    foreach (GridViewRow gridViewRow in typeWiseReportGridView.Rows)
                    {
                        foreach (TableCell gridViewCell in gridViewRow.Cells)
                        {

                            PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewCell.Text));
                            pdfTable.AddCell(pdfCell);
                        }

                    }
                    pdfPCell = new PdfPCell(new Phrase(String.Empty));
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
                        "attachment;filename=TypeWiseReport.pdf");
                    Response.Write(pdfDocument);
                    Response.Flush();
                    Response.End();
                }
            }
        }

    }
}