using System;
using System.Drawing;
using System.IO;
using System.Web;
using WebEzi.Base.DefinedData;

namespace WebEzi.Web.ExtNet
{
    public class UploadFileHelper
    {
        public enum UploadImageMode
        {
            None,
            SpecifiedWidthAndHeight
        }

        #region Properties

        public static string TempDirectoryPath
        {
            get
            {
                string path = "TempFiles\\";
                if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + path))
                {
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + path);
                }

                return path;
            }
        }

        public static string UploadDirectoryPath
        {
            get
            {
                string path = "UploadFiles\\";
                if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + path))
                {
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + path);
                }

                return path;
            }
        }

        #endregion

        /// <summary>
        /// Upload the file to temp directory from front page.
        /// Only for front page.
        /// </summary>
        public static WEFile UploadTempFile(HttpPostedFile postedFile)
        {
            if (postedFile.ContentLength > 0)
            {
                // Upload temp file to temp directory
                var extName = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.') + 1);
                var fileName = Guid.NewGuid() + "." + extName;
                var filePath = AppDomain.CurrentDomain.BaseDirectory + TempDirectoryPath + fileName;
                postedFile.SaveAs(filePath);

                return new WEFile(TempDirectoryPath, fileName);
            }
            else
            {
                throw new  Exception("Don't allow null post file.");
            }
        }

        public static WEFile UploadTempImageFile(HttpPostedFile postedFile, UploadImageMode mode, int width, int hegith)
        {
            if (mode == UploadImageMode.None)
            {
                return UploadTempFile(postedFile);
            }
            else
            {
                using(var originalImage = Image.FromStream(postedFile.InputStream))
                {
                    int x = 0, y = 0;
                    var ow = originalImage.Width;
                    var oh = originalImage.Height;

                    switch (mode)
                    {
                        case  UploadImageMode.SpecifiedWidthAndHeight:
                            break;
                    }

                    // Generate new image
                    using(var bitmap = new Bitmap(width, hegith))
                    {
                        using(var g = Graphics.FromImage(bitmap))
                        {
                            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

                            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                            g.Clear(Color.Transparent);

                            g.DrawImage(originalImage, new Rectangle(0, 0, width, hegith),
                                        new Rectangle(x, y, ow, oh),
                                        GraphicsUnit.Pixel);

                            var fileName = Guid.NewGuid() + Path.GetExtension(postedFile.FileName);
                            var filePath = AppDomain.CurrentDomain.BaseDirectory + TempDirectoryPath + fileName;
                            bitmap.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);

                            return new WEFile(TempDirectoryPath, fileName);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Copy souce file to temp directory
        /// </summary>
        public static WEFile CopyTempFile(WEFile sourceFile)
        {
            var newFileName = Guid.NewGuid() + sourceFile.Extension;
            File.Copy(sourceFile.PhysicalPath, AppDomain.CurrentDomain.BaseDirectory + TempDirectoryPath + newFileName);

            return new WEFile(TempDirectoryPath, newFileName);
        }
        
        /// <summary>
        /// Submit the file, move the temp file to the actual directory.
        /// Only for repository
        /// </summary>
        /// <param name="tempFile">Uploaded temp file from front page</param>
        /// <param name="existFilePath">Exist file on the server</param>
        /// <param name="targetExtPath">Sometimes we put the file in the child directory</param>
        /// <param name="targetFileName">Target file name, never inculde ext name</param>
        public static WEFile SubmitFile(WEFile tempFile, WEFile existFilePath, string targetExtPath, string targetFileName)
        {
            #region Check Data

            if (tempFile == null)
            {
                throw new Exception("Don't allow null temp file");
            }

            if(!tempFile.IsExist)
            {
                throw new Exception("Don't find the temp file with path: " + tempFile.PhysicalPath);
            }

            // If temp file equal to exist file, that means don't need to any file operation.
            // Case: when update a model, front page set the file properties repeat
            if(existFilePath != null && tempFile.PhysicalPath == existFilePath.PhysicalPath)
            {
                return existFilePath;
            }

            #endregion

            var uploadDirectoryPath = UploadDirectoryPath;
            targetExtPath = targetExtPath.Replace('/', '\\');

            // Check the trage path, if not exist, create them
            if(!string.IsNullOrEmpty(targetExtPath))
            {
                var directorys = targetExtPath.Split('\\');
                foreach (var directory in directorys)
                {
                    if (!string.IsNullOrEmpty(directory))
                    {
                        uploadDirectoryPath += directory + "\\";
                        if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + uploadDirectoryPath))
                        {
                            Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + uploadDirectoryPath);
                        }
                    }
                }
            }

            // If already have a file, need to delete first, just only for edit operation
            if(existFilePath != null)
            {
                File.Delete(existFilePath.PhysicalPath);
            }

            // Move file
            var extName = tempFile.Extension;
            var fileName = string.Empty;
            if(string.IsNullOrEmpty(targetFileName))
            {
                fileName = DateTime.Now.ToString("ddMMyyyyHHmmssff") + extName;
            }
            else
            {
                fileName = targetFileName + extName;
            }
            var filePath = uploadDirectoryPath + fileName;

            // If the target file is exising, delete it first. then move
            // Otherwise it will throw exception
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + filePath))
            {
                File.Delete(AppDomain.CurrentDomain.BaseDirectory + filePath);
            }

            // Move file
            File.Move(tempFile.PhysicalPath, AppDomain.CurrentDomain.BaseDirectory + filePath);

            return new WEFile(UploadDirectoryPath, targetExtPath + fileName);
        }

        /// <summary>
        /// Delete a existing file
        /// </summary>
        public static void Delete(WEFile file)
        {
            if (file.IsExist)
            {
                File.Delete(file.PhysicalPath);
            }
        }
    }
}
