using System;
using System.IO;
using Lgsoft.RTQM.Application.FileModule.DTOs;

namespace Lgsoft.RTQM.Application.FileModule.Services
{
    /// <summary>
    /// 文件应用服务。
    /// </summary>
    public interface IFileAppService
    {
        /// <summary>
        /// 创建一个新的文件。
        /// </summary>
        /// <param name="fileDTO">文件信息。</param>
        /// <param name="fileContent">文件内容。</param>
        /// <returns>返回新创建的文件信息。</returns>
        /// <remarks>通过该方法创建的新文件还应该使用 ConfirmNewFile 方法来确认创建操作。</remarks>
        FileDTO CreateNewFile(FileDTO fileDTO, Stream fileContent);

        /// <summary>
        /// 确认一个新的文件。
        /// </summary>
        /// <param name="fileId">文件标识。</param>
        FileDTO ConfirmNewFile(Guid fileId);

        /// <summary>
        /// 获取文件信息。
        /// </summary>
        /// <param name="fileId">文件标识。</param>
        /// <returns>返回文件信息。</returns>
        FileDTO GetFile(Guid fileId);

        /// <summary>
        /// 获取文件内容。
        /// </summary>
        /// <param name="fileId">文件标识。</param>
        /// <returns>返回文件内容。</returns>
        Stream GetFileContent(Guid fileId);
    }
}
