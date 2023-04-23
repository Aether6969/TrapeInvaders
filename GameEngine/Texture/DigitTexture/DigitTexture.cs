using GameEngine;

namespace GameEngine
{
    public sealed class DigitTexture : Texture
    {
        public byte Digit { get; set; }
        public Pixel Color 
        { 
            get => _DigitTexture.Color; 
            set
            {
                _DigitTexture.Color = value;
            }
        }

        private MonoColTexture _DigitTexture;

        public DigitTexture(int width, int height, byte digit) : base(width, height) 
        { 
            this.Digit = digit;
            this._DigitTexture = DigitTextures.GetTextureByDigit(digit);
        }

        public override Pixel this[int x, int y] => _DigitTexture[x, y];
    }
}
