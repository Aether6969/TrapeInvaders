using GameEngine;

namespace TrapeInvaders
{
    internal static partial class Textures
    {
        private static readonly byte[] _Projectile =
            new byte[1 * 3]
            {
                1,
                1,
                1,
            };
        public static MonoColTexture Projectile = new MonoColTexture(1, 3, Pixel.HeartRed, _Projectile);
    }
}
