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

        public event EventHandler OnKeyQPressed;
        public event EventHandler OnEscPressed;

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

                if (key.Key.Equals(ConsoleKey.Q)) {
                    OnKeyQPressed?.Invoke(this, new EventArgs());
                }

                if (key.Key.Equals(ConsoleKey.Escape)) {
                    OnEscPressed?.Invoke(this, new EventArgs());
                }
            }
        }
    }
}
