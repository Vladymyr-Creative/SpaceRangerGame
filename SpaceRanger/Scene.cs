using SpaceRanger.GameObjectFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceRanger
{
    class Scene
    {
        public List<GameObject> Swarm { get; set; }

        public List<GameObject> Ground { get; set; }

        public GameObject PlayerShip { get; set; }

        public List<GameObject> PlayerShipMissile { get; set; }

        public List<GameObject> AlienShipMissile { get; set; }

        private GameSettings _gameSettings;

        private static Scene _scene;

        private Scene() { }

        private Scene(GameSettings gameSettings)
        {
            _gameSettings = gameSettings;
            Swarm = new AlienShipFactory(_gameSettings).GetSwarm();
            Ground = new GroundFactory(_gameSettings).GetGround();
            PlayerShip = new PlayerShipFactory(_gameSettings).GetPlayer();
            PlayerShipMissile = new List<GameObject>();
            AlienShipMissile = new List<GameObject>();
        }

        public Scene Reset()
        {
            return new Scene(_gameSettings);
        }

        public static Scene GetScene(GameSettings gameSettings)
        {
            if (_scene == null) {
                _scene = new Scene(gameSettings);
            }
            return _scene;
        }        
    }
}
