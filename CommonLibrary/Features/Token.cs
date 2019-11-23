using System;
using System.Drawing;
using CommonLibrary.CardsClasses;
using CommonLibrary.Enumerations;

namespace CommonLibrary.Features
{
    [Serializable]
    public class Token
    {
        public RoleType Role { get; set; }
        public RouteCard Card { get; set; }
    }
}
