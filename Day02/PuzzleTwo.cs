using Day02.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02
{
	internal class PuzzleTwo : Shared.PuzzleBase
	{
		public int SolvePuzzle()
		{
			string PuzzleData = this.LoadPuzzleDataIntoMemory();

			string[] SplitIntoLines = PuzzleData.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);

			List<RockPaperScissors> games = new List<RockPaperScissors>();

			PointsData pointsData = new PointsData();
			pointsData.ChoosingRock = 1;
			pointsData.ChoosingPaper = 2;
			pointsData.ChoosingScissor = 3;

			pointsData.WinningGame = 6;
			pointsData.LoosingGame = 0;
			pointsData.DrawingInGame = 3;

			foreach (string line in SplitIntoLines)
			{
				games.Add(RockPaperScissors.ParsePuzzleTwoInput(line).RunGamePuzzle(pointsData));

			}

			return games.Sum(s => s.OurScoreFromGame);

		}
	}
}
