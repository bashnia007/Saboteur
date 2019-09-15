using CommonLibrary.CardsClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using CommonLibrary;
using CommonLibrary.Enumerations;

namespace Server
{
	public static class Validator
	{
		// Вадилатор возможности хода избранной картой - НУЖДАЕТСЯ В РЕАЛИЗАЦИИ
		public static bool ValidateActionCardUsing(ActionCard actionCard, List<ActionCard> tableActionCards)
		{

			return true;
		}

		public static bool ValidateBuildingTunnelAction(RouteCard routeCard, List<RouteCard> tableRouteCards, RoleType roleType)
		{
			//Получаем координаты, куда карточку из руки хотят положить
			int x = routeCard.Coordinates.Coordinate_X;
			int y = routeCard.Coordinates.Coordinate_Y;

			//Определяем какие карточки находятся вокруг
			RouteCard topCardFromTable = tableRouteCards.FirstOrDefault(topCard => topCard.Coordinates.Coordinate_X == x && topCard.Coordinates.Coordinate_Y == y - 1);
			RouteCard bottomCardFromTable = tableRouteCards.FirstOrDefault(bottomCard => bottomCard.Coordinates.Coordinate_X == x && bottomCard.Coordinates.Coordinate_Y == y + 1);
			RouteCard leftCardFromTable = tableRouteCards.FirstOrDefault(leftCard => leftCard.Coordinates.Coordinate_X == x - 1 && leftCard.Coordinates.Coordinate_Y == y);
			RouteCard rightCardFromTable = tableRouteCards.FirstOrDefault(rightCard => rightCard.Coordinates.Coordinate_X == x + 1 && rightCard.Coordinates.Coordinate_Y == y);

			//Создаем переменные валидаторы и проверяем каждое соединение
			bool validateTopJoining = topCardFromTable == null || (routeCard.JoiningTop == topCardFromTable.JoiningBottom);
			bool validateBottomJoining = bottomCardFromTable == null || (routeCard.JoiningBottom == bottomCardFromTable.JoiningTop);
			bool validateRightJoining = rightCardFromTable == null || (routeCard.JoiningRight == rightCardFromTable.JoiningLeft);
			bool validateLeftJoining = leftCardFromTable == null || (routeCard.JoiningLeft == leftCardFromTable.JoiningRight);

			//Вызываем метод, проверяющий возможность прохождения тунеля на данный момент
		    bool canPassTunnel = IsConnectionOpen(routeCard, roleType);// ValidateCanPassTunnel(routeCard, tableRouteCards, new RouteCard(0, 2));

			//Итоговая проверка на возможность построения карточки с руки
			return (validateTopJoining && validateBottomJoining && validateRightJoining && validateLeftJoining && canPassTunnel);
			//return (canPassTunnel);
			
		}

	    private static bool IsConnectionOpen(RouteCard routeCard, RoleType roleType)
	    {
            // bitwise operator for comparing role with connection
	        bool validateTopJoining = routeCard.NeighbourTop != null && 
                                      (((int)roleType & (int)routeCard.NeighbourTop.ConnectionBottom) != 0);
	        bool validateBottomJoining = routeCard.NeighbourBottom != null &&
	                                     (((int)roleType & (int)routeCard.NeighbourBottom.ConnectionTop) != 0);
	        bool validateRightJoining = routeCard.NeighbourRight != null && 
	                                    (((int)roleType & (int)routeCard.NeighbourRight.ConnectionLeft) != 0);
            bool validateLeftJoining = routeCard.NeighbourLeft != null &&
                                       (((int)roleType & (int)routeCard.NeighbourLeft.ConnectionRight) != 0);


            return validateTopJoining || validateBottomJoining || validateRightJoining || validateLeftJoining;
	    }

        public static bool ValidateCanPassTunnel(RouteCard routeCard, List<RouteCard> tableRouteCards, RouteCard startCard)
		{
			//Алгоритм поиска в глубину - НУЖДАЕТСЯ В РЕАЛИЗАЦИИ
			bool canPassTunnel = false;
			if (canPassTunnel == false)
			{
				canPassTunnel = true;
			}
			else canPassTunnel = false;
			return canPassTunnel;
		}
    }
}
