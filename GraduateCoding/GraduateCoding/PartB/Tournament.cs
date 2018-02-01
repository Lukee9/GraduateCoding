using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateCoding.PartB
{
    public class Tournament
    {
        private String[] pl;
        public Tournament(String[] players)
        {
            pl = players;
        }
        public String[] generateMatches()
        {
            List<String> matches = new List<String>(); //Each match represents 2 players playing one game with each other
            for (int match = 1; match <= 2; match++)
            {
                for (int i = 0; i < pl.Length; i++)
                {
                    for (int j = i + 1; j < pl.Length; j++)
                    {
                        switch (match)
                        {
                            case 1:
                                matches.Add($"{pl[i]} vs {pl[j]} (round: {match})");
                                break;
                            case 2:
                                matches.Add($"{pl[j]} vs {pl[i]} (round: {match})");
                                break;
                            default: //should never be hit
                                matches.Add($"{pl[i]} vs {pl[j]} (round: {match})");
                                break;
                        }
                    }
                }
            }
            return matches.ToArray<String>();
        }
        public bool outputMatches(String path)
        {
            List<String> matches = generateMatches().ToList<String>();
            int floorlength = 0;
            int ceilinglength = 0;
            int linelength;
            int startlength = 0;
            for (int i = 0; i < (pl.Length - 1) * 2; i++)
            {
                try
                {
                    floorlength = (int)Math.Ceiling((double)pl.Length / 2) - 1;
                    ceilinglength = floorlength + 1;
                    if (startlength + ceilinglength < matches.Count && matches[startlength + floorlength].Split("round".ToCharArray())[1] == matches[startlength + ceilinglength].Split("round".ToCharArray())[1])
                    {
                        linelength = ceilinglength;
                    }
                    else
                    {
                        linelength = floorlength;
                    }
                    System.IO.File.WriteAllLines($"{path}\\match{i + 1}.txt", matches.GetRange(startlength, linelength));
                    startlength += linelength;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
            }
            return true;
        }
    }
}

