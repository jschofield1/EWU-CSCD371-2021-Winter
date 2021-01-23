using System;
using System.IO;

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        private string? filePath;
        public string FilePath
        {
            get => filePath!;
            set => filePath = value ?? throw new ArgumentNullException(null);
        }

        public FileLogger(string filePath)
        {
            FilePath = filePath;
        }

        public override void Log(LogLevel logLevel, string message)
        {
            if (FilePath == null || !File.Exists(FilePath))
                throw new FileNotFoundException("FilePath is null or does not exist");
            
            TextWriter appendMessage = new StreamWriter(FilePath);

            string dateTime = DateTime.Now.ToString("yyyy-MM-dd/HH:mm:ss");

            appendMessage.WriteLine("Date/time: " + dateTime);
            appendMessage.WriteLine(base.ClassName);
            appendMessage.WriteLine(logLevel);
            appendMessage.WriteLine(message);
            appendMessage.Close();
        }
    }
}
