using System.Collections.Generic;
using System.IO;

namespace ObserverPatternViaDelegate
{
    public class DirectoryMonitor
    {
        private readonly List<string> _filesInFolder;

        public string MonitoredDirectory { get; private set; }
        public DirectoryMonitor(string foldernameToMonitor)
        {
            MonitoredDirectory = foldernameToMonitor;
            _filesInFolder = new List<string>();
        }

        /// <summary>
        /// Check if we can monitor given folder from ctor..
        /// </summary>
        /// <returns></returns>
        public bool StartMonitoring()
        {
            if (!Directory.Exists(MonitoredDirectory))
            {
                return false;
            }
            var directoryInfo = new DirectoryInfo(MonitoredDirectory);
            foreach (var fileInfo in directoryInfo.GetFiles())
            {
                _filesInFolder.Add(fileInfo.FullName);
            }
            return true;
        }

        public List<string> GetDeletedFiles()
        {
            var result = new List<string>();
            foreach (var file in _filesInFolder.ToArray())
            {
                if (!File.Exists(file))
                {
                    _filesInFolder.Remove(file);
                    result.Add(file);
                }
            }

            return result;
        }
    }
}
