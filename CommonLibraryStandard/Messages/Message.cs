using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibraryStandard.Messages
{
    [Serializable]
    public abstract class Message
    {
        public string Id { get; set; }
        public string SenderId { get; set; }
    }
}
