using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceRanger
{
    class SceneRender
    {
        int _screenWigth;
        int _screenHeight;

        char[,] _screenMatrix;
        public SceneRender(GameSettings gameSettings)
        {
            _screenWigth = gameSettings.ConsoleWidth;
            _screenHeight = gameSettings.ConsoleHeight;
            _screenMatrix = new char[gameSettings.ConsoleHeight, gameSettings.ConsoleWidth];

            Console.WindowHeight = gameSettings.ConsoleHeight;
            Console.WindowWidth = gameSettings.ConsoleWidth;

            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
        }

        public void Render(Scene scene)
        {
            Console.SetCursorPosition(0, 0);
            AddListForRender(scene.Swarm);
            AddListForRender(scene.Ground);
            AddListForRender(scene.PlayerShipMissile);
            AddGameObjectForRender(scene.PlayerShip);

            StringBuilder stringBuilder = new StringBuilder();
            for (int y = 0; y < _screenHeight; y++) {
                for (int x = 0; x < _screenWigth; x++) {
                    stringBuilder.Append(_screenMatrix[y, x]);
                }
                stringBuilder.Append(Environment.NewLine);
            }
            Console.WriteLine(stringBuilder.ToString());
            Console.SetCursorPosition(0, 0);
        }

        public void AddGameObjectForRender(GameObject gameObject)
        {
            if (gameObject.GameObjectPlace.YCoordinate < _screenMatrix.GetLength(0) &&
                gameObject.GameObjectPlace.XCoordinate < _screenMatrix.GetLength(1)) {
                _screenMatrix[gameObject.GameObjectPlace.YCoordinate, gameObject.GameObjectPlace.XCoordinate] = gameObject.Figure;
            }
            else {
                ;//_screenMatrix[gameObject.GameObjectPlace.YCoordinate, gameObject.GameObjectPlace.XCoordinate] = 'a';
            }
        }

        public void AddListForRender(List<GameObject> gameObjects)
        {
            foreach (GameObject gameObject in gameObjects) {
                AddGameObjectForRender(gameObject);
            }
        }

        public void ClearScreen()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int y = 0; y < _screenHeight; y++) {
                for (int x = 0; x < _screenWigth; x++) {
                    stringBuilder.Append(' ');
                }
                stringBuilder.Append(Environment.NewLine);
            }
            Console.WriteLine(stringBuilder.ToString());
            Console.SetCursorPosition(0, 0);
        }
    }
}
