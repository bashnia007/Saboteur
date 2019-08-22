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
        //todo override equals method

	    public bool IsNeighbour(Coordinates neighbourCoordinates)
	    {
	        return (Coordinate_X == neighbourCoordinates.Coordinate_X &&
	                Math.Abs(neighbourCoordinates.Coordinate_Y - Coordinate_Y) == 1) ||
	               (Coordinate_Y == neighbourCoordinates.Coordinate_Y &&
	                Math.Abs(neighbourCoordinates.Coordinate_X - Coordinate_X) == 1);
	    }
	}
}
