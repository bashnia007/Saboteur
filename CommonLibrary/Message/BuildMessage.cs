using CommonLibrary.CardsClasses;
using CommonLibrary.Enumerations;
using System;

namespace CommonLibrary.Message
{
    [Serializable]
    public class BuildMessage : GameMessage
    {
        public BuildMessage()
        {
            MessageType = GameMessageType.BuildMessage;
        }
        // ID карты, которую игрок хочет построить
        public int CardId { get; set; }
        public RouteCard RouteCard { get; set; }
        // координаты, где игрок хочет построить карту тунеля
        public Coordinates Coordinates { get; set; }
        // удалось ли построить тунелль
        public bool IsSuccessfulBuild { get; set; }
    }
}
