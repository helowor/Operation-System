using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace App.Model
{
    internal class PCB
    {
        public string Pname { get; set; }
        public string Pid { get; set; }
        public int Time { get; set; }
        
        public int resource1 {  get; set; } = 0;
        public int resource2 { get; set; } = 0;
        public int resource3 { get; set; } = 0;

    }
}
