using System;
using CommonLibrary.Enumerations;

namespace CommonLibrary.Features
{
    [Serializable]
    public class GoldConnections
    {
        public ConnectionType FromTop { get; set; }
        public ConnectionType FromLeft { get; set; }
        public ConnectionType FromBottom { get; set; }
        public ConnectionType FromRight { get; set; }
    }
}
