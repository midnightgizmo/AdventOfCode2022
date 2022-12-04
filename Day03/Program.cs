namespace Day03
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Puzzle puzzle= new Puzzle();

			Console.WriteLine("Puzzle One");
			Console.WriteLine(puzzle.SolvePuzzleOne());

			Console.WriteLine();

			Console.WriteLine("Puzzle Two");
			Console.WriteLine(puzzle.SolvePuzzleTwo());
		}
	}
}