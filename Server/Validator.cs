using CommonLibrary.CardsClasses;
using System;
using System.Collections.Generic;

namespace Server
{
	class Validator
	{
		public bool ValidateActionCardUsing(ActionCard actionCard, List<ActionCard> tableActionCards)
		{

			throw new NotImplementedException();
		}

		public bool ValidateBuildingTunnelAction(RouteCard routeCard, List<RouteCard> tableRouteCards)
		{
			int x = routeCard.Coordinates.Coordinate_X;
			int y = routeCard.Coordinates.Coordinate_Y;

			bool a, b, c, d;

			// Надо переписать так, чтобы булево значение карты с координатой x было равно булеву значению  карты x + 1.
			// И аналогично для других, но фиг знает как это сделать =(((((
			if (routeCard.TopJoining == true)
			{
				if (y == y + 1 && routeCard.BottomJoining == true)
				{
					return a = true;
				}
				else return a = false;
			}
			if (routeCard.BottomJoining == true)
			{
				if (y == y - 1 && routeCard.TopJoining == true)
				{
					return b = true;
				}
				else return b = false;
			}
			if (routeCard.RightJoining == true)
			{
				if (x == x + 1 && routeCard.LeftJoining == true)
				{
					return c = true;
				}
				else return c = false;
			}
			if (routeCard.LeftJoining == true)
			{
				if (x == x - 1 && routeCard.RightJoining == true)
				{
					return d = true;
				}
				else return d = false;
			}
			
			//ValidateCanPassTunnel();
			throw new NotImplementedException();
		}

		public bool ValidateCanPassTunnel(RouteCard routeCard, List<RouteCard> tableRouteCards)
		{
			throw new NotImplementedException();
		}
	}
}
