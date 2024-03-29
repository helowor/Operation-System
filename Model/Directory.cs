using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Model
{
    internal class Directory
    {
        public string Name { get; set; }
        public List<Directory> Subdirectories { get; set; }

        public Directory(string name)
        {
            Name = name;
            Subdirectories = new List<Directory>();
        }
    }
}
