using System;
using System.IO;
namespace Practica_de_api.Models
{
    public sealed class Logger
    {
        private static Logger instance = null;
        private static readonly object lockObject = new object();
        private readonly string logFilePath;

        private Logger()
        {
            logFilePath = "log.txt";
        }

        public static Logger Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new Logger();
                    }
                    return instance;
                }
            }
        }

        public void Log(string message)
        {
            string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}{Environment.NewLine}";
            File.AppendAllText(logFilePath, logEntry);
        }
    }
}
