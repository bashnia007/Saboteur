using CommonLibrary;
using CommonLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLibrary
{
    public class Table
    {
        public List<Player> Players { get; }
        public GameType GameType { get; }

        public Table()
        {
            Players = new List<Player>();
        }

        public void AddPlayer(Player player)
        {
            Players.Add(player);
        }
    }
}
