using CommonLibrary.CardsClasses;
using System;

namespace CommonLibrary.Message
{
    [Serializable]
    public class RotateGoldCard : Message
    {
        public GoldCard CardToRotate { get; set; }
    }
}
