using Probality_calc;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Collections;

public class RollDice
{
    public string RollSuccession()
    {
        WantedNums wantednums = new WantedNums();
        List<int> nums = wantednums.GetWantedNums();
        var rand = new Random();
        string anspart1 = string.Join(", ", nums);
        string ans = $"Rolling in succession...\nWanted numbers are: {anspart1}\n";

        List<List<int>> valuelist = new List<List<int>>();
        List<int> allvalues = new List<int>();
        List<int> selectedNums = new List<int>();

        foreach (var dice in DiceStorage.diceList)
        {
            valuelist.Add(dice.Values);
        }

        foreach (var list in valuelist)
        {
            if (list.Count > 0)
            {
                int randomNumber = list[rand.Next(list.Count)];
                selectedNums.Add(randomNumber);
            }
        }

        foreach (int num in selectedNums)
        {
            ans += $"You rolled {num}.\n";
        }
        bool containsAny = nums.Intersect(selectedNums).Any();
        bool allSame = selectedNums.Distinct().Count() == 1;

        if (allSame && containsAny) ans += "All numbers where the same and in wanted numbers. You win!\n";
        else { ans += "All numbers where not the same. You lose!\n"; }

        return ans;
    }

    public string RollMoreThan()
    {
        WantedNums wantedNums = new WantedNums();
        List<int> nums = wantedNums.GetWantedNums();
        int targetnum = nums[0]; // Ottaa ensimmäisen numeron GetWantedNums:sta
        var rand = new Random();
        int sum = 0;
        string ans = $"Rolling more than {targetnum}...\n";

        List<List<int>> valuelist = new List<List<int>>();
        List<int> allvalues = new List<int>();
        List<int> selectedNums = new List<int>();

        foreach (var dice in DiceStorage.diceList)
        {
            valuelist.Add(dice.Values);
        }

        foreach (var list in valuelist)
        {
            if (list.Count > 0)
            {
                int randomNumber = list[rand.Next(list.Count)];
                selectedNums.Add(randomNumber);
            }
        }

        foreach (int num in selectedNums)
        {
            ans += $"You rolled {num}.\n";
            sum += num;
        }

        if (sum > targetnum) { ans += $"The sum of numbers rolled is {sum}\n{sum} is larger than {targetnum}. You win!\n"; }
        else { ans += $"The sum of numbers rolled is {sum}\n{sum} is not larger than {targetnum}. You lose!\n"; }

        return ans;
    }

    public string RollLessThan()
    {
        WantedNums wantedNums1 = new WantedNums();
        List<int> nums = wantedNums1.GetWantedNums();
        int targetnum = nums[0]; // Ottaa ensimmäisen numeron GetWantedNums:sta
        var rand = new Random();
        int sum = 0;
        string ans = $"Rolling less than {targetnum}...\n";

        List<List<int>> valuelist = new List<List<int>>();
        List<int> allvalues = new List<int>();
        List<int> selectedNums = new List<int>();

        foreach (var dice in DiceStorage.diceList)
        {
            valuelist.Add(dice.Values);
        }

        foreach (var list in valuelist)
        {
            if (list.Count > 0)
            {
                int randomNumber = list[rand.Next(list.Count)];
                selectedNums.Add(randomNumber);
            }
        }

        foreach (int num in selectedNums)
        {
            ans += $"You rolled {num}.\n";
            sum += num;
        }

        if (sum < targetnum) { ans += $"The sum of numbers rolled is {sum}\n{sum} is less than {targetnum}. You win!\n"; }
        else { ans += $"The sum of numbers rolled is {sum}\n{sum} is not less than {targetnum}. You lose!\n"; }

        return ans;
    }
    public string RollSumExactly()
    {
        WantedNums wantedNums2 = new WantedNums();
        List<int> nums = wantedNums2.GetWantedNums();
        int targetnum = nums[0]; // Ottaa ensimmäisen numeron GetWantedNums:sta
        var rand = new Random();
        int sum = 0;
        string ans = $"Rolling less than {targetnum}...\n";

        List<List<int>> valuelist = new List<List<int>>();
        List<int> allvalues = new List<int>();
        List<int> selectedNums = new List<int>();

        foreach (var dice in DiceStorage.diceList)
        {
            valuelist.Add(dice.Values);
        }

        foreach (var list in valuelist)
        {
            if (list.Count > 0)
            {
                int randomNumber = list[rand.Next(list.Count)];
                selectedNums.Add(randomNumber);
            }
        }

        foreach (int num in selectedNums)
        {
            ans += $"You rolled {num}.\n";
            sum += num;
        }

        if (sum == targetnum) { ans += $"The sum of numbers rolled is {sum}\nSum {sum} is the same as wanted sum. You win!\n"; }
        else { ans += $"The sum of numbers rolled is {sum}\nThe sum {sum} is not same as wanted sum. You lose!\n"; }

        return ans;
    }

}
