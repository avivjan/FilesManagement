using FileManagement.Common;
using FluentFTP;
using System;
using System.Collections.Generic;
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
                await ftp.UploadFileAsync(fileToUploadPath, Path.GetFileName(fileToUploadPath));
            }
        }

        public async Task DeleteFileAsync(string fileToDeletePath, UserToken user, CancellationToken cancellation)
        {
            using (var conn = CreateFTPClient())
            {
                await conn.DeleteFileAsync(fileToDeletePath);
            }
        }

        public async Task DownloadFileAsync(string targetLocalPath, string fileToDownloadRemotePath, string nameOfDownloadedFileLocally, UserToken user, CancellationToken cancellation)
        {
            using (var ftp = CreateFTPClient())
            {
                await ftp.ConnectAsync();
                using (MemoryStream ms = new MemoryStream())
                {
                    await ftp.DownloadAsync(ms, fileToDownloadRemotePath);
                    ms.Position = 0;
                    using (StreamReader sr = new StreamReader(ms))
                    {
                        string fileContent = await sr.ReadToEndAsync();
                        var a = targetLocalPath + $"\\{nameOfDownloadedFileLocally}.txt";
                        using (TextWriter tw = new StreamWriter(a, true))
                        {
                            tw.WriteLine(fileContent);
                        }
                    }
                }
            }
        }

        public async Task UpdateFileAsync(string fileToUpdateRemotePath, string updatedFileLocalPath, UserToken user, CancellationToken cancellation)
        {
            await this.DeleteFileAsync(fileToUpdateRemotePath, user, cancellation);
            await this.UploadFileAsync(updatedFileLocalPath, user, cancellation);
        }

        private static FtpClient CreateFTPClient()
        {
            return new FtpClient("127.0.0.1", "test", "test");
        }
    }
}


