using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Probality_calc;


namespace Probality_calc
{
    internal class RollDice
    {
        private List<int> GetWantedNums()
        {
            List<int> WantedNums = new List<int>() { 1, 2 }; //testaukseen. Poistaa, jos  tarve
            return WantedNums;
        }

        private List<int> GetWantedNum()
        {
            List<int> WantedNum = new List<int>() { 18 }; //testaukseen. Poistaa, jos  tarve
            return WantedNum;
        }

        public string RollSuccession()
        {
            List<int> nums = GetWantedNums();
            var rand = new Random();
            string ans = "";

            foreach (var dice in DiceStorage.diceList)
            {
                int Randnum = rand.Next(1, dice.MaxValue);

                if (!nums.Contains(Randnum))
                {
                    ans += $"{dice.Name} rolled {Randnum} \nIt was not in wanted numbers. \n";
                }

                else
                {
                    nums.Clear();  //toimii
                    nums.Add(Randnum);  //lol
                    ans += $"{dice.Name} rolled {Randnum} \nIt was in the wanted numbers. \n";
                }
            }
            return ans;
        }

        public string RollMoreThan()
        {
            List<int> numlist = GetWantedNum(); // jätän yksittäisen numeron listaan, jos helpommin onnistuu json?
            int wanted_num = numlist[0];
            int sum = 0;
            int index = 0;
            int max_amount = DiceStorage.diceList.Count;
            var rand = new Random();
            string ans = "";

            foreach (var dice in DiceStorage.diceList)
            {
                int Randnum = rand.Next(1, dice.MaxValue);
                ans += $"{dice.Name} rolled {Randnum}\n";
                sum += Randnum;
                index++;
            }

            if (sum < wanted_num && index == max_amount)
            {
                ans += $"The wanted sum was {wanted_num} or more.\nThe sum got was {sum}!\nYou Lost!";
            }

            else
            {
                ans += $"The wanted sum was {wanted_num} or more.\nThe sum got was {sum}!\nYou Won!";
            }
            return ans;
        }

        public string RollLessThan()
        {
            List<int> numlist = GetWantedNum();
            int wanted_num = numlist[0];
            int sum = 0;
            int index = 0;
            int max_amount = DiceStorage.diceList.Count;
            var rand = new Random();
            string ans = "";

            foreach (var dice in DiceStorage.diceList)
            {
                int Randnum = rand.Next(1, dice.MaxValue);
                ans += $"{dice.Name} rolled {Randnum}\n";
                sum += Randnum;
                index++;
            }

            if (sum > wanted_num && index == max_amount)
            {
                ans += $"The wanted sum was less than {wanted_num}!\nThe sum got was {sum}!\nYou Lost!";
            }

            else
            {
                ans += $"The wanted sum was less than {wanted_num}!\nThe sum got was {sum}!\nYou Won!";
            }
            return ans;
        }
    }
}
