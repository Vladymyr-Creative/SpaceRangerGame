using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceRanger
{
    class GameSettings
    {
        //**********************************************
        // CONSOLE
        //**********************************************
        public int ConsoleWidth { get; set; } = 80;
        public int ConsoleHeight { get; set; } = 30;

        //**********************************************
        // GAME FIELD
        //**********************************************
        public int GameFieldWidth { get; set; } = 80;
        public int GameFieldHeight { get; set; } = 22;
        public int FieldStartXCoordinate { get; set; } = 1;
        public int FieldStartYCoordinate { get; set; } = 1;      
        
        //**********************************************
        // ALIEN
        //**********************************************
        public int NumberOfSwarmRows { get; set; } = 2;
        public int NumberOfSwarmColls { get; set; } = 60;

        public int SwarmStartXCoordinate { get; set; } = 10;
        public int SwarmStartYCoordinate { get; set; } = 2;

        public char AlienShip { get; set; } = 'V';
        public int SwarmSpeed { get; set; } = 100;

        //**********************************************
        // ALIEN SHIP MISSILE
        //**********************************************
        public char AlienShipMissile { get; set; } = '.';
        public int AlienShipMissileSpeed { get; set; } = 5;
        public int AlienShipMissileFrequancy { get; set; } = 100;

        //**********************************************
        // PLAYER SHIP
        //**********************************************
        public int PlayerShipStartXCoordinate { get; set; } = 40;
        public int PlayerShipStartYCoordinate { get; set; } = 19;
        public char PlayerShip { get; set; } = 'W';

        //**********************************************
        // PLAYER SHIP MISSILE
        //**********************************************
        public char PlayerShipMissile { get; set; } = '!';
        public int PlayerShipMissileSpeed { get; set; } = 5;

        //**********************************************
        // GROUND
        //**********************************************
        public int GroundStartXCoordinate { get; set; } = 10;
        public int GroundStartYCoordinate { get; set; } = 20;
        public char Ground { get; set; } = '=';
        public int NumberOfGroundRows { get; set; } = 1;
        public int NumberOfGroundColls { get; set; } = 60;

        //**********************************************
        // GAME
        //**********************************************
        public int GameSpeed { get; set; } = 101;
    }
}
