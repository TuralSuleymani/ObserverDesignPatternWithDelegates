using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPatternViaDelegate
{
    class Program
    {
        static void Main(string[] args)
        {
            //create subscriber
            Subscriber subscriber = new Subscriber("Simon");

            FolderMonitorDelegate folderMonitorDelegate
                                    = new FolderMonitorDelegate("C:/mycode", subscriber.NotifyMe);

            Console.ReadLine();
            folderMonitorDelegate.Dispose();
        }
    }
}
