using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using System.Timers;

namespace ObserverPatternViaDelegate
{
    public class FolderMonitorDelegate : IDisposable
    {
        private readonly Timer _timer;
        private readonly DirectoryMonitor _directoryMonitor;
        private readonly Action<string,string> _subscriber;
        public FolderMonitorDelegate(string folderToMonitor,Action<string,string> subscriber)
        {
            _directoryMonitor = new DirectoryMonitor(folderToMonitor);
            _subscriber = subscriber;
            if (_directoryMonitor.StartMonitoring())
            {
                _timer = new Timer(1000);
                _timer.Elapsed += CheckIfRemoved;
                _timer.Start();
            }
            else
            {
                Console.WriteLine("Directory doesn't exists");
                this.Dispose();
            }
        }

        private void CheckIfRemoved(object sender, ElapsedEventArgs e)
        {
            //get lists of removed files
            foreach (var fileName in _directoryMonitor.GetDeletedFiles())
            {
                //notify user about changing in folder..
                _subscriber(fileName,_directoryMonitor.MonitoredDirectory);
            }
        }

        public void Dispose()
        {
            _timer.Dispose();
        }
    }
}
