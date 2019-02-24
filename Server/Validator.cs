using CommonLibrary.CardsClasses;
using System;
using System.Collections.Generic;
using System.Linq;

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
			//Получаем координаты, куда карточку из руки хотят положить
			int x = routeCard.Coordinates.Coordinate_X;
			int y = routeCard.Coordinates.Coordinate_Y;

			//Определяем какие карточки находятся вокруг
			RouteCard topCardFromTable = tableRouteCards.FirstOrDefault(topCard => topCard.Coordinates.Coordinate_X == x && topCard.Coordinates.Coordinate_Y == y + 1);
			RouteCard bottomCardFromTable = tableRouteCards.FirstOrDefault(bottomCard => bottomCard.Coordinates.Coordinate_X == x && bottomCard.Coordinates.Coordinate_Y == y - 1);
			RouteCard leftCardFromTable = tableRouteCards.FirstOrDefault(leftCard => leftCard.Coordinates.Coordinate_X == x - 1 && leftCard.Coordinates.Coordinate_Y == y);
			RouteCard rightCardFromTable = tableRouteCards.FirstOrDefault(rightCard => rightCard.Coordinates.Coordinate_X == x + 1 && rightCard.Coordinates.Coordinate_Y == y);

			//Создаем переменные валидаторы для соединений
			bool validateTopJoining = false, 
				validateBottomJoining = false, 
				validateRightJoining = false, 
				validateLeftJoining = false;

			//Проверяем каждое соединение
			if (routeCard.TopJoining == topCardFromTable.BottomJoining)
			{
				validateTopJoining = true;
			}
			if (routeCard.BottomJoining == bottomCardFromTable.TopJoining)
			{
				validateBottomJoining = true;
			}
			if (routeCard.RightJoining == rightCardFromTable.LeftJoining)
			{
				validateRightJoining = true;
			}
			if (routeCard.LeftJoining == leftCardFromTable.RightJoining)
			{
				validateLeftJoining = true;
			}

			//Вызываем метод, проверяющий возможность прохождения тунеля на данный момент
			bool canPassTunnel = ValidateCanPassTunnel();

			//Итоговая проверка на возможность построения карточки с руки
			return (validateTopJoining && validateBottomJoining && validateRightJoining && validateLeftJoining && canPassTunnel);
		}

		private bool ValidateCanPassTunnel()
		{
			throw new NotImplementedException();
		}

		public bool ValidateCanPassTunnel(RouteCard routeCard, List<RouteCard> tableRouteCards)
		{
			//Алгоритм поиска в глубину
			bool canPassTunnel = false;
			if ()
			{
				canPassTunnel = true;
			}
			else canPassTunnel = false;
			return canPassTunnel;
		}
	}
}
