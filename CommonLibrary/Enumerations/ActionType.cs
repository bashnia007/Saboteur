﻿using System;

namespace CommonLibrary.Enumerations
{
    [Serializable]
    public enum ActionType
	{
		BreakLamp, 
		BreakPick,
		BreakTrolley,
		FixLamp, 
		FixPick,
		FixTrolly,
		SpyGoldCard,
		DestroyConnection, 
        Explore,
        Key,
	    ToPrison,
        OutPrison
	}	
}