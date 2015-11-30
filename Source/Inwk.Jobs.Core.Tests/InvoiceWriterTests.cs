using System.Collections.Generic;
using Inwk.Jobs.Core.Commerce;
using Inwk.Jobs.Core.Domain;
using Inwk.Jobs.Core.Output;
using NUnit.Framework;

namespace Inwk.Jobs.Core.Tests
{
    [TestFixture]
    public class InvoiceWriterTests
    {
        [Test]
        public void ItWillCreateInvoice()
        {
            var job = new Job
            {
                Name = "Job 3",
                RequiresExtraMargin = true,
                Items = new List<PrintItem>
                {
                    new PrintItem
                    {
                        Name = "frisbees",
                        Cost = 19385.38m,
                        Taxation = TaxationType.TaxFree
                    },
                    new PrintItem
                    {
                        Name = "yo-yos",
                        Cost = 1829m,
                        Taxation = TaxationType.TaxFree
                    },

                }
            };

            var invoice = new InvoiceCalculator().Calculate(job, "Customer");

            new PdfInvoiceWriter().Write(invoice, "sample.invoice.pdf");
        }
    }
}
