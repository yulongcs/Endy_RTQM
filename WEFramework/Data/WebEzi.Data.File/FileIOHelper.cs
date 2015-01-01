using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using WebEzi.Base.DefinedData;
using WebEzi.Base.Exception;

namespace WebEzi.Data.File
{
    /// <summary>
    /// WebEzi File Storage Solution（File has been uploaded to the temporary directory specified by the application）
    /// 1、文件拷贝保存
    /// 2、文件删除
    /// 暂不考虑大文件的影响,目录自动创建，未完成异常
    /// </summary>
#pragma warning disable 0628
    internal sealed class FileIOHelper
    {
        //new protected member declared in sealed class
        //this warning is irrelevant here


        bool CheckInvalidPathChars(String inString)
        {
            return true;
        }

        bool CheckInvalidNameChars(String inString)
        {
            return true;
        }
        protected internal static void Create()
        {
            //System.IO.File.Create();
        }
        protected internal static bool Exists(string path)
        {
            return System.IO.File.Exists(path);
        }
        protected internal static string GetExtension(string path)
        {
            return System.IO.Path.GetExtension(path);
        }
        /// <summary>
        /// Deletes the specified file.An exception is not thrown if the specified file does not exist;
        /// </summary>
        /// <param name="filePath">The name of the file to be deleted,Wildcard characters are not supported</param>

        protected internal static void Delete(string filePath)
        {
            try
            {
                FileInfo i = new FileInfo(filePath);
                System.IO.File.Delete(filePath);
            }
            catch(System.Exception ex)
            {
                throw new FileIOException(ex.Message);
            }
        }
        /// <summary>
        /// copyie an existing file to a new file. Overwriting a file of the same name is not allowed.
        /// </summary>
        /// <param name="sourceFileName">the file to copy.</param>
        /// <param name="destFileName">the name of the destination file,this can't be a directroy or an existing file .</param>
        protected internal static void Copy(string sourceFileName, string destFileName)
        {
            System.IO.File.Copy(sourceFileName, destFileName);
        }
        /// <summary>
        /// copyie an existing file to a new file. Overwriting a file of the same name is allowed.
        /// </summary>
        /// <param name="sourceFileName">the file to copy.</param>
        /// <param name="destFileName">the name of the destination file,this can't be a directroy .</param>
        /// <param name="overwrite">true if the destination file can be overwritten; otherwise, false.</param>
        protected internal static void Copy(string sourceFileName, string destFileName, bool overwrite)
        {
            FileInfo i = new FileInfo(destFileName);
            if (!i.Directory.Exists)
                i.Directory.Create();
            System.IO.File.Copy(sourceFileName, destFileName, overwrite);

        }

        FileStream FormerOpen;
        FileStream ToFileOpen;
        /// <summary>
        /// Copy File
        /// </summary>
        /// <param FormerFile="string">源文件路径</param>
        /// <param toFile="string">目的文件路径</param> 
        /// <param SectSize="int">传输大小</param> 
        /// <param progressBar="ProgressBar">ProgressBar控件</param> 
        public void CopyFile(string FormerFile, string toFile, int SectSize)
        {
            FileStream fileToCreate = new FileStream(toFile, FileMode.Create);		//创建目的文件，如果已存在将被覆盖
            fileToCreate.Close();										//关闭所有资源
            fileToCreate.Dispose();										//释放所有资源
            FormerOpen = new FileStream(FormerFile, FileMode.Open, FileAccess.Read);//以只读方式打开源文件
            ToFileOpen = new FileStream(toFile, FileMode.Append, FileAccess.Write);	//以写方式打开目的文件
            //根据一次传输的大小，计算传输的个数
            int FileSize;												//要拷贝的文件的大小
            //如果分段拷贝，即每次拷贝内容小于文件总长度
            if (SectSize < FormerOpen.Length)
            {
                byte[] buffer = new byte[SectSize];							//根据传输的大小，定义一个字节数组
                int copied = 0;										//记录传输的大小
                while (copied <= ((int)FormerOpen.Length - SectSize))			//拷贝主体部分
                {
                    FileSize = FormerOpen.Read(buffer, 0, SectSize);			//从0开始读，每次最大读SectSize
                    FormerOpen.Flush();								//清空缓存
                    ToFileOpen.Write(buffer, 0, SectSize);					//向目的文件写入字节
                    ToFileOpen.Flush();									//清空缓存
                    ToFileOpen.Position = FormerOpen.Position;				//使源文件和目的文件流的位置相同
                    copied += FileSize;									//记录已拷贝的大小
                }
                int left = (int)FormerOpen.Length - copied;						//获取剩余大小
                FileSize = FormerOpen.Read(buffer, 0, left);					//读取剩余的字节
                FormerOpen.Flush();									//清空缓存
                ToFileOpen.Write(buffer, 0, left);							//写入剩余的部分
                ToFileOpen.Flush();									//清空缓存
            }
            //如果整体拷贝，即每次拷贝内容大于文件总长度
            else
            {
                byte[] buffer = new byte[FormerOpen.Length];				//获取文件的大小
                FormerOpen.Read(buffer, 0, (int)FormerOpen.Length);			//读取源文件的字节
                FormerOpen.Flush();									//清空缓存
                ToFileOpen.Write(buffer, 0, (int)FormerOpen.Length);			//写放字节
                ToFileOpen.Flush();									//清空缓存
            }
            FormerOpen.Close();										//释放所有资源
            ToFileOpen.Close();										//释放所有资源
            //文件复制完成
        }        
        
        /// <summary>
        /// Get File Size For Show
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        protected internal static string FormatFileSize(long size)
        {
            string FileSize = "";
            #region Format File Size
            if (size != 0)
            {
                //B(Byte)字节,KB(KiloByte)千字节,MB(MegaByte)兆字节,GB(GigaByte)吉字节,TB(TeraByte)太字节,PB(PetaByte)拍字节,EB(ExaByte)艾字节,ZB(ZetaByte)皆字节,YB(YottaByte)佑字节,NB(NonaByte)诺字节,DB(DoggaByte)刀字节
                if (size >= 1099511627776)
                {
                    FileSize = System.Math.Round(Convert.ToDouble((double)size / (double)1073741824), 2).ToString() + "TB";
                }
                if (size >= 1073741824)
                {
                    FileSize = System.Math.Round(Convert.ToDouble((double)size / (double)1073741824), 2).ToString() + "GB";
                }
                else if (size >= 1048576)
                {
                    FileSize = System.Math.Round(Convert.ToDouble((double)size / (double)1048576), 2).ToString() + "MB";
                }
                else if (size >= 1024)
                {
                    FileSize = System.Math.Round(Convert.ToDouble((double)size / (double)1024), 2).ToString() + "KB";
                }
                else
                {
                    FileSize = size.ToString() + "bytes";
                }
            }
            else { FileSize = size.ToString() + "bytes"; }
            #endregion Format File Size
            return FileSize;
        }

        /// <summary>
        /// Note that while this code attempts to display a list of all invalid
        /// characters in paths and filenames, not all of the characters are
        /// within the displayable set of characters. Because the list of invalid
        /// characters can vary, based on the system, output for this code can vary.
        /// </summary>
        /// <param name="dirPath"></param>
        /// <returns></returns>
        protected internal static bool CheckStorageDirectory(string dirPath)
        {
            if (!string.IsNullOrEmpty(dirPath) && dirPath.IndexOfAny(Path.GetInvalidPathChars()) >= 0) return false;
            return true;
        }
        /// <summary>
        /// Note that while this code attempts to display a list of all invalid
        /// characters in paths and filenames, not all of the characters are
        /// within the displayable set of characters. Because the list of invalid
        /// characters can vary, based on the system, output for this code can vary.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        protected internal static bool CheckStorageName(string fileName)
        {
            char[] InvalidCharsBase = new char[] { '\\', '/', ':', '*', '?', '"', '<', '>', '|' };
            InvalidCharsBase.Union(Path.GetInvalidFileNameChars());
            if (string.IsNullOrEmpty(fileName) || fileName.IndexOfAny(InvalidCharsBase) >= 0) return false;
            return true;
        }
    }
}
