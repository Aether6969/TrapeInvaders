using GameEngine;
using Iot.Device.ExplorerHat;
using System.Device.Gpio;

namespace Rasberry_Pi
{
    internal sealed class StaircaseController : IInputManager
    {
        private GpioController Controller;

        const int Pin1 = 16, Pin2 = 20, Pin3 = 21;
        public StaircaseController()
        {
            this.Controller = new GpioController();

            Controller.OpenPin(Pin1, PinMode.Input);
            Controller.OpenPin(Pin2, PinMode.Input);
            Controller.OpenPin(Pin3, PinMode.Input);
        }

        public float Vertical => throw new NotImplementedException();

        public float Horizontal
        {
            get
            {
                bool left = false;
                bool right = false;

                if ((bool)Controller.Read(Pin1))
                {
                    left = true;
                }
                if ((bool)Controller.Read(Pin2))
                {
                    right = true;
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

            if ((bool)Controller.Read(Pin3))
            {
                pressed = true;
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
