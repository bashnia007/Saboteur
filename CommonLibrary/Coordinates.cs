using System;

namespace CommonLibrary
{
    [Serializable]
	public class Coordinates
	{
		public int Coordinate_X { get; set; }
		public int Coordinate_Y { get; set; }

	    public Coordinates(int x, int y)
	    {
	        Coordinate_X = x;
	        Coordinate_Y = y;
	    }
	}
}
