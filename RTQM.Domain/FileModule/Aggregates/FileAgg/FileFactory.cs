using System;
using System.IO;

namespace Lgsoft.RTQM.Domain.FileModule.Aggregates.FileAgg
{
    public static class FileFactory
    {
        public static File CreateFile(string fileFullName, string storageFileName, long fileSize)
        {
            if (string.IsNullOrWhiteSpace(fileFullName))
                throw new ArgumentException("文件名称不能为空。");
            if (string.IsNullOrWhiteSpace(storageFileName))
                throw new ArgumentException("文件的存储名称不能为空。");
            if (fileSize < 0)
                throw new ArgumentException("文件大小不能为负数。");

            var file = new File
                           {
                               FileName = Path.GetFileNameWithoutExtension(fileFullName),
                               FileExtName = Path.GetExtension(fileFullName),
                               FileSize = fileSize,
                               StorageFileName = storageFileName,
                               CreateDate = DateTime.Now,
                               IsTempFile = true,
                           };

            return file;
        }
    }
}
