using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07.FileSystem
{
    internal class CommandPrompt
    {
        private FileSystem _FileSystem = new FileSystem();

        public FileSystem ParseInput(string input)
        {
            string[] InputSplitIntoLines =  input.Split("\r\n");
            for(int i = 0; i < input.Length; i++) 
            {
                int PositionOfNextCommandInArray = this.FindNextCommand(i + 1,InputSplitIntoLines);

                string[] DataOutputToConsol;
				
                if(PositionOfNextCommandInArray >= 0)
                    DataOutputToConsol = this.ExtractOutPutFromCommand(InputSplitIntoLines, i + 1, PositionOfNextCommandInArray - 1);
                // if there was no more commands to find in the input data
                else
					DataOutputToConsol = this.ExtractOutPutFromCommand(InputSplitIntoLines, i + 1, input.Length - 1);


				string line = InputSplitIntoLines[i];
                char FirstLetter = line[0];
                switch(FirstLetter) 
                {
                    case '$':
                        string[] inputs = line.Split(new char[] { ' ', });
                        if(inputs.Length > 1)
                        {
                            this.ProcessCommand(inputs[1],inputs,DataOutputToConsol);


						}
                        
                        break;
                }

                if (PositionOfNextCommandInArray < 0)
                    break;

                // start the for loop again and the line of where the next command should be.
				i = PositionOfNextCommandInArray - 1;
			}

            return this._FileSystem;

		}

        private int FindNextCommand(int IndexStartPosition, string[] InputData)
        {
            // will determin the next line a "$" is found in InputData, Starting from IndexStartPosition.
            // -1 will indicate we did not find "$", which most likely means we got to the end of the array
            int LineNextCommandFoundOn = -1;

            for(int i = IndexStartPosition; i < InputData.Length; i++)
            {
                string LineData = InputData[i];
                if(LineData.Length > 0)
                {
                    if (LineData[0] == '$')
                    {
                        LineNextCommandFoundOn = i;
                        break;
                    }
                }
            }

            return LineNextCommandFoundOn;
        }

        private string[] ExtractOutPutFromCommand(string[] InputData, int IndexStartPosition, int IndexEndPosition)
        {
            int Length = IndexEndPosition- IndexStartPosition + 1;
            string[] OutputData = InputData.Skip(IndexStartPosition).Take(Length).ToArray();

            return OutputData;
        }

        private void ProcessCommand(string commandType, string[] CommandLineData, string[] DataOutputToConsol)
        {
            Commands commands = Commands.UnknownCommand;

            switch(commandType.ToLower())
            {
                case "cd":
                    commands = Commands.ChangeDirectory;
                    this.ChangeDirectory(CommandLineData);
					break;

                case "ls":
                    commands = Commands.ListContent;
                    this.ListContent(DataOutputToConsol);

					break;
            }

           
        }

        private void ChangeDirectory(string[] CommandlineData)
        {
            // if we have not recieved the location of where we want to change the directory too
            if (CommandlineData.Length < 3)
                return;

            // the location of where we want to change directory to
            string parameter = CommandlineData[2];

            switch(parameter)
            {
                case "..":

                    this._FileSystem.MoveBackOneFolder();
                    break;

                // move to the top directory.
                case "/":

                    this._FileSystem.MoveToRootOfDirecetory();
                    break;

                // should be a request to change to a specific folder within this directory
                default:

					this._FileSystem.MoveToSubFolder(parameter);
                    break;
            }

        }

        private void ListContent(string[] DataOutputToConsol)
        {
            foreach(string line in DataOutputToConsol)
            {
                string[] parameters = line.Split(' ');

                if(parameters.Length != 2) 
                    continue;

                // if its a folder
                if (parameters[0]== "dir")
                {
                    // folder name
                    string FolderName = parameters[1];

                    Folder newFoldler = new Folder()
                    {
                        Name = FolderName,
                        ParentFolder = this._FileSystem.WorkingDirectory
                    };
                    this._FileSystem.WorkingDirectory.AddFolder(newFoldler);
                }
                // it must be a file
                else
                {
                    // File size
                    int FileSize = int.Parse(parameters[0]);
                    // File Name
                    string FileName = parameters[1];

                    File newFile = new File() { Name= FileName, Size = FileSize };
                    this._FileSystem.WorkingDirectory.AddFile(newFile);
                }
            }
        }
    }

    public enum Commands
    {
        ChangeDirectory,
        ListContent,
        UnknownCommand
    }
}
