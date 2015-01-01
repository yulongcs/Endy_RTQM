using System;
using System.Configuration;
using System.IO;
using System.Transactions;
using Lgsoft.RTQM.Application.FileModule.DTOs;
using Lgsoft.RTQM.Domain.FileModule.Aggregates.FileAgg;
using Lgsoft.SF.Domain;
using Lgsoft.SF.Infrastructure.CrossCutting.Adapters;
using Lgsoft.SF.Infrastructure.CrossCutting.Logging;

using File = Lgsoft.RTQM.Domain.FileModule.Aggregates.FileAgg.File;

namespace Lgsoft.RTQM.Application.FileModule.Services
{
    public class FileAppService : IFileAppService
    {
        private readonly ITypeAdapter _typeAdapter;
        private readonly IFileRepository _fileRepository;

        public FileAppService(ITypeAdapter typeAdapter, IFileRepository fileRepository)
        {
            _typeAdapter = typeAdapter;
            _fileRepository = fileRepository;
        }

        #region Implementation of IFileAppService

        public FileDTO CreateNewFile(FileDTO fileDTO, Stream fileContent)
        {
            if (fileDTO == null || fileContent == null)
                return null;

            var fileStorage = ConfigurationManager.AppSettings["FileStorage"];
            if (string.IsNullOrWhiteSpace(fileStorage) || !Directory.Exists(fileStorage))
                return null;

            var storageFileName = DateTime.Now.ToString("yyyyMMddHHmmssffff");

            using (var trasaction = new TransactionScope())
            {
                try
                {
                    var file = FileFactory.CreateFile(fileDTO.FileFullName, storageFileName, fileDTO.FileSize);
                    file.Id = IdentityGenerator.NewSequentialGuid();

                    _fileRepository.Add(file);

                    _fileRepository.UnitOfWork.Commit();

                    var storageFileStream = System.IO.File.OpenWrite(Path.Combine(fileStorage, storageFileName));
                    try
                    {
                        fileContent.Position = 0;
                        fileContent.CopyTo(storageFileStream);
                    }
                    finally
                    {
                        storageFileStream.Close();
                    }

                    trasaction.Complete();

                    return _typeAdapter.Adapt<File, FileDTO>(file);
                }
                catch (Exception)
                {
                    _fileRepository.UnitOfWork.RollbackChanges();
                    return null;
                }
            }
        }

        public FileDTO ConfirmNewFile(Guid fileId)
        {
            if (fileId == Guid.Empty)
                return null;

            var file = _fileRepository.Get(fileId);

            if (file == null)
                return null;

            file.SetFileToFixed();

            _fileRepository.UnitOfWork.Commit();

            return _typeAdapter.Adapt<File, FileDTO>(file);
        }

        public FileDTO GetFile(Guid fileId)
        {
            if (fileId == Guid.Empty)
                return null;

            return _typeAdapter.Adapt<File, FileDTO>(_fileRepository.Get(fileId));
        }

        public Stream GetFileContent(Guid fileId)
        {
            if (fileId == Guid.Empty)
            {
                LoggerFactory.CreateLog().LogWarning("无效的文件标识。");
                return null;
            }

            var file = _fileRepository.Get(fileId);

            if (file == null)
                return null;

            var fileStorage = ConfigurationManager.AppSettings["FileStorage"];
            if (string.IsNullOrWhiteSpace(fileStorage) || Directory.Exists(fileStorage))
            {
                LoggerFactory.CreateLog().LogWarning("未指定文件存储位置或位置无效，设置 AppSetting 节中的 FileStorage 为文件存储位置。");
                return null;
            }

            var storageFilePath = Path.Combine(fileStorage, file.StorageFileName);

            if (!System.IO.File.Exists(storageFilePath))
                return null;

            return new FileStream(storageFilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
        }

        #endregion
    }
}
