﻿namespace Day01
{
	internal class Program
	{
		static void Main(string[] args)
		{
			PuzzleOne puzzleOne = new PuzzleOne();

			Console.WriteLine("PuzzleOneAnswer:");
			Console.WriteLine(puzzleOne.SolvePuzzle());

			PuzzleTwo puzzleTwo = new PuzzleTwo();

			Console.WriteLine("PuzzleTwoAnswer:");
			Console.WriteLine(puzzleTwo.SolvePuzzle());
		}
	}
}