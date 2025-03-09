using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probality_calc
{
    internal class Logic
    {
        public float SameNumInSuccession(List<int> WantedNums) //WantedNums voi ottaa useamman numeron. Älä sekota WantedNum:iin, joka voi ottaa vaan yhen
        {
            if (DiceStorage.diceList.Count == 0) return 0f;

            Dictionary<int, int> numCounts = new Dictionary<int, int>();

            foreach (int num in WantedNums)
            {
                bool isInAllLists = DiceStorage.diceList.All(dice => dice.Values.Contains(num));

                if (isInAllLists)
                {
                    int count = DiceStorage.diceList.Sum(dice => dice.Values.Count(v => v == num));
                    numCounts[num] = count;
                }
            }

            int WantedOutcomes = numCounts.Values.Sum();
            int TotalOutcomes = DiceStorage.diceList.Sum(dice => dice.Values.Count);

            if (TotalOutcomes == 0) return 0f;

            float P = (float)WantedOutcomes / TotalOutcomes;
            return P * 100; // %
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

