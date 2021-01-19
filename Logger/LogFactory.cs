using System;
using System.IO;

namespace Logger
{
    public class LogFactory
    {
        public string? FilePath { get; private set; }
        public string? ClassName { get; set; } = "LogFactory";
        public BaseLogger CreateLogger(string? className)
        {
            BaseLogger? logger = null;
            if (className == nameof(FileLogger))
            {
                ClassName = className;
                string filePath = GetFilePath();
                ConfigureFileLogger(filePath);
#pragma warning disable CS8604 // Possible null reference argument
                FileLogger fileLogger = new FileLogger(FilePath);
#pragma warning restore CS8604 // Possible null reference argument 
                logger = fileLogger;

            }
            if (logger == null)
            {
                throw new NullReferenceException("BaseLogger is null, try again");
            }

            else
            {
                return logger;
            }
        }

        public void ConfigureFileLogger(string filePath)
        {
            FilePath = filePath;
        }

        private static string GetFilePath()
        {
            if (File.Exists("testFile.txt"))
            {
                string file = "testFile.txt";
                return file;
            }
            else
                throw new FileNotFoundException();
        }
    }
}