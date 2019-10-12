using CommonLibrary.Enumerations;
using System;

namespace CommonLibrary.CardsClasses
{
    [Serializable]
    public class StairsCard : RouteCard
    {
        #region Constructors

        public StairsCard(int id) : base(id)
        {
        }

        public StairsCard(int id, string imagePath) : base(id, imagePath)
        {
        }

        public StairsCard(int x, int y) : base(x, y)
        {
        }

        public StairsCard(int id, RouteType routeType, string imagePath) : base(id, routeType, imagePath)
        {
        }

        #endregion

        public ConnectionType Color { get; set; }
    }
}
