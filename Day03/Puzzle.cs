using Day03.Jungle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day03
{
	internal class Puzzle : Shared.PuzzleBase
	{

		public int SolvePuzzleOne()
		{
			string PuzzleData = this.LoadPuzzleDataIntoMemory();

			string[] PuzzleDataSplitIntoLines = PuzzleData.Split("\r\n",StringSplitOptions.RemoveEmptyEntries);


			List<Item> Items = new List<Item>();
			foreach (string line in PuzzleDataSplitIntoLines)
			{
				Rucksack aRuckSack= Rucksack.ParseData(line);
				Items.Add(aRuckSack.FindItemThatExistsInBothCompartments());
			}
			
			return Items.Sum(s => s.NumberPriority);
		}

		public int SolvePuzzleTwo() 
		{
			string PuzzleData = this.LoadPuzzleDataIntoMemory();

			string[] PuzzleDataSplitIntoLines = PuzzleData.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);


			int SumOfGroupIdentitys = 0;
			// loop through every 3 lines.
			for(int index = 0; index < PuzzleDataSplitIntoLines.Length; index += 3)
			{
				RucksackGroup rucksackGroup = new RucksackGroup();

				// add the 3 lines of input to the rucksackgroup
				rucksackGroup.AddRuckSack(Rucksack.ParseData(PuzzleDataSplitIntoLines[index]));
				rucksackGroup.AddRuckSack(Rucksack.ParseData(PuzzleDataSplitIntoLines[index + 1]));
				rucksackGroup.AddRuckSack(Rucksack.ParseData(PuzzleDataSplitIntoLines[index + 2]));

				// find the group identity number
				int GroupIdentity = rucksackGroup.FindGroupIdentityNumberInRuckSackList();
				// add the group identiy number to the previouse group identiy numbers we round
				// in previouse loops
				SumOfGroupIdentitys += GroupIdentity;
			}

			
			// return the sum of the group idenity numbers.
			return SumOfGroupIdentitys;
		}
	}
}
