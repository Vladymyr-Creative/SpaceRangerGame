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
            GameObject playerShipMissileObject = new PlayerShipMissile() {
                Figure = GameSettings.PlayerShipMissile,
                GameObjectPlace = objectPlace,
                GameObjectType = GameObjectType.PlayerShipMissile
            };

            return playerShipMissileObject;
        }        
    }
}
