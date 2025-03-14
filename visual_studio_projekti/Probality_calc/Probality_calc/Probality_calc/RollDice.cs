using Probality_calc;
using System.Collections.Generic;
using System;

public class RollDice
{
    private List<int> GetWantedNums()
    {
        // Customize as needed
        return new List<int> { 1, 2 };
    }

    private List<int> GetWantedNum()
    {
        // Customize as needed
        return new List<int> { 18 };
    }

    public string RollSuccession()
    {
        List<int> nums = GetWantedNums();
        var rand = new Random();
        string ans = "";

        foreach (var dice in DiceStorage.diceList)
        {
            // Roll between 1 and MaxValue (inclusive)
            int Randnum = rand.Next(1, dice.MaxValue + 1);

            if (!nums.Contains(Randnum))
            {
                ans += $"{dice.Name} rolled {Randnum} \nIt was not in wanted numbers. \n";
            }
            else
            {
                nums.Clear();  // Reset list
                nums.Add(Randnum);  // Add the rolled number
                ans += $"{dice.Name} rolled {Randnum} \nIt was in the wanted numbers. \n";
            }
        }
        return ans;
    }

    public string RollMoreThan()
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
            // Roll between 1 and MaxValue (inclusive)
            int Randnum = rand.Next(1, dice.MaxValue + 1);
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
            // Roll between 1 and MaxValue (inclusive)
            int Randnum = rand.Next(1, dice.MaxValue + 1);
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
