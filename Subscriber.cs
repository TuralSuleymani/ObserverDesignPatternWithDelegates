using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPatternViaDelegate
{
   public class Subscriber
    {
        private string _name;

        public Subscriber(string name)
        {
            this._name = name;
        }

        public void NotifyMe(string filename,string folder)
        {
            Console.WriteLine($"{_name}, `{filename}` removed from {folder}");
        }
    }
}
