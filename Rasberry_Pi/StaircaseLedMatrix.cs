using TrapeInvaders;
using Iot.Device.Ws28xx;
using System.Device.Spi;

namespace Rasberry_Pi
{
    internal sealed class StaircaseLedMatrix : IRenderTarget
    {
        Ws2812b Strip;

        public Vec2 Size { get; }

        public double GBrightness;

        public StaircaseLedMatrix(int width, int height)
        {
            SpiConnectionSettings spiConnectionSettings = new SpiConnectionSettings(0, 0) 
            {
                ClockFrequency = 2_400_000,
                Mode = SpiMode.Mode0,
                DataBitLength = 8
            };
            SpiDevice spiDevice = SpiDevice.Create(spiConnectionSettings);
            this.Strip = new Ws2812b(spiDevice, width * height);
            
            this.Size = new Vec2(width, height);
            this.GBrightness = 0.25d;
        }

        public Pixel this[int x, int y] 
        { 
            set
            {
                //Reverses every odd line
                int flatIndex;
                if (y % 2 == 1)
                {
                    flatIndex = (y * Size.x) + ((Size.x - 1) - x);
                }
                else
                {
                    flatIndex = (y * Size.x) + x;
                }

                Strip.Image.SetPixel(flatIndex, 0, value * GBrightness);
            }
        }

        public void Draw()
        {
            Strip.Update();
        }
    }
}
