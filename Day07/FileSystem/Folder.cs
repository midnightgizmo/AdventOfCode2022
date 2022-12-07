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
        public List<Folder> Folders { get; set; } = new List<Folder>();
        public Folder? ParentFolder { get; set; } = null;



        public void AddFolder(Folder folder)
        {
            Folders.Add(folder);
        }
        public void AddFile(File file)
        {
            Files.Add(file);
        }

        public long FolderSize
        {
            get
            {
                long Total = this.Files.Sum(f => f.Size);
                foreach (Folder aFolder in this.Folders)
                    Total += aFolder.FolderSize;

                if(Total == 0)
                {
                    int i = 0;
                }
                return Total;
            }
        }

    }
}
