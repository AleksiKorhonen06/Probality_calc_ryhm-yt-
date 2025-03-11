using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probality_calc
{
    internal class Logic
    {
        public float SameNumInSuccession(List<int> WantedNums)
        {
            if (DiceStorage.diceList.Count == 0) return 0f;

            // Step 1: Find numbers that exist in all dice
            HashSet<int> commonNumbers = new HashSet<int>(WantedNums);
            foreach (var dice in DiceStorage.diceList)
            {
                commonNumbers.IntersectWith(dice.Values);
            }

            if (commonNumbers.Count == 0) return 0f; // No common numbers

            // Step 2: Count occurrences per die, ensuring we track each roll separately
            int WantedOutcomes = 0;
            int TotalOutcomes = 1;

            foreach (var dice in DiceStorage.diceList)
            {
                int countInDice = dice.Values.Count(v => commonNumbers.Contains(v));
                WantedOutcomes += countInDice;
                TotalOutcomes *= dice.Values.Count; // Each die contributes to the total possibilities
            }

            if (TotalOutcomes == 0) return 0f;

            return ((float)WantedOutcomes / TotalOutcomes) * 100;
        }

        public float SumLessThan(int WantedNum)
        {
            if (DiceStorage.diceList.Count == 0) return 0f;

            List<List<int>> allValues = DiceStorage.diceList.Select(d => d.Values).ToList();
            List<int> possibleSums = GetAllSums(allValues);

            int validSums = possibleSums.Count(sum => sum < WantedNum);
            int totalSums = possibleSums.Count;

            if (totalSums == 0 || validSums == 0) return 0f;

            return ((float)validSums / totalSums) * 100;
        }

        public float SumMoreThan(int WantedNum)
        {
            if (DiceStorage.diceList.Count == 0) return 0f;

            List<List<int>> allValues = DiceStorage.diceList.Select(d => d.Values).ToList();
            List<int> possibleSums = GetAllSums(allValues);

            int validSums = possibleSums.Count(sum => sum > WantedNum);
            int totalSums = possibleSums.Count;

            if (totalSums == 0 || validSums == 0) return 0f;

            return ((float)validSums / totalSums) * 100;
        }

        // "Auttaja" method. Menee SumLessThan tai SumMoreThan.
        private List<int> GetAllSums(List<List<int>> values)
        {
            List<int> result = new List<int> { 0 };

            foreach (var diceValues in values)
            {
                List<int> newSums = new List<int>();

                foreach (int existingSum in result)
                {
                    foreach (int diceValue in diceValues)
                    {
                        newSums.Add(existingSum + diceValue);
                    }
                }

                result = newSums;
            }

            return result;
        }
    }
}

