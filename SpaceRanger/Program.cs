using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceRanger
{
    class Program
    {
        static GameEngine GameEngine;
        static GameSettings GameSettings;
        
        static void Main(string[] args)
        {
            Initialize();
            GameEngine.Run();
        }

        public static void Initialize()
        {
            GameSettings = new GameSettings();
            GameEngine= GameEngine.GetGameEngine(GameSettings);
        }
    }
}
