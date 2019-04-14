using CommonLibrary.Enumerations;
using System;
using System.Collections.Generic;

namespace CommonLibrary.Message
{
	[Serializable]
	public class PlayersIdMessage : Message
	{
		public List<string> PlayersId;

		public PlayersIdMessage()
		{
			MessageType = GameMessageType.PlayersIdMessage;
		}
	}
}
