using static TrapeInvaders.Invader;
using GameEngine;

namespace TrapeInvaders
{
    internal static partial class Textures
    {
        private readonly static byte[] _Alien1Image =
            new byte[5 * 5]
            {
                1, 0, 0, 0, 0,
                0, 1, 1, 1, 0,
                0, 0, 1, 0, 0,
                0, 0, 1, 0, 0,
                0, 0, 0, 0, 1,
            };
        public static MonoColTexture Alien1 => new MonoColTexture(5, 5, Pixel.AlienBlue, _Alien1Image);

        private readonly static byte[] _Alien2Image =
            new byte[5 * 5]
            {
                1, 0, 0, 0, 0,
                0, 1, 1, 1, 0,
                0, 1, 0, 1, 0,
                0, 1, 0, 1, 0,
                0, 0, 0, 0, 1,
            };
        public static MonoColTexture Alien2 => new MonoColTexture(5, 5, Pixel.AlienBlue, _Alien2Image);

        private readonly static byte[] _Alien3Image =
            new byte[5 * 5]
            {
                1, 0, 0, 0, 0,
                0, 1, 0, 0, 0,
                0, 1, 1, 0, 0,
                0, 1, 1, 0, 0,
                0, 0, 0, 0, 1,
            };
        public static MonoColTexture Alien3 => new MonoColTexture(5, 5, Pixel.AlienBlue, _Alien3Image);

        public static Texture GetTextureByInvader(InvaderType invaderType)
        {
            return invaderType switch
            {
                InvaderType.TopBoy => Alien1,
                InvaderType.MidBoy => Alien2,
                InvaderType.BottomBoy => Alien3,
                _ => throw new ArgumentException(nameof(invaderType)),
            };
        }
    }
}
