using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceRanger.GameObjectFactories
{
    class AlienShipMissileFactory : GameObjectFactory
    {
        public AlienShipMissileFactory(GameSettings gameSettings)
            :base(gameSettings)
        {

        }
        public override GameObject GetGameObject(GameObjectPlace objectPlace) 
        {
            GameObjectPlace missilePlace = new GameObjectPlace {
                XCoordinate= objectPlace.XCoordinate,
                YCoordinate=objectPlace.YCoordinate+1 
            };

            GameObject alienShipMissileObject = new AlienShipMissile() {
                Figure = GameSettings.AlienShipMissile,
                GameObjectPlace = missilePlace,
                GameObjectType = GameObjectType.AlienShipMissile
            };

            return alienShipMissileObject;
        }        
    }
}
