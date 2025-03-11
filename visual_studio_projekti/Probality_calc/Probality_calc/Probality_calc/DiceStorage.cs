using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probality_calc
{
    internal static class DiceStorage
    {
        public static List<Dice> diceList = new List<Dice>();
    }



    // tää on mitkä nopat on json tiedostossa/luotu ja ladattu eli ne jotka on siinä vasemmalla puolella valittavissa. älä sekoita tohon ylempään
    internal static class LoadedDice
    {
        public static List<Dice> diceList = new List<Dice>();
    }
}

