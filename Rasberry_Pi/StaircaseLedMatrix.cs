using TrapeInvadersEngine;
using Iot.Device.Ws28xx;
using System.Device.Spi;
using TrapeInvaders;

namespace Rasberry_Pi
{
    internal sealed class StaircaseLedMatrix : IRenderTarget
    {
        Ws2812b Strip;
        public int Width { get; }
        public int Height { get; }

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
            
            this.Width = width;
            this.Height = height;
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
                    flatIndex = (y * Width) + (Width - x);
                }
                else
                {
                    flatIndex = (y * Width) + x;
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
