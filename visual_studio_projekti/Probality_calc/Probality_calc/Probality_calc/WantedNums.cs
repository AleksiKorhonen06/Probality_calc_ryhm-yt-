using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probality_calc
{
    public class WantedNums
    {
        public List<int> GetWantedNums()
        {
            List<int> numbers = new List<int>();
            string wantednums = GlobalString.UserInput;

            foreach (string substring in wantednums.Split(' '))
            {
                if (int.TryParse(substring, out int number))
                {
                    numbers.Add(number);
                }
            }
            return numbers;
        }
    }
    public static class GlobalString
    {
        public static string UserInput { get; set; }
    }
}
