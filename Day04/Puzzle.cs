using Day04.Camp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day04
{
	internal class Puzzle : Shared.PuzzleBase
	{
		public int SolvePuzzleOne()
		{
			string PuzzleData = this.LoadPuzzleDataIntoMemory();
			string[] EachLine = PuzzleData.Split("\r\n",StringSplitOptions.RemoveEmptyEntries);

			int ContainsCount = 0;
			foreach(string line in EachLine)
			{
				string[] ElfsData = line.Split(',');
				ElfRange elfOne, elfTwo;
				elfOne = ElfRange.ParseInput(ElfsData[0]);
				elfTwo = ElfRange.ParseInput(ElfsData[1]);

				if(elfOne.DoesElfRangeContain(elfTwo))
					ContainsCount++;
				else if(elfTwo.DoesElfRangeContain(elfOne))
					ContainsCount++;
			}

			return ContainsCount;
		}

		public int SolvePuzzleTwo()
		{
			string PuzzleData = this.LoadPuzzleDataIntoMemory();
			string[] EachLine = PuzzleData.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);

			int ContainsCount = 0;
			foreach (string line in EachLine)
			{
				string[] ElfsData = line.Split(',');
				ElfRange elfOne, elfTwo;
				elfOne = ElfRange.ParseInput(ElfsData[0]);
				elfTwo = ElfRange.ParseInput(ElfsData[1]);

				if(elfOne.DoesElfRangeOverlap(elfTwo) == true)
					ContainsCount++;

			}
	
			return ContainsCount;
		}
	}
}
