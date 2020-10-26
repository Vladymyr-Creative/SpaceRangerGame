using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpaceRanger
{
    class Program
    {
        static GameEngine GameEngine;
        static GameSettings GameSettings;
        static UIController UIController;
        static MusicController MusicController;
        
        static void Main(string[] args)
        {
            Initialize();
            GameEngine.Run();
        }

        public static void Initialize()
        {
            GameSettings = new GameSettings();
            GameEngine= GameEngine.GetGameEngine(GameSettings);
            UIController = new UIController();
            MusicController = new MusicController();

            UIController.OnLeftPressed += (obj, arg) => GameEngine.CalculateMovePlayerShipLeft();
            UIController.OnRightPressed += (obj, arg) => GameEngine.CalculateMovePlayerShipRight();
            UIController.OnSpacePressed += (obj, arg) => GameEngine.Shot();

            Thread musicTread = new Thread(MusicController.PlayBackgroundMusic);
            Thread uITread = new Thread(UIController.StartListerning);
            musicTread.Start();
            uITread.Start();
        }
    }
}