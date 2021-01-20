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
                FileLogger fileLogger = new FileLogger(FilePath!);
                logger = fileLogger;
            }
            
            if (logger == null)
                throw new NullReferenceException("BaseLogger is null");

            return logger;
        }

        public void ConfigureFileLogger(string filePath)
        {
            FilePath = filePath;
        }

        private static string GetFilePath()
        {
            if (!File.Exists("testFile.txt"))
                throw new FileNotFoundException("testFile.txt not found");
         
            string testFile = "testFile.txt";
            return testFile;
        }
    }
}
