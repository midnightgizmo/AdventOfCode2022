using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05.Supplies
{
	internal class CratesStack
	{
		
		private List<Stack> StacksOfCrates = new List<Stack>();
		public CratesStack()
		{
			
		}

		public void MoveCrates_PuzzleOne(int NumberToMove, int ColumnToMoveFrom, int ColumnToMoveTo)
		{
			Stack StackFrom = StacksOfCrates[ColumnToMoveFrom];
			Stack StackTo = StacksOfCrates[ColumnToMoveTo];

			for (int i = 0; i < NumberToMove; i++)
			{
				
				object temp = StackFrom.Pop();
				StackTo.Push(temp);

			}
		}

		public void MoveCrates_PuzzleTwo(int NumberToMove, int ColumnToMoveFrom, int ColumnToMoveTo)
		{
			Stack StackFrom = StacksOfCrates[ColumnToMoveFrom];
			Stack StackTo = StacksOfCrates[ColumnToMoveTo];

			Stack tempStack = new Stack();
			for (int i = 0; i < NumberToMove; i++)
			{

				object temp = StackFrom.Pop();
				tempStack.Push(temp);
				//StackTo.Push(temp);

			}
			foreach(char letter in tempStack)
			{
				StackTo.Push(letter);
			}
		}

		public string GetTopCratesLetters()
		{
			StringBuilder sb = new StringBuilder();
			foreach(Stack stack in StacksOfCrates)
			{
				sb.Append(stack.Peek());
			}

			return sb.ToString();
		}

		public static CratesStack ParseCreatesStack(string[] CreatesPositionData)
		{
			int MaxNumberOfStackedCrates = CreatesPositionData.Length;
			int NumberOfStacks = (CreatesPositionData.Max(s => s.Length) + 1) / 4;

			CratesStack cratesStack = new CratesStack();
			
			// go through each column
			for (int column = 0; column < NumberOfStacks; column++)
			{
				Stack aColumn = new Stack();
				// go through each stack
				for (int row = MaxNumberOfStackedCrates - 1; row >=0; row--)
				{
					char letter = CreatesPositionData[row][(column * 4) + 1];
					if(letter != ' ')
						aColumn.Push(letter);
				}

				cratesStack.StacksOfCrates.Add(aColumn);


			}

			return cratesStack;

		}
	}
}
