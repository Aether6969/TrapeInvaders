using GameEngine;

namespace Trappeworks
{
    internal static class ExplotionTextures
    {
        public static FunctionalTexture RandomExpoltion()
        {
            int pedals = Random.Shared.Next(0, 10);
            double pedalAmp = Random.Shared.NextDouble() * 5;

            double thicknes = Random.Shared.NextDouble();
            double speed = Random.Shared.NextDouble() * 1000;

            Pixel color = Pixel.Random();

            int diameter = Random.Shared.Next(5, 100);

            Vec2 center = diameter / 2;

            Func<(int, int), Pixel> func = ((int x, int y) pix) =>
            {
                Vec2 pos = new Vec2(pix.x, pix.y) - center;
                double len = pos.Mag;

                if (len > diameter / 2) return Pixel.None;

                double angle = Math.Atan2(pos.y, pos.x);

                double timemod = (Environment.TickCount64 / (double)TimeSpan.TicksPerSecond) * 1000;

                //return color * ((len) / (diameter / 2));

                return color * Math.Abs(Math.Cos((len + Math.Sin((angle + timemod * speed) * pedals) + timemod) * thicknes));
            };

            return new FunctionalTexture(diameter, diameter, func);
        }
    }
}
