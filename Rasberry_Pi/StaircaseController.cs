using GameEngine;
using System.Device.Gpio;

namespace Rasberry_Pi
{
    internal sealed class StaircaseController : IInputManager
    {
        public StaircaseController()
        {
        }

        public float Vertical => throw new NotImplementedException();

        public float Horizontal
        {
            get
            {
                bool left = false;
                bool right = false;

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();

                    if (key.KeyChar is 'a' or 'A')
                    {
                        left = true;
                    }
                    if (key.KeyChar is 'd' or 'D')
                    {
                        right = true;
                    }
                }

                if (left)
                {
                    Log.Msg("Pressed left");
                }
                if (right)
                {
                    Log.Msg("Pressed right");
                }

                return (left ? -1 : 0) + (right ? 1 : 0);
            }
        }

        public bool GetKeyShoot()
        {
            bool pressed = false;

            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey();

                if (key.KeyChar is ' ')
                {
                    pressed = true;
                }
            }

            if (pressed)
            {
                Log.Msg("Pressed shoot");
                Log.Msg("Time " + DateTime.Now.Microsecond);
            }

            return pressed;
        }
    }
}
