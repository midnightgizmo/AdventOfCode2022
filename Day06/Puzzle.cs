using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day06
{
	internal class Puzzle : Shared.PuzzleBase
	{
		public int SolvePuzzleOne()
		{
			string PuzzleData = this.LoadPuzzleDataIntoMemory();

			for(int i = 3; i < PuzzleData.Length; i++)
			{
				string DataToCheck = PuzzleData.Substring(i - 3, 4);

				// records the position the letter was found in DatToCheck
				Dictionary<char,int> LetterPoistion = new Dictionary<char,int>();
				bool WasSequenceFound = true;
				for(int eachLetterPosition = DataToCheck.Length - 1; eachLetterPosition >=0; eachLetterPosition--)
				{
					char letter = DataToCheck[eachLetterPosition];

					if(LetterPoistion.ContainsKey(letter))
					{
						i += eachLetterPosition;
						WasSequenceFound = false;
						break;
					}
					else
					{
						LetterPoistion.Add(letter, eachLetterPosition);
						continue;
					}
				}

				if(WasSequenceFound)
				{
					return i + 1;
				}
			}

			// should this happen, then the sequence of letter does not contain none repeating letters.
			return -1;
		}

		public int SolvePuzzleTwo()
		{
			int NumberOfLetterToCheck = 14;
			string PuzzleData = this.LoadPuzzleDataIntoMemory();

			// go through each letter. We are going to start at letter 14 in the loop.
			// This will mean we check the the previouse 14 letters from this points.
			for (int i = (NumberOfLetterToCheck - 1); i < PuzzleData.Length; i++)
			{
				// the the 14 letter we are going to check
				string DataToCheck = PuzzleData.Substring(i - (NumberOfLetterToCheck - 1), NumberOfLetterToCheck);

				// records what letters we have found in DataToCheck
				Dictionary<char, int> LetterPoistion = new Dictionary<char, int>();
				// will be set to false if we find a letter that exists more than once.
				bool WasSequenceFound = true;
				// working from right to left, go through each letter and record the letter we have found.
				// if the letter is found more than once we have found a repeating letter. and so the above
				// for loop will need to continue with the starting point (i) set to the position of the found
				// repeating letter.
				for (int eachLetterPosition = DataToCheck.Length - 1; eachLetterPosition >= 0; eachLetterPosition--)
				{
					// get the letter we are looking at
					char letter = DataToCheck[eachLetterPosition];

					// have we found the letter before in this loop
					if (LetterPoistion.ContainsKey(letter))
					{
						// set the new start position in the first for loop
						// to the position of the repeating letter we found
						i += eachLetterPosition;
						// set to false to indicate a repeating letter was found
						WasSequenceFound = false;
						break;
					}
					// if this letter was not found before, make a record of it
					else
					{
						// add the letter to the dictionary
						LetterPoistion.Add(letter, eachLetterPosition);
						// continue through this loop
						continue;
					}
				}
				// if the for loop did not find any repeating letters, WasSequenceFound will equal true
				if (WasSequenceFound)
				{
					// return the position where the none repeating letters were found
					return i + 1;
				}
			}
			// should this happen, then the sequence of letter does not contain none repeating letters.
			return -1;
		}
	}
}
