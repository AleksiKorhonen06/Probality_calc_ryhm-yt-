using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Probality_calc
{
    internal class Logic
    {
        private List<int> GetWantedNums()
        {
            List<int> WantedNums = new List<int>() { 8, 9 }; //testaukseen. Poistaa, jos  tarve
            return WantedNums;
        }

        public string SameNumInSuccession() // sotkusta, mut toimii.
        {
            List<int> wntdnums = GetWantedNums();
            List<List<int>> valuelist = new List<List<int>>();
            List<int> sides = new List<int>();
            List<int> allvalues = new List<int>();
            List<int> validnums = new List<int>();
            List<float> all_fractions = new List<float>();

            int num_of_wntdnums = wntdnums.Count;

            if (DiceStorage.diceList.Count == 0) return "There exists no dice.";

            foreach (var dice in DiceStorage.diceList)
            {
                valuelist.Add(dice.Values);
                sides.Add(dice.Sides);
            }

            foreach (var list in valuelist)
            {
                allvalues.AddRange(list);
            }

            int totalOutcomes = allvalues.Count;

            for (int i = 0; i < num_of_wntdnums; i++)
            {
                int check_num = wntdnums[i];

                if (valuelist.All(list => list.Contains(check_num)))
                {
                    validnums.Add(check_num);
                }
            }

            foreach (var list in valuelist)
            {
                int o = 0;
                int s = list.Count;
                foreach (var num in list)
                {
                    if (validnums.Contains(num)) { o += 1; }
                }
                all_fractions.Add((float)o / s);
            }

            float P = 1;

            foreach (float num in all_fractions)
            {
                P *= num;
            }

            string WantedNumsForAns = string.Join(" or ", wntdnums);
            string ans = $"Probability of all dice rolling {WantedNumsForAns} in succession is {P * 100}%";

            return ans;
        }

        // SumExactly, SumLessThan ja SumMoreThan on vaan copy paste. En jaksa alkaa purkamaan pienemmäks.
        public string SumExactly(int WantedNum)
        {
           if (DiceStorage.diceList.Count == 0) return "There exists no dice.";

            List<List<int>> AllLists = DiceStorage.diceList.Select(d => d.Values).ToList();
            List<int> allsides = new List<int>();

            List<int> possibleSums = new List<int>();

            void FindSums(int index, int currentSum)
            {
                if (index == AllLists.Count)
                {
                    possibleSums.Add(currentSum);
                    return;
                }

                foreach (int num in AllLists[index])
                {
                    FindSums(index + 1, currentSum + num);
                }
            }

            FindSums(0, 0); // alotuskohdat

            int TotalOutcomes = possibleSums.Count;
            int WantedOutcomes = 0;
            List<int> LegitSums = new List<int>();

            foreach (int num in possibleSums)
            {
                if (num == WantedNum)
                {
                    LegitSums.Add(num);
                    WantedOutcomes++;
                }
            }

            int NumOfLegitSums = LegitSums.Count;

            float P = (float)WantedOutcomes / TotalOutcomes * 100;

            string ans = $"Probability of getting sum exactly {WantedNum} from dice is {P}%\n\nThere are {NumOfLegitSums} sums that meet the condition.\n\nThere are {TotalOutcomes} scenarios in total.";

            return ans;
        }
        public string SumLessThan(int WantedNum)
        {
            if (DiceStorage.diceList.Count == 0) return "There exists no dice.";

            List<List<int>> AllLists = DiceStorage.diceList.Select(d => d.Values).ToList();
            List<int> allsides = new List<int>();

            List<int> possibleSums = new List<int>();

            void FindSums(int index, int currentSum)
            {
                if (index == AllLists.Count)
                {
                    possibleSums.Add(currentSum);
                    return;
                }

                foreach (int num in AllLists[index])
                {
                    FindSums(index + 1, currentSum + num);
                }
            }

            FindSums(0, 0); // alotuskohdat

            int TotalOutcomes = possibleSums.Count;
            int WantedOutcomes = 0;
            List<int> LegitSums = new List<int>();

            foreach (int num in possibleSums)
            {
                if (num < WantedNum)
                {
                    LegitSums.Add(num);
                    WantedOutcomes++;
                }
            }

            int NumOfLegitSums = LegitSums.Count;

            float P = (float)WantedOutcomes / TotalOutcomes * 100;

            string ans = $"Probability of getting sum less than{WantedNum} from dice is {P}%\n\nThere are {NumOfLegitSums} sums that meet the condition.\n\nThere are {TotalOutcomes} scenarios in total.";

            return ans;
        }

        public string SumMoreThan(int WantedNum)
        {
            if (DiceStorage.diceList.Count == 0) return "There exists no dice.";

            List<List<int>> AllLists = DiceStorage.diceList.Select(d => d.Values).ToList();
            List<int> allsides = new List<int>();

            List<int> possibleSums = new List<int>();

            void FindSums(int index, int currentSum)
            {
                if (index == AllLists.Count)
                {
                    possibleSums.Add(currentSum);
                    return;
                }

                foreach (int num in AllLists[index])
                {
                    FindSums(index + 1, currentSum + num);
                }
            }

            FindSums(0, 0); // alotuskohdat

            int TotalOutcomes = possibleSums.Count;
            int WantedOutcomes = 0;
            List<int> LegitSums = new List<int>();

            foreach (int num in possibleSums)
            {
                if (num > WantedNum)
                {
                    LegitSums.Add(num);
                    WantedOutcomes++;
                }
            }

            int NumOfLegitSums = LegitSums.Count;

            float P = (float)WantedOutcomes / TotalOutcomes * 100;

            string ans = $"Probability of getting sum more than{WantedNum} from dice is {P}%\n\nThere are {NumOfLegitSums} sums that meet the condition.\n\nThere are {TotalOutcomes} scenarios in total.";

            return ans;
        }
    }
}

