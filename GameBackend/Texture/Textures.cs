using TrapeInvaders;
using static TrapeInvaders.Invader;

namespace TrapeInvaders
{
    internal static class Textures
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

        #region Invader
        public static MonoColTexture Player => new MonoColTexture(7, 5, Pixel.PlayerGreen, _PlayerImage);

        private readonly static byte[] _Alien1Image =
            new byte[5 * 5]
            {
                1, 0, 0, 0, 0,
                0, 0, 0, 0, 0,
                0, 0, 0, 0, 0,
                0, 0, 0, 0, 0,
                0, 0, 0, 0, 1,
            };
        public static MonoColTexture Alien1 => new MonoColTexture(5, 5, Pixel.AlienBlue, _Alien1Image);

        private readonly static byte[] _Alien2Image =
            new byte[5 * 5]
            {
                1, 0, 0, 0, 0,
                0, 0, 0, 0, 0,
                0, 0, 0, 0, 0,
                0, 0, 0, 0, 0,
                0, 0, 0, 0, 1,
            };
        public static MonoColTexture Alien2 => new MonoColTexture(5, 5, Pixel.AlienBlue, _Alien2Image);

        private readonly static byte[] _Alien3Image =
            new byte[5 * 5]
            {
                1, 0, 0, 0, 0,
                0, 0, 0, 0, 0,
                0, 0, 0, 0, 0,
                0, 0, 0, 0, 0,
                0, 0, 0, 0, 1,
            };
        public static MonoColTexture Alien3 => new MonoColTexture(5, 5, Pixel.AlienBlue, _Alien3Image);

        public static Texture GetTextureByInvader(InvaderType invaderType)
        {
            return invaderType switch
            {
                InvaderType.TopBoy =>       Alien1,
                InvaderType.MidBoy =>       Alien2,
                InvaderType.BottomBoy =>    Alien3,
                _ => throw new ArgumentException(nameof(invaderType)),
            };
        }
        #endregion

        #region Digits
        private readonly static byte[] _Digit0 =
            new byte[3 * 5]
            {
                1, 1, 1,
                1, 0, 1,
                1, 0, 1,
                1, 0, 1,
                1, 1, 1,
            };
        private readonly static byte[] _Digit1 =
            new byte[3 * 5]
            {
                0, 1, 0,
                0, 1, 0,
                0, 1, 0,
                0, 1, 0,
                0, 1, 0,
            };
        private readonly static byte[] _Digit2 =
            new byte[3 * 5]
            {
                1, 1, 1,
                0, 0, 1,
                1, 1, 1,
                1, 0, 0,
                1, 1, 1,
            };
        private readonly static byte[] _Digit3 =
            new byte[3 * 5]
            {
                1, 1, 1,
                0, 0, 1,
                1, 1, 1,
                0, 0, 1,
                1, 1, 1,
            };
        private readonly static byte[] _Digit4 =
            new byte[3 * 5]
            {
                1, 0, 1,
                1, 0, 1,
                1, 1, 1,
                0, 0, 1,
                0, 0, 1,
            };
        private readonly static byte[] _Digit5 =
            new byte[3 * 5]
            {
                1, 1, 1,
                1, 0, 0,
                1, 1, 1,
                0, 0, 1,
                1, 1, 1,
            };
        private readonly static byte[] _Digit6 =
            new byte[3 * 5]
            {
                1, 1, 1,
                1, 0, 0,
                1, 1, 1,
                1, 0, 1,
                1, 1, 1,
            };
        private readonly static byte[] _Digit7 =
            new byte[3 * 5]
            {
                1, 1, 1,
                0, 0, 1,
                0, 0, 1,
                0, 0, 1,
                0, 0, 1,
            };
        private readonly static byte[] _Digit8 =
            new byte[3 * 5]
            {
                1, 1, 1,
                1, 0, 1,
                1, 1, 1,
                1, 0, 1,
                1, 1, 1,
            };
        private readonly static byte[] _Digit9 =
            new byte[3 * 5]
            {
                1, 1, 1,
                1, 0, 1,
                1, 1, 1,
                0, 0, 1,
                0, 0, 1,
            };

        public static MonoColTexture GetTextureByDigit(byte digit)
        {
            return digit switch
            {
                0 => new MonoColTexture(3, 5, Pixel.PlayerGreen, _Digit0),
                1 => new MonoColTexture(3, 5, Pixel.PlayerGreen, _Digit1),
                2 => new MonoColTexture(3, 5, Pixel.PlayerGreen, _Digit2),
                3 => new MonoColTexture(3, 5, Pixel.PlayerGreen, _Digit3),
                4 => new MonoColTexture(3, 5, Pixel.PlayerGreen, _Digit4),
                5 => new MonoColTexture(3, 5, Pixel.PlayerGreen, _Digit5),
                6 => new MonoColTexture(3, 5, Pixel.PlayerGreen, _Digit6),
                7 => new MonoColTexture(3, 5, Pixel.PlayerGreen, _Digit7),
                8 => new MonoColTexture(3, 5, Pixel.PlayerGreen, _Digit8),
                9 => new MonoColTexture(3, 5, Pixel.PlayerGreen, _Digit9),
                _ => throw new ArgumentException(nameof(digit)),
            };
        }
        #endregion

    }
}
