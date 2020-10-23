using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceRanger
{
   abstract class GameObject
    {
        public GameObjectPlace GameObjectPlace { get; set; }
        public GameObjectType GameObjectType { get; set; }
        public char Figure { get; set; }
    }
}
