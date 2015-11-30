using System.Collections.Generic;
using System.Linq;
using Inwk.Jobs.Core.Commerce;
using Inwk.Jobs.Core.Domain;
using NUnit.Framework;

namespace Inwk.Jobs.Core.Tests
{
    [TestFixture]
    public class InvoiceCalculatorTest
    {
        [Test]
        public void ItWillCalculateExtraMargin()
        {
            var job = new Job
            {
                Name = "Job 1",
                RequiresExtraMargin = true,
                Items = new List<PrintItem>
                {
                    new PrintItem
                    {
                        Name = "envelopes",
                        Cost = 520.00m,
                        Taxation = TaxationType.Standard
                    },
                    new PrintItem
                    {
                        Name = "letterhead",
                        Cost = 1983.37m,
                        Taxation = TaxationType.TaxFree
                    },

                }
            };

            var invoice = new InvoiceCalculator().Calculate(job, "Customer");

            Assert.IsNotNull("invoice");
            Assert.AreEqual(556.40m, invoice.Items.Single(x => x.Name == "envelopes").Amount);
            Assert.AreEqual(1983.37m, invoice.Items.Single(x => x.Name == "letterhead").Amount);
            Assert.AreEqual(2940.30m, invoice.TotalAmount, "Total amount is incorrect");
        }

        [Test]
        public void ItWillCalculateStandardJob()
        {
            var job = new Job
            {
                Name = "Job 2",
                RequiresExtraMargin = false,
                Items = new List<PrintItem>
                {
                    new PrintItem
                    {
                        Name = "t-shirts",
                        Cost = 294.04m,
                        Taxation = TaxationType.Standard
                    }
                }
            };

            var invoice = new InvoiceCalculator().Calculate(job, "Customer");

            Assert.IsNotNull("invoice");
            Assert.AreEqual(314.62m, invoice.Items.Single(x => x.Name == "t-shirts").Amount);
            Assert.AreEqual(346.96m, invoice.TotalAmount, "Total amount is incorrect");
        }

        [Test]
        public void ItWillCalculateTaxFree()
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

            Assert.IsNotNull("invoice");
            Assert.AreEqual(19385.38m, invoice.Items.Single(x => x.Name == "frisbees").Amount);
            Assert.AreEqual(1829.00m, invoice.Items.Single(x => x.Name == "yo-yos").Amount);
            Assert.AreEqual(24608.68m, invoice.TotalAmount, "Total amount is incorrect");
        }
    }

}
