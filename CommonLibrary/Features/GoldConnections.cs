using System;

namespace CommonLibrary.Features
{
    [Serializable]
    public class GoldConnections
    {
        public bool FromTop { get; set; }
        public bool FromLeft { get; set; }
        public bool FromBottom { get; set; }
        public bool FromRight { get; set; }
    }
}
