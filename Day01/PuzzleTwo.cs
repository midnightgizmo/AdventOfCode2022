using Day01.Elfs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01
{
	internal class PuzzleTwo : Shared.PuzzleBase
	{
		public int SolvePuzzle()
		{
			string PuzzleData = this.LoadPuzzleDataIntoMemory();

			string[] AnElfsFood = PuzzleData.Split("\r\n\r\n", StringSplitOptions.RemoveEmptyEntries);

			List<Elf> ListOfElfs = new List<Elf>();
			foreach (string ElfsFood in AnElfsFood)
			{
				Elf anElf = new Elf();
				anElf.AddCalories(ElfsFood);
				ListOfElfs.Add(anElf);
			}

			List<Elf> ListOfElfsSorted = ListOfElfs.OrderBy(l => l.TotalCalories).ToList();
			return ListOfElfsSorted[^1].TotalCalories + ListOfElfsSorted[^2].TotalCalories + ListOfElfsSorted[^3].TotalCalories;

		}
	}
}
