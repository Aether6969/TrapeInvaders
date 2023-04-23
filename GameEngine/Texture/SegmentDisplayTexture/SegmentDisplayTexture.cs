namespace GameEngine
{
    public sealed class SegmentDisplayTexture : Texture
    {
        public DigitTexture[] Digits;

        public SegmentDisplayTexture(int height, DigitTexture[] digits) 
            : base(digits.Length * 4, height)
        {
            this.Digits = digits;
        }

        public override Pixel this[int x, int y]
        {
            get
            {
                const int pixXperDigit = 4;

                if (x % pixXperDigit == 0)
                {
                    return Pixel.None;
                }

                DigitTexture digit = Digits[x / pixXperDigit];
                return digit[x, y];
            }
        }
    }
}
