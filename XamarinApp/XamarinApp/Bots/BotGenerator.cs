using CommonLibraryStandard;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XamarinApp.Bots
{
    public static class BotGenerator
    {
        private static List<string> BotNames = new List<string>
        {
            "Alice",
            "Angella",
            "Anna",
            "Anton",
            "Boris",
            "Charlie",
            "Dennis",
            "Ivan",
            "Michel",
            "Olga",
            "Piotr",
            "Roman",
            "Yana",
            "Yaroslav",
            "Zena"
        };

        public static List<Player> GenerateBots(int botCount)
        {
            var result = new List<Player>();
            var rnd = new Random();
            for(int i = 0; i < botCount; i++)
            {
                string name;
                do
                {
                    name = BotNames[rnd.Next(BotNames.Count)];
                }
                while (result.All(b => b.Name != name));
                result.Add(new SimpleBot(i, name + " Bot"));
            }

            return result;
        }
    }
}
