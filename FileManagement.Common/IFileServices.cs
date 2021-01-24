using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FileManagement.Common
{
    public interface IFileServices
    {
        Task UploadFileAsync(string fileToUploadPath, UserToken user, CancellationToken cancellation);

        Task DeleteFileAsync(string fileToDeletePath, UserToken user, CancellationToken cancellation);

        Task DownloadFileAsync(string targetLocalPath, string fileToDownloadRemotePath, string nameOfDownloadedFileLocally, UserToken user, CancellationToken cancellation);

        Task UpdateFileAsync(string fileToUpdateRemotePath, string updatedFileLocalPath, UserToken user, CancellationToken cancellation);
    }
}