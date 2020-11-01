using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            _screenWigth = gameSettings.GameFieldWidth;
            _screenHeight = gameSettings.GameFieldHeight;
            _screenMatrix = new char[gameSettings.GameFieldHeight, gameSettings.GameFieldWidth];

            Console.WindowHeight = gameSettings.ConsoleHeight;
            Console.WindowWidth = gameSettings.ConsoleWidth;

            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
        }

        public void Render(Scene scene)
        {
            ClearScreen();
            Console.SetCursorPosition(0, 0);
            AddListForRender(scene.Swarm);
            AddListForRender(scene.Ground);
            AddListForRender(scene.PlayerShipMissile);
            AddListForRender(scene.AlienShipMissile);
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
        }

        public void AddListForRender(List<GameObject> gameObjects)
        {
            foreach (GameObject gameObject in gameObjects) {
                AddGameObjectForRender(gameObject);
            }
        }

        public void ClearScreen()
        {
            for (int y = 0; y < _screenHeight-1; y++) {
                for (int x = 0; x < _screenWigth-1; x++) {
                    _screenMatrix[y, x] = ' ';
                }
            }         
            Console.SetCursorPosition(0, 0);
        }

        public void RenderGameInfo(Dictionary<string, string> gameInfo)
        {
            int cursorPosY = 28;
            string message = "Move - Left/Right; Shot - Spase; Reset - R; Exit - Q; Pause - Esc;";
            RenderMessage(message, cursorPosX: 5, cursorPosY: cursorPosY);
            cursorPosY--;
            for (int i = 0 ; i < gameInfo.Count; i++) {
                cursorPosY--;
                var item = gameInfo.ElementAt(i);
                message = $"{item.Key} number: {item.Value}";
                RenderMessage(message, cursorPosX: 5, cursorPosY: cursorPosY);
            }
        }

        public void RenderGameReset()
        {
            Console.Clear();
            string message = "Game Reset...";
            RenderMessage(message, ConsoleColor.Magenta);
            Thread.Sleep(1000);
        }

        public void RenderGameOver(bool gameIsWin)
        {            
            StringBuilder message = new StringBuilder();
            message.Append("Game Over...");       
            
            ConsoleColor color = ConsoleColor.Red;
            string IsWin = "You lost game ;(";

            if (gameIsWin) {
                IsWin = "You won game :D";
                color = ConsoleColor.Green;
            }
            message.Append(IsWin);

            RenderMessage(message.ToString(), color, cursorPosX: 25 ,cursorPosY: 10);
        }

        public void RenderGameExit()
        {
            Console.Clear();
            string message = "GoodBuy!!!";
            RenderMessage(message, ConsoleColor.Yellow);
            Thread.Sleep(1000);
            Environment.Exit(0);
        }

        public void RenderGamePaused()
        {            
            string message = "Pause ||";
           RenderMessage(message, ConsoleColor.Green);            
        }

        public void RenderMessage(string message, ConsoleColor consoleColor= ConsoleColor.White, int cursorPosX = 0, int cursorPosY = 0)
        {
            Console.SetCursorPosition(cursorPosX, cursorPosY);
            Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
            Console.SetCursorPosition(cursorPosX, cursorPosY);
            ConsoleColor prevConsoleColor = Console.ForegroundColor;
            Console.ForegroundColor = consoleColor;            
            Console.WriteLine(message);
            Console.ForegroundColor = prevConsoleColor;
            Console.SetCursorPosition(0, 0);
        }
    }
}
