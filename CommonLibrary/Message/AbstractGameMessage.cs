using System;
using System.Collections.Generic;

namespace CommonLibrary.Message
{
    [Serializable]
    public abstract class AbstractGameMessage : Message
    {
        public List<string> Recepients { get; }

        public AbstractGameMessage(List<string> recepients)
        {
            Recepients = recepients;
        }
    }
}
