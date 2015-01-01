using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.IO;
using WebEzi.Base.DefinedData;
using WebEzi.Base.Exception;


namespace WebEzi.Data.File
{

    /// <summary>
    /// Only provide storage for your files, save, copy, delete，download, etc;
    /// Do not include the following: increased file content changes, the contents of the file,Can provide some independent operations in other Projects, such as: WordHelper,ExcelHelper,ZipHelper,TxtHelp,HtmlHelper,XMLHelper,etc;
    /// Not considering the impact of large files 
    /// Not provide log 
    /// </summary>
    public class WEFileStorage : WebEzi.Data.File.IWEFileStorage
    {
        private enum StorageMode
        {
            None,
            Override,
            /// <summary>
            /// Using this value, you cannot use the default method for storage 
            /// </summary>
            Specified
        }

        private static readonly string defaultStorageSpecifiedDirectory = "_defaultstorage"; 

        #region  Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="storageSpecifiedPartitionValue"></param>
        public WEFileStorage(string storageSpecifiedPartitionValue)
        {
            SetStorageSpecifiedPartitionValue(storageSpecifiedPartitionValue);
            _autoDirectory = true;
            _storageAutoDirectory = DateTime.Now.ToString("yyyy-MM");
        }
        #endregion Constructors

        #region Properties

        //private 
        private const long _speedDefault = 10485760;
        private StorageMode _modeStorage = StorageMode.None;
        private bool _autoDirectory;
        private string _storageName;
        private string _storageSpecifiedPartitionValue;
        private string _storageSpecifiedDirectory;
        private string _storageAutoDirectory;
        private string _extension;

        //public
        public WEFile FormerFile { get; set;}
        public bool Exists { get { return FileIOHelper.Exists(StoragePhysicalPath); } }
        /// <summary>
        /// Ext name include the '.'
        /// eg .jpg, .png, .gif
        /// </summary>
        public string Extension
        {
            get
            {
                if (string.IsNullOrEmpty(_extension))
                {
                    if (FormerFile != null)
                        _extension = FormerFile.Extension;
                    else if (!string.IsNullOrEmpty(_storageName) && _storageName.Contains('.'))
                    {
                        _extension = FileIOHelper.GetExtension(_storageName);
                    }
                }
                return _extension;
            }
            set
            {
                _extension = value;
            }
        }
        /// <summary>
        /// Storage Partition Value
        /// </summary>
        public string StoragePartitionValue
        {
            get { return _storageSpecifiedPartitionValue; }
            set
            {
                SetStorageSpecifiedPartitionValue(value);
            }
        }
        /// <summary>
        /// File Storage directory (Based on business) 
        /// </summary>
        public string StorageDirectory
        {
            get { 
                if (string.IsNullOrEmpty(_storageSpecifiedDirectory))
                    _storageSpecifiedDirectory = defaultStorageSpecifiedDirectory; 
                return _storageSpecifiedDirectory; 
            }
            set
            {
                if (!FileIOHelper.CheckStorageDirectory(value))
                {
                    throw new FileIOException("Illegal characters in path. ");
                }
                if (!string.IsNullOrEmpty(value))
                {
                    _storageSpecifiedDirectory = value.Trim('\\');
                }
                else
                {
                    _storageSpecifiedDirectory = defaultStorageSpecifiedDirectory;
                }
            }
        }
        /// <summary>
        /// Whether to automatically add directory
        /// </summary>
        public bool AutoDirectory
        {
            get { return _autoDirectory; }
            set
            {
                if (!value) _storageAutoDirectory = null; _autoDirectory = value;
            }
        }
        /// <summary>
        /// automatically directory
        /// </summary>
        public string StorageAutoPath
        {
            get
            {
                if (_autoDirectory && string.IsNullOrEmpty(_storageAutoDirectory))
                { _storageAutoDirectory = DateTime.Now.ToString("yyyy-MM"); }
                return _storageAutoDirectory;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (!_autoDirectory) _autoDirectory = true;
                    _storageAutoDirectory = value.Trim('\\');
                }
                else
                {
                    if (_autoDirectory) _autoDirectory = false;
                    _storageAutoDirectory = null;
                }
            }
        }

        /// <summary>
        /// File name not include the path
        /// </summary>
        public string StorageName
        {
            get { return _storageName; }
            set
            {
                if (!FileIOHelper.CheckStorageName(value))
                {
                    throw new FileIOException("Illegal characters in file name. ");
                }
                if (!string.IsNullOrEmpty(value))
                {
                    _modeStorage = StorageMode.Specified;
                    _storageName = value.Trim('\\');
                    if (value.Contains('.'))
                    {
                        _extension = FileIOHelper.GetExtension(_storageName);
                    }
                }
                else
                {
                    //auto
                }
            }
        }

        /// <summary>
        /// Physical path(read only)
        /// </summary>
        public string StoragePhysicalPath
        {
            get
            {
                if (string.IsNullOrEmpty(_storageSpecifiedPartitionValue) || string.IsNullOrEmpty(_storageSpecifiedDirectory) || string.IsNullOrEmpty(_storageName))
                {
                    return string.Empty;
                }
                else
                {
                    if (string.IsNullOrEmpty(_storageAutoDirectory))
                    {
                        return Path.Combine(_storageSpecifiedPartitionValue, _storageSpecifiedDirectory, _storageName);
                        //return string.Format("{0}{1}\\{3}", _storageSpecifiedPartitionValue, _storageSpecifiedDirectory, StorageAutoPath, _storageName);  
                    }
                    else
                    {
                        //_storageSpecifiedPartitionValue, _storageSpecifiedDirectory, StorageAutoPath, _storageName
                        return Path.Combine(_storageSpecifiedPartitionValue, _storageSpecifiedDirectory, _storageAutoDirectory, _storageName);
                        //return string.Format("{0}{1}\\{2}\\{3}", _storageSpecifiedPartitionValue, _storageSpecifiedDirectory, StorageAutoPath, _storageName);
                    }
                }
            }
        }

        /// <summary>
        /// File Show Name
        /// </summary>
        public string FileShowName { get; set; }

        #region Used to index [待补充]
        
        /// <summary>
        /// 
        /// </summary>
        public string FileShowSize { get; set; }//private set
        public long FileSize { get; set; }//private set
        /*
        private string _fileHastMD5;
        private string _fileHastSHA1;
        private string _fileHastCRC32;
        public string FileHashMD5 { get { if (string.IsNullOrEmpty(_fileHastMD5))_fileHastMD5 = FileHashHelper.ComputeMD5(StoragePhysicalPath); return _fileHastMD5; }  }
        public string FileHashSHA1 { get { if (string.IsNullOrEmpty(_fileHastSHA1))_fileHastSHA1 = FileHashHelper.ComputeSHA1(StoragePhysicalPath); return _fileHastSHA1; } }
        public string FileHashCRC32 { get { if (string.IsNullOrEmpty(_fileHastCRC32))_fileHastCRC32 = FileHashHelper.ComputeCRC32(StoragePhysicalPath); return _fileHastCRC32; } }
        */

        public DateTime FileCreateDate { 
            get{
                return new FileInfo(StoragePhysicalPath).CreationTime;
            }
            private set { new FileInfo(StoragePhysicalPath).CreationTime = value; }
        }
        #endregion Used to index

        public bool LastState;
        public string LastMessage;
        #endregion Properties

        #region private operations
        /// <summary>
        /// SetStorageSpecifiedPartitionValue
        /// </summary>
        /// <param name="storageSpecifiedPartitionValue"></param>
        private void SetStorageSpecifiedPartitionValue(string storageSpecifiedPartitionValue)
        {
            #region SetStorageSpecifiedPartitionValue
            if (!string.IsNullOrEmpty(storageSpecifiedPartitionValue))
            {
                if (!FileIOHelper.CheckStorageDirectory(storageSpecifiedPartitionValue))
                {
                    throw new FileIOException("Illegal characters in path. ");
                }
                _storageSpecifiedPartitionValue = storageSpecifiedPartitionValue.Trim('\\');
            }
            else
            {
                throw new FileIOException("Invalid storage specified Partition");
            }
            #endregion
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool CheckStorageDriver()
        {
            if (string.IsNullOrEmpty( _storageSpecifiedPartitionValue))
            {
                throw new FileIOException("Not specified file partition mode");
            }

            if (string.IsNullOrEmpty(_storageSpecifiedDirectory))
                _storageSpecifiedDirectory = "_defaultstorage"; 
            return true;
        }

        /// <summary>
        /// Clear Last Status
        /// </summary>
        private void ClearLast()
        {
            if (!this.LastState)
            {
                this.LastState = true;
                this.LastMessage = string.Empty;
            }
        }

        #endregion private operations

        #region Save
        /// <summary>
        /// The default storage method is not allowed to use a custom file name
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            if (_modeStorage.Equals(StorageMode.Specified))
            {
                //remark 
                throw new FileIOException("Not specified file overwrite mode");
            }
            return Save(true);
        }

        /// <summary>
        /// Use custom file name for storage(save,update)
        /// </summary>
        /// <param name="overwrite">false:generate a new file name</param>
        /// <returns></returns>
        public bool Save(bool overwrite)
        {
            ClearLast();
            CheckStorageDriver();
            try
            {
                if (FormerFile == null)
                {
                    this.LastState = false;
                    this.LastMessage = "Don't allow null former file";
                    return false;
                }
                //
                if (string.IsNullOrEmpty(_storageName)||!overwrite)
                {
                    //Guid: "N","D","B","P" 
                    _storageName = string.Format("{0}_{1}{2}", DateTime.Now.ToString("ddHHmmss"), Guid.NewGuid().ToString("N"), FormerFile.Extension); //FormerFile.Extension 与描述不一致，当中含'.'
                }
                //
                
                FileInfo fileInfo = new FileInfo(FormerFile.PhysicalPath);
                FileSize = fileInfo.Length;
                
                FileShowSize = FileIOHelper.FormatFileSize(FileSize);
                //
                FileIOHelper.Copy(FormerFile.PhysicalPath, StoragePhysicalPath, overwrite);
            }
            catch (System.Exception ex)
            {
                LastState = false;
                LastMessage = ex.Message;
            }
            //other
            return true;
        }
        #endregion Save

        #region Delete
        /// <summary>
        /// Deletes the specified file(WEFileStorage).An exception is not thrown if the specified file does not exist;
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            return Delete(false);
        }
        /// <summary>
        /// Deletes the specified file(WEFileStorage or WEFile).An exception is not thrown if the specified file does not exist;
        /// </summary>
        /// <param name="IsTemp">True Is WEFile PhysicalPath</param>
        /// <returns></returns>
        public bool Delete(bool IsTemp)
        {
            ClearLast();
            if (IsTemp)
            {
                return Delete(FormerFile.PhysicalPath);
            }
            else
            {
                CheckStorageDriver();
                return Delete(StoragePhysicalPath);
            }
        }

        /// <summary>
        /// Deletes the specified file(PhysicalPath).An exception is not thrown if the specified file does not exist;
        /// </summary>
        /// <returns></returns>
        public bool Delete(string storagePhysicalPath)
        {
            try
            {
                FileIOHelper.Delete(storagePhysicalPath);
            }
            catch (System.Exception ex)
            {
                LastState = false;
                LastMessage = ex.Message;
            }
            return LastState;
 
        }
        #endregion Delete

        #region Copy
        /// <summary>
        /// create temp file duplication
        /// Copies an existing file to a new file.Overwriting a file of the same name is not allowed
        /// </summary>
        /// <param name="destFileName">the name of the destination file,this can't be a directroy or an existing file .</param>
        /// <returns></returns>
        public bool Copy(string destFileName)
        {
            return Copy(destFileName,false);
        }

        /// <summary>
        /// create temp file duplication
        /// Copies an existing file to a new file.Overwriting a file of the same name is allowed
        /// </summary>
        /// <param name="destFileName">the name of the destination file,this can't be a directroy .</param>
        /// <param name="overwrite">true if the destination file can be overwritten; otherwise, false.</param>
        /// <returns></returns>
        public bool Copy(string destFileName, bool overwrite)
        {
            ClearLast();
            CheckStorageDriver();
            try
            {
                FileIOHelper.Copy(this.StoragePhysicalPath, destFileName, overwrite);
                //?未测试
                FormerFile = new WEFile(StoragePhysicalPath, Path.GetFileName(destFileName));
            }
            catch (System.Exception ex)
            {
                LastState = false;
                LastMessage = ex.Message;
            }
            return LastState;
        }
        #endregion Copy

        #region downLoad file
        public bool DownloadDocument()
        {
            return DownloadDocument(_speedDefault);
        }
        public bool DownloadDocument(long _speed)
        {
            return DownloadDocument( false, _speed);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_speed"></param>
        /// <param name="_delete"></param>
        /// <returns></returns>
        public bool DownloadDocument(long _speed, bool _delete)
        {
            return DownloadDocument(false,_speed, _delete);
        }

        /// <summary>
        /// 从WEFile信息中提取下载信息
        /// </summary>
        /// <param name="_Request"></param>
        /// <param name="_Response"></param>
        /// <param name="_isTemp"></param>
        /// <returns></returns>
        public bool DownloadDocument(bool _isTemp)
        {
            return DownloadDocument(_isTemp, _speedDefault,false);
        }
        public bool DownloadDocument(bool _isTemp, long _speed)
        {
            return DownloadDocument(_isTemp, _speedDefault, false);
        }
        /// <summary>
        /// 从WEFile信息中提取下载信息
        /// </summary>
        /// <param name="_Request"></param>
        /// <param name="_Response"></param>
        /// <param name="_isTemp"></param>
        /// <param name="_speed"></param>
        /// <returns></returns>
        public bool DownloadDocument(bool _isTemp, long _speed,bool _delete)
        {
            if (_isTemp)
            {
                return DownloadDocument(FormerFile.PhysicalPath, FormerFile.FileName, _speed, _delete);
            }
            else
            {
                string _fullPath = this.StoragePhysicalPath;
                string _fileName = string.IsNullOrEmpty(this.FileShowName) ? this.StorageName : this.FileShowName;
                return DownloadDocument(_fullPath, _fileName, _speed, _delete);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_expectFileName">filename without Extension</param>
        /// <returns></returns>
        public bool DownloadDocument(string _expectFileName)
        {
            string _fullPath;
            string _fileName;
            if (FormerFile != null)
            {
                _fullPath = FormerFile.PhysicalPath;
                _fileName = string.Format("{0}{1}", _expectFileName, FormerFile.Extension);
            }
            else
            {
                _fullPath = this.StoragePhysicalPath;
                _fileName = string.Format("{0}{1}", _expectFileName, Extension);
            }

            return DownloadDocument(_fullPath, _fileName, _speedDefault,false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_fileName">File Name 根据需求再对file name 进行调整</param>
        /// <param name="_fullPath">File download path </param>
        /// <param name="_speed">Number of bytes per second allowed to download </param>
        /// <param name="_delete">After a successful download do you want to delete </param>
        /// <returns></returns>
        public bool DownloadDocument(string _fullPath,string _fileName, long _speed,bool _delete)
        {
            if (!FileIOHelper.Exists(_fullPath))
            {
                LastState = false;
                LastMessage = "The file that you want to download does not exist or has been removed.";
                return false;
            }
            System.Web.HttpRequest _Request =  System.Web.HttpContext.Current.Request;
            System.Web.HttpResponse _Response = System.Web.HttpContext.Current.Response;

            /*WebEzi DownloadDocument*/
            //_Response.Clear();
            //_Response.ClearContent();
            //_Response.ClearHeaders();
            /*WebEzi DownloadDocument*/

            if (string.IsNullOrEmpty(_fileName))
            {
                _fileName = new FileInfo(_fullPath).Name;
            }
            if (_speed < 1)
            {
                _speed = _speedDefault;
            }
            try
            {
                FileStream myFile = new FileStream(_fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                BinaryReader br = new BinaryReader(myFile);
                try
                {
                    //_Response.Headers.Add Need to run IIS integrated pipeline 
                    _Response.AppendHeader("Accept-Ranges", "bytes");
                    _Response.Buffer = false;
                    long fileLength = myFile.Length;
                    long startBytes = 0;

                    int pack = 10240;
                    int sleep = (int)Math.Floor((decimal)1000 * pack / _speed) + 1;
                    if (_Request.Headers["Range"] != null)
                    {
                        _Response.StatusCode = 206;
                        string[] range = _Request.Headers["Range"].Split(new char[] { '=', '-' });
                        startBytes = Convert.ToInt64(range[1]);
                    }
                    _Response.AppendHeader("Content-Length", (fileLength - startBytes).ToString());
                    if (startBytes != 0)
                    {
                        _Response.AppendHeader("Content-Range", string.Format(" bytes {0}-{1}/{2}", startBytes, fileLength - 1, fileLength));
                    }
                    //if (isGZip)_Response.AppendHeader("Content-Encoding", "gzip");
                    _Response.AddHeader("Connection", "Keep-Alive");
                    _Response.ContentType = "application/octet-stream";
                    _Response.Charset = "UTF-8";
                    _Response.ContentEncoding = Encoding.UTF8;
                    _Response.AddHeader("Content-Disposition", "attachment;filename=" + System.Web.HttpUtility.UrlEncode(_fileName, Encoding.UTF8));
                    br.BaseStream.Seek(startBytes, SeekOrigin.Begin);
                    int maxCount = (int)Math.Floor((decimal)(fileLength - startBytes) / pack) + 1;

                    for (int i = 0; i < maxCount; i++)
                    {
                        if (_Response.IsClientConnected)
                        {
                            _Response.BinaryWrite(br.ReadBytes(pack));
                            System.Threading.Thread.Sleep(sleep);
                        }
                        else
                        {
                            i = maxCount;
                        }
                    }

                    //_Response.Flush();
                    _Response.End();
                    System.Web.HttpContext.Current.ApplicationInstance.CompleteRequest(); 
                }
                catch(System.Exception ex)
                {
                    Console.Write(ex);
                    return false;
                }
                finally
                {
                    br.Close();
                    myFile.Close();

                    if (_delete)
                    {
                        FileIOHelper.Delete(_fullPath);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return false;
            }
            return true;
        }

        #endregion downLoad file

    }
}
