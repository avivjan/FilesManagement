using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FileManagement.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilesManagementWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileServicesController : ControllerBase
    {
        private readonly IFileServices service;
        public FileServicesController()
        {
            service = new FileManagement.BL.FilesService();
        }

        [HttpPost]
        public async Task UploadFileAsync(string fileToUploadPath)
        {
            await service.UploadFileAsync(fileToUploadPath, null, CancellationToken.None);
        }

        [HttpDelete]
        public async Task DeleteFileAsync([FromBody] string fileToDeletePath)
        {
            await service.DeleteFileAsync(fileToDeletePath, null, CancellationToken.None);
        }
    }
}
}
}
