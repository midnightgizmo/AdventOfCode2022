using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07.FileSystem
{
	internal class FileSystem
	{
		public Folder RootFolder;

		public Folder WorkingDirectory { get; private set; }

		public FileSystem()
		{
			this.RootFolder= new Folder();
			this.WorkingDirectory = this.RootFolder;
		}

		public void MoveToRootOfDirecetory()
		{
			this.WorkingDirectory = this.RootFolder;
		}

		public bool MoveBackOneFolder()
		{
			// if we have a working directory and the working directory has a parent folder
			if (this.WorkingDirectory != null && this.WorkingDirectory.ParentFolder != null)
			{
				this.WorkingDirectory = this.WorkingDirectory.ParentFolder;
				return true;
			}
			// eaither workind directory is null or working directory does not have a parent
			else
				return false;
		}

		/// <summary>
		/// Looks for the passed in foldername within the <see cref="WorkingDirectory"/>.
		/// If Folder is found, <see cref="WorkingDirectory"/> is changed to passed in folder name
		/// </summary>
		/// <param name="FolderName"></param>
		/// <returns>true if <see cref="WorkingDirectory"/> changed to passed in Folder name</returns>
		public bool MoveToSubFolder(string FolderName)
		{
			foreach(Folder subFolder in this.WorkingDirectory.Folders)
			{
				if(subFolder.Name == FolderName) 
				{
					this.WorkingDirectory= subFolder;
					return true;
				}
			}

			return false;
		}

	}
}
