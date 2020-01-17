using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibraryStandard
{
    [Serializable]
    public class Player
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public Player()
        {
        }
        public Player(string login)
        {
            Name = login;
        }
    }
}
