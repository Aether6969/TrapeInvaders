namespace GameEngine
{
    public static class DigitTextures
    {
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
                0, 0, 1,
                0, 0, 1,
                0, 0, 1,
                0, 0, 1,
                0, 0, 1,
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
                1, 1, 1,
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
    }
}
