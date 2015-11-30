using System;
using System.Collections;
using System.Collections.Generic;

namespace Inwk.Jobs.Core.Domain
{
    /// <summary>
    /// Basic printing job definition
    /// </summary>
    public class Job
    {
        /// <summary>
        /// Name of the job
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// Whether extra margin should be applied
        /// </summary>
        public Boolean RequiresExtraMargin { get; set; }

        /// <summary>
        /// Individual print items for the job
        /// </summary>
        public IList<PrintItem> Items { get; set; }
    }
}
