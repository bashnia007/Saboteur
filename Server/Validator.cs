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

		public static bool ValidateBuildingTunnelAction(RouteCard routeCard, List<RouteCard> tableRouteCards)
		{
			//Получаем координаты, куда карточку из руки хотят положить
			int x = routeCard.Coordinates.Coordinate_X;
			int y = routeCard.Coordinates.Coordinate_Y;

			//Определяем какие карточки находятся вокруг
			RouteCard topCardFromTable = tableRouteCards.FirstOrDefault(topCard => topCard.Coordinates.Coordinate_X == x && topCard.Coordinates.Coordinate_Y == y + 1);
			RouteCard bottomCardFromTable = tableRouteCards.FirstOrDefault(bottomCard => bottomCard.Coordinates.Coordinate_X == x && bottomCard.Coordinates.Coordinate_Y == y - 1);
			RouteCard leftCardFromTable = tableRouteCards.FirstOrDefault(leftCard => leftCard.Coordinates.Coordinate_X == x - 1 && leftCard.Coordinates.Coordinate_Y == y);
			RouteCard rightCardFromTable = tableRouteCards.FirstOrDefault(rightCard => rightCard.Coordinates.Coordinate_X == x + 1 && rightCard.Coordinates.Coordinate_Y == y);

			//Создаем переменные валидаторы и проверяем каждое соединение
			bool validateTopJoining = topCardFromTable == null || (routeCard.TopJoining == topCardFromTable.BottomJoining);
			bool validateBottomJoining = bottomCardFromTable == null || (routeCard.BottomJoining == bottomCardFromTable.TopJoining);
			bool validateRightJoining = rightCardFromTable == null || (routeCard.RightJoining == rightCardFromTable.LeftJoining);
			bool validateLeftJoining = leftCardFromTable == null || (routeCard.LeftJoining == leftCardFromTable.RightJoining);

			//Вызываем метод, проверяющий возможность прохождения тунеля на данный момент
		    bool canPassTunnel = IsConnectionOpen(routeCard);// ValidateCanPassTunnel(routeCard, tableRouteCards, new RouteCard(0, 2));

			//Итоговая проверка на возможность построения карточки с руки
			//return (validateTopJoining && validateBottomJoining && validateRightJoining && validateLeftJoining && canPassTunnel);
			return (canPassTunnel);
			
		}

	    private static bool IsConnectionOpen(RouteCard routeCard)
	    {
	        int x = routeCard.Coordinates.Coordinate_X;
	        int y = routeCard.Coordinates.Coordinate_Y;

            RouteCard topCardFromTable = Table.OpenedCards.FirstOrDefault(topCard => topCard.Coordinates.Coordinate_X == x && topCard.Coordinates.Coordinate_Y == y + 1);
	        RouteCard bottomCardFromTable = Table.OpenedCards.FirstOrDefault(bottomCard => bottomCard.Coordinates.Coordinate_X == x && bottomCard.Coordinates.Coordinate_Y == y - 1);
	        RouteCard leftCardFromTable = Table.OpenedCards.FirstOrDefault(leftCard => leftCard.Coordinates.Coordinate_X == x - 1 && leftCard.Coordinates.Coordinate_Y == y);
	        RouteCard rightCardFromTable = Table.OpenedCards.FirstOrDefault(rightCard => rightCard.Coordinates.Coordinate_X == x + 1 && rightCard.Coordinates.Coordinate_Y == y);

	        bool validateTopJoining = topCardFromTable == null || topCardFromTable.BottomConnected;
	        bool validateBottomJoining = bottomCardFromTable == null || bottomCardFromTable.TopConnected;
	        bool validateRightJoining = rightCardFromTable == null || rightCardFromTable.LeftConnected;
	        bool validateLeftJoining = leftCardFromTable == null || leftCardFromTable.RightConnected;

	        return validateTopJoining && validateBottomJoining && validateRightJoining && validateLeftJoining;
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
