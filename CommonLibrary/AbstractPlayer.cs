﻿using System;
using CommonLibrary.CardsClasses;
using System.Collections.Generic;

namespace CommonLibrary
{
    [Serializable]
    public abstract class AbstractPlayer
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public RoleCard Role { get; set; }
		public List<HandCard> Hand { get; set; }
	}
}
