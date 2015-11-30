using System;
using System.Collections;
using System.Collections.Generic;
using Inwk.Jobs.Core.Domain;

namespace Inwk.Jobs.Core.Input
{
    /// <summary>
    /// Reads jobs from a fo;e
    /// </summary>
    public interface IJobReader
    {
        /// <summary>
        /// Reads jobs from a file
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        Job Read(String filePath);
    }
}
