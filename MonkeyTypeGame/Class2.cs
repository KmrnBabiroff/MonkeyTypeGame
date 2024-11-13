using System;
using System.Collections.Generic;
using System.IO;    
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyTypeGame
{
    public static class GameData
    {
        public static List<string> Words { get; private set; }
        public static List<string> Sentences { get; private set; }
        public static List<string> All { get; private set; }

        public static GameMode Mode { get; set; }

        static GameData()
        {
            LoadData();
        }

        private static void LoadData()
        {

            Words = new List<string>();
            Sentences = new List<string>();
            All = new List<string>();

            try
            {
                string[] lines = File.ReadAllLines("AllWordsAndSentences.txt");

                foreach (string line in lines)
                {
                    if (line.Contains(" "))
                    {
                        string[] parts = line.Split(' ');
                        if (parts.Length == 1)
                            Words.Add(parts[0]);
                        else
                            Sentences.Add(line);
                    }
                    else
                    {
                        Words.Add(line);
                    }

                    All.Add(line);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error loading data: {ex.Message}");
                throw;
            }
        }

    }
}
