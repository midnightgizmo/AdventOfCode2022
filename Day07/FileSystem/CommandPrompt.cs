using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07.FileSystem
{
    internal class CommandPrompt
    {
        public void ParseInput(string input)
        {
            string[] InputSplitIntoLines =  input.Split("\r\n");
            for(int i = 0; i < input.Length; i++) 
            {
                string line = InputSplitIntoLines[i];
                char FirstLetter = line[0];
                switch(FirstLetter) 
                {
                    case '$':

                        break;
                }
            }
        }
    }
}
