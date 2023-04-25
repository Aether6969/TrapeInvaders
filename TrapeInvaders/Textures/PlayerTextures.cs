using GameEngine;

namespace TrapeInvaders
{
    internal static partial class Textures
    {
        private readonly static byte[] _PlayerImage =
            new byte[7 * 5]
            {
                1, 1, 1, 1, 1, 1, 1,
                1, 1, 1, 1, 1, 1, 1,
                1, 0, 1, 1, 1, 0, 1,
                0, 0, 1, 1, 1, 0, 0,
                0, 0, 0, 1, 0, 0, 0,
            };
        public static MonoColTexture Player => new MonoColTexture(7, 5, Pixel.PlayerGreen, _PlayerImage);
    }
}
