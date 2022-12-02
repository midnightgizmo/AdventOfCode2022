using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02.Game
{
	internal class RockPaperScissors
	{
		private RockPaperScissorsMoveType _AponentsMove;
		private RockPaperScissorsMoveType _OurMove;

		public WhoWon Winner;

		public int OurScoreFromGame { get; private set; }


		public RockPaperScissors(RockPaperScissorsMoveType AponentsMove, RockPaperScissorsMoveType OurMove)
		{
			this._AponentsMove= AponentsMove;
			this._OurMove= OurMove;
		}

		public RockPaperScissors RunGamePuzzle(PointsData ScoreSystem)
		{
			// if it was a draw
			if(this._AponentsMove == this._OurMove)
			{
				this.Winner = WhoWon.Draw;
				this.OurScoreFromGame = ScoreSystem.DrawingInGame + this.GetPointsFromMoveWeMade(ScoreSystem);

			}
			else
			{
				switch(this._AponentsMove)
				{
					case RockPaperScissorsMoveType.Rock:

						// if we choose scissors (we loose)
						if(this._OurMove == RockPaperScissorsMoveType.Scissor)
						{
							this.Winner = WhoWon.ApponentWon;
							this.OurScoreFromGame = ScoreSystem.LoosingGame + this.GetPointsFromMoveWeMade(ScoreSystem);
							
						}
						// if we choose paper (we win)
						else
						{
							this.Winner = WhoWon.WeWon;
							this.OurScoreFromGame = ScoreSystem.WinningGame + this.GetPointsFromMoveWeMade(ScoreSystem);
						}
						break;

					case RockPaperScissorsMoveType.Paper:

						// if we choose Rock (we loose)
						if (this._OurMove == RockPaperScissorsMoveType.Rock)
						{
							this.Winner = WhoWon.ApponentWon;
							this.OurScoreFromGame = ScoreSystem.LoosingGame + this.GetPointsFromMoveWeMade(ScoreSystem);

						}
						// if we choose scissors (we win)
						else
						{
							this.Winner = WhoWon.WeWon;
							this.OurScoreFromGame = ScoreSystem.WinningGame + this.GetPointsFromMoveWeMade(ScoreSystem);
						}
						break;

					case RockPaperScissorsMoveType.Scissor:

						// if we choose paper (we loose)
						if (this._OurMove == RockPaperScissorsMoveType.Paper)
						{
							this.Winner = WhoWon.ApponentWon;
							this.OurScoreFromGame = ScoreSystem.LoosingGame + this.GetPointsFromMoveWeMade(ScoreSystem);

						}
						// if we choose rock (we win)
						else
						{
							this.Winner = WhoWon.WeWon;
							this.OurScoreFromGame = ScoreSystem.WinningGame + this.GetPointsFromMoveWeMade(ScoreSystem);
						}
						break;
				}
			}




			return this;
		}

		


		private int GetPointsFromMoveWeMade(PointsData ScoreSystem)
		{
			switch(this._OurMove)
			{
				case RockPaperScissorsMoveType.Rock:
					return ScoreSystem.ChoosingRock;

				case RockPaperScissorsMoveType.Paper:
					return ScoreSystem.ChoosingPaper;

				case RockPaperScissorsMoveType.Scissor:
					return ScoreSystem.ChoosingScissor;
				
				default:
					return 0;
			}
		}

	

		public static RockPaperScissors ParsePuzzleOneInput(string data)
		{
			string[] splitData = data.Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries);
			// aponents encreyted move
			string aponent = splitData[0];
			// my encrypted move
			string Me = splitData[1];

			return new RockPaperScissors(DycryptMoveType(aponent),DycryptMoveType(Me));
		}

		public static RockPaperScissors ParsePuzzleTwoInput(string data)
		{
			string[] splitData = data.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			// aponents encreyted move
			string aponent = splitData[0];
			// my encrypted move
			string Me = splitData[1];

			RockPaperScissorsMoveType AponentsMoveType = DycryptMoveType(aponent);
			RockPaperScissorsMoveType MyMoveType = RockPaperScissorsMoveType.Unknown;

			switch (AponentsMoveType)
			{
				case RockPaperScissorsMoveType.Rock:
					switch (Me)
					{
						// we need to loose the game
						case "X":
							MyMoveType = RockPaperScissorsMoveType.Scissor;
							break;
						// we need to draw
						case "Y":
							MyMoveType = RockPaperScissorsMoveType.Rock;
							break;
						// we need to win
						case "Z":
							MyMoveType = RockPaperScissorsMoveType.Paper;
							break;
					}
					break;

				case RockPaperScissorsMoveType.Paper:
					switch (Me)
					{
						// we need to loose the game
						case "X":
							MyMoveType = RockPaperScissorsMoveType.Rock;
							break;
						// we need to draw
						case "Y":
							MyMoveType = RockPaperScissorsMoveType.Paper;
							break;
						// we need to win
						case "Z":
							MyMoveType = RockPaperScissorsMoveType.Scissor;
							break;
					}
					break;

				case RockPaperScissorsMoveType.Scissor:
					switch (Me)
					{
						// we need to loose the game
						case "X":
							MyMoveType = RockPaperScissorsMoveType.Paper;
							break;
						// we need to draw
						case "Y":
							MyMoveType = RockPaperScissorsMoveType.Scissor;
							break;
						// we need to win
						case "Z":
							MyMoveType = RockPaperScissorsMoveType.Rock;
							break;
					}
					break;
			}

			return new RockPaperScissors(AponentsMoveType, MyMoveType);
		}

		private static RockPaperScissorsMoveType DycryptMoveType(string move)
		{
			switch(move)
			{
				// rock
				case "A":
				case "X":
					return RockPaperScissorsMoveType.Rock;

				// paper
				case "B":
				case "Y":
					return RockPaperScissorsMoveType.Paper;

				// scissor
				case "C":
				case "Z":
					return RockPaperScissorsMoveType.Scissor;

				default:
					return RockPaperScissorsMoveType.Unknown;
			}

			
		}
	}

	public enum RockPaperScissorsMoveType 
	{
		Rock,
		Paper,
		Scissor,
		Unknown
	}

	public enum WhoWon
	{
		// This is the person we are playing
		ApponentWon,
		// This is us (we won)
		WeWon,
		// no one won
		Draw
	}

	public struct PointsData
	{
		public int WinningGame;
		public int LoosingGame;
		public int DrawingInGame;

		public int ChoosingRock;
		public int ChoosingPaper;
		public int ChoosingScissor;
	}
}


