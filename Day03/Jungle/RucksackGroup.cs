using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day03.Jungle
{
	internal class RucksackGroup
	{
		private List<Rucksack> RucksacksInGroup = new List<Rucksack>();


		public void AddRuckSack(Rucksack rucksack)
		{
			this.RucksacksInGroup.Add(rucksack);
			
		}

		public int FindGroupIdentityNumberInRuckSackList()
		{
			Rucksack firstRuckSack = RucksacksInGroup[0];
			Rucksack secondRuckSack = RucksacksInGroup[1];
			Rucksack thirdRuckSack = RucksacksInGroup[2];


			// go through each letter in the first rucksack
			foreach (char letter in firstRuckSack.RucksackRawData)
			{
				// see if the current letter we are looking at exists in both
				// ruck sack 2 and 3. If it does, we have found the letter we are after
				if (secondRuckSack.RucksackRawData.Contains(letter) == true &&
					thirdRuckSack.RucksackRawData.Contains(letter) == true)
				{
					return Item.ConvertItemNameToPriorityNumber(letter);
				}
			}
			// this should never be reached, if it does, somthing has gone wrong.
			return 0;
			
		}

	}
}
