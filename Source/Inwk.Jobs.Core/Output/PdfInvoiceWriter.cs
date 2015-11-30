using System;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Inwk.Jobs.Core.Domain.Invoicing;

namespace Inwk.Jobs.Core.Output
{
    public class PdfInvoiceWriter : IInvoiceWriter
    {
        public void Write(Invoice invoice, String filePath)
        {
            CreatePdf(invoice, filePath);
        }

        public void CreatePdf(Invoice invoice, string filePath)
        {
            PdfPTable saleTable = SaleTable(invoice);


            FileStream fileStream = new FileStream(filePath,
                                                    FileMode.Create,
                                                    FileAccess.Write,
                                                    FileShare.None);

            Document doc = new Document();
            PdfWriter.GetInstance(doc, fileStream);
            doc.Open();


            Paragraph date = new Paragraph("Date: " + invoice.Date.ToShortDateString()) {Alignment = 2};

            doc.Add(date);

            doc.Add(new Paragraph("Invoice To:"));
            doc.Add(new Paragraph(invoice.Customer));

            Paragraph separator = new Paragraph("_____________________________________________________________________________      ");
            separator.SpacingAfter = 5.5f;
            doc.Add(separator);

            doc.Add(saleTable);
            doc.Close();
        }

        private PdfPTable SaleTable(Invoice invoice)
        {
            var itemList = invoice.Items;

            PdfPTable table = new PdfPTable(3);
            table.TotalWidth = 1000f;
            float[] widths = new float[] { 0.5f, 4f, 1f};
            table.SetWidths(widths);

            table.AddCell(HeaderCell("Item"));
            table.AddCell(HeaderCell("Description"));
            table.AddCell(HeaderCell("Price"));

            foreach (var item in itemList)
            {
                table.AddCell(QuantityCell((itemList.IndexOf(item) + 1).ToString() + "."));
                table.AddCell(item.Name);
                table.AddCell(PriceCell(item.Amount.ToString("C")));
            }




            PdfPCell grandTotal = new PdfPCell(new Phrase(invoice.TotalAmount.ToString("C")))
            {
                Border = Rectangle.TOP_BORDER,
                HorizontalAlignment = 2
            };

            PdfPCell gtText = new PdfPCell(new Phrase("Grand Total:"))
            {
                HorizontalAlignment = 2,
                Colspan = 2,
                Border = Rectangle.TOP_BORDER
            };

            table.AddCell(gtText);
            table.AddCell(grandTotal);


            return table;
        }

        private PdfPHeaderCell HeaderCell(string cellContent)
        {
            PdfPHeaderCell cell = new PdfPHeaderCell
            {
                BackgroundColor = BaseColor.LIGHT_GRAY,
                HorizontalAlignment = 1,
                Phrase = new Phrase(cellContent)
            };
            return cell;
        }

        private PdfPCell PriceCell(string price)
        {
            PdfPCell cell = new PdfPCell
            {
                HorizontalAlignment = 2,
                Phrase = new Phrase(price)
            };

            return cell;
        }

        private PdfPCell QuantityCell(string quantity)
        {
            PdfPCell cell = new PdfPCell
            {
                HorizontalAlignment = 1,
                Phrase = new Phrase(quantity)
            };

            return cell;
        }
    }
}