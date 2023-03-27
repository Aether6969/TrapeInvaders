using GameBackend;
using Iot.Device.Media;
using Iot.Device.Nrf24l01;
using Iot.Device.OneWire;
using Iot.Device.Ws28xx;
using System.Device.Spi;

namespace Rasberry_Pi
{
    internal sealed class StaircaseLedMatrix : IRenderTarget
    {
        Ws2812b strip;
        public int Width { get; }
        public int Height { get; }

        public StaircaseLedMatrix(int width, int height)
        {
            SpiConnectionSettings spiConnectionSettings = new SpiConnectionSettings(0, 0) 
            {
                ClockFrequency = 2_400_000,
                Mode = SpiMode.Mode0,
                DataBitLength = 8
            };
            SpiDevice spiDevice = SpiDevice.Create(spiConnectionSettings);
            this.strip = new Ws2812b(spiDevice, width * height);
            
            this.Width = width;
            this.Height = height;
        }

        public Pixel this[int x, int y] 
        { 
            set
            {
                strip.Image.SetPixel(y * Width + x, 0, value);
            }
        }

        public void Draw()
        {
            strip.Update();

            Console.WriteLine("updated strip");
        }
    }
}
