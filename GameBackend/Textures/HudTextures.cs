using GameEngine;

namespace TrapeInvaders
{
    internal static partial class Textures
    {
        private readonly static byte[] _ScoreImage =
            new byte[19 * 5]
            {
                1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1,
                1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0,
                1, 1, 1, 0, 1, 0, 0, 0, 1, 0, 1, 0, 1, 1, 1, 0, 1, 1, 0,
                0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 1, 0, 1, 1, 0, 0, 1, 0, 0,
                1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 0, 1, 0, 1, 1, 1,
            };
        public static MonoColTexture Score => new MonoColTexture(19, 5, Pixel.PlayerGreen, _ScoreImage);

        private readonly static byte[] _HeartImage =
            new byte[5 * 5]
            {
                0, 1, 0, 1, 0,
                1, 1, 1, 1, 1,
                1, 1, 1, 1, 1,
                0, 1, 1, 1, 0,
                0, 0, 1, 0, 0,
            };
        public static MonoColTexture Heart = new MonoColTexture(5, 5, Pixel.HeartRed, _HeartImage);

        private readonly static byte[] _BottomStripImage =
            new byte[50 * 1]
            {
                1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
            };
        public static MonoColTexture BottomStrip = new MonoColTexture(50, 1, Pixel.PlayerGreen, _BottomStripImage);
    }
}
