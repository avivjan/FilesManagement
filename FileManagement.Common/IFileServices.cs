using FilesService.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FileServices.Common
{
    public interface IFileServices
    {
        Task UploadFileAsync(string fileToUploadPath, UserToken user, CancellationToken cancellation);

        Task DeleteFileAsync(string fileToDeletePath, UserToken user, CancellationToken cancellation);
    }
}