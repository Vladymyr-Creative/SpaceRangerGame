﻿using System;
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
                Console.Beep(784, 150);
                Thread.Sleep(300);
                Console.Beep(784, 150);
                Thread.Sleep(300);
                Console.Beep(932, 150);
                Thread.Sleep(150);
                Console.Beep(1047, 150);
                Thread.Sleep(150);
                Console.Beep(784, 150);
                Thread.Sleep(300);
                Console.Beep(784, 150);
                Thread.Sleep(300);
                Console.Beep(699, 150);
                Thread.Sleep(150);
                Console.Beep(740, 150);
                Thread.Sleep(150);
                Console.Beep(784, 150);
                Thread.Sleep(300);
                Console.Beep(784, 150);
                Thread.Sleep(300);
                Console.Beep(932, 150);
                Thread.Sleep(150);
                Console.Beep(1047, 150);
                Thread.Sleep(150);
                Console.Beep(784, 150);
                Thread.Sleep(300);
                Console.Beep(784, 150);
                Thread.Sleep(300);
                Console.Beep(699, 150);
                Thread.Sleep(150);
                Console.Beep(740, 150);
                Thread.Sleep(150);
                Console.Beep(932, 150);
                Console.Beep(784, 150);
                Console.Beep(587, 1200);
                Thread.Sleep(75);
                Console.Beep(932, 150);
                Console.Beep(784, 150);
                Console.Beep(554, 1200);
                Thread.Sleep(75);
                Console.Beep(932, 150);
                Console.Beep(784, 150);
                Console.Beep(523, 1200);
                Thread.Sleep(150);
                Console.Beep(466, 150);
                Console.Beep(523, 150);
            }
        }
    }
}
