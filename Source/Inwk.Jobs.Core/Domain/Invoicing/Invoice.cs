using System;
using System.Collections;
using System.Collections.Generic;

namespace Inwk.Jobs.Core.Domain.Invoicing
{
    /// <summary>
    /// Represents customer invoice
    /// </summary>
    public class Invoice
    {
        /// <summary>
        /// Date of invoice issuing
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Simplified customer contact
        /// </summary>
        public String Customer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IList<LineItem> Items { get; set; }

        /// <summary>
        /// Pre-calculated invoice total
        /// </summary>
        public Decimal TotalAmount { get; set; }
    }
}
