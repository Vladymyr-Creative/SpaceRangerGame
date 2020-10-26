using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpaceRanger
{
    class MusicController
    {
        public void PlayBackgroundMusic()
        {
            while (true) {
                Console.Beep(440, 300);
                Console.Beep(330, 300);
                Console.Beep(440, 300);
                Console.Beep(330, 300);
                Console.Beep(440, 300);
                Console.Beep(415, 300);
                Console.Beep(415, 300);
                Thread.Sleep(600);
                Console.Beep(415, 300);
                Console.Beep(330, 300);
                Console.Beep(415, 300);
                Console.Beep(330, 300);
                Console.Beep(415, 300);
                Console.Beep(440, 300);
                Console.Beep(440, 300);
                Thread.Sleep(600);
                Console.Beep(440, 300);
                Console.Beep(494, 300);
                Console.Beep(494, 100);
                Console.Beep(494, 100);
                Console.Beep(494, 300);
                Console.Beep(494, 300);
                Console.Beep(523, 300);
                Console.Beep(523, 100);
                Console.Beep(523, 100);
                Console.Beep(523, 300);
                Console.Beep(523, 300);
                Console.Beep(523, 300);
                Console.Beep(494, 300);
                Console.Beep(440, 300);
                Console.Beep(415, 300);
                Console.Beep(440, 800);
            }
        }
    }
}
