using GameEngine;
using Iot.Device.Ws28xx;
using System.Device.Spi;

namespace Rasberry_Pi
{
    internal sealed class StaircaseLedMatrix : IRenderTarget
    {
        private Ws2812b Strip;

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
                //Reverses every even line
                int flatIndex;
                int rowMod = ((Size.y - 1 - y) * Size.x);
                if (y % 2 == 0)
                {
                    flatIndex = rowMod + ((Size.x - 1) - x);
                }
                else
                {
                    flatIndex = rowMod + x;
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
