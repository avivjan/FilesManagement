using FileManagement.Common;
using FluentFTP;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace FileManagement.BL
{
    public class FilesService : IFileServices
    {
        public async Task UploadFileAsync(string fileToUploadPath, UserToken user, CancellationToken cancellation)
        {
            using (FtpClient ftp = CreateFTPClient())
            {
                await ftp.ConnectAsync();
                await ftp.UploadFileAsync(fileToUploadPath, Path.GetFileName(fileToUploadPath));
            }
        }

        public async Task DeleteFileAsync(string fileToDeletePath, UserToken user, CancellationToken cancellation)
        {
            using (var conn = CreateFTPClient())
            {
                await conn.ConnectAsync();
                await conn.DeleteFileAsync(fileToDeletePath);
            }
        }
        private static FtpClient CreateFTPClient()
        {
            return new FtpClient("127.0.0.1", "test", "test");
        }
    }
}
