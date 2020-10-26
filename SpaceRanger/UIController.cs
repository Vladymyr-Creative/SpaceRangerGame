using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceRanger
{
    class UIController
    {
        public event EventHandler OnLeftPressed;
        public event EventHandler OnRightPressed;
        public event EventHandler OnSpacePressed;

        public void StartListerning()
        {
            while (true) {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key.Equals(ConsoleKey.LeftArrow)) {
                    OnLeftPressed?.Invoke(this, new EventArgs());
                }

                if (key.Key.Equals(ConsoleKey.RightArrow)) {
                    OnRightPressed?.Invoke(this, new EventArgs());
                }

                if (key.Key.Equals(ConsoleKey.Spacebar)) {
                    OnSpacePressed?.Invoke(this, new EventArgs());
                }
            }
        }
    }
}
