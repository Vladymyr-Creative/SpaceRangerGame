using SpaceRanger.GameObjectFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpaceRanger
{
    class GameEngine
    {
        private bool _isNotOver;

        private static GameEngine _gameEngine;

        private Scene _scene;

        private SceneRender _sceneRender;

        private GameEngine() { }

        private GameSettings _gameSettings;

        private GameEngine(GameSettings gameSettings)
        {
            _isNotOver = true;
            _scene = Scene.GetScene(gameSettings);
            _sceneRender = new SceneRender(gameSettings);
            _gameSettings = gameSettings;            
        }

        public static GameEngine GetGameEngine(GameSettings gameSettings)
        {
            if (_gameEngine == null) {
                _gameEngine = new GameEngine(gameSettings);
            }
            return _gameEngine;
        }

        public void Run()
        {
            int swarmMoveCounter = 0;
            int playerMissileMoveCounter = 0;
            do {
                _sceneRender.Render(_scene);
                Thread.Sleep(_gameSettings.GameSpeed);
                _sceneRender.ClearScreen();                

                
                if (swarmMoveCounter >= _gameSettings.SwarmSpeed) {
                    CalculateSwarmMove();
                    swarmMoveCounter = 0;
                }

                if (playerMissileMoveCounter >= _gameSettings.PlayerShipMissileSpeed) {
                    CalculateMissileMove();
                    playerMissileMoveCounter = 0;
                }

                playerMissileMoveCounter++;
                swarmMoveCounter++;
            } while (_isNotOver);

            Console.ForegroundColor = ConsoleColor.Red;
            _sceneRender.RenderGameOver();            
        }

        public void CalculateMovePlayerShipLeft()
        {
            if (_scene.PlayerShip.GameObjectPlace.XCoordinate > 1) {
                _scene.PlayerShip.GameObjectPlace.XCoordinate--;
            }
        }

        public void CalculateMovePlayerShipRight()
        {
            if (_scene.PlayerShip.GameObjectPlace.XCoordinate < _gameSettings.ConsoleWidth) {
                _scene.PlayerShip.GameObjectPlace.XCoordinate++;

            }
        }

        public void CalculateSwarmMove()
        {
            for (int i = 0; i < _scene.Swarm.Count; i++) {
                GameObject alienShip = _scene.Swarm[i];
                alienShip.GameObjectPlace.YCoordinate++;
                if (alienShip.GameObjectPlace.YCoordinate == _scene.PlayerShip.GameObjectPlace.YCoordinate) {
                    _isNotOver = false;                    
                }                
            }
        }

        public void Shot()
        {
            PlayerShipMissileFactory missileFactory = new PlayerShipMissileFactory(_gameSettings);
            GameObject missile = missileFactory.GetGameObject(_scene.PlayerShip.GameObjectPlace);
            _scene.PlayerShipMissile.Add(missile);
            //Console.Beep(1000,200);
        }

        public void CalculateMissileMove()
        {
            if (_scene.PlayerShipMissile.Count != 0) {
                for (int i = 0; i < _scene.PlayerShipMissile.Count; i++) {
                    GameObject missile = _scene.PlayerShipMissile[i];
                    if (missile.GameObjectPlace.YCoordinate == 1) {
                        _scene.PlayerShipMissile.RemoveAt(i);
                    }
                    missile.GameObjectPlace.YCoordinate--;
                    for (int j = 0; j < _scene.Swarm.Count; j++) {
                        GameObject alienShip = _scene.Swarm[j];
                        if (missile.GameObjectPlace.Equals(alienShip.GameObjectPlace)) {
                            _scene.Swarm.RemoveAt(j);
                            _scene.PlayerShipMissile.RemoveAt(i);
                            break;
                        }
                    }
                }
            }
        }

    }
}
