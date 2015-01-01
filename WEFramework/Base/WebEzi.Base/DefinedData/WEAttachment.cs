using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebEzi.Base.DefinedData
{
    public class WEAttachment
    {
        #region Properties

        /// <summary>
        /// The attachment file
        /// </summary>
        public WEFile File { get; set; }

        /// <summary>
        /// Expect file name, don't need to include the extension name
        /// </summary>
        public string ExpectName { get; set; }

        #endregion
    }
}
