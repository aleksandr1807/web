using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebLabs.Services
{
    public class FileLoggerProvider:ILoggerProvider
    {
        private string _filePath;
        public FileLoggerProvider(string path)
        {
            _filePath = path;
        }
        public ILogger CreateLogger(string categoryName)
        {
            return new FileLogger(_filePath);
        }
        public void Dispose()
        {

        }
    }
}
