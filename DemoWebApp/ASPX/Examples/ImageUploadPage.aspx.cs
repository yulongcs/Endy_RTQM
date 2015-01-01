using System;
using System.Collections.Generic;
using System.IO;
using Ext.Net;

namespace DemoWebApp.ASPX.Examples
{
    public partial class ImageUploadPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                ReloadGridView();
            }
        }

        private const string UPLOADPATH = "/Files/UploadImages/";
        public const string THUMB = "_thumb";

        private void ReloadGridView()
        {
            string path = Server.MapPath(UPLOADPATH);
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);

            string[] files = System.IO.Directory.GetFiles(path);

            var data = new List<object>(files.Length);
            foreach (string fileName in files)
            {
                var fi = new FileInfo(fileName);
                if (fi.Name.Contains(THUMB))
                {
                    data.Add(new
                    {
                        name = fi.Name,
                        url = UPLOADPATH + fi.Name,
                        lastmod = fi.LastAccessTime
                    });
                }
            }

            this.Store1.DataSource = data;
            this.Store1.DataBind();

            Store store = this.gp.GetStore();
            store.DataSource = data;
            store.DataBind();
        }

        protected void UploadClick(object sender, DirectEventArgs e)
        {
            string tpl = "Upload file: {0}<br/>";
            if (this.FileUpload.HasFile)
            {
                string path = Server.MapPath(UPLOADPATH);
                try
                {
                    var imagePath = path + photoName.Text + new FileInfo(FileUpload.FileName).Extension;
                    var thumbImagePath = path + photoName.Text + THUMB + new FileInfo(FileUpload.FileName).Extension;
                    FileUpload.PostedFile.SaveAs(imagePath);
                    MakeThumbnail(imagePath, thumbImagePath, 80, 60, "H");
                    X.Msg.Show(new MessageBoxConfig
                    {
                        Buttons = MessageBox.Button.OK,
                        Icon = MessageBox.Icon.INFO,
                        Title = "Success",
                        Message = string.Format(tpl, this.FileUpload.PostedFile.FileName)
                    });

                    BasicForm.Reset();
                    ReloadGridView();
                }
                catch (Exception)
                {
                    X.Msg.Show(new MessageBoxConfig
                    {
                        Buttons = MessageBox.Button.OK,
                        Icon = MessageBox.Icon.ERROR,
                        Title = "Fail",
                        Message = "No file uploaded"
                    });
                }
            }
            else
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Buttons = MessageBox.Button.OK,
                    Icon = MessageBox.Icon.ERROR,
                    Title = "Fail",
                    Message = "No file uploaded"
                });
            }
        }

        protected void btnDelete(object sender, DirectEventArgs e)
        {
            string json = e.ExtraParams["Values"];
            var images = JSON.Deserialize<Dictionary<string, string>[]>(json);

            foreach (Dictionary<string, string> row in images)
            {
                string path = Server.MapPath(UPLOADPATH);
                string filePath = string.Empty;
                string originalFilePath = string.Empty;
                foreach (KeyValuePair<string, string> keyValuePair in row)
                {
                    // key include name and url
                    if (keyValuePair.Key == "name")
                    {
                        filePath = path + keyValuePair.Value;
                        originalFilePath = path + keyValuePair.Value.Replace(THUMB, "");
                    }
                    //else if (keyValuePair.Key == "url")
                    //{
                    //    originalFilePath = keyValuePair.Value.Replace("_thumb", "");
                    //    filePath = keyValuePair.Value;
                    //}
                }
                try
                {
                    File.Delete(filePath);
                    File.Delete(originalFilePath);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            BasicForm.Reset();
            ReloadGridView();
        }

        private static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height, string mode)
        {
            System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);
            int thumbWidth = width;
            int thumbHeight = height;

            int x = 0, y = 0;
            int originalImageWidth = originalImage.Width;
            int originalImageHeight = originalImage.Height;

            switch (mode)
            {
                case "HW": //指定高宽缩放
                    break;
                case "W": //指定宽，高按比例
                    thumbHeight = originalImageHeight * width / originalImageWidth;
                    break;
                case "H": //指定高，宽按比例
                    thumbWidth = originalImageWidth * height / originalImageHeight;
                    break;
                case "Cut": //指定高宽裁剪
                    if ((double)originalImageWidth / (double)originalImageHeight >
                        (double)thumbWidth / (double)thumbHeight)
                    {
                        originalImageHeight = originalImage.Height;
                        originalImageWidth = originalImage.Height * thumbWidth / thumbHeight;
                        y = 0;
                        x = (originalImage.Width - originalImageWidth) / 2;
                    }
                    else
                    {
                        originalImageWidth = originalImage.Width;
                        originalImageHeight = originalImage.Width * height / thumbWidth;
                        x = 0;
                        y = (originalImage.Height - originalImageHeight) / 2;
                    }
                    break;
                default:
                    break;
            }

            //新建一个bmp图片
            System.Drawing.Image bitmap = new System.Drawing.Bitmap(thumbWidth, thumbHeight);

            //新建一个画板
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);

            //设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //清空画布并以透明背景色填充
            g.Clear(System.Drawing.Color.Transparent);

            //在指定位置并且按指定大小绘制原图片的指定部分
            g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, thumbWidth, thumbHeight),
                new System.Drawing.Rectangle(x, y, originalImageWidth, originalImageHeight),
                System.Drawing.GraphicsUnit.Pixel);

            try
            {
                //以jpg格式保存缩略图
                bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }

        }
    }
}