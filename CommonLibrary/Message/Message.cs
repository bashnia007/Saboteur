using System;

namespace CommonLibrary.Message
{
    [Serializable]
    public abstract class Message
    {
        public int SenderId { get; set; }
    }
}
