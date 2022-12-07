using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07.FileSystem
{
    internal class Folder
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public List<File> Files { get; set; } = new List<File>();
        public Folder? ParentFolder { get; set; } = null;


    }
}
