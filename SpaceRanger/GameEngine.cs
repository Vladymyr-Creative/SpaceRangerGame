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
            int alienMissileMoveCounter = 0;
            int alienMissileShotCounter = 0;
            do {
                Thread.Sleep(_gameSettings.GameSpeed);
                _sceneRender.Render(_scene);

                if (alienMissileShotCounter >= _gameSettings.AlienShipMissileFrequancy) {
                    AlienShot();
                    alienMissileShotCounter = 0;
                }

                if (alienMissileMoveCounter >= _gameSettings.AlienShipMissileSpeed) {
                    CalculateAlienMissileMove();
                    alienMissileMoveCounter = 0;
                }

                if (swarmMoveCounter >= _gameSettings.SwarmSpeed) {
                    CalculateSwarmMove();
                    swarmMoveCounter = 0;                    
                }                

                if (playerMissileMoveCounter >= _gameSettings.PlayerShipMissileSpeed) {
                    CalculatePlayerMissileMove();
                    playerMissileMoveCounter = 0;                 
                }

                alienMissileShotCounter++;
                alienMissileMoveCounter++;
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

        public void PlayerShot()
        {
            PlayerShipMissileFactory missileFactory = new PlayerShipMissileFactory(_gameSettings);
            GameObject missile = missileFactory.GetGameObject(_scene.PlayerShip.GameObjectPlace);
            _scene.PlayerShipMissile.Add(missile);
            //Console.Beep(1000,200);
        }

        public void AlienShot()
        {
            if (_scene.Swarm.Count() == 0) {
                _isNotOver = false;
            }
            else {
                var rand = new Random();
                var alien = _scene.Swarm.ElementAt(rand.Next(_scene.Swarm.Count()));
                GameObjectPlace alienPlace = alien.GameObjectPlace;

                AlienShipMissileFactory missileFactory = new AlienShipMissileFactory(_gameSettings);
                GameObject missile = missileFactory.GetGameObject(alienPlace);
                _scene.AlienShipMissile.Add(missile);
            }
        }

        public void CalculatePlayerMissileMove()
        {
            if (_scene.PlayerShipMissile.Count != 0) {
                for (int i = 0; i < _scene.PlayerShipMissile.Count; i++) {
                    GameObject missile = _scene.PlayerShipMissile[i];
                    bool missileGetTarget = false;
                    if (missile.GameObjectPlace.YCoordinate == _gameSettings.FieldStartYCoordinate) {
                        _scene.PlayerShipMissile.RemoveAt(i);
                        missileGetTarget = true;
                    }

                    if (missileGetTarget) {
                        continue;
                    }
                    for (int j = 0; j < _scene.Swarm.Count; j++) {
                        GameObject alienShip = _scene.Swarm[j];
                        if (missile.GameObjectPlace.Equals(alienShip.GameObjectPlace)) {
                            _scene.Swarm.RemoveAt(j);
                            _scene.PlayerShipMissile.RemoveAt(i);
                            missileGetTarget = true;
                            break;
                        }
                    }

                    if (missileGetTarget) {
                        continue;
                    }
                    for (int k = 0; k < _scene.AlienShipMissile.Count; k++) {
                        GameObject alienShipMissile = _scene.AlienShipMissile[k];
                        if (missile.GameObjectPlace.Equals(alienShipMissile.GameObjectPlace)) {
                            _scene.AlienShipMissile.RemoveAt(k);
                            _scene.PlayerShipMissile.RemoveAt(i);
                            missileGetTarget = true;
                            break;
                        }
                    }

                    if (missileGetTarget) {
                        continue;
                    }
                    missile.GameObjectPlace.YCoordinate--;
                    if (missile.GameObjectPlace.YCoordinate == _gameSettings.FieldStartYCoordinate) {
                        _scene.PlayerShipMissile.RemoveAt(i);
                        missileGetTarget = true;
                    }

                    if (missileGetTarget) {
                        continue;
                    }
                    for (int j = 0; j < _scene.Swarm.Count; j++) {
                        GameObject alienShip = _scene.Swarm[j];
                        if (missile.GameObjectPlace.Equals(alienShip.GameObjectPlace)) {
                            _scene.Swarm.RemoveAt(j);
                            _scene.PlayerShipMissile.RemoveAt(i);
                            missileGetTarget = true;
                            break;
                        }
                    }

                    if (missileGetTarget) {
                        continue;
                    }
                    for (int k = 0; k < _scene.AlienShipMissile.Count; k++) {
                        GameObject alienShipMissile = _scene.AlienShipMissile[k];
                        if (missile.GameObjectPlace.Equals(alienShipMissile.GameObjectPlace)) {
                            _scene.AlienShipMissile.RemoveAt(k);
                            _scene.PlayerShipMissile.RemoveAt(i);
                            missileGetTarget = true;
                            break;
                        }
                    }
                }
            }
        }

        public void CalculateAlienMissileMove()
        {
            if (_scene.AlienShipMissile.Count != 0) {
                for (int i = 0; i < _scene.AlienShipMissile.Count; i++) {
                    GameObject missile = _scene.AlienShipMissile[i];
                    if (missile.GameObjectPlace.YCoordinate == _gameSettings.GroundStartYCoordinate) {
                        _scene.AlienShipMissile.RemoveAt(i);
                    }
                    missile.GameObjectPlace.YCoordinate++;

                    GameObject playerShip = _scene.PlayerShip;
                    if (missile.GameObjectPlace.Equals(playerShip.GameObjectPlace)) {
                        _isNotOver = false;
                    }

                    for (int j = 0; j < _scene.Ground.Count; j++) {
                        GameObject ground = _scene.Ground[j];
                        if (missile.GameObjectPlace.Equals(ground.GameObjectPlace)) {
                            _scene.Ground.RemoveAt(j);
                            _scene.AlienShipMissile.RemoveAt(i);
                            break;
                        }
                    }                   
                }
            }
        }

    }
}
