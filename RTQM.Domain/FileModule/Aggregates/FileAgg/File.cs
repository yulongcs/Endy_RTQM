using System;
using Lgsoft.SF.Domain;

namespace Lgsoft.RTQM.Domain.FileModule.Aggregates.FileAgg
{
    /// <summary>
    /// 文件信息。
    /// </summary>
    public class File : Entity
    {
        /// <summary>
        /// 文件名称。
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// 文件扩展名。
        /// </summary>
        public string FileExtName { get; set; }

        /// <summary>
        /// 文件的存储名称。
        /// </summary>
        public string StorageFileName { get; set; }

        /// <summary>
        /// 文件大小。
        /// </summary>
        public long FileSize { get; set; }

        /// <summary>
        /// 是否为临时文件。
        /// </summary>
        public bool IsTempFile { get; internal set; }

        /// <summary>
        /// 文件创建日期。
        /// </summary>
        public DateTime CreateDate { get; internal set; }

        /// <summary>
        /// 将文件状态设置为固定（非临时文件）。
        /// </summary>
        public void SetFileToFixed()
        {
            if (IsTempFile)
                IsTempFile = false;
        }

        public string GetFileName()
        {
            return FileName + FileExtName;
        }
    }
}
