﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms.VisualStyles;
using System.Text.Json;

namespace Probality_calc
{

    /* Ei enää käytetä, kun vaihdettiin Newtonsoft Jsoniin.

    internal static class JsonLoader
    {
        private static string filePath = "dice.json"; // nimi voi muuttaa
        
        public static List<Dice> ReadFile()
        {
            try
            {


                string jsonData = File.ReadAllText(filePath);
                List<Dice> list = JsonSerializer.Deserialize<List<Dice>>(jsonData);
                if (list == null || list.Count == 0)
                {
                    // uusi json template
                }
                return list;
            }
            catch
            {
                // uusi json template
                return new List<Dice>();
            }
        }

        public static bool SaveData(List<Dice> dice)
        {
            try
            {
                string JsonOutput = JsonSerializer.Serialize(dice);
                File.WriteAllText(filePath, JsonOutput);
                return true;
            }
            catch
            {
                return false;
            }
        }
    } */
    public class Dice
    {
        public string Name { get; set; }
        public int Sides { get; set; }
        public List<int> Values { get; set; }

        public int MaxValue { get
            {
                return Values.Max();
            } }
        public int MinValue { get
            {
                return Values.Min();
            } }


        public Dice(string name, int sides, List<int> values)
        {
            Name = name;
            Sides = sides;
            Values = values;

            if (Values == null || Values.Count == 0)
            {
                for (int i = 1; i <= sides; i++)
                {
                    Values.Add(i);
                }
            }
        }
    }


    public class AddCustomDice
    {
        string filename = "Dice.json"; //Tarvii ehkä paremman polun

        //jotain jotain
        //json:ssa jo valmiina muutamat nopat (d2, d6...)
        //pitäis keksii miten saada hyvin lisättyä uus noppa json:iin
        //tällä hetkellä en tiiä miten kannattais lähteä liikkeelle.
        public AddCustomDice()
        {
        {
            //new Dice("D6", 6, new List<int>()),
            //new Dice("D12", 12, new List<int>()),
            //new Dice("D20", 20, new List<int>()),
        };
            //Lasketaan näiden max value:
            //int diceMaxSum = diceList.Sum(e => e.MaxValue); // laskee noppien maksimiarvot yhteen
            //min value
            //int diceMinSum = diceList.Sum(e => e.MinValue); // laskee noppien minimiarvot yhteen;

        }
    }

}
