namespace Day02
{
	internal class Program
	{
		static void Main(string[] args)
		{
			PuzzleOne puzzleOne = new PuzzleOne();
			Console.WriteLine("PuzzleOne Answer");
			Console.WriteLine(puzzleOne.SolvePuzzle());

			Console.WriteLine();

			PuzzleTwo puzzleTwo = new PuzzleTwo();
			Console.WriteLine("PuzzleTwo Answer");
			Console.WriteLine(puzzleTwo.SolvePuzzle());
		}
	}
}