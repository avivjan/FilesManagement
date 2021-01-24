using System;
using System.Collections.Generic;
using System.Text;

namespace FileManagement.Common
{
    public class DownloadData
    {
        public string targetLocalPath { get; set; }

        public string fileToDownloadRemotePath { get; set; }

        public string nameOfDownloadedFileLocally { get; set; }

    }
}
