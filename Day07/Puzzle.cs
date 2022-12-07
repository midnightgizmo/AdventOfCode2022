using Day07.FileSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07
{
    internal class Puzzle : Shared.PuzzleBase
    {
        public long SolvePuzzleOne()
        {
            string PuzzleData = this.LoadPuzzleDataIntoMemory();
            CommandPrompt cp = new CommandPrompt();
            FileSystem.FileSystem fileSystem = cp.ParseInput(PuzzleData);

            long Size = this.FindAllFoldersWithSizeAtLeast(fileSystem.RootFolder, 100000);


			return Size;
        }

        private long FindAllFoldersWithSizeAtLeast(Folder ParentFolder, long MaxSize)
        {
            long TotalSize = 0;
            long FolderSize = ParentFolder.FolderSize;

            if (FolderSize <= MaxSize)
                TotalSize += FolderSize;

			foreach (Folder Folder in ParentFolder.Folders) 
            {
				TotalSize += FindAllFoldersWithSizeAtLeast(Folder, MaxSize);
            }

            return TotalSize;

		}

        public long SolvePuzzleTwo()
        {
			string PuzzleData = this.LoadPuzzleDataIntoMemory();
			CommandPrompt cp = new CommandPrompt();
			FileSystem.FileSystem fileSystem = cp.ParseInput(PuzzleData);

            long HardDriveSize = 70000000;
            long UpdateSize = 30000000;
            long TotalAmountOfUsedSpace = fileSystem.RootFolder.FolderSize;
            long FreeSpaceOnDisk = HardDriveSize - TotalAmountOfUsedSpace;
            long spaceNeeded = UpdateSize- FreeSpaceOnDisk;

			// find all folders that are at least <spaceNeeded> in size
			// and add that folders size to the <SizeOfFoldersThatCouldBeDeleted> List
			FindFolderToDelete(fileSystem.RootFolder, spaceNeeded);
            // sort the list from big to small
            SizeOfFoldersThatCouldBeDeleted.Sort();
            // return the the smallest folder size (this would be the one we want to delete
			return SizeOfFoldersThatCouldBeDeleted[0];
        }

        private List<long> SizeOfFoldersThatCouldBeDeleted = new List<long>();
        private void FindFolderToDelete(Folder ParentFolder, long MinSize)
        {
            long FolderSize = ParentFolder.FolderSize;

            if (ParentFolder.Name == "d")
            {
                int i = 0;
            }


			if (FolderSize >= MinSize)
                SizeOfFoldersThatCouldBeDeleted.Add(FolderSize);

			foreach (Folder Folder in ParentFolder.Folders)
			{
				FindFolderToDelete(Folder, MinSize);
			}
		}
    }
}
