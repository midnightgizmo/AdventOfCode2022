using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01.Elfs
{
	internal class Elf
	{
		public List<int> FoodCalories = new List<int>();
		public int TotalCalories = 0;

		public void AddCalories(string calories)
		{
			string[] CaloriesList = calories.Split("\r\n",StringSplitOptions.RemoveEmptyEntries);

			foreach(string calorie in CaloriesList) 
			{ 
				int FoodCalorie = int.Parse(calorie);
				TotalCalories += FoodCalorie;
				FoodCalories.Add(FoodCalorie);

			}
		}
	}
}
