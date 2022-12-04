using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Day03.Jungle
{
	internal class Rucksack
	{
		private List<Item> _LeftCompartment = new List<Item>();
		private List<Item> _RightCompartment = new List<Item>();


		public Item FindItemThatExistsInBothCompartments()
		{
			foreach(Item anItem in this._LeftCompartment) 
			{ 
				Item? foundItem = this._RightCompartment.Where(r => r.NumberPriority == anItem.NumberPriority).FirstOrDefault();
				if(foundItem != null)
					return foundItem;
			}

			return null;
		}

		public Item[] GetLeftCompartment()
		{
			return this._LeftCompartment.ToArray();
		}
		public Item[] GetRightCompartment() 
		{
			return this._RightCompartment.ToArray();
		}

		public string RucksackRawData {get; private set;}

		public static Rucksack ParseData(string RucksackInput)
		{
			Rucksack rucksack = new Rucksack();
			string LeftCompartment, RightCompartment;

			rucksack.RucksackRawData = RucksackInput;

			// split the rucksack into 2 equal parts
			LeftCompartment = RucksackInput.Substring(0, RucksackInput.Length / 2);
			RightCompartment = RucksackInput.Substring(RucksackInput.Length / 2);

			// go through each item in the left and right compartments,
			// work out what each ones number pririty is and add them to the Rucksack._LeftCompartment and Rucksack._RightCompartment
			for (int i = 0; i < RucksackInput.Length / 2; i++)
			{
				Item leftItem= new Item();
				Item rightItem= new Item();

				leftItem.Name = LeftCompartment[i];
				rightItem.Name = RightCompartment[i];

				leftItem.NumberPriority = Item.ConvertItemNameToPriorityNumber(leftItem.Name);
				rightItem.NumberPriority = Item.ConvertItemNameToPriorityNumber(rightItem.Name);

				rucksack._LeftCompartment.Add(leftItem);
				rucksack._RightCompartment.Add(rightItem);
			}

			return rucksack;
		}
	}

	internal class Item
	{
		public char Name;
		public int NumberPriority = 0;

		public static int ConvertItemNameToPriorityNumber(char Name)
		{
			int LowerCaseOffset = ((int)'a') - 1;
			int UpperCaseOffSet = ((int)'A') - 1;
			int priority = (int)Name;

			if(char.IsLower(Name))
				return priority - LowerCaseOffset;
			else
				return priority - UpperCaseOffSet + 26;
		}
	}
}
