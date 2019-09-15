using CommonLibrary.Enumerations;
using System;

namespace CommonLibrary.CardsClasses
{
    [Serializable]
    public class StartCard : RouteCard
    {
        #region Constructors

        public StartCard(int id) : base(id)
        {
        }

        public StartCard(int id, string imagePath) : base(id, imagePath)
        {
        }

        public StartCard(int x, int y) : base(x, y)
        {
        }

        public StartCard(int id, RouteType routeType, string imagePath) : base(id, routeType, imagePath)
        {
        }

        #endregion

        public RoleType Role { get; set; }
    }
}
