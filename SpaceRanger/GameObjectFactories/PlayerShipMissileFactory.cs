using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceRanger.GameObjectFactories
{
    class PlayerShipMissileFactory : GameObjectFactory
    {
        public PlayerShipMissileFactory(GameSettings gameSettings)
            :base(gameSettings)
        {

        }
        public override GameObject GetGameObject(GameObjectPlace objectPlace) 
        {
            GameObjectPlace missilePlace = new GameObjectPlace {
                XCoordinate= objectPlace.XCoordinate,
                YCoordinate=objectPlace.YCoordinate-1 
            };

            GameObject playerShipMissileObject = new PlayerShipMissile() {
                Figure = GameSettings.PlayerShipMissile,
                GameObjectPlace = missilePlace,
                GameObjectType = GameObjectType.PlayerShipMissile
            };

            return playerShipMissileObject;
        }        
    }
}
