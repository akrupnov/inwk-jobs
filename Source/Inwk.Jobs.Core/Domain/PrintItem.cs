using System;

namespace Inwk.Jobs.Core.Domain
{
    /// <summary>
    /// Print item for the job
    /// </summary>
    public class PrintItem
    {
        /// <summary>
        /// Item name
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// Cost of the printing
        /// </summary>
        public Decimal Cost { get; set; }
        /// <summary>
        /// Jobs taxation
        /// </summary>
        public TaxationType Taxation { get; set; }
    }
}