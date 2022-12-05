using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day04.Camp
{
	internal class ElfRange
	{
		public int Start;
		public int End;

		public static ElfRange ParseInput(string input)
		{
			ElfRange elf = new ElfRange();

			string[] NumbersAsString = input.Split(new char[] { '-' });

			elf.Start = int.Parse(NumbersAsString[0]);
			elf.End = int.Parse(NumbersAsString[1]);

			return elf;
		}

		public bool DoesElfRangeContain(ElfRange containsElf)
		{
			if (this.Start <= containsElf.Start &&
				this.End >= containsElf.End)
				return true;
			else
				return false;
		}

		public bool DoesElfRangeOverlap(ElfRange overLapElfCheck)
		{
			if(this.Start > overLapElfCheck.End)
			{
				if (overLapElfCheck.End >= this.Start)
					return true;
				else
					return false;
			}
			else
			{
				if (this.End >= overLapElfCheck.Start)
					return true;
				else
					return false;
			}
		}
	}
}
