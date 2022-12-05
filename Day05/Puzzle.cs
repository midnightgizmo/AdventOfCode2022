using Day05.Supplies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05
{
	internal class Puzzle : Shared.PuzzleBase
	{
		public string SolvePuzzleOne()
		{
			string PuzzleData = this.LoadPuzzleDataIntoMemory();
			string[] PuzzleDataSplitIntoLines = PuzzleData.Split("\r\n");

			int LastLineOfCranePositionData = 0;
			int StartOfCraneMovmentData = 0;
			for(int i = 0; i < PuzzleDataSplitIntoLines.Length; i++)
			{
				string line = PuzzleDataSplitIntoLines[i];
				if (line[0] == '[')
					continue;
				if (line[0] == ' ')
				{
					// check if the second char is a number
					char secondChar = line[1];
					if(char.IsNumber(secondChar) == true)
					{
						// we have found the last line of the first part of the data
						// that shows where all the creates start out.
						LastLineOfCranePositionData = i - 1;
						StartOfCraneMovmentData = i + 1;
						break;
					}
				}
			}

			CratesStack StackedCrates = CratesStack.ParseCreatesStack(PuzzleDataSplitIntoLines.Take(LastLineOfCranePositionData + 1).ToArray());

			foreach(string line in PuzzleDataSplitIntoLines.Skip(StartOfCraneMovmentData + 1))
			{
				Instructions instruction = Instructions.ParaseLine(line);
				StackedCrates.MoveCrates_PuzzleOne(instruction.NumberOfCratsToMove,instruction.ColumnToMoveCratesFrom,instruction.ColumnToMoveCratesTo);
			}
			return StackedCrates.GetTopCratesLetters();
		}

		public string SolvePuzzleTwo()
		{
			string PuzzleData = this.LoadPuzzleDataIntoMemory();
			string[] PuzzleDataSplitIntoLines = PuzzleData.Split("\r\n");

			int LastLineOfCranePositionData = 0;
			int StartOfCraneMovmentData = 0;
			for (int i = 0; i < PuzzleDataSplitIntoLines.Length; i++)
			{
				string line = PuzzleDataSplitIntoLines[i];
				if (line[0] == '[')
					continue;
				if (line[0] == ' ')
				{
					// check if the second char is a number
					char secondChar = line[1];
					if (char.IsNumber(secondChar) == true)
					{
						// we have found the last line of the first part of the data
						// that shows where all the creates start out.
						LastLineOfCranePositionData = i - 1;
						StartOfCraneMovmentData = i + 1;
						break;
					}
				}
			}

			CratesStack StackedCrates = CratesStack.ParseCreatesStack(PuzzleDataSplitIntoLines.Take(LastLineOfCranePositionData + 1).ToArray());

			foreach (string line in PuzzleDataSplitIntoLines.Skip(StartOfCraneMovmentData + 1))
			{
				Instructions instruction = Instructions.ParaseLine(line);
				StackedCrates.MoveCrates_PuzzleTwo(instruction.NumberOfCratsToMove, instruction.ColumnToMoveCratesFrom, instruction.ColumnToMoveCratesTo);
			}
			return StackedCrates.GetTopCratesLetters();
		}
	}
}
