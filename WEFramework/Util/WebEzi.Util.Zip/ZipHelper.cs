using System;
using System.IO;
using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip;

namespace WebEzi.Util.Zip
{
    public class ZipHelper
    {
        #region Create Zip

        public static void CreateZip(string sourceFilePath, string destinationZipFilePath)
        {
            if (sourceFilePath[sourceFilePath.Length - 1] != System.IO.Path.DirectorySeparatorChar)
                sourceFilePath += System.IO.Path.DirectorySeparatorChar;

            var zipStream = new ZipOutputStream(File.Create(destinationZipFilePath));
            zipStream.SetLevel(6);
            CreateZipFiles(sourceFilePath, zipStream, sourceFilePath);

            zipStream.Finish();
            zipStream.Close();
        }
        public static void CreateZip(string sourceFilePath, string destinationZipFilePath, int level)
        {
            if (sourceFilePath[sourceFilePath.Length - 1] != System.IO.Path.DirectorySeparatorChar)
                sourceFilePath += System.IO.Path.DirectorySeparatorChar;

            var zipStream = new ZipOutputStream(File.Create(destinationZipFilePath));
            zipStream.SetLevel(level);
            CreateZipFiles(sourceFilePath, zipStream, sourceFilePath);

            zipStream.Finish();
            zipStream.Close();
        }

        private static void CreateZipFiles(string sourceFilePath, ZipOutputStream zipStream, string staticFile)
        {
            Crc32 crc = new Crc32();
            string[] filesArray = Directory.GetFileSystemEntries(sourceFilePath);
            foreach (string file in filesArray)
            {
                if (Directory.Exists(file))
                {
                    CreateZipFiles(file, zipStream, staticFile);
                }
                else
                {
                    var fileStream = File.OpenRead(file);

                    byte[] buffer = new byte[fileStream.Length];
                    fileStream.Read(buffer, 0, buffer.Length);
                    string tempFile = file.Substring(staticFile.LastIndexOf("\\") + 1);
                    var entry = new ZipEntry(tempFile);

                    entry.DateTime = DateTime.Now;
                    entry.Size = fileStream.Length;
                    fileStream.Close();
                    crc.Reset();
                    crc.Update(buffer);
                    entry.Crc = crc.Value;
                    zipStream.PutNextEntry(entry);

                    zipStream.Write(buffer, 0, buffer.Length);
                }
            }
        }

        #endregion

        public static void UnZip(string targetZipFile, string unZipFolder, string password)
        {
            if (!File.Exists(targetZipFile))
            {
                throw new Exception("Zip file not found." + targetZipFile);
            }

            if (!Directory.Exists(unZipFolder))
            {
                Directory.CreateDirectory(unZipFolder);
            }

            ZipEntry zipEntry;
            string fileName;
            try
            {
                using (var zipStream = new ZipInputStream(File.OpenRead(targetZipFile)))
                {
                    zipStream.Password = password;
                    while ((zipEntry = zipStream.GetNextEntry()) != null)
                    {
                        if (zipEntry.Name != String.Empty)
                        {
                            fileName = Path.Combine(unZipFolder, zipEntry.Name);

                            // Check whether is folder
                            if (fileName.EndsWith("/") || fileName.EndsWith("\\"))
                            {
                                Directory.CreateDirectory(fileName);
                                continue;
                            }

                            using (var streamWriter = File.Create(fileName))
                            {
                                int size;
                                byte[] data = new byte[2048];
                                while (true)
                                {
                                    size = zipStream.Read(data, 0, data.Length);
                                    if (size > 0)
                                    {
                                        streamWriter.Write(data, 0, size);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            finally
            {
                zipEntry = null;
                GC.Collect();
                GC.Collect(1);
            }
        }
    }
}
