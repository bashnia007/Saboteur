using CommonLibrary.CardsClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Server
{
	class Validator
	{
		// Вадилатор возможности хода избранной картой - НУЖДАЕТСЯ В РЕАЛИЗАЦИИ
		public bool ValidateActionCardUsing(ActionCard actionCard, List<ActionCard> tableActionCards)
		{

			return true;
		}

		public bool ValidateBuildingTunnelAction(RouteCard routeCard, List<RouteCard> tableRouteCards)
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
			bool validateTopJoining = (routeCard.TopJoining == topCardFromTable.BottomJoining);
			bool validateBottomJoining = (routeCard.BottomJoining == bottomCardFromTable.TopJoining);
			bool validateRightJoining = (routeCard.RightJoining == rightCardFromTable.LeftJoining);
			bool validateLeftJoining = (routeCard.LeftJoining == leftCardFromTable.RightJoining);

			//Вызываем метод, проверяющий возможность прохождения тунеля на данный момент
			bool canPassTunnel = ValidateCanPassTunnel(routeCard, tableRouteCards);

			//Итоговая проверка на возможность построения карточки с руки
			return (validateTopJoining && validateBottomJoining && validateRightJoining && validateLeftJoining && canPassTunnel);
			
		}

		public bool ValidateCanPassTunnel(RouteCard routeCard, List<RouteCard> tableRouteCards)
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
