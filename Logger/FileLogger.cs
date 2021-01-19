using System;
using System.Collections.Generic;
using System.Text;
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
            StreamWriter appendMessage;
            try
            {
                appendMessage = new StreamWriter(FilePath);
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException(FilePath);
            }

            string dateTime = DateTime.Now.ToString("yyyy-MM-dd_HH:mm");
            appendMessage.WriteLine("Date/time: " + dateTime);
            appendMessage.WriteLine(ClassName);
            appendMessage.WriteLine(logLevel);
            appendMessage.WriteLine(message);
            appendMessage.Dispose();
        }
    }
}