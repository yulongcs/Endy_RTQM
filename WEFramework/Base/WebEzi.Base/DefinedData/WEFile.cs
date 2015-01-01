using System;
using System.IO;
using System.Web;

namespace WebEzi.Base.DefinedData
{
    [Serializable]
    public class WEFile
    {
        public WEFile(string specifiedServerPath, string customPath)
        {
            #region Check Rule

            if (string.IsNullOrEmpty(specifiedServerPath))
            {
                throw new System.Exception("Don't allow empty specified server path path.");
            }

            if (string.IsNullOrEmpty(customPath))
            {
                throw new System.Exception("Don't allow empty custom path.");
            }

            #endregion

            this.SpecifiedServerPath = specifiedServerPath;

            // Change all '\\' to '/'
            this.CustomPath = customPath.Replace('\\', '/');

            this.FileName = customPath.Substring(customPath.LastIndexOf('/') + 1);

            this.Extension = System.IO.Path.GetExtension(this.FileName);
        }

        /// <summary>
        /// Specified server path
        /// eg TempFiles/
        /// </summary>
        private string _specifiedServerPath;
        public string SpecifiedServerPath
        {
            get { return _specifiedServerPath; }
            set { _specifiedServerPath = this.AdjustSpecifiedServerPath(value); }
        }

        /// <summary>
        /// Custom path include the file name, it always under the specifired server path
        /// eg Customer/1/
        /// </summary>
        public string CustomPath { get; set; }

        /// <summary>
        /// File name not include the path
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Ext name not include the '.'
        /// eg jpg, png, gif
        /// </summary>
        public string Extension { get; set; }

        /// <summary>
        /// Physical path
        /// </summary>
        public string PhysicalPath
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory + this.SpecifiedServerPath.Replace('/', '\\') +
                       this.CustomPath.Replace('/', '\\');
            }
        }

        /// <summary>
        /// Url
        /// </summary>
        //public string Url
        //{
        //    get
        //    {
        //        return HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority + "/" +
        //               this.SpecifiedServerPath + this.CustomPath;
        //    }
        //}

        /// <summary>
        /// The file whether is exist
        /// </summary>
        public bool IsExist
        {
            get { return File.Exists(this.PhysicalPath); }
        }

        #region Private Methods

        private string AdjustSpecifiedServerPath(string specifiedServerPath)
        {
            // Change all '\\' to '/'
            specifiedServerPath = specifiedServerPath.Replace('\\', '/');
            // If the last char is not '/', add it.
            if (specifiedServerPath.Substring(specifiedServerPath.Length - 1) != "/")
            {
                specifiedServerPath += "/";
            }

            return specifiedServerPath;
        }

        #endregion
    }
}
