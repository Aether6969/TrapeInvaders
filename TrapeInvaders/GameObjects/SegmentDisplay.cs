using GameEngine;

namespace TrapeInvaders
{
    internal sealed class SegmentDisplay : GameObj
    {
        private int _Number;
        public int Number
        {
            get
            {
                return _Number;
            }
            set
            { 
                _Number = value;
                SetDisplayToNumber(_Number);
            }

        }

        public DigitTexture[] Digits;
        public int NumDigits => Digits.Length;

        private SegmentDisplay(int numDigits, Game game, Transform transform) 
            : base(game, transform, null)
        {
            this.Digits = new DigitTexture[numDigits];

            for (int d = 0; d < Digits.Length; d++)
            {
                Digits[d] = new DigitTexture(0);
            }

            Texture = new SegmentDisplayTexture(5, Digits);
        }

        public static SegmentDisplay Create(int numDigits, Game game, Vec2 pos)
        {
            return new SegmentDisplay(numDigits, game, new Transform(pos, new Vec2(numDigits * 4, 5)));
        }

        private void SetDisplayToNumber(int number)
        {
            string digChars = number.ToString();

            if (digChars.Length > 5)
            {
                Log.Warn(new ArgumentException("The score display was set to a number greather than 5"));
            }

            for (int d = 0; d < Digits.Length; d++)
            {
                Digits[d].Digit = digChars[d] switch
                {
                    '0' => 0,
                    '1' => 0,
                    '2' => 0,
                    '3' => 0,
                    '4' => 0,
                    '5' => 0,
                    '6' => 0,
                    '7' => 0,
                    '8' => 0,
                    '9' => 0,
                    _ => throw new ArgumentException(nameof(number)),
                };
            }
        }

    }
}
