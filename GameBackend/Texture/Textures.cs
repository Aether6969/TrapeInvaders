using TrapeInvadersEngine;

namespace TrapeInvaders
{
    internal static class Textures
    {
        public static MonoColTexture Player => new MonoColTexture(5, 5, Pixel.PlayerGreen,
            new byte[5 * 5] 
            { 
                0, 0, 1, 0, 0,
                0, 0, 1, 0, 0,
                0, 1, 1, 1, 0,
                0, 1, 1, 1, 0,
                1, 1, 1, 1, 1,
            });
    }
}
