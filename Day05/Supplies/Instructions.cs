using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05.Supplies
{
	internal class Instructions
	{
		public int NumberOfCratsToMove = 0;
		public int ColumnToMoveCratesFrom = 0;
		public int ColumnToMoveCratesTo = 0;
		public static Instructions ParaseLine(string Line)
		{
			Instructions instructions = new Instructions();

			string[] data = Line.Split(new char[] { ' ' });

			instructions.NumberOfCratsToMove = int.Parse(data[1]);
			instructions.ColumnToMoveCratesFrom= int.Parse(data[3]) - 1;
			instructions.ColumnToMoveCratesTo = int.Parse(data[5]) - 1;

			return instructions;
		}
	}
}
