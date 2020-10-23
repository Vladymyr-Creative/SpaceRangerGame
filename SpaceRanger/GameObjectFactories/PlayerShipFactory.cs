using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceRanger.GameObjectFactories
{
    class PlayerShipFactory : GameObjectFactory
    {
        public PlayerShipFactory(GameSettings gameSettings)
            : base(gameSettings)
        {

        }
        public override GameObject GetGameObject(GameObjectPlace objectPlace)
        {
            GameObject playerShip = new PlayerShip() {
                Figure = GameSettings.PlayerShip,
                GameObjectPlace = objectPlace,
                GameObjectType = GameObjectType.PlayerShip
            };

            return playerShip;
        }

        public GameObject GetPlayer()
        {
            int startX = GameSettings.PlayerShipStartXCoordinate;
            int startY = GameSettings.PlayerShipStartYCoordinate;

            GameObjectPlace place = new GameObjectPlace() {
                XCoordinate = startX,
                YCoordinate = startY
            };
            GameObject playerShip = GetGameObject(place);

            return playerShip;
        }
    }
}
