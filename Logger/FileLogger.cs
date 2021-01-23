using System;
using System.IO;

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        public string FilePath { get; set; }
        public override string ClassName { get; set; }
        
        public FileLogger(string filePath)
        {
            FilePath = filePath;
            ClassName = "FileLogger";
        }

        public override void Log(LogLevel logLevel, string message)
        {
            if (FilePath == null)
                throw new ArgumentNullException(FilePath);
            
            StreamWriter appendMessage = File.AppendText(FilePath);

            string dateTime = DateTime.Now.ToString("yyyy-MM-dd/hh:mm:ss");
            
            appendMessage.WriteLine("Date/time: " + dateTime);
            appendMessage.WriteLine(ClassName);
            appendMessage.WriteLine(logLevel);
            appendMessage.WriteLine(message);
            appendMessage.Close();
        }
    }
}
