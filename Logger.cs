using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCodeTech
{
    public interface ILogger
    {
        void Log(string result);
    }

    public class ConsoleLogger:ILogger
    {
        public void Log(string result)
        {
            Console.WriteLine(result);
        }
    }

    public class FileLogger : ILogger
    {
        private string _path;
        private string _defaultPath = "myDefaultPath";

        //PATH DEFAULTS WHEN NEW PATH IS NOT PASSED TO CONSTRUCTOR
        public FileLogger(string path=null)
        {
            _path = path?? _defaultPath;
        }

        public void Log(string result)
        {
            using (var streamWriter = new StreamWriter(_path, true))
            {
                streamWriter.WriteLine(result);
            }
        }
    }
}
